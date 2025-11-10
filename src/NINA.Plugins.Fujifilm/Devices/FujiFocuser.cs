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
        _diagnostics.RecordEvent("Focuser", $"Setting focus position to {absolute}");
        var result = FujifilmSdkWrapper.XSDK_SetFocusPos(session.Handle, absolute);
        FujifilmSdkWrapper.CheckResult(session.Handle, result, nameof(FujifilmSdkWrapper.XSDK_SetFocusPos));
    }

    public async Task<int> GetPositionAsync(CancellationToken cancellationToken)
    {
        var session = await EnsureSessionAsync(cancellationToken).ConfigureAwait(false);
        var result = FujifilmSdkWrapper.XSDK_GetFocusPos(session.Handle, out var pos);
        FujifilmSdkWrapper.CheckResult(session.Handle, result, nameof(FujifilmSdkWrapper.XSDK_GetFocusPos));
        return pos - _focusMin;
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

        if (_config?.SdkConstants.FocusModeManual != 0)
        {
            var setMode = FujifilmSdkWrapper.XSDK_SetFocusMode(_session.Handle, _config.SdkConstants.FocusModeManual);
            FujifilmSdkWrapper.CheckResult(_session.Handle, setMode, nameof(FujifilmSdkWrapper.XSDK_SetFocusMode));
        }

        QueryFocusLimits();
        return _session;
    }

    private void QueryFocusLimits()
    {
        if (_session == null)
        {
            return;
        }

        var result = FujifilmSdkWrapper.XSDK_CapFocusPos(_session.Handle, out _focusMin, out _focusMax, out _focusStep);
        if (result != FujifilmSdkWrapper.XSDK_COMPLETE)
        {
            _diagnostics.RecordEvent("Focuser", $"XSDK_CapFocusPos returned {result}. Using default range.");
            _focusMin = 0;
            _focusMax = 10000;
            _focusStep = 1;
            return;
        }

        _diagnostics.RecordEvent("Focuser", $"Focus range min={_focusMin} max={_focusMax} step={_focusStep}");
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
