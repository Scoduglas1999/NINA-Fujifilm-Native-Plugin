using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading;
using NINA.Equipment.Interfaces;
using NINA.Equipment.Interfaces.ViewModel;
using NINA.Plugins.Fujifilm.Diagnostics;

namespace NINA.Plugins.Fujifilm.Devices;

[Export(typeof(IEquipmentProvider))]
[PartCreationPolicy(CreationPolicy.Shared)]
public sealed class FujiCameraProvider : IEquipmentProvider<ICamera>
{
    private readonly IFujiCameraFactory _cameraFactory;
    private readonly IFujifilmDiagnosticsService _diagnostics;

    public string Name => "Fujifilm Native";

    [ImportingConstructor]
    public FujiCameraProvider(IFujiCameraFactory cameraFactory, IFujifilmDiagnosticsService diagnostics)
    {
        _cameraFactory = cameraFactory;
        _diagnostics = diagnostics;
    }

    public IList<ICamera> GetEquipment()
    {
        var cameras = new List<ICamera>();

        try
        {
            _diagnostics.RecordEvent("Provider", "Enumerating Fujifilm cameras");
            var descriptors = _cameraFactory.GetAvailableCamerasAsync(CancellationToken.None).GetAwaiter().GetResult();
            _diagnostics.RecordEvent("Provider", $"Detected {descriptors.Count} Fujifilm camera(s)");

            foreach (var descriptor in descriptors)
            {
                try
                {
                    var camera = _cameraFactory.CreateGenericCamera(descriptor);
                    cameras.Add(camera);
                }
                catch (Exception ex)
                {
                    _diagnostics.RecordEvent("Provider", $"Failed to create camera instance for {descriptor.DisplayName}: {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            _diagnostics.RecordEvent("Provider", $"Camera enumeration failed: {ex.Message}");
        }

        return cameras;
    }
}
