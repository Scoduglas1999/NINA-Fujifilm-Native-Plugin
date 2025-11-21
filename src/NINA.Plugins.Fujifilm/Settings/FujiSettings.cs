namespace NINA.Plugins.Fujifilm.Settings;

public sealed class FujiSettings
{
    public string PreferredCameraId { get; set; } = string.Empty;
    public bool EnableSdkTrace { get; set; }
    public bool ForceManualExposureMode { get; set; } = true;
    public bool ForceManualFocusMode { get; set; } = true;
    public int BulbReleaseDelayMs { get; set; } = 500;
    public bool AutoDeleteNonRaw { get; set; } = true;
    public int FocusBacklashSteps { get; set; } = 0;
    public bool SaveNativeRafSidecar { get; set; } = true;
    public bool EnableExtendedFitsMetadata { get; set; } = true;
}
