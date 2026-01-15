; Inno Setup Script for Fujifilm Native Camera Plugin for N.I.N.A.
; Version: 2.5.0.0

#define MyAppName "Fujifilm Native Camera Plugin for N.I.N.A."
#define MyAppVersion "2.5.0.0"
#define MyAppPublisher "Scdouglas"
#define MyAppURL "https://github.com/scdouglas/NINA.Fujifilm.Plugin"

[Setup]
AppId={{6E2B5A81-7C8E-4C09-9F2A-4F6A0BC6BB1E}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={localappdata}\NINA\Plugins\3.0.0\Fujifilm
DisableDirPage=yes
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes
OutputDir=..\
OutputBaseFilename=NINA.Fujifilm.Plugin-{#MyAppVersion}-Setup
Compression=lzma2/ultra64
SolidCompression=yes
WizardStyle=modern
PrivilegesRequired=lowest
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
UninstallDisplayIcon={app}\NINA.Plugins.Fujifilm.dll
SetupIconFile=
LicenseFile=
InfoBeforeFile=

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Messages]
WelcomeLabel2=This will install the [name/ver] on your computer.%n%nThis plugin provides native camera support for Fujifilm X-series and GFX cameras in N.I.N.A. (Nighttime Imaging 'N' Astronomy).%n%nSupported cameras include X-T2, X-T3, X-T4, X-T5, X-H2, X-H2S, X-Pro3, X-S20, X-M5, GFX 50S, GFX 50R, GFX 100, GFX 100S, and more.%n%nIMPORTANT: Please close N.I.N.A. before continuing.

[Files]
; Main plugin files
Source: "Fujifilm\NINA.Plugins.Fujifilm.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Fujifilm\NINA.Plugins.Fujifilm.pdb"; DestDir: "{app}"; Flags: ignoreversion

; LibRaw libraries
Source: "Fujifilm\libraw.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Fujifilm\LibRawWrapper.dll"; DestDir: "{app}"; Flags: ignoreversion

; Fujifilm SDK files
Source: "Fujifilm\XAPI.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Fujifilm\XSDK.DAT"; DestDir: "{app}"; Flags: ignoreversion
Source: "Fujifilm\FF0000API.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Fujifilm\FF0001API.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Fujifilm\FF0002API.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Fujifilm\FF0003API.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Fujifilm\FF0004API.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Fujifilm\FF0005API.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Fujifilm\FF0006API.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Fujifilm\FF0007API.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Fujifilm\FF0008API.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Fujifilm\FF0009API.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Fujifilm\FF0010API.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Fujifilm\FF0011API.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Fujifilm\FF0012API.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Fujifilm\FF0013API.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Fujifilm\FF0014API.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Fujifilm\FF0015API.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Fujifilm\FF0016API.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Fujifilm\FF0017API.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Fujifilm\FF0018API.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Fujifilm\FF0019API.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Fujifilm\FF0020API.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Fujifilm\FTLPTP.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Fujifilm\FTLPTPIP.dll"; DestDir: "{app}"; Flags: ignoreversion

; Camera configuration files
Source: "Fujifilm\Configuration\*"; DestDir: "{app}\Configuration"; Flags: ignoreversion recursesubdirs createallsubdirs

; Interop files
Source: "Fujifilm\Interop\*"; DestDir: "{app}\Interop"; Flags: ignoreversion recursesubdirs createallsubdirs

[Code]
function IsNINARunning: Boolean;
var
  ResultCode: Integer;
begin
  Result := False;
  if Exec('tasklist', '/FI "IMAGENAME eq N.I.N.A.exe" /NH', '', SW_HIDE, ewWaitUntilTerminated, ResultCode) then
  begin
    // tasklist returns 0 if process found
    Result := (ResultCode = 0);
  end;
end;

function InitializeSetup(): Boolean;
begin
  Result := True;
  // Check if NINA is running - just warn, don't block
end;

procedure CurStepChanged(CurStep: TSetupStep);
begin
  if CurStep = ssPostInstall then
  begin
    // Installation complete
  end;
end;

[Run]
; No post-install actions needed

[UninstallDelete]
Type: filesandordirs; Name: "{app}"
