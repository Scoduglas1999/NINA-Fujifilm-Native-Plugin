using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using NINA.Plugins.Fujifilm.Devices;
using NINA.Plugins.Fujifilm.Diagnostics;

namespace NINA.Plugins.Fujifilm.Settings.Profiles;

/// <summary>
/// Interface for managing camera profiles.
/// </summary>
public interface IProfileManager
{
    /// <summary>
    /// Gets all available profiles.
    /// </summary>
    IReadOnlyList<CameraProfile> Profiles { get; }

    /// <summary>
    /// Gets a profile by its ID.
    /// </summary>
    CameraProfile? GetProfile(Guid id);

    /// <summary>
    /// Gets a profile by its name.
    /// </summary>
    CameraProfile? GetProfileByName(string name);

    /// <summary>
    /// Saves a new profile or updates an existing one.
    /// </summary>
    void SaveProfile(CameraProfile profile);

    /// <summary>
    /// Deletes a profile by its ID.
    /// </summary>
    bool DeleteProfile(Guid id);

    /// <summary>
    /// Creates a new profile from current settings.
    /// </summary>
    CameraProfile CreateFromCurrentSettings(string name, FujiSettings settings, FujiCamera? camera);

    /// <summary>
    /// Applies a profile to the current settings.
    /// </summary>
    void ApplyProfile(CameraProfile profile, FujiSettings settings, FujiCamera? camera);

    /// <summary>
    /// Reloads profiles from disk.
    /// </summary>
    void Reload();
}

/// <summary>
/// Manages saving, loading, and applying camera profiles.
/// </summary>
[Export(typeof(IProfileManager))]
[PartCreationPolicy(CreationPolicy.Shared)]
public sealed class ProfileManager : IProfileManager
{
    private readonly IFujifilmDiagnosticsService _diagnostics;
    private readonly string _profilesPath;
    private readonly List<CameraProfile> _profiles = new();
    private readonly object _lock = new();

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() }
    };

    [ImportingConstructor]
    public ProfileManager(IFujifilmDiagnosticsService diagnostics)
    {
        _diagnostics = diagnostics;

        // Store profiles in the plugin's data directory
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var pluginDataPath = Path.Combine(appDataPath, "NINA", "Plugins", "Fujifilm");
        Directory.CreateDirectory(pluginDataPath);

        _profilesPath = Path.Combine(pluginDataPath, "profiles.json");

        Load();

        // Create default profiles if none exist
        if (_profiles.Count == 0)
        {
            CreateDefaultProfiles();
        }
    }

    /// <inheritdoc/>
    public IReadOnlyList<CameraProfile> Profiles
    {
        get
        {
            lock (_lock)
            {
                return _profiles.ToArray();
            }
        }
    }

    /// <inheritdoc/>
    public CameraProfile? GetProfile(Guid id)
    {
        lock (_lock)
        {
            return _profiles.Find(p => p.Id == id);
        }
    }

    /// <inheritdoc/>
    public CameraProfile? GetProfileByName(string name)
    {
        lock (_lock)
        {
            return _profiles.Find(p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
        }
    }

    /// <inheritdoc/>
    public void SaveProfile(CameraProfile profile)
    {
        if (string.IsNullOrWhiteSpace(profile.Name))
        {
            throw new ArgumentException("Profile name cannot be empty", nameof(profile));
        }

        lock (_lock)
        {
            // Check if this is an update or new profile
            var existingIndex = _profiles.FindIndex(p => p.Id == profile.Id);
            if (existingIndex >= 0)
            {
                profile.ModifiedAt = DateTime.UtcNow;
                _profiles[existingIndex] = profile;
                _diagnostics.RecordEvent("Profiles", $"Updated profile: {profile.Name}");
            }
            else
            {
                profile.CreatedAt = DateTime.UtcNow;
                profile.ModifiedAt = DateTime.UtcNow;
                _profiles.Add(profile);
                _diagnostics.RecordEvent("Profiles", $"Created new profile: {profile.Name}");
            }

            Save();
        }
    }

    /// <inheritdoc/>
    public bool DeleteProfile(Guid id)
    {
        lock (_lock)
        {
            var profile = _profiles.Find(p => p.Id == id);
            if (profile == null)
            {
                return false;
            }

            _profiles.Remove(profile);
            _diagnostics.RecordEvent("Profiles", $"Deleted profile: {profile.Name}");
            Save();
            return true;
        }
    }

    /// <inheritdoc/>
    public CameraProfile CreateFromCurrentSettings(string name, FujiSettings settings, FujiCamera? camera)
    {
        var profile = new CameraProfile
        {
            Name = name,
            PreviewQuality = settings.PreviewDemosaicQuality,
            SaveRafSidecar = settings.SaveNativeRafSidecar,
            EnableExtendedFitsMetadata = settings.EnableExtendedFitsMetadata,
            DriveMode = settings.DriveMode,
            LiveViewQuality = settings.LiveViewQuality,
            LiveViewSize = settings.LiveViewSize
        };

        // Get current ISO from camera if connected
        if (camera != null && camera.IsConnected)
        {
            var caps = camera.GetCapabilitiesSnapshot();
            profile.Iso = caps.DefaultIso;
            profile.DriveMode = camera.GetDriveMode();
        }

        SaveProfile(profile);
        return profile;
    }

    /// <inheritdoc/>
    public void ApplyProfile(CameraProfile profile, FujiSettings settings, FujiCamera? camera)
    {
        _diagnostics.RecordEvent("Profiles", $"Applying profile: {profile.Name}");

        // Apply plugin settings
        settings.PreviewDemosaicQuality = profile.PreviewQuality;
        settings.SaveNativeRafSidecar = profile.SaveRafSidecar;
        settings.EnableExtendedFitsMetadata = profile.EnableExtendedFitsMetadata;
        settings.DriveMode = profile.DriveMode;
        settings.LiveViewQuality = profile.LiveViewQuality;
        settings.LiveViewSize = profile.LiveViewSize;

        // Apply camera settings if connected
        if (camera != null && camera.IsConnected)
        {
            camera.SetDriveMode(profile.DriveMode);
            _diagnostics.RecordEvent("Profiles", $"Applied drive mode: {profile.DriveMode.GetDisplayName()}");
        }

        _diagnostics.RecordEvent("Profiles", $"Profile {profile.Name} applied successfully");
    }

    /// <inheritdoc/>
    public void Reload()
    {
        lock (_lock)
        {
            Load();
        }
    }

    private void Load()
    {
        _profiles.Clear();

        if (!File.Exists(_profilesPath))
        {
            _diagnostics.RecordEvent("Profiles", "No profiles file found, starting fresh");
            return;
        }

        try
        {
            var json = File.ReadAllText(_profilesPath);
            var loadedProfiles = JsonSerializer.Deserialize<List<CameraProfile>>(json, JsonOptions);

            if (loadedProfiles != null)
            {
                _profiles.AddRange(loadedProfiles);
                _diagnostics.RecordEvent("Profiles", $"Loaded {_profiles.Count} profiles from disk");
            }
        }
        catch (Exception ex)
        {
            _diagnostics.RecordEvent("Profiles", $"Error loading profiles: {ex.Message}");
        }
    }

    private void Save()
    {
        try
        {
            var json = JsonSerializer.Serialize(_profiles, JsonOptions);
            File.WriteAllText(_profilesPath, json);
            _diagnostics.RecordEvent("Profiles", $"Saved {_profiles.Count} profiles to disk");
        }
        catch (Exception ex)
        {
            _diagnostics.RecordEvent("Profiles", $"Error saving profiles: {ex.Message}");
        }
    }

    private void CreateDefaultProfiles()
    {
        _diagnostics.RecordEvent("Profiles", "Creating default profiles");

        _profiles.Add(CameraProfile.CreateDeepSkyDefault());
        _profiles.Add(CameraProfile.CreatePlanetaryDefault());
        _profiles.Add(CameraProfile.CreateLunarHdrDefault());

        Save();
    }
}
