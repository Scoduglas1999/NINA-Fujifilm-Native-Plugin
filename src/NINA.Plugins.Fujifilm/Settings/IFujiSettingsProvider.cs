namespace NINA.Plugins.Fujifilm.Settings;

public interface IFujiSettingsProvider
{
    FujiSettings Settings { get; }
    void Save();
}
