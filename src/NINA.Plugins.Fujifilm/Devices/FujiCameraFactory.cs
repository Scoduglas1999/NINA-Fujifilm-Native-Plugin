using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using NINA.Equipment.Equipment.MyCamera;
using NINA.Equipment.Interfaces;
using NINA.Image.Interfaces;
using NINA.Plugins.Fujifilm.Configuration.Loading;
using NINA.Plugins.Fujifilm.Diagnostics;
using NINA.Plugins.Fujifilm.Interop;
using NINA.Profile.Interfaces;

namespace NINA.Plugins.Fujifilm.Devices;

[Export(typeof(IFujiCameraFactory))]
[PartCreationPolicy(CreationPolicy.Shared)]
public sealed class FujiCameraFactory : IFujiCameraFactory
{
    private readonly IFujifilmInterop _interop;
    private readonly IFujifilmDiagnosticsService _diagnostics;
    private readonly ExportFactory<FujiCamera> _cameraFactory;
    private readonly ExportFactory<ILibRawAdapter> _libRawFactory;
    private readonly ICameraModelCatalog _catalog;
    private readonly IProfileService _profileService;
    private readonly IExposureDataFactory _exposureDataFactory;

    [ImportingConstructor]
    public FujiCameraFactory(
        IFujifilmInterop interop,
        IFujifilmDiagnosticsService diagnostics,
        ExportFactory<FujiCamera> cameraFactory,
        ExportFactory<ILibRawAdapter> libRawFactory,
        ICameraModelCatalog catalog,
        IProfileService profileService,
        IExposureDataFactory exposureDataFactory)
    {
        _interop = interop;
        _diagnostics = diagnostics;
        _cameraFactory = cameraFactory;
        _libRawFactory = libRawFactory;
        _catalog = catalog;
        _profileService = profileService;
        _exposureDataFactory = exposureDataFactory;
    }

    public async Task<IReadOnlyList<FujifilmCameraDescriptor>> GetAvailableCamerasAsync(CancellationToken cancellationToken)
    {
        await _interop.InitializeAsync(cancellationToken).ConfigureAwait(false);
        var cameras = await _interop.DetectCamerasAsync(cancellationToken).ConfigureAwait(false);
        if (cameras.Count == 0)
        {
            _diagnostics.RecordEvent("Factory", "No Fujifilm cameras detected.");
        }

        return cameras.Select(info => new FujifilmCameraDescriptor(info.ProductName, info.DeviceId)).ToList();
    }

    public FujiCamera CreateCamera()
    {
        return _cameraFactory.CreateExport().Value;
    }

    public ICamera CreateGenericCamera(FujifilmCameraDescriptor descriptor)
    {
        var cameraExport = _cameraFactory.CreateExport();
        var libRawExport = _libRawFactory.CreateExport();
        var camera = cameraExport.Value;
        var libRaw = libRawExport.Value;
        var adapter = new FujiCameraSdkAdapter(camera, descriptor, _diagnostics, libRaw, cameraExport, libRawExport);

        try
        {
            var stringCtor = typeof(GenericCamera).GetConstructor(new[]
            {
                typeof(string), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(IGenericCameraSDK), typeof(IProfileService), typeof(IExposureDataFactory)
            });

            if (stringCtor != null)
            {
                return (GenericCamera)stringCtor.Invoke(new object[]
                {
                    descriptor.DeviceId,
                    descriptor.DisplayName,
                    "Fujifilm",
                    "Native",
                    true,
                    adapter,
                    _profileService,
                    _exposureDataFactory
                });
            }

            var intCtor = typeof(GenericCamera).GetConstructor(new[]
            {
                typeof(int), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(IGenericCameraSDK), typeof(IProfileService), typeof(IExposureDataFactory)
            });

            if (intCtor != null)
            {
                var hashId = unchecked((int)descriptor.DeviceId.GetHashCode());
                return (GenericCamera)intCtor.Invoke(new object[]
                {
                    hashId,
                    descriptor.DisplayName,
                    "Fujifilm",
                    "Native",
                    true,
                    adapter,
                    _profileService,
                    _exposureDataFactory
                });
            }

            throw new InvalidOperationException("Unsupported GenericCamera constructor signature.");
        }
        catch (Exception ex)
        {
            _diagnostics.RecordEvent("Factory", $"Failed to create GenericCamera: {ex.Message}");
            adapter.Dispose();
            throw;
        }
    }

    public async Task<FujiCameraCapabilities> GetCapabilitiesAsync(FujifilmCameraDescriptor descriptor, CancellationToken cancellationToken)
    {
        var cameraExport = _cameraFactory.CreateExport();
        var camera = cameraExport.Value;
        try
        {
            await camera.ConnectAsync(descriptor, cancellationToken).ConfigureAwait(false);
            var capabilities = camera.GetCapabilitiesSnapshot();
            return capabilities;
        }
        finally
        {
            await camera.DisposeAsync().ConfigureAwait(false);
            cameraExport.Dispose();
        }
    }
}
