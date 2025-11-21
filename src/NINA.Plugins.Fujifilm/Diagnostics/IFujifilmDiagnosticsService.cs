using System.Threading;
using System.Threading.Tasks;

namespace NINA.Plugins.Fujifilm.Diagnostics;

public interface IFujifilmDiagnosticsService
{
    void RecordEvent(string category, string message);
    void RecordSdkCall(string apiName, int result, int apiCode, int errorCode);
    void RecordBayerPatternDetection(string pattern, int width, int height, bool isXTrans, int? isBayerFlag = null);
    void RecordFitsKeywordGeneration(int keywordCount, string? bayerPattern = null);
    void RecordSdkConstantValidation(string constantName, int expectedValue, int actualValue, bool isValid);
    Task<string> ExportDiagnosticsAsync(CancellationToken cancellationToken);
}
