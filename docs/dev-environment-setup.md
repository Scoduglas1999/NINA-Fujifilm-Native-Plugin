# Development Environment Preparation Guide

This document enumerates the exact steps required to prepare a Windows development environment for the Fujifilm native N.I.N.A. camera plugin.

## 1. Install Prerequisites
1. **Visual Studio 2022 (17.10+)**
   - Workloads: `.NET desktop development`, `Desktop development with C++` (for native SDK headers), `Universal Windows Platform` (optional but recommended).
   - Individual components: `MSVC v143 - VS 2022 C++ x64/x86 build tools`, `.NET 7.0 Runtime`, `.NET 7.0 SDK`, `C# and Visual Basic Roslyn compilers`.
2. **Git for Windows** – enable “Use Git from Windows Command Prompt”.
3. **CMake & Ninja (optional)** – only needed if Fujifilm releases sample native projects.
4. **Fujifilm Camera Control SDK** – install/extract to `C:\SDKs\FujifilmCameraControl`.
5. **LibRaw Wrapper** – copy existing `LibRawWrapper.dll` and dependencies (from ASCOM project) into `C:\SDKs\LibRawWrapper`.
6. **N.I.N.A. 2.1 (or target version)** – install stable release for integration testing.

## 2. Directory Layout
```text
C:\Projects\NINA.Plugins.Fujifilm     # New plugin workspace
C:\Projects\NINA.PluginTemplate       # Clone of template repository
C:\SDKs\FujifilmCameraControl        # Vendor SDK binaries & headers
C:\SDKs\LibRawWrapper                # Existing LibRaw wrapper binaries
```

## 3. Clone Template & Create Solution
```powershell
# 1. Clone template
cd C:\Projects
git clone https://github.com/isbeorn/nina.plugin.template.git NINA.PluginTemplate

# 2. Initialize new repo from template
robocopy NINA.PluginTemplate\NINA.Plugin.Template C:\Projects\NINA.Plugins.Fujifilm /E
cd NINA.Plugins.Fujifilm

# 3. Remove template git history
Remove-Item -Force -Recurse .git

# 4. Initialize new git repository
git init

# 5. Rename solution & projects
Rename-Item NINA.Plugin.Template.sln NINA.Plugins.Fujifilm.sln
Rename-Item NINA.Plugin.Template.csproj NINA.Plugins.Fujifilm.csproj
```

## 4. Update Solution & Project Metadata
1. Open solution in Visual Studio.
2. Replace namespaces and assembly names:
   - Project properties → Application → Assembly name: `NINA.Plugins.Fujifilm`.
   - Default namespace: `NINA.Plugins.Fujifilm`.
3. Update `plugin.json`:
   - Generate new GUID (`Tools > Create GUID`).
   - Set `Name`, `Description`, `Version`, `Entrypoint` (`NINA.Plugins.Fujifilm.Plugin.FujiManifest`).
4. Update `AssemblyInfo.cs` and `Directory.Build.props` to use `NINA.Plugins.Fujifilm` name.
5. Remove unused template wizard project if copied (`NINA.Plugin.Template.Wizard`).

## 5. Configure Build Settings
1. Set solution configuration to `Release` and `Debug` for `x64` only; delete `Any CPU` platform.
2. In project file:
   ```xml
   <PropertyGroup>
     <TargetFramework>net7.0-windows</TargetFramework>
     <Platforms>x64</Platforms>
     <RuntimeIdentifier>win-x64</RuntimeIdentifier>
     <ImplicitUsings>enable</ImplicitUsings>
     <Nullable>enable</Nullable>
   </PropertyGroup>
   ```
3. Add SDK library references:
   ```xml
   <ItemGroup>
     <None Include="Interop\Native\*.dll" CopyToOutputDirectory="PreserveNewest" />
     <None Include="Configuration\Assets\CameraConfigs\*.json" CopyToOutputDirectory="PreserveNewest" />
   </ItemGroup>
   ```
4. Reference N.I.N.A. plugin contracts via NuGet or project reference:
   ```powershell
   dotnet add package NINA.PluginContracts --version 2.1.*
   ```
5. Import packaging targets:
   ```xml
   <Import Project="..\build\Bundle.targets" Condition="Exists('..\build\Bundle.targets')" />
   ```

## 6. Copy Vendor SDK Assets
```powershell
# Create folders
mkdir -p src\NINA.Plugins.Fujifilm\Interop\Native

# Copy Fujifilm SDK redistributables
Copy-Item C:\SDKs\FujifilmCameraControl\Bin\x64\*.dll src\NINA.Plugins.Fujifilm\Interop\Native\
Copy-Item C:\SDKs\FujifilmCameraControl\Bin\x64\XSDK.DAT src\NINA.Plugins.Fujifilm\Interop\Native\

# Copy LibRaw wrapper
Copy-Item C:\SDKs\LibRawWrapper\*.dll src\NINA.Plugins.Fujifilm\Interop\Native\
```

## 7. Enable Post-Build Deployment (Debug)
1. Create `build/PostBuild.ps1` with:
   ```powershell
   param(
     [string]$OutputPath
   )
   $target = "$env:LOCALAPPDATA\NINA\Plugins\Fujifilm"
   New-Item -ItemType Directory -Force -Path $target | Out-Null
   robocopy $OutputPath $target /E /XO
   ```
2. In project file add:
   ```xml
   <Target Name="CopyToNinaDebug" AfterTargets="Build" Condition="'$(Configuration)'=='Debug'">
     <Exec Command="powershell -ExecutionPolicy Bypass -File ..\build\PostBuild.ps1 $(TargetDir)" />
   </Target>
   ```

## 8. Verify Compilation
```powershell
# Restore & build
cd C:\Projects\NINA.Plugins.Fujifilm
nuget restore NINA.Plugins.Fujifilm.sln
msbuild NINA.Plugins.Fujifilm.sln /p:Configuration=Debug /p:Platform=x64
```

## 9. Register Plugin with N.I.N.A.
1. Launch N.I.N.A. once to create `%LOCALAPPDATA%\NINA\Plugins` if it does not exist.
2. Copy debug build (`bin\x64\Debug`) to `%LOCALAPPDATA%\NINA\Plugins\Fujifilm` or rely on post-build script.
3. Open N.I.N.A. → Options → General → Plugins → ensure “Load unsigned plugins” enabled (if needed) → restart N.I.N.A.

## 10. Source Control & CI Preparation
1. Add `.gitignore` entries for `dist/`, `bin/`, `obj/`, `%LOCALAPPDATA%` copies.
2. Optionally configure GitHub Actions using N.I.N.A. template workflow for automated builds.
3. Document environment variables required for CI (e.g., path to Fujifilm SDK redistributed assets if licensing permits).

> **Outcome:** After completing these steps, the developer has a clean Visual Studio solution ready to implement the plugin, with SDK assets staged, build outputs copying to the N.I.N.A. plugin folder, and packaging scripts wired in.
