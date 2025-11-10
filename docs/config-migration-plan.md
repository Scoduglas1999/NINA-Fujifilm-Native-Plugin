# Configuration Migration Plan

This plan describes how to port the existing ASCOM configuration data into the N.I.N.A. plugin and provide runtime validation.

## 1. Source Data
- `DriverFolder/Fuji/CameraConfigs/*.json` – current per-model configuration files.
- `DriverFolder/Fuji/CameraDriver/CameraHardware..cs` – JSON deserialization classes (`CameraConfig`, `SdkConstantConfig`, `ShutterSpeedMapping`).

## 2. Target Location
- `src/NINA.Plugins.Fujifilm/Configuration/Assets/CameraConfigs/*.json`
- `src/NINA.Plugins.Fujifilm/Configuration/CameraConfig.cs` (POCO definitions)
- `src/NINA.Plugins.Fujifilm/Configuration/CameraModelCatalog.cs` (loader)

## 3. Migration Steps
1. **Copy JSON Files**
   - Preserve filenames (e.g., `GFX100S.json`, `X-T5.json`).
   - Ensure ASCII encoding and LF line endings.
   - Add new models if missing once SDK constants verified.
2. **Normalize Schema**
   - Confirm each JSON has required properties: `ModelName`, `CameraXSize`, `CameraYSize`, `PixelSizeX`, `PixelSizeY`, `MaxAdu`, `DefaultMinSensitivity`, `DefaultMaxSensitivity`, `DefaultMinExposure`, `DefaultMaxExposure`, `DefaultBulbCapable`, `SdkConstants` object, optional `ShutterSpeedMap` array.
   - Add `Focus` sub-object if autofocus constants differ per model (e.g., `_SetFocusPos_` codes) once identified.
3. **JSON Schema Validation**
   - Create `Configuration/Schemas/camera-config.schema.json` capturing property types, required fields, and value constraints (e.g., exposures > 0, pixel sizes > 0).
   - Use `System.Text.Json.Schema` or `NJsonSchema` in unit tests to validate files.
4. **Loader Implementation**
   - `CameraModelCatalog` should:
     - Load JSON files on startup (defer to `IFileProvider` for testability).
     - Sanitize device names (strip whitespace, unsupported characters) to derive filename (matching ASCOM logic).
     - Provide dictionary keyed by product string and fallback alias list (e.g., `"GFX 100S"` → `GFX100S`).
     - Expose method `GetConfigByDeviceInfo(XSDK_DeviceInformation deviceInfo)` returning config or throwing descriptive exception.
     - Support manual refresh (for plugin settings UI “Reload configs”).
5. **Runtime Overrides**
   - Implement merging strategy for user overrides stored in N.I.N.A. settings (if necessary): e.g., allow custom exposures or image quality codes.
6. **Unit Tests**
   - Validate loading all JSON files without exception.
   - Assert sanitized names map to existing files (e.g., `"X-T5"` sanitized to `XT5` or `X-T5` per logic).
   - Confirm `SdkConstants` values load correctly and match expected ints from SDK PDF.
   - Write regression test ensuring `ShutterSpeedMap` entries produce monotonic durations and unique codes.

## 4. Selection Logic
- On connect, after retrieving `deviceInfo.strProduct`, call `CameraModelCatalog.Resolve(modelName)`.
- If unknown, log warning and fallback to default config with conservative values (maybe `GenericFuji.json`).
- Optionally allow user to select config manually via settings if detection fails.

## 5. Future Enhancements
- Generate JSON automatically from API code list returned by `XSDK_GetDeviceInfoEx` to reduce manual maintenance.
- Add `capabilities.json` summary linking each model to lens AF support, supported release commands, etc.
- Provide command-line tool under `tools/` to validate new config contributions before commit.
