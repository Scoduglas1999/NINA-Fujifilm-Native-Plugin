# Testing & Documentation Plan

## 1. Test Environment Matrix
| Camera Model | Firmware | Connection | Lens | Notes |
| --- | --- | --- | --- | --- |
| GFX100S | Latest | USB-C | GF 32-64mm | Validate medium format bulb modes. |
| X-T5 | Latest | USB-C | XF 33mm f/1.4 | APS-C timed exposures & AF. |
| X-H2S | Latest | USB-C | XF 50-140mm | High-speed drive tests, buffer limits. |
| X-S20 | Latest | USB-C | XC 15-45mm | Test PASM manual-mode enforcement. |

## 2. Test Cases
1. **Connection Lifecycle**
   - Connect/disconnect repeatedly (20 cycles) ensuring no handle leaks.
   - Verify correct config loaded (log camera model, config name).
2. **Capability Verification**
   - Compare ISO/shutter lists against camera menu; confirm min/max exposures match.
   - For each camera, capture enumerated exposures to ensure correctness.
3. **Timed Exposures**
   - Capture exposures from 1/1000s to 30s; ensure download success and FITS metadata accurate.
4. **Bulb Exposures**
   - Capture 60s, 180s, 600s exposures; verify release sequence stops reliably and no residual exposures.
   - Observe buffer usage to confirm `XSDK_DeleteImage` clears frames.
5. **Focus Control**
   - Execute absolute moves across range; measure repeatability.
   - Trigger autofocus operation (if supported) and verify state after completion.
6. **Diagnostics & Logging**
   - Enable SDK trace, perform exposures, confirm logs contain release sequence & error codes.
7. **Failure Scenarios**
   - Disconnect cable mid-exposure – plugin should transition to error and prompt user.
   - Attempt to set unsupported ISO – plugin must reject with validation error.
8. **Packaging Verification**
   - Install release zip on clean machine; confirm plugin loads and finds native DLLs.

## 3. Automation Possibilities
- Use N.I.N.A.’s sequencer scripting to run repeated exposures and capture logs.
- Create PowerShell helper to copy logs and create timestamped bundles after test run.

## 4. Documentation Deliverables
1. **User Guide (`docs/README.md`)**
   - Installation instructions (copy zip, enable plugin).
   - Supported camera models and required camera settings (USB power, exposure dial positions).
   - How to enable SDK trace and export diagnostics.
   - Focus module usage (supported lenses, backlash tuning).
2. **Troubleshooting (`docs/troubleshooting.md`)**
   - Table mapping SDK error codes to resolutions.
   - Common pitfalls (camera not in PC mode, lens manual focus switch, buffer full).
3. **Changelog (`docs/CHANGELOG.md`)**
   - Document features and fixes per release.
4. **Third-Party Notices (`docs/THIRD_PARTY.md`)**
   - Fujifilm SDK license summary.
   - LibRaw licensing terms.
5. **Implementation Notes (`docs/implementation-notes.md`)**
   - Explain architecture decisions for future contributors.

## 5. Reporting & Regression Tracking
- Maintain `tests/results/YYYY-MM-DD/` folder containing logs, FITS samples, and summary reports.
- Track open issues (e.g., camera-specific quirks) in `docs/known-issues.md`.
- After each release, update regression checklist to include newly discovered scenarios.
