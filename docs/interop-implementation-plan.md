# Interop Layer Implementation Plan

This guide outlines how to port the Fujifilm SDK interop layer and integrate the LibRaw wrapper for the native N.I.N.A. plugin.

## 1. Target Files
- `src/NINA.Plugins.Fujifilm/Interop/FujifilmSdkWrapper.cs`
- `src/NINA.Plugins.Fujifilm/Interop/FujifilmSdkHelpers.cs`
- `src/NINA.Plugins.Fujifilm/Interop/LibRawAdapter.cs`
- `src/NINA.Plugins.Fujifilm/Interop/Native/*` (binary payloads)

## 2. Fujifilm SDK Wrapper Port
1. **Structure Definitions**
   - Port `XSDK_ImageInformation`, `XSDK_DeviceInformation` with correct `StructLayout` attributes (`LayoutKind.Sequential`, `CharSet.Ansi`, `Pack=1`).
   - Validate string buffer sizes against SDK header (`32`, `256` etc.).
2. **Function Imports**
   - Apply `[DllImport("XAPI.dll", EntryPoint="XSDK_*", CallingConvention=CallingConvention.Cdecl)]`.
   - Wrap functions in static class `FujifilmSdkWrapper` with `SuppressUnmanagedCodeSecurity` for performance.
3. **Error Handling**
   - Implement `CheckSdkError(IntPtr hCamera, int result, string operation)` that:
     - Returns early if `result == XSDK_COMPLETE`.
     - Calls `XSDK_GetErrorNumber` for details.
     - Throws `FujifilmSdkException` (custom) containing API & error codes.
4. **Helper Methods**
   - Port two-stage helpers from ASCOM driver: `GetIntArrayFromSdk`, `GetIntArrayFromSdkShutterSpeed`, `GetIntArrayFromSdkSensitivity`.
   - Ensure `Marshal.AllocHGlobal` usage wrapped in try/finally.
   - Add cancellation support by running heavy loops in `Task.Run` if used from async context.
5. **Logging Integration**
   - Expose events or internal logging callbacks (pass `ILogger` into wrapper via static property or injection) to record low-level diagnostics.
6. **Thread Safety**
   - Keep wrapper static but ensure all API calls requiring serialized access (e.g., release sequence) are invoked from higher-level locks.

## 3. LibRaw Adapter
1. Wrap existing `Fujifilm.LibRawWrapper.RawProcessor.ProcessRawBuffer` inside `LibRawAdapter.ProcessAsync(byte[] rawBuffer, CancellationToken token)`.
2. Convert returned `ushort[,]` into `CameraImage` / `ImageData` used by N.I.N.A. with correct orientation and bit depth.
3. Handle LibRaw error codes by mapping to human-readable messages via `RawProcessor.GetLastError()` if available or `libraw_strerror`.
4. Ensure native DLLs (`LibRawWrapper.dll`, `libraw.dll`) are copied to output and loaded from plugin directory using `NativeLibrary.Load` (optional fallback to `SetDllDirectory`).

## 4. Exception Types
- `FujifilmSdkException` – includes `Result`, `ApiCode`, `ErrorCode`, `Operation`, friendly message.
- `FujifilmSdkTimeoutException` – derived class for `XSDK_ERRCODE_TIMEOUT` (enables retries).
- `LibRawProcessingException` – includes LibRaw error code and message.

## 5. Testing Strategy
1. **Unit Tests (without hardware)**
   - Mock wrapper functions using `DllImportResolver` or interface abstraction to simulate success/failure.
   - Verify helper methods correctly marshal arrays and free allocated memory (use `SafeHandle` wrappers).
2. **Integration Tests (with hardware)**
   - Provide test harness to run `XSDK_Init` → `XSDK_Detect` → `XSDK_OpenEx` → `XSDK_Close` ensuring no leaks.
   - Validate release sequence timers by mocking `XSDK_Release` (man-in-the-middle wrapper).
3. **Stress Tests**
   - Repeated exposures in rapid succession to confirm no memory leaks or handle leaks.

## 6. Implementation Checklist
- [ ] Create `FujifilmSdkException` class with serialization support.
- [ ] Implement `FujifilmSdkWrapper` with all required P/Invoke signatures.
- [ ] Port helper methods and ensure they throw `FujifilmSdkException` on failure.
- [ ] Add `FujifilmSdkLogger` static property for optional tracing.
- [ ] Implement `LibRawAdapter` with async processing and error mapping.
- [ ] Write unit tests covering conversion helpers and exception paths.
- [ ] Document required DLL versions in `docs/THIRD_PARTY.md`.
- [ ] Update project file to include native DLLs and set `SetDllDirectory` fallback in manifest startup.

## 7. References
- `docs/sdk-constant-table.md` – authoritative constant values and call sequences.
- `DriverFolder/Fuji/CameraDriver/CameraHardware..cs` – original helper implementations.
- Fujifilm SDK Programming Reference §§4.1 – 4.2 – official function definitions.
