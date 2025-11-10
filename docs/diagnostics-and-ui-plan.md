# Diagnostics & Settings UI Plan

## 1. Logging Strategy
- Use `ILoggerFactory` injected via DI to create typed loggers (`ILogger<FujiCamera>`, `ILogger<FujiFocuser>`, etc.).
- Introduce `FujifilmLogCategories` static class for consistent category names (`"FujiCamera"`, `"FujiInterop"`, `"FujiFocus"`).
- Wrap all SDK calls inside logging scopes providing `operation`, `result`, and optional API/error codes.
- Allow optional verbose tracing with plugin setting `EnableSdkTrace`; when enabled, log every SDK call and release sequence step.
- Provide method `LogSdkError(apiCode, errCode)` mapping to human-readable descriptions from `sdk-constant-table.md`.

## 2. Telemetry & Diagnostics Files
- Add `Diagnostics/SdkTraceRecorder.cs` to capture optionally the raw SDK trace (if Fujifilm SDK exposes callbacks).
- Implement rotating log file stored under `%LOCALAPPDATA%\NINA\Logs\Fuji` when verbose tracing enabled.
- Provide command in settings UI to export diagnostic bundle (zips logs + config + plugin version info).

## 3. Plugin Settings Model
- `FujiSettings` (persistent via `ISettingsManager`):
  - `PreferredCameraId`
  - `EnableSdkTrace`
  - `ForceManualExposureMode`
  - `ForceManualFocusMode`
  - `BulbReleaseDelayMs` (override default 500 ms)
  - `AutoDeleteNonRaw` toggle (default true)
  - `FocusBacklashSteps`
- `FujiSettingsProvider` supplies `IPluginSettingsAccessor<FujiSettings>` to DI.

## 4. Settings UI (WPF)
- `UI/SettingsView.xaml` layout:
  - **Connection** section: dropdown for preferred camera, button to refresh devices.
  - **Exposure** section: toggles for manual mode enforcement, bulb delay input.
  - **Focus** section: enabling focuser, backlash value, manual focus hints.
  - **Diagnostics** section: enable SDK trace, button to open logs folder, button to export diagnostics zip.
- Use `Grid` layout with `GroupBox` per section; ensure UI scales with theme.

### ViewModel (`SettingsViewModel`)
- Inject `FujiSettingsProvider`, `ILogger<SettingsViewModel>`, `IFujifilmRuntimeDiagnostics`.
- Expose `ObservableProperty` entries; ensure validation (e.g., bulb delay >= 0, backlash >= 0).
- Commands:
  - `RefreshCamerasCommand` – queries `FujiCameraFactory` for currently detected devices.
  - `OpenLogFolderCommand` – opens log directory via `Process.Start("explorer", path)`.
  - `ExportDiagnosticsCommand` – triggers diagnostic bundle creation.
- Provide `IsBusy` indicator for long-running operations (use `AsyncRelayCommand`).

## 5. Diagnostics API Surface
- Create service `IFujifilmDiagnosticsService` with methods:
  - `Task<string> ExportDiagnosticsAsync(CancellationToken)` – returns path to zip file.
  - `void RegisterExposure(Guid exposureId, ExposureContext context)` – collects metrics for later export.
  - `IEnumerable<ExposureLogEntry>` – enumerates recorded exposures for debugging.
- Implementation stores data under `%LOCALAPPDATA%\NINA\Plugins\Fujifilm\Diagnostics`.

## 6. User Feedback
- Display toast notifications (via N.I.N.A. `INotificationService`) for major events: SDK initialization failure, focus not supported, diagnostics export completed.
- Provide error dialogs with actionable guidance (e.g., “Set camera to Manual mode and re-try.”).

## 7. Testing
- UI automation tests verifying view model validation logic (using `CommunityToolkit.Mvvm` testing helpers).
- Integration test to ensure enabling SDK trace actually increases logging output.
- Manual test plan to confirm diagnostics export zips expected files.

## 8. Documentation
- Update `README.md` with instructions on enabling SDK trace and exporting logs for bug reports.
- Add `docs/troubleshooting.md` capturing common error codes and recommended fixes.
