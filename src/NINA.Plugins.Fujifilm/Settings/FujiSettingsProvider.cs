using System.ComponentModel.Composition;

namespace NINA.Plugins.Fujifilm.Settings;

[Export(typeof(IFujiSettingsProvider))]
[PartCreationPolicy(CreationPolicy.Shared)]
public sealed class FujiSettingsProvider : IFujiSettingsProvider
{
    [ImportingConstructor]
    public FujiSettingsProvider()
    {
        Settings = new FujiSettings();
    }

    public FujiSettings Settings { get; }

    public void Save()
    {
        // TODO: Persist settings via profile-specific storage.
    }
}
