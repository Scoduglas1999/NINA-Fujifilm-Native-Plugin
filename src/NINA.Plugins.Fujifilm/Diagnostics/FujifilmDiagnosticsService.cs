using System;
using System.Collections.Concurrent;
using System.ComponentModel.Composition;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace NINA.Plugins.Fujifilm.Diagnostics;

[Export(typeof(IFujifilmDiagnosticsService))]
[PartCreationPolicy(CreationPolicy.Shared)]
public sealed class FujifilmDiagnosticsService : IFujifilmDiagnosticsService
{
    private readonly ConcurrentQueue<FujifilmDiagnosticEvent> _events = new();

    public FujifilmDiagnosticsService()
    {
        try { System.IO.File.AppendAllText(@"c:\Users\scdou\Documents\NINA.Fujifilm.Plugin\debug_log.txt", $"[{DateTime.Now}] FujifilmDiagnosticsService Constructor called\n"); } catch {}
    }

    public void RecordEvent(string category, string message)
    {
        var evt = new FujifilmDiagnosticEvent(DateTimeOffset.UtcNow, category, message);
        _events.Enqueue(evt);
        try 
        { 
            System.IO.File.AppendAllText(@"c:\Users\scdou\Documents\NINA.Fujifilm.Plugin\debug_log.txt", $"[{evt.Timestamp.ToLocalTime()}] [{category}] {message}\n"); 
        } 
        catch {}
    }

    public void RecordSdkCall(string apiName, int result, int apiCode, int errorCode)
    {
        var message = $"API={apiName} Result={result} ApiCode=0x{apiCode:X} ErrCode=0x{errorCode:X}";
        RecordEvent("SDK", message);
    }

    public void RecordBayerPatternDetection(string pattern, int width, int height, bool isXTrans, int? isBayerFlag = null)
    {
        var message = $"Pattern={pattern} Dimensions={width}x{height} IsXTrans={isXTrans}";
        if (isBayerFlag.HasValue)
        {
            message += $" IsBayer={isBayerFlag.Value}";
        }
        RecordEvent("BayerPattern", message);
    }

    public void RecordFitsKeywordGeneration(int keywordCount, string? bayerPattern = null)
    {
        var message = $"Generated {keywordCount} FITS keywords";
        if (!string.IsNullOrEmpty(bayerPattern))
        {
            message += $" BAYERPAT={bayerPattern}";
        }
        RecordEvent("FITS", message);
    }

    public void RecordSdkConstantValidation(string constantName, int expectedValue, int actualValue, bool isValid)
    {
        if (!isValid)
        {
            RecordEvent("SDKValidation", $"WARNING: {constantName} expected=0x{expectedValue:X} actual=0x{actualValue:X}");
        }
    }

    public async Task<string> ExportDiagnosticsAsync(CancellationToken cancellationToken)
    {
        var targetDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NINA", "Plugins", "Fujifilm", "Diagnostics");
        Directory.CreateDirectory(targetDirectory);
        var fileName = $"diagnostics-{DateTime.UtcNow:yyyyMMdd-HHmmss}.json";
        var filePath = Path.Combine(targetDirectory, fileName);

        var snapshot = _events.ToArray();
        using (var stream = File.Create(filePath))
        {
            await JsonSerializer.SerializeAsync(stream, snapshot, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        return filePath;
    }
}

public readonly record struct FujifilmDiagnosticEvent(DateTimeOffset Timestamp, string Category, string Message);
