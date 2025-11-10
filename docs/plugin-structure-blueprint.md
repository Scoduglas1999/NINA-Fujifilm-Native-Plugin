# Fujifilm N.I.N.A. Plugin Structure Blueprint

This blueprint converts the research notes into concrete folders, files, and responsibilities for the upcoming Fuji native camera plugin. Each entry lists the purpose, primary interfaces, and key dependencies. Paths are relative to the future solution root `NINA.Plugins.Fujifilm/`.

## Top-Level Layout
- `NINA.Plugins.Fujifilm.sln` – Visual Studio solution containing the plugin project and optional test harness.
- `README.md` – Developer-facing overview, build prerequisites, and quick-start.
- `LICENSE.txt` – Licensing terms (reuse ASCOM/Fuji SDK notices as required).
- `Directory.Build.props` – Centralizes .NET version (`net7.0-windows`), nullable context, code analysis rules.
- `build/` – MSBuild utilities and packaging scripts.
  - `Bundle.targets` – Collects binaries, native DLLs, JSON assets into `dist/`.
  - `PostBuild.ps1` – Copies outputs into `%LOCALAPPDATA%\NINA\Plugins\Fujifilm` during debug.
- `dist/` – Generated release artifacts (ignored in source control).
- `docs/` – Living documentation (plan excerpts, SDK references, test matrix).
- `tools/` – Optional helper scripts (e.g., JSON validator, SDK constant extractor).

## Project Directory `src/`
- `NINA.Plugins.Fujifilm/`
  - `NINA.Plugins.Fujifilm.csproj`
    - Targets `net7.0-windows`, `PlatformTarget=x64`.
    - Includes `<ItemGroup>` entries for Fujifilm SDK DLLs and JSON configs (`CopyToOutputDirectory=PreserveNewest`).
    - Imports `../build/Bundle.targets` for packaging.
  - `plugin.json`
    - Manifest consumed by N.I.N.A.; populate `Name`, `Guid`, `Entrypoint`, `Version`, `MinNinaVersion`, `Author`, `Description`.
  - `Properties/`
    - `AssemblyInfo.cs` – Strong name, `InternalsVisibleTo` for tests.
    - `Resources.resx` – Strings for UI.
  - `Plugin/`
    - `FujiManifest.cs`
      - Implements `IPluginManifest`, registers services in `RegisterServices(IServiceCollection services)`.
      - Creates scoped logger categories, loads settings definitions, triggers asset copy validation on startup.
    - `FujiPluginStartup.cs`
      - Optional `IPluginBootstrapper` to run async initialization (e.g., ensure native DLL presence).
    - `ServiceCollectionExtensions.cs`
      - Helper extension to chain all DI registrations (camera/focuser providers, configuration services).
    - `PluginMetadata.cs`
      - Static class exposing plugin `Guid`, `Version`, and human-readable metadata reused across manifest/UI/tests.
  - `Configuration/`
    - `CameraModelCatalog.cs`
      - Loads `CameraConfig` objects from JSON (reuse ASCOM schema), exposes lookup by product name or USB identifier.
      - Provides validation errors with references to JSON path.
    - `CameraConfig.cs`
      - POCO types mirroring JSON structure (`SdkConstants`, shutter maps, default ranges).
    - `ConfigurationService.cs`
      - Implements `ICameraConfigurationService` for DI; caches catalog, exposes refresh hooks.
    - `Assets/CameraConfigs/*.json`
      - Ported model configs (one per Fuji body); may add `index.json` for alias mapping.
    - `Schemas/camera-config.schema.json`
      - JSON schema ensuring configs remain consistent.
  - `Interop/`
    - `FujifilmSdkWrapper.cs`
      - P/Invoke definitions for Fujifilm SDK functions/structs/constants; replicates ASCOM wrapper with async-safe wrappers.
      - Contains `CheckSdkError`, `GetIntArrayFromSdk*` helpers.
    - `FujifilmSdkResultExtensions.cs`
      - Translates SDK error codes into descriptive messages.
    - `LibRawAdapter.cs`
      - Thin wrapper around `LibRawWrapper.dll`, exposes async processing pipeline returning `CameraImage` data.
    - `Native/`
      - Placeholder for dropped native libraries (`XAPI.dll`, `FF00XXAPI.dll`, `LibRawWrapper.dll`, etc.) tracked via `<None Include=... CopyToOutputDirectory>`.
  - `Devices/`
    - `FujiCameraFactory.cs`
      - Implements `ICameraFactory`/`ICameraDiscovery`; enumerates devices via SDK detect, maps to `CameraDescriptor`.
    - `FujiCamera.cs`
      - Implements `ICamera`, `ICameraCooling`, `ICameraGain`, `ICameraStatus`, etc.
      - Houses connect/disconnect, capability cache, exposure execution (`StartExposureAsync`, `ReadoutAsync`).
      - Uses `CameraStateMachine` helper (below).
    - `CameraStateMachine.cs`
      - Encapsulates state transitions (`Idle`, `Exposing`, `Downloading`, `Error`); ensures thread-safe transitions.
    - `ExposureOrchestrator.cs`
      - async coordination for timed/bulb exposures, release command sequences, pointer management, polling loops.
    - `ImageDownloadService.cs`
      - Coordinates `XSDK_ReadImageInfo`, `XSDK_ReadImage`, passes result to `LibRawAdapter`, exposes `Task<CameraImage>`.
    - `FujiFocuserFactory.cs`
      - Registers focuser device when lens supports AF; implements `IFocuserFactory` if required by N.I.N.A. version.
    - `FujiFocuser.cs`
      - Implements `IFocuser`, `IFocuserLimits`. Issues SDK focus commands (§4.2.1 functions) and handles backlash conversions.
    - `LensCapabilityDetector.cs`
      - Queries SDK focus capabilities, caches focus range/step size per body+lens.
  - `Diagnostics/`
    - `LoggerExtensions.cs`
      - Adds structured logging helpers (`WithSdkError`, `LogReleaseSequence`).
    - `SdkTraceRecorder.cs`
      - Optional: captures SDK debug callbacks when enabled via settings.
    - `TelemetryEvents.cs`
      - Defines event payloads for future analytics/log uploads.
  - `Settings/`
    - `FujiSettings.cs`
      - Implements `IPluginSettings`; persists defaults (preferred camera, trace verbosity, AF options).
    - `FujiSettingsProvider.cs`
      - Bridges `ISettingsManager` with strongly typed settings.
  - `UI/`
    - `SettingsView.xaml`
      - WPF UI exposing settings; includes sections for SDK DLL path, logging toggles, AF tuning.
    - `SettingsView.xaml.cs`
      - Code-behind hooking up view model.
    - `SettingsViewModel.cs`
      - Uses `ObservableObject` to expose settings bindings; orchestrates validation.
  - `Tasks/`
    - `FujiPluginTaskDefinitions.cs`
      - Optional sequencer instruction exports (if Fuji-specific steps needed, e.g., “Apply Lens AF Offset”).
  - `Extensions/`
    - Utility extensions specific to plugin (e.g., `CameraDescriptorExtensions`, `SdkStructConverters`).

## Tests Directory
- `tests/NINA.Plugins.Fujifilm.Tests/`
  - `NINA.Plugins.Fujifilm.Tests.csproj`
    - Targets `net7.0`, references main project.
    - Includes fixture for loading JSON configs, verifying DI registration, simulating SDK wrappers via mocks.
  - `Configuration/CameraConfigTests.cs`
  - `Interop/FujifilmSdkWrapperTests.cs`
  - `Devices/FujiCameraTests.cs`
  - `Devices/FujiFocuserTests.cs`
  - `Diagnostics/LoggingTests.cs`

## Build & Packaging Artifacts
- `build/Bundle.targets`
  - Defines `AfterBuild` target to copy `plugin.json`, managed DLLs, native DLLs, JSON configs into `$(OutputPath)\publish`.
  - Zips publish folder into `dist/NINA.Plugins.Fujifilm-v$(Version).zip` with SHA256 generation.
- `build/Version.props`
  - Central place to bump plugin version, referenced by both manifest and assembly.

## External Dependencies
- Fujifilm SDK redistributables (32-bit not needed; ensure x64 copies placed in `src/NINA.Plugins.Fujifilm/Interop/Native/`).
- `LibRawWrapper.dll` plus `libraw.dll` (64-bit) from existing ASCOM driver; license text appended to `docs/THIRD_PARTY.md`.
- N.I.N.A. `PluginContracts` NuGet package (or direct project references when building inside N.I.N.A. workspace).

## Implementation Checklist Tie-In
- **Configuration system** maps to `Configuration/*` entries.
- **Interop layer** built under `Interop/` and leveraged by `Devices/` services.
- **Camera & focus modules** correspond to `FujiCamera`, `FujiFocuser`, state helpers, and orchestrators.
- **Diagnostics/UI** realized via `Diagnostics/` and `UI/` folders.
- **Packaging** orchestrated through `build/` scripts and manifest.
- Ensure `README.md` lists installation steps and enumerates required files to drop into `NINA\Plugins`.
