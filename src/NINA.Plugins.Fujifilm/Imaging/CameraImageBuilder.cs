using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using NINA.Plugins.Fujifilm.Configuration;
using NINA.Plugins.Fujifilm.Diagnostics;
using NINA.Plugins.Fujifilm.Devices;
using NINA.Plugins.Fujifilm.Interop;
using NINA.Plugins.Fujifilm.Settings;

namespace NINA.Plugins.Fujifilm.Imaging;

internal sealed class CameraImageBuilder
{
    private readonly IFujiSettingsProvider _settingsProvider;
    private readonly IFujifilmDiagnosticsService _diagnostics;

    public CameraImageBuilder(IFujiSettingsProvider settingsProvider, IFujifilmDiagnosticsService diagnostics)
    {
        _settingsProvider = settingsProvider;
        _diagnostics = diagnostics;
    }

    public FujiImagePackage Build(
        RawCaptureResult raw,
        LibRawResult processed,
        FujiCameraCapabilities capabilities,
        CameraConfig? config)
    {
        var width = DetermineDimension(processed.Width, raw.Width, config?.CameraXSize ?? 0);
        var height = DetermineDimension(processed.Height, raw.Height, config?.CameraYSize ?? 0);
        var pixels = processed.Success && processed.BayerData.Length == width * height
            ? processed.BayerData
            : new ushort[Math.Max(1, width * height)];

        var (pattern, patternWidth, patternHeight) = ResolvePattern(processed, capabilities, config);
        var rafPath = ResolveRafSidecar(raw, processed);
        var metadata = BuildMetadata(raw, processed, capabilities, pattern, rafPath, config);
        
        // Get debayered RGB data if available (for X-Trans display in NINA)
        var debayeredRgb = processed.GetDebayeredRgb();
        if (debayeredRgb != null && debayeredRgb.Length == width * height * 3)
        {
            _diagnostics.RecordEvent("CameraImageBuilder", $"Debayered RGB data available: {debayeredRgb.Length} pixels (RGB)");
        }

        return new FujiImagePackage(
            pixels,
            width,
            height,
            pattern,
            patternWidth,
            patternHeight,
            metadata,
            rafPath,
            debayeredRgb);
    }

    private int DetermineDimension(int libRawValue, int rawValue, int fallback)
    {
        if (libRawValue > 0)
        {
            return libRawValue;
        }

        if (rawValue > 0)
        {
            return rawValue;
        }

        return Math.Max(1, fallback);
    }

    private (string Pattern, int Width, int Height) ResolvePattern(
        LibRawResult processed,
        FujiCameraCapabilities capabilities,
        CameraConfig? config)
    {
        // If LibRaw provided pattern, use it (already validated in LibRawAdapter)
        if (!string.IsNullOrWhiteSpace(processed.ColorFilterPattern))
        {
            var pattern = processed.ColorFilterPattern;
            var width = processed.PatternWidth > 0 ? processed.PatternWidth : 
                       (pattern.StartsWith("XTRANS", StringComparison.OrdinalIgnoreCase) ? 6 : 2);
            var height = processed.PatternHeight > 0 ? processed.PatternHeight : 
                        (pattern.StartsWith("XTRANS", StringComparison.OrdinalIgnoreCase) ? 6 : 2);
            _diagnostics.RecordEvent("CameraImageBuilder", $"Using LibRaw pattern: {pattern} ({width}x{height})");
            return (pattern, width, height);
        }

        // Fallback: infer from camera model
        var fallbackPattern = InferPatternFromModel(capabilities.Metadata.ProductName, config?.ModelName);
        var fallbackSize = fallbackPattern.StartsWith("XTRANS", StringComparison.OrdinalIgnoreCase) ? 6 : 2;
        _diagnostics.RecordEvent("CameraImageBuilder", $"LibRaw pattern not available, inferred from model: {fallbackPattern} ({fallbackSize}x{fallbackSize})");
        return (fallbackPattern, fallbackSize, fallbackSize);
    }

    private static string InferPatternFromModel(string productName, string? modelName)
    {
        var name = (modelName ?? productName ?? string.Empty).Trim();
        if (name.StartsWith("GFX", StringComparison.OrdinalIgnoreCase))
        {
            return "RGGB";
        }

        if (name.StartsWith("X-", StringComparison.OrdinalIgnoreCase))
        {
            return "XTRANS";
        }

        return "RGGB";
    }

    private string? ResolveRafSidecar(RawCaptureResult raw, LibRawResult processed)
    {
        if (!string.IsNullOrEmpty(processed.RafSidecarPath))
        {
            return processed.RafSidecarPath;
        }

        if (!_settingsProvider.Settings.SaveNativeRafSidecar || raw.RawBuffer.Length == 0)
        {
            return null;
        }

        try
        {
            var directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NINA", "Plugins", "Fujifilm", "Frames");
            Directory.CreateDirectory(directory);
            var filePath = Path.Combine(directory, $"native-{DateTime.UtcNow:yyyyMMdd-HHmmssfff}.raf");
            File.WriteAllBytes(filePath, raw.RawBuffer);
            return filePath;
        }
        catch (Exception ex)
        {
            _diagnostics.RecordEvent("CameraImageBuilder", $"Failed to persist RAF sidecar: {ex.Message}");
            return null;
        }
    }

    private IReadOnlyDictionary<string, string> BuildMetadata(
        RawCaptureResult raw,
        LibRawResult processed,
        FujiCameraCapabilities capabilities,
        string pattern,
        string? rafPath,
        CameraConfig? config)
    {
        var metadata = new Dictionary<string, string>
        {
            ["EXPTIME"] = raw.ExposureSeconds.ToString("0.###", CultureInfo.InvariantCulture),
            ["ISO"] = raw.Iso.ToString(CultureInfo.InvariantCulture),
            ["ROWORDER"] = "TOP-DOWN"
        };

        // Critical bayer pattern metadata (required for PixInsight)
        if (!string.IsNullOrEmpty(pattern))
        {
            // Standardize pattern name for FITS/XISF compatibility
            var standardizedPattern = pattern.ToUpperInvariant();
            if (standardizedPattern.StartsWith("XTRANS", StringComparison.OrdinalIgnoreCase) || 
                standardizedPattern.StartsWith("X-", StringComparison.OrdinalIgnoreCase))
            {
                standardizedPattern = "XTRANS";
            }

            metadata["BAYERPAT"] = standardizedPattern;
            
            // Determine pattern dimensions
            var patternWidth = processed.PatternWidth > 0 ? processed.PatternWidth : 
                             (standardizedPattern == "XTRANS" ? 6 : 2);
            var patternHeight = processed.PatternHeight > 0 ? processed.PatternHeight : 
                              (standardizedPattern == "XTRANS" ? 6 : 2);
            
            metadata["CFAAXIS"] = $"{patternWidth}x{patternHeight}";
            metadata["CFA"] = "1"; // Indicates color filter array present
            
            // For X-Trans: Indicate that debayered RGB data is available for preview
            // This metadata might help NINA understand that the image is already debayered
            if (standardizedPattern == "XTRANS")
            {
                // Check if debayered RGB is available (will be set later in the package)
                // This is a hint that the image has been debayered non-destructively
                metadata["DEBAYERED"] = "1"; // Indicates debayered data available
            }
        }

        // Standard astrophotography keywords
        metadata["XBINNING"] = "1";
        metadata["YBINNING"] = "1";
        metadata["XBAYROFF"] = "0";
        metadata["YBAYROFF"] = "0";

        // Camera model information
        if (!string.IsNullOrEmpty(capabilities.Metadata.ProductName))
        {
            metadata["INSTRUME"] = capabilities.Metadata.ProductName;
            metadata["CAMERA"] = capabilities.Metadata.ProductName; // Duplicate for stacking software compatibility
        }

        // Sensor type identifier
        if (!string.IsNullOrEmpty(pattern))
        {
            var sensorType = pattern.StartsWith("XTRANS", StringComparison.OrdinalIgnoreCase) ? "X-Trans CMOS" : "Bayer CMOS";
            metadata["SENSOR"] = sensorType;
        }

        // Pixel size (from config, in microns)
        if (config != null)
        {
            if (config.PixelSizeX > 0)
            {
                metadata["XPIXSZ"] = config.PixelSizeX.ToString("0.##", CultureInfo.InvariantCulture);
            }
            if (config.PixelSizeY > 0)
            {
                metadata["YPIXSZ"] = config.PixelSizeY.ToString("0.##", CultureInfo.InvariantCulture);
            }
        }

        if (_settingsProvider.Settings.EnableExtendedFitsMetadata)
        {
            metadata["FUJIMODE"] = capabilities.Metadata.ProductName;
            metadata["FUJIISO"] = raw.Iso.ToString(CultureInfo.InvariantCulture);
            metadata["FUJISHUT"] = raw.ShutterCode.ToString(CultureInfo.InvariantCulture);
            metadata["FUJILENS"] = capabilities.Metadata.LensProductName;
            metadata["FUJILENSSN"] = capabilities.Metadata.LensSerialNumber;
            metadata["XTNSPAT"] = pattern;
            metadata["BLACKLVL"] = processed.BlackLevel.ToString(CultureInfo.InvariantCulture);
            metadata["WHITELVL"] = processed.WhiteLevel.ToString(CultureInfo.InvariantCulture);
            metadata["FUJIDR"] = capabilities.Metadata.DynamicRangeCode.ToString(CultureInfo.InvariantCulture);
            if (!string.IsNullOrEmpty(rafPath))
            {
                metadata["RAF_PATH"] = rafPath;
            }
        }

        var bayerPattern = metadata.GetValueOrDefault("BAYERPAT", null);
        _diagnostics.RecordFitsKeywordGeneration(metadata.Count, bayerPattern);

        return metadata;
    }
}

public sealed record FujiImagePackage(
    ushort[] Pixels,
    int Width,
    int Height,
    string ColorFilterPattern,
    int PatternWidth,
    int PatternHeight,
    IReadOnlyDictionary<string, string> FitsKeywords,
    string? RafSidecarPath,
    ushort[]? DebayeredRgb = null)
{
    public static FujiImagePackage Empty { get; } = new(
        Array.Empty<ushort>(),
        0,
        0,
        string.Empty,
        0,
        0,
        new Dictionary<string, string>(),
        null,
        null);
    
    /// <summary>
    /// Gets debayered RGB data if available (for X-Trans display in NINA).
    /// Returns null if not available. Data is in RGBRGB... format, length = Width * Height * 3.
    /// </summary>
    public ushort[]? GetDebayeredRgb() => DebayeredRgb;

    /// <summary>
    /// Gets XISF-compatible properties from FITS keywords.
    /// NINA handles XISF file writing, but we ensure metadata is XISF-compatible.
    /// </summary>
    public IReadOnlyDictionary<string, object> GetXisfProperties()
    {
        var properties = new Dictionary<string, object>();

        // Critical X-Trans properties for XISF
        if (!string.IsNullOrEmpty(ColorFilterPattern))
        {
            var standardizedPattern = ColorFilterPattern.ToUpperInvariant();
            if (standardizedPattern.StartsWith("XTRANS", StringComparison.OrdinalIgnoreCase) ||
                standardizedPattern.StartsWith("X-", StringComparison.OrdinalIgnoreCase))
            {
                standardizedPattern = "XTRANS";
            }

            properties["BAYERPAT"] = standardizedPattern;
            properties["CFAAXIS"] = $"{PatternWidth}x{PatternHeight}";
            properties["CFA"] = true;
        }

        // Convert FITS keywords to XISF properties
        foreach (var kvp in FitsKeywords)
        {
            if (properties.ContainsKey(kvp.Key))
            {
                continue;
            }

            // Convert to appropriate type for XISF
            if (TryConvertToXisfType(kvp.Key, kvp.Value, out var typedValue))
            {
                properties[kvp.Key] = typedValue;
            }
            else
            {
                properties[kvp.Key] = kvp.Value;
            }
        }

        return properties;
    }

    private static bool TryConvertToXisfType(string key, string value, out object? typedValue)
    {
        typedValue = null;

        // Numeric properties
        if (key == "EXPTIME" || key == "XPIXSZ" || key == "YPIXSZ" || key == "EGAIN")
        {
            if (double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out var dbl))
            {
                typedValue = dbl;
                return true;
            }
        }

        if (key == "ISO" || key == "XBINNING" || key == "YBINNING" ||
            key == "XBAYROFF" || key == "YBAYROFF" || key == "BLACKLVL" ||
            key == "WHITELVL" || key == "FUJIISO" || key == "FUJISHUT" ||
            key == "FUJIDR")
        {
            if (int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var intVal))
            {
                typedValue = intVal;
                return true;
            }
        }

        // Boolean properties
        if (key == "CFA")
        {
            if (bool.TryParse(value, out var boolVal))
            {
                typedValue = boolVal;
                return true;
            }
            if (value == "1" || value == "true" || value == "True")
            {
                typedValue = true;
                return true;
            }
            if (value == "0" || value == "false" || value == "False")
            {
                typedValue = false;
                return true;
            }
        }

        return false;
    }
}

