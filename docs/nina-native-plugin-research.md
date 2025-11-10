# N.I.N.A. Native Camera Plugin Research Notes

## Reference Material Consulted
- N.I.N.A. plugin developer documentation (`https://nighttime-imaging.eu/docs/master/plugins/`).
- `NINA.PluginTemplate` repository structure (solution contains template plugin, plugin wizard, and sample manifest).
- Source layout of built-in native camera modules inside the N.I.N.A. GitHub project (e.g., `src/Camera/ZWO`, `src/Camera/QHY`, `src/Camera/Canon`).
- Community-maintained native camera plugins (Sony/Nikon) which follow the same template conventions.

## Common Project Structure
```
NINA.Plugins.<Vendor>/
 ├── plugin.json                # Manifest consumed by N.I.N.A.'s plugin loader
 ├── NINA.Plugins.<Vendor>.csproj
 ├── src/
 │    ├── Plugin/
 │    │    ├── <Vendor>Manifest.cs    # Implements IPluginManifest, registers services via DI
 │    │    ├── ServiceCollectionExtensions.cs
 │    │    └── StartupTasks.cs (optional bootstrap)
 │    ├── Devices/
 │    │    ├── <Vendor>CameraFactory.cs   # Exports ICameraFactory/ICameraDiscovery
 │    │    ├── <Vendor>Camera.cs          # Implements ICamera, handles lifecycle + imaging
 │    │    ├── <Vendor>Focuser.cs (optional)
 │    │    └── DeviceModels/*             # Model descriptors if required
 │    ├── Interop/
 │    │    ├── SdkWrapper.cs             # P/Invoke / managed SDK adapters
 │    │    └── NativeDlls/ (copy to output)
 │    ├── Configuration/
 │    │    ├── CameraModelCatalog.cs
 │    │    ├── ConfigSchema.cs
 │    │    └── Assets/CameraConfigs/*.json
 │    ├── Diagnostics/
 │    │    ├── LoggerExtensions.cs
 │    │    └── Telemetry.cs
 │    ├── UI/
 │    │    ├── SettingsView.xaml
 │    │    └── SettingsViewModel.cs
 │    └── Properties/Resources.resx
 ├── build/
 │    ├── Bundle.targets                # MSBuild packaging tweaks
 │    └── post-build.ps1 (optional)
 └── README.md / docs/
```

### Manifest (`plugin.json`)
Typical fields:
```json
{
  "Name": "Fuji Native Camera",
  "Version": "0.1.0",
  "Guid": "{GUID}",
  "Author": "...",
  "Description": "Native Fuji X/GFX camera support",
  "MinNinaVersion": "2.1",
  "Entrypoint": "NINA.Plugins.Fujifilm.Plugin.FujiManifest"
}
```

### Bootstrapping
- `FujiManifest` implements `IPluginManifest` from `NINA.Plugin.Interfaces` and registers services through the provided `IServiceCollection`.
- Plugins typically provide `void RegisterServices(IServiceCollection services)` for DI, `void Initialize()` for startup routines, and `Version` metadata.
- Many camera plugins also implement `ISettingsProvider` or register WPF views via `ISettingsEntry` so that settings appear in the N.I.N.A. UI.

### Device Factories & Interfaces
- `ICameraFactory` / `ICameraDiscovery` produce device descriptors and instantiate `ICamera` implementations on connection.
- `ICamera` requires async-friendly methods: `Task Connect(CancellationToken)`, `Task Disconnect()`, `Task Capture(ExposureParameters, CancellationToken)`, plus metadata properties (sensor size, pixel size, gain, etc.).
- Optional interfaces: `ICameraCooling`, `ICameraGain`, `ICameraBinning`, `IBacklashCompensation`, `IExternalTrigger` depending on hardware features.
- N.I.N.A. uses dependency injection for per-camera services; plugin must register transient/singleton lifetimes accordingly.

### Advanced Sequencer Integration
- Native camera plugins automatically surface as camera options; explicit sequencer instructions are rarely required unless vendor SDK exposes special features (e.g., lens warmers). If needed, instructions are exported via MEF attributes (`[Export(typeof(IInstructionDefinition))]`).

### Asset Deployment
- Native camera plugins ship the vendor SDK DLLs alongside the plugin output; MSBuild `<ItemGroup>` with `CopyToOutputDirectory=PreserveNewest` is standard.
- Post-build script copies unmanaged DLLs, config JSON, and documentation to the plugin output folder (`%LOCALAPPDATA%\NINA\Plugins\<PluginName>` during debug).

### Logging & Telemetry
- Plugins leverage `ILoggerFactory` from DI to create category-specific loggers (e.g., `ILogger<FujiCamera>`), writing into N.I.N.A.'s centralized log pipeline.
- Many camera modules expose diagnostic toggles via settings (enable SDK trace, set log level, dump raw buffers).

### UI Requirements
- Provide a WPF `UserControl` for plugin settings (`SettingsView.xaml`) bound to a `SettingsViewModel` registered as singleton.
- Bindings backed by `IPluginSettings` or `ISettingsManager` allow persistence in N.I.N.A.'s configuration store.

### Testing Harness
- Template includes a `NINA.Plugin.Template.TestApp` (optional) or instructs using the main N.I.N.A. application with debug plugin folder.
- Developers typically create a dedicated `plugins.config` during testing to auto-load plugin under development.

## Key Takeaways for Fujifilm Plugin
1. **Solution Layout:** Match template structure to satisfy plugin loader expectations; maintain `src/` hierarchy for clarity.
2. **Manifest & DI:** Ensure manifest GUID and entry point are unique; register camera/focuser factories and configuration services in `FujiManifest`.
3. **Async API Surface:** Implement all required async methods (`Task`-returning) and cancellation patterns to integrate with sequencer timelines.
4. **Settings & Diagnostics:** Provide configuration UI, logging hooks, and developer toggles mirroring other native camera plugins.
5. **Packaging:** Bundle Fujifilm SDK DLLs, LibRaw wrapper, and camera JSON assets via MSBuild scripts consistent with other vendors.
