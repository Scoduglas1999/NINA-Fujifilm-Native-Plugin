using System;
using System.ComponentModel.Composition;
using NINA.Plugin;
using NINA.Plugin.Interfaces;
using NINA.Plugins.Fujifilm.UI;

namespace NINA.Plugins.Fujifilm.Plugin;

[Export(typeof(IPluginManifest))]
[PartCreationPolicy(CreationPolicy.Shared)]
public sealed class FujiManifest : PluginBase
{
    [Import(AllowDefault = true, AllowRecomposition = true)]
    public SettingsViewModel? Settings { get; set; }

    public FujiManifest()
    {
    }
}
