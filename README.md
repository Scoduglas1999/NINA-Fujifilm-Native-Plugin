# N.I.N.A. Fujifilm Native Plugin

![N.I.N.A.](https://img.shields.io/badge/N.I.N.A.-3.0%2B-purple?style=flat-square)
![Platform](https://img.shields.io/badge/Platform-Windows_x64-blue?style=flat-square)
![License](https://img.shields.io/badge/License-Apache_2.0-green?style=flat-square)

This plugin provides **native integration** for Fujifilm cameras within [N.I.N.A. (Nighttime Imaging 'N' Astronomy)](https://nighttime-imaging.eu/), bypassing the limitations of generic ASCOM drivers. It communicates directly with the camera firmware to offer robust exposure control, accurate metadata handling, and direct lens motor focusing.

---

## 🚀 Features

### 📸 Native Camera Support
*   **Direct USB Connection**: Eliminates the need for intermediate ASCOM drivers, providing a faster and more stable connection loop.
*   **Smart Metadata Handling**: Automatically detects and writes the correct **Bayer** or **X-Trans** filter patterns to FITS headers.
    *   *No more grid patterns or incorrect colors in PixInsight/Siril.*
*   **Exposure Control**: Full support for Bulb mode, ISO selection, and shutter speeds.
*   **Dual Storage**: Option to save RAW files to the camera's SD card as a backup while transferring FITS data to N.I.N.A.

### 🔭 Electronic Lens Focuser
*   **Lens Drive**: Exposes your attached electronic lens as a **Focuser Device** in N.I.N.A.
*   **Autofocus Integration**: Use N.I.N.A.'s advanced autofocus routines (Hocus Focus, Overshoot) to drive the lens motor.
    *   *Perfect for wide-field rigs using native Fuji glass.*

### 🛠️ Advanced Diagnostics
*   **Live View**: High-speed frame fetching for plate solving and manual focus.
*   **Telemetry**: Detailed logging and diagnostic bundling to assist in troubleshooting connection issues.

---

## 📷 Supported Models

The plugin utilizes the official Fujifilm SDK. The following models have verified configuration maps, though others may work:

| Series | Models |
| :--- | :--- |
| **GFX System** | GFX 100 II, GFX 100S, GFX 100, GFX 50S II, GFX 50R, GFX 50S |
| **X-H Series** | X-H2S, X-H2, X-H1 |
| **X-T Series** | X-T5, X-T4, X-T3, X-T2 |
| **X-S Series** | X-S20, X-S10 |
| **Other** | X-Pro3, X-M5 |

*> **Note:** Older models (e.g., X-T1, X-E2) generally lack the tethering protocol required for this plugin.*

---

## ⚙️ Installation & Setup

### Prerequisites
*   **N.I.N.A. 3.0+** (Beta/Nightly builds recommended for latest plugin API).
*   **Visual C++ Redistributable (x64)**.

### Installation
1.  Download the latest release zip from the [**Releases**](../../releases) page.
2.  Navigate to your local N.I.N.A. plugins directory:
    ```text
    %LOCALAPPDATA%\NINA\Plugins\
    ```
3.  Create a new folder named `Fujifilm`.
      - NINA's folder strucutre in here can vary. During development, the `Fujifilm` folder on my system had to be in the `3.0.0` folder.
5.  Extract the contents of the zip file into this folder.
6.  Restart N.I.N.A.

### Camera Configuration
For the plugin to control the camera, ensure your physical camera settings are correct:
1.  **Connection Mode**: Set to `USB TETHER SHOOTING AUTO` or `PC SHOOT AUTO` (Network/Connection Settings).
2.  **Drive Dial**: Set to `S` (Single Shot).
3.  **Focus Mode**:
    *   If using the **Lens Focuser** feature: Set switch to **S** or **C** (AF).
    *   If using a telescope: Set switch to **M** (Manual).

---

## 🖥️ Usage in N.I.N.A.

1.  **Connect Camera**:
    *   Go to **Equipment > Camera**.
    *   Select **Fujifilm Native Camera** from the dropdown.
    *   Click the connect button.
2.  **Connect Focuser** (Optional):
    *   Go to **Equipment > Focuser**.
    *   Select **Fujifilm Native Focuser**.
    *   *Note: This allows the AF routines to move the lens elements.*
3.  **Imaging**:
    *   ISO and Shutter speed can be adjusted directly in the Imaging tab.
    *   Bulb mode is handled automatically for exposures > 30s (depending on model).

---

## 🧑‍💻 Development

To build this project from source, you will need:
*   **Visual Studio 2022** (or newer).
*   **.NET 7.0 SDK**.
*   **Fujifilm SDK**: Due to licensing, the SDK libraries cannot be distributed in this repo. You must apply for the SDK from Fujifilm and place the relevant `.dll` and `.lib` files in `src/NINA.Plugins.Fujifilm/Interop/Native`.

```powershell
# Build command
dotnet build -c Release
```

---

## 🐛 Troubleshooting

| Issue | Solution |
| :--- | :--- |
| **"Camera Busy"** | The camera is likely writing to the internal SD card buffer. Increase the delay between shots in N.I.N.A. sequencer options. |
| **Focus Timeout** | Ensure the lens is not set to "Manual Clutch" (physical ring pulled back) on lenses like the 16mm f/1.4 or 23mm f/1.4. |
| **Connection Failed** | Ensure no other software (Lightroom, Capture One, X Acquire) is running and capturing the USB port. |

---

## 📄 License

Distributed under the **Apache 2.0 License**. See `LICENSE` for more information.

*Disclaimer: This software is an independent community project and is not affiliated with, endorsed by, or associated with FUJIFILM Corporation.*
