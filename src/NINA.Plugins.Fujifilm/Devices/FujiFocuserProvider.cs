using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading;
using System.Threading.Tasks;
using NINA.Core.Utility;
using NINA.Equipment.Interfaces;
using NINA.Equipment.Interfaces.ViewModel;
using NINA.Image.Interfaces;
using NINA.Plugin.Interfaces;
using NINA.Profile.Interfaces;
using NINA.Plugins.Fujifilm.Diagnostics;

namespace NINA.Plugins.Fujifilm.Devices;

[Export(typeof(IEquipmentProvider))]
public class FujiFocuserProvider : IEquipmentProvider<IFocuser>
{
    private readonly IFujiCameraFactory _cameraFactory;
    private readonly IFujiFocuserFactory _focuserFactory;
    private readonly IFujifilmDiagnosticsService _diagnostics;

    public string Name => "Fujifilm Focuser";

    [ImportingConstructor]
    public FujiFocuserProvider(
        IFujiCameraFactory cameraFactory,
        IFujiFocuserFactory focuserFactory,
        IFujifilmDiagnosticsService diagnostics)
    {
        _cameraFactory = cameraFactory;
        _focuserFactory = focuserFactory;
        _diagnostics = diagnostics;
    }

    public IList<IFocuser> GetEquipment()
    {
        var focusers = new List<IFocuser>();
        try
        {
            var cameras = _cameraFactory.GetAvailableCamerasAsync(CancellationToken.None).GetAwaiter().GetResult();

            foreach (var descriptor in cameras)
            {
                if (_focuserFactory.SupportsFocus(descriptor))
                {
                    var focuser = _focuserFactory.Create(descriptor);
                    focusers.Add(new FujiFocuserSdkAdapter(focuser, descriptor, _diagnostics));
                }
            }
        }
        catch (Exception ex)
        {
            _diagnostics.RecordEvent("FocuserProvider", $"Failed to get equipment: {ex.Message}");
        }

        return focusers;
    }
}
