Fujifilm Native Camera Plugin for N.I.N.A.
==========================================
Version: 2.4.9.0
Author: Scdouglas

DESCRIPTION
-----------
Native camera support for Fujifilm X-series and GFX cameras in N.I.N.A.
(Nighttime Imaging 'N' Astronomy). Provides direct camera control without
requiring third-party capture software.

Supported cameras include X-T2, X-T3, X-T4, X-T5, X-H2, X-H2S, X-Pro3,
X-S20, X-M5, GFX 50S, GFX 50R, GFX 100, GFX 100S, and more.

REQUIREMENTS
------------
- N.I.N.A. version 3.2.0 or later
- Windows 10/11 (64-bit)
- Fujifilm camera with USB tethering support
- Camera set to "USB RAW CONV./BACKUP RESTORE" or "USB TETHER SHOOTING AUTO"

INSTALLATION
------------
1. Close N.I.N.A. if it is running

2. Navigate to your N.I.N.A. plugins folder:
   %LOCALAPPDATA%\NINA\Plugins\

   (Usually: C:\Users\<YourName>\AppData\Local\NINA\Plugins\)

3. Create a new folder called "Fujifilm" (if it doesn't exist):
   %LOCALAPPDATA%\NINA\Plugins\Fujifilm\

4. Copy the ENTIRE contents of the "Fujifilm" folder from this package
   into the plugins folder you just created

5. Start N.I.N.A.

6. Go to Options > Equipment > Camera and select your Fujifilm camera

CAMERA SETUP
------------
On your Fujifilm camera:
1. Go to MENU > SETUP > CONNECTION SETTING > USB SETTING
2. Set to "USB RAW CONV./BACKUP RESTORE" or "USB TETHER SHOOTING AUTO"
3. Connect camera to PC via USB
4. Turn camera ON

PLUGIN SETTINGS
---------------
Access plugin settings via Options > Plugins > Fujifilm Native Camera

Key settings:
- Preview Demosaic Quality: Controls speed vs quality trade-off
  * Fast (~1s): Best for astrophotography - quick downloads
  * Balanced (~4s): Good compromise
  * High Quality (~15s): Best preview quality, slowest

- Save Native RAF Sidecar: Save original RAF files alongside FITS
- Force Manual Exposure/Focus Mode: Recommended for astrophotography

TROUBLESHOOTING
---------------
Camera not detected:
- Ensure USB setting is correct on camera
- Try a different USB port/cable
- Restart both camera and N.I.N.A.

Slow downloads:
- Check Preview Demosaic Quality setting (use "Fast" for speed)
- Disable "Save Native RAF Sidecar" if not needed

Black or corrupted images:
- Ensure camera is set to RAW mode (not JPEG)
- Check camera battery level
- Try disconnecting and reconnecting

SUPPORT
-------
For issues or feature requests, please visit:
https://github.com/scdouglas/NINA.Fujifilm.Plugin

LICENSE
-------
This plugin uses the Fujifilm X SDK which is subject to Fujifilm's
licensing terms. The LibRaw library is used for RAW processing.
