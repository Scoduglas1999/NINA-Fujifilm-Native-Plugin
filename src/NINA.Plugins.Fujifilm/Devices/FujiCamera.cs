using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using NINA.Plugins.Fujifilm.Configuration;
using NINA.Plugins.Fujifilm.Configuration.Loading;
using NINA.Plugins.Fujifilm.Diagnostics;
using NINA.Plugins.Fujifilm.Interop;
using NINA.Plugins.Fujifilm.Interop.Native;
using NINA.Plugins.Fujifilm.Settings;

namespace NINA.Plugins.Fujifilm.Devices;

[Export(typeof(FujiCamera))]
[PartCreationPolicy(CreationPolicy.NonShared)]
public sealed class FujiCamera : IAsyncDisposable
{
    private readonly IFujifilmInterop _interop;
    private readonly ICameraModelCatalog _catalog;
    private readonly IFujiSettingsProvider _settingsProvider;
    private readonly IFujifilmDiagnosticsService _diagnostics;

    private FujifilmCameraSession? _session;
    private CameraConfig? _config;
    private IReadOnlyList<int> _supportedSensitivities = Array.Empty<int>();
    private IReadOnlyDictionary<int, double> _shutterCodeToDuration = new Dictionary<int, double>();
    private bool _bulbCapable;
    private const double DefaultMinExposureSeconds = 0.001;
    private int _bufferShootCapacity;
    private int _bufferTotalCapacity;
    private int _lastModeCode;
    private int _lastAEModeCode;
    private int _lastDynamicRangeCode;
    private int _lastApiErrorCode;
    private int _lastSdkErrorCode;

    public bool SupportsBulb => _bulbCapable;

    public FujiCameraCapabilities GetCapabilitiesSnapshot()
    {
        var isoValues = GetAvailableIsoValues();
        var sensorWidth = _config?.CameraXSize ?? 0;
        var sensorHeight = _config?.CameraYSize ?? 0;
        var minExposure = GetMinExposureSecondsInternal();
        var maxExposure = GetMaxExposureSecondsInternal();
        var defaultIso = SelectClosestIsoInternal(_config?.DefaultMinSensitivity ?? (isoValues.Length > 0 ? isoValues[0] : 200));

        return new FujiCameraCapabilities(
            Array.AsReadOnly(isoValues),
            defaultIso,
            minExposure,
            maxExposure,
            _bulbCapable,
            sensorWidth,
            sensorHeight,
            _bufferShootCapacity,
            _bufferTotalCapacity,
            _lastModeCode,
            _lastAEModeCode,
            _lastDynamicRangeCode,
            _lastApiErrorCode,
            _lastSdkErrorCode);
    }

    public int[] GetAvailableIsoValues()
    {
        if (_supportedSensitivities.Count > 0)
        {
            return _supportedSensitivities.ToArray();
        }

        return BuildFallbackIsoArray();
    }

    public int SelectClosestIso(int iso)
    {
        return SelectClosestIsoInternal(iso);
    }

    public double GetMinExposureSeconds()
    {
        return GetMinExposureSecondsInternal();
    }

    public double GetMaxExposureSeconds()
    {
        return GetMaxExposureSecondsInternal();
    }

    public (int shoot, int total) GetBufferCapacity()
    {
        return (_bufferShootCapacity, _bufferTotalCapacity);
    }

    private int SelectClosestIsoInternal(int iso)
    {
        var isoValues = GetAvailableIsoValues();
        if (isoValues.Length == 0)
        {
            return iso;
        }

        var closest = isoValues[0];
        var delta = Math.Abs(iso - closest);
        foreach (var candidate in isoValues)
        {
            var currentDelta = Math.Abs(iso - candidate);
            if (currentDelta < delta)
            {
                closest = candidate;
                delta = currentDelta;
            }
        }

        return closest;
    }

    private double GetMinExposureSecondsInternal()
    {
        var timed = _shutterCodeToDuration
            .Where(pair => pair.Key != FujifilmSdkWrapper.XSDK_SHUTTER_BULB && pair.Value > 0)
            .Select(pair => pair.Value)
            .ToList();

        if (timed.Count > 0)
        {
            return timed.Min();
        }

        return _config?.DefaultMinExposure ?? DefaultMinExposureSeconds;
    }

    private double GetMaxExposureSecondsInternal()
    {
        var timed = _shutterCodeToDuration
            .Where(pair => pair.Key != FujifilmSdkWrapper.XSDK_SHUTTER_BULB && pair.Value > 0)
            .Select(pair => pair.Value)
            .ToList();

        var timedMax = timed.Count > 0 ? timed.Max() : (_config?.DefaultMaxExposure ?? 600.0);
        if (_bulbCapable)
        {
            var bulbDefault = _config?.DefaultMaxExposure ?? 3600.0;
            var bulbConfigured = _shutterCodeToDuration.TryGetValue(FujifilmSdkWrapper.XSDK_SHUTTER_BULB, out var bulbValue)
                ? bulbValue
                : bulbDefault;
            return Math.Max(timedMax, bulbConfigured);
        }

        return timedMax;
    }

    private int[] BuildFallbackIsoArray()
    {
        if (_config == null)
        {
            return Array.Empty<int>();
        }

        var minIso = _config.DefaultMinSensitivity > 0 ? _config.DefaultMinSensitivity : 160;
        var maxIso = _config.DefaultMaxSensitivity > 0 ? _config.DefaultMaxSensitivity : 12800;
        if (minIso >= maxIso)
        {
            return new[] { minIso };
        }

        return new[] { minIso, maxIso };
    }

    [ImportingConstructor]
    public FujiCamera(
        IFujifilmInterop interop,
        ICameraModelCatalog catalog,
        IFujiSettingsProvider settingsProvider,
        IFujifilmDiagnosticsService diagnostics)
    {
        _interop = interop;
        _catalog = catalog;
        _settingsProvider = settingsProvider;
        _diagnostics = diagnostics;
    }

    public bool IsConnected => _session != null && _session.Handle != IntPtr.Zero;
    public CameraConfig? Configuration => _config;
    public IReadOnlyList<int> SupportedIsoValues => _supportedSensitivities;
    public IReadOnlyDictionary<int, double> ShutterCodeToDuration => _shutterCodeToDuration;

    public async Task ConnectAsync(FujifilmCameraDescriptor descriptor, CancellationToken cancellationToken)
    {
        await _interop.InitializeAsync(cancellationToken).ConfigureAwait(false);

        if (IsConnected)
        {
            _diagnostics.RecordEvent("Camera", "Camera already connected. Disconnecting before reconnecting.");
            await DisconnectAsync().ConfigureAwait(false);
        }

        _session = await _interop.OpenCameraAsync(descriptor.DeviceId, cancellationToken).ConfigureAwait(false);
        _diagnostics.RecordEvent("Camera", $"Opened handle {_session.Handle} for {descriptor.DeviceId}");

        var priorityResult = FujifilmSdkWrapper.XSDK_SetPriorityMode(_session.Handle, FujifilmSdkWrapper.XSDK_PRIORITY_PC);
        FujifilmSdkWrapper.CheckResult(_session.Handle, priorityResult, nameof(FujifilmSdkWrapper.XSDK_SetPriorityMode));

        _config = ResolveConfiguration(descriptor.DisplayName);
        if (_config == null)
        {
            _diagnostics.RecordEvent("Camera", $"No configuration found for camera '{descriptor.DisplayName}'. Using defaults.");
        }

        if (_config != null)
        {
            ApplyConfiguration(_config);
        }

        CacheCapabilities();
        RefreshBufferCapacity();
        RefreshOperatingState();
        _diagnostics.RecordEvent("Camera", $"Fujifilm camera {descriptor.DisplayName} connected. ISO count={_supportedSensitivities.Count}, shutter codes={_shutterCodeToDuration.Count}");
    }

    public async Task DisconnectAsync()
    {
        if (_session == null)
        {
            return;
        }

        await _interop.CloseCameraAsync(_session).ConfigureAwait(false);
        await _session.DisposeAsync().ConfigureAwait(false);
        _session = null;
        _diagnostics.RecordEvent("Camera", "Fujifilm camera disconnected");
    }

    public async ValueTask DisposeAsync()
    {
        await DisconnectAsync().ConfigureAwait(false);
    }

    private CameraConfig? ResolveConfiguration(string productName)
    {
        var config = _catalog.TryGetByProductName(productName);
        if (config != null)
        {
            return config;
        }

        _diagnostics.RecordEvent("Camera", $"Could not resolve configuration for model '{productName}'");
        return null;
    }

    private void ApplyConfiguration(CameraConfig config)
    {
        if (_session == null || _session.Handle == IntPtr.Zero)
        {
            throw new InvalidOperationException("Camera session not available.");
        }

        if (_settingsProvider.Settings.ForceManualExposureMode && config.SdkConstants.ModeManual != 0)
        {
            _diagnostics.RecordEvent("Camera", $"Setting manual exposure mode (code {config.SdkConstants.ModeManual})");
            var setModeResult = FujifilmSdkWrapper.XSDK_SetMode(_session.Handle, config.SdkConstants.ModeManual);
            FujifilmSdkWrapper.CheckResult(_session.Handle, setModeResult, nameof(FujifilmSdkWrapper.XSDK_SetMode));
        }

        var setQuality = FujifilmSdkWrapper.XSDK_SetImageQuality(_session.Handle, config.SdkConstants.ImageQualityRaw);
        FujifilmSdkWrapper.CheckResult(_session.Handle, setQuality, nameof(FujifilmSdkWrapper.XSDK_SetImageQuality));

        var setCompression = FujifilmSdkWrapper.XSDK_SetRAWCompression(_session.Handle, 0);
        FujifilmSdkWrapper.CheckResult(_session.Handle, setCompression, nameof(FujifilmSdkWrapper.XSDK_SetRAWCompression));
    }

    private void CacheCapabilities()
    {
        if (_session == null || _session.Handle == IntPtr.Zero)
        {
            throw new InvalidOperationException("Camera session not available.");
        }

        _supportedSensitivities = QuerySensitivityValues();
        _shutterCodeToDuration = BuildShutterSpeedDictionary(QueryShutterCodes());
    }

    private void RefreshBufferCapacity()
    {
        if (_session == null)
        {
            _bufferShootCapacity = 0;
            _bufferTotalCapacity = 0;
            return;
        }

        var result = FujifilmSdkWrapper.XSDK_GetBufferCapacity(_session.Handle, out var shootFrames, out var totalFrames);
        if (result != FujifilmSdkWrapper.XSDK_COMPLETE)
        {
            _diagnostics.RecordEvent("Camera", $"XSDK_GetBufferCapacity failed with code {result}");
            _bufferShootCapacity = 0;
            _bufferTotalCapacity = 0;
            return;
        }

        _bufferShootCapacity = shootFrames;
        _bufferTotalCapacity = totalFrames;
    }

    private void RefreshOperatingState()
    {
        if (_session == null)
        {
            _lastModeCode = 0;
            _lastAEModeCode = 0;
            _lastDynamicRangeCode = 0;
            _lastApiErrorCode = 0;
            _lastSdkErrorCode = 0;
            return;
        }

        if (FujifilmSdkWrapper.XSDK_GetMode(_session.Handle, out var mode) == FujifilmSdkWrapper.XSDK_COMPLETE)
        {
            _lastModeCode = mode;
        }

        if (FujifilmSdkWrapper.XSDK_GetAEMode(_session.Handle, out var aeMode) == FujifilmSdkWrapper.XSDK_COMPLETE)
        {
            _lastAEModeCode = aeMode;
        }

        if (FujifilmSdkWrapper.XSDK_GetDRange(_session.Handle, out var dRange) == FujifilmSdkWrapper.XSDK_COMPLETE)
        {
            _lastDynamicRangeCode = dRange;
        }

        if (FujifilmSdkWrapper.XSDK_GetErrorNumber(_session.Handle, out var apiCode, out var errCode) == FujifilmSdkWrapper.XSDK_COMPLETE)
        {
            _lastApiErrorCode = apiCode;
            _lastSdkErrorCode = errCode;
        }
    }

    private IReadOnlyList<int> QuerySensitivityValues()
    {
        if (_session == null)
        {
            return Array.Empty<int>();
        }

        int count = 0;
        var result = FujifilmSdkWrapper.XSDK_CapSensitivity(_session.Handle, FujifilmSdkWrapper.XSDK_DRANGE_100, out count, IntPtr.Zero);
        FujifilmSdkWrapper.CheckResult(_session.Handle, result, nameof(FujifilmSdkWrapper.XSDK_CapSensitivity));

        if (count <= 0)
        {
            return Array.Empty<int>();
        }

        IntPtr buffer = Marshal.AllocHGlobal(sizeof(int) * count);
        try
        {
            result = FujifilmSdkWrapper.XSDK_CapSensitivity(_session.Handle, FujifilmSdkWrapper.XSDK_DRANGE_100, out count, buffer);
            FujifilmSdkWrapper.CheckResult(_session.Handle, result, nameof(FujifilmSdkWrapper.XSDK_CapSensitivity));
            var managed = new int[count];
            Marshal.Copy(buffer, managed, 0, count);
            Array.Sort(managed);
            return managed;
        }
        finally
        {
            if (buffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(buffer);
            }
        }
    }

    private IReadOnlyList<int> QueryShutterCodes()
    {
        if (_session == null)
        {
            return Array.Empty<int>();
        }

        int count = 0;
        int bulbCapable;
        var result = FujifilmSdkWrapper.XSDK_CapShutterSpeed(_session.Handle, out count, IntPtr.Zero, out bulbCapable);
        FujifilmSdkWrapper.CheckResult(_session.Handle, result, nameof(FujifilmSdkWrapper.XSDK_CapShutterSpeed));
        _bulbCapable = bulbCapable != 0;

        if (count <= 0)
        {
            return Array.Empty<int>();
        }

        IntPtr buffer = Marshal.AllocHGlobal(sizeof(int) * count);
        try
        {
            result = FujifilmSdkWrapper.XSDK_CapShutterSpeed(_session.Handle, out count, buffer, out bulbCapable);
            FujifilmSdkWrapper.CheckResult(_session.Handle, result, nameof(FujifilmSdkWrapper.XSDK_CapShutterSpeed));
            var managed = new int[count];
            Marshal.Copy(buffer, managed, 0, count);
            Array.Sort(managed);
            return managed;
        }
        finally
        {
            if (buffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(buffer);
            }
        }
    }

    private IReadOnlyDictionary<int, double> BuildShutterSpeedDictionary(IReadOnlyList<int> shutterCodes)
    {
        var map = new Dictionary<int, double>();
        if (_config?.ShutterSpeedMap != null && _config.ShutterSpeedMap.Count > 0)
        {
            foreach (var mapping in _config.ShutterSpeedMap)
            {
                map[mapping.SdkCode] = mapping.Duration;
            }
        }

        if (map.Count == 0)
        {
            foreach (var code in shutterCodes)
            {
                if (code <= 0)
                {
                    continue;
                }

                map[code] = 1.0 / code;
            }
        }

        if (!map.ContainsKey(FujifilmSdkWrapper.XSDK_SHUTTER_BULB))
        {
            map[FujifilmSdkWrapper.XSDK_SHUTTER_BULB] = _config?.DefaultMaxExposure ?? 3600.0;
        }

        return map;
    }

    public async Task<RawCaptureResult> CaptureRawAsync(double exposureSeconds, int iso, CancellationToken cancellationToken)
    {
        if (_session == null || _session.Handle == IntPtr.Zero)
        {
            throw new InvalidOperationException("Camera is not connected.");
        }

        if (exposureSeconds <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(exposureSeconds), "Exposure must be positive.");
        }

        if (_supportedSensitivities.Count > 0 && !_supportedSensitivities.Contains(iso))
        {
            _diagnostics.RecordEvent("Camera", $"Requested ISO {iso} not in supported list; using closest.");
            iso = _supportedSensitivities.OrderBy(value => Math.Abs(value - iso)).First();
        }

        var shutterCode = ResolveShutterCode(exposureSeconds);
        if (shutterCode == FujifilmSdkWrapper.XSDK_SHUTTER_BULB && !_bulbCapable)
        {
            throw new InvalidOperationException("Camera does not report bulb capability; exposure exceeds timed range.");
        }

        _diagnostics.RecordEvent("Camera", $"Starting exposure. Duration={exposureSeconds}s ISO={iso} ShutterCode={shutterCode}");
        var setIsoResult = FujifilmSdkWrapper.XSDK_SetSensitivity(_session.Handle, iso);
        FujifilmSdkWrapper.CheckResult(_session.Handle, setIsoResult, nameof(FujifilmSdkWrapper.XSDK_SetSensitivity));

        if (shutterCode != FujifilmSdkWrapper.XSDK_SHUTTER_BULB)
        {
            var setShutter = FujifilmSdkWrapper.XSDK_SetShutterSpeed(_session.Handle, shutterCode, 0);
            FujifilmSdkWrapper.CheckResult(_session.Handle, setShutter, nameof(FujifilmSdkWrapper.XSDK_SetShutterSpeed));
            await ExecuteTimedExposureAsync(exposureSeconds, cancellationToken).ConfigureAwait(false);
        }
        else
        {
            await ExecuteBulbExposureAsync(exposureSeconds, cancellationToken).ConfigureAwait(false);
        }

        var raw = await DownloadImageAsync(cancellationToken).ConfigureAwait(false);
        var finalized = raw with { ExposureSeconds = exposureSeconds, Iso = iso, ShutterCode = shutterCode, TimestampTicks = DateTime.UtcNow.Ticks };
        RefreshBufferCapacity();
        RefreshOperatingState();
        return finalized;
    }

    private int ResolveShutterCode(double exposureSeconds)
    {
        if (_shutterCodeToDuration.Count == 0)
        {
            return FujifilmSdkWrapper.XSDK_SHUTTER_BULB;
        }

        var closest = _shutterCodeToDuration
            .Where(pair => pair.Value <= exposureSeconds + 1e-6)
            .OrderByDescending(pair => pair.Value)
            .FirstOrDefault();

        if (closest.Key == 0)
        {
            return FujifilmSdkWrapper.XSDK_SHUTTER_BULB;
        }

        return closest.Key;
    }

    public async Task StopExposureAsync()
    {
        if (_session == null)
        {
            return;
        }

        await Task.Run(() =>
        {
            IssueReleaseCommand(FujifilmSdkWrapper.XSDK_RELEASE_N_BULBS1OFF, "Stop exposure (bulb)");
            IssueReleaseCommand(FujifilmSdkWrapper.XSDK_RELEASE_SHOOT_S1OFF, "Stop exposure (timed)");
        }).ConfigureAwait(false);

        RefreshBufferCapacity();
        RefreshOperatingState();
    }

    private async Task ExecuteTimedExposureAsync(double exposureSeconds, CancellationToken cancellationToken)
    {
        if (_session == null)
        {
            return;
        }

        IssueReleaseCommand(FujifilmSdkWrapper.XSDK_RELEASE_SHOOT_S1OFF, "Timed exposure trigger");
        var extra = TimeSpan.FromSeconds(Math.Max(1.0, Math.Min(5.0, exposureSeconds * 0.2)));
        await Task.Delay(TimeSpan.FromSeconds(exposureSeconds) + extra, cancellationToken).ConfigureAwait(false);
    }

    private async Task ExecuteBulbExposureAsync(double exposureSeconds, CancellationToken cancellationToken)
    {
        if (_session == null)
        {
            return;
        }

        IssueReleaseCommand(FujifilmSdkWrapper.XSDK_RELEASE_S1ON, "Bulb S1ON");
        var delay = Math.Max(0, _settingsProvider.Settings.BulbReleaseDelayMs);
        if (delay > 0)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(delay), cancellationToken).ConfigureAwait(false);
        }
        IssueReleaseCommand(FujifilmSdkWrapper.XSDK_RELEASE_BULBS2_ON, "Bulb start");

        await Task.Delay(TimeSpan.FromSeconds(exposureSeconds), cancellationToken).ConfigureAwait(false);
        IssueReleaseCommand(FujifilmSdkWrapper.XSDK_RELEASE_N_BULBS1OFF, "Bulb stop");
    }

    private async Task<RawCaptureResult> DownloadImageAsync(CancellationToken cancellationToken)
    {
        if (_session == null)
        {
            throw new InvalidOperationException("Camera session not available.");
        }

        const int maxAttempts = 10;
        for (var attempt = 0; attempt < maxAttempts; attempt++)
        {
            var infoResult = FujifilmSdkWrapper.XSDK_ReadImageInfo(_session.Handle, out var info);
            FujifilmSdkWrapper.CheckResult(_session.Handle, infoResult, nameof(FujifilmSdkWrapper.XSDK_ReadImageInfo));

            if (info.lDataSize > 0)
            {
                var buffer = new byte[info.lDataSize];
                var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                try
                {
                    var readResult = FujifilmSdkWrapper.XSDK_ReadImage(_session.Handle, handle.AddrOfPinnedObject(), (uint)buffer.Length);
                    FujifilmSdkWrapper.CheckResult(_session.Handle, readResult, nameof(FujifilmSdkWrapper.XSDK_ReadImage));

                    _diagnostics.RecordEvent("Camera", $"Downloaded RAW frame {info.lImagePixWidth}x{info.lImagePixHeight} bytes={buffer.Length}");
                    return new RawCaptureResult(buffer, info.lImagePixWidth, info.lImagePixHeight, info.lFormat, info.lImageBitDepth, 0, 0, 0.0, 0);
                }
                finally
                {
                    handle.Free();
                    var deleteResult = FujifilmSdkWrapper.XSDK_DeleteImage(_session.Handle);
                    if (deleteResult != FujifilmSdkWrapper.XSDK_COMPLETE)
                    {
                        _diagnostics.RecordEvent("Camera", $"XSDK_DeleteImage returned {deleteResult}");
                    }
                }
            }

            _diagnostics.RecordEvent("Camera", $"Image not ready yet (attempt {attempt + 1}). Waiting...");
            await Task.Delay(TimeSpan.FromMilliseconds(200), cancellationToken).ConfigureAwait(false);
            RefreshBufferCapacity();
            RefreshOperatingState();
        }

        throw new TimeoutException("Timed out waiting for Fujifilm image data after exposure.");
    }

    private void IssueReleaseCommand(int releaseMode, string context)
    {
        if (_session == null)
        {
            return;
        }

        IntPtr shotOptPtr = Marshal.AllocHGlobal(sizeof(long));
        try
        {
            Marshal.WriteInt64(shotOptPtr, 0L);
            var releaseResult = FujifilmSdkWrapper.XSDK_Release(_session.Handle, releaseMode, shotOptPtr, out var status);
            if (releaseResult != FujifilmSdkWrapper.XSDK_COMPLETE)
            {
                _diagnostics.RecordEvent("Camera", $"{context} failed (result={releaseResult}, status={status})");
            }
            else
            {
                _diagnostics.RecordEvent("Camera", $"{context} succeeded (status={status})");
            }
        }
        catch (Exception ex)
        {
            _diagnostics.RecordEvent("Camera", $"{context} exception: {ex.Message}");
        }
        finally
        {
            Marshal.FreeHGlobal(shotOptPtr);
        }
    }
}

public sealed record RawCaptureResult(
    byte[] RawBuffer,
    int Width,
    int Height,
    int Format,
    int BitDepth,
    int Iso,
    int ShutterCode,
    double ExposureSeconds,
    long TimestampTicks);

public sealed record FujiCameraCapabilities(
    IReadOnlyList<int> IsoValues,
    int DefaultIso,
    double MinExposureSeconds,
    double MaxExposureSeconds,
    bool SupportsBulb,
    int SensorWidth,
    int SensorHeight,
    int BufferShootCapacity,
    int BufferTotalCapacity,
    int ModeCode,
    int AEModeCode,
    int DynamicRangeCode,
    int LastApiErrorCode,
    int LastSdkErrorCode)
{
    public static FujiCameraCapabilities Empty { get; } = new(
        Array.Empty<int>(),
        0,
        0,
        0,
        false,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0);
}
