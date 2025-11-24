using System;
using System.ComponentModel.Composition;
using System.Threading;
using System.Threading.Tasks;
using NINA.Plugins.Fujifilm.Configuration;
using NINA.Plugins.Fujifilm.Configuration.Loading;
using NINA.Plugins.Fujifilm.Diagnostics;
using NINA.Plugins.Fujifilm.Interop;
using NINA.Plugins.Fujifilm.Interop.Native;

namespace NINA.Plugins.Fujifilm.Devices;

[Export(typeof(FujiFocuser))]
[PartCreationPolicy(CreationPolicy.NonShared)]
public sealed class FujiFocuser : IAsyncDisposable
{
    private readonly IFujifilmInterop _interop;
    private readonly ICameraModelCatalog _catalog;
    private readonly IFujifilmDiagnosticsService _diagnostics;

    private FujifilmCameraDescriptor? _descriptor;
    private CameraConfig? _config;
    private FujifilmCameraSession? _session;
    private int _focusMin;
    private int _focusMax;
    private int _focusStep;

    public int FocusMin => _focusMin;
    public int FocusMax => _focusMax;
    public int FocusRange => _focusMax - _focusMin;

    [ImportingConstructor]
    public FujiFocuser(IFujifilmInterop interop, ICameraModelCatalog catalog, IFujifilmDiagnosticsService diagnostics)
    {
        _interop = interop;
        _catalog = catalog;
        _diagnostics = diagnostics;
    }

    public void Initialize(FujifilmCameraDescriptor descriptor)
    {
        _descriptor = descriptor;
        _config = _catalog.TryGetByProductName(descriptor.DisplayName);
    }

    public async Task MoveAsync(int position, CancellationToken cancellationToken)
    {
        var session = await EnsureSessionAsync(cancellationToken).ConfigureAwait(false);
        var absolute = position + _focusMin;
        if (absolute < _focusMin)
        {
            absolute = _focusMin;
        }
        else if (absolute > _focusMax)
        {
            absolute = _focusMax;
        }
        
        _diagnostics.RecordEvent("Focuser", $"MoveAsync: requested position={position}, absolute={absolute}, min={_focusMin}, max={_focusMax}");
        
        var result = FujifilmSdkWrapper.XSDK_SetFocusPos(session.Handle, absolute);
        _diagnostics.RecordEvent("Focuser", $"XSDK_SetFocusPos returned: {result} (0x{result:X})");
        
        FujifilmSdkWrapper.CheckResult(session.Handle, result, nameof(FujifilmSdkWrapper.XSDK_SetFocusPos));
        
        // Verify the move by reading back the position
        await Task.Delay(100, cancellationToken); // Small delay for lens to respond
        var verifyResult = FujifilmSdkWrapper.XSDK_GetFocusPos(session.Handle, out var actualPos);
        _diagnostics.RecordEvent("Focuser", $"Position after move: requested={absolute}, actual={actualPos}");
    }

    public async Task<int> GetPositionAsync(CancellationToken cancellationToken)
    {
        var session = await EnsureSessionAsync(cancellationToken).ConfigureAwait(false);
        var result = FujifilmSdkWrapper.XSDK_GetFocusPos(session.Handle, out var pos);
        
        if (result != FujifilmSdkWrapper.XSDK_COMPLETE)
        {
            _diagnostics.RecordEvent("Focuser", $"XSDK_GetFocusPos failed: result={result} (0x{result:X})");
        }
        
        FujifilmSdkWrapper.CheckResult(session.Handle, result, nameof(FujifilmSdkWrapper.XSDK_GetFocusPos));
        
        var relative = pos - _focusMin;
        _diagnostics.RecordEvent("Focuser", $"GetPositionAsync: absolute={pos}, relative={relative}, min={_focusMin}");
        
        return relative;
    }

    private async Task<FujifilmCameraSession> EnsureSessionAsync(CancellationToken cancellationToken)
    {
        if (_descriptor == null)
        {
            throw new InvalidOperationException("Focuser has not been initialized.");
        }

        if (_session != null && _session.Handle != IntPtr.Zero)
        {
            return _session;
        }

        _session = await _interop.OpenCameraAsync(_descriptor.DeviceId, cancellationToken).ConfigureAwait(false);
        _diagnostics.RecordEvent("Focuser", $"Opened focuser session for {_descriptor.DisplayName}");

        // XSDK_SetFocusMode is not available in the current XAPI.dll.
        // We rely on the user setting the physical focus switch to 'S' or 'C'.
        // if (_config?.SdkConstants.FocusModeManual != 0)
        // {
        //     var setMode = FujifilmSdkWrapper.XSDK_SetFocusMode(_session.Handle, _config.SdkConstants.FocusModeManual);
        //     FujifilmSdkWrapper.CheckResult(_session.Handle, setMode, nameof(FujifilmSdkWrapper.XSDK_SetFocusMode));
        // }

        QueryFocusLimits();
        return _session;
    }

    private void QueryFocusLimits()
    {
        if (_session == null)
        {
            return;
        }

        _diagnostics.RecordEvent("Focuser", $"Querying focus limits with API_CODE=0x{FujifilmSdkWrapper.XSDK_API_CODE_CapFocusPos:X}, API_PARAM={FujifilmSdkWrapper.XSDK_API_PARAM_CapFocusPos}");

        var result = FujifilmSdkWrapper.XSDK_CapFocusPos(_session.Handle, out var cap);
        
        _diagnostics.RecordEvent("Focuser", $"XSDK_CapFocusPos returned: result={result} (0x{result:X})");
        _diagnostics.RecordEvent("Focuser", $"Struct values: lSizeFocusPosCap={cap.lSizeFocusPosCap}, lStructVer=0x{cap.lStructVer:X}");
        _diagnostics.RecordEvent("Focuser", $"Focus positions: lFocusPlsINF={cap.lFocusPlsINF}, lFocusPlsMOD={cap.lFocusPlsMOD}");
        _diagnostics.RecordEvent("Focuser", $"DOF capability: lFocusPlsFCSDepthCap={cap.lFocusPlsFCSDepthCap}, lMinDriveStep={cap.lMinDriveStepMFDriveEndThresh}");
        
        if (result != FujifilmSdkWrapper.XSDK_COMPLETE)
        {
            _diagnostics.RecordEvent("Focuser", $"XSDK_CapFocusPos failed with result {result}. Using default range.");
            _focusMin = 0;
            _focusMax = 10000;
            _focusStep = 1;
            return;
        }

        // Check if lens supports focus position control
        if (cap.lFocusPlsFCSDepthCap == 0 || cap.lFocusPlsINF == 0 && cap.lFocusPlsMOD == 0)
        {
            var message = "This lens does not support programmatic focus control. Ensure the lens is set to MF (Manual Focus) mode and supports electronic focus.";
            _diagnostics.RecordEvent("Focuser", $"ERROR: {message}");
            throw new NotSupportedException(message);
        }

        _focusMin = Math.Min(cap.lFocusPlsINF, cap.lFocusPlsMOD);
        _focusMax = Math.Max(cap.lFocusPlsINF, cap.lFocusPlsMOD);
        _focusStep = cap.lMinDriveStepMFDriveEndThresh > 0 ? cap.lMinDriveStepMFDriveEndThresh : 1;

        _diagnostics.RecordEvent("Focuser", $"Focus range min={_focusMin} max={_focusMax} step={_focusStep} (INF={cap.lFocusPlsINF}, MOD={cap.lFocusPlsMOD})");
    }

    public async ValueTask DisposeAsync()
    {
        if (_session != null)
        {
            await _interop.CloseCameraAsync(_session).ConfigureAwait(false);
            await _session.DisposeAsync().ConfigureAwait(false);
            _session = null;
        }
    }
}
