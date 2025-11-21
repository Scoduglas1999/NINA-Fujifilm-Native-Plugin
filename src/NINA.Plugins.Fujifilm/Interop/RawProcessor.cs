using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace NINA.Plugins.Fujifilm.Interop;

/// <summary>
/// Hybrid LibRaw processor that uses LibRawWrapper.dll for data extraction
/// and direct P/Invoke to libraw.dll for advanced debayering (X-Trans support).
/// </summary>
public static class RawProcessor
{
    private static Type? _wrapperType;
    private static MethodInfo? _processMethod;

    static RawProcessor()
    {
        try
        {
            // Get the directory where this assembly is located
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string assemblyDirectory = Path.GetDirectoryName(assemblyLocation) ?? string.Empty;
            
            // Both LibRawWrapper.dll and libraw.dll should be in the root plugin directory
            // so Windows can find libraw.dll when loading LibRawWrapper.dll
            string wrapperPath = Path.Combine(assemblyDirectory, "LibRawWrapper.dll");
            
            // Load LibRawWrapper.dll via reflection
            if (File.Exists(wrapperPath))
            {
                var assembly = Assembly.LoadFrom(wrapperPath);
                _wrapperType = assembly.GetType("Fujifilm.LibRawWrapper.RawProcessor");
                // The actual method signature is: int ProcessRawBuffer(byte[] rawBuffer, out ushort[,] bayerData, out int width, out int height)
                _processMethod = _wrapperType?.GetMethod("ProcessRawBuffer", BindingFlags.Public | BindingFlags.Static);
            }
        }
        catch (Exception ex)
        {
            // Log the exception for debugging
            System.Diagnostics.Debug.WriteLine($"[RawProcessor] Failed to load LibRawWrapper: {ex.Message}");
        }
    }

    public static RawProcessingResult ProcessRawBuffer(byte[] buffer)
    {
        return ProcessRawBufferWithMetadata(buffer);
    }

    public static RawProcessingResult ProcessRawBufferWithMetadata(byte[] buffer)
    {
        var result = new RawProcessingResult
        {
            Success = false,
            Status = LibRawProcessingStatus.UnknownError,
            Width = 0,
            Height = 0,
            ColorFilterPattern = string.Empty,
            PatternWidth = 0,
            PatternHeight = 0,
            BayerData = Array.Empty<ushort>(),
            BlackLevel = 0,
            WhiteLevel = 65535
        };

        if (buffer == null || buffer.Length == 0)
        {
            result.Status = LibRawProcessingStatus.InvalidBuffer;
            return result;
        }

        // Try LibRawWrapper.dll first (most reliable)
        if (_processMethod != null)
        {
            try
            {
                // C++ signature: int ProcessRawBuffer(byte[] rawBuffer, out ushort[,] bayerData, out int width, out int height)
                object[] parameters = new object[] { buffer, null, 0, 0 };
                var returnCode = _processMethod.Invoke(null, parameters);
                
                // Extract out parameters
                var bayerData2D = parameters[1] as Array;
                int width = parameters[2] is int w ? w : 0;
                int height = parameters[3] is int h ? h : 0;
                int librawCode = returnCode is int code ? code : -1;
                
                if (librawCode == 0 && bayerData2D != null && width > 0 && height > 0) // LIBRAW_SUCCESS = 0
                {
                    result.Success = true;
                    result.Status = LibRawProcessingStatus.Success;
                    result.Width = width;
                    result.Height = height;
                    result.BayerData = ConvertToLinear(bayerData2D);
                    result.ColorFilterPattern = "XTRANS"; // GFX uses X-Trans
                    result.PatternWidth = 6;
                    result.PatternHeight = 6;
                    
                    // Perform debayering for X-Trans
                    result.DebayeredRgb = PerformDebayering(buffer, width, height);
                    
                    return result;
                }
                else
                {
                    string errorName = librawCode switch
                    {
                        -1 => "LIBRAW_UNSPECIFIED_ERROR",
                        -2 => "LIBRAW_FILE_UNSUPPORTED",
                        -3 => "LIBRAW_REQUEST_FOR_NONEXISTENT_IMAGE",
                        -4 => "LIBRAW_OUT_OF_ORDER_CALL",
                        -5 => "LIBRAW_NO_THUMBNAIL",
                        -6 => "LIBRAW_UNSUPPORTED_THUMBNAIL",
                        -7 => "LIBRAW_INPUT_CLOSED",
                        -100007 => "LIBRAW_UNSUFFICIENT_MEMORY",
                        -100008 => "LIBRAW_DATA_ERROR",
                        -100009 => "LIBRAW_IO_ERROR",
                        -100010 => "LIBRAW_CANCELLED_BY_CALLBACK",
                        -100011 => "LIBRAW_BAD_CROP",
                        _ => $"Unknown({librawCode})"
                    };
                    result.ErrorMessage = $"LibRawWrapper ProcessRawBuffer returned {errorName} (code {librawCode}), dims {width}x{height}";
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = $"LibRawWrapper failed: {ex.GetType().Name} - {ex.Message}";
                if (ex.InnerException != null)
                {
                    result.ErrorMessage += $"\nInner: {ex.InnerException.Message}";
                }
            }
        }
        else
        {
            // Get diagnostic info about why LibRawWrapper isn't loaded
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string assemblyDirectory = Path.GetDirectoryName(assemblyLocation) ?? string.Empty;
            string wrapperPath = Path.Combine(assemblyDirectory, "Interop", "Native", "LibRawWrapper.dll");
            
            bool fileExists = File.Exists(wrapperPath);
            result.ErrorMessage = $"LibRawWrapper.dll not loaded. Path: {wrapperPath}, Exists: {fileExists}, TypeLoaded: {_wrapperType != null}, MethodLoaded: {_processMethod != null}";
        }

        result.Status = LibRawProcessingStatus.WrapperUnavailable;
        return result;
    }

    private static RawProcessingResult MapWrapperResult(object wrapperResult)
    {
        var type = wrapperResult.GetType();
        
        var result = new RawProcessingResult
        {
            Success = ReadBoolProperty(wrapperResult, "Success"),
            Status = (LibRawProcessingStatus)ReadIntProperty(wrapperResult, "Status"),
            Width = ReadIntProperty(wrapperResult, "ImageWidth"),
            Height = ReadIntProperty(wrapperResult, "ImageHeight"),
            ColorFilterPattern = ReadStringProperty(wrapperResult, "ColorFilterPattern") ?? string.Empty,
            PatternWidth = ReadIntProperty(wrapperResult, "PatternWidth"),
            PatternHeight = ReadIntProperty(wrapperResult, "PatternHeight"),
            BlackLevel = ReadIntProperty(wrapperResult, "BlackLevel"),
            WhiteLevel = ReadIntProperty(wrapperResult, "WhiteLevel"),
            BayerData = ConvertToLinear(ReadArrayProperty(wrapperResult, "BayerData")),
            ErrorMessage = ReadStringProperty(wrapperResult, "ErrorMessage")
        };

        return result;
    }

    private static ushort[]? PerformDebayering(byte[] rawBuffer, int width, int height)
    {
        IntPtr processor = IntPtr.Zero;
        IntPtr bufferPtr = IntPtr.Zero;
        IntPtr processedImage = IntPtr.Zero;

        try
        {
            // Initialize LibRaw
            processor = LibRawNative.libraw_init(0);
            if (processor == IntPtr.Zero) return null;

            // Copy buffer to unmanaged memory
            bufferPtr = Marshal.AllocHGlobal(rawBuffer.Length);
            Marshal.Copy(rawBuffer, 0, bufferPtr, rawBuffer.Length);

            // Open and unpack
            int ret = LibRawNative.libraw_open_buffer(processor, bufferPtr, (UIntPtr)rawBuffer.Length);
            if (ret != LibRawNative.LIBRAW_SUCCESS) return null;

            ret = LibRawNative.libraw_unpack(processor);
            if (ret != LibRawNative.LIBRAW_SUCCESS) return null;

            // Process to RGB
            ret = LibRawNative.libraw_dcraw_process(processor);
            if (ret != LibRawNative.LIBRAW_SUCCESS) return null;

            // Get processed RGB image
            int errcode = 0;
            processedImage = LibRawNative.libraw_dcraw_make_mem_image(processor, ref errcode);
            if (processedImage == IntPtr.Zero || errcode != 0) return null;

            // Extract RGB data from processed image
            var imgStruct = Marshal.PtrToStructure<LibRawNative.LibRaw_ProcessedImage>(processedImage);
            
            if (imgStruct.colors != 3 || imgStruct.bits != 16)
                return null; // We expect 16-bit RGB

            int pixelCount = imgStruct.width * imgStruct.height;
            int rgbDataSize = pixelCount * 3; // 3 channels
            ushort[] rgbData = new ushort[rgbDataSize];

            // The data follows immediately after the header
            IntPtr dataPtr = IntPtr.Add(processedImage, Marshal.SizeOf<LibRawNative.LibRaw_ProcessedImage>());
            
            // Copy RGB data (LibRaw returns 16-bit values)
            short[] tempArray = new short[rgbDataSize];
            Marshal.Copy(dataPtr, tempArray, 0, rgbDataSize);
            Buffer.BlockCopy(tempArray, 0, rgbData, 0, rgbDataSize * sizeof(ushort));

            return rgbData;
        }
        catch
        {
            return null;
        }
        finally
        {
            if (processedImage != IntPtr.Zero)
                LibRawNative.libraw_dcraw_clear_mem(processedImage);
            
            if (bufferPtr != IntPtr.Zero)
                Marshal.FreeHGlobal(bufferPtr);
            
            if (processor != IntPtr.Zero)
                LibRawNative.libraw_close(processor);
        }
    }

    private static bool IsXTrans(string pattern)
    {
        return pattern.StartsWith("XTRANS", StringComparison.OrdinalIgnoreCase) ||
               pattern.StartsWith("X-TRANS", StringComparison.OrdinalIgnoreCase);
    }

    private static ushort[] ConvertToLinear(Array? plane)
    {
        if (plane == null) return Array.Empty<ushort>();

        var height = plane.GetLength(0);
        var width = plane.GetLength(1);
        var linear = new ushort[width * height];
        var index = 0;

        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var value = plane.GetValue(y, x);
                linear[index++] = value is ushort u ? u : Convert.ToUInt16(value ?? 0);
            }
        }

        return linear;
    }

    private static bool ReadBoolProperty(object instance, string propertyName)
    {
        return instance.GetType().GetProperty(propertyName)?.GetValue(instance) is bool value && value;
    }

    private static int ReadIntProperty(object instance, string propertyName)
    {
        return instance.GetType().GetProperty(propertyName)?.GetValue(instance) is int value ? value : 0;
    }

    private static string? ReadStringProperty(object instance, string propertyName)
    {
        return instance.GetType().GetProperty(propertyName)?.GetValue(instance)?.ToString();
    }

    private static Array? ReadArrayProperty(object instance, string propertyName)
    {
        return instance.GetType().GetProperty(propertyName)?.GetValue(instance) as Array;
    }
}

public class RawProcessingResult
{
    public bool Success { get; set; }
    public LibRawProcessingStatus Status { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string ColorFilterPattern { get; set; } = string.Empty;
    public int PatternWidth { get; set; }
    public int PatternHeight { get; set; }
    public ushort[] BayerData { get; set; } = Array.Empty<ushort>();
    public ushort[]? DebayeredRgb { get; set; }
    public int BlackLevel { get; set; }
    public int WhiteLevel { get; set; }
    public string? ErrorMessage { get; set; }
    public string? RafSidecarPath { get; set; }
}
