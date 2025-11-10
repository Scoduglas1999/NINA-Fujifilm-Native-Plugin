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

    public void RecordEvent(string category, string message)
    {
        var evt = new FujifilmDiagnosticEvent(DateTimeOffset.UtcNow, category, message);
        _events.Enqueue(evt);
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
