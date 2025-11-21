$dll = Get-ChildItem -Path "c:\Users\scdou\Documents\NINA.Fujifilm.Plugin\src\NINA.Plugins.Fujifilm\bin" -Filter "NINA.Plugins.Fujifilm.dll" -Recurse | Select-Object -First 1
if ($null -eq $dll) {
    Write-Error "Could not find NINA.Plugins.Fujifilm.dll"
    exit 1
}

$sourceDir = $dll.DirectoryName
Write-Host "Found DLL at: $sourceDir"

$target = Join-Path $env:LOCALAPPDATA "NINA\Plugins\Fujifilm"
New-Item -ItemType Directory -Force -Path $target | Out-Null

Write-Host "Deploying to: $target"
# Use /IS (Include Same) to overwrite even if same, and remove /XO (Exclude Older)
robocopy $sourceDir $target /E /IS /NFL /NDL /NJH /NJS

$deployedDll = Join-Path $target "NINA.Plugins.Fujifilm.dll"
if (Test-Path $deployedDll) {
    $version = (Get-Item $deployedDll).VersionInfo.FileVersion
    Write-Host "Deployed Version: $version"
} else {
    Write-Error "Deployment failed: DLL not found at target"
}
