# ASCOM Driver Behavior Inventory for Fuji NINA Plugin

## Source Artifacts Reviewed
- `DriverFolder/Fuji/CameraDriver/CameraHardware..cs`
- `DriverFolder/Fuji/Driver/HardwareFocuser.cs`
- `DriverFolder/Fuji/CameraConfigs/*.json`
- `DriverFolder/Fuji/Native/Libraw.cs`

## Connection Lifecycle (maps to `FujiCamera.ConnectAsync`/`DisconnectAsync`)
- Performs `XSDK_Init` once per process; tracks `sdkInitialized` and exits via `XSDK_Exit` in `Dispose()`.
- Detects cameras with `XSDK_Detect` (USB interface) and opens the first device using `XSDK_OpenEx("ENUM:0")`.
- Immediately sets PC priority (`XSDK_SetPriorityMode`) and retrieves `XSDK_DeviceInformation` plus optional API code list via a two-call pattern with temporary heap allocation.
- Loads camera-specific JSON config based on `deviceInfo.strProduct`; sanitizes model string for filenames.
- Optionally forces Manual exposure mode for PASM bodies (`SdkConstants.ModeManual`) while skipping dial-driven models; logs AE mode via `XSDK_GetAEMode` for diagnostics.
- Attempts to enforce RAW-only capture (`XSDK_SetImageQuality`) and uncompressed RAW (`XSDK_SetRAWCompression`) with verification, swallowing failures as warnings.
- Marks connected state prior to capability caching to satisfy subsequent queries; ensures `Dispose()` and disconnect clear handles, configs, and state.

## Configuration & Capability Caching (maps to `CameraModelCatalog`, `FujiCamera.CacheCapabilitiesAsync`)
- JSON config supplies sensor geometry, ADU limits, default gain/exposure ranges, bulb capability, and SDK constant mappings for each model.
- `CacheCameraCapabilities` populates two dictionaries: SDK shutter code ↔ duration via `PopulateShutterSpeedMaps` using values from Fujifilm SDK reference.
- Queries sensitivity by enforcing DR=100 (`XSDK_SetDRange`) and calling `XSDK_CapSensitivity` through a two-stage helper that allocates unmanaged memory and copies the integer list.
- Queries shutter speeds via `XSDK_CapShutterSpeed`, capturing the SDK bulb-capable flag and reconciling with config defaults.
- Derives min/max exposure and gain from returned lists with fallbacks to config defaults when SDK calls fail; updates `supportedSensitivities`, `supportedShutterSpeeds`, and boolean capabilities (`canAbortExposure`, `canStopExposure`, `bulbCapable`).

## Exposure Orchestration (maps to `FujiCamera.StartExposureAsync`/`StopExposureAsync`)
- Guards with `cameraState` enum (`cameraIdle`, `cameraExposing`, `cameraDownload`, `cameraError`); resets from error state before new exposures.
- Differentiates PASM vs physical-dial bodies via `IsPhysicalDialModel`; timed exposures call `XSDK_SetShutterSpeed` and `XSDK_Release` with `XSDK_RELEASE_SHOOT_S1OFF`.
- Bulb exposures allocate unmanaged `shotOptPtr`, send `XSDK_RELEASE_S1ON`, delay 500 ms, then `XSDK_RELEASE_BULBS2_ON`; physical dial bodies skip `XSDK_SetShutterSpeed` but still run the release sequence.
- Uses `System.Threading.Timer` instances: timed exposures trigger `OnExposureComplete` after duration+buffer; bulb exposures trigger `OnBulbExposureTimerElapsed`, which stops exposure via `XSDK_RELEASE_N_BULBS1OFF` and launches an async polling task.
- Maintains exposure metadata (`exposureStartTime`, `lastExposureDuration`), sets `imageReady=false`, and relies on background polling to transition to `cameraIdle`.
- `StopExposure` throws `MethodNotImplementedException` and simply resets state, indicating no partial stop support.

## Image Acquisition (maps to `FujiCamera.DownloadImageAsync` & FITS builder)
- `OnExposureComplete` / `PollForBulbImage` invoke shared `CheckForImageData` to run `XSDK_ReadImageInfo`; when `lDataSize>0` it flags `imageReady=true` and keeps camera in `cameraIdle`.
- `ImageArray` property lazily downloads data: if `imageReady` false it throws; if `lastImageArray` null it calls `DownloadImageData`.
- `DownloadImageData` transitions `cameraState` to `cameraDownload`, calls `XSDK_ReadImageInfo` and validates format against multiple RAW codes from JSON constants.
- Deletes non-RAW images via `XSDK_DeleteImage` to keep buffer clean, otherwise allocates managed byte buffer, pins it, and calls `XSDK_ReadImage`.
- Processes RAW bytes through `Fujifilm.LibRawWrapper.RawProcessor.ProcessRawBuffer` returning `ushort[,]`, converts to `int[,]`, and stores in `lastImageArray`.
- Cleans up buffers and resets `cameraState` to `cameraIdle`; errors trigger `cameraError` and log stack traces.

## Gain / ISO & Other Camera Properties (maps to camera metadata & control endpoints)
- `Gain` getter/setter call `XSDK_GetSensitivity` / `XSDK_SetSensitivity` with locking, validating requested ISO against discovered list and enforcing state guards during exposures.
- Exposure limits (`ExposureMin`, `ExposureMax`) and `SupportsPulseGuide`, binning, readout options are hard-coded or derived from config/cached values.
- Sets `SensorType` to `RGGB` (NINA may require X-Trans mapping), `BayerOffset` fixed at 0; `ImageReady` bool exposes top-level state.

## Focus / Lens Control (maps to future `FujiFocuser` implementation)
- ASCOM focuser stub (`HardwareFocuser.cs`) is placeholder with absolute positioning but no hardware linkage; all focus behavior must be rebuilt using Fujifilm SDK §4.2.1 commands.
- Camera driver logs removing automatic focus adjustments; current implementation does not call focus-related SDK functions, so new module must translate lens APIs (`SetFocusMode`, `SetFocusPos`, `SetFocusOperation`) into N.I.N.A. focuser semantics.

## Error Handling & Logging (maps to logging/services in plugin)
- Centralized `LogMessage` writes to ASCOM `TraceLogger`; every major operation logs success/failure path.
- `FujifilmSdkWrapper.CheckSdkError` (not shown here) throws detailed exceptions including API/error codes, often augmented with `LogSpecificError` after failed release commands.
- Uses try/finally to release unmanaged resources (`Marshal.FreeHGlobal`) and pinned buffers; ensures SDK handles closed on failure paths.

## Behavior Mapping Summary
- Connection sequence, capability caching, exposure control, and RAW download logic must be ported into N.I.N.A. `FujiCamera` with async equivalents and MEF-managed lifecycle.
- JSON-driven configuration remains authoritative for model-specific constants; loader must sanitize model names identical to ASCOM logic.
- State machine (`cameraState`) and image polling need translation to N.I.N.A.'s task-based model (likely using `TaskCompletionSource` or `BackgroundTask` rather than timers).
- LibRaw ingestion and RAW validation are critical for final FITS output; ensure wrapper DLL is deployed alongside plugin with proper load path.
- Focus subsystem requires new development using SDK focus APIs since the ASCOM implementation is stub-only.
