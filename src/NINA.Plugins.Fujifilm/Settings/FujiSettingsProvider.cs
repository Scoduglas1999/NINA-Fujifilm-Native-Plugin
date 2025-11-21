using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NINA.Plugins.Fujifilm.Settings;

[Export(typeof(IFujiSettingsProvider))]
[PartCreationPolicy(CreationPolicy.Shared)]
public sealed class FujiSettingsProvider : IFujiSettingsProvider
{
    private static readonly string SettingsFilePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "NINA",
        "Plugins",
        "Fujifilm",
        "settings.json");

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.Never,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    [ImportingConstructor]
    public FujiSettingsProvider()
    {
        try { System.IO.File.AppendAllText(@"c:\Users\scdou\Documents\NINA.Fujifilm.Plugin\debug_log.txt", $"[{DateTime.Now}] FujiSettingsProvider Constructor called\n"); } catch {}
        Settings = LoadSettings();
    }

    public FujiSettings Settings { get; }

    public void Save()
    {
        try
        {
            var directory = Path.GetDirectoryName(SettingsFilePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var json = JsonSerializer.Serialize(Settings, JsonOptions);
            File.WriteAllText(SettingsFilePath, json);
        }
        catch (Exception ex)
        {
            // Log error but don't throw - settings persistence failure shouldn't break the plugin
            System.Diagnostics.Debug.WriteLine($"Failed to save Fujifilm plugin settings: {ex.Message}");
        }
    }

    private static FujiSettings LoadSettings()
    {
        try
        {
            if (File.Exists(SettingsFilePath))
            {
                var json = File.ReadAllText(SettingsFilePath);
                var settings = JsonSerializer.Deserialize<FujiSettings>(json, JsonOptions);
                if (settings != null)
                {
                    return settings;
                }
            }
        }
        catch (Exception ex)
        {
            // Log error but continue with default settings
            System.Diagnostics.Debug.WriteLine($"Failed to load Fujifilm plugin settings: {ex.Message}");
        }

        // Return default settings if loading failed or file doesn't exist
        return new FujiSettings();
    }
}
