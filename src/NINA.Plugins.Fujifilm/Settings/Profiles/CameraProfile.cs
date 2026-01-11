using System;
using NINA.Plugins.Fujifilm.Devices;
using NINA.Plugins.Fujifilm.Devices.LiveView;

namespace NINA.Plugins.Fujifilm.Settings.Profiles;

/// <summary>
/// Represents a saved camera profile that can be quickly applied.
/// </summary>
public sealed class CameraProfile
{
    /// <summary>
    /// Unique identifier for this profile.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// User-defined name for this profile.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Optional description of this profile's purpose.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// When this profile was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// When this profile was last modified.
    /// </summary>
    public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;

    // Capture Settings
    /// <summary>
    /// ISO sensitivity value.
    /// </summary>
    public int Iso { get; set; } = 800;

    /// <summary>
    /// Exposure time in seconds (for reference, not directly applied).
    /// </summary>
    public double ExposureTime { get; set; } = 30.0;

    // Plugin Settings
    /// <summary>
    /// Preview demosaicing quality.
    /// </summary>
    public DemosaicQuality PreviewQuality { get; set; } = DemosaicQuality.Fast;

    /// <summary>
    /// Whether to save RAF sidecar files.
    /// </summary>
    public bool SaveRafSidecar { get; set; } = false;

    /// <summary>
    /// Whether to enable extended FITS metadata.
    /// </summary>
    public bool EnableExtendedFitsMetadata { get; set; } = true;

    // Drive Mode
    /// <summary>
    /// Drive/bracketing mode.
    /// </summary>
    public BracketingMode DriveMode { get; set; } = BracketingMode.Off;

    // Live View Settings
    /// <summary>
    /// Live view image quality.
    /// </summary>
    public LiveViewQuality LiveViewQuality { get; set; } = LiveViewQuality.Normal;

    /// <summary>
    /// Live view image size.
    /// </summary>
    public LiveViewSize LiveViewSize { get; set; } = LiveViewSize.Large;

    /// <summary>
    /// Creates a default profile for deep sky imaging.
    /// </summary>
    public static CameraProfile CreateDeepSkyDefault()
    {
        return new CameraProfile
        {
            Name = "Deep Sky Default",
            Description = "Optimized settings for deep sky imaging with fast downloads.",
            Iso = 1600,
            ExposureTime = 120.0,
            PreviewQuality = DemosaicQuality.Fast,
            SaveRafSidecar = false,
            EnableExtendedFitsMetadata = true,
            DriveMode = BracketingMode.Off
        };
    }

    /// <summary>
    /// Creates a default profile for lunar/planetary imaging.
    /// </summary>
    public static CameraProfile CreatePlanetaryDefault()
    {
        return new CameraProfile
        {
            Name = "Planetary Default",
            Description = "Settings for lunar and planetary imaging with high quality preview.",
            Iso = 400,
            ExposureTime = 0.001,
            PreviewQuality = DemosaicQuality.HighQuality,
            SaveRafSidecar = false,
            EnableExtendedFitsMetadata = true,
            DriveMode = BracketingMode.Off
        };
    }

    /// <summary>
    /// Creates a default profile for HDR lunar imaging with exposure bracketing.
    /// </summary>
    public static CameraProfile CreateLunarHdrDefault()
    {
        return new CameraProfile
        {
            Name = "Lunar HDR",
            Description = "Exposure bracketing for HDR lunar imaging.",
            Iso = 200,
            ExposureTime = 0.01,
            PreviewQuality = DemosaicQuality.Balanced,
            SaveRafSidecar = false,
            EnableExtendedFitsMetadata = true,
            DriveMode = BracketingMode.ExposureBracketing
        };
    }
}
