# Test script to verify X-Trans FITS metadata compatibility with PixInsight
# This simulates what metadata would be written for an X-Trans camera

Write-Host "=== NINA Fujifilm Plugin - X-Trans Metadata Test ===" -ForegroundColor Cyan
Write-Host ""

# Simulate the current metadata generation for X-Trans cameras
$XTransMetadata = @{
    # What the plugin CURRENTLY writes:
    "BAYERPAT" = "RGGB"           # Problem: PixInsight sees this as standard Bayer
    "XTNSPAT"  = "XTRANS"         # Custom keyword - PixInsight doesn't recognize this
    "CFAAXIS"  = "2x2"            # Wrong for X-Trans (should be 6x6)
    "CFA"      = "1"
    "INSTRUME" = "X-T5"
    "SENSOR"   = "X-Trans CMOS"
}

Write-Host "Current Plugin Metadata (PROBLEMATIC):" -ForegroundColor Yellow
$XTransMetadata.GetEnumerator() | ForEach-Object { 
    Write-Host "  $($_.Key) = $($_.Value)" 
}

Write-Host ""
Write-Host "PixInsight Interpretation: Standard RGGB Bayer (2x2)" -ForegroundColor Red
Write-Host "Result: INCORRECT debayering - data already processed" -ForegroundColor Red

Write-Host ""
Write-Host "==========================================" -ForegroundColor Cyan
Write-Host ""

# What PixInsight ACTUALLY needs for real X-Trans
# The real X-Trans II pattern (Fuji X-T2 onwards)
$XTransPattern = "GGRGGBGGBGGRBRGRBGGGBGGRGGRGGBRBGBRG"

$CorrectMetadata = @{
    # What would be CORRECT for raw X-Trans data:
    "BAYERPAT" = $XTransPattern   # Full 36-char X-Trans pattern
    "CFAAXIS"  = "6x6"            # X-Trans is 6x6
    "CFA"      = "1"
    "INSTRUME" = "X-T5"
    "SENSOR"   = "X-Trans CMOS"
}

Write-Host "What PixInsight NEEDS for Real X-Trans:" -ForegroundColor Green
$CorrectMetadata.GetEnumerator() | ForEach-Object { 
    Write-Host "  $($_.Key) = $($_.Value)" 
}

Write-Host ""
Write-Host "==========================================" -ForegroundColor Cyan
Write-Host ""

Write-Host "CONCLUSION:" -ForegroundColor Magenta
Write-Host ""
Write-Host "The current implementation saves PROCESSED data (synthetic RGGB)," -ForegroundColor White
Write-Host "not raw X-Trans sensor data. This means:" -ForegroundColor White
Write-Host ""
Write-Host "  1. PixInsight cannot properly calibrate/debayer the data" -ForegroundColor Yellow
Write-Host "  2. The unique X-Trans pattern advantages are lost" -ForegroundColor Yellow
Write-Host "  3. Raw calibration workflows won't work correctly" -ForegroundColor Yellow
Write-Host ""
Write-Host "RECOMMENDATION:" -ForegroundColor Cyan
Write-Host "  Enable 'Save native RAF sidecar' in plugin settings" -ForegroundColor Green
Write-Host "  Use RAF files for stacking in PixInsight" -ForegroundColor Green
Write-Host "  Or consider making RAF the DEFAULT for X-Trans cameras" -ForegroundColor Green
