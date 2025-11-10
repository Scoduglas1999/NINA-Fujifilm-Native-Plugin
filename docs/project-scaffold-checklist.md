# Project Scaffolding Checklist

Use this checklist after the development environment is ready to instantiate the Fujifilm plugin skeleton.

## 1. Create Solution Skeleton
- [ ] Run the template copy commands from `dev-environment-setup.md`.
- [ ] Confirm `NINA.Plugins.Fujifilm.sln` opens without errors.
- [ ] Delete unused template wizard project (`NINA.Plugin.Template.Wizard`) if present.

## 2. Clean Template Artifacts
- [ ] Replace all occurrences of `NINA.Plugin.Template` in `.sln`, `.csproj`, and source files with `NINA.Plugins.Fujifilm`.
- [ ] Update namespaces via `Edit > Find and Replace > Replace in Files`.
- [ ] Remove sample instruction classes, leaving only base plugin structure.

## 3. Establish Folder Layout
- [ ] Create directories:
  - `src/NINA.Plugins.Fujifilm/Plugin`
  - `src/NINA.Plugins.Fujifilm/Devices`
  - `src/NINA.Plugins.Fujifilm/Configuration/Assets/CameraConfigs`
  - `src/NINA.Plugins.Fujifilm/Interop/Native`
  - `src/NINA.Plugins.Fujifilm/Diagnostics`
  - `src/NINA.Plugins.Fujifilm/Settings`
  - `src/NINA.Plugins.Fujifilm/UI`
  - `src/NINA.Plugins.Fujifilm/Tasks`
- [ ] Add placeholder `.gitkeep` files where directories would otherwise be empty.

## 4. Seed Core Source Files
- [ ] `Plugin/FujiManifest.cs` – copy template manifest, rename class, update GUID placeholder.
- [ ] `Plugin/ServiceCollectionExtensions.cs` – scaffold `AddFujifilmPluginServices()` extension.
- [ ] `Devices/FujiCameraFactory.cs` – insert stub implementing `ICameraFactory` returning `NotImplementedException`.
- [ ] `Devices/FujiCamera.cs` – add shell class implementing `ICamera` with TODO comments referencing `camera-core` task.
- [ ] `Devices/FujiFocuser.cs` – stub implementing `IFocuser` returning `NotImplementedException`.
- [ ] `Configuration/CameraModelCatalog.cs` – stub class returning empty dictionary.
- [ ] `Interop/FujifilmSdkWrapper.cs` – copy structure from ASCOM, wrap with `TODO` markers for validation.
- [ ] `Settings/FujiSettings.cs` and `Settings/FujiSettingsProvider.cs` – stub classes integrating with `ISettingsManager`.
- [ ] `UI/SettingsView.xaml` – minimal WPF layout referencing view model.
- [ ] `UI/SettingsViewModel.cs` – stub deriving from `ObservableObject`.

## 5. Register Dependency Injection
- [ ] In `FujiManifest.RegisterServices`, register stubs with appropriate service lifetimes (scoped for devices, singleton for configuration).
- [ ] Ensure `plugin.json` `Entrypoint` matches manifest class.
- [ ] Add `ISettingsEntry` registration so settings appear in N.I.N.A.'s UI (even if view is placeholder).

## 6. Build Verification
- [ ] Run `dotnet build NINA.Plugins.Fujifilm.csproj -c Debug -p:Platform=x64`.
- [ ] Fix compilation errors introduced by new files (temporarily using `throw new NotImplementedException()` where logic pending).
- [ ] Verify post-build copy script produces plugin folder structure in `%LOCALAPPDATA%\NINA\Plugins\Fujifilm`.

## 7. Source Control Hygiene
- [ ] Stage new files with `git add` and create initial commit (`feat: scaffold Fujifilm plugin skeleton`).
- [ ] Tag commit as baseline for subsequent feature branches (`git tag scaffold-initial`).

> Completing these steps yields a compilable yet non-functional plugin skeleton ready for incremental implementation tasks (`interop-port`, `config-migration`, `camera-core`, etc.).
