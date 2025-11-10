param(
    [Parameter(Mandatory = $true)]
    [string]$OutputPath
)

$target = Join-Path $env:LOCALAPPDATA "NINA\Plugins\Fujifilm"
New-Item -ItemType Directory -Force -Path $target | Out-Null
robocopy $OutputPath $target /E /XO | Out-Null
