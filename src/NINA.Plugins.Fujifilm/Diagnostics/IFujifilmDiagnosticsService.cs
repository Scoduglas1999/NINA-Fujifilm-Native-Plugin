using System.Threading;
using System.Threading.Tasks;

namespace NINA.Plugins.Fujifilm.Diagnostics;

public interface IFujifilmDiagnosticsService
{
    void RecordEvent(string category, string message);
    Task<string> ExportDiagnosticsAsync(CancellationToken cancellationToken);
}
