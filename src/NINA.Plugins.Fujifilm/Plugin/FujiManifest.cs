using System.ComponentModel.Composition;
using NINA.Plugin;
using NINA.Plugin.Interfaces;
using NINA.Plugins.Fujifilm.UI;

namespace NINA.Plugins.Fujifilm.Plugin;

[Export(typeof(IPluginManifest))]
[PartCreationPolicy(CreationPolicy.Shared)]
public sealed class FujiManifest : PluginBase
{
    public SettingsViewModel Settings { get; }

    [ImportingConstructor]
    public FujiManifest(SettingsViewModel settingsViewModel)
    {
        Settings = settingsViewModel;
    }
}
