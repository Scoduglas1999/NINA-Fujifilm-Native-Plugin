using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NINA.Equipment.Interfaces;

namespace NINA.Plugins.Fujifilm.Devices;

public interface IFujiCameraFactory
{
    Task<IReadOnlyList<FujifilmCameraDescriptor>> GetAvailableCamerasAsync(CancellationToken cancellationToken);
    FujiCamera CreateCamera();
    ICamera CreateGenericCamera(FujifilmCameraDescriptor descriptor);
    Task<FujiCameraCapabilities> GetCapabilitiesAsync(FujifilmCameraDescriptor descriptor, CancellationToken cancellationToken);
}

public sealed record FujifilmCameraDescriptor(string DisplayName, string DeviceId);
