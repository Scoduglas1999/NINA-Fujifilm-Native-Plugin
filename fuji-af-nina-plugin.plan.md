<!-- a606f942-a791-497b-b451-cc5650af9a1c e436e911-8185-4d9f-8a7d-00eb22e6d07e -->
# Fuji NINA Camera Plugin Build Plan

This plan captures how to build a native N.I.N.A. camera plugin that wraps the Fujifilm SDK and mirrors the proven behavior in the existing ASCOM driver. Use it as the implementation roadmap.

## 1. Key Resources and References
- `DriverFolder/Fuji/CameraDriver/CameraHardware..cs` – definitive reference for connection, exposure sequencing, capability caching, and image download logic you must port. Pay special attention to `Connected`, `CacheCameraCapabilities`, `StartExposure`, `OnBulbExposureTimerElapsed`, `PollForBulbImage`, and `DownloadImageData`.
- `DriverFolder/Fuji/CameraConfigs/*.json` – model metadata and SDK constant mappings; adapt these for the plugin’s configuration assets.
- `SDK_Programming_Reference.md` – authoritative source for every SDK constant, struct, and call signature. Consult by section:
  - §4.1.3 Session Management for `XSDK_OpenEx` / `XSDK_Close`
  - §4.1.6 Camera Operation Mode for priority / AE mode handling
  - §4.1.7 Release Control for `XSDK_Release` command values and sequencing
  - §4.1.8 Image Acquisition for `XSDK_ReadImageInfo` / `XSDK_ReadImage`
  - §4.1.9 Exposure Control for shutter speed and sensitivity capabilities
  - §4.2 model-specific properties when you must drive focus or other optional controls
- Public N.I.N.A. plugin docs and templates: `https://nighttime-imaging.eu/docs/master/plugins` and the `NINA.PluginTemplate` repository (ensure you clone the branch matching the target N.I.N.A. release).

## 2. Environment and Project Setup
- Install Visual Studio 2022 (or newer) with `.NET 7` workloads; confirm your N.I.N.A. target version (2.1 uses .NET 7) and align the plugin target framework accordingly.
- Clone `NINA.PluginTemplate` and rename the solution (e.g., `NINA.FujiCamera`). Update `plugin.json` identifiers (`Guid`, `Name`, `Version`), and adjust namespaces to `NINA.Plugins.Fujifilm`.
- Configure solution platforms to `x64`; the Fujifilm SDK DLLs (`XAPI.dll`, `FF00XXAPI.dll`, `LibRawWrapper.dll`) are 64-bit.
- Add a post-build step (or MSBuild `<ItemGroup CopyToOutputDirectory>`) that copies required Fujifilm SDK redistributables and JSON configs into `$(OutDir)`.

## 3. Solution Structure
Organize the project to keep interop, camera logic, and configuration clean.
- `Interop/FujifilmSdkWrapper.cs`: P/Invoke surface plus helpers, ported from the ASCOM driver but refactored for N.I.N.A. async patterns. Every constant must be cross-checked against `SDK_Programming_Reference.md`.
- `Interop/LibRawProcessor.cs`: either wrap the existing C++/CLI `LibRawWrapper.dll` (from `DriverFolder/Fuji/Native`) or replace with a managed LibRaw binding; ensure licensing and redistribution requirements are respected.
- `Configuration/CameraModelCatalog.cs`: load JSON camera maps into strongly typed objects (reuse the `CameraConfig` classes from `CameraHardware..cs`).
- `Plugin/FujiManifest.cs`: implements `IPluginManifest`, registers factories with N.I.N.A.’s DI, injects logging and settings.
- `Devices/FujiCameraFactory.cs`: implements `ICameraFactory` (or the version-specific provider interface) and exposes discovered devices.
- `Devices/FujiCamera.cs`: implements `ICamera` and contains operational logic (connection, exposure, download).
- Optional `Devices/FujiFocuser.cs`: only if motorized focus is required; otherwise return no focuser device.

## 4. SDK Interop Layer
- Port the struct definitions (`XSDK_DeviceInformation`, `XSDK_ImageInformation`) and function signatures exactly as in `CameraHardware..cs`; mismatched packing or calling conventions will cause silent failures.
- Embed safety helpers like `CheckSdkError`, `GetIntArrayFromSdk` variants, and error logging (`XSDK_GetErrorNumber`), mirroring the existing driver. Wrap them in exceptions that N.I.N.A. can surface in the UI.
- Maintain the release constants (`XSDK_RELEASE_S1ON`, `XSDK_RELEASE_BULBS2_ON`, `XSDK_RELEASE_N_BULBS1OFF`, etc.) exactly as documented; confirm hex values in §4.1.7 of the SDK reference before shipping.
- Expose async-friendly wrappers where appropriate (e.g., `Task<int[]> CapSensitivityAsync`) to keep the camera class responsive.

## 5. Camera Lifecycle Implementation (`FujiCamera`)
Mirror the ASCOM driver’s state machine, translating to N.I.N.A.’s abstractions.
- **Connect / Disconnect**
  - Initialize the SDK with `XSDK_Init`, detect devices (`XSDK_Detect`), and open the first enumerated handle via `XSDK_OpenEx` just as the ASCOM driver does.
  - Immediate steps after connect: call `XSDK_SetPriorityMode` (PC priority), fetch `XSDK_GetDeviceInfoEx`, and load the matching JSON configuration (`LoadConfiguration`). Reuse the sanitization logic for file names.
  - Conditionally force Manual mode for PASM bodies (`currentConfig.SdkConstants.ModeManual`) – adopt the model check list from `Connected` in `CameraHardware..cs`.
  - Enforce RAW + uncompressed using `XSDK_SetImageQuality` and `XSDK_SetRAWCompression`, with JSON-provided constants.
- **Capability Caching**
  - Recreate `CacheCameraCapabilities` to populate ISO and shutter tables. Follow the ASCOM order: call `PopulateShutterSpeedMaps`, set DR to 100 (see §4.1.9.10), query sensitivities via `XSDK_CapSensitivity`, then shutter speeds with `XSDK_CapShutterSpeed`. Respect fallbacks when the SDK returns nothing.
  - Surface capabilities through N.I.N.A.’s camera metadata (`MaxExposure`, `MinExposure`, `GainSteps`, `SupportsBulb`, etc.).
- **Exposure Workflow**
  - Port the branching logic from `StartExposure`: differentiate between physical-dial bodies and PASM bodies (reuse `IsPhysicalDialModel`). For timed exposures send `XSDK_RELEASE_SHOOT_S1OFF`; for bulb sequences follow the S1/BULBS2 start sequence and stop with `XSDK_RELEASE_N_BULBS1OFF`.
  - Keep the guard rails: validate duration against cached min/max, manage `cameraState`, and stage pointers (`Marshal.AllocHGlobal`) safely.
  - Replace the ASCOM timer callbacks with `Task`-based delays compatible with N.I.N.A.’s async pattern. `PollForBulbImage` should run on a background task but marshal progress back to the UI thread when signaling completion.
- **Image Retrieval**
  - Implement `DownloadImageAsync` based on `DownloadImageData`: call `XSDK_ReadImageInfo`, validate format codes against config, fetch the buffer with `XSDK_ReadImage`, and hand off to the LibRaw wrapper.
  - Convert the resulting Bayer array into the format expected by N.I.N.A. (`ICameraImage` / FITS builder). Preserve logging for format mismatches and ensure images are deleted (`XSDK_DeleteImage`) if the format is unsupported.
- **Status & Properties**
  - Map ASCOM properties (`Gain`, `MaxADU`, `SensorName`) to the corresponding N.I.N.A. camera metadata.
  - Forward progress events (percentage, state transitions) to N.I.N.A.’s `IProgress` / `CameraExposureMonitor`.
  - Surface config-driven data such as pixel size and sensor dimensions.

## 6. Optional Focus Support
- If motorized focus is required, replicate the ASCOM hardware logic from `Driver/HardwareFocuser.cs`. Use §4.2.1 (`CapFocusMode`, `SetFocusPos`) of the SDK reference to drive focus operations.
- Expose focus availability based on JSON configuration flags; fall back to “not supported” when a lens is non-motorized.
- Respect N.I.N.A.’s focuser contract (`IFocuser` / `IFocuserDriver`), propagate backlash, and honor sync limits.

## 7. Configuration and Data Files
- Migrate the JSON model files into the plugin’s `Assets/CameraConfigs`. Include both the static sensor metadata and the `SdkConstants` block (mode codes, image quality codes, shutter maps if they ever vary).
- Create an index file (e.g., `camera-models.json`) listing supported models so the plugin can validate devices returned by `XSDK_Detect`.
- During the build, copy all JSON files and native DLLs into the plugin output directory. Ensure the installer or deployment instructions mention placing them alongside the plugin DLL.

## 8. Logging, Settings, and Diagnostics
- Inject N.I.N.A.’s logging (`ILogger`, `LogManager`). Mirror the verbose logging strategy from the ASCOM driver so users can capture SDK error codes.
- Provide a plugin settings page (WPF) if you need to expose toggles such as “Force manual mode” or “Log SDK trace”. Use dependency injection to register the view.
- Implement structured error surfaces: wrap SDK failures in exceptions that include both `APICode` and `ErrorCode` retrieved via `XSDK_GetErrorNumber`, similar to `LogSpecificError` in the ASCOM driver.

## 9. Build, Packaging, and Deployment
- Configure the project to output to `NINA\Plugins\Fujifilm\` during debug for rapid testing (update the post-build event to copy to `%LOCALAPPDATA%\NINA\Plugins\Fujifilm`).
- Produce a release ZIP containing:
  - Plugin DLL(s)
  - Fujifilm SDK redistributables (`XAPI.dll`, `FF00XXAPI.dll`, support DLLs)
  - `LibRawWrapper.dll` (or alternative) plus its dependencies
  - JSON configuration files and any `XSDK.DAT` resources required by Fujifilm
  - A README describing install steps and required camera USB settings
- Document signing instructions if you intend to distribute via the N.I.N.A. plugin repository.

## 10. Validation and Test Plan
- Bench test with a supported Fujifilm body:
  - Verify connection/disconnection cycles (USB priority toggles, AE mode state).
  - Run timed exposures (≤30s) and ensure downloads complete without the bulb sequence.
  - Run bulb exposures (>30s) and confirm the S1/BULBS2 start/stop sequence matches `StartExposure` + `OnBulbExposureTimerElapsed`.
  - Confirm ISO lists and shutter speeds match what `CacheCameraCapabilities` discovers.
  - Validate raw downloads by opening the FITS file in N.I.N.A.’s image viewer and third-party tools.
- Use N.I.N.A.’s built-in plugin diagnostics to watch for unhandled exceptions or UI-thread deadlocks.
- Capture logs for both success and failure paths to fine-tune retries (e.g., when `XSDK_ReadImageInfo` initially reports no data).

## 11. Follow-up Work Items
- Add Wi-Fi transport support (requires adapting detection/open calls when `XSDK_DSC_IF_WIFI` is available).
- Evaluate porting focus and other device classes (`HardwareFilterWheel`, `HardwareSwitch`) if the Fujifilm ecosystem ever exposes them through the SDK.
- Automate regression tests using simulated SDK responses or a hardware-in-the-loop test harness.