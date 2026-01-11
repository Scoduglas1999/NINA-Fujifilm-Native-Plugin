using NINA.Plugins.Fujifilm.Devices;
using NINA.Plugins.Fujifilm.Devices.LiveView;

namespace NINA.Plugins.Fujifilm.Settings;

/// <summary>
/// Demosaicing algorithm quality levels for RAW preview processing.
/// Higher quality = better image but slower processing.
/// </summary>
public enum DemosaicQuality
{
    /// <summary>
    /// Linear interpolation - fastest (~1s), slight softness on edges.
    /// Best for astrophotography where speed matters and subjects are soft.
    /// </summary>
    Fast = 0,

    /// <summary>
    /// VNG (Variable Number of Gradients) - balanced (~3-4s), good edge handling.
    /// Good compromise between speed and quality.
    /// </summary>
    Balanced = 1,

    /// <summary>
    /// AHD (Adaptive Homogeneity-Directed) - highest quality (~15s), best edges.
    /// Use when preview quality is more important than download speed.
    /// </summary>
    HighQuality = 3
}

public sealed class FujiSettings
{
    public string PreferredCameraId { get; set; } = string.Empty;
    public bool EnableSdkTrace { get; set; }
    public bool ForceManualExposureMode { get; set; } = true;
    public bool ForceManualFocusMode { get; set; } = true;
    public int BulbReleaseDelayMs { get; set; } = 500;
    public bool AutoDeleteNonRaw { get; set; } = true;
    public int FocusBacklashSteps { get; set; } = 0;
    public bool SaveNativeRafSidecar { get; set; } = false;
    public bool EnableExtendedFitsMetadata { get; set; } = true;

    /// <summary>
    /// Demosaicing quality for preview images. Higher quality = slower downloads.
    /// Default is Fast for quick ~1s downloads. Does not affect saved RAW files.
    /// </summary>
    public DemosaicQuality PreviewDemosaicQuality { get; set; } = DemosaicQuality.Fast;

    /// <summary>
    /// Drive/bracketing mode to use for captures.
    /// Default is Single Shot (Off) for normal astrophotography.
    /// </summary>
    public BracketingMode DriveMode { get; set; } = BracketingMode.Off;

    /// <summary>
    /// Live view image quality setting.
    /// Default is Normal for balanced speed and quality.
    /// </summary>
    public LiveViewQuality LiveViewQuality { get; set; } = LiveViewQuality.Normal;

    /// <summary>
    /// Live view image size setting.
    /// Default is Large (1280px) for best preview detail.
    /// </summary>
    public LiveViewSize LiveViewSize { get; set; } = LiveViewSize.Large;
}
