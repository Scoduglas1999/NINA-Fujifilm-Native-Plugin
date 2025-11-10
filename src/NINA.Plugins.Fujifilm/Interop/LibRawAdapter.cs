using System;
using System.ComponentModel.Composition;
using System.Threading;
using System.Threading.Tasks;
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
        _diagnostics = diagnostics;
    }

    public Task<LibRawResult> ProcessRawAsync(byte[] buffer, CancellationToken cancellationToken)
    {
        // TODO: call into Fujifilm.LibRawWrapper when available.
        _diagnostics.RecordEvent("LibRaw", "Processing is not yet implemented.");
        return Task.FromResult(new LibRawResult(Array.Empty<ushort>(), 0, 0));
    }
}

public readonly record struct LibRawResult(ushort[] BayerData, int Width, int Height);
