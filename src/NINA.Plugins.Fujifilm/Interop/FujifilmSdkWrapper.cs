using System;
using System.Runtime.InteropServices;

namespace NINA.Plugins.Fujifilm.Interop;

internal static class FujifilmSdkWrapper
{
    private const string SdkDllName = "XAPI.dll";

    public const int XSDK_COMPLETE = 0;

    public const int XSDK_DSC_IF_USB = 1;

    public const int XSDK_PRIORITY_PC = 0x0002;

    public const int XSDK_RELEASE_SHOOT_S1OFF = 0x0104;
    public const int XSDK_RELEASE_S1ON = 0x0200;
    public const int XSDK_RELEASE_BULBS2_ON = 0x0500;
    public const int XSDK_RELEASE_N_BULBS1OFF = 0x000C;
    public const int XSDK_SHUTTER_BULB = -1;

    public const int XSDK_DRANGE_100 = 100;

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
    public static extern int XSDK_CapShutterSpeed(IntPtr hCamera, out int plNumShutterSpeed, IntPtr plShutterSpeed, out int plBulbCapable);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_SetShutterSpeed")]
    public static extern int XSDK_SetShutterSpeed(IntPtr hCamera, int lShutterSpeed, int lBulb);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_CapSensitivity")]
    public static extern int XSDK_CapSensitivity(IntPtr hCamera, int lDR, out int plNumSensitivity, IntPtr plSensitivity);

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

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_GetAEMode")]
    public static extern int XSDK_GetAEMode(IntPtr hCamera, out int plAEMode);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_CapFocusPos")]
    public static extern int XSDK_CapFocusPos(IntPtr hCamera, out int plMin, out int plMax, out int plStep);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_GetFocusPos")]
    public static extern int XSDK_GetFocusPos(IntPtr hCamera, out int plFocusPos);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_SetFocusPos")]
    public static extern int XSDK_SetFocusPos(IntPtr hCamera, int lFocusPos);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_SetFocusMode")]
    public static extern int XSDK_SetFocusMode(IntPtr hCamera, int lFocusMode);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_SetFocusOperation")]
    public static extern int XSDK_SetFocusOperation(IntPtr hCamera, int lOperation);

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

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_SetDRange")]
    public static extern int XSDK_SetDRange(IntPtr hCamera, int lDRange);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_GetDRange")]
    public static extern int XSDK_GetDRange(IntPtr hCamera, out int plDRange);

    [DllImport(SdkDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "XSDK_GetErrorNumber")]
    public static extern int XSDK_GetErrorNumber(IntPtr hCamera, out int plAPICode, out int plERRCode);

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
        public IntPtr hCamera;
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
