# NINA Fujifilm Plugin - Feature Enhancements Design

**Date:** 2026-01-10
**Version:** 2.5.0 (planned)
**Author:** Scdouglas + Claude

---

## Overview

This document outlines the implementation design for five new features in the NINA Fujifilm Plugin, based on analysis of the Fujifilm X SDK v13200.

**Note:** Sensor temperature was investigated but is NOT available. Fujifilm cameras do not record sensor temperature in metadata (unlike Canon, Nikon, Sony). See investigation notes at end of document.

---

## 1. Live View Streaming

### SDK Support
- **Start:** `API_CODE_StartLiveView = 0x3301`
- **Stop:** `API_CODE_StopLiveView = 0x3302`
- **Quality:** `API_CODE_SetLiveViewImageQuality = 0x3323` (Fine/Normal/Basic)
- **Size:** `API_CODE_SetLiveViewImageSize = 0x3325` (L=1280px, M=800px, S=640px)
- **Zoom:** `API_CODE_SetThroughImageZoom = 0x3327` (1x to 24x magnification)

### Implementation

#### New Files
```
Devices/LiveView/
  ILiveViewService.cs       - Interface for live view operations
  LiveViewService.cs        - Implementation with streaming loop
  LiveViewFrame.cs          - Frame data container
```

#### P/Invoke Additions (FujifilmSdkWrapper.cs)
```csharp
// Live View Control
[DllImport(SdkDllName)]
public static extern int XSDK_SetProp(IntPtr hCamera, int apiCode, int param, int value);

// Constants
public const int API_CODE_StartLiveView = 0x3301;
public const int API_CODE_StopLiveView = 0x3302;
public const int API_CODE_SetLiveViewImageQuality = 0x3323;
public const int API_CODE_SetLiveViewImageSize = 0x3325;
public const int API_CODE_SetThroughImageZoom = 0x3327;

public const int SDK_LIVEVIEW_QUALITY_FINE = 0x0001;
public const int SDK_LIVEVIEW_SIZE_L = 0x0001;  // 1280px
public const int SDK_LIVEVIEW_SIZE_M = 0x0002;  // 800px
public const int SDK_LIVEVIEW_SIZE_S = 0x0003;  // 640px
```

#### LiveViewService.cs
```csharp
public class LiveViewService : ILiveViewService
{
    private CancellationTokenSource _streamCts;
    private Task _streamTask;

    public event EventHandler<LiveViewFrame> FrameReceived;
    public bool IsStreaming { get; private set; }

    public async Task StartAsync(IntPtr handle, LiveViewQuality quality, LiveViewSize size)
    {
        // 1. Configure quality and size BEFORE starting
        FujifilmSdkWrapper.XSDK_SetProp(handle, API_CODE_SetLiveViewImageQuality, 1, (int)quality);
        FujifilmSdkWrapper.XSDK_SetProp(handle, API_CODE_SetLiveViewImageSize, 1, (int)size);

        // 2. Start live view
        var result = FujifilmSdkWrapper.XSDK_SetProp(handle, API_CODE_StartLiveView, 0, 0);
        if (result != XSDK_COMPLETE) throw new FujifilmSdkException(result);

        // 3. Begin polling loop
        _streamCts = new CancellationTokenSource();
        _streamTask = StreamFramesAsync(handle, _streamCts.Token);
        IsStreaming = true;
    }

    private async Task StreamFramesAsync(IntPtr handle, CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            var imageInfo = new XSDK_ImageInformation();
            var result = FujifilmSdkWrapper.XSDK_ReadImageInfo(handle, ref imageInfo);

            if (result == XSDK_COMPLETE && (imageInfo.lFormat & 0xFF) == XSDK_IMAGEFORMAT_LIVE)
            {
                var buffer = new byte[imageInfo.lDataSize];
                FujifilmSdkWrapper.XSDK_ReadImage(handle, buffer, imageInfo.lDataSize);

                // Frame is JPEG - raise event
                FrameReceived?.Invoke(this, new LiveViewFrame(buffer, imageInfo));

                // Delete from buffer
                FujifilmSdkWrapper.XSDK_DeleteImage(handle);
            }

            await Task.Delay(16, ct); // ~60fps max polling rate
        }
    }

    public async Task StopAsync(IntPtr handle)
    {
        _streamCts?.Cancel();
        if (_streamTask != null) await _streamTask;

        FujifilmSdkWrapper.XSDK_SetProp(handle, API_CODE_StopLiveView, 0, 0);
        IsStreaming = false;

        // Flush remaining images
        FlushBuffer(handle);
    }

    public void SetZoom(IntPtr handle, int zoomLevel)
    {
        // zoomLevel: 1-24 (maps to SDK_THROUGH_ZOOM_10 through SDK_THROUGH_ZOOM_240)
        FujifilmSdkWrapper.XSDK_SetProp(handle, API_CODE_SetThroughImageZoom, 1, zoomLevel);
    }
}
```

#### Integration with NINA
The `FujiCameraSdkAdapter` will expose:
```csharp
public bool CanShowLiveView => true;
public Task<bool> StartLiveViewAsync() { ... }
public Task StopLiveViewAsync() { ... }
public event EventHandler<byte[]> LiveViewFrameReceived;
```

### Complexity: High
### Priority: High (most requested feature)

---

## 2. Battery Level Display

### SDK Support
- **API Code:** `API_CODE_CheckBatteryInfo = 0x4055`
- **Called via:** `XSDK_GetProp(handle, 0x4055, param, &batteryLevel)`

### Implementation

#### P/Invoke Additions
```csharp
public const int API_CODE_CheckBatteryInfo = 0x4055;
```

#### FujiCameraMetadata.cs Additions
```csharp
public int BatteryLevel { get; set; }  // 0-100 percentage
public string BatteryStatus { get; set; }  // "OK", "Low", "Critical"
```

#### FujiCamera.cs - RefreshBatteryStatus()
```csharp
public void RefreshBatteryStatus()
{
    int batteryLevel = 0;
    var result = FujifilmSdkWrapper.XSDK_GetProp(
        _session.Handle,
        API_CODE_CheckBatteryInfo,
        1,  // param count
        ref batteryLevel);

    if (result == XSDK_COMPLETE)
    {
        _metadata.BatteryLevel = batteryLevel;
        _metadata.BatteryStatus = batteryLevel switch
        {
            > 50 => "OK",
            > 20 => "Low",
            _ => "Critical"
        };
    }
}
```

#### UI Display
Add to equipment info panel via `FujiCameraCapabilities`:
```csharp
public int BatteryLevel => _camera.Metadata.BatteryLevel;
```

### Complexity: Low
### Priority: High (essential for long sessions)

---

## 3. Lens Metadata Display

### SDK Support (Already Partially Implemented)
- **Lens Info:** `XSDK_GetLensInfo(handle, &lensInfo)` - Returns model, serial, capabilities
- **Zoom Position:** `XSDK_GetLensZoomPos(handle, &zoomPos)` - Current zoom position
- **Focal Length:** `XSDK_CapLensZoomPos(handle, ...)` - Maps zoom positions to focal lengths
- **Aperture:** `XSDK_GetAperture(handle, &fNumber)` - Current f-number

### Current State
Already retrieves `LensProductName` and `LensSerialNumber` in `FujiCameraMetadata`.

### Enhancements

#### FujiCameraMetadata.cs Additions
```csharp
// Existing
public string LensProductName { get; set; }
public string LensSerialNumber { get; set; }

// New
public int CurrentFocalLength { get; set; }      // mm
public int FocalLength35mmEquiv { get; set; }    // 35mm equivalent
public double CurrentAperture { get; set; }      // f-number (e.g., 2.8)
public bool HasImageStabilization { get; set; }
public bool HasManualFocus { get; set; }
public bool IsZoomLens { get; set; }
```

#### FujiCamera.cs - RefreshLensMetadata()
```csharp
public void RefreshLensMetadata()
{
    // Get lens info (already done on connect)
    var lensInfo = new XSDK_LensInformation();
    FujifilmSdkWrapper.XSDK_GetLensInfo(_session.Handle, ref lensInfo);

    _metadata.HasImageStabilization = lensInfo.lISCapability != 0;
    _metadata.HasManualFocus = lensInfo.lMFCapability != 0;
    _metadata.IsZoomLens = lensInfo.lZoomPosCapability != 0;

    // Get current aperture
    int fNumber = 0;
    if (FujifilmSdkWrapper.XSDK_GetAperture(_session.Handle, ref fNumber) == XSDK_COMPLETE)
    {
        _metadata.CurrentAperture = fNumber / 100.0; // SDK returns f*100
    }

    // Get focal length for zoom lenses
    if (_metadata.IsZoomLens)
    {
        int zoomPos = 0;
        FujifilmSdkWrapper.XSDK_GetLensZoomPos(_session.Handle, ref zoomPos);

        // Query zoom position to focal length mapping
        int numPos = 0;
        var positions = new int[100];
        var focalLengths = new int[100];
        var focal35mm = new int[100];

        FujifilmSdkWrapper.XSDK_CapLensZoomPos(
            _session.Handle, ref numPos, positions, focalLengths, focal35mm);

        // Find current focal length
        for (int i = 0; i < numPos; i++)
        {
            if (positions[i] == zoomPos)
            {
                _metadata.CurrentFocalLength = focalLengths[i];
                _metadata.FocalLength35mmEquiv = focal35mm[i];
                break;
            }
        }
    }
}
```

#### FITS Header Integration
Add to `CameraImageBuilder.cs`:
```csharp
header.Add("FOCALLEN", metadata.CurrentFocalLength, "Focal length (mm)");
header.Add("APTDIA", metadata.CurrentFocalLength / metadata.CurrentAperture, "Aperture diameter (mm)");
header.Add("INSTRUME", metadata.LensProductName, "Lens model");
```

### Complexity: Low
### Priority: Medium (useful metadata for FITS files)

---

## 4. Bracketing Control

### SDK Support
- **Drive Mode:** `API_CODE_SetDriveMode = 0x1377` / `GetDriveMode = 0x1378` / `CapDriveMode = 0x1379`
- **Bracket Modes:**
  - `XSDK_DRIVE_MODE_BKT_AE = 0x000A` - Auto Exposure bracketing
  - `XSDK_DRIVE_MODE_BKT_ISO = 0x000B` - ISO bracketing
  - `XSDK_DRIVE_MODE_BKT_FOCUS = 0x000F` - Focus bracketing
  - `XSDK_DRIVE_MODE_BKT_DYNAMICRANGE = 0x000E` - Dynamic range bracketing

### Implementation

#### BracketingMode Enum
```csharp
public enum BracketingMode
{
    Off = 0x0001,           // SDK_DRIVE_MODE_S (Single)
    ExposureBracketing = 0x000A,
    IsoBracketing = 0x000B,
    FocusBracketing = 0x000F,
    DynamicRangeBracketing = 0x000E
}
```

#### FujiSettings.cs Additions
```csharp
public BracketingMode BracketMode { get; set; } = BracketingMode.Off;
public int BracketCount { get; set; } = 3;      // Number of shots
public double BracketStepEV { get; set; } = 1.0; // EV steps for AE bracketing
```

#### FujiCamera.cs - SetBracketingMode()
```csharp
public void SetBracketingMode(BracketingMode mode)
{
    var result = FujifilmSdkWrapper.XSDK_SetDriveMode(_session.Handle, (int)mode);
    if (result != XSDK_COMPLETE)
        throw new FujifilmSdkException(result, "Failed to set bracketing mode");
}

public BracketingMode GetBracketingMode()
{
    int mode = 0;
    FujifilmSdkWrapper.XSDK_GetDriveMode(_session.Handle, ref mode);
    return (BracketingMode)mode;
}

public IReadOnlyList<BracketingMode> GetSupportedBracketingModes()
{
    int count = 0;
    var modes = new int[20];
    FujifilmSdkWrapper.XSDK_CapDriveMode(_session.Handle, ref count, modes);

    return modes.Take(count)
        .Where(m => m >= 0x000A && m <= 0x000F) // Filter to bracket modes
        .Cast<BracketingMode>()
        .ToList();
}
```

#### UI Integration (SettingsView.xaml)
```xml
<TextBlock Text="Bracketing Mode" FontWeight="SemiBold"/>
<ComboBox SelectedValue="{Binding Settings.BracketMode, Mode=TwoWay}"
          SelectedValuePath="Tag">
    <ComboBoxItem Content="Off" Tag="{x:Static local:BracketingMode.Off}"/>
    <ComboBoxItem Content="Exposure (AEB)" Tag="{x:Static local:BracketingMode.ExposureBracketing}"/>
    <ComboBoxItem Content="ISO" Tag="{x:Static local:BracketingMode.IsoBracketing}"/>
    <ComboBoxItem Content="Focus" Tag="{x:Static local:BracketingMode.FocusBracketing}"/>
</ComboBox>
<TextBlock TextWrapping="Wrap" Foreground="Gray">
    Bracketing takes multiple shots with varied settings.
    Useful for HDR lunar/planetary imaging.
</TextBlock>
```

### Complexity: Medium
### Priority: Medium (useful for HDR work)

---

## 5. Custom Shooting Profiles

### SDK Support
This is a plugin-side feature - save/restore camera settings as named profiles.

### Implementation

#### CameraProfile.cs
```csharp
public class CameraProfile
{
    public string Name { get; set; }
    public DateTime Created { get; set; }

    // Capture settings
    public int Iso { get; set; }
    public double ExposureTime { get; set; }
    public DemosaicQuality PreviewQuality { get; set; }
    public bool SaveRafSidecar { get; set; }

    // Drive mode
    public BracketingMode BracketMode { get; set; }

    // Notes
    public string Description { get; set; }
}
```

#### ProfileManager.cs
```csharp
public class ProfileManager
{
    private readonly string _profilesPath;
    private List<CameraProfile> _profiles = new();

    public ProfileManager(string basePath)
    {
        _profilesPath = Path.Combine(basePath, "profiles.json");
        Load();
    }

    public IReadOnlyList<CameraProfile> Profiles => _profiles;

    public void SaveProfile(string name, FujiSettings settings, FujiCamera camera)
    {
        var profile = new CameraProfile
        {
            Name = name,
            Created = DateTime.Now,
            Iso = camera.CurrentIso,
            ExposureTime = camera.CurrentExposure,
            PreviewQuality = settings.PreviewDemosaicQuality,
            SaveRafSidecar = settings.SaveNativeRafSidecar,
            BracketMode = camera.GetBracketingMode()
        };

        _profiles.Add(profile);
        Save();
    }

    public async Task ApplyProfileAsync(CameraProfile profile, FujiSettings settings, FujiCamera camera)
    {
        settings.PreviewDemosaicQuality = profile.PreviewQuality;
        settings.SaveNativeRafSidecar = profile.SaveRafSidecar;

        await camera.SetIsoAsync(profile.Iso);
        camera.SetBracketingMode(profile.BracketMode);
    }

    public void DeleteProfile(string name) { ... }
    private void Load() { ... }
    private void Save() { ... }
}
```

#### UI Integration
```xml
<GroupBox Header="Shooting Profiles">
    <StackPanel>
        <ComboBox ItemsSource="{Binding Profiles}"
                  SelectedItem="{Binding SelectedProfile}"
                  DisplayMemberPath="Name"/>
        <StackPanel Orientation="Horizontal">
            <Button Content="Apply" Command="{Binding ApplyProfileCommand}"/>
            <Button Content="Save Current" Command="{Binding SaveProfileCommand}"/>
            <Button Content="Delete" Command="{Binding DeleteProfileCommand}"/>
        </StackPanel>
    </StackPanel>
</GroupBox>
```

### Complexity: Low
### Priority: Low (convenience feature)

---

## Implementation Priority

Based on user value and complexity:

| Phase | Features | Effort |
|-------|----------|--------|
| **Phase 1** | Battery Level | Low |
| **Phase 2** | Lens Metadata enhancements | Low |
| **Phase 3** | Bracketing Control | Medium |
| **Phase 4** | Live View Streaming | High |
| **Phase 5** | Custom Profiles | Low |

---

## Notes

### Electronic Shutter
The `SilentMode` API (`0x4021`/`0x4022`) returns `-1` parameter count on most cameras (X-H2, X-H2S, X-T5, X-M5, GFX series), indicating it's not controllable via SDK on these models. Users must set electronic shutter via camera menu. **Not recommended for implementation.**

### Live View Frame Rate
The SDK doesn't expose frame rate control. Actual FPS depends on:
- USB connection speed
- Image quality/size settings
- Camera processing overhead

Expect 15-30 fps with USB 3.0 and L/Fine quality.

---

## Appendix: Sensor Temperature Investigation

### Finding: NOT AVAILABLE

Sensor temperature was thoroughly investigated as a potential feature for dark frame matching in astrophotography. **Fujifilm cameras do not record sensor temperature.**

### Investigation Results

1. **Fujifilm SDK** - Only provides `GetBodyTemperatureWarning` (API 0x4278) which returns overheating warnings (NONE/YELLOW/RED) for video recording protection. This is body/electronics temperature, not imaging sensor temperature.

2. **RAF MakerNote EXIF** - Reviewed complete [ExifTool FujiFilm tag list](https://exiftool.org/TagNames/FujiFilm.html). No temperature tags exist. Only `ColorTemperature` (0x1005) for white balance Kelvin value.

3. **Cross-manufacturer comparison** - Per [Exiv2 feature request #1219](https://dev.exiv2.org/issues/1219), only Canon, Nikon, and Sony record sensor temperature in metadata. Fujifilm is not mentioned.

4. **RAF file structure** - The proprietary Fujifilm RAF format contains no documented or undocumented temperature fields.

### Conclusion

This is a hardware/firmware limitation of Fujifilm cameras - they simply don't have temperature sensors that log to image metadata (or the SDK doesn't expose them).

### Workaround for Astrophotography

For dark frame calibration with uncooled Fujifilm cameras:
- Take darks in the field at session end (temperature-matched)
- Use dark scaling software (PixInsight, Astro Pixel Processor, DeepSkyStacker)
- Build dark libraries organized by ambient temperature ranges
