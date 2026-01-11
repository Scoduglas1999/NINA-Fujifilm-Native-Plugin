using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using NINA.Equipment.Interfaces.ViewModel;
using NINA.Plugins.Fujifilm.Devices;
using NINA.Profile.Interfaces;
using NINA.WPF.Base.ViewModel;

namespace NINA.Plugins.Fujifilm.UI;

/// <summary>
/// Minimal dockable panel that displays Fujifilm lens info in the imaging tab.
/// Battery is shown in NINA's built-in camera panel; this shows the lens.
/// </summary>
[Export(typeof(IDockableVM))]
public class FujiLensInfoVM : DockableVM
{
    private readonly FujiCamera _camera;
    private string _lensText = "Not connected";
    private bool _isConnected;

    public string LensText
    {
        get => _lensText;
        set { _lensText = value; RaisePropertyChanged(); }
    }

    public bool IsConnected
    {
        get => _isConnected;
        set { _isConnected = value; RaisePropertyChanged(); }
    }

    [ImportingConstructor]
    public FujiLensInfoVM(IProfileService profileService, FujiCamera camera) : base(profileService)
    {
        _camera = camera;
        Title = "Fuji Lens";

        // Subscribe to camera connection changes
        _camera.PropertyChanged += OnCameraPropertyChanged;

        // Initial refresh
        RefreshLensInfo();
    }

    public override bool IsTool => true;  // Shows in tool pane (right side)

    private void OnCameraPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(FujiCamera.IsConnected))
        {
            RefreshLensInfo();
        }
    }

    private void RefreshLensInfo()
    {
        try
        {
            if (!_camera.IsConnected)
            {
                IsConnected = false;
                LensText = "Not connected";
                return;
            }

            IsConnected = true;

            var caps = _camera.GetCapabilitiesSnapshot();
            var meta = caps.Metadata;

            if (!string.IsNullOrWhiteSpace(meta.LensProductName))
            {
                var ois = meta.HasImageStabilization ? " [OIS]" : "";
                LensText = $"{meta.LensProductName}{ois}";
            }
            else
            {
                LensText = "No lens detected";
            }
        }
        catch (Exception)
        {
            LensText = "Error";
        }
    }
}
