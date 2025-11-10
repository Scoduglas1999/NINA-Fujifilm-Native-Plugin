using System.Collections.Generic;

namespace NINA.Plugins.Fujifilm.Configuration.Loading;

public interface ICameraModelCatalog
{
    CameraConfig? TryGetByProductName(string productName);
    IReadOnlyList<CameraConfig> GetAll();
    void Reload();
}
