# FujiAF

This repository contains a native [N.I.N.A.](https://nighttime-imaging.eu/) plugin that enables direct control of Fujifilm X/GFX cameras, including RAW capture and electronic lens focus management.

## Project Structure
- `NINA.Plugins.Fujifilm.sln` – Visual Studio solution for the plugin.
- `src/NINA.Plugins.Fujifilm` – Plugin source code (interop, camera/focuser devices, configuration loader, diagnostics, settings UI).
- `build/` – MSBuild and PowerShell helpers used for packaging and debug deployment.
- `dist/` – Generated release artifacts (`.zip` bundles with all required binaries).
- `docs/` – Design notes, testing plans, and implementation guidance.

## Requirements
- Visual Studio 2022 (17.10+) with the `.NET desktop development` workload.
- .NET 7 SDK.
- Fujifilm Camera Control SDK (64-bit) placed in `src/NINA.Plugins.Fujifilm/Interop/Native`.
- LibRaw wrapper binaries (`LibRawWrapper.dll`, `libraw.dll`) placed alongside the Fujifilm SDK DLLs.

## Building
```powershell
# Restore packages
dotnet restore NINA.Plugins.Fujifilm.sln

# Build Debug (copies output to %LOCALAPPDATA%\NINA\Plugins\Fujifilm)
msbuild NINA.Plugins.Fujifilm.sln /p:Configuration=Debug /p:Platform=x64

# Build Release and produce dist zip
msbuild NINA.Plugins.Fujifilm.sln /p:Configuration=Release /p:Platform=x64
```

The `build/Bundle.targets` target produces a zipped plugin package under `dist/` containing the managed assembly, manifest, configuration assets, and native dependencies.

## Installation
1. Copy the contents of `src/NINA.Plugins.Fujifilm/bin/x64/Debug/` (or the publish folder from a Release build) into `%LOCALAPPDATA%\NINA\Plugins\Fujifilm`.
2. Start N.I.N.A., enable unsigned plugins if necessary, and restart the application.
3. Select **Fujifilm Native Camera** from the camera list and configure settings under **Options → Equipment → Plugins**.

## Status
- Camera connection, ISO/shutter capability discovery, RAW download, and release sequencing implemented.
- Autofocus module provides manual focus control via SDK focus position commands.
- Diagnostics service records events and exports JSON bundles for troubleshooting.
- Extended LibRaw processing pipeline produces FITS frames with Fuji-specific metadata (ISO, shutter, lens, X-Trans pattern) and optional RAF sidecars for stacking tools.

Refer to the documents in `docs/` for detailed design notes, SDK mappings, and test plans.
