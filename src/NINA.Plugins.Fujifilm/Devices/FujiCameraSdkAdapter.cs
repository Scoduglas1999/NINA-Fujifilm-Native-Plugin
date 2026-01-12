using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using NINA.Core.Enum;
﻿using NINA.Core.Utility;
using NINA.Equipment.Interfaces;
using NINA.Equipment.Interfaces.ViewModel;
using NINA.Image.Interfaces;
using NINA.Plugin.Interfaces;
using NINA.Plugins.Fujifilm.Configuration;
using NINA.Plugins.Fujifilm.Devices.LiveView;
using NINA.Plugins.Fujifilm.Diagnostics;
using NINA.Plugins.Fujifilm.Imaging;
using NINA.Plugins.Fujifilm.Interop;
using NINA.Plugins.Fujifilm.Interop.Native;
using NINA.Plugins.Fujifilm.Settings;
using NINA.Profile.Interfaces;

namespace NINA.Plugins.Fujifilm.Devices;

#nullable enable
internal sealed class FujiCameraSdkAdapter : IGenericCameraSDK, IDisposable
{
    private readonly FujiCamera _camera;
    private readonly FujifilmCameraDescriptor _descriptor;
    private readonly IFujifilmDiagnosticsService _diagnostics;
    private readonly ILibRawAdapter _libRawAdapter;
    private readonly IFujiSettingsProvider _settingsProvider;
    private readonly CameraImageBuilder _imageBuilder;
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
    private bool _imageReady;
    private FujiCameraExposureState _cameraState = FujiCameraExposureState.Idle;

    private int _roiX;
    private int _roiY;
    private int _roiWidth;
    private int _roiHeight;
    private int _roiBin = 1;
    private bool _disposed;
    private DateTime _lastExposureStartUtc = DateTime.MinValue;
    private FujiCameraCapabilities _capabilities = FujiCameraCapabilities.Empty;
    private FujiImagePackage? _lastImagePackage;

    private readonly IProfileService _profileService;

    // Live view support
    private readonly ILiveViewService _liveViewService;
    private readonly BlockingCollection<LiveViewFrame> _liveViewFrameQueue = new(boundedCapacity: 2); // Keep small to minimize latency
    private bool _liveViewActive;
    private int _liveViewWidth;
    private int _liveViewHeight;
    private volatile LiveViewFrame? _latestFrame; // Always keep the most recent frame for lowest latency
    private bool _debugFrameSaved; // Debug: only save one frame

    /// <summary>
    /// Gets whether live view is currently active.
    /// </summary>
    public bool IsLiveViewActive => _liveViewActive;

    /// <summary>
    /// Gets the current live view width, or 0 if not active.
    /// </summary>
    public int LiveViewWidth => _liveViewActive ? _liveViewWidth : 0;

    /// <summary>
    /// Gets the current live view height, or 0 if not active.
    /// </summary>
    public int LiveViewHeight => _liveViewActive ? _liveViewHeight : 0;

    public FujiCameraSdkAdapter(
        FujiCamera camera,
        FujifilmCameraDescriptor descriptor,
        IFujifilmDiagnosticsService diagnostics,
        ILibRawAdapter libRawAdapter,
        IFujiSettingsProvider settingsProvider,
        IProfileService profileService,
        ILiveViewService liveViewService,
        IDisposable cameraLifetime,
        IDisposable libRawLifetime)
    {
        _camera = camera;
        _descriptor = descriptor;
        _diagnostics = diagnostics;
        _libRawAdapter = libRawAdapter;
        _settingsProvider = settingsProvider;
        _profileService = profileService;
        _liveViewService = liveViewService;
        _imageBuilder = new CameraImageBuilder(settingsProvider, diagnostics, profileService);
        _cameraLifetime = cameraLifetime;
        _libRawLifetime = libRawLifetime;

        // Subscribe to live view frames
        _liveViewService.FrameReceived += OnLiveViewFrameReceived;
        _diagnostics.RecordEvent("Adapter", $"DIAG: Subscribed to LiveViewService.FrameReceived (service instance: {_liveViewService.GetHashCode()})");
    }

    private int _frameReceivedCount = 0;

    private void OnLiveViewFrameReceived(object? sender, LiveViewFrame frame)
    {
        _frameReceivedCount++;

        // Log first frame and every 100th frame
        if (_frameReceivedCount == 1 || _frameReceivedCount % 100 == 0)
        {
            _diagnostics.RecordEvent("Adapter", $"Frame received #{_frameReceivedCount}: {frame.Width}x{frame.Height}, {frame.JpegData.Length} bytes");
        }

        // Always store the latest frame for minimum latency
        _latestFrame = frame;

        // Also add to queue for GetVideoCapture, dropping oldest if full
        if (!_liveViewFrameQueue.TryAdd(frame))
        {
            // Queue is full, remove oldest and try again
            _liveViewFrameQueue.TryTake(out _);
            _liveViewFrameQueue.TryAdd(frame);
        }
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
        _cameraState = FujiCameraExposureState.Idle;
        _imageReady = false;
        _lastImagePackage = null;
        _isoValues = _capabilities.IsoValues.Count > 0 ? CopyIsoValues(_capabilities.IsoValues) : Array.Empty<int>();
        _currentIso = _camera.SelectClosestIso(_capabilities.DefaultIso > 0 ? _capabilities.DefaultIso : (_isoValues.Length > 0 ? _isoValues[0] : 200));
        _roiX = 0;
        _roiY = 0;
        _roiWidth = _capabilities.SensorWidth > 0 ? _capabilities.SensorWidth : (_config?.CameraXSize ?? 0);
        _roiHeight = _capabilities.SensorHeight > 0 ? _capabilities.SensorHeight : (_config?.CameraYSize ?? 0);
        _roiBin = 1;
        _connected = true;
        _diagnostics.RecordEvent("Adapter", $"Connected to {_descriptor.DisplayName}");
        _diagnostics.RecordEvent("Adapter", $"Available ISO values: [{string.Join(", ", _isoValues)}]");
        _diagnostics.RecordEvent("Adapter", $"Initial ISO set to: {_currentIso}");
        _diagnostics.RecordEvent("Adapter", $"Buffer capacity: {_capabilities.BufferShootCapacity}/{_capabilities.BufferTotalCapacity}");
        _diagnostics.RecordEvent("Adapter", $"State Mode={_capabilities.ModeCode}, AE={_capabilities.AEModeCode}, DR={_capabilities.DynamicRangeCode}, LastError={_capabilities.LastSdkErrorCode} (API {_capabilities.LastApiErrorCode})");
    }

    public void Disconnect()
    {
        if (!_connected)
        {
            return;
        }

        // Stop live view if active
        if (_liveViewActive)
        {
            StopVideoCapture();
        }

        CancelCapture();
        _camera.DisconnectAsync().GetAwaiter().GetResult();
        _connected = false;
        _cameraState = FujiCameraExposureState.Idle;
        _imageReady = false;
        _lastImagePackage = null;
        _diagnostics.RecordEvent("Adapter", $"Disconnected {_descriptor.DisplayName}");
    }

    /// <summary>
    /// Gets supported binning modes.
    /// Note: Fujifilm cameras do not support binning via the SDK.
    /// Only 1x1 (no binning) is available.
    /// </summary>
    public int[] GetBinningInfo()
    {
        // Binning is not supported by Fujifilm cameras
        return new[] { 1 };
    }

    public (int, int) GetDimensions()
    {
        // When live view is active, return the live view dimensions
        if (_liveViewActive && _liveViewWidth > 0 && _liveViewHeight > 0)
        {
            return (_liveViewWidth, _liveViewHeight);
        }
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

    public SensorType GetSensorInfo()
    {
        // For GFX cameras (Bayer), RGGB is the standard.
        // For X-Trans, NINA doesn't have an XTrans enum, so we use RGGB as a placeholder.
        // Live view also uses RGGB synthetic Bayer pattern.
        return SensorType.RGGB;
    }

    public bool SetGain(int value)
    {
        var previousIso = _currentIso;
        _currentIso = _camera.SelectClosestIso(value);
        _diagnostics.RecordEvent("Adapter", $"SetGain called: requested={value}, selected={_currentIso} (was {previousIso})");
        return true;
    }

    public bool SetOffset(int value) => false;

    public bool SetUSBLimit(int value) => false;

    public double GetMaxExposureTime() => _capabilities.MaxExposureSeconds > 0 ? _capabilities.MaxExposureSeconds : (_config?.DefaultMaxExposure ?? 600.0);

    public double GetMinExposureTime() => _capabilities.MinExposureSeconds > 0 ? _capabilities.MinExposureSeconds : (_config?.DefaultMinExposure ?? 0.001);

    public DateTime StartExposure(double exposureTime, int width, int height)
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
            _cameraState = FujiCameraExposureState.Exposing;
            _imageReady = false;
            _lastImagePackage = null;

            _captureTask = Task.Run(() =>
                _camera.CaptureRawAsync(exposureTime, _currentIso, _captureCts.Token),
                CancellationToken.None);
            _captureTask.ContinueWith(task =>
            {
                if (task.IsCanceled)
                {
                    _cameraState = FujiCameraExposureState.Error;
                    _imageReady = false;
                    return;
                }

                if (task.IsFaulted)
                {
                    _cameraState = FujiCameraExposureState.Error;
                    _imageReady = false;
                    _diagnostics.RecordEvent("Adapter", $"Exposure task faulted: {task.Exception?.GetBaseException().Message}");
                    return;
                }

                _imageReady = true;
                _cameraState = FujiCameraExposureState.Ready;
            }, CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
        }
        _lastExposureStartUtc = DateTime.UtcNow;
        return _lastExposureStartUtc;
    }

    public void StopExposure()
    {
        CancelCapture();
    }

    /// <summary>
    /// Sets the Region of Interest (ROI) for image capture.
    /// Note: Fujifilm cameras do not support arbitrary ROI or binning via the SDK.
    /// Only full-frame capture is supported. This method validates that the requested
    /// ROI matches the full sensor dimensions.
    /// </summary>
    public bool SetROI(int startX, int startY, int width, int height, int binning)
    {
        var fullWidth = _capabilities.SensorWidth > 0 ? _capabilities.SensorWidth : (_config?.CameraXSize ?? width);
        var fullHeight = _capabilities.SensorHeight > 0 ? _capabilities.SensorHeight : (_config?.CameraYSize ?? height);
        
        // Fujifilm cameras don't support arbitrary ROI or binning - only full frame
        if (startX != 0 || startY != 0 || width != fullWidth || height != fullHeight || binning != 1)
        {
            _diagnostics.RecordEvent("Adapter", $"ROI/Binning not supported by Fujifilm SDK. Requested: ({startX},{startY}) {width}x{height} bin{binning}, Required: (0,0) {fullWidth}x{fullHeight} bin1");
            return false;
        }

        // Store the full-frame ROI for GetROI() compatibility
        _roiX = startX;
        _roiY = startY;
        _roiWidth = width;
        _roiHeight = height;
        _roiBin = 1; // Binning is not supported
        return true;
    }

    public int GetBitDepth() => 16;

    public (int, int, int, int, int) GetROI()
    {
        // When live view is active, return the live view dimensions
        if (_liveViewActive && _liveViewWidth > 0 && _liveViewHeight > 0)
        {
            return (0, 0, _liveViewWidth, _liveViewHeight, 1);
        }
        return (_roiX, _roiY, _roiWidth, _roiHeight, _roiBin);
    }

    public bool HasTemperatureReadout() => false;

    public bool HasTemperatureControl() => false;

    public bool SetCooler(bool onOff) => false;

    public bool GetCoolerOnOff() => false;

    public bool SetTargetTemperature(double temperature) => false;

    public double GetTargetTemperature() => double.NaN;

    public double GetTemperature() => double.NaN;

    public double GetCoolerPower() => double.NaN;

    public FujiImagePackage? LastImagePackage => _lastImagePackage;

    public FujiCameraExposureState GetCameraState() => _cameraState;

    public double GetExposureProgress()
    {
        if (_cameraState == FujiCameraExposureState.Exposing && _lastExposureSeconds > 0)
        {
            var elapsed = (DateTime.UtcNow - _lastExposureStartUtc).TotalSeconds;
            return Math.Clamp((elapsed / _lastExposureSeconds) * 100.0, 0.0, 100.0);
        }

        return _cameraState switch
        {
            FujiCameraExposureState.Downloading => 90.0,
            FujiCameraExposureState.Ready => 100.0,
            _ => 0.0
        };
    }

    public async Task<ushort[]> GetExposure(double exposureTime, int width, int height, CancellationToken ct)
    {
        var totalStopwatch = System.Diagnostics.Stopwatch.StartNew();
        var stepStopwatch = System.Diagnostics.Stopwatch.StartNew();

        Task<RawCaptureResult>? captureTask;
        lock (_sync)
        {
            captureTask = _captureTask;
        }

        if (captureTask == null)
        {
            throw new InvalidOperationException("No exposure has been started.");
        }

        _cameraState = FujiCameraExposureState.Downloading;

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

        var usbTransferMs = stepStopwatch.ElapsedMilliseconds;
        stepStopwatch.Restart();

        Logger.Info($"[TIMING] USB transfer complete: {usbTransferMs}ms, buffer size: {raw.RawBuffer.Length} bytes");

        var libRaw = await _libRawAdapter.ProcessRawAsync(raw.RawBuffer, ct).ConfigureAwait(false);

        var libRawMs = stepStopwatch.ElapsedMilliseconds;
        stepStopwatch.Restart();

        Logger.Info($"[TIMING] LibRaw processing: {libRawMs}ms, Success={libRaw.Success}, {libRaw.Width}x{libRaw.Height}, BayerLen={libRaw.BayerData.Length}, RgbLen={libRaw.DebayeredRgb?.Length ?? 0}");

        var package = _imageBuilder.Build(raw, libRaw, _capabilities, _config);

        var buildMs = stepStopwatch.ElapsedMilliseconds;
        stepStopwatch.Restart();

        Logger.Info($"[TIMING] Image build: {buildMs}ms, {package.Width}x{package.Height}");
        
        // Diagnostic logging for black image investigation
        if (package.Pixels.Length > 0)
        {
            ushort min = ushort.MaxValue;
            ushort max = ushort.MinValue;
            long sum = 0;
            
            // Sample every 100th pixel to avoid performance hit
            for (int i = 0; i < package.Pixels.Length; i += 100)
            {
                var val = package.Pixels[i];
                if (val < min) min = val;
                if (val > max) max = val;
                sum += val;
            }
            
            double avg = (double)sum / (package.Pixels.Length / 100 + 1);
            _diagnostics.RecordEvent("Adapter", $"Image stats (sampled): Min={min}, Max={max}, Avg={avg:F2}");
        }

        _roiWidth = package.Width;
        _roiHeight = package.Height;
        _lastImagePackage = package;
        _imageReady = false;
        _cameraState = FujiCameraExposureState.Idle;
        
        // For X-Trans cameras: We use LibRaw to debayer non-destructively (raw data is preserved).
        // The debayered RGB data is used for NINA's live preview to show color images.
        //
        // Since NINA's GetExposure() expects single-channel data (width*height), we have options:
        // 1. Return debayered RGB converted to luminance (grayscale preview, shows image content)
        // 2. Return raw bayer data (NINA can't debayer X-Trans, so this shows incorrectly)
        // 3. Try returning RGB data in a format NINA might understand (experimental)
        //
        // The metadata with BAYERPAT=XTRANS is already set in the image package,
        // which will be written to FITS/XISF files for stacking software.
        // The raw bayer data in package.Pixels is always preserved for proper stacking.
        var debayeredRgb = package.GetDebayeredRgb();
        var previewMultipliers = package.GetPreviewCameraMultipliers();
        var previewBitDepth = package.GetPreviewBitDepth();
        if (debayeredRgb != null && package.ColorFilterPattern.StartsWith("XTRANS", StringComparison.OrdinalIgnoreCase))
        {
            // Try returning RGB data for color preview
            try
            {
                var syntheticBayer = ConvertRgbToSyntheticBayer(debayeredRgb, package.Width, package.Height, previewMultipliers);

                var convertMs = stepStopwatch.ElapsedMilliseconds;
                var totalMs = totalStopwatch.ElapsedMilliseconds;

                Logger.Info($"[TIMING] RGB->Bayer conversion: {convertMs}ms");
                Logger.Info($"[TIMING] TOTAL GetExposure: {totalMs}ms (USB:{usbTransferMs} + LibRaw:{libRawMs} + Build:{buildMs} + Convert:{convertMs})");

                return syntheticBayer;
            }
            catch (Exception ex)
            {
                Logger.Error($"[TIMING] Synthetic Bayer conversion failed: {ex.Message}");
                return package.Pixels;
            }
        }

        // For Bayer cameras or when debayered RGB is not available, return raw bayer data
        var totalMsBayer = totalStopwatch.ElapsedMilliseconds;
        Logger.Info($"[TIMING] TOTAL GetExposure (Bayer path): {totalMsBayer}ms");

        return package.Pixels;
    }
    
    /// <summary>
    /// Converts RGB data to a synthetic RGGB Bayer pattern.
    /// This allows NINA to display a color preview for X-Trans cameras by treating the data as standard Bayer.
    /// LibRaw is configured for raw camera space with neutral settings, so we do a direct conversion
    /// without any color correction to avoid double-processing issues with NINA 3.2's color pipeline.
    /// </summary>
    private ushort[] ConvertRgbToSyntheticBayer(ushort[] rgbData, int width, int height, double[]? cameraMultipliers)
    {
        var bayer = new ushort[width * height];
        
        // Calculate the source width from the RGB data length
        // The RGB data might be wider than the target width if we applied a safety crop
        // rgbData.Length = sourceWidth * height * 3
        int sourceWidth = rgbData.Length / (height * 3);
        
        // Parallel loop for performance
        Parallel.For(0, height, y =>
        {
            for (int x = 0; x < width; x++)
            {
                // Target index (packed)
                int index = y * width + x;
                
                // Source index (using source stride)
                int rgbIndex = (y * sourceWidth + x) * 3;
                
                // RGGB Pattern:
                // R G
                // G B
                
                bool isEvenRow = (y % 2 == 0);
                bool isEvenCol = (x % 2 == 0);
                
                if (isEvenRow)
                {
                    if (isEvenCol)
                    {
                        // Red
                        bayer[index] = rgbData[rgbIndex];
                    }
                    else
                    {
                        // Green (on Red row)
                        bayer[index] = rgbData[rgbIndex + 1];
                    }
                }
                else
                {
                    if (isEvenCol)
                    {
                        // Green (on Blue row)
                        bayer[index] = rgbData[rgbIndex + 1];
                    }
                    else
                    {
                        // Blue
                        bayer[index] = rgbData[rgbIndex + 2];
                    }
                }
            }
        });
        
        return bayer;
    }

    /// <summary>
    /// Converts RGB data (RGBRGB... format) to luminance for NINA preview display.
    /// This is the fallback method when RGB preview doesn't work.
    /// Since NINA's GetExposure() expects single-channel data (width*height), we convert
    /// RGB to grayscale luminance for preview. The raw bayer data is still available in
    /// the image package for proper stacking.
    /// 
    /// This debayering is non-destructive - it's only for live preview.
    /// </summary>
    private ushort[] ConvertRgbToLuminance(ushort[] rgbData, int width, int height)
    {
        // Convert RGB to luminance (Y = 0.299*R + 0.587*G + 0.114*B)
        // This provides a grayscale preview that shows the image content
        // The raw bayer data is preserved in the image package for stacking software
        var luminance = new ushort[width * height];
        for (int i = 0; i < width * height; i++)
        {
            var r = rgbData[i * 3];
            var g = rgbData[i * 3 + 1];
            var b = rgbData[i * 3 + 2];
            
            // ITU-R BT.601 luminance formula
            var y = (ushort)(0.299 * r + 0.587 * g + 0.114 * b);
            luminance[i] = y;
        }
        
        _diagnostics.RecordEvent("Adapter", $"Converted RGB to luminance for X-Trans preview ({luminance.Length} pixels)");
        return luminance;
    }

    public bool IsExposureReady()
    {
        lock (_sync)
        {
            return _imageReady;
        }
    }

    public bool HasDewHeater() => false;

    public bool SetDewHeater(int power) => false;

    public bool IsDewHeaterOn() => false;

    /// <summary>
    /// Starts live view video capture.
    /// Uses the LiveViewService to stream JPEG frames from the camera.
    /// </summary>
    public void StartVideoCapture(double exposureTime, int width, int height)
    {
        EnsureConnected();

        if (_liveViewActive)
        {
            _diagnostics.RecordEvent("Adapter", "Live view already active, ignoring StartVideoCapture");
            return;
        }

        var handle = _camera.SessionHandle;
        if (handle == IntPtr.Zero)
        {
            throw new InvalidOperationException("Camera session handle is not available");
        }

        // Get user settings for live view quality and size
        var settings = _settingsProvider.Settings;
        var liveViewQuality = settings.LiveViewQuality;
        var liveViewSize = settings.LiveViewSize;

        // Set initial live view dimensions based on the selected size
        // Aspect ratio is approximately 3:2 for Fuji sensors
        _liveViewWidth = liveViewSize.GetApproximateWidth();
        _liveViewHeight = (int)(_liveViewWidth / 1.5); // 3:2 aspect ratio

        // Clear any old frames from the queue and latest frame
        while (_liveViewFrameQueue.TryTake(out _)) { }
        _latestFrame = null;

        _diagnostics.RecordEvent("Adapter", $"DIAG: Calling StartAsync on LiveViewService instance: {_liveViewService.GetHashCode()}");

        // Start live view with user-configured quality and size
        _liveViewService.StartAsync(handle, liveViewQuality, liveViewSize, CancellationToken.None)
            .ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    _diagnostics.RecordEvent("Adapter", $"Failed to start live view: {t.Exception?.GetBaseException().Message}");
                    _liveViewActive = false;
                }
            });

        _liveViewActive = true;
        _diagnostics.RecordEvent("Adapter", $"Live view started: {_liveViewWidth}x{_liveViewHeight} ({liveViewSize}/{liveViewQuality})");
    }

    /// <summary>
    /// Stops live view video capture.
    /// </summary>
    public void StopVideoCapture()
    {
        if (!_liveViewActive)
        {
            return;
        }

        var handle = _camera.SessionHandle;
        if (handle != IntPtr.Zero)
        {
            _liveViewService.StopAsync(handle).GetAwaiter().GetResult();
        }

        // Clear the frame queue
        while (_liveViewFrameQueue.TryTake(out _)) { }

        _liveViewActive = false;
        // Reset live view dimensions so GetDimensions/GetROI returns sensor size for normal exposures
        _liveViewWidth = 0;
        _liveViewHeight = 0;
        _latestFrame = null;
        _debugFrameSaved = false; // Reset so next session saves a new debug frame
        _frameReceivedCount = 0;
        _getVideoCaptureCount = 0;
        _diagnostics.RecordEvent("Adapter", "Live view stopped");
    }

    private int _getVideoCaptureCount = 0;

    /// <summary>
    /// Gets a live view frame as ushort[] image data.
    /// Uses the queue for frame delivery to ensure we get a complete frame.
    /// </summary>
    public async Task<ushort[]> GetVideoCapture(double exposureTime, int width, int height, CancellationToken ct)
    {
        _getVideoCaptureCount++;
        if (_getVideoCaptureCount == 1 || _getVideoCaptureCount % 100 == 0)
        {
            _diagnostics.RecordEvent("Adapter", $"GetVideoCapture #{_getVideoCaptureCount}: requested {width}x{height}, active={_liveViewActive}, latestFrame={_latestFrame != null}");
        }

        if (!_liveViewActive)
        {
            throw new InvalidOperationException("Live view is not active");
        }

        // Try to get a frame from the queue - this ensures we get a complete frame
        // that won't be modified during processing
        LiveViewFrame? frame = null;
        var startTime = DateTime.UtcNow;

        while (!ct.IsCancellationRequested)
        {
            // Try to take from queue with short timeout
            if (_liveViewFrameQueue.TryTake(out frame, 50))
            {
                break;
            }

            // Fall back to latest frame if queue is empty but we have a frame available
            var latestFrame = _latestFrame;
            if (latestFrame != null)
            {
                frame = latestFrame;
                break;
            }

            // Check overall timeout
            if ((DateTime.UtcNow - startTime).TotalMilliseconds > 2000)
            {
                throw new TimeoutException("Timeout waiting for live view frame");
            }

            await Task.Delay(10, ct).ConfigureAwait(false);
        }

        if (frame == null)
        {
            throw new OperationCanceledException("Live view frame retrieval was cancelled");
        }

        // Make a local copy of the JPEG data to ensure thread safety during processing
        var jpegData = frame.JpegData;

        // Debug: Save first frame to disk to verify JPEG quality
        if (_debugFrameSaved == false)
        {
            _debugFrameSaved = true;
            try
            {
                var debugPath = System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    $"fuji_liveview_debug_{DateTime.Now:HHmmss}.jpg");
                System.IO.File.WriteAllBytes(debugPath, jpegData);
                _diagnostics.RecordEvent("Adapter", $"DEBUG: Saved frame to {debugPath} ({jpegData.Length} bytes)");
            }
            catch (Exception ex)
            {
                _diagnostics.RecordEvent("Adapter", $"DEBUG: Failed to save frame: {ex.Message}");
            }
        }

        // Convert JPEG to ushort[] image data
        return ConvertJpegToImageData(jpegData, width, height);
    }

    /// <summary>
    /// Converts JPEG data to ushort[] image data for NINA.
    /// Creates a synthetic RGGB Bayer pattern from the JPEG.
    /// Uses native JPEG dimensions for best quality.
    /// </summary>
    private ushort[] ConvertJpegToImageData(byte[] jpegData, int targetWidth, int targetHeight)
    {
        using var ms = new MemoryStream(jpegData);
        using var bitmap = new Bitmap(ms);

        int width = bitmap.Width;
        int height = bitmap.Height;

        // Log dimension info for debugging (only on first frame or size change)
        if (_liveViewWidth != width || _liveViewHeight != height)
        {
            _diagnostics.RecordEvent("Adapter", $"Live view: JPEG {width}x{height}, target {targetWidth}x{targetHeight}");
        }

        // Update live view dimensions - these will be used by GetDimensions/GetROI
        _liveViewWidth = width;
        _liveViewHeight = height;

        // Create output array
        var result = new ushort[width * height];

        // Lock bitmap for fast pixel access
        var rect = new Rectangle(0, 0, width, height);
        var bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

        try
        {
            int stride = bitmapData.Stride;
            byte[] pixels = new byte[stride * height];
            System.Runtime.InteropServices.Marshal.Copy(bitmapData.Scan0, pixels, 0, pixels.Length);

            // Create synthetic RGGB Bayer pattern
            Parallel.For(0, height, y =>
            {
                int rowOffset = y * stride;
                bool isEvenRow = (y % 2 == 0);

                for (int x = 0; x < width; x++)
                {
                    int pixelOffset = rowOffset + x * 3;

                    // BGR format in bitmap
                    byte b = pixels[pixelOffset];
                    byte g = pixels[pixelOffset + 1];
                    byte r = pixels[pixelOffset + 2];

                    bool isEvenCol = (x % 2 == 0);

                    // RGGB Bayer Pattern - scale 8-bit to 16-bit
                    ushort value;
                    if (isEvenRow)
                    {
                        value = isEvenCol ? (ushort)(r * 257) : (ushort)(g * 257);
                    }
                    else
                    {
                        value = isEvenCol ? (ushort)(g * 257) : (ushort)(b * 257);
                    }

                    result[y * width + x] = value;
                }
            });

            return result;
        }
        finally
        {
            bitmap.UnlockBits(bitmapData);
        }
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

    /// <summary>
    /// Gets the current battery level (0-100) from the camera.
    /// Returns -1 if battery level is not available.
    /// </summary>
    public int GetBatteryLevel()
    {
        if (!_connected)
            return -1;

        // Refresh capabilities to get latest battery info
        _capabilities = _camera.GetCapabilitiesSnapshot();
        var level = _capabilities.Metadata.BatteryLevel;
        return level > 0 ? level : -1;
    }

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
            _cameraState = FujiCameraExposureState.Idle;
            _imageReady = false;
            _lastImagePackage = null;
        }
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _disposed = true;

        // Unsubscribe from live view events
        _liveViewService.FrameReceived -= OnLiveViewFrameReceived;
        _liveViewFrameQueue.Dispose();

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

internal enum FujiCameraExposureState
{
    Idle,
    Exposing,
    Downloading,
    Ready,
    Error
}