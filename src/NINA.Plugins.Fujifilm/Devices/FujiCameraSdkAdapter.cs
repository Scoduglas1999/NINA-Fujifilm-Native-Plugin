using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NINA.Core.Enum;
using NINA.Equipment.Interfaces;
using NINA.Plugins.Fujifilm.Configuration;
using NINA.Plugins.Fujifilm.Diagnostics;
using NINA.Plugins.Fujifilm.Interop;
using NINA.Plugins.Fujifilm.Interop.Native;

namespace NINA.Plugins.Fujifilm.Devices;

internal sealed class FujiCameraSdkAdapter : IGenericCameraSDK, IDisposable
{
    private readonly FujiCamera _camera;
    private readonly FujifilmCameraDescriptor _descriptor;
    private readonly IFujifilmDiagnosticsService _diagnostics;
    private readonly ILibRawAdapter _libRawAdapter;
    private readonly IDisposable _cameraLifetime;
    private readonly IDisposable _libRawLifetime;

    private readonly object _sync = new();

    private CameraConfig? _config;
    private int[] _isoValues = Array.Empty<int>();
    private int _currentIso;
    private bool _connected;

    private Task<RawCaptureResult>? _captureTask;
    private CancellationTokenSource? _captureCts;
    private double _lastExposureSeconds;

    private int _roiX;
    private int _roiY;
    private int _roiWidth;
    private int _roiHeight;
    private int _roiBin = 1;
    private bool _disposed;
    private DateTime _lastExposureStartUtc = DateTime.MinValue;
    private FujiCameraCapabilities _capabilities = FujiCameraCapabilities.Empty;

    public FujiCameraSdkAdapter(
        FujiCamera camera,
        FujifilmCameraDescriptor descriptor,
        IFujifilmDiagnosticsService diagnostics,
        ILibRawAdapter libRawAdapter,
        IDisposable cameraLifetime,
        IDisposable libRawLifetime)
    {
        _camera = camera;
        _descriptor = descriptor;
        _diagnostics = diagnostics;
        _libRawAdapter = libRawAdapter;
        _cameraLifetime = cameraLifetime;
        _libRawLifetime = libRawLifetime;
    }

    public bool Connected => _connected;

    public void Connect()
    {
        if (_connected)
        {
            return;
        }

        _camera.ConnectAsync(_descriptor, CancellationToken.None).GetAwaiter().GetResult();
        _config = _camera.Configuration;
        _capabilities = _camera.GetCapabilitiesSnapshot();
        _isoValues = _capabilities.IsoValues.Count > 0 ? CopyIsoValues(_capabilities.IsoValues) : Array.Empty<int>();
        _currentIso = _camera.SelectClosestIso(_capabilities.DefaultIso > 0 ? _capabilities.DefaultIso : (_isoValues.Length > 0 ? _isoValues[0] : 200));
        _roiX = 0;
        _roiY = 0;
        _roiWidth = _capabilities.SensorWidth > 0 ? _capabilities.SensorWidth : (_config?.CameraXSize ?? 0);
        _roiHeight = _capabilities.SensorHeight > 0 ? _capabilities.SensorHeight : (_config?.CameraYSize ?? 0);
        _roiBin = 1;
        _connected = true;
        _diagnostics.RecordEvent("Adapter", $"Connected to {_descriptor.DisplayName}");
        _diagnostics.RecordEvent("Adapter", $"Buffer capacity: {_capabilities.BufferShootCapacity}/{_capabilities.BufferTotalCapacity}");
        _diagnostics.RecordEvent("Adapter", $"State Mode={_capabilities.ModeCode}, AE={_capabilities.AEModeCode}, DR={_capabilities.DynamicRangeCode}, LastError={_capabilities.LastSdkErrorCode} (API {_capabilities.LastApiErrorCode})");
    }

    public void Disconnect()
    {
        if (!_connected)
        {
            return;
        }

        CancelCapture();
        _camera.DisconnectAsync().GetAwaiter().GetResult();
        _connected = false;
        _diagnostics.RecordEvent("Adapter", $"Disconnected {_descriptor.DisplayName}");
    }

    public int[] GetBinningInfo()
    {
        return new[] { 1 };
    }

    public (int, int) GetDimensions()
    {
        var width = _roiWidth > 0 ? _roiWidth : (_config?.CameraXSize ?? 0);
        var height = _roiHeight > 0 ? _roiHeight : (_config?.CameraYSize ?? 0);
        return (width, height);
    }

    public int GetGain() => _currentIso;

    public int GetMaxGain() => (_isoValues.Length > 0) ? _isoValues[_isoValues.Length - 1] : 0;

    public int GetMaxOffset() => 0;

    public int GetMaxUSBLimit() => 0;

    public int GetMinGain() => (_isoValues.Length > 0) ? _isoValues[0] : 0;

    public int GetMinOffset() => 0;

    public int GetMinUSBLimit() => 0;

    public int GetOffset() => 0;

    public double GetPixelSize() => _config?.PixelSizeX ?? double.NaN;

    public int GetUSBLimit() => 0;

    public SensorType GetSensorInfo() => SensorType.Color;

    public bool SetGain(int value)
    {
        _currentIso = _camera.SelectClosestIso(value);
        return true;
    }

    public bool SetOffset(int value) => false;

    public bool SetUSBLimit(int value) => false;

    public double GetMaxExposureTime() => _capabilities.MaxExposureSeconds > 0 ? _capabilities.MaxExposureSeconds : (_config?.DefaultMaxExposure ?? 600.0);

    public double GetMinExposureTime() => _capabilities.MinExposureSeconds > 0 ? _capabilities.MinExposureSeconds : (_config?.DefaultMinExposure ?? 0.001);

    public void StartExposure(double exposureTime, int width, int height)
    {
        EnsureConnected();

        lock (_sync)
        {
            if (_captureTask != null && !_captureTask.IsCompleted)
            {
                throw new InvalidOperationException("Exposure already in progress.");
            }

            _captureCts = new CancellationTokenSource();
            _lastExposureSeconds = exposureTime;

            _captureTask = Task.Run(() =>
                _camera.CaptureRawAsync(exposureTime, _currentIso, _captureCts.Token),
                CancellationToken.None);
        }
        _lastExposureStartUtc = DateTime.UtcNow;
    }

    public void StopExposure()
    {
        CancelCapture();
    }

    public bool SetROI(int startX, int startY, int width, int height, int binning)
    {
        var fullWidth = _capabilities.SensorWidth > 0 ? _capabilities.SensorWidth : (_config?.CameraXSize ?? width);
        var fullHeight = _capabilities.SensorHeight > 0 ? _capabilities.SensorHeight : (_config?.CameraYSize ?? height);
        if (startX != 0 || startY != 0 || width != fullWidth || height != fullHeight)
        {
            _diagnostics.RecordEvent("Adapter", "ROI requests are currently not supported. Falling back to full frame.");
            return false;
        }

        _roiX = startX;
        _roiY = startY;
        _roiWidth = width;
        _roiHeight = height;
        _roiBin = Math.Max(1, binning);
        return true;
    }

    public int GetBitDepth() => 16;

    public (int, int, int, int, int) GetROI() => (_roiX, _roiY, _roiWidth, _roiHeight, _roiBin);

    public bool HasTemperatureReadout() => false;

    public bool HasTemperatureControl() => false;

    public bool SetCooler(bool onOff) => false;

    public bool GetCoolerOnOff() => false;

    public bool SetTargetTemperature(double temperature) => false;

    public double GetTargetTemperature() => double.NaN;

    public double GetTemperature() => double.NaN;

    public double GetCoolerPower() => double.NaN;

    public async Task<ushort[]> GetExposure(double exposureTime, int width, int height, CancellationToken ct)
    {
        Task<RawCaptureResult>? captureTask;
        lock (_sync)
        {
            captureTask = _captureTask;
        }

        if (captureTask == null)
        {
            throw new InvalidOperationException("No exposure has been started.");
        }

        RawCaptureResult raw;
        try
        {
            raw = await captureTask.ConfigureAwait(false);
        }
        finally
        {
            lock (_sync)
            {
                _captureTask = null;
                _captureCts?.Dispose();
                _captureCts = null;
            }
        }

        var libRaw = await _libRawAdapter.ProcessRawAsync(raw.RawBuffer, ct).ConfigureAwait(false);
        if (libRaw.BayerData.Length == 0)
        {
            _diagnostics.RecordEvent("Adapter", "LibRaw conversion returned no data. Returning empty frame.");
            var fallbackWidth = raw.Width > 0 ? raw.Width : (_capabilities.SensorWidth > 0 ? _capabilities.SensorWidth : width);
            var fallbackHeight = raw.Height > 0 ? raw.Height : (_capabilities.SensorHeight > 0 ? _capabilities.SensorHeight : height);
            if (fallbackWidth <= 0 || fallbackHeight <= 0)
            {
                return Array.Empty<ushort>();
            }

            _roiWidth = fallbackWidth;
            _roiHeight = fallbackHeight;

            return new ushort[fallbackWidth * fallbackHeight];
        }

        if (libRaw.Width > 0 && libRaw.Height > 0)
        {
            _roiWidth = libRaw.Width;
            _roiHeight = libRaw.Height;
        }
        else if (raw.Width > 0 && raw.Height > 0)
        {
            _roiWidth = raw.Width;
            _roiHeight = raw.Height;
        }

        return libRaw.BayerData;
    }

    public bool IsExposureReady()
    {
        lock (_sync)
        {
            return _captureTask != null && _captureTask.IsCompleted;
        }
    }

    public bool HasDewHeater() => false;

    public bool SetDewHeater(int power) => false;

    public bool IsDewHeaterOn() => false;

    public void StartVideoCapture(double exposureTime, int width, int height)
    {
        throw new NotSupportedException("Live view is not yet supported for Fujifilm cameras.");
    }

    public void StopVideoCapture()
    {
        throw new NotSupportedException("Live view is not yet supported for Fujifilm cameras.");
    }

    public Task<ushort[]> GetVideoCapture(double exposureTime, int width, int height, CancellationToken ct)
    {
        throw new NotSupportedException("Live view is not yet supported for Fujifilm cameras.");
    }

    public List<string> GetReadoutModes() => new() { "Default" };

    public int GetReadoutMode() => 0;

    public void SetReadoutMode(int modeIndex)
    {
        if (modeIndex != 0)
        {
            _diagnostics.RecordEvent("Adapter", "Readout mode selection is not supported; defaulting to mode 0.");
        }
    }

    public bool HasAdjustableFan() => false;

    public bool SetFanPercentage(int fanPercentage) => false;

    public int GetFanPercentage() => 0;

    private void EnsureConnected()
    {
        if (!_connected)
        {
            throw new InvalidOperationException("Camera is not connected.");
        }
    }

    private void CancelCapture()
    {
        lock (_sync)
        {
            if (_captureTask == null)
            {
                return;
            }

            try
            {
                _camera.StopExposureAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                _diagnostics.RecordEvent("Adapter", $"StopExposure failed during cancel: {ex.Message}");
            }

            _captureCts?.Cancel();
            _captureTask = null;
            _captureCts?.Dispose();
            _captureCts = null;
        }
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _disposed = true;

        if (_connected)
        {
            Disconnect();
        }

        _cameraLifetime.Dispose();
        _libRawLifetime.Dispose();
    }

    private static int[] CopyIsoValues(IReadOnlyList<int> isoValues)
    {
        var result = new int[isoValues.Count];
        for (var i = 0; i < isoValues.Count; i++)
        {
            result[i] = isoValues[i];
        }

        return result;
    }
}
