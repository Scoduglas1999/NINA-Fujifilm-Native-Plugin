using System;
using System.Runtime.InteropServices;
using System.Text;

namespace NINA.Plugins.Fujifilm.Interop;

internal static class FujifilmSdkWrapper
{
    private const string SdkDllName = "XAPI.dll";

    public const int XSDK_COMPLETE = 0;
    public const int XSDK_ERROR = -1;

    public const int XSDK_DSC_IF_USB = 1;

    public const int XSDK_PRIORITY_PC = 0x0002;

    // Error Codes (SDK §5)
    public const int XSDK_ERRCODE_NOERR = 0x0000;
    public const int XSDK_ERRCODE_SEQUENCE = 0x1001;
    public const int XSDK_ERRCODE_PARAM = 0x1002;
    public const int XSDK_ERRCODE_INVALID_CAMERA = 0x1003;
    public const int XSDK_ERRCODE_LOADLIB = 0x1004;
    public const int XSDK_ERRCODE_UNSUPPORTED = 0x1005;
    public const int XSDK_ERRCODE_BUSY = 0x1006;
    public const int XSDK_ERRCODE_FORCEMODE_BUSY = 0x1007;
    public const int XSDK_ERRCODE_AF_TIMEOUT = 0x1008;
    public const int XSDK_ERRCODE_SHOOT_ERROR = 0x1009;
    public const int XSDK_ERRCODE_FRAME_FULL = 0x100A;
    public const int XSDK_ERRCODE_STANDBY = 0x1010;
    public const int XSDK_ERRCODE_NODRIVER = 0x100C;
    public const int XSDK_ERRCODE_NO_MODEL_MODULE = 0x100D;
    public const int XSDK_ERRCODE_API_NOTFOUND = 0x100E;
    public const int XSDK_ERRCODE_API_MISMATCH = 0x100F;
    public const int XSDK_ERRCODE_COMMUNICATION = 0x2001;
    public const int XSDK_ERRCODE_TIMEOUT = 0x2002;
    public const int XSDK_ERRCODE_COMBINATION = 0x2003;
    public const int XSDK_ERRCODE_WRITEERROR = 0x2004;
    public const int XSDK_ERRCODE_CARDFULL = 0x2005;
    public const int XSDK_ERRCODE_HARDWARE = 0x3001;
    public const int XSDK_ERRCODE_INTERNAL = 0x9001;
    public const int XSDK_ERRCODE_MEMFULL = 0x9002;
    public const int XSDK_ERRCODE_UNKNOWN = 0x9100;
    public const int XSDK_ERRCODE_RUNNING_OTHER_FUNCTION = 0x9101;

    public const int XSDK_RELEASE_SHOOT = 0x0100;
    public const int XSDK_RELEASE_N_S1OFF = 0x0004;
    public const int XSDK_RELEASE_SHOOT_S1OFF = XSDK_RELEASE_SHOOT | XSDK_RELEASE_N_S1OFF;
    public const int XSDK_RELEASE_S1ON = 0x0200;
    public const int XSDK_RELEASE_BULBS2_ON = 0x0500;
    public const int XSDK_RELEASE_N_BULBS2OFF = 0x0008;
    public const int XSDK_RELEASE_N_BULBS1OFF = XSDK_RELEASE_N_BULBS2OFF | XSDK_RELEASE_N_S1OFF;
    public const int XSDK_SHUTTER_BULB = -1;

    public const int XSDK_DRANGE_100 = 0x0064;
    
    // AE Mode constants
    public const int XSDK_AE_OFF = 0x0001;  // Manual exposure mode
    public const int XSDK_AE_PROGRAM = 0x0006;  // Program AE
    public const int XSDK_AE_APERTURE_PRIORITY = 0x0003;  // Aperture priority
    public const int XSDK_AE_SHUTTER_PRIORITY = 0x0004;  // Shutter priority
    public const int XSDK_DRANGE_200 = 200;
    public const int XSDK_DRANGE_400 = 400;
    public const int XSDK_DRANGE_800 = 800;
    public const int XSDK_DRANGE_AUTO = 0xffff;
    
    // Shooting Mode Constants
    public const int XSDK_MODE_M = 0x1101;  // Manual mode

    // Media Record Constants
    public const int XSDK_MEDIAREC_OFF = 0;
    public const int XSDK_MEDIAREC_SD = 1;
    public const int XSDK_MEDIAREC_RAW = 2;

    // ========== Battery Info API (from XAPIOpt.h) ==========
    public const int API_CODE_CheckBatteryInfo = 0x4055;

    // Battery API parameter values - model specific:
    // Newer models (X-T5, X-H2, X-H2S, X-S20, X-M5, GFX100II, GFX100SII): param = 8
    // Older models (X-T3, X-T4, X-S10, X-Pro3, GFX50S, GFX50R, GFX100S, GFX50SII): param = 6
    // The param value represents the number of output values the API supports
    // For body battery info/ratio, we try param 1 first, then model-specific values
    public const int API_PARAM_CheckBatteryInfo_Body = 1;        // Body battery info (status code)
    public const int API_PARAM_CheckBatteryInfo_BodyRatio = 4;   // Body battery ratio (0-100%)
    public const int API_PARAM_CheckBatteryInfo_NewModels = 8;   // For X-T5, X-H2, etc.
    public const int API_PARAM_CheckBatteryInfo_OldModels = 6;   // For X-T3, X-T4, etc.

    // Power Capacity Status Codes (from XAPIOpt.h lines 1234-1247)
    public const int SDK_POWERCAPACITY_EMPTY = 0x0000;      // Empty
    public const int SDK_POWERCAPACITY_END = 0x0001;        // End (about to die)
    public const int SDK_POWERCAPACITY_PREEND = 0x0002;     // Pre-end (very low)
    public const int SDK_POWERCAPACITY_HALF = 0x0003;       // Half
    public const int SDK_POWERCAPACITY_FULL = 0x0004;       // Full
    public const int SDK_POWERCAPACITY_HIGH = 0x0005;       // High
    public const int SDK_POWERCAPACITY_PREEND5 = 0x0007;    // Less than 20%
    public const int SDK_POWERCAPACITY_20 = 0x0008;         // 20%
    public const int SDK_POWERCAPACITY_40 = 0x0009;         // 40%
    public const int SDK_POWERCAPACITY_60 = 0x000A;         // 60%
    public const int SDK_POWERCAPACITY_80 = 0x000B;         // 80%
    public const int SDK_POWERCAPACITY_100 = 0x000C;        // 100%
    public const int SDK_POWERCAPACITY_DC_CHARGE = 0x000D;  // Charging via DC
    public const int SDK_POWERCAPACITY_DC = 0x00FF;         // Powered by DC adapter

    // ========== Drive Mode API Codes (from XAPI.h lines 238-240) ==========
    public const int API_CODE_SetDriveMode = 0x1377;
    public const int API_CODE_GetDriveMode = 0x1378;
    public const int API_CODE_CapDriveMode = 0x1379;
    public const int API_PARAM_DriveMode = 1;

    // ========== Drive Mode Constants (from XAPI.h lines 2107-2124) ==========
    public const int XSDK_DRIVE_MODE_S = 0x0001;           // Single shot
    public const int XSDK_DRIVE_MODE_CL = 0x0002;          // Continuous Low
    public const int XSDK_DRIVE_MODE_CH = 0x0003;          // Continuous High
    public const int XSDK_DRIVE_MODE_BOOST = 0x0004;       // Continuous Boost
    public const int XSDK_DRIVE_MODE_BKT_AE = 0x000A;      // Auto Exposure Bracketing
    public const int XSDK_DRIVE_MODE_BKT_ISO = 0x000B;     // ISO Bracketing
    public const int XSDK_DRIVE_MODE_BKT_DYNAMICRANGE = 0x000E;  // Dynamic Range Bracketing
    public const int XSDK_DRIVE_MODE_BKT_FOCUS = 0x000F;   // Focus Bracketing

    // ========== Lens Position/Zoom API Codes (from XAPI.h) ==========
    public const int API_CODE_CapLensZoomPos = 0x1321;
    public const int API_CODE_SetLensZoomPos = 0x1322;
    public const int API_CODE_GetLensZoomPos = 0x1323;
    public const int API_PARAM_LensZoomPos = 1;

    // ========== Aperture API Codes (from XAPI.h) ==========
    public const int API_CODE_CapAperture = 0x1324;
    public const int API_CODE_SetAperture = 0x1325;
    public const int API_CODE_GetAperture = 0x1326;
    public const int API_PARAM_Aperture = 1;

    // ========== Live View API Codes (from XAPI.h) ==========
    public const int API_CODE_StartLiveView = 0x3301;
    public const int API_CODE_StopLiveView = 0x3302;
    public const int API_CODE_SetLiveViewImageQuality = 0x3323;
    public const int API_CODE_SetLiveViewImageSize = 0x3325;
    public const int API_CODE_SetThroughImageZoom = 0x3327;
    public const int API_PARAM_LiveView = 1;

    // ========== Live View Quality Constants ==========
    public const int XSDK_LIVEVIEW_QUALITY_FINE = 0x0001;
    public const int XSDK_LIVEVIEW_QUALITY_NORMAL = 0x0002;
    public const int XSDK_LIVEVIEW_QUALITY_BASIC = 0x0003;

    // ========== Live View Size Constants ==========
    public const int XSDK_LIVEVIEW_SIZE_L = 0x0001;   // 1280px
    public const int XSDK_LIVEVIEW_SIZE_M = 0x0002;   // 800px
    public const int XSDK_LIVEVIEW_SIZE_S = 0x0003;   // 640px

    // ========== Image Format Constants ==========
    public const int XSDK_IMAGEFORMAT_RAW = 1;
    public const int XSDK_IMAGEFORMAT_JPEG = 2;
    public const int XSDK_IMAGEFORMAT_TIFF = 3;
    public const int XSDK_IMAGEFORMAT_LIVE = 4;  // Live View JPEG

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_Init")]
    public static extern int XSDK_Init(IntPtr hLib);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_Exit")]
    public static extern int XSDK_Exit();

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_Detect")]
    public static extern int XSDK_Detect(int lInterface, IntPtr pInterface, IntPtr pDeviceName, out int plCount);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_OpenEx")]
    public static extern int XSDK_OpenEx([MarshalAs(UnmanagedType.LPStr)] string pDevice, out IntPtr phCamera, out int plCameraMode, IntPtr pOption);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_Close")]
    public static extern int XSDK_Close(IntPtr hCamera);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_SetPriorityMode")]
    public static extern int XSDK_SetPriorityMode(IntPtr hCamera, int lPriorityMode);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_GetDeviceInfoEx")]
    public static extern int XSDK_GetDeviceInfoEx(IntPtr hCamera, out XSDK_DeviceInformation pDevInfo, out int plNumAPICode, IntPtr plAPICode);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_CapShutterSpeed")]
    public static extern int XSDK_CapShutterSpeed(IntPtr hCamera, ref int plNumShutterSpeed, IntPtr plShutterSpeed, out int plBulbCapable);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_SetShutterSpeed")]
    public static extern int XSDK_SetShutterSpeed(IntPtr hCamera, int lShutterSpeed, int lBulb);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_CapSensitivity")]
    public static extern int XSDK_CapSensitivity(IntPtr hCamera, ref int lDR, ref int plNumSensitivity, IntPtr plSensitivity);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_SetSensitivity")]
    public static extern int XSDK_SetSensitivity(IntPtr hCamera, int lSensitivity);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_GetSensitivity")]
    public static extern int XSDK_GetSensitivity(IntPtr hCamera, out int plSensitivity);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_SetMode")]
    public static extern int XSDK_SetMode(IntPtr hCamera, int lMode);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_GetMode")]
    public static extern int XSDK_GetMode(IntPtr hCamera, out int plMode);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_SetImageQuality")]
    public static extern int XSDK_SetImageQuality(IntPtr hCamera, int lImageQuality);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_SetRAWCompression")]
    public static extern int XSDK_SetRAWCompression(IntPtr hCamera, int lRawCompression);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_SetAEMode")]
    public static extern int XSDK_SetAEMode(IntPtr hCamera, int lAEMode);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_GetAEMode")]
    public static extern int XSDK_GetAEMode(IntPtr hCamera, out int plAEMode);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_SetMediaRecord")]
    public static extern int XSDK_SetMediaRecord(IntPtr hCamera, int lMediaRecord);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_GetMediaRecord")]
    public static extern int XSDK_GetMediaRecord(IntPtr hCamera, out int plMediaRecord);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_GetLensInfo")]
    public static extern int XSDK_GetLensInfo(IntPtr hCamera, out XSDK_LensInformation pLensInfo);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_GetLensVersion")]
    public static extern int XSDK_GetLensVersion(IntPtr hCamera, [MarshalAs(UnmanagedType.LPStr)] StringBuilder pLensVersion);

    // Focus Control API Codes
    public const int XSDK_API_CODE_SetFocusPos = 0x2207;
    public const int XSDK_API_CODE_GetFocusPos = 0x2208;
    public const int XSDK_API_CODE_CapFocusPos = 0x2259;
    
    // Focus Control API Parameters (consistent across all camera models)
    public const int XSDK_API_PARAM_CapFocusPos = 2;
    public const int XSDK_API_PARAM_SetFocusPos = 1;
    public const int XSDK_API_PARAM_GetFocusPos = 1;

    // Helper methods wrapping generic property functions
    public static int XSDK_CapFocusPos(IntPtr hCamera, out XSDK_FOCUS_POS_CAP focusPosCap)
    {
        int num = 0;
        int size = Marshal.SizeOf<XSDK_FOCUS_POS_CAP>();
        IntPtr pFocusPosCap = Marshal.AllocHGlobal(size);
        
        // Initialize struct size and version as per SDK docs
        var cap = new XSDK_FOCUS_POS_CAP();
        cap.lSizeFocusPosCap = size;
        cap.lStructVer = 0x00010000;
        Marshal.StructureToPtr(cap, pFocusPosCap, false);

        System.Diagnostics.Debug.WriteLine($"[FujiSDK] XSDK_CapFocusPos: struct size={size}, API_CODE=0x{XSDK_API_CODE_CapFocusPos:X}, API_PARAM={XSDK_API_PARAM_CapFocusPos}");

        try
        {
            int result = XSDK_CapProp_Focus(hCamera, XSDK_API_CODE_CapFocusPos, XSDK_API_PARAM_CapFocusPos, ref size, pFocusPosCap);
            
            System.Diagnostics.Debug.WriteLine($"[FujiSDK] XSDK_CapFocusPos: result={result}, size after call={size}");
            
            focusPosCap = Marshal.PtrToStructure<XSDK_FOCUS_POS_CAP>(pFocusPosCap);
            
            System.Diagnostics.Debug.WriteLine($"[FujiSDK] XSDK_CapFocusPos: lSizeFocusPosCap={focusPosCap.lSizeFocusPosCap}, lStructVer=0x{focusPosCap.lStructVer:X}, lFocusPlsINF={focusPosCap.lFocusPlsINF}, lFocusPlsMOD={focusPosCap.lFocusPlsMOD}, lFocusPlsFCSDepthCap={focusPosCap.lFocusPlsFCSDepthCap}");
            
            return result;
        }
        finally
        {
            Marshal.FreeHGlobal(pFocusPosCap);
        }
    }

    public static int XSDK_GetFocusPos(IntPtr hCamera, out int plFocusPos)
    {
        long val;
        int result = XSDK_GetProp(hCamera, XSDK_API_CODE_GetFocusPos, XSDK_API_PARAM_GetFocusPos, out val);
        plFocusPos = (int)val;
        return result;
    }

    public static int XSDK_SetFocusPos(IntPtr hCamera, int lFocusPos)
    {
        return XSDK_SetProp(hCamera, XSDK_API_CODE_SetFocusPos, XSDK_API_PARAM_SetFocusPos, lFocusPos);
    }

    // Specific P/Invoke for CapFocusPos which uses IN/OUT for the size parameter
    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_CapProp")]
    private static extern int XSDK_CapProp_Focus(IntPtr hCamera, int lAPICode, int lAPIParam, ref int plSize, IntPtr pData);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_Release")]
    public static extern int XSDK_Release(IntPtr hCamera, int lReleaseMode, IntPtr plShotOpt, out int pStatus);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_ReadImageInfo")]
    public static extern int XSDK_ReadImageInfo(IntPtr hCamera, out XSDK_ImageInformation pImgInfo);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_ReadImage")]
    public static extern int XSDK_ReadImage(IntPtr hCamera, IntPtr pData, uint ulDataSize);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_DeleteImage")]
    public static extern int XSDK_DeleteImage(IntPtr hCamera);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_GetBufferCapacity")]
    public static extern int XSDK_GetBufferCapacity(IntPtr hCamera, out int plShootFrameNum, out int plTotalFrameNum);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_SetDynamicRange")]
    public static extern int XSDK_SetDynamicRange(IntPtr hCamera, int lDRange);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_GetDynamicRange")]
    public static extern int XSDK_GetDynamicRange(IntPtr hCamera, out int plDRange);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_GetImageSize")]
    public static extern int XSDK_GetImageSize(IntPtr hCamera, out int plImageSize);

    // Image Size Constants (Generic/Common)
    // The actual values depend on the camera generation, but we can define common ones or handle raw ints.
    // For GFX100S:
    // L 4:3 is what we mostly care about.
    // We will pass the raw int to CameraSpecs and handle it there.

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_GetErrorNumber")]
    public static extern int XSDK_GetErrorNumber(IntPtr hCamera, out int plAPICode, out int plERRCode);

    // Model-dependent property functions (for Long Exposure NR, Noise Reduction, etc.)
    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_CapProp")]
    public static extern int XSDK_CapProp(IntPtr hCamera, int lAPICode, int lAPIParam, out int plNum, IntPtr plValues);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_SetProp")]
    public static extern int XSDK_SetProp(IntPtr hCamera, int lAPICode, int lAPIParam, long lValue);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_GetProp")]
    public static extern int XSDK_GetProp(IntPtr hCamera, int lAPICode, int lAPIParam, out long plValue);

    // Battery Info overload for newer models (X-T5, X-H2, X-H2S, X-S20, X-M5, GFX100II, GFX100SII)
    // These models require 8 output parameters
    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_GetProp")]
    public static extern int XSDK_GetProp_Battery8(
        IntPtr hCamera,
        int lAPICode,
        int lAPIParam,
        out long plBodyBatteryInfo,
        out long plGripBatteryInfo,
        out long plGripBattery2Info,
        out long plBodyBatteryRatio,
        out long plGripBatteryRatio,
        out long plGripBattery2Ratio,
        out long plBodyBattery2Info,
        out long plBodyBattery2Ratio2);

    // Battery Info overload for older models (X-T3, X-T4, X-S10, X-Pro3, GFX50S, GFX50R, GFX100S, GFX50SII)
    // These models require 6 output parameters
    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_GetProp")]
    public static extern int XSDK_GetProp_Battery6(
        IntPtr hCamera,
        int lAPICode,
        int lAPIParam,
        out long plBodyBatteryInfo,
        out long plGripBatteryInfo,
        out long plGripBattery2Info,
        out long plBodyBatteryRatio,
        out long plGripBatteryRatio,
        out long plGripBattery2Ratio);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct XSDK_DeviceInformation
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string strVendor;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string strManufacturer;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string strProduct;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string strFirmware;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string strDeviceType;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string strSerialNo;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string strFramework;
        public byte bDeviceId;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string strDeviceName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string strYNo;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct XSDK_ImageInformation
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string strInternalName;
        public int lFormat;
        public int lDataSize;
        public int lImagePixHeight;
        public int lImagePixWidth;
        public int lImageBitDepth;
        public int lPreviewSize;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct XSDK_FOCUS_POS_CAP
    {
        public int lSizeFocusPosCap;
        public int lStructVer;
        public int lFocusPlsINF;
        public int lFocusPlsMOD;
        public int lFocusOverSearchPlsINF;
        public int lFocusOverSearchPlsMOD;
        public int lFocusPlsFCSDepthCap;
        public int lMinDriveStepMFDriveEndThresh;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct XSDK_LensInformation
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string strModel;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string strProductName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string strSerialNo;
        public int lISCapability;
        public int lMFCapability;
        public int lZoomPosCapability;
    }

    public static void CheckResult(IntPtr cameraHandle, int result, string operation)
    {
        if (result == XSDK_COMPLETE)
        {
            return;
        }

        var error = GetLastError(cameraHandle);
        throw new FujifilmSdkException(operation, result, error.ApiCode, error.ErrorCode);
    }

    public static FujifilmSdkError GetLastError(IntPtr cameraHandle)
    {
        int apiCode;
        int errCode;
        var result = XSDK_GetErrorNumber(cameraHandle, out apiCode, out errCode);
        return new FujifilmSdkError(result, apiCode, errCode);
    }
}

internal readonly record struct FujifilmSdkError(int Result, int ApiCode, int ErrorCode);

internal sealed class FujifilmSdkException : Exception
{
    public FujifilmSdkException(string operation, int result, int apiCode, int errorCode)
        : base($"Fujifilm SDK call '{operation}' failed (Result={result}, ApiCode=0x{apiCode:X}, ErrCode=0x{errorCode:X})")
    {
        Result = result;
        ApiCode = apiCode;
        ErrorCode = errorCode;
    }

    public int Result { get; }
    public int ApiCode { get; }
    public int ErrorCode { get; }
}
