using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace NINA.Plugins.Fujifilm.Configuration.Loading;

public sealed class CameraModelCatalog : ICameraModelCatalog
{
    private readonly object _sync = new();
    private readonly JsonSerializerOptions _serializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
        AllowTrailingCommas = true
    };

    private IReadOnlyList<CameraConfig> _configs = Array.Empty<CameraConfig>();
    private Dictionary<string, CameraConfig> _lookup = new(StringComparer.OrdinalIgnoreCase);

    public CameraModelCatalog()
    {
        Reload();
    }

    public CameraConfig? TryGetByProductName(string productName)
    {
        if (string.IsNullOrWhiteSpace(productName))
        {
            return null;
        }

        lock (_sync)
        {
            _lookup.TryGetValue(productName.Trim(), out var config);
            if (config != null)
            {
                return config;
            }

            var sanitized = SanitizeModelName(productName);
            _lookup.TryGetValue(sanitized, out config);
            return config;
        }
    }

    public IReadOnlyList<CameraConfig> GetAll()
    {
        lock (_sync)
        {
            return _configs;
        }
    }

    public void Reload()
    {
        lock (_sync)
        {
            var directory = ResolveConfigDirectory();
            if (!Directory.Exists(directory))
            {
                _configs = Array.Empty<CameraConfig>();
                _lookup = new Dictionary<string, CameraConfig>(StringComparer.OrdinalIgnoreCase);
                return;
            }

            var files = Directory.GetFiles(directory, "*.json", SearchOption.TopDirectoryOnly);
            var configs = new List<CameraConfig>(files.Length);
            var lookup = new Dictionary<string, CameraConfig>(StringComparer.OrdinalIgnoreCase);

            foreach (var file in files)
            {
                try
                {
                    using var stream = File.OpenRead(file);
                    var config = JsonSerializer.Deserialize<CameraConfig>(stream, _serializerOptions);
                    if (config == null || string.IsNullOrWhiteSpace(config.ModelName))
                    {
                        continue;
                    }

                    configs.Add(config);
                    var keys = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                    {
                        config.ModelName,
                        SanitizeModelName(config.ModelName)
                    };

                    foreach (var key in keys)
                    {
                        lookup[key] = config;
                    }
                }
                catch
                {
                    // Ignore invalid individual config file for now.
                }
            }

            _configs = configs;
            _lookup = lookup;
        }
    }

    private static string ResolveConfigDirectory()
    {
        var baseDir = AppContext.BaseDirectory;
        return Path.Combine(baseDir, "Configuration", "Assets", "CameraConfigs");
    }

    private static string SanitizeModelName(string name)
    {
        var chars = name.Where(char.IsLetterOrDigit).ToArray();
        return new string(chars);
    }
}
