using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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
public class FujiCamera : IAsyncDisposable
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
    private FujiCameraMetadata _metadata = FujiCameraMetadata.Empty;
    private IReadOnlyList<int> _rawSensitivityCodes = Array.Empty<int>();
    private IReadOnlyList<int> _rawShutterCodes = Array.Empty<int>();
    private FujifilmSdkWrapper.XSDK_DeviceInformation? _deviceInfo;
    private FujifilmSdkWrapper.XSDK_LensInformation? _lensInfo;
    private string _lensVersion = string.Empty;
    private int[] _supportedApiCodes = Array.Empty<int>();

    public bool SupportsBulb => _bulbCapable;

    public FujiCameraCapabilities GetCapabilitiesSnapshot()
    {
        var isoValues = GetAvailableIsoValues();
        var sensorWidth = _config?.CameraXSize ?? 0;
        var sensorHeight = _config?.CameraYSize ?? 0;
        var minExposure = GetMinExposureSecondsInternal();
        var maxExposure = GetMaxExposureSecondsInternal();
        var defaultIso = SelectClosestIsoInternal(_config?.DefaultMinSensitivity ?? (isoValues.Length > 0 ? isoValues[0] : 200));
        var (timedMin, timedMax, bulbMax) = GetExposureRangeSnapshot();

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
            _lastSdkErrorCode,
            _metadata,
            Array.AsReadOnly(_rawSensitivityCodes.ToArray()),
            Array.AsReadOnly(_rawShutterCodes.ToArray()),
            timedMax,
            bulbMax > 0 ? bulbMax : maxExposure);
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

    private (double TimedMin, double TimedMax, double BulbMax) GetExposureRangeSnapshot()
    {
        var timed = _shutterCodeToDuration
            .Where(pair => pair.Key != FujifilmSdkWrapper.XSDK_SHUTTER_BULB && pair.Value > 0)
            .Select(pair => pair.Value)
            .ToList();

        var timedMin = timed.Count > 0 ? timed.Min() : (_config?.DefaultMinExposure ?? DefaultMinExposureSeconds);
        var timedMax = timed.Count > 0 ? timed.Max() : (_config?.DefaultMaxExposure ?? 600.0);
        var bulbMax = 0.0;

        if (_bulbCapable)
        {
            var bulbDefault = _config?.DefaultMaxExposure ?? 3600.0;
            bulbMax = _shutterCodeToDuration.TryGetValue(FujifilmSdkWrapper.XSDK_SHUTTER_BULB, out var bulbValue)
                ? Math.Max(timedMax, bulbValue)
                : Math.Max(timedMax, bulbDefault);
        }

        return (timedMin, timedMax, bulbMax);
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
        try { System.IO.File.AppendAllText(@"c:\Users\scdou\Documents\NINA.Fujifilm.Plugin\debug_log.txt", $"[{DateTime.Now}] FujiCamera Constructor called\n"); } catch {}
        _interop = interop;
        _catalog = catalog;
        _settingsProvider = settingsProvider;
        _diagnostics = diagnostics;
    }

    public bool IsConnected => _session != null && _session.Handle != IntPtr.Zero;
    public CameraConfig? Configuration => _config;
    public FujiCameraMetadata Metadata => _metadata;
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
        TraceSdkCall(nameof(FujifilmSdkWrapper.XSDK_SetPriorityMode), priorityResult);

        RefreshDeviceMetadata();

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
        _metadata = FujiCameraMetadata.Empty;
        _supportedApiCodes = Array.Empty<int>();
        _diagnostics.RecordEvent("Camera", "Fujifilm camera disconnected");
    }

    public async ValueTask DisposeAsync()
    {
        await DisconnectAsync().ConfigureAwait(false);
    }

    private CameraConfig? ResolveConfiguration(string productName)
    {
        _diagnostics.RecordEvent("Camera", $"Resolving configuration for product name: '{productName}'");
        var config = _catalog.TryGetByProductName(productName);
        if (config != null)
        {
            _diagnostics.RecordEvent("Camera", $"Configuration found for {productName} (Model: {config.ModelName})");
            return config;
        }

        // Try stripping parenthesized text (e.g. "GFX100S (_GFX100S)" -> "GFX100S")
        var cleanName = productName.Split('(')[0].Trim();
        if (cleanName != productName)
        {
            _diagnostics.RecordEvent("Camera", $"Retrying configuration resolution with clean name: '{cleanName}'");
            config = _catalog.TryGetByProductName(cleanName);
            if (config != null)
            {
                _diagnostics.RecordEvent("Camera", $"Configuration found for {cleanName} (Model: {config.ModelName})");
                return config;
            }
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
            TraceSdkCall(nameof(FujifilmSdkWrapper.XSDK_SetMode), setModeResult);
        }

        // NOTE: XSDK_SetImageQuality does not exist in the SDK.
        // The ASCOM driver doesn't call it either. Commenting out for now.
        // var setQuality = FujifilmSdkWrapper.XSDK_SetImageQuality(_session.Handle, config.SdkConstants.ImageQualityRaw);
        // FujifilmSdkWrapper.CheckResult(_session.Handle, setQuality, nameof(FujifilmSdkWrapper.XSDK_SetImageQuality));
        // TraceSdkCall(nameof(FujifilmSdkWrapper.XSDK_SetImageQuality), setQuality);

        // NOTE: XSDK_SetRAWCompression also does not exist in the SDK.
        // Commenting out - not critical for raw capture.
        // var setCompression = FujifilmSdkWrapper.XSDK_SetRAWCompression(_session.Handle, 0);
        // FujifilmSdkWrapper.CheckResult(_session.Handle, setCompression, nameof(FujifilmSdkWrapper.XSDK_SetRAWCompression));
        // TraceSdkCall(nameof(FujifilmSdkWrapper.XSDK_SetRAWCompression), setCompression);
    }

    private void RefreshDeviceMetadata()
    {
        if (_session == null || _session.Handle == IntPtr.Zero)
        {
            _metadata = FujiCameraMetadata.Empty;
            _supportedApiCodes = Array.Empty<int>();
            return;
        }

        var handle = _session.Handle;
        int apiCount;
        var infoResult = FujifilmSdkWrapper.XSDK_GetDeviceInfoEx(handle, out var deviceInfo, out apiCount, IntPtr.Zero);
        FujifilmSdkWrapper.CheckResult(handle, infoResult, nameof(FujifilmSdkWrapper.XSDK_GetDeviceInfoEx));
        TraceSdkCall(nameof(FujifilmSdkWrapper.XSDK_GetDeviceInfoEx), infoResult);

        var apiCodes = Array.Empty<int>();
        if (apiCount > 0)
        {
            var buffer = Marshal.AllocHGlobal(sizeof(int) * apiCount);
            try
            {
                infoResult = FujifilmSdkWrapper.XSDK_GetDeviceInfoEx(handle, out deviceInfo, out apiCount, buffer);
                FujifilmSdkWrapper.CheckResult(handle, infoResult, nameof(FujifilmSdkWrapper.XSDK_GetDeviceInfoEx));
                TraceSdkCall(nameof(FujifilmSdkWrapper.XSDK_GetDeviceInfoEx), infoResult);
                apiCodes = new int[apiCount];
                Marshal.Copy(buffer, apiCodes, 0, apiCount);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        _deviceInfo = deviceInfo;
        _supportedApiCodes = apiCodes;

        _lensInfo = null;
        _lensVersion = string.Empty;

        var lensInfoResult = FujifilmSdkWrapper.XSDK_GetLensInfo(handle, out var lensInfo);
        if (lensInfoResult == FujifilmSdkWrapper.XSDK_COMPLETE)
        {
            _lensInfo = lensInfo;
        }
        TraceSdkCall(nameof(FujifilmSdkWrapper.XSDK_GetLensInfo), lensInfoResult);

        var lensVersionBuilder = new StringBuilder(256);
        var lensVersionResult = FujifilmSdkWrapper.XSDK_GetLensVersion(handle, lensVersionBuilder);
        if (lensVersionResult == FujifilmSdkWrapper.XSDK_COMPLETE)
        {
            _lensVersion = lensVersionBuilder.ToString().Trim();
        }
        TraceSdkCall(nameof(FujifilmSdkWrapper.XSDK_GetLensVersion), lensVersionResult);

        _metadata = FujiCameraMetadata.From(deviceInfo, _lensInfo, _lensVersion, _supportedApiCodes, _lastDynamicRangeCode);
        _diagnostics.RecordEvent("Camera", $"Device metadata captured (Body={_metadata.ProductName}, Lens={_metadata.LensProductName})");
    }

    private void CacheCapabilities()
    {
        if (_session == null || _session.Handle == IntPtr.Zero)
        {
            throw new InvalidOperationException("Camera session not available.");
        }

        var sensitivities = QuerySensitivityValues();
        _supportedSensitivities = sensitivities;
        _rawSensitivityCodes = sensitivities;

        var shutterCodes = QueryShutterCodes();
        _rawShutterCodes = shutterCodes;
        _shutterCodeToDuration = BuildShutterSpeedDictionary(shutterCodes);
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
        TraceSdkCall(nameof(FujifilmSdkWrapper.XSDK_GetBufferCapacity), result);

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
            TraceSdkCall(nameof(FujifilmSdkWrapper.XSDK_GetMode), FujifilmSdkWrapper.XSDK_COMPLETE);
        }

        if (FujifilmSdkWrapper.XSDK_GetAEMode(_session.Handle, out var aeMode) == FujifilmSdkWrapper.XSDK_COMPLETE)
        {
            _lastAEModeCode = aeMode;
            TraceSdkCall(nameof(FujifilmSdkWrapper.XSDK_GetAEMode), FujifilmSdkWrapper.XSDK_COMPLETE);
        }

        if (FujifilmSdkWrapper.XSDK_GetDynamicRange(_session.Handle, out var dRange) == FujifilmSdkWrapper.XSDK_COMPLETE)
        {
            _lastDynamicRangeCode = dRange;
            TraceSdkCall(nameof(FujifilmSdkWrapper.XSDK_GetDynamicRange), FujifilmSdkWrapper.XSDK_COMPLETE);
        }

        if (FujifilmSdkWrapper.XSDK_GetErrorNumber(_session.Handle, out var apiCode, out var errCode) == FujifilmSdkWrapper.XSDK_COMPLETE)
        {
            _lastApiErrorCode = apiCode;
            _lastSdkErrorCode = errCode;
            TraceSdkCall(nameof(FujifilmSdkWrapper.XSDK_GetErrorNumber), FujifilmSdkWrapper.XSDK_COMPLETE);
        }

        _metadata = _metadata with { DynamicRangeCode = _lastDynamicRangeCode };
    }

    private IReadOnlyList<int> QuerySensitivityValues()
    {
        if (_session == null)
        {
            return Array.Empty<int>();
        }

        // WORKAROUND: XSDK_CapSensitivity causes AccessViolationException on some cameras (e.g. GFX100S)
        // even with correct P/Invoke and delays. This might be an SDK bug or specific to the .NET environment.
        // To ensure stability, we return a comprehensive list of standard ISO values.
        // If the user selects an unsupported value, SetSensitivity will return an error, which is handled.
        
        _diagnostics.RecordEvent("Camera", "Using hardcoded ISO list to prevent SDK crash (AccessViolationException).");

        // Try to set Dynamic Range to 100% (Standard) as a good practice, but ignore errors/crashes
        try
        {
            int drToQuery = FujifilmSdkWrapper.XSDK_DRANGE_100;
            _diagnostics.RecordEvent("Camera", $"Setting Dynamic Range to {drToQuery} (Best Effort).");
            var drResult = FujifilmSdkWrapper.XSDK_SetDynamicRange(_session.Handle, drToQuery);
            TraceSdkCall(nameof(FujifilmSdkWrapper.XSDK_SetDynamicRange), drResult);
            // No delay needed if we aren't querying immediately
        }
        catch (Exception ex)
        {
            _diagnostics.RecordEvent("Camera", $"Warning: Exception setting Dynamic Range: {ex.Message}");
        }

        // Standard Fujifilm ISO values
        var isoList = new List<int>
        {
            100, 125, 160, 200, 250, 320, 400, 500, 640, 800,
            1000, 1250, 1600, 2000, 2500, 3200, 4000, 5000, 6400, 8000,
            10000, 12800, 25600, 51200, 102400
        };

        // Add current ISO if known and not in list?
        // We don't know current ISO without calling GetSensitivity, which might also crash?
        // Let's try to GetSensitivity safely.
        try
        {
            int currentIso;
            var result = FujifilmSdkWrapper.XSDK_GetSensitivity(_session.Handle, out currentIso);
            if (result == FujifilmSdkWrapper.XSDK_COMPLETE)
            {
                if (!isoList.Contains(currentIso) && currentIso > 0)
                {
                    isoList.Add(currentIso);
                    isoList.Sort();
                }
            }
        }
        catch
        {
            // Ignore errors getting current ISO
        }

        return isoList;
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
        TraceSdkCall(nameof(FujifilmSdkWrapper.XSDK_CapShutterSpeed), result);

        if (count <= 0)
        {
            return Array.Empty<int>();
        }

        IntPtr buffer = Marshal.AllocHGlobal(sizeof(int) * count);
        try
        {
            result = FujifilmSdkWrapper.XSDK_CapShutterSpeed(_session.Handle, out count, buffer, out bulbCapable);
            FujifilmSdkWrapper.CheckResult(_session.Handle, result, nameof(FujifilmSdkWrapper.XSDK_CapShutterSpeed));
            TraceSdkCall(nameof(FujifilmSdkWrapper.XSDK_CapShutterSpeed), result);
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

        // If map is empty (e.g. missing from JSON), populate with standard defaults
        // If map is empty (e.g. missing from JSON), populate with standard defaults from ASCOM driver
        if (map.Count == 0)
        {
            _diagnostics.RecordEvent("Camera", "Shutter speed map missing from config; using standard defaults from ASCOM driver.");
            
            // Mappings based on SDK PDF pp. 91-95 (copied from ASCOM driver)
            // These are generally consistent across models.
            var defaults = new Dictionary<int, double>
            {
                { 5, 1.0 / 180000.0 }, { 6, 1.0 / 160000.0 }, { 7, 1.0 / 128000.0 },
                { 9, 1.0 / 102400.0 }, { 12, 1.0 / 80000.0 }, { 15, 1.0 / 64000.0 },
                { 19, 1.0 / 51200.0 }, { 24, 1.0 / 40000.0 }, { 30, 1.0 / 32000.0 },
                { 38, 1.0 / 25600.0 }, { 43, 1.0 / 24000.0 }, { 48, 1.0 / 20000.0 },
                { 61, 1.0 / 16000.0 }, { 76, 1.0 / 12800.0 }, { 86, 1.0 / 12000.0 },
                { 96, 1.0 / 10000.0 }, { 122, 1.0 / 8000.0 }, { 153, 1.0 / 6400.0 },
                { 172, 1.0 / 6000.0 }, { 193, 1.0 / 5000.0 }, { 244, 1.0 / 4000.0 },
                { 307, 1.0 / 3200.0 }, { 345, 1.0 / 3000.0 }, { 387, 1.0 / 2500.0 },
                { 488, 1.0 / 2000.0 }, { 615, 1.0 / 1600.0 }, { 690, 1.0 / 1500.0 },
                { 775, 1.0 / 1250.0 }, { 976, 1.0 / 1000.0 }, { 1230, 1.0 / 800.0 },
                { 1381, 1.0 / 750.0 }, { 1550, 1.0 / 640.0 }, { 1953, 1.0 / 500.0 },
                { 2460, 1.0 / 400.0 }, { 2762, 1.0 / 350.0 }, { 3100, 1.0 / 320.0 },
                { 3906, 1.0 / 250.0 }, { 4921, 1.0 / 200.0 }, { 5524, 1.0 / 180.0 },
                { 6200, 1.0 / 160.0 }, { 7812, 1.0 / 125.0 }, { 9843, 1.0 / 100.0 },
                { 11048, 1.0 / 90.0 }, { 12401, 1.0 / 80.0 }, { 15625, 1.0 / 60.0 },
                { 19686, 1.0 / 50.0 }, { 22097, 1.0 / 45.0 }, { 24803, 1.0 / 40.0 },
                { 31250, 1.0 / 30.0 }, { 39372, 1.0 / 25.0 }, { 49606, 1.0 / 20.0 },
                { 62500, 1.0 / 15.0 }, { 78745, 1.0 / 13.0 }, { 99212, 1.0 / 10.0 },
                { 125000, 1.0 / 8.0 }, { 157490, 1.0 / 6.0 }, { 198425, 1.0 / 5.0 },
                { 250000, 1.0 / 4.0 }, { 314980, 1.0 / 3.0 }, { 396850, 1.0 / 2.5 },
                { 500000, 1.0 / 2.0 }, { 629960, 1.0 / 1.6 }, { 707106, 1.0 / 1.5 },
                { 793700, 1.0 / 1.3 }, { 1000000, 1.0 }, { 1259921, 1.3 },
                { 1414213, 1.5 }, { 1587401, 1.6 }, { 2000000, 2.0 },
                { 2519842, 2.5 }, { 3174802, 3.0 }, { 4000000, 4.0 },
                { 5039684, 5.0 }, { 6349604, 6.0 }, { 8000000, 8.0 },
                { 10079368, 10.0 }, { 12699208, 13.0 }, { 16000000, 15.0 },
                { 20158736, 20.0 }, { 25398416, 25.0 }, { 32000000, 30.0 },
                { 64000000, 60.0 }
            };

            // Only add codes that are actually supported by the camera
            foreach (var kvp in defaults)
            {
                // We can check if the code exists in shutterCodes, but shutterCodes might be incomplete?
                // The ASCOM driver filters by supportedShutterSpeeds.
                // Let's do the same: only add if it's in the supported list (shutterCodes).
                // However, shutterCodes is a List<int>.
                // Note: shutterCodes comes from QueryShutterCodes -> XSDK_CapShutterSpeed.
                
                // Efficient check:
                if (shutterCodes.Contains(kvp.Key))
                {
                    map[kvp.Key] = kvp.Value;
                }
            }
            
            // Also ensure we have at least something if the intersection is empty (unlikely)
            if (map.Count == 0 && shutterCodes.Count > 0)
            {
                 _diagnostics.RecordEvent("Camera", "Warning: No standard shutter codes matched camera capabilities. Falling back to 1.0/code heuristic.");
                 foreach (var code in shutterCodes)
                 {
                     if (code <= 0) continue;
                     map[code] = 1.0 / code;
                 }
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
        TraceSdkCall(nameof(FujifilmSdkWrapper.XSDK_SetSensitivity), setIsoResult);

        if (shutterCode != FujifilmSdkWrapper.XSDK_SHUTTER_BULB)
        {
            var setShutter = FujifilmSdkWrapper.XSDK_SetShutterSpeed(_session.Handle, shutterCode, 0);
            FujifilmSdkWrapper.CheckResult(_session.Handle, setShutter, nameof(FujifilmSdkWrapper.XSDK_SetShutterSpeed));
            TraceSdkCall(nameof(FujifilmSdkWrapper.XSDK_SetShutterSpeed), setShutter);
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
            TraceSdkCall(nameof(FujifilmSdkWrapper.XSDK_ReadImageInfo), infoResult);

            if (info.lDataSize > 0)
            {
                var buffer = new byte[info.lDataSize];
                var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                try
                {
                    var readResult = FujifilmSdkWrapper.XSDK_ReadImage(_session.Handle, handle.AddrOfPinnedObject(), (uint)buffer.Length);
                    FujifilmSdkWrapper.CheckResult(_session.Handle, readResult, nameof(FujifilmSdkWrapper.XSDK_ReadImage));
                    TraceSdkCall(nameof(FujifilmSdkWrapper.XSDK_ReadImage), readResult);

                    // Diagnostic logging for black image investigation
                    var sampleBytes = string.Join(" ", buffer.Take(20).Select(b => b.ToString("X2")));
                    _diagnostics.RecordEvent("FujiCamera", $"Downloaded image: Size={buffer.Length} bytes, First 20 bytes: {sampleBytes}");

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
                    TraceSdkCall(nameof(FujifilmSdkWrapper.XSDK_DeleteImage), deleteResult);
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
            TraceSdkCall(nameof(FujifilmSdkWrapper.XSDK_Release), releaseResult);
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

    private void TraceSdkCall(string apiName, int result)
    {
        if (!_settingsProvider.Settings.EnableSdkTrace)
        {
            return;
        }

        try
        {
            var handle = _session?.Handle ?? IntPtr.Zero;
            var error = FujifilmSdkWrapper.GetLastError(handle);
            _diagnostics.RecordSdkCall(apiName, result, error.ApiCode, error.ErrorCode);
        }
        catch (Exception ex)
        {
            _diagnostics.RecordEvent("SDKTrace", $"Trace capture failed for {apiName}: {ex.Message}");
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
    int LastSdkErrorCode,
    FujiCameraMetadata Metadata,
    IReadOnlyList<int> RawIsoCodes,
    IReadOnlyList<int> RawShutterCodes,
    double TimedExposureMaxSeconds,
    double BulbExposureMaxSeconds)
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
        0,
        FujiCameraMetadata.Empty,
        Array.Empty<int>(),
        Array.Empty<int>(),
        0,
        0);
}

public sealed record FujiCameraMetadata(
    string ProductName,
    string SerialNumber,
    string FirmwareVersion,
    string DeviceName,
    string LensProductName,
    string LensSerialNumber,
    string LensVersion,
    IReadOnlyList<int> SupportedApiCodes,
    int DynamicRangeCode)
{
    public static FujiCameraMetadata Empty { get; } = new(
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        Array.Empty<int>(),
        0);

    internal static FujiCameraMetadata From(
        FujifilmSdkWrapper.XSDK_DeviceInformation deviceInfo,
        FujifilmSdkWrapper.XSDK_LensInformation? lensInfo,
        string lensVersion,
        IReadOnlyList<int> apiCodes,
        int dynamicRangeCode)
    {
        var codes = apiCodes?.ToArray() ?? Array.Empty<int>();
        var lens = lensInfo ?? new FujifilmSdkWrapper.XSDK_LensInformation();
        return new FujiCameraMetadata(
            deviceInfo.strProduct?.Trim() ?? string.Empty,
            deviceInfo.strSerialNo?.Trim() ?? string.Empty,
            deviceInfo.strFirmware?.Trim() ?? string.Empty,
            deviceInfo.strDeviceName?.Trim() ?? string.Empty,
            lens.strProductName?.Trim() ?? string.Empty,
            lens.strSerialNo?.Trim() ?? string.Empty,
            lensVersion?.Trim() ?? string.Empty,
            Array.AsReadOnly(codes),
            dynamicRangeCode);
    }
}
