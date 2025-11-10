# Fujifilm SDK Function & Constant Matrix

This matrix captures the core Fujifilm X/GFX SDK APIs, constants, and data structures the native N.I.N.A. plugin must use. Section numbers reference `SDK_Programming_Reference.md` provided by Fujifilm.

## 1. Session Management (SDK §4.1.3)
| API | Purpose | Notes | Call Order | Failure Handling |
| --- | --- | --- | --- | --- |
| `XSDK_Init(IntPtr hLib)` | Initialize SDK runtime | Pass `IntPtr.Zero`. Must be paired with `XSDK_Exit`. | Called once per process prior to any other API. | Throw on non-zero return; plugin should surface fatal error. |
| `XSDK_Exit()` | Tear down SDK | Only call if SDK initialized. | App shutdown or plugin unload. | Log warnings if result != `XSDK_COMPLETE`. |
| `XSDK_Detect(int lInterface, IntPtr pInterface, IntPtr pDeviceName, out int plCount)` | Enumerate connected cameras | Use `XSDK_DSC_IF_USB` (`1`). | Before opening cameras; optionally on refresh. | Non-zero results -> show user error dialog/log. |
| `XSDK_OpenEx(string deviceId, out IntPtr hCamera, out int plCameraMode, IntPtr pOption)` | Open camera session | Device ID format `"ENUM:<index>"`. | After successful detect; before capability queries. | On failure, call `XSDK_Close` if handle allocated; propagate error. |
| `XSDK_Close(IntPtr hCamera)` | Close camera session | Safe to call on partially opened handles. | During disconnect. | Log errors; ensure handle nulled regardless. |
| `XSDK_GetDeviceInfoEx(IntPtr hCamera, out XSDK_DeviceInformation info, out int numApi, IntPtr apiBuffer)` | Retrieve device metadata + supported API codes | Requires two-call pattern: first with `IntPtr.Zero` to get count, second with allocated buffer. | Immediately after open to determine model name, serial, firmware, API list. | On failure free any allocated buffer and abort connection. |

## 2. Camera Mode & Priority (SDK §4.1.6)
| Constant / API | Value | Description |
| --- | --- | --- |
| `XSDK_PRIORITY_PC` | `0x0002` | Sets camera to PC priority mode; must be set after open. |
| `XSDK_SetPriorityMode(IntPtr hCamera, int mode)` | – | Switches between camera vs PC control. |
| `XSDK_GetPriorityMode(IntPtr hCamera, out int mode)` | – | Diagnostic readback, optional. |
| `XSDK_SetMode(IntPtr hCamera, int mode)` | – | Sets PASM mode (Manual). Value per model from JSON `SdkConstants.ModeManual`. |
| `XSDK_GetMode(IntPtr hCamera, out int mode)` | – | Verifies current AE mode; used for logging. |
| `XSDK_GetAEMode(IntPtr hCamera, out int plAEMode)` | – | Additional diagnostics for dial-driven bodies. |

## 3. Exposure Control (SDK §4.1.9)
| Item | Value / Source | Usage |
| --- | --- | --- |
| `XSDK_CapSensitivity` | Function | Two-call pattern; obtains allowed ISO list for given DR. |
| `XSDK_SetSensitivity` | Function | Sets ISO (Gain) prior to exposure; values from capabilities. |
| `XSDK_GetSensitivity` | Function | Fetch current ISO; used for state logging and property reads. |
| `XSDK_CapShutterSpeed` | Function | Returns shutter code list and bulb capability flag. |
| `XSDK_SetShutterSpeed` | Function | Sets timed exposure or enters bulb (-1). |
| `XSDK_GetShutterSpeed` | Function | Diagnostic logging before exposure. |
| `XSDK_SetDRange`/`XSDK_GetDRange` | Functions | DR constants: `XSDK_DRANGE_*` (100/200/400/800). Used before sensitivity query. |
| `XSDK_RELEASE_SHOOT` | `0x0100` | Base release command (S2). |
| `XSDK_RELEASE_S1ON` | `0x0200` | Half-press / prefocus. |
| `XSDK_RELEASE_N_S1OFF` | `0x0004` | Release S1 flag. |
| `XSDK_RELEASE_SHOOT_S1OFF` | `0x0104` | Combined timed exposure command (shoot + S1 off). |
| `XSDK_RELEASE_BULBS2_ON` | `0x0500` | Initiates bulb exposure. |
| `XSDK_RELEASE_N_BULBS2OFF` | `0x0008` | Bulb release flag. |
| `XSDK_RELEASE_N_BULBS1OFF` | `0x000C` | Stops bulb exposure (Bulb S1 off + Bulb stop). |
| `XSDK_SHUTTER_BULB` | `-1` | Special shutter value for bulb exposures. |

### Exposure Call Sequences
1. **Timed exposure**: set shutter speed → `XSDK_RELEASE_SHOOT_S1OFF` → wait (duration + buffer) → poll image → `XSDK_ReadImage`.
2. **Bulb exposure (PASM body)**: set shutter speed to `XSDK_SHUTTER_BULB` → `S1ON` → 500 ms delay → `BULBS2_ON` → wait duration → `N_BULBS1OFF` → poll image.
3. **Bulb exposure (dial body)**: skip `XSDK_SetShutterSpeed`, but run same release sequence while user sets dial to bulb.

## 4. Image Acquisition (SDK §4.1.8)
| API | Purpose | Notes |
| --- | --- | --- |
| `XSDK_ReadImageInfo(IntPtr hCamera, out XSDK_ImageInformation info)` | Query image metadata | Use to detect image readiness (`lDataSize > 0`) and format code. |
| `XSDK_ReadImage(IntPtr hCamera, IntPtr buffer, uint size)` | Download raw image bytes | Requires pinned managed buffer; respects size from `ReadImageInfo`. |
| `XSDK_DeleteImage(IntPtr hCamera)` | Remove current image from camera buffer | Used when format not RAW or after successful download. |
| `XSDK_GetBufferCapacity(IntPtr hCamera, out int shootFrames, out int totalFrames)` | Optional capacity info | Helps diagnose buffer overruns, not currently used. |

### Format Validation
- JSON `SdkConstants` provides acceptable RAW formats: `ImageQualityRaw`, `ImageQualityRawFine`, `ImageQualityRawNormal`, `ImageQualityRawSuperfine`.
- Reject any `XSDK_ImageInformation.lFormat` not matching the configured set; call `XSDK_DeleteImage` to keep buffer clean.

## 5. Error Codes (SDK §4.1.4)
| Constant | Value | Description |
| --- | --- | --- |
| `XSDK_COMPLETE` | `0` | Success. |
| `XSDK_ERROR` | `-1` | Unspecific error. |
| `XSDK_ERRCODE_NOERR` | `0x0000` | No error. |
| `XSDK_ERRCODE_SEQUENCE` | `0x1001` | Invalid call order. |
| `XSDK_ERRCODE_PARAM` | `0x1002` | Invalid parameter. |
| `XSDK_ERRCODE_INVALID_CAMERA` | `0x1003` | Handle invalid / camera disconnected. |
| `XSDK_ERRCODE_BUSY` | `0x1006` | Camera busy (e.g., executing exposure). |
| `XSDK_ERRCODE_SHOOT_ERROR` | `0x1008` | Exposure failed. |
| `XSDK_ERRCODE_TIMEOUT` | `0x2002` | Communication timeout. |
| `XSDK_ERRCODE_COMMUNICATION` | `0x2001` | I/O failure. |
| `XSDK_ERRCODE_INTERNAL` | `0x9001` | Internal SDK error. |
| `XSDK_ERRCODE_UNKNOWN` | `0x9100` | Unknown failure. |

Use `XSDK_GetErrorNumber(IntPtr hCamera, out int apiCode, out int errCode)` after failures to retrieve detailed error context for logging/UI.

## 6. Focus & Lens Control (SDK §4.2.1)
| API | Purpose | Notes |
| --- | --- | --- |
| `XSDK_CapFocusMode` | Enumerate focus modes | Determine if manual/continuous AF supported. |
| `XSDK_SetFocusMode` / `XSDK_GetFocusMode` | Switch focus mode | Manual focus code stored in JSON `SdkConstants.FocusModeManual`. |
| `XSDK_CapFocusPos` | Query focus position range | Provides min/max positions for lens. |
| `XSDK_GetFocusPos` / `XSDK_SetFocusPos` | Absolute focus operations | Use for implementing `IFocuser.Position`. |
| `XSDK_SetFocusOperation` | Trigger AF drive | Required for half-press/completion; takes `lAPICode` from model API list. |
| `XSDK_CapFocusArea`, `XSDK_SetFocusArea` | Optional zone selection | Only needed if providing advanced AF controls. |

*Note:* Specific focus API codes (`lAPICode`) vary per body and must be obtained from `XSDK_GetDeviceInfoEx` API list or vendor documentation (captured in JSON configs when available).

## 7. Image Quality & Compression (SDK §4.2.5)
| API / Constant | Value | Description |
| --- | --- | --- |
| `XSDK_SetImageQuality(int quality)` | – | Set RAW/JPEG output mode. Value from JSON `SdkConstants.ImageQualityRaw` etc. |
| `XSDK_GetImageQuality(out int quality)` | – | Verify selected image quality. |
| `XSDK_SetRAWCompression(int mode)` | `0` = uncompressed, `1` = lossless, `2` = lossy | Plugin forces `0` (uncompressed). |
| `XSDK_GetRAWCompression(out int mode)` | – | Diagnostics / verification. |

## 8. Miscellaneous Constants & Helpers
| Item | Value | Usage |
| --- | --- | --- |
| `XSDK_DSC_IF_USB` | `1` | Interface code for USB detection. |
| `SdkConstantConfig` JSON | Model-specific | Stores manual mode, focus mode, image quality codes, shutter mapping. |
| `durationToSdkShutterSpeed` map | Derived | Maps seconds to shutter codes (populated from SDK PDF pp. 91–95). |
| `FujifilmSdkWrapper.GetIntArrayFromSdkSensitivity` | Helper | Wraps two-call pattern with managed allocation & logging. |
| `FujifilmSdkWrapper.GetIntArrayFromSdkShutterSpeed` | Helper | Retrieves shutter list and bulb capability. |

## 9. Sequencing Notes
1. Always initialize SDK before attempting detection.
2. After `XSDK_OpenEx`, set PC priority, gather device info, load configuration, set manual mode (if required), enforce RAW/uncompressed, then cache capabilities.
3. Before exposures, ensure camera state idle, validate requested gain/exposure against cached limits, set shutter/ISO, and run release sequence.
4. Poll `XSDK_ReadImageInfo` until data available; download with `XSDK_ReadImage`, validate format, and delete or process accordingly.
5. Wrap all SDK calls with logging and `CheckSdkError` to capture API & error codes for diagnostics.

## 10. Future Considerations
- Wi-Fi transport uses different interface codes (`XSDK_DSC_IF_TCPIP`); not prioritized but note for backlog.
- Movie control APIs (§4.1.14) and optional imaging properties (film simulations, dynamic range expansions) can be exposed later via plugin settings.
