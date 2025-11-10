# Fujifilm Focus Control Design

This document explains how the plugin will expose Fujifilm lens focus capabilities to N.I.N.A. through a focuser device.

## 1. Objectives
- Provide absolute focus position control when the attached lens supports electronic focus drive.
- Offer manual override detection (disable focuser when lens lacks AF motors).
- Surface minimum/maximum focus positions, backlash adjustments, and step size conversions.

## 2. Key SDK APIs (SDK §4.2.1)
- `XSDK_CapFocusMode` / `XSDK_SetFocusMode` / `XSDK_GetFocusMode`
- `XSDK_CapFocusPos` / `XSDK_SetFocusPos` / `XSDK_GetFocusPos`
- `XSDK_SetFocusOperation` (trigger AF operation)
- Optional: `XSDK_CapFocusArea`, `XSDK_SetFocusArea` (future enhancement)

## 3. Architecture
- `FujiFocuserFactory` implements `IFocuserFactory` producing descriptors when `LensCapabilityDetector` reports focus support.
- `FujiFocuser` implements `IFocuser` and `IFocuserLimits`.
- `LensCapabilityDetector` caches focus metadata per model+lens serial using `XSDK_GetDeviceInfoEx` API codes.
- `FocusCommandBuilder` converts relative step requests into SDK absolute positions.

## 4. Capability Detection Flow
1. On camera connect, query lens info via `FujifilmSdkWrapper.XSDK_GetDeviceInfoEx` and focus capability API codes list.
2. Call `XSDK_CapFocusMode` to verify manual focus mode presence (use `currentConfig.SdkConstants.FocusModeManual`).
3. Use `XSDK_CapFocusPos` to retrieve min/max position and step granularity (if available).
4. If any calls fail or lens reports non-focusable, skip focuser registration.

## 5. Focuser API Implementation
- `bool Absolute => true`
- `int Position`
  - On get: call `XSDK_GetFocusPos`, convert to `int` relative to min position.
  - On set: compute absolute target = `minFocus + steps` and call `XSDK_SetFocusPos`.
- `void Move(int position)`
  - Validate within `[0, MaxStep]`.
  - Optionally queue operations using `SemaphoreSlim` to avoid overlapping moves.
- `bool IsMoving`
  - Fuji SDK operations are synchronous; return `false` after command completes.
- `int MaxStep`
  - Derived from `maxFocus - minFocus` or fallback to config default if unavailable.
- `int MaxIncrement`
  - Could match `MaxStep` or limit to safe value (e.g., 2000) to avoid lens runaway.
- `double StepSize`
  - Estimate microns per step using lens focal length & hyperfocal formula (approx) or provide config override.
- `bool TempComp => false`, `double Temperature => throw PropertyNotImplemented` (Fuji lenses lack sensors).

## 6. Manual Focus & AF Assist
- Provide plugin setting “Force manual focus mode on connect.” When enabled, call `XSDK_SetFocusMode` with manual code.
- Offer optional `RunAutoFocus` method mapping to `XSDK_SetFocusOperation` for half-press AF if lens supports it (exposed via sequencer instruction later).

## 7. Safety & Error Handling
- Wrap all SDK calls with `FujifilmSdkException` handling; map busy/invalid state to user-friendly errors.
- If lens is physically switched to manual focus, `XSDK_SetFocusPos` may fail; catch error and disable focuser with warning.
- Provide methods to refresh capabilities at runtime (if lens swapped while connected).

## 8. Testing
- Unit tests mocking `IFujifilmSdk` to simulate focus ranges and error codes.
- Integration test plan: connect to lens with AF (e.g., XF 50mm f/1.0), run move commands, verify response.
- Negative test: attach manual focus lens (e.g., Laowa) and ensure focuser not registered.

## 9. Deliverables
- `FujiFocuserFactory.cs`, `FujiFocuser.cs`, `LensCapabilityDetector.cs`, `FocusCommandBuilder.cs`.
- Unit tests within `tests/.../Devices/FujiFocuserTests.cs`.
- Settings UI options for focus features documented in `docs/implementation-notes.md`.
