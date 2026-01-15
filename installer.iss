; Inno Setup Script for NINA Fujifilm Plugin
; Download Inno Setup from: https://jrsoftware.org/isdl.php

#define MyAppName "NINA Fujifilm Plugin"
#define MyAppVersion "2.5.0.0"
#define MyAppPublisher "Scdouglas"
#define MyAppURL "https://github.com/scdouglas/NINA.Fujifilm.Plugin"

[Setup]
AppId={{B2F9A3E8-4C7D-4F1A-8E2B-9D6C3A5F2E8B}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={localappdata}\NINA\Plugins\3.0.0\Fujifilm
DisableDirPage=no
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes
OutputDir=.\installer
OutputBaseFilename=NINA_Fujifilm_Plugin_Setup_{#MyAppVersion}
Compression=lzma2/max
SolidCompression=yes
WizardStyle=modern
ArchitecturesAllowed=x64
ArchitecturesInstallIn64BitMode=x64
PrivilegesRequired=lowest
Uninstallable=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Files]
; Main plugin DLL and dependencies
Source: "src\NINA.Plugins.Fujifilm\bin\Release\net8.0-windows\NINA.Plugins.Fujifilm.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "src\NINA.Plugins.Fujifilm\bin\Release\net8.0-windows\NINA.Plugins.Fujifilm.pdb"; DestDir: "{app}"; Flags: ignoreversion

; Copy all other DLLs and dependencies (except NINA ones which should already be in NINA)
Source: "src\NINA.Plugins.Fujifilm\bin\Release\net8.0-windows\*.dll"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist; Excludes: "NINA.*.dll,System.*.dll,Microsoft.*.dll,netstandard.dll"

; Copy the manifest and JSON files
Source: "src\NINA.Plugins.Fujifilm\bin\Release\net8.0-windows\plugin.json"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist
Source: "src\NINA.Plugins.Fujifilm\bin\Release\net8.0-windows\*.json"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist

; Copy the Configuration folder (camera configs)
Source: "src\NINA.Plugins.Fujifilm\bin\Release\net8.0-windows\Configuration\*"; DestDir: "{app}\Configuration"; Flags: ignoreversion recursesubdirs createallsubdirs

; Copy the Interop folder
Source: "src\NINA.Plugins.Fujifilm\bin\Release\net8.0-windows\Interop\*"; DestDir: "{app}\Interop"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"

[Code]
function InitializeSetup(): Boolean;
begin
  Result := True;
  
  // Check if NINA is installed
  if not DirExists(ExpandConstant('{localappdata}\NINA')) then
  begin
    MsgBox('NINA installation not found. Please install NINA first.' + #13#10 + 
           'Expected location: ' + ExpandConstant('{localappdata}\NINA'), 
           mbError, MB_OK);
    Result := False;
  end;
end;

procedure InitializeWizard();
var
  PluginPath: String;
begin
  // Check for NINA 3.0.0 folder first
  PluginPath := ExpandConstant('{localappdata}\NINA\Plugins\3.0.0');
  if DirExists(PluginPath) then
  begin
    WizardForm.DirEdit.Text := PluginPath + '\Fujifilm';
  end;
  // If 3.0.0 doesn't exist, let the user specify the location manually
end;

procedure CurStepChanged(CurStep: TSetupStep);
begin
  if CurStep = ssPostInstall then
  begin
    MsgBox('Installation complete!' + #13#10 + #13#10 +
           'The Fujifilm plugin has been installed to:' + #13#10 +
           ExpandConstant('{app}') + #13#10 + #13#10 +
           'Please restart NINA to load the plugin.', 
           mbInformation, MB_OK);
  end;
end;
