namespace NINA.Plugins.Fujifilm.Devices;

/// <summary>
/// Bracketing modes supported by Fujifilm cameras via the Drive Mode API.
/// Values correspond to SDK constants from XAPI.h.
/// </summary>
public enum BracketingMode
{
    /// <summary>
    /// Single shot mode - no bracketing.
    /// SDK: XSDK_DRIVE_MODE_S = 0x0001
    /// </summary>
    Off = 0x0001,

    /// <summary>
    /// Continuous Low speed shooting.
    /// SDK: XSDK_DRIVE_MODE_CL = 0x0002
    /// </summary>
    ContinuousLow = 0x0002,

    /// <summary>
    /// Continuous High speed shooting.
    /// SDK: XSDK_DRIVE_MODE_CH = 0x0003
    /// </summary>
    ContinuousHigh = 0x0003,

    /// <summary>
    /// Continuous Boost speed shooting.
    /// SDK: XSDK_DRIVE_MODE_BOOST = 0x0004
    /// </summary>
    ContinuousBoost = 0x0004,

    /// <summary>
    /// Auto Exposure Bracketing - varies exposure time.
    /// Useful for HDR lunar/planetary imaging.
    /// SDK: XSDK_DRIVE_MODE_BKT_AE = 0x000A
    /// </summary>
    ExposureBracketing = 0x000A,

    /// <summary>
    /// ISO Bracketing - varies ISO sensitivity.
    /// SDK: XSDK_DRIVE_MODE_BKT_ISO = 0x000B
    /// </summary>
    IsoBracketing = 0x000B,

    /// <summary>
    /// Dynamic Range Bracketing.
    /// SDK: XSDK_DRIVE_MODE_BKT_DYNAMICRANGE = 0x000E
    /// </summary>
    DynamicRangeBracketing = 0x000E,

    /// <summary>
    /// Focus Bracketing - varies focus position.
    /// Useful for focus stacking.
    /// SDK: XSDK_DRIVE_MODE_BKT_FOCUS = 0x000F
    /// </summary>
    FocusBracketing = 0x000F
}

/// <summary>
/// Extension methods for BracketingMode enum.
/// </summary>
public static class BracketingModeExtensions
{
    /// <summary>
    /// Gets a human-readable display name for the bracketing mode.
    /// </summary>
    public static string GetDisplayName(this BracketingMode mode)
    {
        return mode switch
        {
            BracketingMode.Off => "Single Shot",
            BracketingMode.ContinuousLow => "Continuous Low",
            BracketingMode.ContinuousHigh => "Continuous High",
            BracketingMode.ContinuousBoost => "Continuous Boost",
            BracketingMode.ExposureBracketing => "Exposure Bracketing (AEB)",
            BracketingMode.IsoBracketing => "ISO Bracketing",
            BracketingMode.DynamicRangeBracketing => "Dynamic Range Bracketing",
            BracketingMode.FocusBracketing => "Focus Bracketing",
            _ => mode.ToString()
        };
    }

    /// <summary>
    /// Returns true if this mode involves capturing multiple shots automatically.
    /// </summary>
    public static bool IsMultiShotMode(this BracketingMode mode)
    {
        return mode switch
        {
            BracketingMode.ExposureBracketing => true,
            BracketingMode.IsoBracketing => true,
            BracketingMode.DynamicRangeBracketing => true,
            BracketingMode.FocusBracketing => true,
            _ => false
        };
    }
}
