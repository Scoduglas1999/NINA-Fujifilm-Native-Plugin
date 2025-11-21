using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using NINA.Plugins.Fujifilm.Diagnostics;

namespace NINA.Plugins.Fujifilm.Interop;

public interface ILibRawAdapter
{
    Task<LibRawResult> ProcessRawAsync(byte[] buffer, CancellationToken cancellationToken);
}

[Export(typeof(ILibRawAdapter))]
[PartCreationPolicy(CreationPolicy.Shared)]
public sealed class LibRawAdapter : ILibRawAdapter
{
    private readonly IFujifilmDiagnosticsService _diagnostics;

    [ImportingConstructor]
    public LibRawAdapter(IFujifilmDiagnosticsService diagnostics)
    {
        try { System.IO.File.AppendAllText(@"c:\Users\scdou\Documents\NINA.Fujifilm.Plugin\debug_log.txt", $"[{DateTime.Now}] LibRawAdapter Constructor called\n"); } catch {}
        _diagnostics = diagnostics;
    }

    public async Task<LibRawResult> ProcessRawAsync(byte[] buffer, CancellationToken cancellationToken)
    {
        if (buffer == null || buffer.Length == 0)
        {
            _diagnostics.RecordEvent("LibRaw", "Empty buffer provided; skipping processing.");
            return LibRawResult.FromFailure(LibRawProcessingStatus.InvalidBuffer, null);
        }

        return await Task.Run(() =>
        {
            RawProcessingResult processed;
            
            try
            {
                processed = RawProcessor.ProcessRawBufferWithMetadata(buffer);
            }
            catch (Exception ex)
            {
                _diagnostics.RecordEvent("LibRaw", $"RawProcessor threw exception: {ex.GetType().Name} - {ex.Message}");
                _diagnostics.RecordEvent("LibRaw", $"Exception stack trace: {ex.StackTrace}");
                if (ex.InnerException != null)
                {
                    _diagnostics.RecordEvent("LibRaw", $"Inner exception: {ex.InnerException.GetType().Name} - {ex.InnerException.Message}");
                }
                var rafPath = TryPersistRaf(buffer);
                return LibRawResult.FromFailure(LibRawProcessingStatus.UnhandledException, rafPath);
            }

            if (!processed.Success)
            {
                var rafPath = processed.RafSidecarPath ?? TryPersistRaf(buffer);
                processed.RafSidecarPath = rafPath;
            }

            _diagnostics.RecordEvent("LibRaw", $"LibRaw status={processed.Status} size={processed.Width}x{processed.Height} pattern={processed.ColorFilterPattern} ({processed.PatternWidth}x{processed.PatternHeight}) sidecar={(processed.RafSidecarPath ?? "none")}");
            
            if (!string.IsNullOrEmpty(processed.ErrorMessage))
            {
                _diagnostics.RecordEvent("LibRaw", $"Error details: {processed.ErrorMessage}");
            }
            
            // Diagnostic logging for black image investigation
            if (processed.BayerData != null && processed.BayerData.Length > 0)
            {
                var samplePixels = string.Join(" ", processed.BayerData.Take(20));
                _diagnostics.RecordEvent("LibRaw", $"Bayer data sample (first 20 pixels): {samplePixels}");
                
                // Check for all zeros
                bool allZeros = true;
                for (int i = 0; i < Math.Min(processed.BayerData.Length, 1000); i++)
                {
                    if (processed.BayerData[i] != 0)
                    {
                        allZeros = false;
                        break;
                    }
                }
                if (allZeros) _diagnostics.RecordEvent("LibRaw", "WARNING: First 1000 pixels are all zeros!");
            }
            else
            {
                _diagnostics.RecordEvent("LibRaw", "WARNING: BayerData is null or empty!");
            }

            return MapToLibRawResult(processed);
        }, cancellationToken).ConfigureAwait(false);
    }

    private string? TryPersistRaf(byte[] buffer)
    {
        try
        {
            var directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NINA", "Plugins", "Fujifilm", "Frames");
            Directory.CreateDirectory(directory);
            var path = Path.Combine(directory, $"frame-{DateTime.UtcNow:yyyyMMdd-HHmmssfff}.raf");
            File.WriteAllBytes(path, buffer);
            return path;
        }
        catch (Exception ex)
        {
            _diagnostics.RecordEvent("LibRaw", $"Failed to persist RAF sidecar: {ex.Message}");
            return null;
        }
    }

    private LibRawResult MapToLibRawResult(RawProcessingResult processed)
    {
        return new LibRawResult(
            BayerData: processed.BayerData,
            Width: processed.Width,
            Height: processed.Height,
            ColorFilterPattern: processed.ColorFilterPattern,
            PatternWidth: processed.PatternWidth,
            PatternHeight: processed.PatternHeight,
            BlackLevel: processed.BlackLevel,
            WhiteLevel: processed.WhiteLevel,
            Status: processed.Status,
            RafSidecarPath: processed.RafSidecarPath,
            DebayeredRgb: processed.DebayeredRgb
        );
    }
}

public enum LibRawProcessingStatus
{
    Success = 0,
    InvalidBuffer,
    WrapperUnavailable,
    ProcessingFailed,
    UnhandledException,
    InitializationFailed,
    UnsupportedFormat,
    InsufficientMemory,
    CorruptData,
    IoError,
    LibRawError,
    MetadataExtractionFailed,
    DataExtractionFailed,
    UnknownError
}

public readonly record struct LibRawResult(
    ushort[] BayerData,
    int Width,
    int Height,
    string ColorFilterPattern,
    int PatternWidth,
    int PatternHeight,
    int BlackLevel,
    int WhiteLevel,
    LibRawProcessingStatus Status,
    string? RafSidecarPath,
    ushort[]? DebayeredRgb = null)
{
    public bool Success => Status == LibRawProcessingStatus.Success && BayerData.Length > 0 && Width > 0 && Height > 0;
    
    /// <summary>
    /// Gets debayered RGB data if available from LibRaw (for X-Trans display in NINA).
    /// Returns null if not available or for Bayer sensors.
    /// </summary>
    public ushort[]? GetDebayeredRgb() => DebayeredRgb;

    public static LibRawResult FromFailure(LibRawProcessingStatus status, string? rafPath)
        => new(Array.Empty<ushort>(), 0, 0, string.Empty, 0, 0, 0, 0, status, rafPath, null);
}
