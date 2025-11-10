# Build & Packaging Plan

## 1. Build Configurations
- **Debug x64** – copies plugin to `%LOCALAPPDATA%\NINA\Plugins\Fujifilm` for rapid testing.
- **Release x64** – produces optimized binaries and packaging artifacts under `dist/`.

## 2. MSBuild Enhancements (`build/Bundle.targets`)
```xml
<Project>
  <PropertyGroup>
    <PublishDir>$(OutputPath)publish\</PublishDir>
    <DistDir>$(MSBuildThisFileDirectory)..\dist\</DistDir>
  </PropertyGroup>

  <Target Name="PreparePublish" AfterTargets="Build">
    <ItemGroup>
      <PublishItems Include="$(TargetPath)" />
      <PublishItems Include="$(TargetDir)plugin.json" />
      <PublishItems Include="$(TargetDir)Interop\Native\**\*" />
      <PublishItems Include="$(TargetDir)Configuration\Assets\CameraConfigs\**\*" />
      <PublishItems Include="$(TargetDir)README.md" Condition="Exists('$(TargetDir)README.md')" />
      <PublishItems Include="$(TargetDir)docs\**\*" Condition="Exists('$(TargetDir)docs')" />
    </ItemGroup>

    <RemoveDir Directories="$(PublishDir)" />
    <MakeDir Directories="$(PublishDir)" />
    <Copy SourceFiles="@(PublishItems)" DestinationFolder="$(PublishDir)%(RecursiveDir)" SkipUnchangedFiles="true" />
  </Target>

  <UsingTask TaskName="CreateZip" TaskFactory="CodeTaskFactory" AssemblyFile="$(MSBuildToolsPath)\Microsoft.Build.Tasks.Core.dll">
    <ParameterGroup>
      <SourceDir ParameterType="System.String" Required="true" />
      <ZipPath ParameterType="System.String" Required="true" />
    </ParameterGroup>
    <Task>
      <Reference Include="System.IO.Compression" />
      <Reference Include="System.IO.Compression.FileSystem" />
      <Using Namespace="System.IO.Compression" />
      <Code Type="Fragment" Language="cs"><![CDATA[
        if (File.Exists(ZipPath)) File.Delete(ZipPath);
        ZipFile.CreateFromDirectory(SourceDir, ZipPath, CompressionLevel.Optimal, false);
      ]]></Code>
    </Task>
  </UsingTask>

  <Target Name="PackagePlugin" AfterTargets="PreparePublish">
    <MakeDir Directories="$(DistDir)" />
    <PropertyGroup>
      <ZipFile>$(DistDir)NINA.Plugins.Fujifilm-v$(VersionSuffix).zip</ZipFile>
    </PropertyGroup>
    <CreateZip SourceDir="$(PublishDir)" ZipPath="$(ZipFile)" />
    <Exec Command="powershell -ExecutionPolicy Bypass -Command \"Get-FileHash -Algorithm SHA256 '$(ZipFile)' | Format-List\"" />
  </Target>
</Project>
```
- `VersionSuffix` read from `build/Version.props` (e.g., `0.1.0`).

## 3. Release Artifact Contents
```
NINA.Plugins.Fujifilm-v0.1.0.zip
 ├── NINA.Plugins.Fujifilm.dll
 ├── plugin.json
 ├── Interop/Native/
 │    ├── XAPI.dll
 │    ├── FF00XXAPI.dll (0..20)
 │    ├── FTLPTP.dll / FTLPTPIP.dll
 │    ├── LibRawWrapper.dll
 │    ├── libraw.dll
 │    └── XSDK.DAT
 ├── Configuration/Assets/CameraConfigs/*.json
 ├── docs/README.md (user-facing)
 ├── docs/THIRD_PARTY.md (licensing notices)
 └── docs/CHANGELOG.md
```

## 4. Signing (Optional)
- If distributing widely, code-sign plugin DLL using organization certificate (Azure SignTool or signtool.exe).
- Document signing process in `docs/release-process.md`.

## 5. Continuous Integration
- Configure GitHub Actions workflow:
  - Restore (`dotnet restore`), build Debug & Release for x64.
  - Run unit tests.
  - Upload release artifact (zip + SHA256).
- Use secret `FUJI_SDK_URL` if SDK redistributables cannot be stored in repo; CI job downloads them and caches.

## 6. Manual Release Checklist
1. Update version in `build/Version.props` and `plugin.json`.
2. Update `docs/CHANGELOG.md` with highlights.
3. Build Release: `msbuild NINA.Plugins.Fujifilm.csproj -p:Configuration=Release -p:Platform=x64`.
4. Verify `dist/` contains zip and SHA256 text.
5. Test install: copy contents of publish folder to clean `%LOCALAPPDATA%\NINA\Plugins\Fujifilm`, launch N.I.N.A., confirm plugin loads.
6. Create GitHub release attaching zip and checksum, include release notes.

## 7. Installer (Future)
- Consider NSIS or WiX bootstrapper to copy files automatically and ensure prerequisites (Fujifilm SDK redistributables) installed.
