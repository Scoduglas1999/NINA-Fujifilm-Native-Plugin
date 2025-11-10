using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading;
using System.Threading.Tasks;
using NINA.Plugins.Fujifilm.Diagnostics;
using NINA.Plugins.Fujifilm.Interop.Native;

namespace NINA.Plugins.Fujifilm.Interop;

[Export(typeof(IFujifilmInterop))]
[PartCreationPolicy(CreationPolicy.Shared)]
public sealed class FujifilmInterop : IFujifilmInterop
{
    private readonly IFujifilmDiagnosticsService _diagnostics;
    private readonly SemaphoreSlim _runtimeLock = new(1, 1);
    private bool _runtimeInitialized;

    [ImportingConstructor]
    public FujifilmInterop(IFujifilmDiagnosticsService diagnostics)
    {
        _diagnostics = diagnostics;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        await _runtimeLock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            if (_runtimeInitialized)
            {
                return;
            }

            _diagnostics.RecordEvent("Interop", "Initializing Fujifilm SDK runtime");
            var initResult = FujifilmSdkWrapper.XSDK_Init(IntPtr.Zero);
            FujifilmSdkWrapper.CheckResult(IntPtr.Zero, initResult, nameof(FujifilmSdkWrapper.XSDK_Init));
            _runtimeInitialized = true;
        }
        finally
        {
            _runtimeLock.Release();
        }
    }

    public async Task ShutdownAsync()
    {
        await _runtimeLock.WaitAsync().ConfigureAwait(false);
        try
        {
            if (!_runtimeInitialized)
            {
                return;
            }

            _diagnostics.RecordEvent("Interop", "Shutting down Fujifilm SDK runtime");
            var exitResult = FujifilmSdkWrapper.XSDK_Exit();
            if (exitResult != FujifilmSdkWrapper.XSDK_COMPLETE)
            {
                _diagnostics.RecordEvent("Interop", $"XSDK_Exit returned {exitResult}");
            }

            _runtimeInitialized = false;
        }
        finally
        {
            _runtimeLock.Release();
        }
    }

    public async Task<IReadOnlyList<FujifilmCameraInfo>> DetectCamerasAsync(CancellationToken cancellationToken)
    {
        await InitializeAsync(cancellationToken).ConfigureAwait(false);

        _diagnostics.RecordEvent("Interop", "Detecting Fujifilm cameras via USB");
        int count;
        var detectResult = FujifilmSdkWrapper.XSDK_Detect(FujifilmSdkWrapper.XSDK_DSC_IF_USB, IntPtr.Zero, IntPtr.Zero, out count);
        FujifilmSdkWrapper.CheckResult(IntPtr.Zero, detectResult, nameof(FujifilmSdkWrapper.XSDK_Detect));

        if (count <= 0)
        {
            _diagnostics.RecordEvent("Interop", "No Fujifilm cameras detected by SDK");
            return Array.Empty<FujifilmCameraInfo>();
        }

        var cameras = new List<FujifilmCameraInfo>(count);
        for (var index = 0; index < count; index++)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var deviceId = $"ENUM:{index}";
            IntPtr cameraHandle = IntPtr.Zero;
            try
            {
                int openResult = FujifilmSdkWrapper.XSDK_OpenEx(deviceId, out cameraHandle, out var mode, IntPtr.Zero);
                FujifilmSdkWrapper.CheckResult(IntPtr.Zero, openResult, nameof(FujifilmSdkWrapper.XSDK_OpenEx));
                _diagnostics.RecordEvent("Interop", $"Opened camera handle {cameraHandle} in mode {mode} for detection");

                FujifilmSdkWrapper.XSDK_DeviceInformation deviceInfo;
                int apiCount;
                var infoResult = FujifilmSdkWrapper.XSDK_GetDeviceInfoEx(cameraHandle, out deviceInfo, out apiCount, IntPtr.Zero);
                FujifilmSdkWrapper.CheckResult(cameraHandle, infoResult, nameof(FujifilmSdkWrapper.XSDK_GetDeviceInfoEx));

                cameras.Add(new FujifilmCameraInfo(
                    deviceInfo.strProduct?.Trim() ?? $"Fujifilm Camera {index}",
                    deviceInfo.strSerialNo?.Trim() ?? string.Empty,
                    deviceId));
            }
            catch (FujifilmSdkException ex)
            {
                _diagnostics.RecordEvent("Interop", $"Detection failed at index {index}: {ex.Message}");
            }
            finally
            {
                if (cameraHandle != IntPtr.Zero)
                {
                    var closeResult = FujifilmSdkWrapper.XSDK_Close(cameraHandle);
                    if (closeResult != FujifilmSdkWrapper.XSDK_COMPLETE)
                    {
                        _diagnostics.RecordEvent("Interop", $"XSDK_Close returned {closeResult} during detection phase");
                    }
                }
            }
        }

        return cameras;
    }

    public async Task<FujifilmCameraSession> OpenCameraAsync(string deviceId, CancellationToken cancellationToken)
    {
        await InitializeAsync(cancellationToken).ConfigureAwait(false);
        _diagnostics.RecordEvent("Interop", $"Opening Fujifilm camera {deviceId}");
        int openResult = FujifilmSdkWrapper.XSDK_OpenEx(deviceId, out var handle, out var mode, IntPtr.Zero);
        FujifilmSdkWrapper.CheckResult(IntPtr.Zero, openResult, nameof(FujifilmSdkWrapper.XSDK_OpenEx));
        _diagnostics.RecordEvent("Interop", $"Camera handle {handle} opened in mode {mode}");
        return new FujifilmCameraSession(handle, deviceId);
    }

    public Task CloseCameraAsync(FujifilmCameraSession session)
    {
        if (session == null || session.Handle == IntPtr.Zero)
        {
            return Task.CompletedTask;
        }

        _diagnostics.RecordEvent("Interop", $"Closing Fujifilm camera {session.DeviceId}");
        var result = FujifilmSdkWrapper.XSDK_Close(session.Handle);
        if (result != FujifilmSdkWrapper.XSDK_COMPLETE)
        {
            _diagnostics.RecordEvent("Interop", $"XSDK_Close returned {result}");
        }

        session.Handle = IntPtr.Zero;
        return Task.CompletedTask;
    }

    public async ValueTask DisposeAsync()
    {
        await ShutdownAsync().ConfigureAwait(false);
        _runtimeLock.Dispose();
    }
}
