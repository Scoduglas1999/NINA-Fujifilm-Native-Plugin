using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace NINA.Plugins.Fujifilm.Interop.Native;

public sealed class FujifilmCameraSession : IAsyncDisposable
{
    internal FujifilmCameraSession(IntPtr handle, string deviceId)
    {
        Handle = handle;
        DeviceId = deviceId;
    }

    public IntPtr Handle { get; internal set; }
    public string DeviceId { get; }

    public ValueTask DisposeAsync()
    {
        if (Handle != IntPtr.Zero)
        {
            FujifilmSdkWrapper.XSDK_Close(Handle);
            Handle = IntPtr.Zero;
        }

        return default;
    }
}
