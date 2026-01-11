# N.I.N.A. Fujifilm Native Plugin

![N.I.N.A.](https://img.shields.io/badge/N.I.N.A.-3.0%2B-purple?style=flat-square)
![Platform](https://img.shields.io/badge/Platform-Windows_x64-blue?style=flat-square)
![License](https://img.shields.io/badge/License-Apache_2.0-green?style=flat-square)
![.NET](https://img.shields.io/badge/.NET-8.0-blue?style=flat-square)

A native camera integration plugin for [N.I.N.A. (Nighttime Imaging 'N' Astronomy)](https://nighttime-imaging.eu/) that enables direct USB communication with Fujifilm cameras. This plugin bypasses generic ASCOM drivers to interface directly with the camera firmware, providing features and performance not available through standard drivers.

---

## Features

### Camera Control

- **Direct USB Communication**: Connects directly to the camera via USB for reliable, low-latency control
- **Full Exposure Control**: Supports timed exposures and bulb mode up to 60 minutes
- **ISO Management**: Queries available ISO values from the camera and allows full programmatic control
- **16-bit RAW Capture**: Captures full-resolution RAW images with complete sensor data
- **Battery Monitoring**: Real-time battery level display in the camera equipment panel with automatic refresh
- **Lens Detection**: Displays attached lens model, focal length, aperture, and OIS (optical image stabilization) status

### X-Trans Sensor Support

- **Synthetic Bayer Preview**: Converts X-Trans sensor data to a standard Bayer pattern for full-color live preview in N.I.N.A.
- **Non-Destructive Processing**: Preview conversion does not affect saved images; original RAW data is preserved
- **Correct Metadata**: Writes appropriate `BAYERPAT` and `ROWORDER` FITS headers for compatibility with PixInsight, Siril, and other stacking software

### Electronic Lens Focuser

- **Native Lens Control**: Exposes electronic Fujifilm lenses as focuser devices in N.I.N.A.
- **Absolute Position Control**: Moves focus to specific positions within the lens mechanical range
- **Autofocus Compatibility**: Works with N.I.N.A.'s autofocus routines for automated focusing with native Fuji lenses
- **Focus Range Detection**: Automatically queries lens focus limits (infinity to close focus)

### Configuration Options

- **Demosaic Quality**: Selectable preview quality (Fast/Balanced/High Quality) to balance speed and image quality
- **RAF Sidecar Export**: Optional saving of native Fujifilm RAF files alongside processed images
- **Extended FITS Metadata**: Adds Fujifilm-specific metadata to FITS headers
- **Focus Backlash Compensation**: Configurable backlash correction for precise focus control
- **Camera Profiles**: Save and load configuration presets for different imaging scenarios

---

## Supported Cameras

The plugin supports Fujifilm cameras with USB tethering capability. Configuration files are included for the following models:

| Series | Models |
| :--- | :--- |
| **GFX (Medium Format)** | GFX100, GFX100S, GFX50S, GFX50R |
| **X-H Series** | X-H2, X-H2S |
| **X-T Series** | X-T5, X-T4, X-T3, X-T2 |
| **X-S Series** | X-S20 |
| **Other** | X-Pro3, X-M5 |

**Note:** Older models without USB tethering protocol support (such as X-T1, X-E2, and earlier) are not compatible with this plugin.

---

## Requirements

- **N.I.N.A. 3.0 or later**
- **Windows x64**
- **Visual C++ Redistributable (x64)**
- **.NET 8.0 Runtime**

---

## Installation

1. Download the latest release from the [Releases](../../releases) page
2. Navigate to your N.I.N.A. plugins directory:
   ```
   %LOCALAPPDATA%\NINA\Plugins\3.0.0\
   ```
3. Create a folder named `Fujifilm`
4. Extract the release contents into this folder
5. Restart N.I.N.A.

---

## Camera Setup

Configure your camera with the following settings for proper plugin operation:

### Physical Camera Settings

| Setting | Required Value | Purpose |
| :--- | :--- | :--- |
| **Connection Mode** | `USB TETHER SHOOTING AUTO` or `PC SHOOT AUTO` | Enables USB control |
| **Drive Dial** | `S` (Single Shot) | Prevents burst capture conflicts |
| **Shutter Dial** | `T` (Time) or `A` (Auto) | Allows software shutter control |
| **ISO Dial** | `A` (Auto) or `C` (Command) | Allows software ISO control |
| **Focus Mode** | `S` or `C` for lens focuser; `M` for manual/telescope | Determines focus control method |

### N.I.N.A. Settings

For X-Trans cameras to display color preview:

1. Navigate to **Options > Imaging**
2. Enable **Debayer Image** (or "Auto Debayer")
3. In the Imaging tab, verify the **Debayer** toggle is active in the image panel toolbar

---

## Plugin Settings

Access plugin settings through **Options > Equipment > Camera > Fujifilm**.

| Setting | Description | Default |
| :--- | :--- | :--- |
| **Force Manual Exposure Mode** | Ensures camera operates in Manual mode | Enabled |
| **Force Manual Focus Mode** | Ensures lens operates in manual focus | Enabled |
| **Bulb Release Delay** | Delay in milliseconds for bulb mode releases | 500ms |
| **Save Native RAF Sidecar** | Saves original RAF file alongside processed images | Disabled |
| **Extended FITS Metadata** | Adds Fujifilm metadata to FITS headers | Enabled |
| **Demosaic Quality** | Preview processing quality (Fast/Balanced/High Quality) | Fast |
| **Focus Backlash Steps** | Backlash compensation for focus operations | 0 |

---

## Troubleshooting

| Issue | Cause | Solution |
| :--- | :--- | :--- |
| **Camera Busy / Exposure Fail** | Camera writing to SD card | Increase image download delay in N.I.N.A. options, or disable SD card recording in camera settings |
| **Exposure Error 0x2003** | Invalid dial combination | Set Shutter and ISO dials to `T`/`A` or `C` to allow software control |
| **Black & White Preview** | Debayering disabled | Enable **Debayer Image** in N.I.N.A. imaging options |
| **Focus Timeout** | Lens in manual focus mode | Ensure lens focus switch is set to `S` or `C` (not pulled back to MF on clutch-type lenses) |
| **Lens Not Detected** | Manual focus lens or adapter | Only electronic AF lenses are supported for focuser control |
| **Battery Not Updating** | Normal behavior | Battery status refreshes every 30 seconds while connected |

---

## Limitations

- **No Live View**: Live view video streaming is not currently implemented
- **No Binning**: Only full-frame capture is supported
- **No Cooling Control**: Fujifilm cameras do not have cooling systems
- **RAW Only**: Plugin captures RAW images; JPEG capture is not supported
- **Windows Only**: Requires Windows x64; macOS and Linux are not supported
- **Electronic Lenses Only**: Focus control requires lenses with electronic focus motors

---

## Building from Source

### Requirements

- Visual Studio 2022
- .NET 8.0 SDK
- Fujifilm X Acquire SDK (must be obtained from Fujifilm)

### Build Steps

1. Obtain the Fujifilm SDK and place the DLL files in `src/NINA.Plugins.Fujifilm/Interop/Native/`
2. Open the solution in Visual Studio or build from command line:
   ```powershell
   dotnet build -c Release
   ```
3. Output files will be in `src/NINA.Plugins.Fujifilm/bin/Release/net8.0-windows/`

---

## License

This project is licensed under the **Apache License 2.0**. See the [LICENSE](LICENSE) file for details.

---

*This software is an independent community project. It is not affiliated with, endorsed by, or associated with FUJIFILM Corporation or the N.I.N.A. development team.*
