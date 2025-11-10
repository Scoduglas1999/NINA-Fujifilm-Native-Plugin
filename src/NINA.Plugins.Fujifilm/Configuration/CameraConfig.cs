using System;
using System.Collections.Generic;

namespace NINA.Plugins.Fujifilm.Configuration;

public sealed class CameraConfig
{
    public string ModelName { get; set; } = string.Empty;
    public int CameraXSize { get; set; }
    public int CameraYSize { get; set; }
    public double PixelSizeX { get; set; }
    public double PixelSizeY { get; set; }
    public int MaxAdu { get; set; }
    public int DefaultMinSensitivity { get; set; }
    public int DefaultMaxSensitivity { get; set; }
    public double DefaultMinExposure { get; set; }
    public double DefaultMaxExposure { get; set; }
    public bool DefaultBulbCapable { get; set; }
    public SdkConstantConfig SdkConstants { get; set; } = new();
    public IReadOnlyList<ShutterSpeedMapping> ShutterSpeedMap { get; set; } = Array.Empty<ShutterSpeedMapping>();
}

public sealed class SdkConstantConfig
{
    public int ModeManual { get; set; }
    public int FocusModeManual { get; set; }
    public int ImageQualityRaw { get; set; }
    public int ImageQualityRawFine { get; set; }
    public int ImageQualityRawNormal { get; set; }
    public int ImageQualityRawSuperfine { get; set; }
}

public sealed class ShutterSpeedMapping
{
    public int SdkCode { get; set; }
    public double Duration { get; set; }
}
