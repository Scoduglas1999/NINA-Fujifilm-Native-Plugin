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
        // Handle lifecycle is now managed by FujifilmInterop via reference counting.
        // We do NOT close the handle here to allow session sharing between Camera and Focuser.
        Handle = IntPtr.Zero;
        return default;
    }
}
