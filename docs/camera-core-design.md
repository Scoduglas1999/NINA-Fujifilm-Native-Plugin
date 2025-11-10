# FujiCamera Core Implementation Design

This document specifies the architecture and execution flow for the `FujiCamera` class and supporting services implementing the N.I.N.A. camera interfaces.

## 1. Interfaces
- `ICamera` – primary contract (connect/disconnect, capture, properties).
- `ICameraCooling` – exposes cooler status (Fuji bodies have no active cooling; return defaults).
- `ICameraGain` – provide gain enumeration and setters.
- `ICameraStatus` – surface `CameraState`, `ImageReady`, `PercentCompleted` equivalents.
- `ICameraReadout` – asynchronous fetch of image data (maps to `DownloadImageData`).

## 2. Supporting Services
- `FujifilmSession` – wraps SDK handle, manages connect/disconnect sequence, ensures thread-safe access (uses `SemaphoreSlim`).
- `CameraStateMachine` – thread-safe class managing states (`Idle`, `Exposing`, `Downloading`, `Error`).
- `ExposureOrchestrator` – handles timed vs bulb exposures, release command sequencing, timers, and cancellation tokens.
- `ImageAcquisitionService` – polls `XSDK_ReadImageInfo`, downloads raw bytes, triggers LibRaw processing.
- `CapabilityCache` – stores ISO list, shutter map, bulb capability, sensor metadata.

## 3. Lifecycle Flow
1. `ConnectAsync(CancellationToken)`:
   - Acquire session lock.
   - Initialize SDK if not already done (`FujifilmSdkRuntime.EnsureInitialized`).
   - Call `XSDK_Detect` → pick device (initially first) → `XSDK_OpenEx`.
   - Set PC priority, gather device info, load configuration via `CameraModelCatalog`.
   - Optionally set manual mode & image quality/RAW compression.
   - Populate `CapabilityCache` (ISO/shutter). Update `ICamera` property caches.
2. `DisconnectAsync()`:
   - Cancel any in-flight exposures.
   - Close session handle, flush state, mark state machine `Idle`.

## 4. Exposure Workflow
- Public method `Task<ICameraExposureResult> CaptureAsync(ExposureParameters parameters, CancellationToken token)` orchestrates exposures.
- Sequence:
  1. Validate input (ISO, duration) against `CapabilityCache`.
  2. Acquire session lock to serialize SDK calls.
  3. Set gain (if changed) and shutter speed/bulb mode.
  4. Start release sequence through `ExposureOrchestrator`:
     - Timed: send `XSDK_RELEASE_SHOOT_S1OFF`, schedule completion task delay `duration + buffer`.
     - Bulb: start `S1ON` → wait 500 ms → `BULBS2_ON`, schedule stop after duration.
  5. Update `CameraStateMachine` to `Exposing`; record start time.
  6. On timer completion: for timed exposures call `ImageAcquisitionService.ReadOnceAsync`; for bulb exposures, orchestrator stops exposure (`N_BULBS1OFF`) then begins polling loop.
  7. When bytes ready, `ImageAcquisitionService` downloads RAW data and pushes to `LibRawAdapter.ProcessAsync` to get `CameraImage`.
  8. Build `CameraExposureResult` containing metadata, histogram references, file path (if saved) or buffer.

### Async Patterns
- Use `CancellationToken` throughout; canceling should attempt to stop exposure gracefully (if possible). For now, follow ASCOM behavior (no abort) but plan extension.
- Replace `System.Threading.Timer` with `Task.Delay` + `CancellationTokenSource` to avoid timer leaks.
- Use `TaskCompletionSource` to signal state transitions (`ExposureStarted`, `ExposureCompleted`).

## 5. Image Output
- Convert `int[,]`/`ushort[,]` to `CameraImage` (N.I.N.A. type) with metadata: dimensions, pixel size, binning, bit depth.
- Expose FITS header contributions via `ICameraImageMetadataProvider` (if available) – include gain, ISO, shutter speed, sensor temperature (if accessible), lens info from SDK device info.
- Provide `ImageReady` and `ReadoutProgress` updates through events or `INotifyPropertyChanged` implementation.

## 6. Error Handling
- Catch `FujifilmSdkException`; map known error codes to user-friendly messages and update state to `Error`.
- On errors during exposure, mark `CameraStateMachine` as `Error` and ensure `ImageAcquisitionService` stops polling.
- Provide recovery path: `ResetAfterErrorAsync()` to reinitialize session if needed.

## 7. Logging
- Inject `ILogger<FujiCamera>`; log key milestones: connect/disconnect, capability ranges, exposure start/stop, download durations, errors.
- Trace release sequences with hex codes for troubleshooting (matching ASCOM logs).
- Optionally include logging scopes for each exposure ID.

## 8. Performance Considerations
- Ensure all heavy processing (LibRaw) runs on background thread to avoid UI blocking.
- Limit allocations by reusing buffers via `ArrayPool<byte>` for image download; release to pool after LibRaw processing.
- Avoid capturing large buffers in logs.

## 9. Unit/Integration Tests
- **Unit**: Use mock `IFujifilmSdk` interface to simulate SDK results (success/failure). Test state machine transitions, capability validation, error propagation.
- **Integration**: With physical camera, run timed & bulb exposures of varying durations; verify raw download and ensure no resource leaks across repeated cycles.
- **Regression**: Simulate failure cases (e.g., `XSDK_ERRCODE_TIMEOUT`) to confirm state resets and error messaging.

## 10. Deliverables
- Fully implemented `FujiCamera` class.
- Supporting services (`FujifilmSession`, `ExposureOrchestrator`, `ImageAcquisitionService`, `CameraStateMachine`).
- Unit tests under `tests/NINA.Plugins.Fujifilm.Tests/Devices/`.
- Developer documentation snippet for exposures added to `docs/implementation-notes.md` (future combined doc).
