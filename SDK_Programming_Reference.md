**FUJIFILM X Series/GFX System**

# Digital Camera Control Software Development Kit

# 1. 33

# API Reference

# Revision 1. 33 .0. 0

# Mar. 20 , 2025

# FUJIFILM Corporation

## THIS DOCUMENT IS FURNISHED ON AN “AS IS” BASIS WITHOUT

## WARRANTY OF ANY KIND, EXPRESS OR IMPLIED.

## FUJIFILM MAKES NO REPRESENTATION OR WARRANTIES.

```
Copyright© 2014- 2025 FUJIFILM Corporation.
```

## Table of Contents


















- FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0.
            -
- 1. INTRODUCTION
   - 1.1. COMPATIBLE OPERATING SYSTEMS
      - 1.1.1. Windows
      - 1.1.2. macOS
      - 1.1.3. Linux
      - 1.1.4. Android
   - 1.2. SUPPORTED CAMERAS
      - 1.2.1. USB Connection Support
      - 1.2.2. Wi-Fi Connection Support
   - 1.3. LIMITATIONS
   - 1.4. REDISTRIBUTABLE FILES
      - 1.4.1. Windows Version (32 bit libraries)
      - 1.4.1. Windows Version (64 bit libraries)
      - 1.4.2. macOS Version
      - 1.4.1. Linux Version (Linux® 64bit (ARMv8)))
      - 1.4.2. Linux Version (Linux® 32bit (ARMv7))
      - 1.4.3. Linux Version (Linux® 64bit (x64) )
      - 1.4.4. Android Version
   - 1.5. STORAGE MODEL
   - 1.6. BASIC POLICIES FOR X/GFX CAMERA BEHAVIOR
   - 1.7. CAMERA PRIORITY MODE / PC PRIORITY MODE
   - 1.8. CONTROLS RELATED TO MOVIE RECORDING
- 2. STATE DIAGRAM
- 3. API OVERVIEW
   - 3.1. COMMON APIS (MANDATORY FUNCTIONS)
   - 3.2. MODEL DEPENDENT APIS (OPTIONAL FUNCTIONS)............................................................................................................
- 4. API REFERENCE
   - 4.1. COMMON APIS (MANDATORY FUNCTIONS)
      - 4.1.1. Initialize / Finalize
         - 4.1.1.1. XSDK_Init
         - 4.1.1.2. XSDK_Exit
      - 4.1.2. Enumeration
         - 4.1.2.1. XSDK_Detect
         - 4.1.2.2. XSDK_Append
      - 4.1.3. Session Management
         - 4.1.3.1. XSDK_OpenEx
         - 4.1.3.2. XSDK_SetUSBDeviceHandle
- FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0.
         -
      - 4.1.3.3. XSDK_Close
      - 4 .1.3.4. XSDK_PowerOFF
   - 4.1.4. Basic Functions
      - 4.1.4.1. XSDK_GetErrorNumber
      - 4.1.4.2. XSDK_GetErrorDetails
      - 4.1.4.3. XSDK_GetVersionString
   - 4.1.5. Device Information
      - 4.1.5.1. XSDK_GetDeviceInfo
      - 4.1.5.2. XSDK_GetDeviceInfoEx
      - 4.1.5.3. XSDK_WriteDeviceName
      - 4.1.5.4. XSDK_GetFirmwareVersion
      - 4.1.5.5. XSDK_GetLensInfo
      - 4.1.5.6. XSDK_GetLensVersion
   - 4.1.6. Camera Operation Mode
      - 4.1.6.1. XSDK_CapPriorityMode
      - 4.1.6.2. XSDK_SetPriorityMode
      - 4.1.6.3. XSDK_GetPriorityMode
      - 4.1.6.4. XSDK_CapDriveMode
      - 4.1.6.5. XSDK_SetDriveMode
      - 4.1.6.6. XSDK_GetDriveMode
      - 4.1.6.7. XSDK_CapMode
      - 4.1.6.8. XSDK_SetMode
      - 4.1.6.9. XSDK_GetMode
   - 4.1.7. Release Control
      - 4.1.7.1. XSDK_CapRelease
      - 4.1.7.2. XSDK_Release
      - 4.1.7.3. XSDK_CapReleaseEx
      - 4.1.7.4. XSDK_ReleaseEx
      - 4.1.7.5. XSDK_GetReleaseStatus
   - 4.1.8. Image Acquisition
      - 4.1.8.1. XSDK_ReadImageInfo
      - 4.1.8.2. XSDK_ReadPreview
      - 4.1.8.3. XSDK_ReadImage
      - 4.1.8.4. XSDK_DeleteImage
      - 4.1.8.5. XSDK_GetBufferCapacity
   - 4.1.9. Exposure Control
      - 4.1.9.1. XSDK_CapAEMode
      - 4.1.9.2. XSDK_SetAEMode
      - 4.1.9.3. XSDK_GetAEMode
      - 4.1.9.4. XSDK_CapShutterSpeed
- FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0.
         -
      - 4.1.9.5. XSDK_SetShutterSpeed
      - 4.1.9.6. XSDK_GetShutterSpeed
      - 4.1.9.7. XSDK_CapExposureBias
      - 4.1.9.8. XSDK_SetExposureBias
      - 4.1.9.9. XSDK_GetExposureBias
      - 4.1.9.10. XSDK_CapDynamicRange
      - 4.1.9.11. XSDK_SetDynamicRange
      - 4.1.9.12. XSDK_GetDynamicRange
      - 4.1.9.13. XSDK_CapSensitivity
      - 4.1.9.14. XSDK_SetSensitivity
      - 4.1.9.15. XSDK_GetSensitivity
      - 4.1.9.16. XSDK_CapMeteringMode
      - 4.1.9.17. XSDK_SetMeteringMode
      - 4.1.9.18. XSDK_GetMeteringMode
      - 4.1.9.19. XSDK_CapLensZoomPos
      - 4.1.9.20. XSDK_SetLensZoomPos
      - 4.1.9.21. XSDK_GetLensZoomPos
      - 4.1.9.22. XSDK_CapAperture
      - 4.1.9.23. XSDK_SetAperture
      - 4.1.9.24. XSDK_GetAperture
   - 4.1.10. White Balance Control
      - 4.1.10.1. XSDK_CapWBMode.....................................................................................................................................................
      - 4.1.10.2. XSDK_SetWBMode
      - 4.1.10.3. XSDK_GetWBMode
      - 4.1.10.4. XSDK_CapWBColorTemp
      - 4.1.10.5. XSDK_SetWBColotTemp
      - 4.1.10.6. GetWBColorTemp
   - 4.1.11. Media Recording Control
      - 4.1.11.1. XSDK_CapMediaRecord
      - 4.1.11.2. XSDK_SetMediaRecord
      - 4.1.11.3. XSDK_GetMediaRecord
   - 4.1.12. Operation Mode Control
      - 4.1.12.1. XSDK_CapForceMode
      - 4.1.12.2. XSDK_SetForceMode
   - 4.1.13. Backup/Retore Settings
      - 4.1.13.1. XSDK_SetBackupSettings
      - 4.1.13.2. XSDK_GetBackupSettings
   - 4.1.14. Movie Control
      - 4.1.14.1. XSDK_CapMovieShutterSpeed
      - 4.1.14.2. XSDK_SetMovieShutterSpeed
- FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0.
            -
         - 4.1.14.3. XSDK_GetMovieShutterSpeed
         - 4.1.14.4. XSDK_CapMovieExposureBias
         - 4.1.14.5. XSDK_SetMovieExposureBias
         - 4.1.14.6. XSDK_GetMovieExposureBias
         - 4.1.14.7. XSDK_CapMovieSensitivity
         - 4.1.14.8. XSDK_SetMovieSensitivity
         - 4.1.14.9. XSDK_GetMovieSensitivity
         - 4.1.14.10. XSDK_CapMovieAperture
         - 4.1.14.11. XSDK_SetMovieAperture
         - 4.1.14.12. XSDK_GetMovieAperture
         - 4.1.14.13. XSDK_ CapMovieDynamicRange
         - 4.1.14.14. XSDK_ SetMovieDynamicRange
         - 4.1.14.15. XSDK_ GetMovieDynamicRange
         - 4.1.14.16. XSDK_ CapMovieMeteringMode
         - 4.1.14.17. XSDK_ SetMovieMeteringMode
         - 4.1.14.18. XSDK_ GetMovieMeteringMode
         - 4.1.14.19. XSDK_CapMovieWBMode
         - 4.1.14.20. XSDK_SetMovieWBMode
         - 4.1.14.21. XSDK_GetMovieWBMode
         - 4.1.14.22. XSDK_CapMovieWBColorTemp
         - 4.1.14.23. XSDK_SetMovieWBColotTemp
         - 4.1.14.24. GetMovieWBColorTemp
      - 4.1.15. Optional Model-Dependent Function Interface
         - 4.1.15.1. XSDK_CapProp
         - 4.1.15.2. XSDK_SetProp
         - 4.1.15.3. XSDK_GetProp
   - 4.2. MODEL DEPENDENT APIS (OPTIONAL FUNCTIONS)..........................................................................................................
      - 4.2.1. Focus Control
         - 4.2.1.1. CapFocusMode
         - 4.2.1.2. SetFocusMode
         - 4.2.1.3. GetFocusMode
         - 4.2.1.4. CapAFMode
         - 4.2.1.5. SetAFMode
         - 4.2.1.6. GetAFMode
         - 4.2.1.7. CapFocusArea
         - 4.2.1.8. SetFocusArea
         - 4.2.1.9. GetFocusArea
         - 4.2.1.10. CapShutterPriorityMode
         - 4.2.1.11. SetShutterPriorityMode
         - 4.2.1.12. GetShutterPriorityMode
- FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0.
      -
   - 4.2.1.13. CapFaceDetectionMode..............................................................................................................................................
   - 4.2.1.14. SetFaceDetectionMode...............................................................................................................................................
   - 4.2.1.15. GetFaceDetectionMode
   - 4.2.1.16. CapEyeAFMode
   - 4.2.1.17. SetEyeAFMode
   - 4.2.1.18. GetEyeAFMode
   - 4.2.1.19. CapSubjectDetectionMode
   - 4.2.1.20. SetSubjectDetectionMode
   - 4.2.1.21. GetSubjectDetectionMode
   - 4.2.1.22. CapFullTimeManualFocus
   - 4.2.1.23. SetFullTimeManualFocus
   - 4.2.1.24. GetFullTimeManualFocus
   - 4.2.1.1. CapFocusPoints
   - 4.2.1.1. SetFocusPoints
   - 4.2.1.2. GetFocusPoints
   - 4.2.1.3. CapInstantAFMode
   - 4.2.1.4. SetInstantAFMode
   - 4.2.1.5. GetInstantAFMode
   - 4.2.1.6. CapPreAFMode
   - 4.2.1.7. SetPreAFMode
   - 4.2.1.8. GetPreAFMode
   - 4.2.1.9. CapAFIlluminator
   - 4.2.1.10. SetAFIlluminator
   - 4.2.1.11. GetAFIlluminator.........................................................................................................................................................
   - 4.2.1.12. CapFocusPos
   - 4.2.1.13. SetFocusPos
   - 4.2.1.14. GetFocusPos................................................................................................................................................................
   - 4.2.1.15. CapFocusLimiterPos
   - 4.2.1.16. SetFocusLimiterPos
   - 4.2.1.17. GetFocusLimiterIndicator
   - 4.2.1.18. GetFocusLimiterRange
   - 4.2.1.19. CapFocusLimiterMode
   - 4.2.1.20. SetFocusLimiterMode
   - 4.2.1.21. GetFocusLimiterMode
   - 4.2.1.22. CapFocusSpeed
   - 4.2.1.23. SetFocusSpeed
   - 4.2.1.24. GetFocusSpeed
   - 4.2.1.25. CapFocusOperation
   - 4.2.1.26. SetFocusOperation
   - 4.2.1.27. CapAFZoneCustom
- FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0.
         -
      - 4.2.1.28. SetAFZoneCustom
      - 4.2.1.29. GetAFZoneCustom
   - 4.2.2. Crop Control
      - 4.2.2.1. CapCropMode
      - 4.2.2.2. SetCropMode
      - 4.2.2.3. GetCropMode
      - 4.2.2.4. CapCropZoom
      - 4.2.2.5. SetCropZoom
      - 4.2.2.6. GetCropZoom
   - 4.2.3. Zoom Control
      - 4.2.3.1. CapZoomSpeed
      - 4.2.3.2. SetZoomSpeed
      - 4.2.3.3. GetZoomSpeed
      - 4.2.3.4. CapZoomOperation
      - 4.2.3.5. SetZoomOperation
   - 4.2.4. Exposure Control
      - 4.2.4.1. CapInterlockAEAFArea
      - 4.2.4.2. SetInterlockAEAFArea
      - 4.2.4.3. GetInterlockAEAFArea
      - 4.2.4.4. CapHighFrequencyFlickerlessMode
      - 4.2.4.5. SetHighFrequencyFlickerlessMode
      - 4.2.4.6. GetHighFrequencyFlickerlessMode
   - 4.2.5. Image Size / Quality...........................................................................................................................................
      - 4.2.5.1. CapImageSize
      - 4.2.5.2. SetImageSize
      - 4.2.5.3. GetImageSize
      - 4.2.5.4. CapImageQuality
      - 4.2.5.5. SetImageQuality..........................................................................................................................................................
      - 4.2.5.6. GetImageQuality
      - 4.2.5.7. CapRAWCompression
      - 4.2.5.8. SetRAWCompression
      - 4.2.5.9. GetRAWCompression
      - 4.2.5.10. SetRAWOutputDepth
      - 4.2.5.11. GetRAWOutputDepth
   - 4.2.6. White Balance
      - 4.2.6.1. CapWhiteBalanceTune
      - 4.2.6.2. SetWhiteBalanceTune
      - 4.2.6.3. GetWhiteBalanceTune
   - 4.2.7. Film Simulation
      - 4.2.7.1. CapFilmSimulationMode
- FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0.
         -
      - 4.2.7.2. SetFilmSimulationMode
      - 4.2.7.3. GetFilmSimulationMode
      - 4.2.7.4. CapGrainEffect
      - 4.2.7.5. SetGrainEffect
      - 4.2.7.6. GetGrainEffect
      - 4.2.7.7. CapMonochromaticColor
      - 4.2.7.8. SetMonochromaticColor
      - 4.2.7.9. GetMonochromaticColor
   - 4.2.8. Image Quality Control
      - 4.2.8.1. CapSharpness
      - 4.2.8.2. SetSharpness
      - 4.2.8.3. GetSharpness
      - 4.2.8.4. CapColorMode
      - 4.2.8.5. SetColorMode
      - 4.2.8.6. GetColorMode
      - 4.2.8.7. CapHighLightTone
      - 4.2.8.8. SetHighLightTone
      - 4.2.8.9. GetHighLightTone
      - 4.2.8.10. CapShadowTone
      - 4.2.8.11. SetShadowTone
      - 4.2.8.12. GetShadowTone
      - 4.2.8.13. CapShadowing
      - 4.2.8.14. SetShadowing
      - 4.2.8.15. GetShadowing
      - 4.2.8.16. CapWideDynamicRange
      - 4.2.8.17. SetWideDynamicRange
      - 4.2.8.18. GetWideDynamicRange
      - 4.2.8.19. CapColorChromeBlue
      - 4.2.8.20. SetColorChromeBlue
      - 4.2.8.21. GetColorChromeBlue
      - 4.2.8.22. CapClarityMode
      - 4.2.8.23. SetClarityMode
      - 4.2.8.24. GetClarityMode
      - 4.2.8.25. SetSmoothSkinEffect
      - 4.2.8.26. GetSmoothSkinEffect
      - 4.2.8.27. CapNoiseReduction
      - 4.2.8.28. SetNoiseReduction
      - 4.2.8.29. GetNoiseReduction
      - 4.2.8.30. CapLMOMode
      - 4.2.8.31. SetLMOMode
- FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0.
         -
      - 4.2.8.32. GetLMOMode
      - 4.2.8.33. CapLongExposureNR
      - 4.2.8.34. SetLongExposureNR
      - 4.2.8.35. GetLongExposureNR
      - 4.2.8.36. CapPortraitEnhancer
      - 4.2.8.37. SetPortraitEnhancer
      - 4.2.8.38. GetPortraitEnhancer
   - 4.2.9. Self Timer
      - 4.2.9.1. CapCaptureDelay
      - 4.2.9.2. SetCaptureDelay
      - 4.2.9.3. GetCaptureDelay
   - 4.2.10. SET-UP
      - 4.2.10.1. SetDateTime
      - 4.2.10.2. GetDateTime
      - 4.2.10.3. SetDateTimeDispFormat
      - 4.2.10.4. GetDateTimeDispFormat
      - 4.2.10.5. CapWorldClock
      - 4.2.10.6. SetWorldClock
      - 4.2.10.7. GetWorldClock
      - 4.2.10.8. CapTimeDifference
      - 4.2.10.9. SetTimeDifference
      - 4.2.10.10. GetTimeDifference
      - 4.2.10.11. CapSummerTime
      - 4.2.10.12. SetSummerTime
      - 4.2.10.13. GetSummerTime
      - 4.2.10.14. CapResetSetting
      - 4.2.10.15. ResetSetting
      - 4.2.10.16. CapExposurePreview
      - 4.2.10.17. SetDispMMode / SetExposurePreview
      - 4.2.10.18. GetDispMMode / GetExposurePreview
      - 4.2.10.19. CapFrameGuideMode
      - 4.2.10.20. SetFrameGuideMode
      - 4.2.10.21. GetFrameGuideMode
      - 4.2.10.22. SetFrameGuideGridInfo
      - 4.2.10.23. GetFrameGuideGridInfo..............................................................................................................................................
      - 4.2.10.24. CapFocusScaleUnit
      - 4.2.10.25. SetFocusScaleUnit
      - 4.2.10.26. GetFocusScaleUnit
      - 4.2.10.27. SetFilenamePrefix
      - 4.2.10.28. GetFilenamePrefix
- FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0.
         -
      - 4.2.10.29. CapLockButtonMode
      - 4.2.10.30. SetLockButtonMode
      - 4.2.10.31. GetLockButtonMode
      - 4.2.10.32. CapColorSpace
      - 4.2.10.33. SetColorSpace
      - 4.2.10.34. GetColorSpace
      - 4.2.10.35. CapFunctionLock
      - 4.2.10.36. SetFunctionLock
      - 4.2.10.37. GetFunctionLock
      - 4.2.10.38. CapFunctionLockCategory
      - 4.2.10.39. SetFunctionLockCategory
      - 4.2.10.40. GetFunctionLockCategory
      - 4.2.10.41. CapFormatMemoryCard
      - 4.2.10.42. FormatMemoryCard
      - 4.2.10.43. CapCustomDispInfo.....................................................................................................................................................
      - 4.2.10.44. SetCustomDispInfo......................................................................................................................................................
      - 4.2.10.45. GetCustomDispInfo
      - 4.2.10.46. GetTransparentFrameInfo
      - 4.2.10.47. CapMaskSetting
      - 4.2.10.48. SetMaskSetting
      - 4.2.10.49. GetMaskSetting
   - 4.2.11. Image Stabilization
      - 4.2.11.1. CapLensISSwitch
      - 4.2.11.2. SetLensISSwitch
      - 4.2.11.3. GetLensISSwitch
      - 4.2.11.4. CapISMode
      - 4.2.11.5. SetISMode
      - 4.2.11.6. GetISMode
   - 4.2.12. Save Image Meta-tag Information
      - 4.2.12.1. SetComment
      - 4.2.12.2. GetComment
      - 4.2.12.3. SetCopyright
      - 4.2.12.4. GetCopyright
   - 4.2.13. Camera Information
      - 4.2.13.1. CheckBatteryInfo
      - 4.2.13.2. GetShutterCount
      - 4.2.13.3. GetShutterCountEx
      - 4.2.13.4. GetTiltShiftLensStatus
   - 4.2.14. Media Control
      - 4.2.14.1. GetMediaCapacity
- FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0.
         -
      - 4.2.14.2. GetMediaStatus
   - 4.2.15. Display Control
      - 4.2.15.1. CapMFAssistMode
      - 4.2.15.2. SetMFAssistMode
      - 4.2.15.3. GetMFAssistMode
      - 4.2.15.4. CapFocusCheckMode
      - 4.2.15.5. SetFocusCheckMode
      - 4.2.15.6. GetFocusCheckMode
      - 4.2.15.7. CapViewMode.............................................................................................................................................................
      - 4.2.15.8. SetViewMode..............................................................................................................................................................
      - 4.2.15.9. GetViewMode
   - 4.2.16. Live View
      - 4.2.16.1. StartLiveView
      - 4.2.16.2. StopLiveView
      - 4.2.16.3. CapLiveViewImageQuality
      - 4.2.16.4. SetLiveViewImageQuality
      - 4.2.16.5. GetLiveViewImageQuality
      - 4.2.16.6. CapLiveViewImageSize
      - 4.2.16.7. SetLiveViewImageSize
      - 4.2.16.8. GetLiveViewImageSize
      - 4.2.16.9. CapThroughImageZoom
      - 4.2.16.10. SetThroughImageZoom
      - 4.2.16.11. GetThroughImageZoom
      - 4.2.16.12. GetLiveViewStatus
   - 4.2.17. Movie Control – MOVIE SETTING
      - 4.2.17.1. CapMovieImageFormat
      - 4.2.17.2. SetMovieImageFormat
      - 4.2.17.3. GetMovieImageFormat
      - 4.2.17.4. CapAnamorphicDesqueezeDisplay
      - 4.2.17.5. SetAnamorphicDesqueezeDisplay
      - 4.2.17.6. GetAnamorphicDesqueezeDisplay
      - 4.2.17.7. CapAnamorphicMagnification
      - 4.2.17.8. SetAnamorphicMagnification
      - 4.2.17.9. GetAnamorphicMagnification
      - 4.2.17.10. CapMovieResolution
      - 4.2.17.11. SetMovieResolution
      - 4.2.17.12. GetMovieResolution
      - 4.2.17.13. CapMovieFrameRate
      - 4.2.17.14. SetMovieFrameRate
      - 4.2.17.15. GetMovieFrameRate
- FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0.
      -
   - 4.2.17.16. CapHighSpeedRecMode..............................................................................................................................................
   - 4.2.17.17. SetHighSpeedRecMode...............................................................................................................................................
   - 4.2.17.18. GetHighSpeedRecMode
   - 4.2.17.19. CapHighSpeedRecResolution
   - 4.2.17.20. SetHighSpeedRecResolution
   - 4.2.17.21. GetHighSpeedRecResolution
   - 4.2.17.22. CapHighSpeedRecFrameRate
   - 4.2.17.23. SetHighSpeedRecFrameRate
   - 4.2.17.24. GetHighSpeedRecFrameRate
   - 4.2.17.25. CapHighSpeedRecPlayBackFrameRate
   - 4.2.17.26. SetHighSpeedRecPlayBackFrameRate
   - 4.2.17.27. GetHighSpeedRecPlayBackFrameRate
   - 4.2.17.28. CapMovieCaptureDelay
   - 4.2.17.29. SetMovieCaptureDelay
   - 4.2.17.30. GetMovieCaptureDelay...............................................................................................................................................
   - 4.2.17.31. CapMovieMediaRecord
   - 4.2.17.32. SetMovieMediaRecord
   - 4.2.17.33. GetMovieMediaRecord
   - 4.2.17.34. CapMovieBitRate
   - 4.2.17.35. SetMovieBitRate
   - 4.2.17.36. GetMovieBitRate.........................................................................................................................................................
   - 4.2.17.37. CapMovieFileFormat
   - 4.2.17.38. SetMovieFileFormat
   - 4.2.17.39. GetMovieFileFormat
   - 4.2.17.40. CapMovieMediaRecordProRes
   - 4.2.17.41. SetMovieMediaRecordProRes
   - 4.2.17.42. GetMovieMediaRecordProRes
   - 4.2.17.43. GetMediaEjectWarning
   - 4.2.17.44. CapMovieHDMIOutputInfoDisplay
   - 4.2.17.45. SetMovieHDMIOutputInfoDisplay
   - 4.2.17.46. GetMovieHDMIOutputInfoDisplay
   - 4.2.17.47. CapMovieHDMIRecControl
   - 4.2.17.48. SetMovieHDMIRecControl
   - 4.2.17.49. GetMovieHDMIRecControl
   - 4.2.17.50. CapMovieHDMIOutputRAW
   - 4.2.17.51. SetMovieHDMIOutputRAW
   - 4.2.17.52. GetMovieHDMIOutputRAW
   - 4.2.17.53. CapMovieHDMIOutputRAWResolution
   - 4.2.17.54. SetMovieHDMIOutputRAWResolution
   - 4.2.17.55. GetMovieHDMIOutputRAWResolution
- FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0.
      -
   - 4.2.17.56. CapMovieHDMIOutputRAWFrameRate
   - 4.2.17.57. SetMovieHDMIOutputRAWFrameRate
   - 4.2.17.58. GetMovieHDMIOutputRAWFrameRate
   - 4.2.17.59. CapMovieCropMagnification
   - 4.2.17.60. SetMovieCropMagnification
   - 4.2.17.61. GetMovieCropMagnification
   - 4.2.17.62. GetMovieCropMagnificationValue
   - 4.2.17.63. CapFlogRecording
   - 4.2.17.64. SetFlogRecording
   - 4.2.17.65. GetFlogRecording
   - 4.2.17.66. CapMovieDataLevelSetting
   - 4.2.17.67. SetMovieDataLevelSetting
   - 4.2.17.68. GetMovieDataLevelSetting
   - 4.2.17.69. CapMovieHighFrequencyFlickerlessMode
   - 4.2.17.70. SetMovieHighFrequencyFlickerlessMode
   - 4.2.17.71. GetMovieHighFrequencyFlickerlessMode
   - 4.2.17.72. CapMovieIsMode
   - 4.2.17.73. SetMovieIsMode
   - 4.2.17.74. GetMovieIsMode
   - 4.2.17.75. CapMovieIsModeBoost
   - 4.2.17.76. SetMovieIsModeBoost
   - 4.2.17.77. GetMovieIsModeBoost
   - 4.2.17.78. CapMovieZebraSetting
   - 4.2.17.79. SetMovieZebraSetting
   - 4.2.17.80. GetMovieZebraSetting
   - 4.2.17.81. CapMovieZebraLevel
   - 4.2.17.82. SetMovieZebraLevel
   - 4.2.17.83. GetMovieZebraLevel
   - 4.2.17.84. CapWaveFormVectorScope
   - 4.2.17.85. SetWaveFormVectorScope
   - 4.2.17.86. GetWaveFormVectorScope
   - 4.2.17.87. GetWaveFormData......................................................................................................................................................
   - 4.2.17.88. GetVectorScopeData
   - 4.2.17.89. GetParadeData
   - 4.2.17.90. CapWaveFormSetting
   - 4.2.17.91. SetWaveFormSetting
   - 4.2.17.92. GetWaveFormSetting
   - 4.2.17.93. CapVectorScopeSetting
   - 4.2.17.94. SetVectorScopeSetting
   - 4.2.17.95. GetVectorScopeSetting
- FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0.
         -
      - 4.2.17.96. CapParadeSettingDisplay
      - 4.2.17.97. SetParadeSettingDisplay
      - 4.2.17.98. GetParadeSettingDisplay.............................................................................................................................................
      - 4.2.17.99. CapParadeSettingColor
      - 4.2.17.100. SetParadeSettingColor
      - 4.2.17.101. GetParadeSettingColor
      - 4.2.17.102. CapMovieOptimizedControl........................................................................................................................................
      - 4.2.17.103. SetMovieOptimizedControl.........................................................................................................................................
      - 4.2.17.104. GetMovieOptimizedControl
      - 4.2.17.105. CapRecFrameIndicator
      - 4.2.17.106. SetRecFrameIndicator
      - 4.2.17.107. GetRecFrameIndicator
      - 4.2.17.108. CapMovieTallyLight
      - 4.2.17.109. SetMovieTallyLight
      - 4.2.17.110. GetMovieTallyLight
      - 4.2.17.111. CapFanSetting
      - 4.2.17.112. SetFanSetting
      - 4.2.17.113. GetFanSetting
      - 4.2.17.114. SetMovieCustomSetting
      - 4.2.17.115. SetMovieCustomName
      - 4.2.17.116. GetMovieCustomName
      - 4.2.17.117. CapMovieDigitalZoom
      - 4.2.17.118. SetMovieDigitalZoom..................................................................................................................................................
      - 4.2.17.119. GetMovieDigitalZoom
      - 4.2.17.120. GetMovieDigitalZoomRange
      - 4.2.17.121. GetMovieRecordingTime
      - 4.2.17.122. GetMovieRemainingTime
      - 4.2.17.123. GetHistogramData
      - 4.2.17.124. GetBodyTemperatureWarning
      - 4.2.17.125. CapShortMovieSecond................................................................................................................................................
      - 4.2.17.126. SetShortMovieSecond.................................................................................................................................................
      - 4.2.17.127. GetShortMovieSecond
      - 4.2.17.128. GetMovieTransparentFrameInfo
   - 4.2.18. Movie Control – IMAGE QUALITY SETTING
      - 4.2.18.1. CapMovieFilmSimulationMode
      - 4.2.18.2. SetMovieFilmSimulationMode
      - 4.2.18.3. GetMovieFilmSimulationMode
      - 4.2.18.4. CapMovieMonochromaticColor
      - 4.2.18.5. SetMovieMonochromaticColor
      - 4.2.18.6. GetMovieMonochromaticColor
- FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0.
         -
      - 4.2.18.7. CapMovieWhiteBalanceTune
      - 4.2.18.8. SetMovieWhiteBalanceTune
      - 4.2.18.9. GetMovieWhiteBalanceTune
      - 4.2.18.10. CapMovieHighLightTone
      - 4.2.18.11. SetMovieHighLightTone
      - 4.2.18.12. GetMovieHighLightTone
      - 4.2.18.13. CapMovieShadowTone
      - 4.2.18.14. SetMovieShadowTone
      - 4.2.18.15. GetMovieShadowTone
      - 4.2.18.16. CapMovieColorMode
      - 4.2.18.17. SetMovieColorMode
      - 4.2.18.18. GetMovieColorMode
      - 4.2.18.19. CapMovieSharpness
      - 4.2.18.20. SetMovieSharpness
      - 4.2.18.21. GetMovieSharpness
      - 4.2.18.22. CapMovieNoiseReduction
      - 4.2.18.23. SetMovieNoiseReduction............................................................................................................................................
      - 4.2.18.24. GetMovieNoiseReduction
      - 4.2.18.25. CapInterFrameNR
      - 4.2.18.26. SetInterFrameNR
      - 4.2.18.27. GetInterFrameNR
      - 4.2.18.28. CapFlogDRangePriority
      - 4.2.18.29. SetFlogDRangePriority
      - 4.2.18.30. GetFlogDRangePriority
      - 4.2.18.31. CapMoviePeripheralLightCorrection
      - 4.2.18.32. SetMoviePeripheralLightCorrection
      - 4.2.18.33. GetMoviePeripheralLightCorrection
      - 4.2.18.34. CapMoviePortraitEnhancer
      - 4.2.18.35. SetMoviePortraitEnhancer
      - 4.2.18.36. GetMoviePortraitEnhancer
   - 4.2.19. Movie Control - AF/MF SETTING
      - 4.2.19.1. CapMovieFocusArea
      - 4.2.19.2. SetMovieFocusArea
      - 4.2.19.3. GetMovieFocusArea
      - 4.2.19.4. CapMovieAFMode
      - 4.2.19.5. SetMovieAFMode
      - 4.2.19.6. GetMovieAFMode
      - 4.2.19.7. CapMovieAFCCustom
      - 4.2.19.8. SetMovieAFCCustom
      - 4.2.19.9. GetMovieAFCCustom
- FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0.
         -
      - 4.2.19.10. CapMovieEyeAFMode
      - 4.2.19.11. SetMovieEyeAFMode
      - 4.2.19.12. GetMovieEyeAFMode
      - 4.2.19.13. CapMovieFaceDetectionMode
      - 4.2.19.14. SetMovieFaceDetectionMode
      - 4.2.19.15. GetMovieFaceDetectionMode
      - 4.2.19.16. CapMovieSubjectDetectionMode
      - 4.2.19.17. SetMovieSubjectDetectionMode
      - 4.2.19.18. GetMovieSubjectDetectionMode
      - 4 .2.19.19. GetTrackingAfFrameInfo
      - 4.2.19.20. CapMovieFullTimeManual
      - 4.2.19.21. SetMovieFullTimeManual
      - 4.2.19.22. GetMovieFullTimeManual
      - 4.2.19.23. CapMovieMFAssistMode
      - 4.2.19.24. SetMovieMFAssistMode
      - 4.2.19.25. GetMovieMFAssistMode
      - 4.2.19.26. CapMovieFocusCheckMode
      - 4.2.19.27. SetMovieFocusCheckMode
      - 4.2.19.28. GetMovieFocusCheckMode
      - 4.2.19.29. CapMovieFocusCheckLock
      - 4.2.19.30. SetMovieFocusCheckLock
      - 4.2.19.31. GetMovieFocusCheckLock
      - 4.2.19.32. GetFocusMapData
      - 4.2.19.33. GetMovieFocusMeter
   - 4.2.20. Movie Control - AUDIO SETTING
      - 4.2.20.1. CapInternalMicLevel
      - 4.2.20.2. SetInternalMicLevel
      - 4.2.20.3. GetInternalMicLevel....................................................................................................................................................
      - 4.2.20.4. CapInternalMicLevelManual
      - 4.2.20.5. SetInternalMicLevelManual
      - 4.2.20.6. GetInternalMicLevelManual
      - 4.2.20.7. CapExternalMicLevel
      - 4.2.20.8. SetExternalMicLevel
      - 4.2.20.9. GetExternalMicLevel
      - 4.2.20.10. CapExternalMicLevelManual
      - 4.2.20.11. SetExternalMicLevelManual
      - 4.2.20.12. GetExternalMicLevelManual
      - 4.2.20.13. CapMicLevelLimiter.....................................................................................................................................................
      - 4.2.20.14. SetMicLevelLimiter......................................................................................................................................................
      - 4.2.20.15. GetMicLevelLimiter
- FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0.
         -
      - 4.2.20.16. CapWindFilter
      - 4.2.20.17. SetWindFilter
      - 4.2.20.18. GetWindFilter
      - 4.2.20.19. CapLowCutFilter
      - 4.2.20.20. SetLowCutFilter
      - 4.2.20.21. GetLowCutFilter
      - 4.2.20.22. CapHeadPhonesVolume..............................................................................................................................................
      - 4.2.20.23. SetHeadPhonesVolume...............................................................................................................................................
      - 4.2.20.24. GetHeadPhonesVolume
      - 4.2.20.25. CapXLRAdapterMicSource
      - 4.2.20.26. SetXLRAdapterMicSource
      - 4.2.20.27. GetXLRAdapterMicSource
      - 4.2.20.28. CapXLRAdapterMoniteringSource
      - 4.2.20.29. SetXLRAdapterMoniteringSource
      - 4.2.20.30. GetXLRAdapterMoniteringSource
      - 4.2.20.31. CapXLRAdapterHDMIOutputSource
      - 4.2.20.32. SetXLRAdapterHDMIOutputSource
      - 4.2.20.33. GetXLRAdapterHDMIOutputSource
      - 4.2.20.34. GetMicLevelIndicator
      - 4.2.20.35. CapMovieRecVolume
      - 4.2.20.36. SetMovieRecVolume
      - 4.2.20.37. GetMovieRecVolume
      - 4.2.20.38. CapDirectionalMic.......................................................................................................................................................
      - 4.2.20.39. SetDirectionalMic
      - 4.2.20.40. GetDirectionalMic
   - 4.2.21. Movie Control - TIME CODE SETTING
      - 4.2.21.1. CapTimeCodeDisplay
      - 4.2.21.2. SetTimeCodeDisplay
      - 4.2.21.3. GetTimeCodeDisplay
      - 4.2.21.4. CapTimeCodeStartSetting
      - 4.2.21.5. SetTimeCodeStartSetting
      - 4.2.21.6. CapTimeCodeCountUp................................................................................................................................................
      - 4.2.21.7. SetTimeCodeCountUp.................................................................................................................................................
      - 4.2.21.8. GetTimeCodeCountUp
      - 4.2.21.9. CapTimeCodeDropFrame
      - 4.2.21.10. SetTimeCodeDropFrame
      - 4.2.21.11. GetTimeCodeDropFrame
      - 4.2.21.12. CapTimeCodeHDMIOutput
      - 4.2.21.13. SetTimeCodeHDMIOutput
      - 4.2.21.14. GetTimeCodeHDMIOutput
- FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0.
            -
         - 4.2.21.15. CapATOMOSAirGluConnection
         - 4.2.21.16. SetATOMOSAirGluConnection
         - 4.2.21.17. GetATOMOSAirGluConnection
         - 4.2.21.18. GetTimeCode
         - 4.2.21.19. GetTimeCodeCurrentValue
         - 4.2.21.20. GetTimeCodeStatus
      - 4.2.22. Other Functions
         - 4.2.22.1. CapCustomAutoPowerOff
         - 4.2.22.2. SetCustomAutoPowerOff
         - 4.2.22.3. GetCustomAutoPowerOff
         - 4.2.22.4. CapPerformanceSettings
         - 4.2.22.5. SetPerformanceSettings
         - 4.2.22.6. GetPerformanceSettings
         - 4.2.22.7. CapElectronicLevelSetting
         - 4.2.22.1. SetElectronicLevelSetting
         - 4.2.22.2. GetElectronicLevelSetting
         - 4 .2.22.3. CapUSBPowerSupplyCommunication
         - 4.2.22.4. SetUSBPowerSupplyCommunication
         - 4.2.22.5. GetUSBPowerSupplyCommunication
         - 4.2.22.6. CapAutoPowerOffSetting
         - 4.2.22.7. SetAutoPowerOffSetting
         - 4.2.22.8. GetAutoPowerOffSetting
- 5. ERROR CODES
- 6. SAMPLE SOURCE CODE
   - 6.1. HOTFOLDER
      - 6.1.1. Overview
      - 6.1.2. Compatible OS, Development Environment, Langage, Libraries
      - 6.1.3. Operations (for Windows)
      - 6.1.4. Operations (for macOS)
   - 6.2. RELEASEBUTTON (FOR WINDOWS)
      - 6.2.1. Overview
      - 6.2.2. Compatible OS
   - 6.3. ZOOMPOS
      - 6.3.1. Overview
      - 6.3.2. Compatible OS, Development Environment, Langage, Libraries
   - 6.4. MULTIPLE
      - 6.4.1. Overview
      - 6.4.2. Compatible OS, Development Environment, Langage, Libraries
   - 6.5. LIVEVIEW
- FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0.
         -
      - 6.5.1. Overview
      - 6.5.2. Compatible OS, Development Environment, Langage, Libraries
- 7. APPENDIX
   - 7.1. XFILENAME
      - 7.1.1. Overview


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**
20

**Revision History**

**Revision Date Description**

1. 20 .0.0 Mar. 18 , 202 1 ⚫ Initial release compatible with:
    FUJIFILM X-T3, X-T4, X-Pro3, GFX 50S, GFX 50R, GFX 100 , and GFX100S.
1.21.0.0 Jun. 24, 2021 ⚫ Adds support for FUJIFILM X-S10 (firmware version 2.00 or later).
1.2 2 .0.0 Sep. 16, 2021 ⚫ Adds support for FUJIFILM GFX50S II
1.2 3 .0. 1 Jun. 30 , 202 2 ⚫ Adds support for FUJIFILM X-H2S
1.24.0.0 Sep. 8, 2022 ⚫ Adds support for FUJIFILM X-H
1 .25.0.0 Nov. 2, 2022 ⚫ Adds support for FUJIFILM X-T
1 .2 7 .0. 0 Apr. 26 , 202 3 ⚫ Adds support for FUJIFILM X-S
1 .28.0.0 Sep. 12 , 2023 ⚫ Adds support for FUJIFILM GFX 100 II
1 .29.0.0 Feb. 20 , 202 4 ⚫ Adds support for FUJIFILM GFX100S II
1.3 1 .0.0 Oct.1, 2024 ⚫ Adds support for FUJIFILM X-M
    ⚫ Add APIs for movie control
1 .32.0.0 Jan.23, 2025 ⚫ Adds support for Linux
    ⚫ Adds support for Android OS
1 .3 3 .0.0 Mar.20, 2025 ⚫ Adds support for FUJIFILM GFX100RF

**Note:**
Microsoft, Windows, and Visual Studio are either registered trademarks or trademarks of Microsoft Corporation in the
United States and/or other countries.
Apple, macOS and Xcode are registered trademarks of Apple Inc.
Other company and product names are generally the trademarks or registered trademarks of their respective companies.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

**1. Introduction**
This software development kit (SDK) is for FUJIFILM GFX & X Series digital cameras. It provides functions for
controlling cameras from Windows PC and Mac computers, including:
- adjusting camera shooting conditions,
- operating the camera shutter-release, AF lock button, and other controls, and
- transferring taken images from the camera to the computer.
This SDK does not offer features for converting RAW files to other formats.
It provides C language interfaces for controlling FUJIFILM digital cameras that support tethered shooting.
A limited selections of GFX & X Series cameras are supported.

**1.1. Compatible Operating Systems
1.1.1. Windows**
Windows
OS Windows 7(x86/x64), Windows 8.1(x86/x64), Windows 10(x86/x64), and Windows
11 with the latest Service Pack.
(All testing performed under Japanese versions of Windows)
CPU Intel CPUs
Interface USB (for direct connections between cameras and computers),
TCP/IP (only for models that support Wi Fi tethering)
Programs 32 bit libraries / 64 bit libraries
Development Environment Microsoft Visual Studio 201 7 (Visual C++)
Maximum number of cameras 4 simultaneous connections

To load the SDK library “XAPI.dll”, call LoadLibrary() function and then call GetProcAddress() to get pointers to
exported API functions. All related DLLs (FTLPTP.dll, FF0001API.dll, ...) should be in the same folder as “XAPI.dll”.
When you finish using the SDK, call FreeLibrary() to unload the library.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

**1.1.2. macOS**
The macOS version of the SDK is provided in “bundle” libraries and “dylib” libraries.

macOS
OS macOS Sierra (10.12), High Sierra (10.13), Mojave (10.14), Catalina (10.15), Big Sur
(11), Monterey(12), Ventura(13), Sonoma(14) and Sequoia ( 15 ).
**_macOS 10.15.2 is NOT supported._**
(All testing was performed in Japanese operating environments.)
Interface USB (for direct connections between cameras and computers),
TCP/IP (only for models that support Wi Fi tethering)
Programs 64 bit libraries (Universal 2)
Development Environment Xcode
Maximum number of cameras 4 simultaneous connections

All dylib libraries (FTLPTP.dylib, and FTLPTPIP.dylib) have to be in the “Resources” folder of the application. To place
all related bundle libraries (FF0001API.bundle, ...) in the “Resources” folder is recommended.
The libraries are signed by Fujifilm. Please set the "Signing" > "Enable Hardened Runtime" to "Yes", and then check the
"Disable Library Validation" in the "Hardened Runtime" > "runtime Exceptions" for your project at the XCode.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

**1.1.3. Linux**

Linux
OS Ubuntu 22.04.5 LT S 64bit (x64)
RaspberryPi OS 32bit (ARMv 7 )
RaspberryPi OS 64bit (ARMv8)
Interface USB (for direct connections between cameras and computers),
TCP/IP (only for models that support Wi Fi tethering)
Programs 32 bit libraries for ARMv7/ 64 bit libraries for ARMv8
Dependecy libusb-1.0.27
Maximum number of cameras 4 simultaneous connections

To load the SDK library “XAPI.so”, call dlopen() function and then call dlsym() to get pointers to exported API
functions. All related so libraries (FTLPTP.so, FF0001API.so, ...) should be in the same folder as “XAPI.so”.
When you finish using the SDK, call dlclose() to unload the library.
If you would not like to specify absolute paths of the libraries, you have to proper LD_LIBRARY_PATH prior to load
libraries.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
1.1.4. Android
```
Android
OS Android1 1
Android1 2
Android1 3
Android1 4
Android1 5
(All testing was performed in Japanese operating environments.)
Interface USB (for direct connections between cameras and computers),
Programs 64 bit libraries
Development Environment Android Studio (Android SDK^ : Android Studio Hedgehog | 2023.1.1 Patch 2)^
Maximum number of cameras 1 simultaneous connections
To use the SDK libraries, please follow the Android NDK manner.
Place SDK libraries in the jniLibs folder.
Add a JNI wrapper library to the project by placing C++ wrapper code and make file in the cpp folder.
JNI C++ wrapper functions have to be named following the manner below:
Java_(package name)_(class name)_(method name)
Load the wrapper so library to use the SDK from Kotlin/Java application code.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

**1.2. Supported Cameras**
FUJIFILM X-T3
FUJIFILM X-T4
FUJIFILM GFX 50S (firmware version 1.00, or 1.01, USB connections ONLY)
FUJIFILM X-Pro 3
FUJIFILM GFX 50R
FUJIFILM GFX 100
FUJIFILM GFX100S
FUJIFILM X-S10 (firmware version 2.00 or later)
FUJIFILM GFX 50 S II
FUJIFILM X-H2S
FUJIFILM X-H2
FUJIFILM X-T5
FUJIFILM X-S20
FUJIFILM GFX100 II
FUJIFILM GFX100S II
FUJIFILM X-M5
FUJIFILM GFX100RF

* Please upgrade the camera with the latest firmware. The firmware is available from:
https://fujifilm-x.com/support/download/firmware/cameras/

**1.2.1. USB Connection Support**
All SDK-compatible models support tethered shooting control via USB connections.

**Readying the Camera**
Following the instructions in the camera Owner’s Manual or New Feature Guide, choose a “tethered” connection mode
such as PC SHOOT AUTO, USB AUTO, or USB TETHER SHOOTING AUTO.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

In case of X-H2S, choose “USB TETHER SHOOTING AUTO” from “NETWORK/USB SETTING MENU > SELECT
CONNECTION SETTING”.
**1.2.2. Wi-Fi Connection Support**
Cameras other than GFX 50S firmware version 1. 00 or 1.01, can be connected via Wi-Fi networks instead of via USB
cable.

**Readying the Camera**
[X-H2S , X-H2, X-T5 and X-S20]
**Please refer to the “Manual(Network and USB Settings)” of the model to setup a Wi-Fi connection environment.
eg. For X-H2S, FUJIFILM X-H2S Manual(Network and USB Settings)**

[Other models]

1. Specify how the camera is assigned an IP address.
    Select **AUTO** or **MANUAL** for
    - **CONNECTION SETTING** > **WIRELESS SETTINGS** > **IP**
       **ADDRESS** , or
    - **CONNECTION SETTING** > **NETWORK SETTING** >
       **WIRELESS IP ADDRESS SETTING**
    (menu options vary with the firmware version).
    If you chose MANUAL, specify an IP address (IP ADDRESS),
    network mask (NETMASK), and gateway address
    (GATEWAY ADDRESS) manually.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

2. Specify the Access Point
    Select **SIMPLE SETUP** or **MANUAL** for
    - **CONNECTION SETTING** > **WIRELESS SETTINGS** > **ACCESS**
    **POINT SETTINGS** , or
    - **CONNECTION SETTING** > **NETWORK SETTING** >
    **WIRELESS ACCESS POINT SETTING**
    (menu options vary with the firmware version).
    And then follow the on-screen instructions to specify an access point.
3. Choose a WIRELESS FIXED (or WIRELESS TETHER SHOOTING FIXED).
    In the camera menus,
    - chose **CONNECTION SETTING** > **PC SHOOT MODE** and
       choose **WIRELESS FIXED** , or
    - select **CONNECTION SETTING** > **PC CONNECTION MODE**
       and choose **WIRELESS TETHER SHOOTING FIXED**
    (menu options vary with the firmware version).
    The camera will connect to the Wi‑Fi access point.
4. Check the IP Address of the camera
    When the camera and computer are on different networks, go to
    **CONNECTION SETTING** > **WIRELESS SETTINGS** > **IP**
    **ADDRESS** , or
    **CONNECTION SETTING** > **INFORMATION**
    (menu options vary with the firmware version) in the camera
    menus, check the camera’s IP address.
    Specifying the IP address onto your application software on
    the computer makes communications available.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

**Camera Status Monitoring**
During wireless tethered photography, the camera indicator lamp shows camera status as
follows.

Indicator Lamp Status
Blinking in red
Blinking in red describes “searching for the access point”.

Blinking in orange
Blinking in orange describes “awaiting a connection from tethered shooting software”.

Blinking in green
Blinking in green describes “ready for tethered shooting”.

Red with red flashes (red)
Blinking in red describes “searching for the access point”.
Lighting in red describes “images awaiting upload”.
As a result, the LED lights in red always.
Red with blinking in orange
Blinking in orange describes “awaiting a connection from tethered shooting software”.
Lighting in red describes “images awaiting upload”.
As a result, the LED brinks in orange and red.
Red with blinking in green
Blinking in green describes “ready for tethered shooting”.
Lighting in red describes “images awaiting upload”.
As a result, the LED brinks in green and red.
Green
Subject in focus.

Flashes in green
Focus or exposure warning.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

**1.3. Limitations
The SDK PROHIBITS:**

- **multiple simultaneous calls to SDK functions from a single process (SDK function calls should be safely**
    **controlled using lock mechanisms such as CriticalSection or Mutex), and**
- **multiple simultaneous calls to SDK functions from multiple processes.**

**1.4. Redistributable Files
1.4.1. Windows Version (32 bit libraries)**
Redistributable files Version
REDISTRIBUTABLES¥WINDOWS¥32bit¥ **FTLPTP.dll** 3.3. 3. 0
REDISTRIBUTABLES¥WINDOWS¥32bit¥ **FTLPTPIP.dll** 1.3.2. 3
REDISTRIBUTABLES¥WINDOWS¥32bit¥ **XAPI.dll** 1.1 6 .0. 3
REDISTRIBUTABLES¥WINDOWS¥32bit¥ **XSDK.dat** -
REDISTRIBUTABLES¥WINDOWS¥32bit¥ **FF000 0 API.dll** 1.1.0.0
REDISTRIBUTABLES¥WINDOWS¥32bit¥ **FF0001API.dll** 1 .3.0.2
REDISTRIBUTABLES¥WINDOWS¥32bit¥ **FF000 2 API.dll** 1 .3.0.0
REDISTRIBUTABLES¥WINDOWS¥32bit¥ **FF000 3 API.dll** 1. 4 .0. 0
REDISTRIBUTABLES¥WINDOWS¥32bit¥ **FF000 4 API.dll** 1 .0.0. 0
REDISTRIBUTABLES¥WINDOWS¥32bit¥ **FF000 5 API.dll** 1 .1.0.0
REDISTRIBUTABLES¥WINDOWS¥32bit¥ **FF000 6 API.dll** 1. 2 .0. 0
REDISTRIBUTABLES¥WINDOWS¥32bit¥ **FF000 7 API.dll** 1. 1 .0.0
REDISTRIBUTABLES¥WINDOWS¥32bit¥ **FF000 8 API.dll** 1. 3 .0.0
REDISTRIBUTABLES¥WINDOWS¥32bit¥ **FF000 9 API.dll** 1 .0.0.3
REDISTRIBUTABLES¥WINDOWS¥32bit¥ **FF00 10 API.dll** 1. 0 .0. 1
REDISTRIBUTABLES¥WINDOWS¥32bit¥ **FF00 11 API.dll** 1. 0 .0. 5
REDISTRIBUTABLES¥WINDOWS¥32bit¥ **FF0012API.dll** 1.0.0.1
REDISTRIBUTABLES¥WINDOWS¥32bit¥ **FF001 3 API.dll** 1.0.0.1
REDISTRIBUTABLES¥WINDOWS¥32bit¥ **FF00 14 API.dll** 1.2. 1 .0
REDISTRIBUTABLES¥WINDOWS¥32bit¥ **FF00 15 API.dll** 1.2. 1 .0
REDISTRIBUTABLES¥WINDOWS¥32bit¥ **FF00 16 API.dll** 1.1. 1 .0
REDISTRIBUTABLES¥WINDOWS¥32bit¥ **FF00 17 API.dll** 1.1. 1 .0
REDISTRIBUTABLES¥WINDOWS¥32bit¥ **FF00 18 API.dll** 1.1. 1 .0
REDISTRIBUTABLES¥WINDOWS¥32bit¥ **FF00 19 API.dll** 1.1. 1 .0
REDISTRIBUTABLES¥WINDOWS¥32bit¥ **FF00 20 API.dll** 1 .0. 1. 0
REDISTRIBUTABLES¥WINDOWS¥32bit¥ **FF00 21 API.dll** 1 .0.0.5


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

**1.4.1. Windows Version (64 bit libraries)**
Redistributable files Version
REDISTRIBUTABLES¥WINDOWS¥64bit¥ **FTLPTP.dll** 3.3. 3. 0
REDISTRIBUTABLES¥WINDOWS¥64bit¥ **FTLPTPIP.dll** 1.3.2. 3
REDISTRIBUTABLES¥WINDOWS¥64bit¥ **XAPI.dll** 1.1 6 .0. 3
REDISTRIBUTABLES¥WINDOWS¥ 64 bit¥ **XSDK.dat** -
REDISTRIBUTABLES¥WINDOWS¥64bit¥ **FF000 0 API.dll** 1.1.0.0
REDISTRIBUTABLES¥WINDOWS¥64bit¥ **FF0001API.dll** 1 .3.0.2
REDISTRIBUTABLES¥WINDOWS¥64bit¥ **FF000 2 API.dll** 1 .3.0.0
REDISTRIBUTABLES¥WINDOWS¥64bit¥ **FF000 3 API.dll** 1. 4 .0. 0
REDISTRIBUTABLES¥WINDOWS¥64bit¥ **FF000 4 API.dll** 1 .0.0. 0
REDISTRIBUTABLES¥WINDOWS¥64bit¥ **FF000 5 API.dll** 1 .1.0.0
REDISTRIBUTABLES¥WINDOWS¥64bit¥ **FF000 6 API.dll** 1. 2 .0. 0
REDISTRIBUTABLES¥WINDOWS¥64bit¥ **FF000 7 API.dll** 1. 1 .0.0
REDISTRIBUTABLES¥WINDOWS¥64bit¥ **FF000 8 API.dll** 1. 3 .0.0
REDISTRIBUTABLES¥WINDOWS¥64bit¥ **FF000 9 API.dll** 1 .0.0.3
REDISTRIBUTABLES¥WINDOWS¥64bit¥ **FF00 10 API.dll** 1. 0 .0. 1
REDISTRIBUTABLES¥WINDOWS¥64bit¥ **FF00 11 API.dll** 1. 0 .0. 5
REDISTRIBUTABLES¥WINDOWS¥64bit¥ **FF0012API.dll** 1.0.0.1
REDISTRIBUTABLES¥WINDOWS¥64bit¥ **FF001 3 API.dll** 1.0.0.1
REDISTRIBUTABLES¥WINDOWS¥64bit¥ **FF001 4 API.dll** 1.2. 1 .0
REDISTRIBUTABLES¥WINDOWS¥64bit¥ **FF001 5 API.dll** 1.2. 1 .0

REDISTRIBUTABLES¥WINDOWS¥64bit¥ **FF00 16 API.dll** (^) 1.1. 1 .0
REDISTRIBUTABLES¥WINDOWS¥64bit¥ **FF00 17 API.dll** (^) 1.1. 1 .0
REDISTRIBUTABLES¥WINDOWS¥64bit¥ **FF00 18 API.dll** (^) 1.1. 1 .0
REDISTRIBUTABLES¥WINDOWS¥64bit¥ **FF00 19 API.dll** (^) 1.1. 1 .0
REDISTRIBUTABLES¥WINDOWS¥64bit¥ **FF0020API.dll** 1.0. 1. 0
REDISTRIBUTABLES¥WINDOWS¥64bit¥ **FF002 1 API.dll** 1.0. 0. 5


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

**1.4.2. macOS Version**
Redistributable files Version
REDISTRIBUTABLES/macOS/ **SDK_ 133 00.zip** -
**FTLPTP.dylib** 3.3. 3. 0
**FTLPTPIP.dylib** 1.3.2. 3
**XAPI.bundle** 1.1 6 .0. 3
**XSDK.DAT** -
**FF000 0 API.bundle** 1.1.0.0
**FF0001API.bundle** 1 .3.0.2
**FF000 2 API.bundle** 1 .3.0.0
**FF000 3 API.bundle** 1. 4 .0. 0
**FF000 4 API.bundle** 1 .0.0. 0
**FF000 5 API.bundle** 1 .1.0.0
**FF000 6 API.bundle** 1. 2 .0. 0
**FF000 7 API.bundle** 1. 1 .0.0
**FF000 8 API.bundle** 1. 3 .0.0
**FF000 9 API.bundle** 1 .0.0.3
**FF00 10 API.bundle** 1. 0 .0. 1
**FF00 11 API.bundle** 1. 0 .0. 5
**FF0012API.bundle** 1.0.0.1
**FF001 3 API.bundle** 1.0.0.1
**FF001 4 API.bundle** 1.2. 1 .0
**FF001 5 API.bundle** 1.2. 1 .0
**FF0016API.bundle** 1.1. 1 .0
**FF0017API.bundle** 1.1. 1 .0
**FF0018API.bundle** 1.1. 1 .0
**FF0019API.bundle** 1.1. 1 .0
**FF0020API.bundle** 1 .0. 1. 0
**FF0021API.bundle** 1 .0.0.5


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

**1.4.1. Linux Version (Linux® 64bit (ARMv8)))**
Redistributable files Version
REDISTRIBUTABLES/Linux64ARMv8/ -
**FTLPTP.so** 1.0.0.0
**FTLPTPIP.so** 1.0.0.0
**XAPI.so** 1.1 6 .0. 3
**XSDK.DAT** -
**FF000 0 API.so** 1.1.0.0
**FF0001API.so** 1 .3.0.2
**FF000 2 API.so** 1 .3.0.0
**FF000 3 API.so** 1. 4 .0. 0
**FF000 4 API.so** 1 .0.0. 0
**FF000 5 API.so** 1 .1.0.0
**FF000 6 API.so** 1. 2 .0. 0
**FF000 7 API.so** 1. 1 .0.0
**FF000 8 API.so** 1. 3 .0.0
**FF000 9 API.so** 1 .0.0.3
**FF00 10 API.so** 1. 0 .0. 1
**FF00 11 API.so** 1. 0 .0. 5
**FF0012API.so** 1.0.0.1
**FF001 3 API.so** 1.0.0.1
**FF001 4 API.so** 1.2. 1 .0
**FF001 5 API.so** 1.2. 1 .0
**FF0016API.so** 1.1. 1 .0
**FF0017API.so** 1.1. 1 .0
**FF0018API.so** 1.1. 1 .0
**FF0019API.so** 1.1. 1 .0
**FF0020API.so** 1 .0. 1. 0
**FF0021API.so** 1 .0. 0. 5


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

**1.4.2. Linux Version (Linux® 32bit (ARMv7))**
Redistributable files Version
REDISTRIBUTABLES/Linux32ARMv7/ -
**FTLPTP.so** 1.0.0.0
**FTLPTPIP.so** 1.0.0.0
**XAPI.so** 1.1 6 .0. 3
**XSDK.DAT** -
**FF000 0 API.so** 1.1.0.0
**FF0001API.so** 1 .3.0.2
**FF000 2 API.so** 1 .3.0.0
**FF000 3 API.so** 1. 4 .0. 0
**FF000 4 API.so** 1 .0.0. 0
**FF000 5 API.so** 1 .1.0.0
**FF000 6 API.so** 1. 2 .0. 0
**FF000 7 API.so** 1. 1 .0.0
**FF000 8 API.so** 1. 3 .0.0
**FF000 9 API.so** 1 .0.0.3
**FF00 10 API.so** 1. 0 .0. 1
**FF00 11 API.so** 1. 0 .0. 5
**FF0012API.so** 1.0.0.1
**FF001 3 API.so** 1.0.0.1
**FF001 4 API.so** 1.2. 1 .0
**FF001 5 API.so** 1.2. 1 .0
**FF0016API.so** 1.1. 1 .0
**FF0017API.so** 1.1. 1 .0
**FF0018API.so** 1.1. 1 .0
**FF0019API.so** 1.1. 1 .0
**FF0020API.so** 1 .0. 1. 0
**FF0021API.so** 1 .0.0.5


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

**1.4.3. Linux Version (Linux® 64bit (x64)** )
Redistributable files Version
REDISTRIBUTABLES/Linux64PC/ -
**FTLPTP.so** 1.0.0.0
**FTLPTPIP.so** 1.0.0.0
**XAPI.so** 1.1 6 .0. 3
**XSDK.DAT** -
**FF000 0 API.so** 1.1.0.0
**FF0001API.so** 1 .3.0.2
**FF000 2 API.so** 1 .3.0.0
**FF000 3 API.so** 1. 4 .0. 0
**FF000 4 API.so** 1 .0.0. 0
**FF000 5 API.so** 1 .1.0.0
**FF000 6 API.so** 1. 2 .0. 0
**FF000 7 API.so** 1. 1 .0.0
**FF000 8 API.so** 1. 3 .0.0
**FF000 9 API.so** 1 .0.0.3
**FF00 10 API.so** 1. 0 .0. 1
**FF00 11 API.so** 1. 0 .0. 5
**FF0012API.so** 1.0.0.1
**FF001 3 API.so** 1.0.0.1
**FF001 4 API.so** 1.2. 1 .0
**FF001 5 API.so** 1.2. 1 .0
**FF0016API.so** 1.1. 1 .0
**FF0017API.so** 1.1. 1 .0
**FF0018API.so** 1.1. 1 .0
**FF0019API.so** 1.1. 1 .0
**FF0020API.so** 1 .0. 1. 0
**FF0021API.so** 1 .0.0.5


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

**1.4.4. Android Version**
Redistributable files Version
REDISTRIBUTABLES/Android/arm64-v8a/ -
**FTLPTP.so** 1.0.0.0
**XAPI.so** 1.1 6 .0. 3
**FF000 0 API.so** 1.1.0.0
**FF0001API.so** 1 .3.0.2
**FF000 2 API.so** 1 .3.0.0
**FF000 3 API.so** 1. 4 .0. 0
**FF000 4 API.so** 1 .0.0. 0
**FF000 5 API.so** 1 .1.0.0
**FF000 6 API.so** 1. 2 .0. 0
**FF000 7 API.so** 1. 1 .0.0
**FF000 8 API.so** 1. 3 .0.0
**FF000 9 API.so** 1 .0.0.3
**FF00 10 API.so** 1. 0 .0. 1
**FF00 11 API.so** 1. 0 .0. 5
**FF0012API.so** 1.0.0.1
**FF001 3 API.so** 1.0.0.1
**FF001 4 API.so** 1.2. 1 .0
**FF001 5 API.so** 1.2. 1 .0
**FF0016API.so** 1.1. 1 .0
**FF0017API.so** 1.1. 1 .0
**FF0018API.so** 1.1. 1 .0
**FF0019API.so** 1.1. 1 .0
**FF0020API.so** 1 .0. 1. 0
**FF0021API.so** 1 .0.0.5
**REDISTRIBUTABLES/Android/armeabi-v7a/** -
**FTLPTP.so** 1 .0.0.0
**XAPI.so** 1.1 6 .0. 3
**FF0000API.so** 1.1.0.0
**FF0001API.so** 1 .3.0.2
**FF0002API.so** 1 .3.0.0
**FF0003API.so** 1. 4 .0. 0
**FF0004API.so** 1 .0.0. 0
**FF0005API.so** 1 .1.0.0
**FF0006API.so** 1. 2 .0. 0


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
FF0007API.so 1. 1 .0.0
FF0008API.so 1. 3 .0.0
FF0009API.so 1 .0.0.3
FF0010API.so 1. 0 .0. 1
FF0011API.so 1. 0 .0. 5
FF0012API.so 1.0.0.1
FF001 3 API.so 1.0.0.1
FF001 4 API.so 1.2. 1 .0
FF001 5 API.so 1.2. 1 .0
FF0016API.so 1.1. 1 .0
FF0017API.so 1.1. 1 .0
FF0018API.so 1.1. 1 .0
FF0019API.so 1.1. 1 .0
FF0020API.so 1 .0. 1. 0
FF0021API.so 1 .0.0.5
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
1.5. Storage Model
```
All cameras that support tethered shooting have in-camera volatile storage for data transfer. All images taken in tethered
shooting mode are saved to this in-camera volatile storage. An SDK API is available to automatically copy the images
from the in-camera volatile storage to the SD memory card. Files and other data on the memory card cannot be accessed
via the SDK API interface in tethered shooting modes.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

**1.6. Basic Policies for X/GFX Camera Behavior**
GFX & X series cameras are designed for hierarchical settings. The topmost is the “OPERATION MODE
(SHOOTING/PLAYBACK)”.

The next is the “MODE (P/A/S/M/C1/C2/C2/.../MOVIE/...)”. Some models feature separate “P/S/A/M/C1/...” dial and
“MOVIE/STILL” switch.
Some models do not have the dial or the switch, but the policy still exists.

The third level in the settings hierarchy is “DRIVE MODE”.
The MOVIE mode may be categorized in the DRIVE MODE, if the camera does not have MODE dial.

The figure below describes it in detail.
OPERATION MODE
SHOOTING PLAYBACK
MODE
P S A M C MOVIE
DRIVE MODE
Single Single Single Single Single 4K 16:9 29.97
100M

```
SINGLE
```
```
CL CL CL CL CL FHD 16:9 29.97
100M
CH CH CH CH CH DCI 16:9 29.97
100M
BKT BKT BKT BKT BKT ...
PIXEL SHIFT PIXEL SHIFT PIXEL SHIFT PIXEL SHIFT PIXEL SHIFT ... PIXEL SHIFT
... ... ... ... ... ... MOVIE
EXPOSURE MODE
P S A M P P
S S
A A
M M
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

In addition to the policies described above, GFX & X series cameras feature a policy for tethered shooting.
The physical dial or switch positions take precedence over electronic (software) settings.

**1.7. Camera Priority Mode / PC Priority Mode**
To support legacy models(FUJIFILM X-T3, FUJIFILM X-T4, FUJIFILM GFX 50S (firmware version 1.00, or 1.01,
USB connections ONLY), FUJIFILM X-Pro3, FUJIFILM GFX 50R, FUJIFILM GFX 100, FUJIFILM GFX100S
FUJIFILM X-S10 (firmware version 2.00 or later), FUJIFILM GFX50S II), the SDK offers a choice of “Camera Priority”
and “PC Priority” modes that determine whether photographs are taken using camera or computer controls.
In “Camera Priority” mode, users hold the camera or mount it on a tripod and adjust settings on the camera itself. Taken
images are transferred to the computer as they are taken for displaying in the computer monitor or saving onto computer
disks. Exposure and other settings are adjusted using the controls on the camera. The shutter is also released using the
release button on the camera.
In “PC Priority” mode, users can check the view-finder image or the LCD image from the computer. They also can
check and adjust camera settings remotely from the computer. Taken images are transferred to the computer as they are
taken for displaying in the computer monitor or saving onto computer disks. Exposure and other shooting settings are
adjusted remotely using the SDK APIs from the computer. The shutter is also released remotely using the SDK APIs
from the computer.
When the camera is powered on , the default mode selected is “Camera Priority”.
For recent models, the PC Priority Mode is available only for compatibility. You don’t need to use the PC Priority Mode.

**1.8. Controls related to movie recording**
The control related to movie recording are available only in the Camera Priority Mode
The DRIVE MODE have to be set to MOVIE MODE.
The DRIVE MODE can be set via the SDK for some models. Please refer to the XSDK_CapDriveMode API in detail.
Ther ◎(movie recording) button feture is not covered by these features.
Please note that some settings have defferent settings for still imaging shooting and for movie recording, and note that
icon in the camera menu.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

**2. State Diagram**

State State name Description
S0 Loaded The SDK library is loaded.
S1 Initialized The SDK has been initialized and is ready to use.
S2 Detected Available cameras are listed into the SDK’s internal table.
S3 Session A specified camera can be controlled.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

**3. API Overview**

API functions are classified as either “COMMON” (mandatory functions) and “MODEL DEPENDENT” (optional
functions).
The “COMMON APIs” can be used with all compatible cameras in the same manner.
The “MODEL DEPENDENT APIs” supported differ with the camera model. The parameters of “MODEL
DEPENDENT APIs” are also differ with the camera model.

All “COMMON APIs” are described in “XAPI.h”. “MODEL DEPENDENT APIs” are described in model-dependent
header files. For example, functions for the FUJIFILM GFX100S are described in “GFX100S.h”. Header files for
model-dependent functions sometimes reference “XAPIOpt.H”.
To load the SDK, you need only load “XAPI.dll” (Windows) or “XAPI.bundle” (macOS).

On Windows, macOS, or Linux, you need only to load “XAPI.dll” (Windows), “XAPI.bundle” (macOS), or “XAPI.so”
(Linux) to use the SDK.
On Android you need to load the wrapper so library to use the SDK.

*Windows/macOS

```
Layered Library Structure
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

*Linux

```
Layered Library Structure
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

*Android

```
Layered Library Structure
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

**3.1. COMMON APIs (Mandatory Functions)**
All SDK-compliant cameras support these mandatory functions.
**Function Description
Initialize/Finalize**
_XSDK_Init_ Initializes and starts use of the SDK.
_XSDK_Exit_ Finalizes and terminates use of the SDK.
**Enumeration**
_XSDK_Detect_ Enumerates available cameras and generates a connected camera list.
This API is not supported with the SDK for Android OS.
_XSDK_Append_ Update the connected camera list.
This API is not supported with the SDK for Android OS, since the SDK
for Android OS supports only one camera connection.
**Session Management**
_XSDK_OpenEx_ Establishes a session between the camera and the computer.
This API is not supported with the SDK for Android OS.
_XSDK_SetUSBDeviceHandle_ This API is supported only with the SDK for Android OS.
This API is called from the alternative code for XSDK_OpenEx.
This API provides opening camera feature on Android OS.
_XSDK_Close_ Closes the session between the camera and the computer.
_XSDK_PowerOFF_ Closes the session between the camera and the computer, and shut the
camera down.
**Basic Functions**
_XSDK_GetErrorNumber_ Gets the error details of the last called function.
_XSDK_GetErrorDetails_ Gets details of the busy error when the plERRCode returned by a call to
XSDK_GetErrorNumber is
XSDK_ERRCODE_RUNNING_OTHER_FUNCTION.
_XSDK_GetVersionString_ Gets version numbers in a string format.
**Device Information**
_XSDK_GetDeviceInfo_ Gets information about the connected camera.
_XSDK_GetDeviceInfoEx_ Gets information about the connected camera and supported APIs by the
camera.
_XSDK_WriteDeviceName_ Assigns a device-unique name to the camera.
_XSDK_GetFirmwareVersion_ Get the firmware version of the camera in string.
_XSDK_GetLensInfo_ Gets lens information from the camera.
_XSDK_GetLensVersion_ Gets the firmware version of the lens attached to the camera in a string
format.
**Camera Operation Mode**
_XSDK_CapPriorityMode_ Queries supported operation modes.
_XSDK_SetPriorityMode_ Sets the camera operation mode.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

_XSDK_GetPriorityMode_ Gets the current camera operation mode.
_XSDK_CapDriveMode_ Queries supported drive modes.
_XSDK_SetDriveMode_ Sets the camera drive mode.
_XSDK_GetDriveMode_ Gets the current camera drive mode.
_XSDK_CapMode_ Queries supported camera MODES.
_XSDK_SetMode_ Sets the camera MODE.
_XSDK_GetMode_ Gets the current camera MODE.
**Release Control**
_XSDK_CapRelease_ Queries supported release-related modes (shutter release, AE-L, AF-L,
...), when the system is in PC priority mode..
_XSDK_Release_ Triggers shutter release-related operations (shutter release, AE-L, AF-L,
...) when the system is in PC priority mode.
_XSDK_CapReleaseEx_ Queries supported release-related modes (shutter release, AE-L, AF-L, ...)
when the system is in CAMERA priority mode.
_XSDK_ReleaseEx_ Triggers shutter release-related operations (shutter release, AE-L, AF-L,
...) when the system is in CAMERA priority mode.
_XSDK_GetReleaseStatus_ Gets the status of release operation.
**Image Acquisition**
_XSDK_ReadImageInfo_ Gets information from an image from the top of the in-camera buffer.
_XSDK_ReadPreview_ Gets a low-resolution image of the image from the top of the in-camera
buffer.
_XSDK_ReadImage_ Gets a captured image from the top of the in-camera buffer and deletes it
from the buffer.
_XSDK_DeleteImage_ Deletes a captured image from the top of the in-camera buffer.
_XSDK_GetBufferCapacity_ Gets the status of the in-camera buffer.
**Exposure Control**
_XSDK_CapAEMode_ Queries supported exposure modes (P/A/S/M) to set.
_XSDK_SetAEMode_ Sets the exposure mode setting.
_XSDK_GetAEMode_ Gets the exposure mode setting.
_XSDK_CapShutterSpeed_ Queries supported shutter speeds to set.
_XSDK_SetShutterSpeed_ Sets the shutter speed value.
_XSDK_GetShutterSpeed_ Gets the shutter speed setting.
_XSDK_CapExposureBias_ Queries supported exposure compensations to set.
_XSDK_SetExposureBias_ Sets the exposure compensation value.
_XSDK_GetExposureBias_ Gets the exposure compensation setting.
_XSDK_CapDynamicRange_ Queries supported dynamic ranges to set.
_XSDK_SetDynamicRange_ Sets the dynamic range value.
_XSDK_GetDynamicRange_ Gets the dynamic range setting.
_XSDK_CapSensitivity_ Queries supported ISO sensitivities to set.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

_XSDK_SetSensitivity_ Sets the ISO sensitivity value.
_XSDK_GetSensitivity_ Gets the ISO sensitivity setting.
_XSDK_CapMeteringMode_ Queries supported metering modes to set.
_XSDK_SetMeteringMode_ Sets the metering mode.
_XSDK_GetMeteringMode_ Gets the metering mode setting.
_XSDK_CapLensZoomPos_ Queries supported zoom positions to set.
_XSDK_SetLensZoomPos_ Sets the zoom position.
_XSDK_GetLensZoomPos_ Gets the zoom position setting.
_XSDK_CapAperture_ Queries supported aperture values to set.
_XSDK_SetAperture_ Sets the aperture value.
_XSDK_GetAperture_ Gets the aperture setting.
**White Balance Control**
_XSDK_CapWBMode_ Queries supported white-balance modes to set.
_XSDK_SetWBMode_ Sets the white-balance mode.
_XSDK_GetWBMode_ Gets the white-balance mode setting.
_XSDK_CapWBColorTemp_ Queries supported color temperatures to set available when
WBMode=ColorTemperature.
_XSDK_SetWBColorTemp_ Sets the color temperature value for WBMode=ColorTemperature.
_XSDK_GetWBColorTemp_ Gets the color temperature setting for WBMode=ColorTemperature.
**Media Recording Control**
_XSDK_CapMediaRecord_ Queries supported media recording control modes to set.
_XSDK_SetMediaRecord_ Sets the media recording control modes for the tethering operation.
_XSDK_GetMediaRecord_ Gets the media recording control modes setting for the tethering
operation.
**Operation Mode Control**
_XSDK_CapForceMode_ Queries supported operation modes to set.
_XSDK_SetForceMode_ Forcibly changes the operating mode to SHOOTING MODE.
**Backup and Restore**
_XSDK_SetBackupSettingse_ Restore camera backup settings.
_XSDK_GetBackupSettings_ Backup camera settings.
**Movie Control**
_XSDK_CapMovieShutterSpeed_ Queries supported shutter speeds to set in movie mode.
_XSDK_SetMovieShutterSpeed_ Sets the shutter speed value in movie mode.
_XSDK_GetMovieShutterSpeed_ Gets the shutter speed setting in movie mode.
_XSDK_CapMovieExposureBias_ Queries supported exposure compensations to set in movie mode.
_XSDK_SetMovieExposureBias_ Sets the exposure compensation value in movie mode.
_XSDK_GetMovieExposureBias_ Gets the exposure compensation setting in movie mode.
_XSDK_CapMovieSensitivity_ Queries supported ISO sensitivities to set in movie mode.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

_XSDK_SetMovieSensitivity_ Sets the ISO sensitivity value in movie mode.
_XSDK_GetMovieSensitivity_ Gets the ISO sensitivity setting in movie mode.
_XSDK_CapMovieAperture_ Queries supported aperture values to set in movie mode.
_XSDK_SetMovieAperture_ Sets the aperture value in movie mode.
_XSDK_GetMovieAperture_ Gets the aperture setting in movie mode.
_XSDK_CapMovieDynamicRange_ Queries supported dynamic ranges to set in movie mode.
_XSDK_SetMovieDynamicRange_ Sets the dynamic range value in movie mode.
_XSDK_GetMovieDynamicRange_ Gets the dynamic range setting in movie mode.
_XSDK_CapMovieMeteringMode_ Queries supported metering modes to set in movie mode.
_XSDK_SetMovieMeteringMode_ Sets the metering mode in movie mode.
_XSDK_GetMovieMeteringMode_ Gets the metering mode setting in movie mode.
_XSDK_CapMovieWBMode_ Queries supported white-balance modes to set in movie mode.
_XSDK_SetMovieWBMode_ Sets the white-balance mode in movie mode.
_XSDK_GetMovieWBMode_ Gets the white-balance mode setting in movie mode.
_XSDK_CapMovieWBColorTemp_ Queries supported color temperatures to set available in movie mode
when WBMode = ColorTemperature.
_XSDK_SetMovieWBColorTemp_ Sets the color temperature value in movie mode for WBMode =
ColorTemperature.
_XSDK_GetMovieWBColorTemp_ Gets the movie color temperature setting in movie mode for WBMode =
ColorTemperature.
**Model Dependent Function Interface**
_XSDK_CapProp_ Queries supported values for a model-dependent function.
_XSDK_SetProp_ Sets values for the model-dependent function.
_XSDK_GetProp_ Gets the settings for the model-dependent function.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

**3.2. MODEL DEPENDENT APIs (Optional Functions)**
Some cameras support the optional model-dependent functions listed below. These functions can be called via the
“XSDK_CapProp”, “XSDK_GetProp”, and “XSDK_SetProp” functions.
**Function Description
Focus Control**
_CapFocusMode_ Queries supported focus modes.
_SetFocusMode_ Sets the focus mode.
_GetFocusMode_ Gets the focus mode setting.
_CapAFMode_ Queries supported AF modes.
_SetAFMode_ Sets the AF MODE setting.
_GetAFMode_ Gets the AF MODE setting.
_CapFocusArea_ Queries supported FOCUS AREA and focus area-size settings.
_SetFocusArea_ Sets the FOCUS AREA and focus area-size settings.
_GetFocusArea_ Gets the FOCUS AREA and focus area-size settings.
_CapShutterPriorityMode_ Queries supported RELEASE/FOCUS PRIORITY settings for AF-S or
AF-C.
_SetShutterPriorityMode_ Sets the RELEASE/FOCUS PRIORITY setting for AF-S or AF-C.
_GetShutterPriorityMode_ Gets the RELEASE/FOCUS PRIORITY setting for AF-S or AF-C.
_CapFaceDetectionMode_ Queries supported FACE DETECTION modes.
_SetFaceDetectionMode_ Sets the FACE DETECTION mode.
_GetFaceDetectionMode_ Gets the FACE DETECTION mode.
_CapEyeAFMode_ Queries supported EYE AF modes.
_SetEyeAFMode_ Sets the EYE AF mode.
_GetEyeAFMode_ Gets the EYE AF mode.
_CapSubjectDetectionMode_ Queries supported subject detection modes.
_SetSubjectDetectionMode_ Sets the subject detection mode.
_GetSubjectDetectionMode_ Gets the subject detection mode.
_CapFullTimeManualFocus_ Queries supported AF+MF modes.
_SetFullTimeManualFocus_ Sets the AF+MF mode.
_GetFullTimeManualFocus_ Gets the AF+MF mode.
_CapFocusPoints_ Queries supported options for selecting the NUMBER OF FOCUS
POINTS.
_SetFocusPoints_ Sets the NUMBER OF FOCUS POINTS.
_GetFocusPoints_ Gets the NUMBER OF FOCUS POINTS.
_CapInstantAFMode_ Queries supported INSTANT AF SETTING options.
_SetInstantAFMode_ Sets the INSTANT AF SETTING.
_GetInstantAFMode_ Gets the INSTANT AF SETTING.
_CapPreAFMode_ Queries supported PRE-AF settings.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

_SetPreAFMode_ Sets the PRE-AF setting.
_GetPreAFMode_ Gets the PRE-AF setting.
_CapAFIlluminator_ Queries supported AF ILLUMINATOR settings.
_SetAFIlluminator_ Sets the AF ILLUMINATOR setting.
_GetAFIlluminator_ Gets the AF ILLUMINATOR setting.
_CapFocusPos_ Queries the focus positions to set available in manual focus mode.
_SetFocusPos_ Sets the focus position for manual focus mode.
_GetFocusPos_ Gets the focus position for manual focus mode.
_CapFocusLimiterPos_ Queries available AF search ranges (near/far) for focus limiter 1(custom).
_SetFocusLimiterPos_ Sets the current focus position to one of endpoints of a focus limiter.
_GetFocusLimiterIndicator_ Gets a information for the current focus limiter.
Usable for drawing a focus indicator.
_GetFocusLimiterRange_ Gets a list of the endpoints for available focus limiters in specified unit.
_CapFocusLimiterMode_ Queries available focus limiter selections.
_SetFocusLimiterMode_ Sets the focus limiter selection.
_GetFocusLimiterMode_ Gets the current focus limiter selection.
_CapFocusSpeed_ Queries available focus speed selecitons.
_SetFocusSpeed_ Sets the focus speed seleciton.
_GetFocusSpeed_ Gets the current focus speed selection.
_CapFocusOperation_ Queries available focus operations.
_SetFocusOperation_ Triggers the focus operation.
_CapAFZoneCustom_ Queries supported _ZONE CUSTOM_ settings
_SetAFZoneCustom_ Sets the _ZONE CUSTOM_ setting.
_GetAFZoneCustom_ Gets the _ZONE CUSTOM_ setting.
**Crop Control**
_CapCropMode_ Queries supported crop modes.
_SetCropMode_ Sets the crop mode.
_GetCropMode_ Gets the crop mode.
_CapCropZoom_ Queries available crop zoom magnification ratios.
_SetCropZoom_ Sets the crop zoom magnification ratio.
_GetCropZoom_ Gets the current crop zoom magnification ratio.
**Zoom Control**
_CapZoomSpeed_ Queries available zoom speed selections.
_SetZoomSpeed_ Sets the zoom speed selection.
_GetZoomSpeed_ Gets the current zoom speed selection.
_CapZoomOperation_ Queries available zoom operations.
_SetZoomOperation_ Triggers the zoom operation.
**Exposure Control**


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

_CapInterlockAEAFArea_ Queries supported modes for INTERLOCK AE SPOT AND AF
POSITION.
_SetInterlockAEAFArea_ Sets the INTERLOCK AE SPOT AND AF POSITION mode.
_GetInterlockAEAFArea_ Gets the INTERLOCK AE APOT AND AF POSITION mode.
_CapHighFrequencyFlickerlessMode_ Queries supported modes for FLICKERLESS S.S. SETTING.
_SetHighFrequencyFlickerlessMode_ Sets the FLICKERLESS S.S. SETTING.
_GetHighFrequencyFlickerlessMode_ Gets the FLICKERLESS S.S. SETTING.
**Image Size / Quality**
_CapImageSize_ Queries supported IMAGE SIZE settings.
_SetImageSize_ Sets the IMAGE SIZE setting.
_GetImageSize_ Gets the IMAGE SIZE setting.
_CapImageQuality_ Queries supported IMAGE QUALITY settings.
_SetImageQuality_ Sets the IMAGE QUALITY setting.
_GetImageQuality_ Gets the IMAGE QUALITY setting.
_CapRAWCompression_ Queries supported RAW COMPRESSION/RAW RECORDING TYPE
settings.
_SetRAWCompression_ Sets the RAW COMPRESSION / RAW RECORDING TYPE setting.
_GetRAWCompression_ Gets the RAW COMPRESSION / RAW RECORDING TYPE setting.
_SetRAWOutputDepth_ Sets the RAW RECORDING OUTPUT DEPTH setting.
_GetRAWOutputDepth_ Gets the RAW RECORDING OUTPUT DEPTH setting.
**White Balance**
_CapWhiteBalanceTune_ Queries supported WHITE BALANCE SHIFT settings.
_SetWhiteBalanceTune_ Sets the WHITE BALANCE SHIFT settings.
_GetWhiteBalanceTune_ Gets the WHITE BALANCE SHIFT settings.
**Film Simulation**
_CapFilmSimulationMode_ Queries supported FILM SIMULATION settings.
_SetFilmSimulationMode_ Sets the FILM SIMULATION setting.
_GetFilmSimulationMode_ Gets the FILM SIMULATION setting.
_CapGrainEffect_ Queries supported GRAIN EFFECT settings.
_SetGrainEffect_ Sets the GRAIN EFFECT setting.
_GetGrainEffect_ Gets the GRAIN EFFECT setting.
_CapMonochromaticColor_ Queries supported MONOCHROMATIC COLOR settings.
_SetMonochromaticColor_ Sets the MONOCHROMATIC COLOR settings.
_GetMonochromaticColor_ Gets the MONOCHROMATIC COLOR settings.
**Image Quality Control**
_CapSharpness_ Queries supported SHARPNESS settings.
_SetSharpness_ Sets the SHARPNESS setting.
_GetSharpness_ Gets the SHARPNESS setting.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

_CapColorMode_ Queries supported saturation (COLOR) settings.
_SetColorMode_ Sets the COLOR setting.
_GetColorMode_ Gets the COLOR setting.
_CapHighLightTone_ Queries supported HIGHLIGHT TONE settings.
_SetHighLightTone_ Sets the HIGHLIGHT TONE setting.
_GetHighLightTone_ Gets the HIGHLIGHT TONE setting.
_CapShadowTone_ Queries supported SHADOW TONE settings.
_SetShadowTone_ Sets the SHADOW TONE setting.
_GetShadowTone_ Gets the SHADOW TONE setting.
_CapShadowing_ Queries supported values for COLOR CHROME EFFECT.
_SetShadoing_ Sets the COLOR CHROME EFFECT setting.
_GetShadowing_ Gets the COLOR CHROME EFFECT setting.
_CapWideDynamicRange_ Queries supported D RANGE PRIORITY settings.
_SetWideDynamicRange_ Sets the D RANGE PRIORITY setting.
_GetWideDynamicRange_ Gets the current D RANGE PRIORITY setting.
_CapColorChromeBlue_ Queries supported COLOR CHROME FX BLUE settings.
_SetColorChromeBlue_ Sets the COLOR CHROME FX BLUE setting.
_GetColorChromeBlue_ Gets the COLOR CHROME FX BLUE setting.
_CapClarityMode_ Queries supported CLARITY values.
_SetClarityMode_ Sets the CLARITY setting.
_GetClarityMode_ Gets the CLARITY setting.
_SetSmoothSkinEffect_ Sets the SMOOTH SKIN EFFECT setting.
_GetSmoothSkinEffect_ Gets the SMOOTH SKIN EFFECT setting.
_CapNoiseReduction_ Queries supported NOISE REDUCTION/HIGH ISO NR settings.
_SetNoiseReduction_ Sets the NOISE REDUCTION/HIGH ISO NR setting.
_GetNoiseReduction_ Gets the NOISE REDUCTION/HIGH ISO NR setting.
_CapLMOMode_ Queries supported LENS MODULATION OPTIMIZER settings.
_SetLMOMode_ Sets the LENS MODULATION OPTIMIZER setting.
_GetLMOMode_ Gets the LENS MODULATION OPTIMIZER setting.
_CapLongExposureNR_ Queries supported LONG EXPOSURE NR settings.
_SetLongExposureNR_ Sets the LONG EXPOSURE NR setting.
_GetLongExposureNR_ Gets the LONG EXPOSURE NR setting.
**Self Timer**
_CapCaptureDelay_ Queries supported SELF-TIMER duration settings.
_SetCaptureDelay_ Sets the SELF-TIMER setting.
_GetCaptureDelay_ Gets the SELF-TIMER setting.
**SET-UP**
_SetDateTime_ Sets the DATE/TIME settings.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

_GetDateTime_ Gets the DATE/TIME settings.
_SetDateTimeDispFormat_ Sets the DATE/TIME format.
_GetDateTimeDispFormat_ Gets the DATE/TIME format.
_CapWorldClock_ Queries supported HOME, LOCAL settings.
_SetWorldClock_ Sets the HOME or LOCAL setting.
_GetWorldClock_ Gets the HOME or LOCAL setting.
_CapTimeDifference_ Queries supported TIME DIFFERENCE settings.
_SetTimeDifference_ Sets the TIME DIFFERENCE settings.
_GetTimeDifference_ Gets the TIME DIFFERENCE settings.
_CapSummerTime_ Queries supported DAYLIGHT SAVINGS settings.
_SetSummerTime_ Sets DAYLIGHT SAVINGS setting.
_GetSummerTime_ Gets the DAYLIGHT SAVINGS setting.
_CapResetSetting_ Queries supported reset options.
_ResetSetting_ Executes RESET setting.
_CapExposurePreview_ Queries supported PREVIEW EXP./WB IN MANUAL MODE settings.
_SetExposurePreview_ Sets the PREVIEW EXP./WB IN MANUAL MODE setting.
_GetExposurePreview_ Gets the PREVIEW EXP./WB IN MANUAL MODE setting.
_CapFrameGuideMode_ Queries supported FRAMING GUIDELINE settings.
_SetFrameGuideMode_ Sets the FRAMING GUIDELINE setting.
_GetFrameGuideMode_ Gets the FRAMING GUIDELINE setting.
_SetFrameGuideGridInfo_ Sets the custom FRAMING GUIDELINE.
_GetFrameGuideGridInfo_ Gets the custom FRAMING GUIDELINE.
_CapFocusScaleUnit_ Queries supported focus distance units.
_SetFocusScaleUnit_ Sets the focus distance unit.
_GetFocusScaleUnit_ Gets the focus distance unit.
_SetFilenamePrefix_ Sets the EDIT FILE NAME setting.
_GetFilenamePrefix_ Gets the EDIT FILE NAME setting.
_CapLockButtonMode_ Queries supported AE/AF LOCK MODE settings.
_SetLockButtonMode_ Sets the AE/AF LOCK MODE setting.
_GetLockButtonMode_ Gets the AE/AF LOCK MODE setting.
_CapColorSpace_ Queries supported COLOR SPACE settings.
_SetColorSpace_ Sets the COLOR SPACE setting.
_GetColorSpace_ Gets the COLOR SPACE setting.
_CapFunctionLock_ Queries supported LOCK SETTINGs.
_SetFunctionLock_ Sets the LOCK SETTING.
_GetFunctionLock_ Gets the LOCK SETTING.
_CapFunctionLockCategory_ Queries the supported FUNCTION SELECTIONS for SELECTED
FUNCTION LOCK.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

_SetFunctionLockCategory_ Sets the FUNCTION SELECTIONS for SELECTED FUNCTION
LOCK.
_GetFunctionLockCategory_ Gets the FUNCTION SELECTIONS for SELECTED FUNCTION
LOCK.
_CapFormatMemoryCard_ Queries supported memory card slots.
_FormatMemoryCard_ Executes the FORMAT procedure.
_CapCustomDispInfo_ Queries the supported DISP. CUSTOM SETTINGs.
_SetCustomDispInfo_ Sets the DISP. CUSTOM SETTING.
_GetCustomDispInfo_ Gets the DISP. CUSTOM SETTING.
_GetTransparentFrameInfo_ Gets the Transparent frame information.
_CapMaskSetting_ Queries the supported SURROUND VIEW settings.
_SetMaskSetting_ Sets the SURROUND VIEW setting.
_GetMaskSetting_ Gets the SURROUND VIEW setting.
**Image Stabilization**
_CapLensISSwitch_ Queries the available lens IS switch settings to set.
_SetLensISSwitch_ Sets the lens IS switch mode.
_GetLensISSwitch_ Gets the lens IS switch mode.
_CapISMode_ Queries supported IS MODE settings.
_SetISMode_ Sets the IS MODE setting.
_GetISMode_ Gets the IS MODE setting.
**Save Image Metatags**
_SetComment_ Sets the comment tag strings to be saved in images.
_GetComment_ Gets the comment tag strings to be saved in images.
_SetCopyright_ Sets the copyright tag strings to be saved in images.
_GetCopyright_ Gets the copyright tag strings to be saved in images.
**Camera Information**
_CheckBatteryInfo_ Gets the battery status.
_GetShutterCount_ Gets the shutter counter.
_GetShutterCountEx_ Gets the count for the front-curtain shutter.
_GetTiltShiftLensStatus_ Gets tilt/shift lens status from the camera.
**Media Control**
_GetMediaCapacity_ Gets recording media capacity.
_GetMediaStatus_ Gets recording media status.
**Display Control**
_CapMFAssistMode_ Queries supported MF ASSIST MODE settings.
_SetMFAssistMode_ Sets the MF ASSIST MODE setting
_GetMFAssistMode_ Gets the MF ASSIST MODE setting
_CapFocusCheckMode_ Queries supported FOCUS CHECK MODE settings.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

_SetFocusCheckMode_ Sets the FOCUS CHECK MODE setting
_GetFocusCheckMode_ Gets the FOCUS CHECK MODE setting
_CapViewMode_ Queries supported VIEW MODE settings.
_SetViewMode_ Sets the VIEW MODE setting.
_GetViewMode_ Gets the VIEW MODE setting.
**Live View**
_StartLiveView_ Starts live view.
_StopLiveView_ Ends live view.
_CapLiveViewImageQuality_ Queries supported live view image quality settings.
_SetLiveViewImageQuality_ Sets the live view image quality setting.
_GetLiveViewImageQuality_ Gets the live view image quality setting.
_CapLiveViewImageSize_ Queries supported live view image size settings.
_SetLiveViewImageSize_ Sets the live view image size setting.
_GetLiveViewImageSize_ Gets the live view image size setting.
_CapThroughImageZoom_ Queries supported live view zoom ratio settings.
_SetThroughImageZoom_ Sets the live view zoom ratio setting.
_GetThroughImageZoom_ Gets the live view zoom ratio setting.
_GetLiveViewStatus_ Gets live view status.
**Movie Control - MOVIE SETTING**
_CapMovieImageFormat_ Queries supported IMAGE FORMAT settings.
_SetMovieImageFormat_ Sets the IMAGE FORMAT setting.
_GetMovieImageFormat_ Gets the IMAGE FORMAT setting.
_CapAnamorphicDesqueezeDisplay_ Queries supported DESQUEEZE DISPLAY IN RECODING settings.
_SetAnamorphicDesqueezeDisplay_ Sets the DESQUEEZE DISPLAY IN RECODING setting.
_GetAnamorphicDesqueezeDisplay_ Get the DESQUEEZE DISPLAY IN RECODING setting.
_CapAnamorphicMagnification_ Queries supported MAGNIFICATION settings.
_SetAnamorphicMagnification_ Sets the MAGNIFICATION setting.
_GetAnamorphicMagnification_ Gets the MAGNIFICATION setting.
_CapMovieResolution_ Queries supported MOVIE MODE settings.
_SetMovieResolution_ Sets the MOVIE MODE setting.
_GetMovieResolution_ Gets the MOVIE MODE setting.
_CapMovieFrameRate_ Queries supported MOVIE MODE settings.
_SetMovieFrameRate_ Sets the MOVIE MODE setting.
_GetMovieFrameRate_ Gets the MOVIE MODE setting.
_CapHighSpeedRecMode_ Queries supported HIGH SPEED REC settings.
_SetHighSpeedRecMode_ Sets the HIGH SPEED REC setting.
_GetHighSpeedRecMode_ Gets the HIGH SPEED REC setting.
_CapHighSpeedRecResolution_ Queries supported HIGH SPEED REC settings.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

_SetHighSpeedRecResolution_ Sets the HIGH SPEED REC setting.
_GetHighSpeedRecResolution_ Gets the HIGH SPEED REC setting.
_CapHighSpeedRecFrameRate_ Queries supported HIGH SPEED REC settings.
_SetHighSpeedRecFrameRate_ Sets the HIGH SPEED REC setting.
_GetHighSpeedRecFrameRate_ Gets the HIGH SPEED REC setting.
_CapHighSpeedRecPlayBackFrameRate_ Queries supported HIGH SPEED REC settings.
_SetHighSpeedRecPlayBackFrameRate_ Sets the HIGH SPEED REC setting.
_GetHighSpeedRecPlayBackFrameRate_ Gets the HIGH SPEED REC setting.
_CapMovieCaptureDelay_ Queries supported SELF TIMER settings.
_SetMovieCaptureDelay_ Sets the SELF TIMER setting.
_GetMovieCaptureDelay_ Get the SELF TIMER setting.
_CapMovieMediaRecord_ Queries supported MEDIA REC SETTING settings.
_SetMovieMediaRecord_ Sets the MEDIA REC SETTING setting.
_GetMovieMediaRecord_ Gets the MEDIA REC SETTING setting.
_CapMovieBitRate_ Queries supported MEDIA REC SETTING settings.
_SetMovieBitRate_ Sets the MEDIA REC SETTING setting.
_GetMovieBitRate_ Gets the MEDIA REC SETTING setting.
_CapMovieFileFormat_ Queries supported MEDIA REC SETTING settings.
_SetMovieFileFormat_ Sets the MEDIA REC SETTING setting.
_GetMovieFileFormat_ Gets the MEDIA REC SETTING setting.
_CapMovieMediaRecordProRes_ Queries supported PROXY SETTING settings.
_SetMovieMediaRecordProRes_ Sets the PROXY SETTING setting.
_GetMovieMediaRecordProRes_ Gets the PROXY SETTING setting.
_GetMediaEjectWarning_ Gets the media eject warning information.
_CapMovieHDMIOutputInfoDisplay_ Queries supported HDMI OUTPUT INFO DISPLAY settings.
_SetMovieHDMIOutputInfoDisplay_ Sets the HDMI OUTPUT INFO DISPLAY setting.
_GetMovieHDMIOutputInfoDisplay_ Gets the HDMI OUTPUT INFO DISPLAY setting.
_CapMovieHDMIRecControl_ Queries supported HDMI REC CONTROL settings.
_SetMovieHDMIRecControl_ Sets the HDMI REC CONTROL setting.
_GetMovieHDMIRecControl_ Gets the HDMI REC CONTROL setting.
_CapMovieHDMIOutputRAW_ Queries supported RAW OUTPUT SETTING settings.
_SetMovieHDMIOutputRAW_ Sets the RAW OUTPUT SETTING setting.
_GetMovieHDMIOutputRAW_ Gets the RAW OUTPUT SETTING setting.
_CapMovieHDMIOutputRAWResolution_ Queries supported RAW OUTPUT SETTING settings.
_SetMovieHDMIOutputRAWResolution_ Sets the RAW OUTPUT SETTING setting.
_GetMovieHDMIOutputRAWResolution_ Gets the RAW OUTPUT SETTING setting.
_CapMovieHDMIOutputRAWFrameRate_ Queries supported RAW OUTPUT SETTING settings.
_SetMovieHDMIOutputRAWFrameRate_ Sets the RAW OUTPUT SETTING setting.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

_GetMovieHDMIOutputRAWFrameRate_ Gets the RAW OUTPUT SETTING setting.
_CapMovieCropMagnification_ Queries supported FIX MOVIE CROP MAGNIFICATION settings.
_SetMovieCropMagnification_ Sets the FIX MOVIE CROP MAGNIFICATION setting.
_GetMovieCropMagnification_ Gets the FIX MOVIE CROP MAGNIFICATION setting.
_GetMovieCropMagnificationValue_ Gets the MOVIE CROP MAGNIFICATION value.
_CapFlogRecording_ Queries supported F-Log/HLG RECODING settings.
_SetFlogRecording_ Sets the F-Log/HLG RECODING setting.
_GetFlogRecording_ Gets the F-Log/HLG RECODING setting.
_CapMovieDataLevelSetting_ Queries supported DATA LEVEL SETTING settings.
_SetMovieDataLevelSetting_ Sets the DATA LEVEL SETTING setting.
_GetMovieDataLevelSetting_ Gets the DATA LEVEL SETTING setting.
_CapMovieHighFrequencyFlickerlessMode_ Queries supported FLICKERLESS S.S. SETTING settings.
_SetMovieHighFrequencyFlickerlessMode_ Sets the FLICKERLESS S.S. SETTING setting.
_GetMovieHighFrequencyFlickerlessMode_ Gets the FLICKERLESS S.S. SETTING setting.
_CapMovieIsMode_ Queries supported IS MODE settings.
_SetMovieIsMode_ Sets the IS MODE setting.
_GetMovieIsMode_ Gets the IS MODE setting.
_CapMovieIsModeBoost_ Queries supported IS MODE BOOST settings.
_SetMovieIsModeBoost_ Sets the IS MODE BOOST setting.
_GetMovieIsModeBoost_ Gets the IS MODE BOOST setting.
_CapMovieZebraSetting_ Queries supported ZEBRA SETTING settings.
_SetMovieZebraSetting_ Sets the ZEBRA SETTING setting.
_GetMovieZebraSetting_ Gets the ZEBRA SETTING setting.
_CapMovieZebraLevel_ Queries supported ZEBRA LEVEL settings.
_SetMovieZebraLevel_ Sets the ZEBRA LEVEL setting.
_GetMovieZebraLevel_ Gets the ZEBRA LEVEL setting.
_CapWaveFormVectorScope_ Queries supported WAVE FORM/VECTOR SCOPE settings.
_SetWaveFormVectorScope_ Sets the WAVE FORM/VECTOR SCOPE setting.
_GetWaveFormVectorScope_ Get the WAVE FORM/VECTOR SCOPE setting.
_GetWaveFormData_ Get the WaveForm data.
_GetVectorScopeData_ Gets the VECTOR SCOPE data.
_GetParadeData_ Gets the PARADE data.
_CapWaveFormSetting_ Queries supported WAVEFORM settings.
_SetWaveFormSetting_ Sets the WAVEFORM setting.
_GetWaveFormSetting_ Gets the WAVEFORM setting.
_CapVectorScopeSetting_ Queries supported VECTORSCOPE settings.
_SetVectorScopeSetting_ Sets the VECTORSCOPE setting.
_GetVectorScopeSetting_ Gets the VECTORSCOPE setting.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

_CapParadeSettingDisplay_ Queries supported PARADE SETTING (SWICH DISP.) settings.
_SetParadeSettingDisplay_ Sets the PARADE SETTING (SWICH DISP.) setting
_GetParadeSettingDisplay_ Gets the PARADE SETTING (SWICH DISP.) setting
_CapParadeSettingColor_ Queries supported PARADE SETTING (COLOR) settings.
_SetParadeSettingColor_ Sets the PARADE SETTING (COLOR) setting
_GetParadeSettingColor_ Gets the PARADE SETTING (COLOR) setting
_CapMovieOptimizedControl_ Queries supported MOVIE OPTIMIZED MODE settongs.
_SetMovieOptimizedControl_ Sets the MOVIE OPTIMIZED MODE setting.
_GetMovieOptimizedControl_ Gets the MOVIE OPTIMIZED MODE setting.
_CapRecFrameIndicator_ Queries supported REC FRAME INDICATOR settings.
_SetRecFrameIndicator_ Sets the REC FRAME INDICATOR setting.
_GetRecFrameIndicator_ Get the REC FRAME INDICATOR setting.
_CapMovieTallyLight_ Queries supported TALLY LAMP settings.
_SetMovieTallyLight_ Sets the TALLY LAMP settng.
_GetMovieTallyLight_ Gets the TALLY LAMP setting.
_CapFanSetting_ Queries supported COOLING FAN SETTING settings.
_SetFanSetting_ Sets the COOLING FAN SETTING setting.
_GetFanSetting_ Gets the COOLING FAN SETTING setting.
_SetMovieCustomSetting_ Sets the EDIT/SAVE CUSTOM SETTING setting.
_SetMovieCustomName_ Sets the EDIT/SAVE CUSTOM SETTING name.
_GetMovieCustomName_ Gets the EDIT/SAVE CUSTOM SETTING name.
_CapMovieDigitalZoom_ Queries supported DIGITAL TELE-CONV. settings.
_SetMovieDigitalZoom_ Sets the DIGITAL TELE-CONV. setting.
_GetMovieDigitalZoom_ Gets the DIGITAL TELE-CONV. setting.
_GetMovieDigitalZoomRange_ Gets the DIGITAL TELE-CONV. RANGE setting.
_GetMovieRecordingTime_ Gets the RECORDING TIME.
_GetMovieRemainingTime_ Gets the REMAINING TIME.
_GetHistogramData_ Gets the HISTOGRAM data.
_GetBodyTemperatureWarning_ Gets the TEMPERATURE LIMIT information.
_CapShortMovieSecond_ Queries supported SHORT MOVIE MODE SECONDS SETUP settings.
_SetShortMovieSecond_ Sets the SHORT MOVIE MODE SECONDS SETUP setting.
_GetShortMovieSecond_ Gets the SHORT MOVIE MODE SECONDS SETUP setting.
_GetMovieTransparentFrameInfo_ Gets the Transparent frame information.
**Movie Control - IMAGE QUALITY SETTING**
_CapMovieFilmSimulationMode_ Queries supported FILM SIMULATION settings.
_SetMovieFilmSimulationMode_ Sets the FILM SIMULATION setting.
_GetMovieFilmSimulationMode_ Gets the FILM SIMULATION setting.
_CapMovieMonochromaticColor_ Queries supported MONOCHROMATIC COLOR settings.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

_SetMovieMonochromaticColor_ Sets the MONOCHROMATIC COLOR setting.
_GetMovieMonochromaticColor_ Gets the MONOCHROMATIC COLOR setting.
_CapMovieWhiteBalanceTune_ Queries supported WHITE BALANCE settings.
_SetMovieWhiteBalanceTune_ Sets the WHITE BALANCE setting.
_GetMovieWhiteBalanceTune_ Gets the WHITE BALANCE setting.
_CapMovieHighLightTone_ Queries supported TONE CURVE(HIGHLIGHTS) settings.
_SetMovieHighLightTone_ Sets the TONE CURVE(HIGHLIGHTS) setting.
_GetMovieHighLightTone_ Gets the TONE CURVE(HIGHLIGHTS) setting.
_CapMovieShadowTone_ Queries supported TONE CURVE(SHADOWS) settings.
_SetMovieShadowTone_ Sets the TONE CURVE(SHADOWS) setting.
_GetMovieShadowTone_ Gets the TONE CURVE(SHADOWS) setting.
_CapMovieColorMode_ Queries supported COLOR settings.
_SetMovieColorMode_ Sets the COLOR setting.
_GetMovieColorMode_ Gets the COLOR setting.
_CapMovieSharpness_ Queries supported SHARPNESS settings.
_SetMovieSharpness_ Sets the SHARPNESS setting.
_GetMovieSharpness_ Gets the SHARPNESS setting.
_CapMovieNoiseReduction_ Queries supported HIGH ISO NR settings.
_SetMovieNoiseReduction_ Sets the HIGH ISO NR setting.
_GetMovieNoiseReduction_ Gets the HIGH ISO NR setting.
_CapInterFrameNR_ Queries supported INTERFRAME NR settings.
_SetInterFrameNR_ Sets the INTERFRAME NR setting.
_GetInterFrameNR_ Gets the INTERFRAME NR setting.
_CapFlogDRangePriority_ Queries supported F-LOG2 D RANGE PRIORITY settings.
_SetFlogDRangePriority_ Sets the F-LOG2 D RANGE PRIORITY setting.
_GetFlogDRangePriority_ Gets the F-LOG2 D RANGE PRIORITY setting.
_CapMoviePeripheralLightCorrection_ Queries supported PERIPHERAL LIGHT CORRECTION settings.
_SetMoviePeripheralLightCorrection_ Sets the PERIPHERAL LIGHT CORRECTION setting.
_GetMoviePeripheralLightCorrection_ Gets the PERIPHERAL LIGHT CORRECTION setting.
_CapMoviePortraitEnhancer_ Queries supported MOVIE BEAUTIFUL SKIN PROCESSING settings.
_SetMoviePortraitEnhancer_ Sets the MOVIE BEAUTIFUL SKIN PROCESSING setting.
_GetMoviePortraitEnhancer_ Gets the MOVIE BEAUTIFUL SKIN PROCESSING setting.
**Movie Control - AF/MF SETTING**
_CapMovieFocusArea_ Queries supported FOCUS AREA settings.
_SetMovieFocusArea_ Sets the FOCUS AREA setting.
_GetMovieFocusArea_ Gets the FOCUS AREA setting.
_CapMovieAFMode_ Queries supported AF MODE settings.
_SetMovieAFMode_ Sets the AF MODE setting.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

_GetMovieAFMode_ Gets the AF MODE setting.
_CapMovieAFCCustom_ Queries supported AF-C CUSTOM SETTINGS settings.
_SetMovieAFCCustom_ Sets the AF-C CUSTOM SETTINGS setting.
_GetMovieAFCCustom_ Gets the AF-C CUSTOM SETTINGS setting.
_CapMovieEyeAFMode_ Queries supported FACE/EYE DETECTION SETTING settings.
_SetMovieEyeAFMode_ Sets the FACE/EYE DETECTION SETTING setting.
_GetMovieEyeAFMode_ Gets the FACE/EYE DETECTION SETTING setting.
_CapMovieFaceDetectionMode_ Queries supported FACE DETECTION SETTING settings.
_SetMovieFaceDetectionMode_ Sets the FACE DETECTION SETTING setting.
_GetMovieFaceDetectionMode_ Gets the FACE DETECTION SETTING setting.
_CapMovieSubjectDetectionMode_ Queries supported SUBJECT DETECTION SETTING settings.
_SetMovieSubjectDetectionMode_ Sets the SUBJECT DETECTION SETTING setting.
_GetMovieSubjectDetectionMode_ Gets the SUBJECT DETECTION SETTING setting.
_GetTrackingAfFrameInfo_ Gets the subject detection tracking AF framing outline information.
_CapMovieFullTimeManual_ Queries supported AF+MF settings.
_SetMovieFullTimeManual_ Sets the M AF+MF setting.
_GetMovieFullTimeManual_ Gets the AF+MF setting.
_CapMovieMFAssistMode_ Queries supported MF ASSIST settings.
_SetMovieMFAssistMode_ Sets the MF ASSIST setting.
_GetMovieMFAssistMode_ Gets the MF ASSIST setting.
_CapMovieFocusCheckMode_ Queries supported FOCUS CHECK settings.
_SetMovieFocusCheckMode_ Sets the FOCUS CHECK setting.
_GetMovieFocusCheckMode_ Gets the FOCUS CHECK setting.
_CapMovieFocusCheckLock_ Queries supported FOCUS CHECK LOCK settings.
_SetMovieFocusCheckLock_ Sets the FOCUS CHECK LOCK setting.
_GetMovieFocusCheckLock_ Gets the FOCUS CHECK LOCK setting.
_GetFocusMapData_ Gets the FUCUS MAP data.
_GetMovieFocusMeter_ Gets the FOCUS METER status.
**Movie Control - AUDIO SETTING**
_CapInternalMicLevel_ Queries supported INTERNAL MIC LEVEL ADJUSTMENT settings.
_SetInternalMicLevel_ Sets the INTERNAL MIC LEVEL ADJUSTMENT setting.
_GetInternalMicLevel_ Gets the INTERNAL MIC LEVEL ADJUSTMENT setting.
_CapInternalMicLevelManual_ Queries supported INTERNAL MIC LEVEL ADJUSTMENT
(MANUAL) settings.
_SetInternalMicLevelManual_ Sets the INTERNAL MIC LEVEL ADJUSTMENT (MANUAL) setting.
_GetInternalMicLevelManual_ Gets the INTERNAL MIC LEVEL ADJUSTMENT (MANUAL) setting.
_CapExternalMicLevel_ Queries supported EXTERNAL MIC LEVEL ADJUSTMENT settings.
_SetExternalMicLevel_ Sets the EXTERNAL MIC LEVEL ADJUSTMENT setting.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

_GetExternalMicLevel_ Sets the EXTERNAL MIC LEVEL ADJUSTMENT setting.
_CapExternalMicLevelManual_ Queries supported EXTERNAL MIC LEVEL ADJUSTMENT
(MANUAL) settings.
_SetExternalMicLevelManual_ Sets the EXTERNAL MIC LEVEL ADJUSTMENT (MANUAL) setting.
_GetExternalMicLevelManual_ Gets the EXTERNAL MIC LEVEL ADJUSTMENT (MANUAL) setting.
_CapMicLevelLimiter_ Queries supported MIC LEVEL LIMITER settings.
_SetMicLevelLimiter_ Sets the MIC LEVEL LIMITER setting.
_GetMicLevelLimiter_ Gets the MIC LEVEL LIMITER setting.
_CapWindFilter_ Queries supported WIND FILTER settings.
_SetWindFilter_ Sets the WIND FILTER setting.
_GetWindFilter_ Gets the WIND FILTER setting.
_CapLowCutFilter_ Queries supported LOW CUT FILTER settings.
_SetLowCutFilter_ Sets the LOW CUT FILTER setting.
_GetLowCutFilter_ Gets the LOW CUT FILTER setting.
_CapHeadPhonesVolume_ Queries supported HEADPHONES VOLUME settings.
_SetHeadPhonesVolume_ Sets the HEADPHONES VOLUME setting.
_GetHeadPhonesVolume_ Gets the HEADPHONES VOLUME setting.
_CapXLRAdapterMicSource_ Queries supported MIC INPUT CHANNEL settings.
_SetXLRAdapterMicSource_ Sets the MIC INPUT CHANNEL setting.
_GetXLRAdapterMicSource_ Gets the MIC INPUT CHANNEL setting.
_CapXLRAdapterMoniteringSource_ Queries supported 4CH AUDIO MONITORING settings.
_SetXLRAdapterMoniteringSource_ Sets the 4CH AUDIO MONITORING setting.
_GetXLRAdapterMoniteringSource_ Gets the 4CH AUDIO MONITORING setting
_CapXLRAdapterHDMIOutputSource_ Queries supported HDMI 4CH AUDIO OUTPUT settings.
_SetXLRAdapterHDMIOutputSource_ Sets the HDMI 4CH AUDIO OUTPUT setting.
_GetXLRAdapterHDMIOutputSource_ Gets the HDMI 4CH AUDIO OUTPUT setting.
_GetMicLevelIndicator_ Gets the MIC LEVEL.
_CapMovieRecVolume_ Queries supported REC START/STOP VOLUME setting.
_SetMovieRecVolume_ Sets the REC START/STOP VOLUME setting.
_GetMovieRecVolume_ Gets the REC START/STOP VOLUME setting.
_CapDirectionalMic_ Queries supported DIRECTIONAL MICROPHONE settings.
_SetDirectionalMic_ Sets the DIRECTIONAL MICROPHONE setting.
_GetDirectionalMic_ Gets the DIRECTIONAL MICROPHONE setting.
**Movie Control - TIME CODE SETTING**
_CapTimeCodeDisplay_ Queries supported TIME CODE DISPLAY settings.
_SetTimeCodeDisplay_ Sets the TIME CODE DISPLAY setting.
_GetTimeCodeDisplay_ Gets the TIME CODE DISPLAY setting.
_CapTimeCodeStartSetting_ Queries supported START TIME SETTING settings.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

_SetTimeCodeStartSetting_ Sets the START TIME SETTING setting.
_CapTimeCodeCountUp_ Queries supported COUNT UP SETTING settings.
_SetTimeCodeCountUp_ Sets the COUNT UP SETTING setting.
_GetTimeCodeCountUp_ Gets the COUNT UP SETTING setting.
_CapTimeCodeDropFrame_ Queries supported DROP FRAME settings.
_SetTimeCodeDropFrame_ Sets the DROP FRAME setting.
_GetTimeCodeDropFrame_ Gets the DROP FRAME setting.
_CapTimeCodeHDMIOutput_ Queries supported HDMI TIME CODE OUTPUT settings.
_SetTimeCodeHDMIOutput_ Sets the HDMI TIME CODE OUTPUT setting.
_GetTimeCodeHDMIOutput_ Gets the HDMI TIME CODE OUTPUT setting.
_CapATOMOSAirGluConnection_ Queries supported CONNECT TO ATOMOS AirGlu BT settings.
_SetATOMOSAirGluConnection_ Sets the CONNECT TO ATOMOS AirGlu BT settings.
_GetATOMOSAirGluConnection_ Gets the CONNECT TO ATOMOS AirGlu BT setting.
_GetTimeCode_ Gets the TIME CODE
_GetTimeCodeCurrentValue_ Gets the TIME CODE (current value).
_GetTimeCodeStatus_ Gets the TIME CODE SYNC. status.
**Other Functions**
_CapCustomAutoPowerOff_ Queries supported customizable options for AUTO POWER OFF for “2
MIN”.
_SetCustomAutoPowerOff_ Sets the custom AUTO POWER OFF for “2 MIN”.
_GetCustomAutoPowerOff_ Gets the custom AUTO POWER OFF for “2 MIN”.
_CapPerformanceSettings_ Queries supported PERFORMANCE settings.
_SetPerformanceSettings_ Sets the PERFORMANCE setting.
_GetPerformanceSettings_ Get the PERFORMANCE setting.
_CapElectronicLevelSetting_ Queries supported ELECTRONIC LEVEL SETTING selections.
_SetElectronicLevelSetting_ Sets the ELECTRONIC LEVEL SETTING.
_GetElectronicLevelSetting_ Gets the ELECTRONIC LEVEL SETTING.
_CapUSBPowerSupplyCommunication_ Queries supported USB POWER SUPPLY / COMM SETTING
selections.
_SetUSBPowerSupplyCommunication_ Sets the USB POWER SUPPLY / COMM SETTING.
_GetUSBPowerSupplyCommunication_ Gets the USB POWER SUPPLY / COMM SETTING.
_CapAutoPowerOffSetting_ Queries supported AUTO POWER OFF settings.
_SetAutoPowerOffSetting_ Sets the AUTO POWER OFF setting.
_GetAutoPowerOffSetting_ Gets the AUTO POWER OFF setting.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4. API Reference**

**4.1. COMMON APIs (Mandatory Functions)**

**4.1.1. Initialize / Finalize**

**4.1.1.1. XSDK_Init**

**Description**
Initializes and starts use of the SDK.

**Syntax**

**Parameters**
hLIB (IN) Under Windows, hLib is set to the HMODULE returned for the loaded XAPI.dll. If
the SDK files are not in the same folder as the executable file, the SDK will use
this parameter to load lower-layered libraries. If all the files are in the same folder
as the executable file, this parameter can be set to NULL.
Under macOS, set hLib to NULL.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S0.

**See Also**
XSDK_Exit

```
XSDK_APIENTRY XSDK_Init (
LIB_HANDLE hLib
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.1.2. XSDK_Exit**

**Description**
Finalizes and terminates use of the SDK.

**Syntax**
XSDK_APIENTRY XSDK_Exit();

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in States S1 and S2.

**See Also**
XSDK_Init


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.2. Enumeration**

**4.1.2.1. XSDK_Detect**

**Description**
Enumerates available cameras and generates a connected camera list.
This API is not supported with the SDK for Android OS. In the case of Android OS following to the codes bellow
please receive return values.
**Syntax(other than Android OS)**

**Parameters**
lInterface (IN) The interface, defined as follows using BIT-OR:
XSDK_DSC_IF_USB USB
XSDK_DSC_IF_WIFI_LOCAL Network (searches in local segment)
XSDK_DSC_IF_WIFI_IP^ Network^ (assign in IPv4 address)^
pInterface (IN) If the XSDK_DSC_IF_WIFI_IP bit of lInterface is on, pInterface specifies where
to find the target camera. The search IP addresses (IPv4) can be listed as
comma-separated values...
E.g. “192.168.100.32, 192.168.100.33, 192.168.200.20”
...or as ranges using expressions such as:
“192.168.100”, meaning “192.168.100.1 to 192.168.100.254”.
“192.168.100.21-192.168.100.30”, meaning “192.168.100.21 to
192.168.100.30”.
XSDK version 1.4.0.0 does not support detection using multiple addresses. You
can specify only one IP address.
E.g. “192.168.100.32”
If XSDK_DSC_IF_WIFI_IP bit is not on, pInterface should be set to NULL.
pDeviceName (IN) The name of the device that is the target of the search.
E.g. “GFX100S”
Set NULL to enumerate all available devices.
plCount (OUT) Returns the number of devices detected.

```
XSDK_APIENTRY XSDK_Detect(
long lInterface,
LPSTR pInterface,
LPSTR pDeviceName,
long* plCount
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**Alternative codes
(Kotlin)**

```
MainActivity.kt
```
```
class MainActivity : AppCompatActivity() {
object AndroidSDKResult{
const val COMPLETE = 0L
const val ERROR = -1L
}
object AndroidSDKErrorNumber{
const val ERRCODE_NOERR = 0x00000000L
const val ERRCODE_SEQUENCE = 0x00001001L
const val ERRCODE_PERMISSION = 0x00001002L
const val ERRCODE_UNKNOWN = 0x00009100L
}
```
```
private lateinit var permissionIntent: PendingIntent
private lateinit var usbManager: UsbManager
private var device: UsbDevice? = null
private var detectedDevice: UsbDevice? = null
private var usbDeviceConnection: UsbDeviceConnection? = null
private var detectedcount: Long = 0
private var errordetails: Long = AndroidSDKErrorNumber.ERRCODE_NOERR
private val hCamera: XSDK.SDKLong = XSDK.SDKLong(long = 0)
```
```
override fun onCreate(savedInstanceState: Bundle?) {
super.onCreate(savedInstanceState)
```
```
permissionIntent = PendingIntent.getBroadcast(
this,
0 ,
Intent("com.fujifilm.example.USB_PERMISSION").apply {
this.`package` = packageName
},
if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.S) PendingIntent.FLAG_MUTABLE else 0
)
if (savedInstanceState == null) {
usbManager = getSystemService(USB_SERVICE) as UsbManager
}
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
```
}
```
```
private fun detect():Long {
var result:Long = AndroidSDKResult.COMPLETE
errordetails = AndroidSDKErrorNumber.ERRCODE_NOERR
```
```
if (usbManager.deviceList.size == 1 ) {
device = usbManager.deviceList.values.toList()[ 0 ]
}else{
device = null
detectedDevice = null
usbDeviceConnection = null
}
if (device != null) {
if (usbManager.hasPermission(device)) {
detectedDevice = device
detectedcount = 1
}else{
usbManager.requestPermission(device, permissionIntent)
if (usbManager.hasPermission(device)) {
detectedDevice = device
detectedcount = 1
}else{
errordetails = AndroidSDKErrorNumber.ERRCODE_PERMISSION
result = AndroidSDKResult.ERROR
}
}
}else{
detectedcount = 0
}
return result
}
```
```
private fun open(): Long {
errordetails = AndroidSDKErrorNumber.ERRCODE_NOERR
```
```
try {
if (usbDeviceConnection != null) {
errordetails = AndroidSDKErrorNumber.ERRCODE_SEQUENCE
return AndroidSDKResult.ERROR
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
```
}
if (detectedDevice == null) {
errordetails = AndroidSDKErrorNumber.ERRCODE_SEQUENCE
return AndroidSDKResult.ERROR
}
val requiredDevice = detectedDevice!!
if (!usbManager.hasPermission(requiredDevice)) {
errordetails = AndroidSDKErrorNumber.ERRCODE_PERMISSION
return AndroidSDKResult.ERROR
}
```
```
usbDeviceConnection = usbManager.openDevice(requiredDevice)
val fd = usbDeviceConnection!!.fileDescriptor
val descriptors = usbDeviceConnection!!.rawDescriptors
return CameraControl.setUSBDeviceHandle(fd.toLong(), descriptors, hCamera)
} catch (e: Exception) {
errordetails = AndroidSDKErrorNumber.ERRCODE_UNKNOWN
return AndroidSDKResult.ERROR
}
}
}
```
```
CameraControl.kt
```
```
object CameraControl {
```
```
fun setUSBDeviceHandle(fileDescriptor:Long, descriptors:ByteArray, hCamera: XSDK.SDKLong):Long {
return xsdk.XSDK_SetUSBDeviceHandle(fileDescriptor, descriptors, hCamera)
}
}
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**(Java)**
MainActivity.java

```
public class MainActivity extends AppCompatActivity {
```
```
private enum AndroidSDKResult{
COMPLETE( 0 ),
ERROR(- 1 );
```
```
private long id;
```
```
private AndroidSDKResult(long id) {
this.id = id;
}
```
```
public long getValue() {
return this.id;
}
}
private enum AndroidSDKErrorNumber{
ERRCODE_NOERR(0x00000000),
ERRCODE_SEQUENCE(0x00001001),
ERRCODE_PERMISSION(0x00001002),
ERRCODE_UNKNOWN(0x00009100);
```
```
private long id;
```
```
private AndroidSDKErrorNumber(long id) {
this.id = id;
}
```
```
public long getValue() {
return this.id;
}
}
```
```
private PendingIntent permissionIntent;
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
```
private UsbManager usbManager;
private UsbDevice device = null;
private UsbDevice detectedDevice = null;
private UsbDeviceConnection usbDeviceConnection;
private static long detectedcount = 0 ;
private static long errordetails = AndroidSDKErrorNumber.ERRCODE_NOERR.getValue();
private static long hCamera[] = { 0 };
```
```
@Override
protected void onCreate(Bundle savedInstanceState) {
super.onCreate(savedInstanceState);
```
```
Intent updateIntent = new Intent("com.fujifilm.example.USB_PERMISSION");
updateIntent.setPackage(this.getPackageName());
int flags;
if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.S){
flags = PendingIntent.FLAG_MUTABLE;
}
else {
flags = 0 ;
}
permissionIntent = PendingIntent.getBroadcast(this, 0 , updateIntent, flags);
if (savedInstanceState == null) {
usbManager = (UsbManager) getSystemService(Context.USB_SERVICE);
}
}
```
```
private long detect() {
long result = AndroidSDKResult.COMPLETE.getValue();
errordetails = AndroidSDKErrorNumber.ERRCODE_NOERR.getValue();
```
```
HashMap<String, UsbDevice> deviceList = usbManager.getDeviceList();
if (deviceList.size() == 1 ) {
Iterator<UsbDevice> deviceIterator = deviceList.values().iterator();
while(deviceIterator.hasNext()){
device = deviceIterator.next();
break;
}
}else{
device = null;
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
```
detectedDevice = null;
usbDeviceConnection = null;
}
if (device != null) {
if (usbManager.hasPermission(device)) {
detectedDevice = device;
detectedcount = 1 ;
} else {
usbManager.requestPermission(device, permissionIntent);
if (usbManager.hasPermission(device)) {
detectedDevice = device;
detectedcount = 1 ;
} else {
errordetails = AndroidSDKErrorNumber.ERRCODE_PERMISSION.getValue();
result = AndroidSDKResult.ERROR.getValue();
}
}
}else{
detectedcount = 0 ;
}
return result;
}
```
```
private long open() {
errordetails = AndroidSDKErrorNumber.ERRCODE_NOERR.getValue();
```
```
try {
if (usbDeviceConnection != null) {
errordetails = AndroidSDKErrorNumber.ERRCODE_SEQUENCE.getValue();
return AndroidSDKResult.ERROR.getValue();
}
if (detectedDevice == null) {
errordetails = AndroidSDKErrorNumber.ERRCODE_SEQUENCE.getValue();
return AndroidSDKResult.ERROR.getValue();
}
UsbDevice requiredDevice = detectedDevice;
if (!usbManager.hasPermission(requiredDevice)) {
errordetails = AndroidSDKErrorNumber.ERRCODE_PERMISSION.getValue();
return AndroidSDKResult.ERROR.getValue();
}
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Remarks**
This function can be used in States S1 and S2.
**See also**
https://developer.android.com/develop/connectivity/usb/host
**Note**
To control cameras on M1/M2 Mac with macOS15, please allow at least 3000 mS between XSDK_Init() and
XSDK_Detect().

```
usbDeviceConnection = usbManager.openDevice(requiredDevice);
int fd = usbDeviceConnection.getFileDescriptor();
byte[] descriptors = usbDeviceConnection.getRawDescriptors();
return CameraControl.setUSBDeviceHandle(fd, descriptors, hCamera);
} catch (Exception e) {
errordetails = AndroidSDKErrorNumber.ERRCODE_UNKNOWN.getValue();
return AndroidSDKResult.ERROR.getValue();
}
}
}
CameraControl.java
```
```
public class CameraControl {
```
```
public static long setUSBDeviceHandle(int fileDescriptor, byte[] descriptors, long[] hCamera) {
return xsdk.XSDK_SetUSBDeviceHandle(fileDescriptor, descriptors, hCamera);
}
}
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.2.2. XSDK_Append**

**Description**
Update the connected camera list.
This API is not supported with the SDK for Android OS, since the SDK for Android OS supports only one camera
connection.
**Syntax**

**Parameters**
lInterface (IN) The interface, defined as follows using BIT-OR:
XSDK_DSC_IF_USB USB
XSDK_DSC_IF_WIFI_LOCAL Network (searches in local segment)
XSDK_DSC_IF_WIFI_IP^ Network (assign in IPv4 address)^
pInterface (IN) If the XSDK_DSC_IF_WIFI_IP bit of lInterface is on, pInterface specifies where
to find the target camera. The search IP addresses (IPv4) can be listed as
comma-separated values...
E.g. “192.168.100.32, 192.168.100.33, 192.168.200.20”
...or as ranges using expressions such as:
“192.168.100”, meaning “192.168.100.1 to 192.168.100.254”.
“192.168.100.21-192.168.100.30”, meaning “192.168.100.21 to
192.168.100.30”.
XSDK version 1.4.0.0 does not support detection using multiple addresses. You
can specify only one IP address.
E.g. “192.168.100.32”
If XSDK_DSC_IF_WIFI_IP bit is not on, pInterface should be set to NULL.
pDeviceName (IN) The name of the device that is the target of the search.
E.g. “GFX100S”
Set NULL to enumerate all available devices.
plCount (IN/OUT) Returns the number of devices detected.
pCameraList (OUT) When the pDeviceList equals to NULL, the plCount returns the maximum field
number of the connected camera list.
To get all information for connected cameras, allocate
sizeof(XSDK_DeviceStatus) * (*plCount)

```
XSDK_APIENTRY XSDK_Append(
long lInterface,
LPSTR pInterface,
LPSTR pDeviceName,
long* plCount,
XSDK_DeviceStatus* pDeviceList
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
```
for pDeviceList and set the returned (*plCount) to (*plCount) before calling the
XSDK_Append().
```
typedef struct{
char strProduct[256]; //The model name
char strSerialNo[256]; ///The serial number (USB only)
char strIPAddress[256]; //The IPv4 address (network connection only)
char strFramework[256]; //USB / ETHER(Ethernet) / IP(Wi-Fi)
bool bValid; //true: valid, false: invalid
} XSDK_CameraList;^
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Remarks**
This function can be used in State S 2. The Stetes for some under controled cameras may be in State S3.
**Note**
This API is used for appending newly connected camera to the camera list. To detcted a disconnection (or turning
off) of the connected camera, please check the return value for the XSDK_GetErrorNumber for any API call. When
the return value is XSDK_ERRCODE_COMMUNICATION or XSDK_ERRCODE_TIMEOUT, the camera may
be disconnected or beeing turned off.

```
The figure below shows an example when one connected camera is disconnected and then connected again.
When the same camera is reconneted, the camera is registerd to the same lDevIndex.
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
```
The figure below shows another example when one connected camera is disconnected and then another camera is
connected.
When the new camera is conneted, the camera is registerd to the new lDevIndex.
```
```
The figure below shows another example when one connected camera is disconnected and then call XSDK_Detect.
The camera list will be newly generated. The former lDevIndex is not guaranteed.
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.3. Session Management**

**4.1.3.1. XSDK_OpenEx**

**Description**
Establishes a session between the camera and the computer.
This API is not supported with the SDK for Android OS. In the case of Android OS following to the codes bellow
please receive return values.

**Syntax(other than Android OS)**

**Parameters**
pDevice (IN) The name of the camera to which a connection is to be made as a
NULL-terminated ASCII string. To name the camera via an index, use:
“ENUM:<number>”
where <number> is a string with a value of from 0 to the ( *plCount - 1 ) returned
by XSDK_Detect. For example, if XSDK_Detect returns *plCount=2, pDevice can
be either “ENUM:0” or “ENUM:1”.
To name the camera via its IP address, use:
“IPv4:<ip address>”
where <ip address> is a string giving an IPv4-style IP address. For example, to
connect a camera with an IP address of 192.168.0.1, use:
“IPv4:192.168.0.1”
phCamera (OUT) Returns the camera handle when the function completes.
plCameraMode (OUT) Returns a bitmap of camera features compatible with tethering operations.
XSDK_DSC_MODE_TETHER Tethered shooting is supported
XSDK_DSC_MODE_RAW The connection mode is USB RAW DEV.
XSDK_DSC_MODE_BR Backup/Restore supported
XSDK_DSC_MODE_WEBCAM Limited tethered shooting functions are supported (only
for XWebcam operations)

```
pOption (IN) pOption should be set to NULL.
```
```
XSDK_APIENTRY XSDK_OpenEx(
LPCSTR pDevice,
XSDK_HANDLE* phCamera,
long* plCameraMode,
void* pOption
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Alternative codes
(Kotlin)**
MainActivity.kt

```
class MainActivity : AppCompatActivity() {
object AndroidSDKResult{
const val COMPLETE = 0L
const val ERROR = -1L
}
object AndroidSDKErrorNumber{
const val ERRCODE_NOERR = 0x00000000L
const val ERRCODE_SEQUENCE = 0x00001001L
const val ERRCODE_PERMISSION = 0x00001002L
const val ERRCODE_UNKNOWN = 0x00009100L
}
```
```
private lateinit var permissionIntent: PendingIntent
private lateinit var usbManager: UsbManager
private var device: UsbDevice? = null
private var detectedDevice: UsbDevice? = null
private var usbDeviceConnection: UsbDeviceConnection? = null
private var detectedcount: Long = 0
private var errordetails: Long = AndroidSDKErrorNumber.ERRCODE_NOERR
private val hCamera: XSDK.SDKLong = XSDK.SDKLong(long = 0)
```
```
override fun onCreate(savedInstanceState: Bundle?) {
super.onCreate(savedInstanceState)
```
```
permissionIntent = PendingIntent.getBroadcast(
this,
0 ,
Intent("com.fujifilm.example.USB_PERMISSION").apply {
this.`package` = packageName
},
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
```
if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.S) PendingIntent.FLAG_MUTABLE else 0
)
if (savedInstanceState == null) {
usbManager = getSystemService(USB_SERVICE) as UsbManager
}
}
```
```
private fun detect():Long {
var result:Long = AndroidSDKResult.COMPLETE
errordetails = AndroidSDKErrorNumber.ERRCODE_NOERR
```
```
if (usbManager.deviceList.size == 1 ) {
device = usbManager.deviceList.values.toList()[ 0 ]
}else{
device = null
detectedDevice = null
usbDeviceConnection = null
}
if (device != null) {
if (usbManager.hasPermission(device)) {
detectedDevice = device
detectedcount = 1
}else{
usbManager.requestPermission(device, permissionIntent)
if (usbManager.hasPermission(device)) {
detectedDevice = device
detectedcount = 1
}else{
errordetails = AndroidSDKErrorNumber.ERRCODE_PERMISSION
result = AndroidSDKResult.ERROR
}
}
}else{
detectedcount = 0
}
return result
}
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
```
private fun open(): Long {
errordetails = AndroidSDKErrorNumber.ERRCODE_NOERR
```
```
try {
if (usbDeviceConnection != null) {
errordetails = AndroidSDKErrorNumber.ERRCODE_SEQUENCE
return AndroidSDKResult.ERROR
}
if (detectedDevice == null) {
errordetails = AndroidSDKErrorNumber.ERRCODE_SEQUENCE
return AndroidSDKResult.ERROR
}
val requiredDevice = detectedDevice!!
if (!usbManager.hasPermission(requiredDevice)) {
errordetails = AndroidSDKErrorNumber.ERRCODE_PERMISSION
return AndroidSDKResult.ERROR
}
```
```
usbDeviceConnection = usbManager.openDevice(requiredDevice)
val fd = usbDeviceConnection!!.fileDescriptor
val descriptors = usbDeviceConnection!!.rawDescriptors
return CameraControl.setUSBDeviceHandle(fd.toLong(), descriptors, hCamera)
} catch (e: Exception) {
errordetails = AndroidSDKErrorNumber.ERRCODE_UNKNOWN
return AndroidSDKResult.ERROR
}
}
}
```
```
CameraControl.kt
```
```
object CameraControl {
```
```
fun setUSBDeviceHandle(fileDescriptor:Long, descriptors:ByteArray, hCamera: XSDK.SDKLong):Long {
return xsdk.XSDK_SetUSBDeviceHandle(fileDescriptor, descriptors, hCamera)
}
}
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**(Java)**
MainActivity.java

```
public class MainActivity extends AppCompatActivity {
```
```
private enum AndroidSDKResult{
COMPLETE( 0 ),
ERROR(- 1 );
```
```
private long id;
```
```
private AndroidSDKResult(long id) {
this.id = id;
}
```
```
public long getValue() {
return this.id;
}
}
private enum AndroidSDKErrorNumber{
ERRCODE_NOERR(0x00000000),
ERRCODE_SEQUENCE(0x00001001),
ERRCODE_PERMISSION(0x00001002),
ERRCODE_UNKNOWN(0x00009100);
```
```
private long id;
```
```
private AndroidSDKErrorNumber(long id) {
this.id = id;
}
```
```
public long getValue() {
return this.id;
}
}
```
```
private PendingIntent permissionIntent;
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
```
private UsbManager usbManager;
private UsbDevice device = null;
private UsbDevice detectedDevice = null;
private UsbDeviceConnection usbDeviceConnection;
private static long detectedcount = 0 ;
private static long errordetails = AndroidSDKErrorNumber.ERRCODE_NOERR.getValue();
private static long hCamera[] = { 0 };
```
```
@Override
protected void onCreate(Bundle savedInstanceState) {
super.onCreate(savedInstanceState);
```
```
Intent updateIntent = new Intent("com.fujifilm.example.USB_PERMISSION");
updateIntent.setPackage(this.getPackageName());
int flags;
if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.S){
flags = PendingIntent.FLAG_MUTABLE;
}
else {
flags = 0 ;
}
permissionIntent = PendingIntent.getBroadcast(this, 0 , updateIntent, flags);
if (savedInstanceState == null) {
usbManager = (UsbManager) getSystemService(Context.USB_SERVICE);
}
}
```
```
private long detect() {
long result = AndroidSDKResult.COMPLETE.getValue();
errordetails = AndroidSDKErrorNumber.ERRCODE_NOERR.getValue();
```
```
HashMap<String, UsbDevice> deviceList = usbManager.getDeviceList();
if (deviceList.size() == 1 ) {
Iterator<UsbDevice> deviceIterator = deviceList.values().iterator();
while(deviceIterator.hasNext()){
device = deviceIterator.next();
break;
}
}else{
device = null;
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
```
detectedDevice = null;
usbDeviceConnection = null;
}
if (device != null) {
if (usbManager.hasPermission(device)) {
detectedDevice = device;
detectedcount = 1 ;
} else {
usbManager.requestPermission(device, permissionIntent);
if (usbManager.hasPermission(device)) {
detectedDevice = device;
detectedcount = 1 ;
} else {
errordetails = AndroidSDKErrorNumber.ERRCODE_PERMISSION.getValue();
result = AndroidSDKResult.ERROR.getValue();
}
}
}else{
detectedcount = 0 ;
}
return result;
}
```
```
private long open() {
errordetails = AndroidSDKErrorNumber.ERRCODE_NOERR.getValue();
```
```
try {
if (usbDeviceConnection != null) {
errordetails = AndroidSDKErrorNumber.ERRCODE_SEQUENCE.getValue();
return AndroidSDKResult.ERROR.getValue();
}
if (detectedDevice == null) {
errordetails = AndroidSDKErrorNumber.ERRCODE_SEQUENCE.getValue();
return AndroidSDKResult.ERROR.getValue();
}
UsbDevice requiredDevice = detectedDevice;
if (!usbManager.hasPermission(requiredDevice)) {
errordetails = AndroidSDKErrorNumber.ERRCODE_PERMISSION.getValue();
return AndroidSDKResult.ERROR.getValue();
}
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**Remarks**
This function can be used in State S2.

**See Also**
XSDK_Detect, XSDK_Close, XSDK_PowerOFF

```
usbDeviceConnection = usbManager.openDevice(requiredDevice);
int fd = usbDeviceConnection.getFileDescriptor();
byte[] descriptors = usbDeviceConnection.getRawDescriptors();
return CameraControl.setUSBDeviceHandle(fd, descriptors, hCamera);
} catch (Exception e) {
errordetails = AndroidSDKErrorNumber.ERRCODE_UNKNOWN.getValue();
return AndroidSDKResult.ERROR.getValue();
}
}
}
```
```
CameraControl.java
```
```
public class CameraControl {
```
```
public static long setUSBDeviceHandle(int fileDescriptor, byte[] descriptors, long[] hCamera) {
return xsdk.XSDK_SetUSBDeviceHandle(fileDescriptor, descriptors, hCamera);
}
}
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.3.2. XSDK_SetUSBDeviceHandle**

**Description**
This API is supported only with the SDK for Android OS.
This API is called from the alternative code for XSDK_OpenEx.
This API provides opening camera feature on Android OS.

**Syntax**

**Parameters**
lFileDescriptor (IN) The native file descriptor for the camera.
Set the return value of the UsbDeviceConnection.getFileDescriptor prior to calling
the API.
pRawDescriptors (IN) The raw USB descriptors for the camera.
Set the return value of the UsbDeviceConnection.getRawDescriptors prior to
calling the API.
phCamera (OUT) Returns the camera handle when the function completes.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S2.

**See Also**
XSDK_OpenEx, XSDK_Close, XSDK_PowerOFF

```
XSDK_APIENTRY XSDK_SetUSBDeviceHandle(
long lFileDescriptor,
unsigned char* pRawDescriptors,
XSDK_HANDLE* phCamera
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.3.3. XSDK_Close**

**Description**
Closes the session between the camera and the computer.
**Syntax**

**Parameters**
hCamera (IN) Camera handle.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**IMPORTANT NOTICE**
Wait at least 600 mS after calling XSDK_Close(). Sample source code:
:
XSDK_Close();
Sleep( 600 );
XSDK_Exit();
:
**Remarks**
This function can be used in State S3.
**See Also**
XSDK_Detect, XSDK_OpenEx, XSDK_PowerOFF

```
XSDK_APIENTRY XSDK_Close(
XSDK_HANDLE hCamera
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.3.4. XSDK_PowerOFF**

**Description**
Closes the session between the camera and the computer, and shut the camera down.
During shutdown, camera settings and counter logs are saved to the camera’s non-volatile memory. To use the
camera again, either:

- turn the camera off, wait a few moments, and then turn the camera on again, or
- keep the shutter button (or remote release) pressed for over two seconds.

**Syntax**

**Parameters**
hCamera (IN) Camera handle.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_Detect, XSDK_OpenEx, XSDK_Close

```
XSDK_APIENTRY XSDK_PowerOFF(
XSDK_HANDLE hCamera
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.4. Basic Functions**

**4.1.4.1. XSDK_GetErrorNumber**

**Description**
Gets the detailed result of the last called function.

**Syntax**

**Parameters**
hCamera (IN) The camera handle must be provided in State S3; otherwise, hCamera can be set to
NULL.
plAPICode (OUT) The last called API code.
plERRCode (OUT) See the ERROR CODES for details.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in all states.

```
XSDK_APIENTRY XSDK_GetErrorNumber(
XSDK_HANDLE hCamera,
long* plAPICode,
long* plERRCode
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.4.2. XSDK_GetErrorDetails**

**Description**
Gets details of the busy error when the plERRCode returned by a call to XSDK_GetErrorNumber is
XSDK_ERRCODE_RUNNING_OTHER_FUNCTION.
**Syntax**

**Parameters**
hCamera (IN) The camera handle must be provided in State S3; otherwise, hCamera can be set to
NULL.
plAPICode (OUT) The last called API code.
pulERRCode (OUT) Returns the function currently running.
XSDK_ERROR_DETAIL_AEL AE is locked
XSDK_ERROR_DETAIL_AFL AF is locked
XSDK_ERROR_DETAIL_INSTANTAF INSTANT AF in operation
XSDK_ERROR_DETAIL_AFON AF for AF ON in operation

XSDK_ERROR_DETAIL_SHOOTING (^) Shooting in progress
XSDK_ERROR_DETAIL_SHOOTINGCOUNTDOWN (^) SELF-TIMER in operation
XSDK_ERROR_DETAIL_RECORDING Movie is in recording
XSDK_ERROR_DETAIL_LIVEVIEW (^) Liveview is in progress
XSDK_ERROR_DETAIL_UNTRANSFERRED_IMAGE Pictures remain in the
in-camera volatile memory^
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Remarks**
This function can be used in all states.
XSDK_APIENTRY XSDK_GetErrorDetails(
XSDK_HANDLE hCamera,
long* plAPICode,
unsigned long* pulERRCode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.4.3. XSDK_GetVersionString**

**Description**
Gets version numbers in a string format.

**Syntax**

**Parameters**
pVersionString (OUT) Returns the SDK version as a string. Allocate space for a 256-byte character string
before calling this function.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in all states.

```
XSDK_APIENTRY XSDK_GetVersionString(
LPSTR pVersionString
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.5. Device Information**

**4.1.5.1. XSDK_GetDeviceInfo**

**Description**
Gets information about the connected camera.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
pDevInfo (OUT) Returns camera information with the following data structure:
typedef struct{
char strVendor[256]; // The name of the camera vendor (e.g. “FUJIFILM”)
char strManufacturer[256]; // The name of the camera manufacturer (e.g. “FUJIFILM”)
char strProduct[256]; // The camera model name (e.g. “GFX100S”)
char strFirmware[256]; // The camera firmware version (e.g. “1.00”)
char strDeviceType[256]; //
char strSerialNo[256]; // The camera serial number
char strFramework[256]; // The interface type (“USB” or “Wi-Fi”)
BYTE bDeviceId; //
char strDeviceName[32]; // A unique name set using XSDK_WriteDeviceName
char strYNo[32]; // Reserved
} XSDK_DeviceInformation;
Some information is not returned for some models.
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_WriteDeviceName

```
XSDK_APIENTRY XSDK_GetDeviceInfo(
XSDK_HANDLE hCamera,
XSDK_DeviceInformation* pDevInfo
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.5.2. XSDK_GetDeviceInfoEx**

**Description**
Gets information about the connected camera and supported APIs by the camera.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
pDevInfo (OUT) Returns camera information with the following data structure:
typedef struct{
char strVendor[256]; // The name of the camera vendor (e.g. “FUJIFILM”)
char strManufacturer[256]; // The name of the camera manufacturer (e.g. “FUJIFILM”)
char strProduct[256]; // The camera model name (e.g. “GFX100S”)
char strFirmware[256]; // The camera firmware version (e.g. “1.00”)
char strDeviceType[256]; //
char strSerialNo[256]; // The camera serial number
char strFramework[256]; // The interface type (“USB” or “Wi-Fi”)
BYTE bDeviceId; //
char strDeviceName[32]; // A unique name set using XSDK_WriteDeviceName
char strYNo[32]; // Reserved
} XSDK_DeviceInformation;
Some information is not returned for some models.
plNumAPICode (OUT) Returns the number of APICode supported.
plAPICode (OUT) If not NULL, plAPICode will return a list of APICode supported. Allocate
sizeof(long) * (* plNumAPICode) bytes of space before calling this function.
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**

```
XSDK_APIENTRY XSDK_GetDeviceInfoEx(
XSDK_HANDLE hCamera,
XSDK_DeviceInformation* pDevInfo,
long* plNumAPICode,
long* plAPICode
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
```
XSDK_WriteDeviceName
```
**Sample**
long lNumAPICode;
long* plAPICode;
XSDK_GetDeviceInfoEx( hCam, &lNumAPICode, NULL );
plAPICode = new long [lNumAPICode];
XSDK_GetDeviceInfoEx ( hCam, &lNumAPICode, plAPICode);
:
delete [] plAPICode;


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.5.3. XSDK_WriteDeviceName**

**Description**
Assigns a device-unique name to the camera.
The name is written to the camera’s non-volatile memory and is useful for identifying a target camera when
multiple cameras are connected.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
pDeviceName (IN) A unique name. Up to 32 characters including the NULL terminator.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_GetDeviceInfo

```
XSDK_APIENTRY XSDK_WriteDeviceName(
XSDK_HANDLE hCamera,
LPCSTR pDeviceName
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.5.4. XSDK_GetFirmwareVersion**

**Description**
Get the firmware version of the camera in string.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
pFirmwareVersion (OUT) Returns the camera firmware version as a string. Allocate space for a 256 - byte
character string before calling this function.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

```
XSDK_APIENTRY XSDK_GetFirmwareVersion(
XSDK_HANDLE hCamera,
LPSTR pFirmwareVersion
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.5.5. XSDK_GetLensInfo**

**Description**
Gets lens information from the camera.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
pLensInfo (OUT) Returns the lens information with a following data structure:
typedef struct{
char strModel[20]; // Reserved
char strProductName[ 100 ]; // The model name of the lens
char strSerialNo[20]; // The serial number of the lens
long lISCapability; // Lens image stabilization switch (1: Present, 0: Not present)
long lMFCapability; // Lens manual focus switch (1: Present, 0: Not present)
long lZoomPosCapability; // SetZoomPos enabled Lens
} XSDK_LensInformation;
If the camera features a built-in lens (fixed lens), strModel[0] and strSerialNo[0]
will be set to NULL and strProductName will give the lens information, for
example “FUJINON LENS 4.0x f=6.4-25.6mm 1:1.8-4.9”.
Where the lens does not supply information to the camera, as is the case with Leica
M mount lens with a mount adapter, strModel[0] and strSerialNo[0] are set to
NULL and strProductName gives the mount adapter setting, for example “28mm”.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**

```
XSDK_APIENTRY XSDK_GetLensInfo(
XSDK_HANDLE hCamera,
XSDK_LensInformation* pLensInfo
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.5.6. XSDK_GetLensVersion**

**Description**
Gets the firmware version of the lens attached to the camera in a string format.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
pLensVersion (OUT) Returns the lens firmware version as a string. Allocate space for a 256-byte
character string before calling this function.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**

```
XSDK_APIENTRY XSDK_GetLensVersion(
XSDK_HANDLE hCamera,
LPSTR pLensVersion
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.6. Camera Operation Mode**

**4.1.6.1. XSDK_CapPriorityMode**

**Description**
Queries supported operation modes.
“Camera Priority” mode allows operations to be performed from the camera using camera dials, buttons, shutter
release, and other controls. In “PC Priority” mode, the camera can be operated from a computer, and camera dials,
buttons, shutter release, and (with the exception of the lens manual focus ring) other controls cannot be used.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plNumPriorityMode (OUT) Returns the supported number of settings for XSDK_SetPriorityMode.
A value of 2 will be returned, if the camera supports both “Camera Priority” and
“PC Priority” modes.
plPriorityMode (OUT) If not NULL, plPriorityMode will return a list of the XSDK_SetPriorityMode
settings supported. Allocate sizeof(long) * (*plNumPriorityMode) bytes of space
before calling this function.
XSDK_PRIORITY_CAMERA “Camera Priority” mode
XSDK_PRIORITY_PC “PC Priority” mode

```
For example, a camera that supports both “Camera Priority” and “PC Priority”
modes returns:
plPriorityMode [0] = XSDK_PRIORITY_CAMERA
plPriorityMode [1] = XSDK_PRIORITY_PC
XSDK_PRIORITY_CAMERA and XSDK_PRIORITY_PC will not necessarily
be returned in this order.
```
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

```
XSDK_APIENTRY XSDK_CapPriorityMode(
XSDK_HANDLE hCamera,
long* plNumPriorityMode,
long* plPriorityMode
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**Remarks**
This function can be used in State S3.

**See Also**
XSDK_SetPriorityMode, XSDK_GetPriorityMode

**Sample**
long lNumPriorityMode;
long* plPriorityMode;
XSDK_CapPriorityMode( hCam, &lNumPriorityMode, NULL );
plPriorityMode = new long [lNumPriorityMode];
XSDK_CapPriorityMode( hCam, &lNumPriorityMode, plPriorityMode);
:
delete [] plPriorityMode;


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.6.2. XSDK_SetPriorityMode**

**Description**
Sets the camera operation mode.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lPriorityMode (IN) The priority mode.
See plPriorityMode of XSDK_CapPriorityMode.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_CapPriorityMode, XSDK_GetPriorityMode

```
XSDK_APIENTRY XSDK_SetPriorityMode(
XSDK_HANDLE hCamera,
long lPriorityMode,
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.6.3. XSDK_GetPriorityMode**

**Description**
Gets the current camera operation mode.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plPriorityMode (OUT) The priority mode.
See plPriorityMode of XSDK_CapPriorityMode.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_CapPriorityMode, XSDK_SetPriorityMode

```
XSDK_APIENTRY XSDK_GetPriorityMode(
XSDK_HANDLE hCamera,
long* plPriorityMode,
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.6.4. XSDK_CapDriveMode**

**Description**
Queries supported drive modes.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plNumDriveMode (OUT) Returns the number of XSDK_SetDriveMode settings supported.
plDriveMode (OUT) If plDriveMode is NULL, the function will return only plNumDriveMode with
the number of supported XSDK_SetDriveMode settings. Otherwise it will return
plDriveMode with a list of the XSDK_SetDriveMode settings supported.
Allocate sizeof(long) * (*plNumDriveMode) bytes of space before calling this
function..
XSDK_DRIVE_MODE_S STILL IMAGE
(SINGLE)
XSDK_DRIVE_MODE_MOVIE MOVIE
XSDK_DRIVE_MODE_CH CH HIGH
SPEED
BURST
XSDK_DRIVE_MODE_CL CL LOW
SPEED
BURST
XSDK_DRIVE_MODE_MULTI_EXPOSURE MULTIPLE
EXPOSURE
XSDK_DRIVE_MODE_ADVFILTER ADVANCED
FILTER
XSDK_DRIVE_MODE_PANORAMA PANORAMA
XSDK_DRIVE_MODE_HDR HDR
XSDK_DRIVE_MODE_BKT_AE AE BKT
XSDK_DRIVE_MODE_BKT_ISO ISO BKT
XSDK_DRIVE_MODE_BKT_FILMSIMULATION FILM
SIMULATION

```
XSDK_APIENTRY XSDK_CapPriorityMode(
XSDK_HANDLE hCamera,
long* plNumDriveMode,
long* plDriveMode
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
```
BKT
XSDK_DRIVE_MODE_BKT_WHITEBALANCE WHITE
BALANCE
BKT
XSDK_DRIVE_MODE_BKT_DYNAMICRANGE DYNAMIC
RANGE BKT
XSDK_DRIVE_MODE_BKT_FOCUS FOCUS BKT
XSDK_DRIVE_MODE_PIXELSHIFTMULTISHOT PIXEL SHIFT
MULTI SHOT
XSDK_DRIVE_MODE_CH_CROP CH HIGH
SPEED
BURST
(CROP)
XSDK_DRIVE_MODE_PIXELSHIFTMULTISHOT_FEWERFRAMES PIXEL-SHIFT
MULTI-SHOT
ACCURATE
COLOR
```
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_SetDriveMode, XSDK_GetDriveMode

**Sample**
long lNumDriveMode;
long* plDriveMode;
XSDK_CapDriveMode( hCam, &lNumDriveMode, NULL );
plDriveMode = new long [lNumDriveMode];
XSDK_CapDriveMode( hCam, &lNumDriveMode, plDriveMode);
:
delete [] plDriveMode;


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.6.5. XSDK_SetDriveMode**

**Description**
Sets the camera drive mode.
This function cannot be used to set the drive mode in the case of cameras for which the drive mode is selected
mechanically via a mode dial.
**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lDriveMode (IN) The drive mode.
XSDK_DRIVE_MODE_S STILL IMAGE (SINGLE)
XSDK_DRIVE_MODE_MOVIE MOVIE

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_GetDriveMode

```
XSDK_APIENTRY XSDK_SetDriveMode(
XSDK_HANDLE hCamera,
long lDriveMode,
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.6.6. XSDK_GetDriveMode**

**Description**
Gets the current camera drive mode.
We strongly recommend calling this function when you start controlling the camera, as most still photography
control APIs will not be accepted when the camera is in MOVIE mode.
**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plDriveMode (OUT) The drive Mode.
XSDK_DRIVE_MODE_S STILL IMAGE (SINGLE); in some cases this
value is returned if tethered shooting is not
supported.
XSDK_DRIVE_MODE_MOVIE MOVIE
XSDK_DRIVE_MODE_PIXELSHIFTMULTISHOT PIXELSHIFT MULTISHOT
XSDK_DRIVE_MODE_INVALID Returned if the camera is equipped with a mode
dial and the dial is rotated to MOVIE.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.
Models not compatible with drones and gimbals always return “STILL IMAGE MODE”.

**See Also**
XSDK_SetDriveMode

```
XSDK_APIENTRY XSDK_GetDriveMode(
XSDK_HANDLE hCamera,
long* plDriveMode,
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.6.7. XSDK_CapMode**

**Description**
Queries supported camera MODES.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plNumMode (OUT) Returns the number of XSDK_SetMode settings supported.
plMode (OUT) If plMode is NULL, the function will return only plNumMode with the number
of supported XSDK_SetMode settings. Otherwise it will return plMode with a list
of the XSDK_SetMode settings supported.
Allocate sizeof(long) * (*plNumMode) bytes of space before calling this
function..
XSDK_MODE_STILL_C0 STILL MODE P, S, A, or M
XSDK_MODE_STILL_C1 STILL MODE C1
XSDK_MODE_STILL_C2 STILL MODE C2
XSDK_MODE_STILL_C3 STILL MODE C3
XSDK_MODE_STILL_C4 STILL MODE C4
XSDK_MODE_STILL_C5 STILL MODE C5
XSDK_MODE_STILL_C6 STILL MODE C6
XSDK_MODE_STILL_C7 STILL MODE C7
XSDK_MODE_STILL_ADVFILTER STILL MODE Advanced FILTER
XSDK_MODE_STILL_SP STILL MODE Scene Position
XSDK_MODE_STILL_AUTO STILL MODE AUTO
XSDK_MODE_MOVIE_C0 MOVIE MODE P, S, A, or M
XSDK_MODE_MOVIE_C1 MOVIE MODE C1
XSDK_MODE_MOVIE_C2 MOVIE MODE C2
XSDK_MODE_MOVIE_C3 MOVIE MODE C3
XSDK_MODE_MOVIE_C4 MOVIE MODE C4
XSDK_MODE_MOVIE_C5 MOVIE MODE C5
XSDK_MODE_MOVIE_C6 MOVIE MODE C6

```
XSDK_APIENTRY XSDK_CapMode(
XSDK_HANDLE hCamera,
long* plNumMode,
long* plMode
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
```
XSDK_MODE_MOVIE_C7 MOVIE MODE C7
XSDK_MODE_MOVIE_VLOG^ MOVIR MODE VLOG^
```
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**

```
This function can be used in State S3.
```
**See Also**
XSDK_SetMode, XSDK_GetMode

**Sample**
long lNumMode;
long* plMode;
XSDK_CapMode( hCam, &lNumMode, NULL );
plMode = new long [lNumMode];
XSDK_CapMode( hCam, &lNumMode, plMode);
:
delete [] plMode;


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.6.8. XSDK_SetMode**

**Description**
Sets the camera MODE.
This function cannot be used to set the MODE in the case of cameras for which the MODE is selected mechanically
via a MODE DIAL.
**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lMode (IN) The mode.
XSDK_MODE_STILL_C0 STILL MODE P, S, A, or M
XSDK_MODE_STILL_C1 STILL MODE C1
XSDK_MODE_STILL_C2 STILL MODE C2
XSDK_MODE_STILL_C3 STILL MODE C3
XSDK_MODE_STILL_C4 STILL MODE C4
XSDK_MODE_STILL_C5 STILL MODE C5
XSDK_MODE_STILL_C6 STILL MODE C6
XSDK_MODE_STILL_C7 STILL MODE C7
XSDK_MODE_STILL_ADVFILTER STILL MODE Advanced FILTER
XSDK_MODE_STILL_SP STILL MODE Scene Position
XSDK_MODE_STILL_AUTO STILL MODE AUTO
XSDK_MODE_MOVIE_C0 MOVIE MODE P, S, A, or M
XSDK_MODE_MOVIE_C1 MOVIE MODE C1
XSDK_MODE_MOVIE_C2 MOVIE MODE C2
XSDK_MODE_MOVIE_C3 MOVIE MODE C3
XSDK_MODE_MOVIE_C4 MOVIE MODE C4
XSDK_MODE_MOVIE_C5 MOVIE MODE C5
XSDK_MODE_MOVIE_C6 MOVIE MODE C6
XSDK_MODE_MOVIE_C7^ MOVIE MODE C7^

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

```
XSDK_APIENTRY XSDK_SetMode(
XSDK_HANDLE hCamera,
long lMode
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**Remarks**
This function can be used in State S3.

**See Also**
XSDK_GetMode, XSDK_CapMode


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.6.9. XSDK_GetMode**

**Description**
Gets the current camera MODE.
We strongly recommend calling this function when you start controlling the camera, as most still photography
control APIs will not be accepted when the camera is in MOVIE mode.
**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plMode (OUT) The Mode.
XSDK_MODE_STILL_C0 STILL MODE P, S, A, or M
XSDK_MODE_STILL_C1 STILL MODE C1
XSDK_MODE_STILL_C2 STILL MODE C2
XSDK_MODE_STILL_C3 STILL MODE C3
XSDK_MODE_STILL_C4 STILL MODE C4
XSDK_MODE_STILL_C5 STILL MODE C5
XSDK_MODE_STILL_C6 STILL MODE C6
XSDK_MODE_STILL_C7 STILL MODE C7
XSDK_MODE_STILL_ADVFILTER STILL MODE Advanced FILTER
XSDK_MODE_STILL_SP STILL MODE Scene Position
XSDK_MODE_STILL_AUTO STILL MODE AUTO
XSDK_MODE_MOVIE_C0 MOVIE MODE P, S, A, or M
XSDK_MODE_MOVIE_C1 MOVIE MODE C1
XSDK_MODE_MOVIE_C2 MOVIE MODE C2
XSDK_MODE_MOVIE_C3 MOVIE MODE C3
XSDK_MODE_MOVIE_C4 MOVIE MODE C4
XSDK_MODE_MOVIE_C5 MOVIE MODE C5
XSDK_MODE_MOVIE_C6 MOVIE MODE C6
XSDK_MODE_MOVIE_C7^ MOVIE MODE C7^

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

```
XSDK_APIENTRY XSDK_GetMode(
XSDK_HANDLE hCamera,
long* plMode
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**Remarks**
This function can be used in State S3.

**See Also**
XSDK_SetMode, XSDK_CapMode


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.7. Release Control**

**4.1.7.1. XSDK_CapRelease**

**Description**
Queries supported release-related modes (shutter release, AE-L, AF-L, ...) when the system is in PC priority mode.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plNumReleaseMode (OUT) The number of supported XSDK_Release settings.
plReleaseMode (OUT) If plReleaseMode is NULL, the function will return only plNumReleaseMode
with the number of supported XSDK_Release lReleaseMode settings.
Otherwise it will return plReleaseMode with a list of the XSDK_Release
lReleaseMode settings supported.
Allocate sizeof(long) * (*plNumReleaseMode) bytes of space before calling
this function.
XSDK_RELEASE_SHOOT_S1OFF Shutter button pressed all the way down and
then released.
XSDK_RELEASE_S1ON Shutter button pressed halfway.
XSDK_RELEASE_N_S1OFF Shutter button released from the state of
pressing halfway.
XSDK_RELEASE_S2_S1OFF Shutter button pressed full-way from the state
of pressing halfway, then finally released.
XSDK_RELEASE_BULBS2_ON Shutter button pressed full-halfway from the
state of pressing halfway to start BULB
photography.
XSDK_RELEASE_N_BULBS1OFF BULB photography ended.
XSDK_RELEASE_REC_START_S1OFF Shutter button pressed full-halfway from the
state of pressing halfway to start movie
recording.
XSDK_RELEASE_REC_STOP Movie recording ended.

```
XSDK_APIENTRY XSDK_CapRelease(
XSDK_HANDLE hCamera,
long* plNumReleaseMode,
long* plReleaseMode
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
```
XSDK_RELEASE_PIXELSHIFT PIXEL SHIFT MULTI SHOT started.
XSDK_RELEASE_CUSWB CUSTOM WHITE BALANCE measuring shot
started.
XSDK_RELEASE_INSTANTAF Instant AF ON
XSDK_RELEASE_N_INSTANTAF Instant AF OFF
XSDK_RELEASE_AEON AE-L ON
XSDK_RELEASE_N_AEOFF AE-L OFF
XSDK_RELEASE_AFON AF-L ON
XSDK_RELEASE_N_AFOFF AF-L OFF
XSDK_RELEASE_WBLON AW B-L ON
XSDK_RELEASE_N_WBLOFF AW B-L OFF
XSDK_RELEASE_AF AF ON
XSDK_RELEASE_N_AF AF OFF
XSDK_RELEASE_CANCEL Long time-exposure cancelled while in
progress.
```
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_Release

**Sample**
long lNumReleaseMode;
long* plReleaseMode;
XSDK_CapRelease( hCam, &lNumReleaseMode, NULL );
plReleaseMode = new long [lNumReleaseMode];
XSDK_CapRelease( hCam, &lNumReleaseMode, plReleaseMode);
:
delete [] plReleaseMode;


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.7.2. XSDK_Release**

**Description**
Triggers shutter release-related operations (shutter release, AE-L, AF-L, ...) when the system is in PC priority
mode.

**IMPORTANT NOTICE**
To operate full-press shutter button, half-shutter control prior to the full-press shutter is required.
The XSDK_Release for full-press shutter control returns immediately. To ascertain the completion of shooting
operation, you should poll the camera buffer by XSDK_GetBufferCapacity() or XSDK_ReadImageInfo().

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lReleaseMode (IN) See plReleaseMode of XSDK_CapRelease.
pShotOpt (IN)/
(OUT)

```
Specifies the number of pictures to be taken per burst in burst photography modes
and returns the number of pictures actually taken.
pStatus (OUT) Sometimes returns AF status when the function is called for S1- and S2-related
operations..
XSDK_RELEASE_OK AF in focus
XSDK_RELEASE_AF_FAILURE AF is not in focus
XSDK_RELEASE_AF_UNCHECK AF status is not available
```
```
Calls to measure custom white balance return autoexposure status.
XSDK_RELEASE_CWB_AE_NOERROR Custom WB successed
XSDK_RELEASE_CWB_AE_OVER Error with over exposured
XSDK_RELEASE_CWB_AE_UNDER Error with under exposured
```
**Return Value**

```
XSDK_APIENTRY XSDK_Release(
XSDK_HANDLE hCamera,
long lReleaseMode,
long* pShotOpt,
long* pStatus
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
```
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
```
**Remarks**
This function can be used in State S3.

**See Also**
XSDK_CapRelease


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.7.3. XSDK_CapReleaseEx**

**Description**
Queries supported release-related modes (shutter release, AE-L, AF-L, ...) when the system is in CAMERA priority
mode.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plNumReleaseMode (IN) The number of supported XSDK_Release settings.
pulReleaseMode (OUT) If pulReleaseMode is NULL, the function will return only
plNumReleaseMode with the number of supported XSDK_ReleaseEx
ulReleaseMode settings. Otherwise it will return pulReleaseMode with a list
of the XSDK_ReleaseEx ulReleaseMode settings supported.
Allocate sizeof(long) * (*plNumReleaseMode) bytes of space before calling
this function.
XSDK_RELEASE_EX_S1_ON Shutter button pressed halfway.
XSDK_RELEASE_EX_S1_OFF Shutter button released from the state of
pressing halfway.
XSDK_RELEASE_EX_S2_ON Shutter button pressed full-way
XSDK_RELEASE_EX_S2_OFF Shutter button released from the state of
pressing full-way to halfway.
XSDK_RELEASE_EX_REC_START Movie recording button ON (recording started).
Available only if camera has movie recording
button.
XSDK_RELEASE_EX_REC_STOP Movie recording button OFF (recording
ended). Available only if camera has movie
recording button.
XSDK_RELEASE_EX_CUSWB_ON Start CUSTOM WHITE BALANCE measuring
shooting.
XSDK_RELEASE_EX_CUSWB_OFF End CUSTOM WHITE BALANCE measuring
shooting mode.

```
XSDK_APIENTRY XSDK_CapReleaseEx(
XSDK_HANDLE hCamera,
long* plNumReleaseMode,
unsigned long* pulReleaseMode
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
```
XSDK_RELEASE_EX_CANCEL Long time-exposure cancelled while in
progress.
XSDK_RELEASE_EX_INSTANTAF_ON Instant AF ON
XSDK_RELEASE_EX_INSTANTAF_OFF Instant AF OFF
XSDK_RELEASE_EX_AEL_ON AE-L ON
XSDK_RELEASE_EX_AEL_OFF AE-L OFF
XSDK_RELEASE_EX_AFL_ON AF-L ON
XSDK_RELEASE_EX_AFL_OFF AF-L OFF
XSDK_RELEASE_EX_AFON_ON AF ON
XSDK_RELEASE_EX_AFON_OFF AF ON
XSDK_RELEASE_EX_WBL_ON AW B-L ON
XSDK_RELEASE_EX_WBL_OFF AW B-L OFF
XSDK_RELEASE_EX_S1_ON_S2_ON_S2
_OFF_S1_OFF
```
```
Shutter button pressed all the way down and
then released.
XSDK_RELEASE_EX_S2_ON_S2_OFF_S
1_OFF
```
```
Shutter button pressed full-way from the state
of pressing halfway, then finally released
XSDK_RELEASE_EX_S2_OFF_S1_OFF Shutter button pressed full-halfway from the
state of pressing halfway.
```
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_ReleaseEx


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**Sample**
long lNumReleaseMode;
unsigned long* pulReleaseMode;
XSDK_CapReleaseEx( hCam, &lNumReleaseMode, NULL );
pulReleaseMode = new unsigned long [lNumReleaseMode];
XSDK_CapReleaseEx( hCam, &lNumReleaseMode, pulReleaseMode);
:
delete [] pulReleaseMode;


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.7.4. XSDK_ReleaseEx**

**Description**
Triggers shutter release-related operations (shutter release, AE-L, AF-L, ...) when the system is in CAMERA
priority mode.

**IMPORTANT NOTICE**
To operate full-press shutter button, half-shutter control prior to the full-press shutter is required.
The XSDK_ReleaseEx for full-press shutter control returns immediately. To ascertain the completion of shooting
operation, you should poll the camera buffer by XSDK_GetBufferCapacity() or XSDK_ReadImageInfo().

**Syntax**
XSDK_APIENTRY XSDK_ReleaseEx(
XSDK_HANDLE hCamera,
unsigned long ulReleaseMode,
long* pShotOpt,
long* pStatus
);

**Parameters**
hCamera (IN) The camera handle.
ulReleaseMode (IN) See pulReleaseMode of XSDK_CapReleaseEx.
pShotOpt (IN)/
(OUT)

```
Specifies the number of pictures to be taken per burst in burst photography modes
and returns the number of pictures actually taken.
pStatus (OUT) Sometimes returns AF status when the function is called for S1- and S2-related
operations..
XSDK_RELEASE_OK AF in focus
XSDK_RELEASE_AF_FAILURE AF is not in focus
XSDK_RELEASE_AF_UNCHECK AF status is not available
```
```
Calls to measure custom white balance return autoexposure status.
XSDK_RELEASE_CWB_AE_NOERROR Custom WB successed
XSDK_RELEASE_CWB_AE_OVER Error with over exposured
XSDK_RELEASE_CWB_AE_UNDER Error with under exposured
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_CapReleaseEx


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.7.5. XSDK_GetReleaseStatus**

**Description**
Gets the status of release operation.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plReleaseStatus (OUT) Returns release status via bit ON/OFF.
XSDK_RELEASE_STATUS_S1 S1 operation in progress
XSDK_RELEASE_STATUS_BULB BULB release in progress
XSDK_RELEASE_STATUS_AF AF operation in progress
XSDK_RELEASE_STATUS_AEL AE locked
XSDK_RELEASE_STATUS_AFL AF locked
XSDK_RELEASE_STATUS_WBL WB locked
XSDK_RELEASE_STATUS_SHOOTING Burst photography in progress
(other bits) (reserved)

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_CapRelease, XSDK_Release

```
XSDK_APIENTRY XSDK_GetReleaseStatus(
XSDK_HANDLE hCamera,
long* plReleaseStatus,
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.8. Image Acquisition**

**4.1.8.1. XSDK_ReadImageInfo**

**Description**
Gets information from an image from the top of the in-camera buffer.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
pImgInfo (OUT) Returns the image information with a following data structure:
typedef struct{
char strInternalName[32]; // Internal file name
long lFormat; // Image format
long lDataSize; // Data size (file size)
long lImagePixHeight; // Image pixel height
long lImagePixWidth; // Image pixel width
long lImageBitDepth; // Image bit depth
long lPreviewSize; // Size of preview image
} XSDK_ImageInformation;

```
lFormat:
```
```
lFormat & 0x 0 F 00 Description
0x0000 Picture taken with camera rotated 0°.
0x0 600 Picture taken with camera rotated 90°.
0x0 300 Picture taken with camera rotated 180°.
```
```
lFormat & 0x00FF Image format
XSDK_IMAGEFORMAT_RAW RAW
XSDK_IMAGEFORMAT_LIVE Live view JPEG
XSDK_IMAGEFORMAT_NONE No image in the queue
XSDK_IMAGEFORMAT_THUMBNAIL Thmbnail
XSDK_IMAGEFORMAT_JPEG JPEG
XSDK_IMAGEFORMAT_HEIF HEIF
```
```
XSDK_APIENTRY XSDK_ReadImageInfo(
XSDK_HANDLE hCamera,
XSDK_ImageInformation* pImgInfo
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
```
0x0 800 Picture taken with camera rotated 270°.
```
```
lPreviewSize:
If the camera supports preview transfer with a captured image at the top of the
queue,1PreviewSize returns the size of the preview. Use XSDK_ReadPreview to
get the preview. If the camera does not support preview transfer, 1PreviewSize will
return zero.
```
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_ReadImage, XSDK_ReadPreview


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.8.2. XSDK_ReadPreview**

**Description**
Gets a low-resolution image of the image from the top of the in-camera buffer.
The image at the top of the queue is not deleted after the preview is read.
This function can be used with images with a non-zero value for XSDK_ImageInformation::lPreviewSize.
The preview is always in JPEG format. You may find this function useful for Wi-Fi and other slow connections.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
pData (IN) A pointer to the read-image buffer.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_ReadImageInfo

```
XSDK_APIENTRY XSDK_ReadPreview (
XSDK_HANDLE hCamera,
unsigned char* pData,
unsigned long lDataSize
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.8.3. XSDK_ReadImage**

**Description**
Gets a captured image from the top of the in-camera buffer and deletes it from the buffer.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
pData (IN) A pointer to the read-image buffer.
ulDataSize (IN) The number of bytes allocated for pData.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**Note**
We recommend that both the RAW and JPEG pictures shot in RAW+JPEG mode simultaneously have the same file
name.

```
XSDK_APIENTRY XSDK_ReadImage(
XSDK_HANDLE hCamera,
unsigned char* pData,
unsigned long ulDataSize
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.8.4. XSDK_DeleteImage**

**Description**
Deletes a captured image from the top of the in-camera buffer.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_ReadImage, XSDK_ReadImageInfo,

```
XSDK_APIENTRY XSDK_DeleteImage(
XSDK_HANDLE hCamera,
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.8.5. XSDK_GetBufferCapacity**

**Description**
Gets the status of the in-camera buffer.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plShootFrameNum (OUT) Returns the number of frames shot (the number of captured images).
plTotalFrameNum (OUT) Returns the total number of frames.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_ReadImage, XSDK_DeleteImage

```
XSDK_APIENTRY XSDK_GetBufferCapacity(
XSDK_HANDLE hCamera,
long* plShootFrameNum,
long* plTotalFrameNum
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.9. Exposure Control**

**4.1.9.1. XSDK_CapAEMode**

**Description**
Queries supported exposure modes (P/A/S/M) to set.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plNumAEMode (OUT) Returns the number of supported XSDK_SetAEMode settings.
plAEMode (OUT) If not NULL, plAEMode will return a list of the XSDK_SetAEMode settings
supported.
XSDK_AE_OFF 0x0001 Manual mode
XSDK_AE_APERTURE_PRIORITY 0x000 3 Aperture-priority mode
XSDK_AE_SHUTTER_PRIORITY 0x000 4 Shutter-priority mode
XSDK_AE_PROGRAM 0x000 6 Program AE mode

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_SetAEMode, XSDK_GetAEMode

```
XSDK_APIENTRY XSDK_CapAEMode(
XSDK_HANDLE hCamera,
long* plNumAEMode,
long* plAEMode
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**Sample**
long lNumAEMode;
long* plAEMode;
XSDK_CapAEMode ( hCam, & lNumAEMode, NULL );
plAEMode = new long [lNumAEMode];
XSDK_ CapAEMode ( hCam, &lNumAEMode, plAEMode );
:
delete [] plAEMode;


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.9.2. XSDK_SetAEMode**

**Description**
Sets the exposure mode setting.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lAEMode (IN) The exposure mode to which the camera will be set.
See plAEMode of “XSDK_CapAEMode”.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_CapAEMode, XSDK_GetAEMode

```
XSDK_APIENTRY XSDK_SetAEMode(
XSDK_HANDLE hCamera,
long lAEMode,
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.9.3. XSDK_GetAEMode**

**Description**
Gets the exposure mode setting.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plAEMode (OUT) Returns the exposure mode.
See plAEMode of “XSDK_CapAEMode”.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_CapAEMode, XSDK_SetAEMode

```
XSDK_APIENTRY XSDK_GetAEMode(
XSDK_HANDLE hCamera,
long* plAEMode,
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.9.4. XSDK_CapShutterSpeed**

**Description**
Queries supported shutter speeds to set.
The results vary with the exposure mode and shutter type (mechanical or electronic); set the exposure mode and
shutter type before calling this function. (To set the shutter type via the SDK, only the XSDK_SetBackupSettings is
available).

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plNumShutterSpeed (OUT) Returns the number of supported XSDK_SetShutterSpeed settings.
plShutterSpeed (OUT) If not NULL, plShutterSpeed will return a list of the XSDK_SetShutterSpeed
settings supported.
Allocate sizeof(long) * (*plNumShutterSpeed) bytes of space before calling this
function.
Tv SS Value Macro definition
17 3/6 1 /180000 5 XSDK_SHUTTER_1_180000
17 2/6 1 /160000 6 XSDK_SHUTTER_1_160000
17 1 /128000 7 XSDK_SHUTTER_1_128000
1 6 4/6 1 /102400 9 XSDK_SHUTTER_1_102400
1 6 2/6 1 /80000 12 XSDK_SHUTTER_1_80000
16 1 /64000 15 XSDK_SHUTTER_1_60000
1 5 4/6 1 /51200 19 XSDK_SHUTTER_1_5 0000
15 2/6 1/40000 24 XSDK_SHUTTER_1_40000
15 1/32000 30 XSDK_SHUTTER_1_32000
14 5/6 34
14 4/6 1/25000 38 XSDK_SHUTTER_1_ 25600
14 3/6 1/24000 43 XSDK_SHUTTER_1_ 24000
14 2/6 1/20000 48 XSDK_SHUTTER_1_ 20000
14 1/6 54

```
XSDK_APIENTRY XSDK_CapShutterSpeed(
XSDK_HANDLE hCamera,
long* plNumShutterSpeed,
long* plShutterSpeed,
long* plBulbCapable
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
```
14 1/16000 61 XSDK_SHUTTER_1_ 16000
13 5/6 68
13 4/6 1/13000 76 XSDK_SHUTTER_1_ 12800
13 3/6 1/12000 86 XSDK_SHUTTER_1_ 12000
13 2/6 1/10000 96 XSDK_SHUTTER_1_ 10000
13 1/6 108
13 1/8000 122 XSDK_SHUTTER_1_ 8000
12 5/6 137
12 4/6 1/6400 153 XSDK_SHUTTER_1_ 6400
12 3/6 1/6000 172 XSDK_SHUTTER_1_ 6000
12 2/6 1/5000 193 XSDK_SHUTTER_1_ 5000
12 1/6 217
12 1/4000 244 XSDK_SHUTTER_1_ 4000
11 5/6 274
11 4/6 1/3200 307 XSDK_SHUTTER_1_ 3200
11 3/6 1/3000 345 XSDK_SHUTTER_1_ 3000
11 2/6 1/2500 387 XSDK_SHUTTER_1_ 2500
11 1/6 435
11 1/2000 488 XSDK_SHUTTER_1_ 2000
10 5/6 548
10 4/6 1/1600 615 XSDK_SHUTTER_1_ 1600
10 3/6 1/1500 690 XSDK_SHUTTER_1_ 1500
10 2/6 1/1250 775 XSDK_SHUTTER_1_ 1250
10 1/6 870
10 1/1000 976 XSDK_SHUTTER_1_ 1000
9 5/6 1096
9 4/6 1/800 1230 XSDK_SHUTTER_1_ 800
9 3/6 1/750 1381 XSDK_SHUTTER_1_ 750
9 2/6 1/640 1550 XSDK_SHUTTER_1_ 640
9 1/6 1740
9 1/500 1953 XSDK_SHUTTER_1_ 500
8 5/6 2192
8 4/6 1/400 2460 XSDK_SHUTTER_1_ 400
8 3/6 1/350 2762 XSDK_SHUTTER_1_ 350
8 2/6 1/320 3100 XSDK_SHUTTER_1_ 320
8 1/6 3480
8 1/250 3906 XSDK_SHUTTER_1_ 250
7 5/6 4384
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
```
7 4/6 1/200 4921 XSDK_SHUTTER_1_ 200
7 3/6 1/180 5524 XSDK_SHUTTER_1_ 180
7 2/6 1/160 6200 XSDK_SHUTTER_1_ 160
7 1/6 6960
7 1/125 7812 XSDK_SHUTTER_1_ 125
6 5/6 8769
6 4/6 1/100 9843 XSDK_SHUTTER_1_ 100
6 3/6 1/90 11048 XSDK_SHUTTER_1_ 90
6 2/6 1/80 12401 XSDK_SHUTTER_1_ 80
6 1/6 13920
6 1/60 15625 XSDK_SHUTTER_1_ 60
5 5/6 17538
5 4/6 1/50 19686 XSDK_SHUTTER_1_ 50
5 3/6 1/45 22097 XSDK_SHUTTER_1_ 45
5 2/6 1/40 24803 XSDK_SHUTTER_1_ 40
5 1/6 27840
5 1/30 31250 XSDK_SHUTTER_1_ 30
4 5/6 35076
4 4/6 1/25 39372 XSDK_SHUTTER_1_ 25
4 3/6 1/20 44194 XSDK_SHUTTER_1_ 20 H
4 2/6 1/20 49606 XSDK_SHUTTER_1_ 20
4 1/6 55681
4 1/15 62500 XSDK_SHUTTER_1_ 15
3 5/6 70153
3 4/6 1/13 78745 XSDK_SHUTTER_1_ 13
3 3/6 1/10 88388 XSDK_SHUTTER_1_ 10 H
3 2/6 1/10 99212 XSDK_SHUTTER_1_ 10
3 1/6 111362
3 1/8 125000 XSDK_SHUTTER_1_ 8
2 5/6 140307
2 4/6 1/6 157490 XSDK_SHUTTER_1_ 6
2 3/6 1/6 176776 XSDK_SHUTTER_1_6H
2 2/6 1/5 198425 XSDK_SHUTTER_1_ 5
2 1/6 222724
2 1/4 250000 XSDK_SHUTTER_1_ 4
1 5/6 280615
1 4/6 1/3 314980 XSDK_SHUTTER_1_ 3
1 3/6 1/3 353553 XSDK_SHUTTER_1_3H
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
```
1 2/6 1/2.5 396850 XSDK_SHUTTER_1_2P5
1 1/6 445449
1 1/2 500000 XSDK_SHUTTER_1_ 2
5/6 561231
4/6 1/1.6 629960 XSDK_SHUTTER_1_1P6
3/6 1/1.5 707106 XSDK_SHUTTER_1_1P5
2/6 1/1.3 793700 XSDK_SHUTTER_1_1P3
1/6 890898
0 1 ” 1000000 XSDK_SHUTTER_1
```
- 1/6 1122462
- 2/6 1.3” 1259921 XSDK_SHUTTER_1P3
- 3/6 1.5” 1414213 XSDK_SHUTTER_1P5
- 4/6 1.6” 1587401 XSDK_SHUTTER_1P6
- 5/6 1781797
- 1 2 ” 2000000 XSDK_SHUTTER_ 2
- 1 1/6 2244924
- 1 2/6 2.5” 2519842 XSDK_SHUTTER_2P5
- 1 3/6 3 ” 2828427 XSDK_SHUTTER_3H
- 1 4/6 3 ” 3174802 XSDK_SHUTTER_ 3
- 1 5/6 3563594
- 2 4 ” 4000000 XSDK_SHUTTER_ 4
- 2 1/6 4489848
- 2 2/6 5 ” 5039684 XSDK_SHUTTER_ 5
- 2 3/6 6 ” 5656854 XSDK_SHUTTER_6H
- 2 4/6 6 ” 6349604 XSDK_SHUTTER_ 6
- 2 5/6 7127189
- 3 8 ” 8000000 XSDK_SHUTTER_ 8
- 3 1/6 8979696
- 3 2/6 10 ” 10079368 XSDK_SHUTTER_1 0
- 3 3/6 10 ” 11313708 XSDK_SHUTTER_10H
- 3 4/6 13 ” 12699208 XSDK_SHUTTER_1 3
- 3 5/6 14254379
- 4 15 ” 16000000 XSDK_SHUTTER_ 15
- 4 1/6 17959392
- 4 2/6 20 ” 20158736 XSDK_SHUTTER_ 20
- 4 3/6 20 ” 22627416 XSDK_SHUTTER_20H
- 4 4/6 25 ” 25398416 XSDK_SHUTTER_ 25
- 4 5/6 28508758


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
- 5 30 ” 32000000 XSDK_SHUTTER_ 30
0 XSDK_SHUTTER_UNKNOWN
BULB - 1 XSDK_SHUTTER_BULB

```
Please refer the XAPI.H for the full list.
plBulbCapable (OUT) 0: BULB not supported
1: BULB supported in exposure mode M.
```
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.
The results vary with the exposure mode and shutter type (mechanical or electronic); set the exposure mode and
shutter type before calling this function. For example, in program AE mode, *plNumShutterSpeed will be zero.

**See Also**
XSDK_SetShutterSpeed, XSDK_GetShutterSpeed

**Sample**
long lNumShutterSpeed, lBulbCapable;
long* plShutterSpeed;
**XSDK_CapShutterSpeed** ( hCam, &lNumShutterSpeed, NULL, &lBulbCapable );
plShutterSpeed = new long [ lNumShutterSpeed ];
**XSDK_CapShutterSpeed** ( hCam, &lNumShutterSpeed, plShutterSpeed, &lBulbCapable );
:
delete [] plShutterSpeed;


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.9.5. XSDK_SetShutterSpeed**

**Description**
Sets the shutter speed value.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lShutterSpeed (IN) The shutter speed to which the camera will be set.
See plShutterSpeed of “XSDK_CapShutterSpeed”.
1ShutterSpeed is ignored if 1Bulb = 1.
lBulb (IN) 0: lShutterSpeed is valid for setting the shutter speed
1: BULB mode.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_CapShutterSpeed, XSDK_GetShutterSpeed

```
XSDK_APIENTRY XSDK_SetShutterSpeed(
XSDK_HANDLE hCamera,
long lShutterSpeed,
long lBulb
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.9.6. XSDK_GetShutterSpeed**

**Description**
Gets the shutter speed setting.
**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plShutterSpeed (OUT) Returns the shutter speed. If BULB is selected for shutter speed, the function
returns XSDK_SHUTTER_BULB.
XSDK_SHUTTER_UNKNOWN is returned if the function called during playback
or while the setup menu is in use.
See the remarks for XSDK_SS_* for a macro definition.
Calls to this function while the shutter button is pressed halfway may return shutter
speeds in increments of 1/10 EV. For information on negative values, refer to the
header file.
plBulb (OUT) Receive the shutter speed setting is BULB or not.
0: Camera not in BULB mode
1: Camera in BULB mode

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.
In exposure modes P (program AE) and A (aperture-priority AE), the function can be used to query the shutter speed
calculated automatically by the camera, returning a value calculated based on increments of 1/10 Tv.
Use the pre-defined macro XSDK_SS_* to help monitor shutter speed.
The function returns a value for *plShutterSpeed of XSDK_SHUTTER_UNKNOWN for shutter speeds that are not
multiples of 1/6 EV.

**See Also**
XSDK_CapShutterSpeed, XSDK_SetShutterSpeed

```
XSDK_APIENTRY XSDK_GetShutterSpeed(
XSDK_HANDLE hCamera,
long* plShutterSpeed,
long* plBulb
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.9.7. XSDK_CapExposureBias**

**Description**
Queries supported exposure compensations to set.
The results for some models vary with the exposure mode; set the exposure mode before calling this function.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plNumExposureBias (OUT) Returns the number of supported XSDK_SetExposureBias settings.
plExposureBias (OUT) If not NULL, plExposureBias will return a list of the XSDK_SetExposureBias
settings supported.
Allocate sizeof(long) * (*plNumExposureBias) bytes of space before calling this
function.
Value Exposure Comp. Macro definition
: : :

- 150 - 5 EV XSDK_EXPOSURE_BIAS_M5P00
: : :
- 90 - 3 EV XSDK_EXPOSURE_BIAS_M3P00
- 87 - 2.9 EV XSDK_EXPOSURE_BIAS_M2P90
- 85 - 2 5/6 EV XSDK_EXPOSURE_BIAS_M2P83
- 84 - 2.8 EV XSDK_EXPOSURE_BIAS_M2P80
- 81 - 2.7 EV XSDK_EXPOSURE_BIAS_M2P70
- 80 - 2 2/3 EV XSDK_EXPOSURE_BIAS_M2P67
- 78 - 2.6 XSDK_EXPOSURE_BIAS_M2P60
- 75 - 2 1/2 EV XSDK_EXPOSURE_BIAS_M2P50
- 72 - 2.4 XSDK_EXPOSURE_BIAS_M2P40
- 70 - 2 1/3 EV XSDK_EXPOSURE_BIAS_M2P33
- 69 - 2.3 EV XSDK_EXPOSURE_BIAS_M2P30
- 66 - 2.2 EV XSDK_EXPOSURE_BIAS_M2P20
- 65 - 2 1/6 EV XSDK_EXPOSURE_BIAS_M2P17
- 63 - 2.1 EV XSDK_EXPOSURE_BIAS_M2P10

```
XSDK_APIENTRY XSDK_CapExposureBias(
XSDK_HANDLE hCamera,
long* plNumExposureBias,
long* plExposureBias
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
- 60 - 2 EV XSDK_EXPOSURE_BIAS_M2P00
: : :
0 0 EV XSDK_EXPOSURE_BIAS_0
: : :
+150 5 EV XSDK_EXPOSURE_BIAS_P5P00
: : :

```
Value Exposure Step Macro definition
3 1/10 EV XSDK_EXPOSURE_BIAS_STEP_1_10
5 1/6 EV XSDK_EXPOSURE_BIAS_STEP_1_6
10 1/3 EV XSDK_EXPOSURE_BIAS_STEP_1_3
15 1/2 EV XSDK_EXPOSURE_BIAS_STEP_1_2
```
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.
The results for some models vary with the exposure mode; set the exposure mode before calling this function.

**See Also**
XSDK_SetExposureBias, XSDK_GetExposureBias


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.9.8. XSDK_SetExposureBias**

**Description**
Sets the exposure compensation value.
**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lExposureBias (IN) The value to which exposure compensation will be set.
See plExposureBias of XSDK_CapExposureBias for information on supported
values.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_CapExposureBias, XSDK_GetExposureBias

```
XSDK_APIENTRY XSDK_SetExposureBias(
XSDK_HANDLE hCamera,
long lExposureBias
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.9.9. XSDK_GetExposureBias**

**Description**
Gets the exposure compensation setting.
**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plExposureBias (OUT) Returns the current exposure compensation value.
See plExposureBias of XSDK_CapExposureBias for information on supported
values.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_CapExposureBias, XSDK_SetExposureBias

```
XSDK_APIENTRY XSDK_GetExposureBias(
XSDK_HANDLE hCamera,
long* plExposureBias
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.9.10. XSDK_CapDynamicRange**

**Description**
Queries supported dynamic ranges to set.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plNumDynamicRange (IN) Returns the number of supported XSDK_SetDynamicRange settings.
plDynamicRange (IN) If not NULL, plDynamicRange will return a list of the
XSDK_SetDynamicRange settings supported.
Allocate sizeof(long) * (*plNumDynamicRange) bytes of space before calling
this function.
0xffff XSDK_DRANGE_AUTO Dynamic range AUTO
Other values Dynamic range in %

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_CapSensitivity, XSDK_SetSensitivity, XSDK_GetSensitivity, XSDK_SetDynamicRange,
XSDK_GetDynamicRange

```
XSDK_APIENTRY XSDK_CapSensitivityDR(
XSDK_HANDLE hCamera,
long* plNumDynamicRange,
long* plDynamicRange,
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**Sample**
long lNumDynamicRange;
long* plDynamicRange;
**XSDK_CapDynamicRange** ( hCam, &lNumDynamicRange, NULL );
plDynamicRange = new long [lNumDynamicRange];
**XSDK_CapDynamicRange** ( hCam, & lNumDynamicRange, plDynamicRange );
:
delete []plDynamicRange;


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.9.11. XSDK_SetDynamicRange**

**Description**
Sets the dynamic range value.
**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lDynamicRange (IN) The value to which dynamic range will be set.
See plDynamicRange of XSDK_CapDynamicRange for information on supported
values.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_CapSensitivity, XSDK_SetSensitivity, XSDK_GetSensitivity, XSDK_CapDynamicRange,
XSDK_GetDynamicRange

```
XSDK_APIENTRY XSDK_SetDynamicRange(
XSDK_HANDLE hCamera,
long lDynamicRange
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.9.12. XSDK_GetDynamicRange**

**Description**
Gets the dynamic range setting.
**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plDynamicRange (OUT) Returns the dynamic range.
See plDynamicRange of XSDK_CapDynamicRange for information on supported
values.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_CapSensitivity, XSDK_SetSensitivity, XSDK_GetSensitivity, XSDK_CapDynamicRange,
XSDK_SetDynamicRange

```
XSDK_APIENTRY XSDK_GetDynamicRange(
XSDK_HANDLE hCamera,
long* plDynamicRange
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.9.13. XSDK_CapSensitivity**

**Description**
Queries supported ISO sensitivities to set.
Given that the settings available vary with the value selected for dynamic range, we recommend that you query
sensitivity for all dynamic ranges.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lDR (IN) The dynamic range for which sensitivity is being queried.
See plDynamicRange of XSDK_CapDynamicRange.
plNumSensitivity (OUT) Returns the number of supported settings for XSDK_SetSensitivity.
plSensitivity (OUT) If not NULL, plSensitivity will return a list of the XSDK_SetSensitivity settings
supported.
Allocate sizeof(long) * (*plNumSensitivity) bytes of space before calling this
function.
Macro definition value ISO mode
XSDK_SENSITIVITY_ISO 50 50 ISO 50
XSDK_SENSITIVITY_ISO 60 60 ISO 60
XSDK_SENSITIVITY_ISO 64 64 ISO 6 4
XSDK_SENSITIVITY_ISO 80 80 ISO 80
XSDK_SENSITIVITY_ISO100 100 ISO 100
XSDK_SENSITIVITY_ISO1 25 125 ISO 125
XSDK_SENSITIVITY_ISO1 60 160 ISO 160
XSDK_SENSITIVITY_ISO200 200 ISO 200
XSDK_SENSITIVITY_ISO250 250 ISO 250
XSDK_SENSITIVITY_ISO320 320 ISO 320
XSDK_SENSITIVITY_ISO400 400 ISO 400
XSDK_SENSITIVITY_ISO500 500 ISO 500
XSDK_SENSITIVITY_ISO640 640 ISO 640
XSDK_SENSITIVITY_ISO800 800 ISO 800

```
XSDK_APIENTRY XSDK_CapSensitivity(
XSDK_HANDLE hCamera,
ｌong lDR,
long* plNumSensitivity,
long* plSensitivity
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
```
XSDK_SENSITIVITY_ISO1000 1000 ISO 1000
XSDK_SENSITIVITY_ISO1250 1250 ISO 1250
XSDK_SENSITIVITY_ISO1600 1600 ISO 1600
XSDK_SENSITIVITY_ISO2000 2000 ISO 2000
XSDK_SENSITIVITY_ISO2500 2500 ISO 2500
XSDK_SENSITIVITY_ISO3200 3200 ISO 3200
XSDK_SENSITIVITY_ISO4000 4000 ISO 4000
XSDK_SENSITIVITY_ISO5000 5000 ISO 5000
XSDK_SENSITIVITY_ISO6400 6400 ISO 6400
XSDK_SENSITIVITY_ISO 8000 8000 ISO 8000
XSDK_SENSITIVITY_ISO 10000 10000 ISO 10000
XSDK_SENSITIVITY_ISO12800 12800 ISO 12800
XSDK_SENSITIVITY_ISO 16000 16000 ISO 16000
XSDK_SENSITIVITY_ISO 20000 20000 ISO 20000
XSDK_SENSITIVITY_ISO25600 25600 ISO 25600
XSDK_SENSITIVITY_ISO 32000 32000 ISO 32000
XSDK_SENSITIVITY_ISO 40000 40000 ISO 40000
XSDK_SENSITIVITY_ISO51200 51200 ISO 51200
XSDK_SENSITIVITY_ISO 64000 64000 ISO 64000
XSDK_SENSITIVITY_ISO 80000 80000 ISO 80000
XSDK_SENSITIVITY_ISO 102400 102400 ISO 102400
: : :
XSDK_SENSITIVITY_AUTO_1 - 1 ISO AUTO (1)
XSDK_SENSITIVITY_AUTO_2 - 2 ISO AUTO (2)
XSDK_SENSITIVITY_AUTO_3 - 3 ISO AUTO (3)
XSDK_SENSITIVITY_AUTO_4 - 4 ISO AUTO (4)
XSDK_SENSITIVITY_AUTO - 10 ISO AUTO
: : :
XSDK_SENSITIVITY_AUTO 400 - 400 ISO AUTO 400
XSDK_SENSITIVITY_AUTO800 - 800 ISO AUTO 800
XSDK_SENSITIVITY_AUTO1600 - 1600 ISO AUTO 1600
XSDK_SENSITIVITY_AUTO3200 - 3200 ISO AUTO 3200
XSDK_SENSITIVITY_AUTO6400 - 6400 ISO AUTO 6400
: : :
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**

**Sample**
long lNumSensitivity;
long* plSensitivity;
**XSDK_CapSensitivity** ( hCam, XSDK_DRANGE_AUTO, &lNumSensitivity, NULL );
plSensitivity = new long [lNumSensitivity];
**XSDK_CapDynamicRange** ( hCam, XSDK_DRANGE_AUTO, &lNumSensitivity, plSensitivity);
:
delete []plSensitivity;


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.9.14. XSDK_SetSensitivity**

**Description**
Sets the ISO sensitivity value.
**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lSensitivity (IN) The value to which sensitivity will be set.
See plSensitivity of “XSDK_CapSensitivity” for information on supported values.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**

```
XSDK_APIENTRY XSDK_SetSensitivity(
XSDK_HANDLE hCamera,
long lSensitivity
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.9.15. XSDK_GetSensitivity**

**Description**
Gets the ISO sensitivity setting.
**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plSensitivity (OUT) Returns the current value for ISO sensitivity.
See plSensitivity of “XSDK_CapSensitivity” for information on supported values.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**

```
XSDK_APIENTRY XSDK_GetSensitivity(
XSDK_HANDLE hCamera,
long* plSensitivity
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.9.16. XSDK_CapMeteringMode**

**Description**
Queries supported metering modes to set..
The results for some models vary with the option selected for face detection; set face detection before calling this
function.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plNumMeteringMode (OUT) Returns the number of supported XSDK_SetMeteringMode settings.
plMeteringMode (OUT) If not NULL, plMeteringMode will return a list of the XSDK_SetMeteringMode
settings supported.
Allocate sizeof(long) * (*plNumMeteringMode) bytes of space before calling
this function.
icon

XSDK_METERING_AVERAGE 0x0001 (^)
XSDK_METERING_MULTI 0x0003 (^)
XSDK_METERING_CENTER 0x0004 (^)
XSDK_METERING_CENTER_WEIGHTED 0x0002 (^)
XSDK_METERING_SPOT
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Remarks**
This function can be used in State S3.
XSDK_APIENTRY XSDK_CapMeteringMode(
XSDK_HANDLE hCamera,
long* plNumMeteringMode,
long* plMeteringMode
)


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.9.17. XSDK_SetMeteringMode**

**Description**
Sets the metering mode.
**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lMeteringMode (IN) The metering mode

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**

```
XSDK_APIENTRY XSDK_SetMeteringMode(
XSDK_HANDLE hCamera,
long lMeteringMode
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.9.18. XSDK_GetMeteringMode**

**Description**
Gets the metering mode setting.
**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plMeteringMode (OUT) The metering mode

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**

```
XSDK_APIENTRY XSDK_GetMeteringMode(
XSDK_HANDLE hCamera,
long* plMeteringMode
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.9.19. XSDK_CapLensZoomPos**

**Description**
Queries supported zoom positions to set.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plNumZoomPos (OUT) Returns the number of supported zoom positions.
plZoomPos (OUT) If not NULL, plZoomPos returns a list of the zoom positions supported.
Allocate sizeof(long) * (*plNumZoomPos) bytes of space before calling this
function.
plFocalLength (OUT) If not NULL, plFocalLength returns a list of the focal length positions supported.
The values are 100 times the actual focal lengths.
Allocate sizeof(long) * (*plNumZoomPos) bytes of space before calling this
function.
pl35mmFocalLength (OUT) If not NULL, pl35mmFocalLength returns a list of the 35 mm-equivalent focal
length positions supported. The values are 100 times the actual focal lengths.
Allocate sizeof(long) * (*plNumZoomPos) bytes of space before calling this
function.

```
XSDK_APIENTRY XSDK_CapLensZoomPos(
XSDK_HANDLE hCamera,
long* plNumZoomPos,
long* plZoomPos,
long* plFocusLength,
long* pl35mmFocusLength
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.9.20. XSDK_SetLensZoomPos**

**Description**
Sets the zoom position.
**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lZoomPos (IN) The zoom position, in steps.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**

```
XSDK_APIENTRY XSDK_SetLensZoomPos(
XSDK_HANDLE hCamera,
long lZoomPos
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.9.21. XSDK_GetLensZoomPos**

**Description**
Gets the zoom position setting.
**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plZoomPos (OUT) The zoom position, in steps.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**

```
XSDK_APIENTRY XSDK_GetLensZoomPos(
XSDK_HANDLE hCamera,
long* plZoomPos
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.9.22. XSDK_CapAperture**

**Description**
Queries supported aperture values to set.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lZoomPos (IN) The zoom position retrieved using “XSDK_CapLensZoomPos”.
plNumAperture (OUT) Returns the number of XSDK_SetAperture settings available at zoom position
lZoomPos.
plFNumber (OUT) If not NULL, plFNumber returns a list of the XSDK_SetAperture settings available
at zoom position lZoomPos.
Allocate sizeof(long) * (*plNumAperture) bytes of space before calling this
function.
The aperture values returned are 100 times the actual F numbers.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**

```
XSDK_APIENTRY XSDK_CapAperture(
XSDK_HANDLE hCamera,
long lZoomPos,
long* plNumAperture,
long* plFNumber
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.9.23. XSDK_SetAperture**

**Description**
Sets the aperture value.
**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lFNumber (IN) Returns the current aperture value, expressed as the F number multiplied by 100.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**

```
XSDK_APIENTRY XSDK_SetAperture(
XSDK_HANDLE hCamera,
long lFNumber
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.9.24. XSDK_GetAperture**

**Description**
Gets the aperture setting.
**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plFNumber (OUT) Receive the aperture in F number.
The value is hundredfold value of the actual aperture F number.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**

```
XSDK_APIENTRY XSDK_GetAperture(
XSDK_HANDLE hCamera,
long* plFNumber
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.10. White Balance Control**

**4.1.10.1. XSDK_CapWBMode**

**Description**
Queries supported white-balance modes to set.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plNumWBMode (OUT) Returns the number of supported XSDK_SetWBMode settings.
plWBMode (OUT) If not NULL, plWBMode returns a list of the XSDK_SetWBMode settings
supported.
Allocate sizeof(long) * (*plNumWBMode) bytes of space before calling this
function.
XSDK_WB_AUTO AUTO
XSDK_WB_AUTO_WHITE_PRIORITY AUTO (WHITE PRIORITY)
XSDK_WB_AUTO_AMBIENCE_PRIORITY AUTO (AMBIENCE PRIORITY)
XSDK_WB_CUSTOM1 CUSTOM1
XSDK_WB_CUSTOM 2 CUSTOM2
XSDK_WB_CUSTOM 3 CUSTOM3
XSDK_WB_COLORTEMP COLOR TEMPERATURE
XSDK_WB_DAYLIGHT DAYLIGHT / FINE
XSDK_WB_SHADE SHADE
XSDK_WB_FLUORESCENT1 FLUORESCENT- 1
XSDK_WB_FLUORESCENT2 FLUORESCENT- 2
XSDK_WB_FLUORESCENT3 FLUORESCENT- 3
XSDK_WB_INCANDESCENT INCANDESCENT
XSDK_WB_UNDER_WATER UNDERWATER

```
XSDK_APIENTRY XSDK_CapWBMode(
XSDK_HANDLE hCamera,
long* plNumWBMode,
long* plWBMode
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_CapWBMode, XSDK_SetWBMode, XSDK_GetWBMode
XSDK_SetWBColorTemp, XSDK_GetWBColorTemp
SetWhiteBalanceMode, GetWhiteBalanceMode, SetWhiteBalanceTune, GetWhiteBalanceTune


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.10.2. XSDK_SetWBMode**

**Description**
Sets the white-balance mode.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lWBMode (IN) The white-balance mode.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**See Also**
XSDK_CapWBMode, XSDK_GetWBMode,
XSDK_CapWBColorTemp, XSDK_SetWBColorTemp, XSDK_GetWBColorTemp
SetWhiteBalanceMode, GetWhiteBalanceMode, SetWhiteBalanceTune, GetWhiteBalanceTune

```
APIENTRY XSDK_SetWBMode(
XSDK_HANDLE hCamera,
long lWBMode,
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.10.3. XSDK_GetWBMode**

**Description**
Gets the white-balance mode setting.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
*plWBMode (OUT) The current white-balance mode.
See lWBMode of “XSDK_SetWBMode”.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**See Also**
XSDK_CapWBMode, XSDK_SetWBMode,
XSDK_CapWBColorTemp, XSDK_SetWBColorTemp, XSDK_GetWBColorTemp
SetWhiteBalanceMode, GetWhiteBalanceMode, SetWhiteBalanceTune, GetWhiteBalanceTune

```
APIENTRY XSDK_GetWBMode(
XSDK_HANDLE hCamera,
long* plWBMode,
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.10.4. XSDK_CapWBColorTemp**

**Description**
Queries supported color temperatures to set available when WBMode=ColorTemperature.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plNumWBColorTemp (OUT) Returns the number of supported XSDK_SetWBColorTemp settings.
plWBColorTemp (OUT) If not NULL, plWBColorTemp returns a list of the XSDK_SetWBColorTemp
settings supported.
Allocate sizeof(long) * (*plNumWBColorTemp) bytes of space before calling
this function.
XSDK_WB_COLORTEMP_2500 2500K
XSDK_WB_COLORTEMP_2550 2550K
XSDK_WB_COLORTEMP_2650 2650K
XSDK_WB_COLORTEMP_2700 2700K
XSDK_WB_COLORTEMP_2800 2800K
XSDK_WB_COLORTEMP_2850 2850K
XSDK_WB_COLORTEMP_2950 2950K
XSDK_WB_COLORTEMP_3000 3000K
XSDK_WB_COLORTEMP_3100 3100K
XSDK_WB_COLORTEMP_3200 3200K
XSDK_WB_COLORTEMP_3300 3300K
XSDK_WB_COLORTEMP_3400 3400K
XSDK_WB_COLORTEMP_3600 3600K
XSDK_WB_COLORTEMP_3700 3700K
XSDK_WB_COLORTEMP_3800 3800K
XSDK_WB_COLORTEMP_4000 4000K
XSDK_WB_COLORTEMP_4200 4200K
XSDK_WB_COLORTEMP_4300 4300K
XSDK_WB_COLORTEMP_4500 4500K
XSDK_WB_COLORTEMP_4800 4800K

```
XSDK_APIENTRY XSDK_CapWBColorTemp(
XSDK_HANDLE hCamera,
long* plNumWBColorTemp,
long* plWBColorTemp
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
```
XSDK_WB_COLORTEMP_5000 5000K
XSDK_WB_COLORTEMP_5300 5300K
XSDK_WB_COLORTEMP_5600 5600K
XSDK_WB_COLORTEMP_5900 5900K
XSDK_WB_COLORTEMP_6300 6300K
XSDK_WB_COLORTEMP_6700 6700K
XSDK_WB_COLORTEMP_7100 7100K
XSDK_WB_COLORTEMP_7700 7700K
XSDK_WB_COLORTEMP_8300 8300K
XSDK_WB_COLORTEMP_9100 9100K
XSDK_WB_COLORTEMP_10000 10000K
Other values between 2500 and 10000 The color temperature, in degrees
Kelvin.
```
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**Note**
Color temperatures for cameras later than the X-Pro3 can be set in increments of 10 degrees Kelvin.

**See Also**
XSDK_CapWBMode, XSDK_SetWBMode, XSDK_GetWBMode
XSDK_SetWBColorTemp, XSDK_GetWBColorTemp
SetWhiteBalanceMode, GetWhiteBalanceMode, SetWhiteBalanceTune, GetWhiteBalanceTune


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.10.5. XSDK_SetWBColotTemp**

**Description**
Sets the color temperature value for WBMode=ColorTemperature.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lColorTemp (IN) The color temperature, in degrees Kelvin.
XSDK_WB_COLORTEMP_2500 2500K
XSDK_WB_COLORTEMP_2550 2550K
XSDK_WB_COLORTEMP_2650 2650K
XSDK_WB_COLORTEMP_2700 2700K
XSDK_WB_COLORTEMP_2800 2800K
XSDK_WB_COLORTEMP_2850 2850K
XSDK_WB_COLORTEMP_2950 2950K
XSDK_WB_COLORTEMP_3000 3000K
XSDK_WB_COLORTEMP_3100 3100K
XSDK_WB_COLORTEMP_3200 3200K
XSDK_WB_COLORTEMP_3300 3300K
XSDK_WB_COLORTEMP_3400 3400K
XSDK_WB_COLORTEMP_3600 3600K
XSDK_WB_COLORTEMP_3700 3700K
XSDK_WB_COLORTEMP_3800 3800K
XSDK_WB_COLORTEMP_4000 4000K
XSDK_WB_COLORTEMP_4200 4200K
XSDK_WB_COLORTEMP_4300 4300K
XSDK_WB_COLORTEMP_4500 4500K
XSDK_WB_COLORTEMP_4800 4800K
XSDK_WB_COLORTEMP_5000 5000K
XSDK_WB_COLORTEMP_5300 5300K
XSDK_WB_COLORTEMP_5600 5600K
XSDK_WB_COLORTEMP_5900 5900K

```
APIENTRY XSDK_SetWBColorTemp(
XSDK_HANDLE hCamera,
long lColorTemp
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
```
XSDK_WB_COLORTEMP_6300 6300K
XSDK_WB_COLORTEMP_6700 6700K
XSDK_WB_COLORTEMP_7100 7100K
XSDK_WB_COLORTEMP_7700 7700K
XSDK_WB_COLORTEMP_8300 8300K
XSDK_WB_COLORTEMP_9100 9100K
XSDK_WB_COLORTEMP_10000 10000K
Other values between 2500 and 10000 The color temperature, in degrees
Kelvin.
```
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Note**
Color temperatures for cameras later than the X-Pro3 can be set in increments of 10 degrees Kelvin

**See Also**
XSDK_CapWBMode, XSDK_SetWBMode, XSDK_GetWBMode
XSDK_CapWBColorTemp, XSDK_GetWBColorTemp
SetWhiteBalanceMode, GetWhiteBalanceMode, SetWhiteBalanceTune, GetWhiteBalanceTune


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.10.6. GetWBColorTemp**

**Description**
Gets the color temperature setting for WBMode=ColorTemperature.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
*plColorTemp (OUT) Returns the current color temperature, in degrees Kelvin.
See lColorTemp of “XSDK_SetWBColorTemp”.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Note**
Cameras newer than X-Pro3 can be set color temperature in 10 degree unit.

**See Also**
XSDK_CapWBMode, XSDK_SetWBMode, XSDK_GetWBMode
XSDK_CapWBColorTemp, XSDK_SetWBColorTemp
SetWhiteBalanceMode, GetWhiteBalanceMode, SetWhiteBalanceTune, GetWhiteBalanceTune

```
APIENTRY XSDK_GetWBColorTemp(
XSDK_HANDLE hCamera,
long* plColorTemp
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.11. Media Recording Control**

**4.1.11.1. XSDK_CapMediaRecord**

**Description**
Queries supported media recording control modes to set.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plNumMediaRecord (OUT) Returns the number of supported XSDK_SetMediaRecord settings.
plMediaRecord (OUT) If not NULL, plMediaRecord returns a list of the XSDK_SetMediaRecord
settings supported.
Allocate sizeof(long) * (*plNumMediaRecord) bytes of space before calling
this function.
XSDK_MEDIAREC_RAWJPEG Recording RAW and JPEG
XSDK_MEDIAREC_RAW Recording RAW
XSDK_MEDIAREC_JPEG Recording JPEG
XSDK_MEDIAREC_OFF Recording OFF

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**

```
XSDK_APIENTRY XSDK_CapMediaRecord(
XSDK_HANDLE hCamera,
long* plNumMediaRecord,
long* plMediaRecord
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.11.2. XSDK_SetMediaRecord**

**Description**
Sets the media recording control modes for the tethering operation.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lMediaRecord (IN)
XSDK_MEDIAREC_RAWJPEG Recording RAW and JPEG
XSDK_MEDIAREC_RAW Recording RAW
XSDK_MEDIAREC_JPEG Recording JPEG
XSDK_MEDIAREC_OFF Recording OFF

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
XSDK Ver.1.1 or later only.

**See Also**

```
APIENTRY XSDK_SetMediaRecord(
XSDK_HANDLE hCamera,
long lMediaRecord
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.11.3. XSDK_GetMediaRecord**

**Description**
Gets the media recording control modes setting for the tethering operation.
**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plMediaRecord (OUT) See lMediaRecord of XSDK_SetMediaRecord

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
XSDK Ver.1.1 or later only.

**See Also**

```
APIENTRY XSDK_GetMediaRecord(
XSDK_HANDLE hCamera,
long* plMediaRecord
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.12. Operation Mode Control**

**4.1.12.1. XSDK_CapForceMode**

**Description**
Queries supported operation modes to set.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plNumForceMode (OUT) Returns the number of supported XSDK_SetForceMode settings.
plForceMode (OUT) If not NULL, plForceMode returns a list of the XSDK_SetForceMode settings
supported.
Allocate sizeof(long) * (*plNumForceMode) bytes of space before calling this
function.
XSDK_FORCESHOOTSTANDBY_SHOOT Returned if the camera
allows shooting mode to
be selected remotely.
XSDK_FORCESHOOTSTANDBY_PLAYBACK Returned if the camera
allows playback mode to
be selected remotely.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**

```
XSDK_APIENTRY XSDK_CapForceMode(
XSDK_HANDLE hCamera,
long* plNumForceMode,
long* plForceMode
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.12.2. XSDK_SetForceMode**

**Description**
Forcibly changes the operating mode to SHOOTING MODE.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lForceMode
(IN)
XSDK_FORCESHOOTSTANDBY_SHOOT Forcibly selects shooting
mode.
XSDK_FORCESHOOTSTANDBY_PLAYBACK Forcibly selects playback
mode.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
There are currently no cameras that support XSDK_FORCESHOOTSTANDBY_PLAYBACK.

**See Also**

```
APIENTRY XSDK_SetForceMode(
XSDK_HANDLE hCamera,
long lForceMode
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.13. Backup/Retore Settings**

**4.1.13.1. XSDK_SetBackupSettings**

**Description**
Restore camera backup settings.
The settings restored are camera- and in some cases version-dependent.
**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lSize (IN) The size of the backup data.
pBackup (IN) The backup data.
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Remarks**
This function can be used in PC priority mode in State S3.
**Note**
**_Note that_** **XSDK_SetBackupSettings** **_sometimes returns_** **XSDK_ERRCODE_BUSY** **_for_** **XSDK_ERROR****_. To
complete the operation, try calling_** **XSDK_SetBackupSettings** **_again_****.
See Also**
GetBackupSettings

```
APIENTRY XSDK_SetBackupSettings(
XSDK_HANDLE hCamera,
long lSize,
unsigned char* pBackup
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.13.2. XSDK_GetBackupSettings**

**Description**
Backup camera settings.
The backup data is camera dependent and also may version dependent.
**Syntax**

**Parameters**
hCamera (IN) The camera handle.
*plSize (IN/
OUT)

```
The size of the backup data. If pBackup is NULL, *plSize returns the size of the
current camera setting data.
pBackup (IN/
OUT)
```
```
Camera setting data.
```
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Remarks**
This function can be used in PC priority mode in State of S3.
**Note**
**_Note that_** **XSDK_GetBackupSettings** **_sometimes returns_** **XSDK_ERRCODE_BUSY** **_for_** **XSDK_ERROR****_. To
complete the operation, try calling_** **XSDK_GetBackupSettings** **_again._**

**See Also**
SetBackupSettings

```
APIENTRY XSDK_GetBackupSettings(
XSDK_HANDLE hCamera,
long* plSize,
unsigned char* pBackup
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.14. Movie Control**

**4.1.14.1. XSDK_CapMovieShutterSpeed**

**Description**
Queries supported shutter speeds to set in movie mode.
The results vary with the exposure mode and shutter type (mechanical or electronic); set the exposure mode and
shutter type before calling this function. (To set the shutter type via the SDK, only the XSDK_SetBackupSettings is
available).

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
*plNumShutterSpeed (OUT) Returns the number of supported XSDK_SetMovieShutterSpeed settings.
*pllShutterSpeed (OUT) If not NULL, pllShutterSpeed will return a list of
the XSDK_SetMovieShutterSpeed settings supported.
Allocate sizeof(long long) * (*plNumShutterSpeed) bytes of space before
calling this function.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**

##### 4.1.14.3. XSDK_GetMovieShutterSpeed

```
APIENTRY XSDK_CapMovieShutterSpeed(
XSDK_HANDLE hCamera,
long* plNumShutterSpeed
long long* pllShutterSpeed
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.14.2. XSDK_SetMovieShutterSpeed**

**Description**
Sets the shutter speed value in movie mode.
**Syntax**

**Parameters**
hCamera (IN) The camera handle.
llShutterSpeed (IN) The value to which shutter speed will be set.
See pllShutterSpeed of “XSDK_CapMovieShutterSpeed” for information on
supported values.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_CapMovieShutterSpeed, XSDK_GetMovieShutterSpeed

```
APIENTRY XSDK_SetMovieShutterSpeed(
XSDK_HANDLE hCamera,
long long llShutterSpeed
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.14.3. XSDK_GetMovieShutterSpeed**

**Description**
Gets the shutter speed setting in movie mode.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
*pllShutterSpeed (OUT) Returns the current value for shutter speed.
See llShutterSpeed of “XSDK_SetMovieShutterSpeed”.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.
In exposure modes P (program AE) and A (aperture-priority AE), the function can be used to query the shutter speed
calculated automatically by the camera, returning a value calculated based on increments of 1/10 Tv.
Use the pre-defined macro XSDK_SS_* to help monitor shutter speed.
The function returns a value for *plShutterSpeed of XSDK_SHUTTER_UNKNOWN for shutter speeds that are not
multiples of 1/6 EV.

**See Also**
XSDK_CapMovieShutterSpeed, XSDK_SetMovieShutterSpeed

```
APIENTRY XSDK_GetMovieShutterSpeed(
XSDK_HANDLE hCamera,
long long* pllShutterSpeed
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
##### 4.1.14.4. XSDK_CapMovieExposureBias

**Description**
Queries supported exposure compensations to set in movie mode.
The results for some models vary with the exposure mode; set the exposure mode before calling this function.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
*plNumExposureBias (OUT) Returns the number of supported XSDK_SetMovieExposureBias settings.
*plExposureBias (OUT) If not NULL, plExposureBias will return a list of
the XSDK_SetMovieExposureBias settings supported.
Allocate sizeof(long) * (*plNumExposureBias) bytes of space before calling
this function.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.
The results for some models vary with the exposure mode; set the exposure mode before calling this function.

**See Also**

##### 4.1.14.6. XSDK_GetMovieExposureBias

```
APIENTRY XSDK_CapMovieExposureBias(
XSDK_HANDLE hCamera,
long* plNumExposureBias
long* plExposureBias
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
##### 4.1.14.5. XSDK_SetMovieExposureBias

**Description**
Sets the exposure compensation value in movie mode.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lExposureBias (IN) The value to which exposure compensation will be set.
See plExposureBias of “XSDK_CapMovieExposureBias” for information on
supported values.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remark**
This function can be used in State S3.

**See Also**
XSDK_CapMovieExposureBias, XSDK_GetMovieExposureBias

```
APIENTRY XSDK_SetMovieExposureBias (
XSDK_HANDLE hCamera,
long lExposureBias
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.14.6. XSDK_GetMovieExposureBias**

**Description**
Gets the exposure compensation setting in movie mode.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
*plExposureBias (OUT) Returns the current exposure compensation value.
See lExposureBias of “XSDK_SetMovieExposureBias”.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_CapMovieExposureBias, XSDK_ SetMovieExposureBias

```
APIENTRY XSDK_GetMovieExposureBias (
XSDK_HANDLE hCamera,
long* plExposureBias
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
##### 4.1.14.7. XSDK_CapMovieSensitivity

**Description**
Queries supported ISO sensitivities to set in movie mode.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
*plNumSensitivity (OUT) Returns the number of supported XSDK_SetMovieSensitivity settings.
*plSensitivity (OUT) If not NULL, plSensitivity will return a list of the XSDK_SetMovieSensitivity
settings supported.
Allocate sizeof(long) * (*plNumSensitivity) bytes of space before calling this
function.
Macro definition value mode
XSDK_SENSITIVITY_MOVIE_AUTO - 10 MOVIE AUTO
The other parameters are the same as XSDK_CapSensitivity.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**

##### 4.1.14.9. XSDK_GetMovieSensitivity

```
APIENTRY XSDK_CapMovieSensitivity(
XSDK_HANDLE hCamera,
long* plNumSensitivity
long* plSensitivity
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
##### 4.1.14.8. XSDK_SetMovieSensitivity

**Description**
Sets the ISO sensitivity value in movie mode.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lSensitivity (IN) The value to which ISO sensitivity will be set.
See plSensitivity of “XSDK_CapMovieSensitivity” for information on
supported values.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_CapMovieSensitivity, XSDK_GetMovieSensitivity

```
APIENTRY XSDK_SetMovieSensitivity(
XSDK_HANDLE hCamera,
long lSensitivity
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.14.9. XSDK_GetMovieSensitivity**

**Description**
Gets the ISO sensitivity setting in movie mode.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
*plSensitivity (OUT) Returns the current value for ISO sensitivity.
See plSensitivity of “XSDK_CapMovieSensitivity” for information on
supported values.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_CapMovieSensitivity, XSDK_SetMovieSensitivity

```
APIENTRY XSDK_GetMovieSensitivity(
XSDK_HANDLE hCamera,
long* plSensitivity
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
##### 4.1.14.10. XSDK_CapMovieAperture

**Description**
Queries supported aperture values to set in movie mode.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
*plNumAperture (OUT) Returns the number of supported XSDK_SetMovieAperture settings.
*plAperture (OUT) If not NULL, plAperture will return a list of the XSDK_SetMovieAperture
settings supported.
Allocate sizeof(long) * (*plNumAperture) bytes of space before calling this
function.
The aperture values returned are 100 times the actual F numbers.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**

##### 4.1.14.12. XSDK_GetMovieAperture

```
APIENTRY XSDK_CapMovieAperture(
XSDK_HANDLE hCamera,
long* plNumAperture
long* plAperture
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
##### 4.1.14.11. XSDK_SetMovieAperture

**Description**
Sets the aperture value in movie mode.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lAperture (IN) The value to which aperture will be set.
The aperture values returned are 100 times the actual F numbers.
See plAperture of “XSDK_CapMovieAperture” for information on supported
values.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_CapMovieAperture, XSDK_GetMovieAperture

```
APIENTRY XSDK_SetMovieAperture(
XSDK_HANDLE hCamera,
long lAperture
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.14.12. XSDK_GetMovieAperture**

**Description**
Gets the aperture setting in movie mode.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
*plAperture (OUT) Returns the current value for aperture.
See lAperture of “XSDK_SetMovieAperture”.
The aperture values returned are 100 times the actual F numbers.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_CapMovieAperture, XSDK_SetMovieAperture

```
APIENTRY XSDK_GetMovieAperture(
XSDK_HANDLE hCamera,
long* lAperture
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
##### 4.1.14.13. XSDK_ CapMovieDynamicRange

**Description**
Queries supported dynamic ranges to set in movie mode.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plNumDynamicRange (OUT) Returns the number of supported XSDK_ SetMovieDynamicRange settings.
plDynamicRange (OUT) If not NULL, plDynamicRange returns a list of the XSDK_SetWBMode
settings supported.
Allocate sizeof(long) * (*plNumDynamicRange) bytes of space before calling
this function.
XSDK_DRANGE_AUTO AUTO
100 100%
200 200%
400 400%
800 8 00%^
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**

##### 4.1.14.15. XSDK_ GetMovieDynamicRange

```
XSDK_APIENTRY XSDK_ CapMovieDynamicRange(
XSDK_HANDLE hCamera,
long* plNumDynamicRange,
long* plDynamicRange
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
##### 4.1.14.14. XSDK_ SetMovieDynamicRange

**Description**
Sets the dynamic range value in movie mode.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lDynamicRange (IN) The value to which dynamic range will be set.
See plDynamicRange of XSDK_CapMOveDynamicRange for information on
supported values.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_ GetMovieDynamicRange, XSDK_ CapMovieDynamicRange

```
APIENTRY XSDK_ SetMovieDynamicRange(
XSDK_HANDLE hCamera,
long lDynamicRange
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.14.15. XSDK_ GetMovieDynamicRange**

**Description**
Gets the dynamic range setting in movie mode.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plDynamicRange (OUT) Returns the current value for dynamic range.
See lDynamicRangeof “XSDK_SetMovieDynamicRange”.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_ SetMovieDynamicRange, XSDK_ CapMovieDynamicRange

```
APIENTRY XSDK_ GetMovieDynamicRange (
XSDK_HANDLE hCamera,
long* plDynamicRange
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
##### 4.1.14.16. XSDK_ CapMovieMeteringMode

**Description**
Queries supported metering modes to set in movie mode.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plNumMeteringMode (OUT) Returns the number of supported XSDK_SetMovieMeteringMode settings.
plMeteringMode (OUT) If not NULL, plMeteringMode returns a list of the XSDK_SetWBMode settings
supported.
Allocate sizeof(long) * (*plNumMeteringMode) bytes of space before calling
this function.
XSDK_METERING_AVERAGE Average
XSDK_METERING_CENTER_WEIGHTED Center Weighted
XSDK_METERING_MULTI Multi spot
XSDK_METERING_CENTER^ Center spot^
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**

##### 4.1.14.18. XSDK_ GetMovieMeteringMode

```
XSDK_APIENTRY XSDK_CapMovieMeteringMode(
XSDK_HANDLE hCamera,
long* plNumMeteringMode ,
long* plMeteringMode
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
##### 4.1.14.17. XSDK_ SetMovieMeteringMode

**Description**
Sets the metering mode in movie mode.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lMeteringMode (IN) The value to which metering mode will be set.
See plMeteringMode of XSDK_CapMovieMeteringMode for information on
supported values.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_ GetMovieMeteringMode, XSDK_ CapMovieMeteringMode

```
APIENTRY XSDK_ SetMovieMeteringMode (
XSDK_HANDLE hCamera,
long lMeteringMode
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.14.18. XSDK_ GetMovieMeteringMode**

**Description**
Gets the metering mode setting in movie mode.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plMeteringMode (OUT) Returns the current value for metering mode.
See lMeteringModeof “XSDK_ SetMovieMeteringMode”.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_ SetMovieMeteringMode, XSDK_ CapMovieMeteringMode

```
APIENTRY XSDK_ GetMovieMeteringMode (
XSDK_HANDLE hCamera,
long* plMeteringMode
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
##### 4.1.14.19. XSDK_CapMovieWBMode

**Description**
Queries supported white-balance modes to set in movie mode.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plNumWBMode (OUT) Returns the number of supported XSDK_SetMovieWBMode settings.
plWBMode (OUT) If not NULL, plWBMode returns a list of the XSDK_SetMovieWBMode settings
supported.
Allocate sizeof(long) * (*plNumWBMode) bytes of space before calling this
function.
XSDK_WB_AUTO AUTO
XSDK_WB_AUTO_WHITE_PRIORITY AUTO (WHITE PRIORITY)
XSDK_WB_AUTO_AMBIENCE_PRIORITY AUTO (AMBIENCE PRIORITY)
XSDK_WB_DAYLIGHT DAYLIGHT / FINE
XSDK_WB_INCANDESCENT INCANDESCENT
XSDK_WB_UNDER_WATER UNDERWATER
XSDK_WB_FLUORESCENT1 FLUORESCENT- 1
XSDK_WB_FLUORESCENT2 FLUORESCENT- 2
XSDK_WB_FLUORESCENT3 FLUORESCENT- 3
XSDK_WB_SHADE SHADE
XSDK_WB_COLORTEMP COLOR TEMPERATURE
XSDK_WB_CUSTOM1 CUSTOM1
XSDK_WB_CUSTOM 2 CUSTOM2
XSDK_WB_CUSTOM 3 CUSTOM3
XSDK_WB_CUSTOM 4 CUSTOM 4
XSDK_WB_CUSTOM^5 CUSTOM^5^

```
APIENTRY XSDK_CapMovieWBMode(
XSDK_HANDLE hCamera,
long* plNumWBMode,
long* plWBMode
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_CapMovieWBMode, XSDK_SetMovieWBMode, XSDK_GetMovieWBMode
XSDK_SetMovieWBColorTemp, XSDK_GetMovieWBColorTemp
SetWhiteBalanceMode, GetWhiteBalanceMode, SetWhiteBalanceTune, GetWhiteBalanceTune


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
##### 4.1.14.20. XSDK_SetMovieWBMode

**Description**
Sets the white-balance mode in movie mode.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lWBMode (IN) The WHITE BALANCE.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_CapMovieWBMode, XSDK_GetMovieWBMode,
XSDK_CapMovieWBColorTemp, XSDK_SetMovieWBColorTemp, XSDK_GetMovieWBColorTemp
SetWhiteBalanceMode, GetWhiteBalanceMode, SetWhiteBalanceTune, GetWhiteBalanceTune

```
APIENTRY XSDK_SetMovieWBMode(
XSDK_HANDLE hCamera,
long lWBMode,
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
##### 4.1.14.21. XSDK_GetMovieWBMode

**Description**
Gets the white-balance mode setting in movie mode.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
*plWBMode (OUT) The current WHITE BALANCE.
See lWBMode of “XSDK_SetMovieWBMode”.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**See Also**
XSDK_CapMovieWBMode, XSDK_SetMovieWBMode,
XSDK_CapMovieWBColorTemp, XSDK_SetMovieWBColorTemp, XSDK_GetMovieWBColorTemp
SetWhiteBalanceMode, GetWhiteBalanceMode, SetWhiteBalanceTune, GetWhiteBalanceTune

```
APIENTRY XSDK_GetMovieWBMode(
XSDK_HANDLE hCamera,
long* plWBMode,
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
##### 4.1.14.22. XSDK_CapMovieWBColorTemp

**Description**
Queries supported color temperatures to set available in movie mode when WBMode = ColorTemperature.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
plNumWBColorTemp (OUT) Returns the number of supported XSDK_SetMovieWBColorTemp settings.
plWBColorTemp (OUT) If not NULL,
plWBColorTemp returns a list of the
XSDK_SetMovieWBColorTemp settings supported.
Allocate sizeof(long) * (*plNumWBColorTemp) bytes of space before calling
this function.
XSDK_WB_COLORTEMP_2500 2500K
XSDK_WB_COLORTEMP_2550 2550K
XSDK_WB_COLORTEMP_2650 2650K
XSDK_WB_COLORTEMP_2700 2700K
XSDK_WB_COLORTEMP_2800 2800K
XSDK_WB_COLORTEMP_2850 2850K
XSDK_WB_COLORTEMP_2950 2950K
XSDK_WB_COLORTEMP_3000 3000K
XSDK_WB_COLORTEMP_3100 3100K
XSDK_WB_COLORTEMP_3200 3200K
XSDK_WB_COLORTEMP_3300 3300K
XSDK_WB_COLORTEMP_3400 3400K
XSDK_WB_COLORTEMP_3600 3600K
XSDK_WB_COLORTEMP_3700 3700K
XSDK_WB_COLORTEMP_3800 3800K
XSDK_WB_COLORTEMP_4000 4000K
XSDK_WB_COLORTEMP_4200 4200K
XSDK_WB_COLORTEMP_4300 4300K

```
XSDK_APIENTRY XSDK_CapMovieWBColorTemp(
XSDK_HANDLE hCamera,
long* plNumWBColorTemp,
long* plWBColorTemp
)
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
```
XSDK_WB_COLORTEMP_4500 4500K
XSDK_WB_COLORTEMP_4800 4800K
XSDK_WB_COLORTEMP_5000 5000K
XSDK_WB_COLORTEMP_5300 5300K
XSDK_WB_COLORTEMP_5600 5600K
XSDK_WB_COLORTEMP_5900 5900K
XSDK_WB_COLORTEMP_6300 6300K
XSDK_WB_COLORTEMP_6700 6700K
XSDK_WB_COLORTEMP_7100 7100K
XSDK_WB_COLORTEMP_7700 7700K
XSDK_WB_COLORTEMP_8300 8300K
XSDK_WB_COLORTEMP_9100 9100K
XSDK_WB_COLORTEMP_10000 10000K
Other values between 2500 and 10000 The color temperature, in degrees
Kelvin.
```
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**Note**
Color temperatures for cameras later than the X-Pro3 can be set in increments of 10 degrees Kelvin.

**See Also**
XSDK_CapMovieWBMode, XSDK_SetMovieWBMode, XSDK_GetMovieWBMode
XSDK_SetMovieWBColorTemp, XSDK_GetMovieWBColorTemp
SetWhiteBalanceMode, GetWhiteBalanceMode, SetWhiteBalanceTune, GetWhiteBalanceTune


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
##### 4.1.14.23. XSDK_SetMovieWBColotTemp

**Description**
Sets the color temperature value in movie mode for WBMode = ColorTemperature.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lColorTemp (IN) The COLOR TEMPERATURE, in degrees Kelvin.
XSDK_WB_COLORTEMP_2500 2500K
XSDK_WB_COLORTEMP_2550 2550K
XSDK_WB_COLORTEMP_2650 2650K
XSDK_WB_COLORTEMP_2700 2700K
XSDK_WB_COLORTEMP_2800 2800K
XSDK_WB_COLORTEMP_2850 2850K
XSDK_WB_COLORTEMP_2950 2950K
XSDK_WB_COLORTEMP_3000 3000K
XSDK_WB_COLORTEMP_3100 3100K
XSDK_WB_COLORTEMP_3200 3200K
XSDK_WB_COLORTEMP_3300 3300K
XSDK_WB_COLORTEMP_3400 3400K
XSDK_WB_COLORTEMP_3600 3600K
XSDK_WB_COLORTEMP_3700 3700K
XSDK_WB_COLORTEMP_3800 3800K
XSDK_WB_COLORTEMP_4000 4000K
XSDK_WB_COLORTEMP_4200 4200K
XSDK_WB_COLORTEMP_4300 4300K
XSDK_WB_COLORTEMP_4500 4500K
XSDK_WB_COLORTEMP_4800 4800K
XSDK_WB_COLORTEMP_5000 5000K
XSDK_WB_COLORTEMP_5300 5300K
XSDK_WB_COLORTEMP_5600 5600K
XSDK_WB_COLORTEMP_5900 5900K

```
APIENTRY XSDK_SetMovieWBColorTemp(
XSDK_HANDLE hCamera,
long lColorTemp
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
```
XSDK_WB_COLORTEMP_6300 6300K
XSDK_WB_COLORTEMP_6700 6700K
XSDK_WB_COLORTEMP_7100 7100K
XSDK_WB_COLORTEMP_7700 7700K
XSDK_WB_COLORTEMP_8300 8300K
XSDK_WB_COLORTEMP_9100 9100K
XSDK_WB_COLORTEMP_10000 10000K
Other values between 2500 and 10000 The color temperature, in
degrees Kelvin.
```
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**Note**
Color temperatures for cameras later than the X-Pro3 can be set in increments of 10 degrees Kelvin

**See Also**
XSDK_CapMovieWBMode, XSDK_SetMovieWBMode, XSDK_GetMovieWBMode
XSDK_CapMovieWBColorTemp, XSDK_GetMovieWBColorTemp
SetWhiteBalanceMode, GetWhiteBalanceMode, SetWhiteBalanceTune, GetWhiteBalanceTune


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
##### 4.1.14.24. GetMovieWBColorTemp

**Description**
Gets the movie color temperature setting in movie mode for WBMode = ColorTemperature.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
*plColorTemp (OUT) Returns the current COLOR TEMPERATURE, in degrees Kelvin.
See lColorTemp of “XSDK_SetMovieWBColorTemp”.

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

**Note**
Cameras newer than X-Pro3 can be set color temperature in 10 degree unit.

**See Also**
XSDK_CapMovieWBMode, XSDK_SetMovieWBMode, XSDK_GetMovieWBMode
XSDK_CapMovieWBColorTemp, XSDK_SetMovieWBColorTemp
SetWhiteBalanceMode, GetWhiteBalanceMode, SetWhiteBalanceTune, GetWhiteBalanceTune

```
APIENTRY XSDK_GetMovieWBColorTemp(
XSDK_HANDLE hCamera,
long* plColorTemp
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
**4.1.15. Optional Model-Dependent Function Interface**

##### 4.1.15.1. XSDK_CapProp

**Description**
Queries supported values for a model-dependent function.
The API function “XSDK_CapProp” is used for model-dependent functions with names that begin with “Cap...”.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) The API code. For more information, see the model-dependent header file.
lAPIParam (IN) The number of parameters. For more information, see the model-dependent header
file.
... API-dependent parameters

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

```
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
```
###### 

```
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
##### 4.1.15.2. XSDK_SetProp

**Description**
Sets values for the model-dependent function.
The API function “XSDK_SetProp” is used for model-dependent functions with names that begin with “Set ...”.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) The API code. For more information, see the model-dependent header file.
lAPIParam (IN) The number of parameters. For more information, see the model-dependent header
file.
... API dependent parameters

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

```
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
```
##### 

```
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
COMMON API
```
##### 4.1.15.3. XSDK_GetProp

**Description**
Gets the settings for the model-dependent function.
The API function “XSDK_GetProp” is used for model-dependent functions with names that begin with “Get ...”.

**Syntax**

**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) The API code. For more information, see the model-dependent header file.
lAPIParam (IN) The number of parameters. For more information, see the model-dependent header
file.
... API dependent parameters

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR

**Remarks**
This function can be used in State S3.

```
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
```
##### 

```
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2. MODEL DEPENDENT APIs (Optional Functions)**
Model dependent functions can be accessed via three API functions below:
XSDK_SetProp()
XSDK_GetProp()
XSDK_CapProp().
**In this section, the string <model> represents the name of the target camera model, chosen from the following:
Model name Read <model> as...
FUJIFILM X-T3 X-T3
FUJIFILM X-T 4 X-T 4
FUJIFILM X-Pro 3 X-PRO 3
FUJIFILM GFX 50S GFX 50S
FUJIFILM GFX 50R GFX 50R
FUJIFILM GFX 100 GFX100
FUJIFILM GFX100S GFX100S
FUJIFILM X-S10 X-S 10
FUJIFILM GFX50S II GFX50S II
FUJIFILM X-H2S X-H2S
FUJIFILM X-H2 X-H2
FUJIFILM X-T5 X-T5
FUJIFILM X-S20 X-S20
FUJIFILM GFX100 II GFX100 II
FUJIFILM GFX100S II GFX100S II
FUJIFILM X-M5 X-M5
FUJIFILM GFX100RF GFX100RF**


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1. Focus Control**

##### 4.2.1.1. CapFocusMode

**Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**

(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported focus modes.
**Syntax**
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plFocusMode
);
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapFocusMode
lAPIParam (IN) <model>_API_PARAM_CapFocusMode
plNum (OUT) Returns the number of SetFocusMode settings supported.
plFocusMode (OUT) If plFocusMode is NULL, the function will return only plNum with the number of
supported SetFocusMode settings. Otherwise it will return plFocusMode with a list
of the SetFocusMode settings supported.
Allocate sizeof(long) * (*plNum) bytes of space before calling this function.
**Remarks**
This function can be used in State S3.
**See Also**

##### 4.2.1.3. GetFocusMode

**Sample**
long lAPICode = <model>_API_CODE_CapFocusMode;
long lAPIParam = <model>_API_PARAM_CapFocusMode;
long lNum;


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
long* plFocusMode;
XSDK_CapProp( hCam, lAPICode, lAPIParam, &lNum, NULL );
plFocusMode = new long [lNum];
XSDK_CapProp( hCam, lAPICode, lAPIParam, &lNum, plFocusMode );
:
delete [] plFocusMode;


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API

##### 4.2.1.2. SetFocusMode

**Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**

(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the focus mode.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetFocusMode
lAPIParam (IN) <model>_API_PA R A M_SetFocusMode
lFocusMode (IN)
<model>_FOCUS_MANUAL MANUAL
<model>_FOCUS_AFS AF-S
<model>_FOCUS_AFC AF-C
**Remarks**
This function can be used in State S3.
**See Also**
GetFocusMode
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lFocusMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.3. GetFocusMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the focus mode setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetFocusMode
lAPIParam (IN) <model>_API_PA R A M_GetFocusMode
plFocusMode (OUT) See lFocusMode of “SetFocusMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetFocusMode
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plFocusMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API

##### 4.2.1.4. CapAFMode

**Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**

(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported AF modes.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapAFMode
lAPIParam (IN) <model>_API_PARAM_CapAFMode
lAngle (IN) See lAngle of “SetAFMode”.
plNum (OUT) Returns the number of “SetAFMode” settings supported.
plAFMode (OUT) See plAFMode of “SetAFMode”.
**Remarks**
This function can be used in State S3.
**See Also**

##### 4.2.1.5. SetAFMode

```
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lAngle,
long* plNum,
long* plAFMode
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.5. SetAFMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the AF MODE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetAFMode
lAPIParam (IN) <model>_API_PA R A M_SetAFMode
lAngle (IN)
<model>_ITEM_DIRECTION_CURRENT in camera’s current orientation
<model>_ITEM_DIRECTION_0 when camera is rotated 0° or 180°
<model>_ITEM_DIRECTION_90 when camera is rotated 90°
<model>_ITEM_DIRECTION_270 when camera is rotated 270°
lAFMode (IN) **[GFX 50S/GFX 50R]**
<model>_AF_AREA AREA
<model>_AF_SINGLE SINGLE
<model>_AF_ZONE ZONE
<model>_AF_WIDETRACKING WIDE/TRACKING
**[Other models]**
<model>_AF_AREA AREA
<model>_AF_SINGLE SINGLE
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lAngle,
long lAFMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_AF_ZONE ZONE
<model>_AF_WIDETRACKING WIDE/TRACKING
<model>_AF_ALL ALL
**Remarks**
This function can be used in State S3.
**See Also**

##### 4.2.1.6. GetAFMode


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.6. GetAFMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the AF MODE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetAFMode
lAPIParam (IN) <model>_API_PA R A M_GetAFMode
lAngle (IN) See lAngle of “SetAFMode”.
plAFMode (OUT) See lAFMode of “SetAFMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetAFMode
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lAngle,
long* plAFMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API

##### 4.2.1.7. CapFocusArea

**Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**

(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported FOCUS AREA and focus area-size settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapFocusArea
lAPIParam (IN) <model>_API_PARAM_CapFocusArea
lAngle (IN) See lAngle of “SetFocusArea”.
pFocusArea_Min (OUT) See pFocusArea of “SetFocusArea”.
pFocusArea_Max (OUT) See pFocusArea of “SetFocusArea”.
**Remarks**
This function can be used in State S3.
**See Also**

##### 4.2.1.8. SetFocusArea

```
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lAngle,
<model>_FocusArea* pFocusArea_Min,
<model>_FocusArea* pFocusArea_Max
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.8. SetFocusArea
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX
50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the FOCUS AREA and focus area-size settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetFocusArea
lAPIParam (IN) <model>_API_PA R A M_SetFocusArea
lAngle (IN)
<model>_ITEM_DIRECTION_0 when camera is rotated 0° or 180°
<model>_ITEM_DIRECTION_ 90 when camera is rotated 90°
<model>_ITEM_DIRECTION_ 270 when camera is rotated 270°
pFocusArea (IN) **[X-T 3 ]**
Pointer to an XT3_FocusArea valuable.
typedef struct{
long h; // Horizontal display coordinate (absolute)
long v; // Vertical display coordinate (absolute)
long size; // Area size
} XT 3 _FocusArea;
⚫ 3:2
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lAngle,
<model>_FocusArea* pFocusArea
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
⚫ 16:9
⚫ 1:1


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**[X-Pro3 / X-T 4 / X-H2S / X-S20]**
Pointer to an XPRO3_ FocusArea /_XT4_FocusArea /_XH2S_FocusArea
/_XS20_FocusArea valuable.
typedef struct{
long h; // Horizontal display coordinate (absolute)
long v; // Vertical display coordinate (absolute)
long size; // Area size
} XPRO3_FocusArea;
typedef struct{
long h; // Horizontal display coordinate (absolute)
long v; // Vertical display coordinate (absolute)
long size; // Area size
} XT 4 _FocusArea;
typedef struct{
long h; // Horizontal display coordinate (absolute)
long v; // Vertical display coordinate (absolute)
long size; // Area size
} XH2S_FocusArea;
typedef struct{
long h; // Horizontal display coordinate (absolute)
long v; // Vertical display coordinate (absolute)
long size; // Area size
} XS20_FocusArea;
⚫ 3:2


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
⚫ 16:9
⚫ 1:1


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**[X-H2/X-T5]**
Pointer to an XH2_FocusArea / XT5_FocusArea valuable.
typedef struct{
long h; // Horizontal display coordinate (absolute)
long v; // Vertical display coordinate (absolute)
long size; // Area size
} XH2_FocusArea;
typedef struct{
long h; // Horizontal display coordinate (absolute)
long v; // Vertical display coordinate (absolute)
long size; // Area size
} XT5_FocusArea;
⚫ 3:2


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
⚫ 16:9
⚫ 1:1


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
⚫ 4:3
⚫ 5:4


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**[GFX 50S / GFX 50R]**
Pointer to an GFX50S_FocusArea / GFX50R_FocusArea valuable.
typedef struct{
long h; // Horizontal display coordinate (absolute)
long v; // Vertical display coordinate (absolute)
long size; // Area size
} GFX50S_FocusArea;
typedef struct{
long h; // Horizontal display coordinate (absolute)
long v; // Vertical display coordinate (absolute)
long size; // Area size
} GFX50R_FocusArea;
⚫ 4:3


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
⚫ 3:2
⚫ 16:9


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
⚫ 1:1
⚫ 65:24


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
⚫ 5:4
⚫ 7:6


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**[GFX 100/GFX100S/GFX100 II/GFX100S II]**
Pointer to an GFX100_FocusArea/GFX100S_FocusArea/
GFX100II_FocusArea/GFX100SII_FocusArea valuable.
typedef struct{
long h; // Horizontal display coordinate (absolute)
long v; // Vertical display coordinate (absolute)
long size; // Area size
} GFX100_FocusArea;
typedef struct{
long h; // Horizontal display coordinate (absolute)
long v; // Vertical display coordinate (absolute)
long size; // Area size
} GFX100S_FocusArea;
typedef struct{
long h; // Horizontal display coordinate (absolute)
long v; // Vertical display coordinate (absolute)
long size; // Area size
} GFX100II_FocusArea;
typedef struct{
long h; // Horizontal display coordinate (absolute)
long v; // Vertical display coordinate (absolute)
long size; // Area size


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
} GFX100SII_FocusArea;
⚫ 4:3
⚫ 3:2
⚫ 16:9


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
⚫ 1:1
⚫ 65:24


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
⚫ 5:4
⚫ 7:6


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**Remarks**
This function can be used in State S3.
**See Also**

##### 4.2.1.9. GetFocusArea


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.9. GetFocusArea
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the FOCUS AREA and focus area-size settings.
**Syntax
eturn Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetFocusArea
lAPIParam (IN) <model>_API_PA R A M_GetFocusArea
lAngle (IN) See lAngle of “SetFocusArea”.
pFocusArea (OUT) See pFocusArea of “SetFocusArea”.
**Remarks**
This function can be used in State S3.
**See Also**
SetFocusArea
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lAngle ,
<model>_FocusArea* pFocusArea
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API

##### 4.2.1.10. CapShutterPriorityMode

**Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**

(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported RELEASE/FOCUS PRIORITY settings for AF-S or AF-C..
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapShutterPriorityMode
lAPIParam (IN) <model>_API_PARAM_CapShutterPriorityMode
lFocusMode (IN) See lFocusMode of “SetShutterPriorityMode”
plNum (OUT) Returns the number of “SetShutterPriorityMode” settings supported.
plPriority (OUT)
<model>_AFPRIORITY_RELEASE RELEASE PRIORITY
<model>_AFPRIORITY_FOCUS FOCUS PRIORITY
**Remarks**
This function can be used in State S3.
**See Also**

##### 4.2.1.12. GetShutterPriorityMode

```
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lFocusMode,
long* plNum,
long* plPriority
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API

##### 4.2.1.11. SetShutterPriorityMode

**Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**

(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the RELEASE/FOCUS PRIORITY setting for AF-S or AF-C.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetShutterPriorityMode
lAPIParam (IN) <model>_API_PA R A M_SetShutterPriorityMode
lFocusMode (IN) The target focus mode.
<model>_ITEM_AFPRIORITY_AFS AF-S
<model>_ITEM_AFPRIORITY_AFC AF-C
lPriority (IN)
<model>_AFPRIORITY_RELEASE RELEASE PRIORITY
<model>_AFPRIORITY_FOCUS FOCUS PRIORITY
**Remarks**
This function can be used in State S3.
**See Also**
GetShutterPriorityMode
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lFocusMode,
long lPriority
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.12. GetShutterPriorityMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the RELEASE/FOCUS PRIORITY setting for AF-S or AF-C.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetShutterPriorityMode
lAPIParam (IN) <model>_API_PA R A M_GetShutterPriorityMode
lFocusMode (IN) See lFocusMode of “SetShutterPriorityMode”
plPriority (OUT) See lPriority of “SetShutterPriorityMode”
**Remarks**
This function can be used in State S3.
**See Also**
SetShutterPriorityMode
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lFocusMode,
long* plPriority
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.13. CapFaceDetectionMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported FACE DETECTION modes.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapFaceDetectionMode
lAPIParam (IN) <model>_API_PARAM_CapFaceDetectionMode
plNum (OUT) Returns the number of “SetFaceDetectionMode” settings supported.
plFDMode (OUT) See lFDMode of “SetFaceDetectionMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetFaceDetectionMode
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plFDMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.14. SetFaceDetectionMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the FACE DETECTION mode.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetFaceDetectionMode
lAPIParam (IN) <model>_API_PA R A M_SetFaceDetectionMode
lFDMode (IN)
<model>_FACE_DETECTION_ON ON
<model>_FACE_DETECTION_OFF OFF
**Remarks**
This function can be used in State S3.
**See Also**
GetFaceDetectionMode
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lFDMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.15. GetFaceDetectionMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the FACE DETECTION mode.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetFaceDetectionMode
lAPIParam (IN) <model>_API_PA R A M_GetFaceDetectionMode
plFDMode (OUT) See lFDMode of “SetFaceDetectionMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetFaceDetectionMode
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plFDMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.16. CapEyeAFMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported EYE AF modes.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapEyeAFMode
lAPIParam (IN) <model>_API_PARAM_CapEyeAFMode
plNum (OUT) Returns the number of “SetEyeAFMode” settings supported.
plEyeMode (OUT) See lEyeMode of “SetEyeAFMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetEyeAFMode
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plEyeMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.17. SetEyeAFMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the EYE AF mode.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetEyeAFMode
lAPIParam (IN) <model>_API_PA R A M_SetEyeAFMode
lEyeMode (IN)
<model>_EYE_AF_OFF OFF
<model>_EYE_AF_AUTO AUTO
<model>_EYE_AF_RIGHT_PRIORITY Right eye priority
<model>_EYE_AF_LEFT_PRIORITY Left eye priority
**Remarks**
This function can be used in State S3.
**See Also**
GetEyeAFMode
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lEyeMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.18. GetEyeAFMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the EYE AF mode.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetEyeAFMode
lAPIParam (IN) <model>_API_PA R A M_GetEyeAFMode
plEyeMode (OUT) See lEyeMode of “SetEyeAFMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetEyeAFMode
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plEyeMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.19. CapSubjectDetectionMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported subject detection modes.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapSubjectDetectionMode
lAPIParam (IN) <model>_API_PARAM_CapSubjectDetectionMode
plNum (OUT) Returns the number of “SetSubjectDetectionMode” settings supported.
plMode (OUT) See lMode of “SetSubjectDetectionMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetSubjectDetectionMode
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.20. SetSubjectDetectionMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Sets the subject detection mode.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetSubjectDetectionMode
lAPIParam (IN) <model>_API_PARAM_ SetSubjectDetectionMode
lMode (IN)
<model>_SUBJECT_DETECTION_OFF OFF
<model>_SUBJECT_DETECTION_ANIMAL Animal
<model>_SUBJECT_DETECTION_BIRD Bird
<model>_SUBJECT_DETECTION_CAR Automobile
<model>_SUBJECT_DETECTION_BIKE Motor cycle & Bike
<model>_SUBJECT_DETECTION_AIRPLANE Airplane
<model>_SUBJECT_DETECTION_TRAIN Train
**Remarks**
This function can be used in State S3.
**See Also**
GetEyeAFMode
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.21. GetSubjectDetectionMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3
**Description**
Gets the subject detection mode.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetSubjectDetectionMode
lAPIParam (IN) <model>_API_PARAM_GetSubjectDetectionMode
plMode (OUT) See lMode of “SetSubjectDetectionMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetSubjectDetectionMode
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.22. CapFullTimeManualFocus
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported AF+MF modes.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapFullTimeManualFocus
lAPIParam (IN) <model>_API_PARAM_CapFullTimeManualFocus
plNum (OUT) Returns the number of “SetFullTimeManualFocus” settings supported.
plFullTimeManual (OUT) See lFullTimeManual of “SetFullTimeManualFocus”.
**Remarks**
This function can be used in State S3.
**See Also**
SetFullTimeManualFocus
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plFullTimeManual
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.23. SetFullTimeManualFocus
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX
50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the AF+MF mode.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetFullTimeManualFocus
lAPIParam (IN) <model>_API_PA R A M_SetFullTimeManualFocus
lFullTimeManual (IN)
<model>_OFF OFF
<model>_ON ON
**Remarks**
This function can be used in State S3.
**See Also**
GetFullTimeManualFocus
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lFullTimeManual
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.24. GetFullTimeManualFocus
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the AF+MF mode.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetFullTimeManualFocus
lAPIParam (IN) <model>_API_PA R A M_GetFullTimeManualFocus
plFullTimeManual (OUT) See lFullTimeManual of “SetFullTimeManualFocus”.
**Remarks**
This function can be used in State S3.
**See Also**
SetFullTimeManualFocus
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plFullTimeManual
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.1. CapFocusPoints
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported options for selecting the NUMBER OF FOCUS POINTS
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapFocusPoints
lAPIParam (IN) <model>_API_PARAM_CapFocusPoints
plNum (OUT) Returns the number of “SetFocusPoints” settings supported.
plFocusPoints (OUT)
<model>_FOCUS_POINTS_11X7 77 POINTS
<model>_FOCUS_POINTS_13X7 91 POINTS
<model>_FOCUS_POINTS_13X9 117 POINTS
<model>_FOCUS_POINTS_21X13 273 POINTS
<model>_FOCUS_POINTS_25X13 325 POINTS
<model>_FOCUS_POINTS_25X17 425 POINTS
**Remarks**
This function can be used in State S3.
**See Also**
SetFocusPoints
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plFocusPoints
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.1. SetFocusPoints
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the NUMBER OF FOCUS POINTS.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetFocusPoints
lAPIParam (IN) <model>_API_PA R A M_SetFocusPoints
lFocusPoints (IN)
<model>_FOCUS_POINTS_13X7 91 POINTS
<model>_FOCUS_POINTS_25X13 325 POINTS
<model>_FOCUS_POINTS_13X9 117 POINTS
<model>_FOCUS_POINTS_25X17 425 POINTS
The options supported vary with the camera model.
**Remarks**
This function can be used in State S3.
**See Also**
GetFocusPoints
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lFocusPoints
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.2. GetFocusPoints
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the NUMBER OF FOCUS POINTS.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetFocusPoints
lAPIParam (IN) <model>_API_PA R A M_GetFocusPoints
plFocusPoints (OUT) See lFocusPoints of “SetFocusPoints”.
**Remarks**
This function can be used in State S3.
**See Also**
SetFocusPoints
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plFocusPoints
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.3. CapInstantAFMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported INSTANT AF SETTING options.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapInstantAFMode
lAPIParam (IN) <model>_API_PARAM_CapInstantAFMode
plNum (OUT) Returns the number of “SetInstantAFMode” settings supported.
plInstantAFMode (OUT) See lInstantAFMode of “SetInstantAFMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetInstantAFMode
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plInstantAFMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.4. SetInstantAFMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the INSTANT AF SETTING.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetInstantAFMode
lAPIParam (IN) <model>_API_PA R A M_SetInstantAFMode
lInstantAFMode (IN)
<model>_INSTANT_AF_MODE_AFS AF-S
<model>_INSTANT_AF_MODE_AFC AF-C
**Remarks**
This function can be used in State S3.
**See Also**
GetInstantAFMode
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lInstantAFMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.5. GetInstantAFMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100**
(^) **GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the INSTANT AF SETTING.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetInstantAFMode
lAPIParam (IN) <model>_API_PA R A M_GetInstantAFMode
plInstantAFMode (OUT) See lInstantAFMode of “SetInstantAFMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetInstantAFMode
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plInstantAFMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.6. CapPreAFMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported PRE-AF settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapPreAFMode
lCategory (IN) <model>_API_PARAM_CapPreAFMode
plNum (OUT) Returns the number of “SetPreAFMode” settings supported.
plPreAF (OUT) See lPreAF of “SetPreAFMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetPreAFMode
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plPreAF
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.7. SetPreAFMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the PRE-AF setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetPreAFMode
lAPIParam (IN) <model>_API_PA R A M_SetPreAFMode
lPreAF (IN)
<model>_ON ON
<model>_OFF OFF
**Remarks**
This function can be used in State S3.
**See Also**
GetPreAFMode
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lPreAF
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.8. GetPreAFMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the PRE-AF setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetPreAFMode
lCategory (IN) <model>_API_PA R A M_GetPreAFMode
plPreAF (OUT) See lPreAF of “SetPreAFMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetPreAFMode
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plPreAF
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.9. CapAFIlluminator
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported AF ILLUMINATOR settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapAFIlluminator
lAPIParam (IN) <model>_API_PARAM_CapAFIlluminator
plNum (OUT) Returns the number of “SetAFIlluminator” settings supported.
plAFIlluminator (OUT) See lAFIlluminator of “SetAFIlluminator”.
**Remarks**
This function can be used in State S3.
**See Also**
SetAFIlluminator
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plAFIlluminator
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.10. SetAFIlluminator
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the AF ILLUMINATOR setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetAFIlluminator
lAPIParam (IN) <model>_API_PA R A M_SetAFIlluminator
lAFIlluminator (IN)
<model>_ON ON
<model>_OFF OFF
**Remarks**
This function can be used in State S3.
**See Also**
GetAFIlluminator
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lAFIlluminator
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.11. GetAFIlluminator
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the AF ILLUMINATOR setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetAFIlluminator
lAPIParam (IN) <model>_API_PA R A M_GetAFIlluminator
plAFIlluminator (OUT) See lAFIlluminator of “SetAFIlluminator”.
**Remarks**
This function can be used in State S3.
**See Also**
SetAFIlluminator
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plAFIlluminator
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.12. CapFocusPos
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Queries the focus positions to set available in manual focus mode.
**_Note that the focus position is not absolute, but fluctuates with temperature and a variety of other conditions.
The relative focus position can be specified using_** **GetFocusPos** **_and_** **CapFocusPos.
Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapFocusPos
lAPIParam (IN) <model>_API_PA R A M_CapFocusPos
plSizeFocusPosCap (IN/OUT) Set sizeof(<model>_FOCUS_POS_CAP) prior to calling the API.
pFocusPosCap (OUT) typedef struct _<model>_FOCUS_POS_CAP {
long lSizeFocusPosCap;
long lStructVer;
long lFocusPlsINF;
long lFocusPlsMOD;
long lFocusOverSearchPlsINF;
long lFocusOverSearchPlsMOD;
long lFocusPlsFCSDepthCap;
long lMinDriveStepMFDriveEndThresh;
} <model>_FOCUS_POS_CAP, *P<model>_FOCUS_POS_CAP;
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSizeFocusPosCap,
<model>_FOCUS_POS_CAP * pFocusPosCap
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**Note**
lSizeFocusPosCap :
sizeof(<model>_FOCUS_POS_CAP)
lStructVer :
Fixed to 0x00010000
lFocusOverSearchPlsMOD, lFocusPlsMOD, lFocusPlsINF, lFocusOverSearchPlsINF:
INF Å lFocusOverSearchPlsINF →ÇÅ // →ÇÅ lFocusOverSearchPlsMOD → MOD
lFocusPlsINF lFocusPlsMOD
lFocusPlsFCSDepthCap :
DOF pulse. Returns zero if the lens does not support Set/GetFocusPos.
lMinDriveStepMFDriveEndThresh :
Minimum travel pulse. Returns zero if the lens does not support Set/GetFocusPos.
**Remarks**
This function can be used in State S3.
**See Also**
SetFocusPos, GetFocusPos


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.13. SetFocusPos
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the focus position for manual focus mode.
**_Note that the focus position is not absolute, but fluctuates with temperature and a variety of other conditions.
The relative focus position can be specified using_** **GetFocusPos** **_and_** **CapFocusPos.
Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetFocusPos
lAPIParam (IN) <model>_API_PA R A M_SetFocusPos
lFocusPos (IN) The target focus position to set. See “CapFocusPos”.
**Remarks**
This function can be used in State S3.
**See Also**
CapFocusPos, GetFocusPos
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lFocusPos
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.14. GetFocusPos
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX
50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the focus position for manual focus mode.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetFocusPos
lAPIParam (IN) <model>_API_PA R A M_GetFocusPos
plFocusPos (OUT) The current focus position pulse. See “CapFocusPos”.
**Remarks**
This function can be used in State S3.
**See Also**
CapFocusPos, SetFocusPos
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plFocusPos
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.15. CapFocusLimiterPos
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries available AF search ranges (near/far) for focus limiter 1(custom).
**Syntax**
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plPosNum,
long* plModeNum,
long* plFocusLimiterPos,
long* plMode
);
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapFocusLimiterPos
lAPIParam (IN) <model>_API_PARAM_ CapFocusLimiterPos
plPosNum (IN/OUT) Returns the number of availble edge positions.
plModeNum (IN/OUT) Returns 1 always.
plFocusLimiterPos (OUT) The available endpoints.
<model>_FOCUS_LIMITER_POS_A AF search endpoint A
<model>_FOCUS_LIMITER_POS_B^ AF search endpoint^ B^
plMode (OUT) Available(customizable) focus limiter list.
Fixed to <model>_FOCUS_LIMITER_1.
<model>_FOCUS_LIMITER_1^ Custom^
**Remarks**
This function can be used in State S3.
**See Also**
SetFocusLimiterPos
**Sample**
long lAPICode = <model>_API_CODE_CapFocusLimiterPos;


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
long lAPICode = <model>_API_PARAM_ CapFocusLimiterPos;
long lPosNum;
long lModeNum;
long* plFocusLimiterPos;
long* plMode;
XSDK_CapProp( hCam, lAPICode, lAPIParam, &lPosNum, &lModeNum, NULL, NULL );
plFocusLimiterPos = new long [lPosNum];
plMode = new long [lModeNum];
XSDK_CapProp( hCam, lAPICode, lAPIParam, &lPosNum, &lModeNum, plFocusLimiterPos, plMode );
:
delete [] plFocusLimiterPos;
delete [] plMode;


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.16. SetFocusLimiterPos
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the current focus position to one of endpoints of a focus limiter.
**Syntax**
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lFocusLimiterPos,
long lMode
);
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetFocusLimiterPos
lAPIParam (IN) <model>_API_PARAM_ SetFocusLimiterPos
lFocusLimiterPos (IN) The selection of the target limiter endpoint.
<model>_FOCUS_LIMITER_POS_A Search range limit A
<model>_FOCUS_LIMITER_POS_B Search range limit B
lMode (IN) The selection of the target focus limiter(custom).
<model>_FOCUS_LIMITER_1 Custom
**Remarks**
This function can be used in State S3.
**See Also**
CapFocusLimiterPos


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.17. GetFocusLimiterIndicator
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets a information for the current focus limiter.
Usable for drawing a focus indicator.
**Syntax**
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
<model>_FOCUS_LIMITER_INDICATOR* pFocusLimiterIndicator
);
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetFocusLimiterIndicator
lAPIParam (IN) <model>_API_PARAM_GetFocusLimiterIndicator
pFocusLimiterIndicator (OUT) typedef struct _<model> _FOCUS_LIMITER_INDICATOR {
long lCurrent;
long lDOF_Near;
long lDOF_Far;
long lPos_A;
long lPos_B;
long lStatus;
} <model> _FOCUS_LIMITER_INDICATOR;
The locations for each position below normalized 0 to 1024. (0 for MOD, 1024
for infinity)
lCurrent : The current focus position.
lDOF_Near: Endpoint on MOD side of Depth of field.
lDOF_Far: Endpoint on infinity side of Depth of field.
lPos_A: A endpoint of AF search range.
lPos_B: B endpoint of AF search range.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
lStatus: Queries whether the search range is valid or not.
1: Valid; 0: Invalid.
**Remarks**
This function can be used in State S3.
**See Also**


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.18. GetFocusLimiterRange
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets a list of the endpoints for available focus limiters in specified unit.
**Syntax**
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
<model>_FOCUS_LIMITER* pFocusLimiter
);
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetFocusLimiterRange
lAPIParam (IN) <model>_API_PARAM_ GetFocusLimiterRange
plNum (OUT) Returns the number of available focus limiters.
pFocusLimiter (OUT) When the pFocusLimiter is set to NULL, this API returns the number of available
focus limiters for plNum.
If not NULL, the API will return a list of the <model>_FOCUS_LIMITER.
Allocate sizeof(<model>_FOCUS_LIMITER) * (*plNum) bytes of space before
calling this function.
typedef struct _<model>_FOCUS_LIMITER {
long lPos_A;
long lPos_B;
} <model>_FOCUS_LIMITER;
lPos_A: The absolute distance for the endpoint A in mm or 1/1000 ft.
lPos_B: The absolute distance for the endpoint B in mm or 1/1000 ft.
*Use SetFocusScaleUnit to select the unit, GetFocusScaleUnit to get the current
unit setting.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
*The valid value will be from 0 to 0x00FFFFFE. 0x00FFFFFF shows that no
endpoint is set.
**Remarks**
This function can be used in State S3.
**See Also**
GetScaleUnit


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.19. CapFocusLimiterMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries available focus limiter selections.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapFocusLimiterMode
lAPIParam (IN) <model>_API_PARAM_ CapFocusLimiterMode
plNum (OUT) Returns the number of “SetFocusLimiterMode” settings supported.
plMode (OUT)
<model>_FOCUS_LIMITER_OFF OFF
<model>_FOCUS_LIMITER_1 CUSTOM
<model>_FOCUS_LIMITER_2 PRESET1
<model>_FOCUS_LIMITER_3 PRESET2
**Remarks**
This function can be used in State S3.
**See Also**
SetFocusLimiterMode, GetFocusLimiterMode
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.20. SetFocusLimiterMode
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the focus limiter selection.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetFocusLimiterMode
lAPIParam (IN) <model>_API_PARAM_ SetFocusLimiterMode
lMode (IN)
<model>_FOCUS_LIMITER_OFF OFF
<model>_FOCUS_LIMITER_1 CUSTOM
<model>_FOCUS_LIMITER_2 PRESET1
<model>_FOCUS_LIMITER_3 PRESET2
**Remarks**
This function can be used in State S3.
**See Also**
CapFocusLimiterMode, GetFocusLimiterMode
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.21. GetFocusLimiterMode
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the current focus limiter selection.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetFocusLimiterMode
lAPIParam (IN) <model>_API_PARAM_ GetFocusLimiterMode
plMode (OUT)
<model>_FOCUS_LIMITER_OFF OFF
<model>_FOCUS_LIMITER_1 CUSTOM
<model>_FOCUS_LIMITER_2 PRESET1
<model>_FOCUS_LIMITER_3^ PRESET2^
**Remarks**
This function can be used in State S3.
**See Also**
CapFocusLimiterMode, SetFocusLimiterMode
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.22. CapFocusSpeed
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3
**Description**
Queries available focus speed selecitons.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapFocusSpeed
lAPIParam (IN) <model>_API_PARAM_CapFocusSpeed
plNum (OUT) Returns the number of “SetFocusSpeed” settings supported.
plSpeed (OUT)
<model>_LENS_FOCUS_SPEED_1 speed 1 (slowest)
<model>_LENS_FOCUS_SPEED_ 2 spped 2
<model>_LENS_FOCUS_SPEED_ 3 spped 3
<model>_LENS_FOCUS_SPEED_ 4 spped 4
<model>_LENS_FOCUS_SPEED_ 5 spped 5
<model>_LENS_FOCUS_SPEED_ 6 spped 6
<model>_LENS_FOCUS_SPEED_ 7 spped 7
<model>_LENS_FOCUS_SPEED_^8 spped 8 (fastest)^
**Remarks**
This function can be used in State S3.
**See Also**
SetFocusSpeed, GetFocusSpeed
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSpeed
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.23. SetFocusSpeed
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Sets the focus speed seleciton.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetFocusSpeed
lAPIParam (IN) <model>_API_PARAM_SetFocusSpeed
lSpeed (IN)
<model>_LENS_FOCUS_SPEED_1 speed 1 (slowest)
<model>_LENS_FOCUS_SPEED_ 2 spped 2
<model>_LENS_FOCUS_SPEED_ 3 spped 3
<model>_LENS_FOCUS_SPEED_ 4 spped 4
<model>_LENS_FOCUS_SPEED_ 5 spped 5
<model>_LENS_FOCUS_SPEED_ 6 spped 6
<model>_LENS_FOCUS_SPEED_ 7 spped 7
<model>_LENS_FOCUS_SPEED_^8 spped 8 (fastest)^
**Remarks**
This function can be used in State S3.
**See Also**
CapFocusSpeed, GetFocusSpeed
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSpeed
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.24. GetFocusSpeed
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Gets the current focus speed selection.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetFocusSpeed
lAPIParam (IN) <model>_API_PARAM_SetFocusSpeed
plSpeed (OUT)
<model>_LENS_FOCUS_SPEED_1 speed 1 (slowest)
<model>_LENS_FOCUS_SPEED_ 2 spped 2
<model>_LENS_FOCUS_SPEED_ 3 spped 3
<model>_LENS_FOCUS_SPEED_ 4 spped 4
<model>_LENS_FOCUS_SPEED_ 5 spped 5
<model>_LENS_FOCUS_SPEED_ 6 spped 6
<model>_LENS_FOCUS_SPEED_ 7 spped 7
<model>_LENS_FOCUS_SPEED_^8 spped 8 (fastest)^
**Remarks**
This function can be used in State S3.
**See Also**
CapFocusSpeed, SetFocusSpeed
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSpeed
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.25. CapFocusOperation
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3
**Description**
Queries available focus operations.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapFocusOperation
lAPIParam (IN) <model>_API_PARAM_CapFocusOperation
plNum (OUT) Returns the number of “SetFocusOperation” settings supported setting.
plSetting (OUT)
<model>_ZOOM_OPERATION_START start
<model>_ZOOM_OPERATION_STOP stop
plNumSpeed (OUT) Returns the number of “SetFocusOperation” settings supported speed.
plSpeed (OUT)
<model>_LENS_FOCUS_SPEED_1 speed 1 (slowest)
<model>_LENS_FOCUS_SPEED_ 2 spped 2
<model>_LENS_FOCUS_SPEED_ 3 spped 3
<model>_LENS_FOCUS_SPEED_ 4 spped 4
<model>_LENS_FOCUS_SPEED_ 5 spped 5
<model>_LENS_FOCUS_SPEED_ 6 spped 6
<model>_LENS_FOCUS_SPEED_ 7 spped 7
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting,
long* plNumSpeed,
long* plSpeed
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_LENS_FOCUS_SPEED_^8 spped 8 (fastest)^
**Remarks**
This function can be used in State S3.
**See Also**
SetFocusOperation


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.26. SetFocusOperation
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
^3^^3^^3^^3^
**Description**
Triggers the focus operation.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetFocusOperation
lAPIParam (IN) <model>_API_PARAM_SetFocusOperation
lSetting (IN)
<model>_FOCUS_OPERATION_START start
<model>_FOCUS_OPERATION_STOP stop
lDirection (IN)
<model>_FOCUS_DIRECTION_NEAR near
<model>_FOCUS_DIRECTION_FAR far
lSpeed (IN)
<model>_LENS_FOCUS_SPEED_1 speed 1 (slowest)
<model>_LENS_FOCUS_SPEED_ 2 spped 2
<model>_LENS_FOCUS_SPEED_ 3 spped 3
<model>_LENS_FOCUS_SPEED_ 4 spped 4
<model>_LENS_FOCUS_SPEED_ 5 spped 5
<model>_LENS_FOCUS_SPEED_ 6 spped 6
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSpeed,
long lDirection,
long lSpeed
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_LENS_FOCUS_SPEED_ 7 spped 7
<model>_LENS_FOCUS_SPEED_ 8 spped 8 (fastest)
**Remarks**
This function can be used in State S3.
**See Also**
CapFocusOperation


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.27.** **_CapAFZoneCustom_**
**Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3
**Description**
Queries supported _ZONE CUSTOM_ settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapAFZoneCustom
lAPIParam (IN) <model>_API_PARAM_CapAFZoneCustom
plNumMode (IN/OUT) Returns the number of “SeAFZoneCustom” settings supported.
pZoneCustom (OUT) typedef struct _SDK_AFZoneCustomCapablity {
long mode; // Zone custom mode
SDK_AFZoneCustom min; // Minimum set value
SDK_AFZoneCustom max; // Maximum set value
} SDK_AFZoneCustomCapablity;
*Zone custom mode
<model>_AF_ZONECUSTOM1 ZoneCustom1
<model>_AF_ZONECUSTOM2 ZoneCustom2
<model>_AF_ZONECUSTOM 3 ZoneCustom3
*Set value structure
typedef struct{
long h; // Horizontal display coordinate (absolute)
long v; // Vertical display coordinate (absolute)
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long*plNum,
<model>_AFZoneCustomCapablity* pZoneCustom
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
} <model>_AFZoneCustom;
**Note**
If pZoneCustom is NULL, the function will return only plNum with the number of supported SetAFZoneCustom
settings.
Otherwise it will return pZoneCustom with a list of the SetAFZoneCustom settings supported. *plNum should be
set to the number of allocated SDK_AFZoneCustomCapablity.
Allocate sizeof(SDK_AFZoneCustomCapablity) * (*plNum) bytes of space before calling this function.
**Remarks**
This function can be used in State S3.
**See Also**
SetAFZoneCustom, GetAFZoneCustom


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.28. SetAFZoneCustom
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3
**Description**
Sets the _ZONE CUSTOM_ setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetAFZoneCustom
lAPIParam (IN) <model>_API_PA R A M_SetAFZoneCustom
lMode (IN) See mode of “CapAFZoneCustom”.
pZoneCustom (IN) Value to set.
typedef struct{
long h; // Horizontal display coordinate (absolute)
long v; // Vertical display coordinate (absolute)
} <model>_AFZoneCustom
**Remarks**
This function can be used in State S3.
**See Also**
CapAFZoneCustom, GetAFZoneCustom
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lMode,
<model>_AFZoneCustom* pZoneCustom
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.1.29.** **_GetAFZoneCustom_**
**Supported Cameras
X-
T1
X-
T2
X-
T3
X-
T4
X-
T 5
X-
Pro2
X-
Pro3
X-
S10
X-
H2S
X-
H2
X-
S20
X-
M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
^3^^3^^3^^3^
**Description**
Gets the _ZONE CUSTOM_ setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetAFZoneCustom
lAPIParam (IN) <model>_API_PA R A M_GetAFZoneCustom
lMode (IN) See mode of “CapAFZoneCustom”.
pZoneCustom (OUT) See pZoneCustom of “SetAFZoneCustom”.
**Remarks**
This function can be used in State S3.
**See Also**
CapAFZoneCustom, SetAFZoneCustom
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lMode ,
<model>_AFZoneCustom* pZoneCustom
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.2. Crop Control
4.2.2.1. CapCropMode
Supported Cameras
X-
T1
X-
T2
X-
T3
X-
T4
X-
T 5
X-
Pro2
X-
Pro3
X-
S10
X-
H2S
X-
H2
X-
S20
X-
M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported crop modes.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapCropMode
lAPIParam (IN) <model>_API_PARAM_CapCropMode
plNum (OUT) Returns the number of “SetCropMode” settings supported.
plCropMode (OUT)
**[GFX100S/GFX100II/GFX100SII]**
<model>_CROPMODE_OFF OFF
<model>_CROPMODE_35MM ON
<model>_CROPMODE_AUTO AUTO
**[X-H2S/X-H2]**
<model>_CROPMODE_OFF OFF
<model>_CROPMODE_SPORTSFINDER_125^ ON^
**Remarks**
This function can be used in State S3.
**See Also**
SetCropMode, GetCropMode
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plCropMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.2.2. SetCropMode
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the crop mode.
**Syntax**
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lCropMode
);
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetCropMode
lAPIParam (IN) <model>_API_PARAM_SetCropMode
lCropMode (IN)
**[GFX System]**
<model>_CROPMODE_OFF OFF
<model>_CROPMODE_35MM ON
<model>_CROPMODE_AUTO AUTO
**[X Series]**
<model>_CROPMODE_OFF OFF
<model>_CROPMODE_SPORTSFINDER_125 ON
**Remarks**
This function can be used in State S3.
**See Also**
CapCropMode, GetCropMode


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.2.3. GetCropMode
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the crop mode.
**Syntax**
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plCropMode,
long* plCropModeStatus
);
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetCropMode
lAPIParam (IN) <model>_API_PARAM_GetCropMode
plCropMode (OUT)
**[GFX System]**
<model>_CROPMODE_OFF OFF
<model>_CROPMODE_35MM ON
<model>_CROPMODE_AUTO AUTO
**[X Series]**
<model>_CROPMODE_OFF OFF
<model>_CROPMODE_SPORTSFINDER_125 ON
plCropModeStatus (OUT)
**[GFX System]**
<model>_CROPMODE_OFF OFF
<model>_CROPMODE_35MM ON


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**[X Series]**
<model>_CROPMODE_OFF OFF
<model>_CROPMODE_SPORTSFINDER_125^ ON^
**Remarks**
This function can be used in State S3.
**See Also**
CapCropMode, SetCropMode


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.2.4. CapCropZoom
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3
**Description**
Queries available crop zoom magnification ratios.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapCropZoom
lAPIParam (IN) <model>_API_PARAM_CapCropZoom
plNum (OUT) Returns the number of “SetCropZoom” settings supported.
plZoom (OUT)
<model>_CROP_ZOOM_OFF OFF
<model>_CROP_ZOOM_1 0 x 1.0
<model>_CROP_ZOOM_1 1 x 1. 1
<model>_CROP_ZOOM_1 2 x 1. 2
<model>_CROP_ZOOM_1 3 x 1.3
<model>_CROP_ZOOM_1 4 x 1.4
<model>_CROP_ZOOM_1 5 x 1.5
<model>_CROP_ZOOM_1 6 x 1.6
<model>_CROP_ZOOM_1 7 x 1.7
<model>_CROP_ZOOM_1 8 x 1.8
<model>_CROP_ZOOM_1 9 x 1.9
<model>_CROP_ZOOM_ 20 x 2.0
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plZoom
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**[GFX100RF]**
<model>_CROP_ZOOM_OFF OFF
<model>_CROP_ZOOM_35MM 3 5mm
<model>_CROP_ZOOM_50MM 5 0mm
<model>_CROP_ZOOM_63MM^6 3mm^
**Remarks**
This function can be used in State S3.
**See Also**
SetCropZoom, GetCropZoom


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.2.5. SetCropZoom
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Sets the crop zoom magnification ratio.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetCropZoom
lAPIParam (IN) <model>_API_PARAM_SetCropZoom
lZoom (IN)
<model>_CROP_ZOOM_OFF OFF
<model>_CROP_ZOOM_1 0 x 1.0
<model>_CROP_ZOOM_1 1 x 1. 1
<model>_CROP_ZOOM_1 2 x 1. 2
<model>_CROP_ZOOM_1 3 x 1.3
<model>_CROP_ZOOM_1 4 x 1.4
<model>_CROP_ZOOM_1 5 x 1.5
<model>_CROP_ZOOM_1 6 x 1.6
<model>_CROP_ZOOM_1 7 x 1.7
<model>_CROP_ZOOM_1 8 x 1.8
<model>_CROP_ZOOM_1 9 x 1.9
<model>_CROP_ZOOM_ 20 x 2.0
**[GFX100RF]**
<model>_CROP_ZOOM_OFF OFF
<model>_CROP_ZOOM_35MM 3 5mm
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lZoom
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_CROP_ZOOM_50MM 5 0mm
<model>_CROP_ZOOM_63MM 6 3mm
**Remarks**
This function can be used in State S3.
**See Also**
CapCropZoom, GetCropZoom


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.2.6. GetCropZoom
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Gets the current crop zoom magnification ratio.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetCropZoom
lAPIParam (IN) <model>_API_PARAM_GetCropZoom
plZoom (OUT)
<model>_CROP_ZOOM_OFF OFF
<model>_CROP_ZOOM_1 0 x 1.0
<model>_CROP_ZOOM_1 1 x 1. 1
<model>_CROP_ZOOM_1 2 x 1. 2
<model>_CROP_ZOOM_1 3 x 1.3
<model>_CROP_ZOOM_1 4 x 1.4
<model>_CROP_ZOOM_1 5 x 1.5
<model>_CROP_ZOOM_1 6 x 1.6
<model>_CROP_ZOOM_1 7 x 1.7
<model>_CROP_ZOOM_1 8 x 1.8
<model>_CROP_ZOOM_1 9 x 1.9
<model>_CROP_ZOOM_ 20 x 2.0
**[GFX100RF]**
<model>_CROP_ZOOM_OFF OFF
<model>_CROP_ZOOM_35MM 3 5mm
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plZoom
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_CROP_ZOOM_50MM 5 0mm
<model>_CROP_ZOOM_63MM 6 3mm
**Remarks**
This function can be used in State S3.
**See Also**
CapFocusLimiterMode, SetFocusLimiterMode


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.3. Zoom Control
4.2.3.1. CapZoomSpeed
Supported Cameras
X-
T1
X-
T2
X-
T3
X-
T4
X-
T 5
X-
Pro2
X-
Pro3
X-
S10
X-
H2S
X-
H2
X-
S20
X-
M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3
**Description**
Queries available zoom speed selections.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapZoomSpeed
lAPIParam (IN) <model>_API_PARAM_CapZoomSpeed
plNum (OUT) Returns the number of “SetZoomSpeed” settings supported.
plSpeed (OUT)
<model>_LENS_ZOOM_SPEED_1 speed 1 (slowest)
<model>_LENS_ZOOM_SPEED_ 2 spped 2
<model>_LENS_ZOOM_SPEED_ 3 spped 3
<model>_LENS_ZOOM_SPEED_ 4 spped 4
<model>_LENS_ZOOM_SPEED_ 5 spped 5
<model>_LENS_ZOOM_SPEED_ 6 spped 6
<model>_LENS_ZOOM_SPEED_ 7 spped 7
<model>_LENS_ZOOM_SPEED_^8 spped 8 (fastest)^
**Remarks**
This function can be used in State S3.
**See Also**
SetZoomSpeed, GetZoomSpeed
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSpeed
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.3.2. SetZoomSpeed
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Sets the zoom speed selection.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetZoomSpeed
lAPIParam (IN) <model>_API_PARAM_SetZoomSpeed
lSpeed (IN)
<model>_LENS_ZOOM_SPEED_1 speed 1 (slowest)
<model>_LENS_ZOOM_SPEED_ 2 spped 2
<model>_LENS_ZOOM_SPEED_ 3 spped 3
<model>_LENS_ZOOM_SPEED_ 4 spped 4
<model>_LENS_ZOOM_SPEED_ 5 spped 5
<model>_LENS_ZOOM_SPEED_ 6 spped 6
<model>_LENS_ZOOM_SPEED_ 7 spped 7
<model>_LENS_ZOOM_SPEED_^8 spped 8 (fastest)^
**Remarks**
This function can be used in State S3.
**See Also**
CapZoomSpeed, GetZoomSpeed
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSpeed
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.3.3. GetZoomSpeed
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Gets the current zoom speed selection.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetZoomSpeed
lAPIParam (IN) <model>_API_PARAM_SetZoomSpeed
plSpeed (OUT)
<model>_LENS_ZOOM_SPEED_1 speed 1 (slowest)
<model>_LENS_ZOOM_SPEED_ 2 spped 2
<model>_LENS_ZOOM_SPEED_ 3 spped 3
<model>_LENS_ZOOM_SPEED_ 4 spped 4
<model>_LENS_ZOOM_SPEED_ 5 spped 5
<model>_LENS_ZOOM_SPEED_ 6 spped 6
<model>_LENS_ZOOM_SPEED_ 7 spped 7
<model>_LENS_ZOOM_SPEED_^8 spped 8 (fastest)^
**Remarks**
This function can be used in State S3.
**See Also**
CapZoomSpeed, SetZoomSpeed
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSpeed
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.3.4. CapZoomOperation
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3
**Description**
Queries available zoom operations.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapZoomOperation
lAPIParam (IN) <model>_API_PARAM_CapZoomOperation
plNum (OUT) Returns the number of “SetZoomOperation” settings supported setting.
plSetting (OUT)
<model>_ZOOM_OPERATION_START start
<model>_ZOOM_OPERATION_STOP stop
plNumSpeed (OUT) Returns the number of “SetZoomOperation” settings supported speed.
plSpeed (OUT)
<model>_LENS_ZOOM_SPEED_1 speed 1 (slowest)
<model>_LENS_ZOOM_SPEED_ 2 spped 2
<model>_LENS_ZOOM_SPEED_ 3 spped 3
<model>_LENS_ZOOM_SPEED_ 4 spped 4
<model>_LENS_ZOOM_SPEED_ 5 spped 5
<model>_LENS_ZOOM_SPEED_ 6 spped 6
<model>_LENS_ZOOM_SPEED_ 7 spped 7
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting,
long* plNumSpeed,
long* plSpeed
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_LENS_ZOOM_SPEED_^8 spped 8 (fastest)^
**Remarks**
This function can be used in State S3.
**See Also**
SetZoomOperation


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.3.5. SetZoomOperation
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
^3^^3^^3^^3^
**Description**
Triggers the zoom operation.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetZoomOperation
lAPIParam (IN) <model>_API_PARAM_SetZoomOperation
lSetting (IN)
<model>_ZOOM_OPERATION_START start
<model>_ZOOM_OPERATION_STOP stop
lDirection (IN)
<model>_ZOOM_DIRECTION_WIDE wide
<model>_ZOOM_DIRECTION_TELE tele
lSpeed (IN)
<model>_LENS_ZOOM_SPEED_1 speed 1 (slowest)
<model>_LENS_ZOOM_SPEED_ 2 spped 2
<model>_LENS_ZOOM_SPEED_ 3 spped 3
<model>_LENS_ZOOM_SPEED_ 4 spped 4
<model>_LENS_ZOOM_SPEED_ 5 spped 5
<model>_LENS_ZOOM_SPEED_ 6 spped 6
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting,
long lDirection,
long lSpeed
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_LENS_ZOOM_SPEED_ 7 spped 7
<model>_LENS_ZOOM_SPEED_ 8 spped 8 (fastest)
**Remarks**
This function can be used in State S3.
**See Also**
CapZoomOperation


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.4. Exposure Control
4.2.4.1. CapInterlockAEAFArea
Supported Cameras
X-
T1
X-
T2
X-
T3
X-
T4
X-
T 5
X-
Pro2
X-
Pro3
X-
S10
X-
H2S
X-
H2
X-
S20
X-
M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported modes for INTERLOCK AE SPOT AND AF POSITION.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapInterlockAEAFArea
lAPIParam (IN) <model>_API_PARAM_CapInterlockAEAFArea
plNum (OUT) Returns the number of “SetInterlockAEAFArea” settings supported.
plInterlockMode (OUT) See lInterlockMode of “SetInterlockAEAFArea”.
**Remarks**
This function can be used in State S3.
**See Also**
SetInterlockAEAFArea
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plInterlockMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.4.2. SetInterlockAEAFArea
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the INTERLOCK AE SPOT AND AF POSITION mode.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetInterlockAEAFArea
lAPIParam (IN) <model>_API_PA R A M_SetInterlockAEAFArea
lInterlockMode (IN)
<model>_ON ON
<model>_OFF OFF
**Remarks**
This function can be used in State S3.
**See Also**
GetInterlockAEAFArea
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lInterlockMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.4.3. GetInterlockAEAFArea
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the INTERLOCK AE SPOT AND AF POSITION mode.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetInterlockAEAFArea
lAPIParam (IN) <model>_API_PA R A M_GetInterlockAEAFArea
plInterlockMode (OUT) See lInterlockMode of “SetInterlockAEAFArea”.
**Remarks**
This function can be used in State S3.
**See Also**
SetInterlockAEAFArea
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plInterlockMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.4.4. CapHighFrequencyFlickerlessMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported modes for FLICKERLESS S.S. SETTING.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapHighFrequencyFlickerlessMode
lAPIParam (IN) <model>_API_PARAM_ CapHighFrequencyFlickerlessMode
plNum (OUT) Returns the number of “SetHighFrequencyFlickerlessMode” settings supported.
plMode (OUT) See lMode of “SetHighFrequencyFlickerlessMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetHighFrequencyFlickerlessMode
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.4.5. SetHighFrequencyFlickerlessMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Sets the FLICKERLESS S.S. SETTING.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetHighFrequencyFlickerlessMode
lAPIParam (IN) <model>_API_PARAM_ SetHighFrequencyFlickerlessMode
lMode (IN)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
GetHighFrequencyFlickerlessMode
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.4.6. GetHighFrequencyFlickerlessMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Gets the FLICKERLESS S.S. SETTING.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetHighFrequencyFlickerlessMode
lAPIParam (IN) <model>_API_PARAM_GetHighFrequencyFlickerlessMode
plMode (OUT) See lMode of “SetHighFrequencyFlickerlessMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetHighFrequencyFlickerlessMode
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.5. Image Size / Quality
4.2.5.1. CapImageSize
Supported Cameras
X-
T1
X-
T2
X-
T3
X-
T4
X-
T 5
X-
Pro2
X-
Pro3
X-
S10
X-
H2S
X-
H2
X-
S20
X-
M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported IMAGE SIZE settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapImageSize
lAPIParam (IN) <model>_API_PARAM_CapImageSize
plNum (OUT) Returns the number of “SetImageSize” settings supported.
plImageSize (OUT) See lImageSize of “SetImageSize”.
**Remarks**
This function can be used in State S3.
**See Also**
SetImageSize
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plImageSize
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.5.2. SetImageSize
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-H1
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the IMAGE SIZE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetImageSize
lAPIParam (IN) <model>_API_PA R A M_SetImageSize
lImageSize (IN) **[X-H2/X-T5]**
<model>_IMAGESIZE_S_3_2 S 3:2
<model>_IMAGESIZE_S_16_9 S 16:9
<model>_IMAGESIZE_S_1_1 S 1:1
<model>_IMAGESIZE_S_4_3 S 4:3
<model>_IMAGESIZE_S_5_4 S 5:4
<model>_IMAGESIZE_M_3_2 M 3:2
<model>_IMAGESIZE_M_16_9 M 16:9
<model>_IMAGESIZE_M_1_1 M 1:1
<model>_IMAGESIZE_M_4_3 M 4:3
<model>_IMAGESIZE_M_5_4 M 5:4
<model>_IMAGESIZE_L_3_2 L 3:2
<model>_IMAGESIZE_L_16_9 L 16:9
<model>_IMAGESIZE_L_1_1 L 1:1
<model>_IMAGESIZE_L_4_3 L 4:3
<model>_IMAGESIZE_L_5_4 L 5:4
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lImageSize
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**[GFX50S/GFX 50R]**
<model>_IMAGESIZE_S_3_2 S 3:2
<model>_IMAGESIZE_S_16_9 S 16:9
<model>_IMAGESIZE_S_1_1 S 1:1
<model>_IMAGESIZE_S_4_3 S 4:3
<model>_IMAGESIZE_S_65_24 S 65:24
<model>_IMAGESIZE_S_5_4 S 5:4
<model>_IMAGESIZE_S_7_6 S 7:6
<model>_IMAGESIZE_L_3_2 L 3:2
<model>_IMAGESIZE_L_16_9 L 16:9
<model>_IMAGESIZE_L_1_1 L 1:1
<model>_IMAGESIZE_L_4_3 L 4:3
<model>_IMAGESIZE_L_65_24 L 65:24
<model>_IMAGESIZE_L_5_4 L 5:4
<model>_IMAGESIZE_L_7_6 L 7:6
**[GFX100/GFX100S/GFX100 II/GFX100S II]**
<model>_IMAGESIZE_S_3_2 S 3:2
<model>_IMAGESIZE_S_16_9 S 16:9
<model>_IMAGESIZE_S_1_1 S 1:1
<model>_IMAGESIZE_S_4_3 S 4:3
<model>_IMAGESIZE_S_65_24 S 65:24
<model>_IMAGESIZE_S_5_4 S 5:4
<model>_IMAGESIZE_S_7_6 S 7:6
<model>_IMAGESIZE_M_3_2 M 3:2
<model>_IMAGESIZE_M_16_9 M 16:9
<model>_IMAGESIZE_M_1_1 M 1:1
<model>_IMAGESIZE_M_4_3 M 4:3
<model>_IMAGESIZE_M_65_24 M 65:24
<model>_IMAGESIZE_M_5_4 M 5:4
<model>_IMAGESIZE_M_7_6 M 7:6
<model>_IMAGESIZE_L_3_2 L 3:2
<model>_IMAGESIZE_L_16_9 L 16:9
<model>_IMAGESIZE_L_1_1 L 1:1
<model>_IMAGESIZE_L_4_3 L 4:3
<model>_IMAGESIZE_L_65_24 L 65:24
<model>_IMAGESIZE_L_5_4 L 5:4
<model>_IMAGESIZE_L_7_6 L 7:6
**[Other models]**


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_IMAGESIZE_S_3_2 1 S 3:2
<model>_IMAGESIZE_S_16_9 2 S 16:9
<model>_IMAGESIZE_S_1_1 3 S 1:1
<model>_IMAGESIZE_M_3_2 4 M 3:2
<model>_IMAGESIZE_M_16_9 5 M 16:9
<model>_IMAGESIZE_M_1_1 6 M 1:1
<model>_IMAGESIZE_L_3_2 7 L 3:2
<model>_IMAGESIZE_L_16_9 8 L 16:9
<model>_IMAGESIZE_L_1_1 9 L 1:1
**[GFX100RF]**
<model>_IMAGESIZE_S_3_2 S 3:2
<model>_IMAGESIZE_S_16_9 S 16:9
<model>_IMAGESIZE_S_1_1 S 1:1
<model>_IMAGESIZE_S_4_3 S 4:3
<model>_IMAGESIZE_S_65_24 S 65:24
<model>_IMAGESIZE_S_5_4 S 5:4
<model>_IMAGESIZE_S_7_6 S 7:6
<model>_IMAGESIZE_S_3_4 S 3:4
<model>_IMAGESIZE_S_ 1 7_6 S 17:6
<model>_IMAGESIZE_M_3_2 M 3:2
<model>_IMAGESIZE_M_16_9 M 16:9
<model>_IMAGESIZE_M_1_1 M 1:1
<model>_IMAGESIZE_M_4_3 M 4:3
<model>_IMAGESIZE_M_65_24 M 65:24
<model>_IMAGESIZE_M_5_4 M 5:4
<model>_IMAGESIZE_M_7_6 M 7:6
<model>_IMAGESIZE_M_3_4 S 3:4
<model>_IMAGESIZE_M_ 1 7_6 S 17:6
<model>_IMAGESIZE_L_3_2 L 3:2
<model>_IMAGESIZE_L_16_9 L 16:9
<model>_IMAGESIZE_L_1_1 L 1:1
<model>_IMAGESIZE_L_4_3 L 4:3
<model>_IMAGESIZE_L_65_24 L 65:24
<model>_IMAGESIZE_L_5_4 L 5:4
<model>_IMAGESIZE_L_7_6 L 7:6
<model>_IMAGESIZE_L_3_4 S 3:4
<model>_IMAGESIZE_L_ 1 7_6 S 17:6


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**Remarks**
This function can be used in State S3.
**See Also**
GetImageSize


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.5.3. GetImageSize
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the IMAGE SIZE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetImageSize
lAPIParam (IN) <model>_API_PA R A M_GetImageSize
plImageSize (OUT) See lImageSize of “SetImageSize”.
**Remarks**
This function can be used in State S3.
**See Also**
SetImageSize
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plImageSize
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.5.4. CapImageQuality
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported IMAGE QUALITY settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapImageQuality
lAPIParam (IN) <model>_API_PARAM_CapImageQuality
plNum (OUT) Returns the number of “SetImageQuality” settings supported.
plImageQuality (OUT) See lImageQuality of “SetImageQuality”.
**Remarks**
This function can be used in State S3.
**See Also**
SetImageQuality
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plImageQuality
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.5.5. SetImageQuality
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the IMAGE QUALITY setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetImageQuality
lAPIParam (IN) <model>_API_PARAM_SetImageQuality
lImageQuality (IN)
**[GFX 50S/GFX 50R/GFX 100/GFX100S/GFX100II/GFX100SII]**
GFX50S_IMAGEQUALITY_RAW RAW
GFX50S_IMAGEQUALITY_SUPERFINE SUPERFINE
GFX50S_IMAGEQUALITY_FINE FINE
GFX50S_IMAGEQUALITY_NORMAL NORMAL
GFX50S_IMAGEQUALITY_RAW_SUPERFINE RAW+SUPERFINE
GFX50S_IMAGEQUALITY_RAW_FINE RAW+FINE
GFX50S_IMAGEQUALITY_RAW_NORMAL RAW+NORMAL
**[Other models]**
<model>_IMAGEQUALITY_RAW RAW
<model>_IMAGEQUALITY_FINE FINE
<model>_IMAGEQUALITY_NORMAL NORMAL
<model>_IMAGEQUALITY_RAW_FINE RAW+FINE
<model>_IMAGEQUALITY_RAW_NORMAL RAW+NORMAL
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lImageQuality
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**Remarks**
This function can be used in State S3.
**See Also**
GetImageQuality


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.5.6. GetImageQuality
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the IMAGE QUALITY setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetImageQuality
lAPIParam (IN) <model>_API_PARAM_GetImageQuality
plImageQuality (OUT) See lImageQuality of “SetImageQuality”.
**Remarks**
This function can be used in State S3.
**See Also**
SetImageQuality
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plImageQuality
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.5.7. CapRAWCompression
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported RAW COMPRESSION/RAW RECORDING TYPE settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapRAWCompression
lAPIParam (IN) <model>_API_PARAM_CapRAWCompression
plNum (OUT) Returns the number of “SetRAWCompression” settings supported.
plRAWCompression (OUT) See lRAWCompression of “SetRAWCompression”.
**Remarks**
This function can be used in State S3.
**See Also**
SetRAWCompression
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plRAWCompression
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.5.8. SetRAWCompression
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the RAW COMPRESSION / RAW RECORDING TYPE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetRAWCompression
lAPIParam (IN) <model>_API_PARAM_SetRAWCompression
lRAWCompression (IN)
<model>_RAW_COMPRESSION_OFF UNCOMPRESSED
<model>_RAW_COMPRESSION_LOSSLESS LOSSLESS COMPRESSED
<model>_RAW_COMPRESSION_LOSSY COMPRESSED
(LOSSY COMPRESSED)
The values supported vary with the camera model and firmware version.
**Remarks**
This function can be used in State S3.
**See Also**
GetRAWCompression
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lRAWCompression
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.5.9. GetRAWCompression
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the RAW COMPRESSION / RAW RECORDING TYPE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetRAWCompression
lAPIParam (IN) <model>_API_PARAM_GetRAWCompression
plRAWCompression (OUT) See lRAWCompression of “SetRAWCompression”.
**Remarks**
This function can be used in State S3.
**See Also**
SetRAWCompression
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plRAWCompression
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.5.10. SetRAWOutputDepth
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-H1
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3
**Description**
Sets the RAW RECORDING OUTPUT DEPTH setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetRAWOutputDepth
lAPIParam (IN) <model>_API_PARAM_SetRAWOutputDepth
lRAWDepth (IN)
<model>_RAW_OUTPUTDEPTH_14BIT 14 bit
<model>_RAW_OUTPUTDEPTH_16BIT 16 bit
**Remarks**
This function can be used in State S3.
**See Also**
GetRAWOutputDepth
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lRAWDepth
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.5.11. GetRAWOutputDepth
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-H1
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the RAW RECORDING OUTPUT DEPTH setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetRAWOutputDepth
lAPIParam (IN) <model>_API_PARAM_GetRAWOutputDepth
plRAWDepth (OUT) See lRAWDepth of “SetRAWOutputDepth”.
**Remarks**
This function can be used in State S3.
**See Also**
SetRAWOutputDepth
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plRAWDepth
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.6. White Balance
4.2.6.1. CapWhiteBalanceTune
Supported Cameras
X-
T1
X-
T2
X-
T3
X-
T4
X-
T 5
X-
Pro2
X-
Pro3
X-
S10
X-
H2S
X-
H2
X-
S20
X-
M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported WHITE BALANCE SHIFT settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapWhiteBalanceTune
lAPIParam (IN) <model>_API_PARAM_CapWhiteBalanceTune
lWBMode (IN)
<model>_WB_AUTO AUTO
<model>_WB_AUTO_WHITE_PRIORITY AUTO (WHITE PRIORITY)
<model>_WB_AUTO_AMBIENCE_PRIORITY AUTO (AMBIENCE PRIORITY)
<model>_WB_DAYLIGHT DAYLIGHT / FINE
<model>_WB_INCANDESCENT INCANDESCENT^
<model>_WB_UNDER_WATER UNDERWATER
<model>_WB_FLUORESCENT1 FLUORESCENT- 1
<model>_WB_FLUORESCENT2 FLUORESCENT-^2
<model>_WB_FLUORESCENT3 FLUORESCENT- 3
<model>_WB_SHADE SHADE
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lWBMode,
long* plTuneR_Min,
long* plTuneB_Min,
long* plTuneR_Max,
long* plTuneB_Max
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_WB_COLORTEMP COLOR TEMPERATURE
<model>_WB_CUSTOM1 CUSTOM1^
<model>_WB_CUSTOM2 CUSTOM2
<model>_WB_CUSTOM3 CUSTOM3
<model>_WB_CUSTOM4 CUSTOM4^
<model>_WB_CUSTOM5^ CUSTOM5^
plTuneR_Min (OUT) See lTuneR of SetWhiteBalanceTune.
plTuneB_Min (OUT) See lTuneB of SetWhiteBalanceTune.
plTuneR_Max (OUT) See lTuneR of SetWhiteBalanceTune.
plTuneB_Max (OUT) See lTuneB of SetWhiteBalanceTune.
**Note**
Using this function to change the white balance mode setting temporary inside the SDK. It can be shown LCD/EVF
in a moment.
**Remarks**
This function can be used in State S3.
**See Also**
SetWhiteBalanceTune


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.6.2. SetWhiteBalanceTune
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the WHITE BALANCE SHIFT settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetWhiteBalanceTune
lAPIParam <model>_API_PA R A M_SetWhiteBalanceTune
lWBMode (IN) Specifies the white balance mode to be fine-tuned.
When the white balance mode is set to color temperature, the selected value applies
to all color temperatures.
See lWBMode of SetWhiteBalanceMode or XSDK_SetWBMode.
lTuneR (IN) Specify a red-cyan tuning value.
<model>_WB_R_SHIFT_MIN Minimum red-tuning value
<model>_WB_R_SHIFT_MAX Maximum red-tuning value.
<model>_WB_R_SHIFT_STEP Tuning increment for red-tuning value.
(Cyan) -9 / -8 / -7 / -6 / -5 / -4 / -3 / -2 / -1 / 0 / 1 / 2 / 3 / 4 / 5 / 6 / 7 / 8 / 9 (Red)
lTuneB (IN) Specify a red-cyan tuning value.
<model>_WB_B_SHIFT_MIN Minimum blue-tuning value
<model>_WB_B_SHIFT_MAX Maximum blue-tuning value.
<model>_WB_B_SHIFT_STEP Tuning increment for blue-tuning value.
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lWBMode,
long lTuneR,
long lTuneB
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
(Yellow) -9 / -8 / -7 / - 6 / -5 / -4 / -3 / -2 / -1 / 0 / 1 / 2 / 3 / 4 / 5 / 6 / 7 / 8 / 9 (Blue)
**Note**
Setting the values takes a few seconds.
**Remarks**
This function can be used in State S3.
**See Also**
GetWhiteBalanceTune


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.6.3. GetWhiteBalanceTune
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the WHITE BALANCE SHIFT settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetWhiteBalanceTune
lAPIParam <model>_API_PA R A M_GetWhiteBalanceTune
lWBMode (IN) When the white balance is set to color temperature, the fine-tuning applies at all
color temperatures.
See lWBMode of SetWhiteBalanceTune.
plTuneR (OUT) See lTuneR of SetWhiteBalanceTune.
plTuneB (OUT) See lTuneB of SetWhiteBalanceTune.
**Note**
Using this function to change the white balance mode setting temporary inside the SDK. It can be shown LCD/EVF
in a moment.
**Remarks**
This function can be used in State S3.
**See Also**
SetWhiteBalanceTune
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lWBMode,
long* plTuneR,
long* plTuneB
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.7. Film Simulation
4.2.7.1. CapFilmSimulationMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported FILM SIMULATION settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapFilmSimulationMode
lAPIParam (IN) <model>_API_PARAM_CapFilmSimulationMode
plNum (OUT) Returns the number of “SetFilmSimulationMode” settings supported.
plFilmSimulation (OUT) The film simulation mode.
<model>_FILMSIMULATION_PROVIA 1 PROVIA/STANDARD
<model>_FILMSIMULATION_VELVIA 2 Ve l v i a / V I V I D
<model>_FILMSIMULATION_ASTIA 3 Astia/SOFT
<model>_FILMSIMULATION_CLASSICCHROME 11 CLASSIC CHROME
<model>_FILMSIMULATION_REALAACE 20 REALA ACE
<model>_FILMSIMULATION_NEGHI 4 PRO Neg. Hi
<model>_FILMSIMULATION_NEGSTD 5 PRO Neg. Std
<model>_FILMSIMULATION_CLASSICNEG 17 CLASSIC Neg.
<model>_FILMSIMULATION_NOSTALGICNEG 19 NOSTALGIC Neg.
<model>_FILMSIMULATION_ETERNA 16 ETERNA/CINEMA
<model>_FILMSIMULATION_BLEACH_BYPASS 18 ETERNA BLEACH BYPASS
<model>_FILMSIMULATION_ACROS 12 ACROS
<model>_FILMSIMULATION_ACROS_Y 13 ACROS+Y Filter
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plFilmSimulation
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_FILMSIMULATION_ACROS_R 14 ACROS+R Filter
<model>_FILMSIMULATION_ACROS_G 15 ACROS+G Filter
<model>_FILMSIMULATION_MONOCHRO 6 B/W
<model>_FILMSIMULATION_MONOCHRO_Y 7 Monochrome+Y Filter
<model>_FILMSIMULATION_MONOCHRO_R 8 Monochrome+R Filter
<model>_FILMSIMULATION_MONOCHRO_G 9 Monochrome+G Filter
<model>_FILMSIMULATION_SEPIA 10 Sepia
The values supported vary with the camera model and firmware version.
**Remarks**
This function can be used in State S3.
**See Also**
SetFilmSimulationMode


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.7.2. SetFilmSimulationMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the FILM SIMULATION setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetFilmSimulationMode
lAPIParam (IN) <model>_API_PA R A M_SetFilmSimulationMode
lFilmSimulation (IN) The film simulation mode.
<model>_FILMSIMULATION_PROVIA 1 PROVIA/STANDARD
<model>_FILMSIMULATION_VELVIA 2 Ve l v i a/VIVID
<model>_FILMSIMULATION_ASTIA 3 Astia/SOFT
<model>_FILMSIMULATION_CLASSICCHROME 11 CLASSIC CHROME
<model>_FILMSIMULATION_REALAACE 20 REALA ACE
<model>_FILMSIMULATION_NEGHI 4 PRO Neg. Hi
<model>_FILMSIMULATION_NEGSTD 5 PRO Neg. Std
<model>_FILMSIMULATION_CLASSICNEG 17 CLASSIC Neg.
<model>_FILMSIMULATION_NOSTALGICNEG 19 NOSTALGIC Neg.
<model>_FILMSIMULATION_ETERNA 16 ETERNA/CINEMA
<model>_FILMSIMULATION_BLEACH_BYPASS 18 ETERNA BLEACH BYPASS
<model>_FILMSIMULATION_ACROS 12 ACROS
<model>_FILMSIMULATION_ACROS_Y 13 ACROS+Y Filter
<model>_FILMSIMULATION_ACROS_R 14 ACROS+R Filter
<model>_FILMSIMULATION_ACROS_G 15 ACROS+G Filter
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lFilmSimulation
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_FILMSIMULATION_MONOCHRO 6 B/W
<model>_FILMSIMULATION_MONOCHRO_Y 7 Monochrome+Y Filter
<model>_FILMSIMULATION_MONOCHRO_R 8 Monochrome+R Filter
<model>_FILMSIMULATION_MONOCHRO_G 9 Monochrome+G Filter
<model>_FILMSIMULATION_SEPIA 10 Sepia
The values supported vary with the camera model and firmware version.
**Remarks**
This function can be used in State S3.
**See Also**
GetFilmSimulationMode


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.7.3. GetFilmSimulationMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the FILM SIMULATION setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetFilmSimulationMode
lAPIParam (IN) <model>_API_PA R A M_GetFilmSimulationMode
plFilmSimulation (OUT) The film simulation mode. See lFilmSimulation of “SetFilmSimulationMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetFilmSimulationMode
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plFilmSimulation
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.7.4. CapGrainEffect
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported GRAIN EFFECT settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapGrainEffect
lAPIParam (IN) <model>_API_PARAM_CapGrainEffect
plNum (OUT) Returns the number of “SetGrainEffect” settings supported.
plEffect (OUT) See lEffect of “SetGrainEffect”.
**Remarks**
This function can be used in State S3.
**See Also**
SetGrainEffect
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plEffect
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.7.5. SetGrainEffect
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the GRAIN EFFECT setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetGrainEffect
lAPIParam (IN) <model>_API_PA R A M_SetGrainEffect
lEffect (IN) The GRAIN EFFECT mode.
**< X-T3, GFX 50S, GFX 50R, and GFX 100 Ver.1.x>**
<model>_GRAIN_EFFECT_OFF OFF
<model>_GRAIN_EFFECT_P1
<model>_GRAIN_EFFECT_WEAK
WEAK
<model>_GRAIN_EFFECT_P2
<model>_GRAIN_EFFECT_STRONG
STRONG
**< Other models >**
<model>_GRAIN_EFFECT_OFF_SMALL OFF / SMALL
<model>_GRAIN_EFFECT_WEAK_SMALL WEAK / SMALL
<model>_GRAIN_EFFECT_STRONG_SMALL STRONG / SMALL
<model>_GRAIN_EFFECT_OFF_LARGE OFF / LARGE
<model>_GRAIN_EFFECT_WEAK_LARGE WEAK / LARGE
<model>_GRAIN_EFFECT_STRONG_LARGE STRONG / LARGE
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lEffect
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**Remarks**
This function can be used in State S3.
**See Also**
GetGrainEffect


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.7.6. GetGrainEffect
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the GRAIN EFFECT setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetGrainEffect
lAPIParam (IN) <model>_API_PA R A M_GetGrainEffect
plEffect (OUT) See lEffect of “SetGrainEffect”.
**Remarks**
This function can be used in State S3.
**See Also**
SetGrainEffect
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plEffect
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.7.7. CapMonochromaticColor
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported MONOCHROMATIC COLOR settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMonochromaticColor
lAPIParam (IN) <model>_API_PARAM_CapMonochromaticColor
plWarmCoolNum (OUT) Returns the number of The MONOCHROMATIC COLOR settings for
WA R M-COOL axis
plRedGreenNum (OUT) Returns the number of The MONOCHROMATIC COLOR settings for
MAGENTA-GREEN axis.
plWarmCool (OUT) See lWarmCool of “SetMonochromaticColor”.
plMagentaGreen (OUT) See lMagentaGreen of “SetMonochromaticColor”.
**Remarks**
This function can be used in State S3.
**See Also**
SetMonochromaticColor
**Sample**
long lAPICode = <model>_API_CODE_ CapMonochromaticColor;
long lAPIParam = <model>_API_PARAM_CapMonochromaticColor;
long lWarmCoolNum;
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plWarmCoolNum,
long* plMagentaGreenNum,
long* plWarmCool,
long* plMagentaGreen
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
long lMagentaGreenNum;
long* plWarmCool;
long* plMagentaGreen;
XSDK_CapProp( hCam, lAPICode, lAPIParam, &lWarmCoolNum, &lMagentaGreenNum, NULL, NULL );
plWarmCool = new long [lWarmCoolNum];
plMagentaGreen = new long [lMagentaGreenNum];
XSDK_CapProp( hCam, lAPICode, lAPIParam, &lWarmCoolNum, &lMagentaGreenNum,
plWarmCool, plMagentaGreen);
delete [] plWarmCool;
delete [] plMagentaGreen;


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.7.8. SetMonochromaticColor
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the MONOCHROMATIC COLOR settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMonochromaticColor
lAPIParam (IN) <model>_API_PA R A M_SetMonochromaticColor
lWarmCool (IN) The MONOCHROMATIC COLOR setting of WARM-COOL direction.
<model>_MONOCHROMATICCOLOR_WC_P180 + 18 (Warm)
<model>_MONOCHROMATICCOLOR_WC_P170 + 17
<model>_MONOCHROMATICCOLOR_WC_P160 + 16
<model>_MONOCHROMATICCOLOR_WC_P150 + 15
<model>_MONOCHROMATICCOLOR_WC_P140 + 14
<model>_MONOCHROMATICCOLOR_WC_P130 + 13
<model>_MONOCHROMATICCOLOR_WC_P120 + 12
<model>_MONOCHROMATICCOLOR_WC_P110 + 11
<model>_MONOCHROMATICCOLOR_WC_P100 + 10
<model>_MONOCHROMATICCOLOR_WC_P90 + 9
<model>_MONOCHROMATICCOLOR_WC_P80 + 8
<model>_MONOCHROMATICCOLOR_WC_P70 + 7
<model>_MONOCHROMATICCOLOR_WC_P60 + 6
<model>_MONOCHROMATICCOLOR_WC_P50 + 5
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lWarmCool,
long lMagentaGreen
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_MONOCHROMATICCOLOR_WC_P40 + 4
<model>_MONOCHROMATICCOLOR_WC_P30 + 3
<model>_MONOCHROMATICCOLOR_WC_P20 + 2
<model>_MONOCHROMATICCOLOR_WC_P10 + 1
<model>_MONOCHROMATICCOLOR_WC_0 0
<model>_MONOCHROMATICCOLOR_WC_M10 - 1
<model>_MONOCHROMATICCOLOR_WC_M20 - 2
<model>_MONOCHROMATICCOLOR_WC_M30 - 3
<model>_MONOCHROMATICCOLOR_WC_M40 - 4
<model>_MONOCHROMATICCOLOR_WC_M50 - 5
<model>_MONOCHROMATICCOLOR_WC_M60 - 6
<model>_MONOCHROMATICCOLOR_WC_M70 - 7
<model>_MONOCHROMATICCOLOR_WC_M80 - 8
<model>_MONOCHROMATICCOLOR_WC_M90 - 9
<model>_MONOCHROMATICCOLOR_WC_M100 - 10
<model>_MONOCHROMATICCOLOR_WC_M110 - 11
<model>_MONOCHROMATICCOLOR_WC_M120 - 12
<model>_MONOCHROMATICCOLOR_WC_M130 - 13
<model>_MONOCHROMATICCOLOR_WC_M140 - 14
<model>_MONOCHROMATICCOLOR_WC_M150 - 15
<model>_MONOCHROMATICCOLOR_WC_M160 - 16
<model>_MONOCHROMATICCOLOR_WC_M170 - 17
<model>_MONOCHROMATICCOLOR_WC_M180 - 18 (Cool)
lMaghentaGreen (IN) The MONOCHROMATIC COLOR setting of MAGENTA-GREEN direction.
<model>_MONOCHROMATICCOLOR_RG_P180 + 18 (Green)
<model>_MONOCHROMATICCOLOR_RG_P170 + 17
<model>_MONOCHROMATICCOLOR_RG_P160 + 16
<model>_MONOCHROMATICCOLOR_RG_P150 + 15
<model>_MONOCHROMATICCOLOR_RG_P14 0 + 14
<model>_MONOCHROMATICCOLOR_RG_P130 + 13
<model>_MONOCHROMATICCOLOR_RG_P120 + 12
<model>_MONOCHROMATICCOLOR_RG_P110 + 11
<model>_MONOCHROMATICCOLOR_RG_P100 + 10
<model>_MONOCHROMATICCOLOR_RG_P90 + 9
<model>_MONOCHROMATICCOLOR_RG_P80 + 8
<model>_MONOCHROMATICCOLOR_RG_P70 + 7
<model>_MONOCHROMATICCOLOR_RG_P60 + 6


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_MONOCHROMATICCOLOR_RG_P50 + 5
<model>_MONOCHROMATICCOLOR_RG_P40 + 4
<model>_MONOCHROMATICCOLOR_RG_P30 + 3
<model>_MONOCHROMATICCOLOR_RG_P20 + 2
<model>_MONOCHROMATICCOLOR_RG_P10 + 1
<model>_MONOCHROMATICCOLOR_RG_0 0
<model>_MONOCHROMATICCOLOR_RG_M10 - 1
<model>_MONOCHROMATICCOLOR_RG_M20 - 2
<model>_MONOCHROMATICCOLOR_RG_M30 - 3
<model>_MONOCHROMATICCOLOR_RG_M40 - 4
<model>_MONOCHROMATICCOLOR_RG_M50 - 5
<model>_MONOCHROMATICCOLOR_RG_M60 - 6
<model>_MONOCHROMATICCOLOR_RG_M70 - 7
<model>_MONOCHROMATICCOLOR_RG_M80 - 8
<model>_MONOCHROMATICCOLOR_RG_M90 - 9
<model>_MONOCHROMATICCOLOR_RG_M100 - 10
<model>_MONOCHROMATICCOLOR_RG_M110 - 11
<model>_MONOCHROMATICCOLOR_RG_M120 - 12
<model>_MONOCHROMATICCOLOR_RG_M130 - 13
<model>_MONOCHROMATICCOLOR_RG_M140 - 14
<model>_MONOCHROMATICCOLOR_RG_M150 - 15
<model>_MONOCHROMATICCOLOR_RG_M160 - 16
<model>_MONOCHROMATICCOLOR_RG_M170 - 17
<model>_MONOCHROMATICCOLOR_RG_M180 - 18 (Magenta)
**Remarks**
This function can be used in State S3.
**See Also**
GetMonochromaticColor


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.7.9. GetMonochromaticColor
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the MONOCHROMATIC COLOR settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMonochromaticColor
lAPIParam (IN) <model>_API_PA R A M_GetMonochromaticColor
plWarmCool (OUT) See lWarmCool of “SetMonochromaticColor”.
plMagentaGreen (OUT) See lMagentaGreen of “SetMonochromaticColor”.
**Remarks**
This function can be used in State S3.
**See Also**
SetMonochromaticColor
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plWarmCool
long* plMagentaGreen
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8. Image Quality Control
4.2.8.1. CapSharpness
Supported Cameras
X-
T1
X-
T2
X-
T3
X-
T4
X-
T 5
X-
Pro2
X-
Pro3
X-
S10
X-
H2S
X-
H2
X-
S20
X-
M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported SHARPNESS settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapSharpness
lAPIParam (IN) <model>_API_PARAM_CapSharpness
plNum (OUT) Returns the number of “SetSharpness” settings supported.
plSharpness (OUT) See lSharpness of “SetSharpness”.
**Remarks**
This function can be used in State S3.
**See Also**
SetSharpness
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSharpness
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.2. SetSharpness
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the SHARPNESS setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetSharpness
lAPIParam (IN) <model>_API_PA R A M_SetSharpness
lSharpness (IN)
<model>_SHARPNESS_P4 **+ 4**
<model>_SHARPNESS_P3 **+ 3**
<model>_SHARPNESS_P2 **+2**
<model>_SHARPNESS_P1 **+1**
<model>_SHARPNESS_0 **0**
<model>_SHARPNESS_M1 **- 1**
<model>_SHARPNESS_M2 **- 2**
<model>_SHARPNESS_M3 **- 3**
<model>_SHARPNESS_M4 **- 4
Remarks**
This function can be used in State S3.
**See Also**
GetSharpness
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSharpness
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.3. GetSharpness
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the SHARPNESS setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetSharpness
lAPIParam (IN) <model>_API_PA R A M_GetSharpness
plSharpness (OUT) See lSharpness of “SetSharpness”.
**Remarks**
This function can be used in State S3.
**See Also**
SetSharpness
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSharpness
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.4. CapColorMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported saturation (COLOR) settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapColorMode
lAPIParam (IN) <model>_API_PARAM_CapColorMode
plNum (OUT) Returns the number of “SetColorMode” settings supported.
plColorMode (OUT) See lColorMode of “SetColorMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetColorMode
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plColorMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.5. SetColorMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the COLOR setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetColorMode
lAPIParam (IN) <model>_API_PA R A M_SetColorMode
lColorMode (IN)
<model>_COLOR_P4 **+ 4**
<model>_COLOR_P3 **+ 3**
<model>_COLOR_P2 **+2**
<model>_COLOR_P1 **+1**
<model>_COLOR_0 **0**
<model>_COLOR_M1 **- 1**
<model>_COLOR_M2 **- 2**
<model>_COLOR_M3 **- 3**
<model>_COLOR_M4 **- 4
Remarks**
This function can be used in State S3.
**See Also**
GetColorMode
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lColorMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.6. GetColorMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX
50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the COLOR setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetColorMode
lAPIParam (IN) <model>_API_PA R A M_GetColorMode
plColorMode (OUT) See lColorMode of “SetColorMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetColorMode
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plColorMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.7. CapHighLightTone
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported HIGHLIGHT TONE settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapHighLightTone
lAPIParam (IN) <model>_API_PARAM_CapHighLightTone
plNum (OUT) Returns the number of “SetHighlightTone” settings supported.
plTone (OUT) See lTone of “SetHighLightTone”
**Remarks**
This function can be used in State S3.
**See Also**
SetHighLightTone
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plTone
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.8. SetHighLightTone
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the HIGHLIGHT TONE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetHighLightTone
lAPIParam (IN) <model>_API_PA R A M_SetHighLightTone
lTone (IN)
<model>_HIGHLIGHT_TONE _P4 **+ 4**
<model>_HIGHLIGHT_TONE _P3_5 * **+3.5**
<model>_HIGHLIGHT_TONE _P3 **+ 3**
<model>_HIGHLIGHT_TONE _P2_5 * **+2.5**
<model>_HIGHLIGHT_TONE _P2 **+2**
<model>_HIGHLIGHT_TONE _P1_5 * **+1.5**
<model>_HIGHLIGHT_TONE _P1 **+1**
<model>_HIGHLIGHT_TONE _P0_5 * **+0.5**
<model>_HIGHLIGHT_TONE _0 **0**
<model>_HIGHLIGHT_TONE _M 0 _5 * **- 0.5**
<model>_HIGHLIGHT_TONE _M1 **- 1**
<model>_HIGHLIGHT_TONE _M1_5 * **- 1 .5**
<model>_HIGHLIGHT_TONE _M2 **- 2
*** Some models do not support these settings
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lTone
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**Remarks**
This function can be used in State S3.
**See Also**
GetHighLightTone


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.9. GetHighLightTone
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the HIGHLIGHT TONE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetHighLightTone
lAPIParam (IN) <model>_API_PA R A M_GetHighLightTone
plTone (OUT) See lTone of “SetHighLightTone”**.
Remarks**
This function can be used in State S3.
**See Also**
SetHighLightTone
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plTone
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.10. CapShadowTone
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported SHADOW TONE settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapShadowTone
lAPIParam (IN) <model>_API_PARAM_CapShadowTone
plNum (OUT) Returns the number of “SetShadowTone” settings supported.
plTone (OUT) See lTone of “SetShadowTone”.
**Remarks**
This function can be used in State S3.
**See Also**
SetShadowTone
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plTone
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.11. SetShadowTone
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the SHADOW TONE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetShadowTone
lAPIParam (IN) <model>_API_PA R A M_SetShadowTone
lTone (IN)
<model>_SHADOW_TONE _P4 **+ 4**
<model>_SHADOW_TONE _P3_5 * **+3.5**
<model>_SHADOW_TONE _P3 **+ 3**
<model>_SHADOW_TONE _P2_5 * **+2.5**
<model>_SHADOW_TONE _P2 **+2**
<model>_SHADOW_TONE _P1_5 * **+1.5**
<model>_SHADOW_TONE _P1 **+1**
<model>_SHADOW_TONE _P0_5 * **+0.5**
<model>_SHADOW_TONE _0 **0**
<model>_SHADOW_TONE _M0_5 * **- 0.5**
<model>_SHADOW_TONE _M1 **- 1**
<model>_SHADOW_TONE _M1_5 * **- 1 .5**
<model>_SHADOW_TONE _M2 **- 2
*** Some models do not support these settings
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lTone
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**Remarks**
This function can be used in State S3.
**See Also**
GetShadowTone


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.12. GetShadowTone
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the SHADOW TONE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetShadowTone
lAPIParam (IN) <model>_API_PA R A M_GetShadowTone
plTone (OUT) See lTone of “SetShadowTone”.
**Remarks**
This function can be used in State S3.
**See Also**
SetShadowTone
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plTone
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.13. CapShadowing
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported values for COLOR CHROME EFFECT.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapShadowing
lAPIParam (IN) <model>_API_PA R A M_CapShadowing
plNum (OUT) Returns the number of “SetShadowing” settings supported.
plShadowing (OUT) See lColorChromeEffect of “SetShadowing”.
**Remarks**
This function can be used in State S3.
**See Also**
SetShadowing
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plShadowing
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.14. SetShadowing
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the COLOR CHROME EFFECT setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetShadowing
lAPIParam (IN) <model>_API_PA R A M_SetShadowing
lShadowing (IN)
<model>_SHADOWING_P2 **STRONG**
<model>_SHADOWING_P1 **WEAK**
<model>_SHADOWING_0 **OFF
Remarks**
This function can be used in State S3.
**See Also**
GetShadowing
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lShadowing
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.15. GetShadowing
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the COLOR CHROME EFFECT setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetShadowing
lAPIParam (IN) <model>_API_PA R A M_GetShadowing
plShadowing (OUT) See “SetShadowing”.
**Remarks**
This function can be used in State S3.
**See Also**
SetShadowing
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plShadowing
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.16. CapWideDynamicRange
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported D RANGE PRIORITY settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapWideDynamicRange
lAPIParam (IN) <model>_API_PARAM_CapWideDynamicRange
plNum (OUT) Returns the number of “SetWideDynamicRange” settings supported.
plWideDynamicRange (OUT)
<model>_WIDEDYNAMICRANGE_0 **OFF**
<model>_WIDEDYNAMICRANGE_P1 **WEAK**
<model>_WIDEDYNAMICRANGE_P2 **STRONG**
<model>_WIDEDYNAMICRANGE_P3 **EXTRA STRONG**
<model>_WIDEDYNAMICRANGE_AUTO **AUTO
Remarks**
This function can be used in State S3.
**See Also**
SetWideDynamicRange, GetWideDynamicRange
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plWideDynamicRange
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.17. SetWideDynamicRange
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the D RANGE PRIORITY setting.
**Syntax**
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lWideDynamicRange
);
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetWideDynamicRange
lAPIParam (IN) <model>_API_PARAM_SetWideDynamicRange
lWideDynamicRange (OUT)
<model>_WIDEDYNAMICRANGE_0 **OFF**
<model>_WIDEDYNAMICRANGE_P1 **WEAK**
<model>_WIDEDYNAMICRANGE_P2 **STRONG**
<model>_WIDEDYNAMICRANGE_P2 **EXTRA STRONG**
<model>_WIDEDYNAMICRANGE_AUTO^ **AUTO**^
**Remarks**
This function can be used in State S3.
**See Also**
CapWideDynamicRange, GetWideDynamicRange


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.18. GetWideDynamicRange
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the current D RANGE PRIORITY setting.
**Syntax**
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plWideDynamicRange
);
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetWideDynamicRange
lAPIParam (IN) <model>_API_PARAM_GetWideDynamicRange
plWideDynamicRange (OUT)
<model>_WIDEDYNAMICRANGE_0 **OFF**
<model>_WIDEDYNAMICRANGE_P1 **WEAK**
<model>_WIDEDYNAMICRANGE_P2 **STRONG**
<model>_WIDEDYNAMICRANGE_P3 **EXTRA STRONG**
<model>_WIDEDYNAMICRANGE_AUTO **AUTO
Remarks**
This function can be used in State S3.
**See Also**
CapWideDynamicRange, SetWideDynamicRange


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.19. CapColorChromeBlue
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported COLOR CHROME FX BLUE settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapColorChromeBlue
lAPIParam (IN) <model>_API_PARAM_CapColorChromeBlue
plNum (OUT) Returns the number of “SetColorChromeBlue” settings supported.
plEffect (OUT) See lColorChromeBlue of “SetColorChromeBlue”.
**Remarks**
This function can be used in State S3.
**See Also**
SetColorChromeBlue
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plEffect
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.20. SetColorChromeBlue
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the COLOR CHROME FX BLUE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetColorChromeBlue
lAPIParam (IN) <model>_API_PA R A M_SetColorChromeBlue
lColorChromeBlue (IN)
<model>_COLORCHROME_BLUE_P2 **STRONG**
<model>_COLORCHROME_BLUE_P1 **WEAK**
<model>_COLORCHROME_BLUE_0 **OFF**
The GFX 100 supports COLOR CHROME FX BLUE from firmware version 2.00.
**Remarks**
This function can be used in State S3.
**See Also**
GetColorChromeBlue
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lColorChromeBlue
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.21. GetColorChromeBlue
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the COLOR CHROME FX BLUE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetColorChromeBlue
lAPIParam (IN) <model>_API_PA R A M_GetColorChromeBlue
plColorChromeBlue (OUT) See lColorChromeBlue of “SetColorChromeBlue”.
**Remarks**
This function can be used in State S3.
**See Also**
SetColorChromeBlue
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plColorChromeBlue
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.22. CapClarityMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported CLARITY values.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapClarityMode
lAPIParam (IN) <model>_API_PARAM_CapClarityMode
plNum (OUT) Returns the number of “SetClarityMode” settings supported.
plClarity (OUT)
<model>_CLARITY_P5 **+5**
<model>_CLARITY_P4 **+4**
<model>_CLARITY_P3 **+3**
<model>_CLARITY_P2 **+2**
<model>_CLARITY_P1 **+1**
<model>_CLARITY_0 **0**
<model>_CLARITY_M1 **- 1**
<model>_CLARITY_M2 **- 2**
<model>_CLARITY_M3 **- 3**
<model>_CLARITY_M4 **- 4**
<model>_CLARITY_M5 **- 5**
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plClarity
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**Remarks**
This function can be used in State S3.
**See Also**
SetClarityMode


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.23. SetClarityMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the CLARITY setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetClarityMode
lAPIParam (IN) <model>_API_PA R A M_SetClarityMode
lClarity (IN)
<model>_CLARITY_P5 **+5**
<model>_CLARITY_P4 **+4**
<model>_CLARITY_P3 **+3**
<model>_CLARITY_P2 **+ 2**
<model>_CLARITY_P1 **+ 1**
<model>_CLARITY_0 **0**
<model>_CLARITY_M1 **- 1**
<model>_CLARITY_M2 **- 2**
<model>_CLARITY_M3 **- 3**
<model>_CLARITY_M4 **- 4**
<model>_CLARITY_M5 **- 5**
The GFX 100 supports CLARITY from firmware version 2.00.
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lClarity
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**Remarks**
This function can be used in State S3.
**See Also**
GetClarityMode


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.24. GetClarityMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the CLARITY setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetClarityMode
lAPIParam (IN) <model>_API_PA R A M_GetClarityMode
plClarity (OUT) See lClarity of “SetClarityMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetClarityMode
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plClarity
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.25. SetSmoothSkinEffect
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the SMOOTH SKIN EFFECT setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetSmoothSkinEffect
lAPIParam (IN) <model>_API_PA R A M_SetSmoothSkinEffect
lEffect (IN)
<model>_SMOOTHSKIN_EFFECT_OFF **OFF**
<model>_SMOOTHSKIN_EFFECT_P1 **WEAK**
<model>_SMOOTHSKIN_EFFECT_P2 **STRONG**
The GFX 50S support SMOOTH SKIN EFFECT from firmware version 4.00.
The GFX 50R support SMOOTH SKIN EFFECT from firmware version 2.00.
**Remarks**
This function can be used in State S3.
**See Also**
GetSmoothSkinEffect
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lEffect
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.26. GetSmoothSkinEffect
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the SMOOTH SKIN EFFECT setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetSmoothSkinEffect
lAPIParam (IN) <model>_API_PA R A M_GetSmoothSkinEffect
plEffect (OUT) See lEffect of “SetSmoothSkinEffect”.
**Remarks**
This function can be used in State S3.
**See Also**
SetSmoothSkinEffect
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plEffect
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.27. CapNoiseReduction
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported NOISE REDUCTION / HIGH ISO NR settings.
NOISE REDUCTION and HIGH ISO NR are the same feature. Depending on the model, the name of the feature is
different.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapNoiseReduction
lAPIParam (IN) <model>_API_PARAM_CapNoiseReduction
plNum (OUT) Returns the number of “SetNoiseReduction” settings supported.
plNoiseReduction (OUT) See lNoiseReduction of “SetNoiseReduction”.
**Remarks**
This function can be used in State S3.
**See Also**
SetNoiseReduction
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plNoiseReduction
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.28. SetNoiseReduction
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the NOISE REDUCTION / HIGH ISO NR setting.
NOISE REDUCTION and HIGH ISO NR are the same feature. Depending on the model, the name of the feature is
different.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetNoiseReduction
lAPIParam (IN) <model>_API_PA R A M_SetNoiseReduction
lNoiseReduction (IN)
<model>_NOISEREDUCTION_P4 **+ 4**
<model>_NOISEREDUCTION_P3 **+ 3**
<model>_NOISEREDUCTION_P2 **+2**
<model>_NOISEREDUCTION_P1 **+1**
<model>_NOISEREDUCTION_0 **0**
<model>_NOISEREDUCTION_M1 **- 1**
<model>_NOISEREDUCTION_M2 **- 2**
<model>_NOISEREDUCTION_M3 **- 3**
<model>_NOISEREDUCTION_M4 **- 4
Remarks**
This function can be used in State S3.
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lNoiseReduction
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**See Also**
GetNoiseReduction


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.29. GetNoiseReduction
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the NOISE REDUCTION / HIGH ISO NR setting.
NOISE REDUCTION and HIGH ISO NR are the same feature. Depending on the model, the name of the feature is
different.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetNoiseReduction
lAPIParam (IN) <model>_API_PA R A M_GetNoiseReduction
plNoiseReduction (OUT) See lNoiseReduction of “SetNoiseReduction”.
**Remarks**
This function can be used in State S3.
**See Also**
SetNoiseReduction
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNoiseReduction
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.30. CapLMOMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3
**Description**
Queries supported LENS MODULATION OPTIMIZER settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapLMOMode
lAPIParam (IN) <model>_API_PARAM_CapLMOMode
plNum (OUT) Returns the number of “SetLMOMode” settings supported.
plLMOMode (OUT) See lLMOMode of “SetLMOMode”
**Remarks**
This function can be used in State S3.
**See Also**
SetLMOMode
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plLMOMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.31. SetLMOMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the LENS MODULATION OPTIMIZER setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetLMOMode
lAPIParam (IN) <model>_API_PA R A M_SetLMOMode
lLMOMode (IN)
<model>_ON ON
<model>_OFF OFF
**Remarks**
This function can be used in State S3.
**See Also**
GetLMOMode
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lLMOMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.32. GetLMOMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the LENS MODULATION OPTIMIZER setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetLMOMode
lAPIParam (IN) <model>_API_PA R A M_GetLMOMode
plLMOMode (OUT) See lLMOMode of “SetLMOMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetLMOMode
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plLMOMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.33. CapLongExposureNR
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported LONG EXPOSURE NR settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapLongExposureNR
lAPIParam (IN) <model>_API_PARAM_CapLongExposureNR
plNum (OUT) Returns the number of “SetLongExposureNR” settings supported.
plLongExposureNR (OUT) See lLongExposureNR of “SetLongExposureNR”.
**Remarks**
This function can be used in State S3.
**See Also**
SetLongExposureNR
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plLongExposureNR
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.34. SetLongExposureNR
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the LONG EXPOSURE NR setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetLongExposureNR
lAPIParam (IN) <model>_API_PA R A M_SetLongExposureNR
lLongExposureNR (IN)
<model>_ON ON
<model>_OFF OFF
**Remarks**
This function can be used in State S3.
**See Also**
GetLongExposureNR
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lLongExposureNR
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.35. GetLongExposureNR
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the LONG EXPOSURE NR setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetLongExposureNR
lAPIParam (IN) <model>_API_PA R A M_GetLongExposureNR
plLongExposureNR (OUT) See lLongExposureNR of “SetLongExposureNR”.
**Remarks**
This function can be used in State S3.
**See Also**
SetLongExposureNR
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plLongExposureNR
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.36. CapPortraitEnhancer
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3
**Description**
Queries supported BEAUTIFUL SKIN PROCESSING settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapPortraitEnhancer
lAPIParam (IN) <model>_API_PARAM_ CapPortraitEnhancer
plNum (OUT) Returns the number of “SetPortraitEnhancer” settings supported
plMode (OUT)
<model>_ PORTRAIT_ENHANCER_OFF OFF
<model>_ PORTRAIT_ENHANCER_SOFT Weak
<model>_ PORTRAIT_ENHANCER_MEDIUM Medium
<model>_^ PORTRAIT_ENHANCER_HARD^ Strong^
**Remarks**
This function can be used in State S3.
**See Also**
SetPortraitEnhancer,GetPortraitEnhancer
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.37. SetPortraitEnhancer
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3
**Description**
Sets the BEAUTIFUL SKIN PROCESSING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetPortraitEnhancer
lAPIParam (IN) <model>_API_PARAM_ SetPortraitEnhancer
lMode (IN)
<model>_ PORTRAIT_ENHANCER_OFF OFF
<model>_ PORTRAIT_ENHANCER_SOFT Weak
<model>_ PORTRAIT_ENHANCER_MEDIUM Medium
<model>_^ PORTRAIT_ENHANCER_HARD^ Strong^
**Remarks**
This function can be used in State S3.
**See Also**
CapPortraitEnhancer, GetPortraitEnhancer
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.8.38. GetPortraitEnhancer
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3
**Description**
Gets the MOVIE BEAUTIFUL SKIN PROCESSING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetPortraitEnhancer
lAPIParam (IN) <model>_API_PARAM_ GetPortraitEnhancer
plMode (OUT) See lSetting of “SetPortraitEnhancer”.
**Remarks**
This function can be used in State S3.
**See Also**
CapPortraitEnhancer, SetPortraitEnhancer
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.9. Self Timer
4.2.9.1. CapCaptureDelay
Supported Cameras
X-
T1
X-
T2
X-
T3
X-
T4
X-
T 5
X-
Pro2
X-
Pro3
X-
S10
X-
H2S
X-
H2
X-
S20
X-
M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 (^)
**Description**
Queries supported SELF-TIMER duration settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapCaptureDelay
lAPIParam (IN) <model>_API_PARAM_CapCaptureDelay
plNum (OUT) Returns the number of “SetCaptureDelay” settings supported.
plCaptureDelay (OUT) See lCaptureDelay of “SetCaptureDelay”.
**Remarks**
This function can be used in State S3.
**See Also**
SetCaptureDelay
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plCaptureDelay
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.9.2. SetCaptureDelay
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the SELF-TIMER setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetCaptureDelay
lAPIParam (IN) <model>_API_PA R A M_SetCaptureDelay
lCaptureDelay (IN)
<model>_CAPTUREDELAY_10 10 sec.
<model>_CAPTUREDELAY_2 2 sec.
<model>_CAPTUREDELAY_OFF OFF
**Remarks**
This function can be used in State S3.
**See Also**
GetCaptureDelay
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lCaptureDelay
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.9.3. GetCaptureDelay
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the SELF-TIMER setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetCaptureDelay
lAPIParam (IN) <model>_API_PA R A M_GetCaptureDelay
plCaptureDelay (OUT) See lCaptureDelay of “SetCaptureDelay”.
**Remarks**
This function can be used in State S3.
**See Also**
SetCaptureDelay
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plCaptureDelay
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10. SET-UP
4.2.10.1. SetDateTime
Supported Cameras
X-
T1
X-
T2
X-
T3
X-
T4
X-
T 5
X-
Pro2
X-
Pro3
X-
S10
X-
H2S
X-
H2
X-
S20
X-
M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the DATE/TIME settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetDateTime
lAPIParam (IN) <model>_API_PA R A M_SetDateTime
lYear (IN) YEAR: 2000- 2050
lMonth (IN) MONTH: 1- 12
lDay (IN) DATE: 1- 31
lHour (IN) HOUR: 0- 23
lMinute (IN) MINUTE: 0- 59
lSecond (IN) SECOND: 0- 59
**Remarks**
This function can be used in State S3.
**See Also**
GetDateTime
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lYear,
long lMonth,
long lDay,
long lHour,
long lMinute,
long lSecond
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.2. GetDateTime
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the DATE/TIME settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetDateTime
lAPIParam (IN) <model>_API_PA R A M_GetDateTime
plYear (OUT) See “SetDateTime”.
plMonth (OUT) See “SetDateTime”.
plDay (OUT) See “SetDateTime”.
plHour (OUT) See “SetDateTime”.
plMinute (OUT) See “SetDateTime”.
plSecond (OUT) See “SetDateTime”.
**Remarks**
This function can be used in State S3.
**See Also**
SetDateTime
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plYear,
long* plMonth,
long* plDay,
long* plHour,
long* plMinute,
long* plSecond
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.3. SetDateTimeDispFormat
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Sets the DATE/TIME format.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetDateTimeDispFormat
lAPIParam (IN) <model>_API_PA R A M_SetDateTimeDispFormat
lFormat (IN)
<model>_DATE_FORMAT_YMD YY.MM.DD
<model>_DATE_FORMAT_DMY DD.MM.YY
<model>_DATE_FORMAT_MDY MM/DD/YY
**Remarks**
This function can be used in State S3.
**See Also**
GetDateTimeDispFormat
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lFormat
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.4. GetDateTimeDispFormat
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Get the DATE/TIME format.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetDateTimeDispFormat
lAPIParam (IN) <model>_API_PA R A M_GetDateTimeDispFormat
plFormat (OUT) See lFormat of “SetDateTimeDispFormat”.
**Remarks**
This function can be used in State S3.
**See Also**
SetDateTimeDispFormat
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plFormat
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.5. CapWorldClock
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported HOME, LOCAL settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapWorldClock
lAPIParam (IN) <model>_API_PARAM_CapWorldClock
plNum (OUT) Returns the number of “SetWorldClock” settings supported.
plWorldClock (OUT) See lWorldClock of “SetWorldClock”.
**Remarks**
This function can be used in State S3.
**See Also**
SetWorldClock
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plWorldClock
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.6. SetWorldClock
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Sets the HOME or LOCAL setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetWorldClock
lAPIParam (IN) <model>_API_PA R A M_SetWorldClock
lWorldClock (IN)
<model>_TIMEDIFF_HOME HOME
<model>_TIMEDIFF_LOCAL LOCAL
**Remarks**
This function can be used in State S3.
**See Also**
GetWorldClock
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lWorldClock
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.7. GetWorldClock
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Gets the HOME or LOCAL setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetWorldClock
lAPIParam (IN) <model>_API_PA R A M_GetWorldClock
plWorldClock (OUT) See lWorldClock of “SetWorldClock”.
**Remarks**
This function can be used in State S3.
**See Also**
SetWorldClock
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plWorldClock
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.8. CapTimeDifference
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported TIME DIFFERENCE settings.
If the model supports UTC based timezone, TIME DIFFERENCE is depending on HOME/LOCAL setting. To call
CapTimeDifference, setting HOME/LOCAL prior to this API is required.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapTimeDifference
lAPIParam (IN) <model>_API_PARAM_CapTimeDifference
plDiffHourNum (OUT) Returns the number of Hour : -23 ... 0 ... +23
plDiffMinuteNum (OUT) Returns the number of Minutes : 0 / 15 / 30 / 45
plDiffHour (OUT) See lDiffHour of “SetTimeDifference”.
plDiffMinute (OUT) See lDiffMinute of “SetTimeDifference”.
**Remarks**
This function can be used in State S3.
**See Also**
SetTimeDifference
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plDiffHourNum,
long* plDiffMinuteNum,
long* plDiffHour,
long* plDiffMinute
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.9. SetTimeDifference
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Sets the TIME DIFFERENCE settings.
If the model supports UTC based timezone, TIME DIFFERENCE is depending on HOME/LOCAL setting. To call
SetTimeDifference, setting HOME/LOCAL prior to this API is required.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetTimeDifference
lAPIParam (IN) <model>_API_PA R A M_SetTimeDifference
lDiffHour (IN) HOUR: -23 ... 0 ... +23
lDiffMinute (IN) MINUTES: 0 / 15 / 30 / 45
**Remarks**
This function can be used in State S3.
**See Also**
GetTimeDifference
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lDiffHour,
long lDiffMinute
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.10. GetTimeDifference
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Gets the TIME DIFFERENCE settings.
If the model supports UTC based timezone, TIME DIFFERENCE is depending on HOME/LOCAL setting. To call
GetTimeDifference, setting HOME/LOCAL prior to this API is required.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetTimeDifference
lAPIParam (IN) <model>_API_PA R A M_GetTimeDifference
plDiffHour (OUT) See lDiffHour of “SetTimeDifference”.
plDiffMinute (OUT) See lDiffMinute of “SetTimeDifference”.
**Remarks**
This function can be used in State S3.
**See Also**
SetTimeDifference
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plDiffHour,
long* plDiffMinute
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.11. CapSummerTime
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported DAYLIGHT SAVINGS settings.
If the model supports UTC based timezone, DAYLIGHT SAVINGS is depending on HOME/LOCAL setting. To
call CapSummerTime, setting HOME/LOCAL prior to this API is required.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapSummerTime
lAPIParam (IN) <model>_API_PARAM_CapSummerTime
plNum (OUT) Returns the number of “SetSummerTime” settings supported.
plSummerTime (OUT) See lSummerTime of “SetSummerTime”.
**Remarks**
This function can be used in State S3.
**See Also**
SetSummerTime
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSummerTime
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.12. SetSummerTime
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Sets DAYLIGHT SAVINGS setting.
If the model supports UTC based timezone, DAYLIGHT SAVINGS is depending on HOME/LOCAL setting. To
call SetSummerTime, setting HOME/LOCAL prior to this API is required.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetSummerTime
lAPIParam (IN) <model>_API_PARAM_SetSummerTime
lSummerTime (IN)
<model>_ON ON
<model>_OFF OFF
**Remarks**
This function can be used in State S3.
**See Also**
GetSummerTime
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSummerTime
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.13. GetSummerTime
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Gets the DAYLIGHT SAVINGS setting.
If the model supports UTC based timezone, DAYLIGHT SAVINGS is depending on HOME/LOCAL setting. To
call GetSummerTime, setting HOME/LOCAL prior to this API is required.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetSummerTime
lAPIParam (IN) <model>_API_PARAM_GetSummerTime
plSummerTime (OUT) See lSummerTime of “SetSummerTime”.
**Remarks**
This function can be used in State S3.
**See Also**
SetSummerTime
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSummerTime
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.14. CapResetSetting
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported reset options.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapResetSetting
lAPIParam (IN) <model>_API_PARAM_CapResetSetting
plNum (OUT) Returns the number of “ResetSetting” settings supported.
plCategory (OUT)
<model>_ITEM_RESET_SHOOTMENU SHOOTING MENU
<model>_ITEM_RESET_SETUP SET-UP MENU
<model>_ITEM_RESET_MOVIEMENU^ MOVIE MENU^
**Remarks**
This function can be used in State S3.
**See Also**
ResetSetting
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plCategory
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.15. ResetSetting
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Executes RESET setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ResetSetting
lAPIParam (IN) <model>_API_PA R A M_ResetSetting
lCategory (IN) Select the target menu.
<model>_ITEM_RESET_SHOOTMENU SHOOTING MENU
<model>_ITEM_RESET_SETUP SET-UP MENU
<model>_ITEM_RESET_MOVIEMENU MOVIE MENU
Settings in the MOVIE MENU cannot be reset currently.
**Remarks**
This function can be used in State S3.
**See Also**
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lCategory
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.16. CapExposurePreview
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3
**Description**
Queries supported PREVIEW EXP./WB IN MANUAL MODE settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapExposurePreview
lAPIParam (IN) <model>_API_PARAM_CapExposurePreview
plNum (OUT) Returns the number of “SetExposurePreview” settings supported.
plMode (OUT) See lDispMode of “SetDispMMode / SetExposurePreview”.
**Remarks**
This function can be used in State S3.
**See Also**
SetDispMMode / SetExposurePreview
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.17. SetDispMMode / SetExposurePreview
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX
50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the PREVIEW EXP./WB IN MANUAL MODE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetDispMMode,
or <model>_API_CODE_SetExposurePreview
lAPIParam (IN) <model>_API_PARAM_SetDispMMode,
or <model>_API_PA R A M_SetExposurePreview
lDispMode (IN)
<model>_EXPOSURE_PREVIEW_ME_MWB Preview Exp. / WB
<model>_EXPOSURE_PREVIEW_AE_MWB Preview WB
<model>_EXPOSURE_PREVIEW_AE_AWB Preview OFF
**Remarks**
This function can be used in State S3.
**See Also**
GetDispMMode / GetExposurePreview
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lDispMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.18. GetDispMMode / GetExposurePreview
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the PREVIEW EXP./WB IN MANUAL MODE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetDispMMode,
or <model>_API_CODE_GetExposurePreview
lAPIParam (IN) <model>_API_PA R A M_GetDispMMode,
or <model>_API_PA R A M_GetExposurePreview
plDispMode (OUT) See lDispMode of “SetDispMMode / SetExposurePreview”.
**Remarks**
This function can be used in State S3.
**See Also**
SetDispMMode / SetExposurePreview
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plDispMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.19. CapFrameGuideMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported FRAMING GUIDELINE settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapFrameGuideMode
lAPIParam (IN) <model>_API_PARAM_CapFrameGuideMode
plNum (OUT) Returns the number of “SetFrameGuideMode” settings supported.
plFrameGuideMode (OUT) See lFrameGuideMode of “SetFrameGuideMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetFrameGuideMode
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plFrameGuideMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.20. SetFrameGuideMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the FRAMING GUIDELINE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetFrameGuideMode
lAPIParam (IN) <model>_API_PA R A M_SetFrameGuideMode
lFrameGuideMode (IN)
<model>_FRAMEGUIDE_GRID_9 GRID 9
<model>_FRAMEGUIDE_GRID_24 GRID 24
<model>_FRAMEGUIDE_GRID_HD HD FRAME
**Remarks**
This function can be used in State S3.
**See Also**
GetFrameGuideMode
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lFrameGuideMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.21. GetFrameGuideMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the FRAMING GUIDELINE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetFrameGuideMode
lAPIParam (IN) <model>_API_PA R A M_GetFrameGuideMode
plFrameGuideMode (OUT) See lFrameGuideMode of “SetFrameGuideMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetFrameGuideMode
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plFrameGuideMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.22. SetFrameGuideGridInfo
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the custom FRAMING GUIDELINE.
HD Frame can be modified using the function.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetFrameGuideGridInfo
lAPIParam (IN) <model>_API_PA R A M_SetFrameGuideGridInfo
lDirection (IN)
<model>_ITEM_DIRECTION_0 Create custom framing guides for use
when the camera is rotated 0° (coordinates
refer to the screen as seen from the rear).
Coordinates for use when the camera is
rotated 180° are generated automatically.
<model>_ITEM_DIRECTION_90 Create custom framing guides for use
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lDirection,
<model>_FrameGuideGridInfo* pGridInfo
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
when the camera is rotated CCW 90°
counterclockwise (coordinates refer to the
screen as seen from the rear)
Coordinates for use when the camera is
rotated CCW 270° counterclockwise are
generated automatically.
pGridInfo (IN) typedef struct{
long lGridH[5]; // lGridH[4] have to be zero
long lGridV[5]; // lGridV[4] have to be zero
long lLineWidthH;
long lLineWidthV;
long lLineColorIndex;
long lLineAlpha;
} <model>_FrameGuideGridInfo;
lGridH[]:Drawing position (in percent of the LCD/EVF height) of horizontal lines.
Up to 4 lines, 0..3 is available.
The value is used with denominator 1024 inside the camera.
0: not to draw the line
1 - 1023: position of horizontal lines ( 1: almost top of the LCD/EVF, 1023:
almost bottom of the LCD/EVF )
lGridV[]:Drawing position (in percent of the LCD/EVF width) of vertical lines.
Up to 4 lines, 0..3 is available.
The value is used with denominator 1024 inside the camera.
0: not to draw the line


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
1 - 1023: position of vertical lines ( 1: almost leftmost of the LCD/EVF, 1023:
almost rightmost of the LCD/EVF )
lLineWidthH:The line width (in percent of the LCD/EVF height) of the horizontal
lines.
The value is used with denominator 1024 inside the camera.
0: not to draw the line
1 - 127: line width of the horizontal lines.
lLineWidthV:The line width (in percent of the LCD/EVF width) of the vertical
lines.
The value is used with denominator 1024 inside the camera.
0: not to draw the line
1 - 127: line width of the horizontal lines.
lLineColorIndex : The line color
0:BLACK, 1:BLUE, 2:GREEN, 3:CYAN, 4:RED, 5:VIOLET, 6:YELLOW,
7:WHITE
lLineAlpha : The transparancy ratio of the line.
0:0%(solid) 1:12.5% 2:25% 3: 37.5% 4: 50% 5: 62.5% 6:75%
7:87.5%
**Remarks**
This function can be used in State S3.
**See Also**
GetFrameGuideGridInfo


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.23. GetFrameGuideGridInfo
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the custom FRAMING GUIDELINE.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetFrameGuideGridInfo
lAPIParam (IN) <model>_API_PA R A M_GetFrameGuideGridInfo
lDirection (IN) See lDirection of SetFrameGuideGridInfo.
pGridInfo (OUT) See pGridInfo of SetFrameGuideGridInfo.
**Remarks**
This function can be used in State S3.
**See Also**
SetFrameGuideGridInfo
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lDirection,
<model>_FrameGuideGridInfo* pGridInfo
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.24. CapFocusScaleUnit
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported focus distance units.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapFocusScaleUnit
lAPIParam (IN) <model>_API_PARAM_ CapFocusScaleUnit
plNum (OUT) Returns the number of “SetFocusScaleUnit” settings supported.
plScaleUnit (OUT)
<model>_SCALEUNIT_M METERS
<model>_SCALEUNIT_FT FEET
**Remarks**
This function can be used in State S3.
**See Also**
SetFocusScaleUnit, GetFocusScaleUnit
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plScaleUnit
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.25. SetFocusScaleUnit
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the focus distance unit.
**Syntax**
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lScaleUnit
);
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetFocusScaleUnit
lAPIParam (IN) <model>_API_PARAM_ SetFocusScaleUnit
lScaleUnit (IN)
<model>_SCALEUNIT_M METERS
<model>_SCALEUNIT_FT FEET
**Remarks**
This function can be used in State S3.
**See Also**
CapFocusScaleUnit, GetFocusScaleUnit


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.26. GetFocusScaleUnit
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the focus distance unit.
**Syntax**
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plScaleUnit
);
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetFocusScaleUnit
lAPIParam (IN) <model>_API_PARAM_ GetFocusScaleUnit
plScaleUnit (OUT)
<model>_SCALEUNIT_M METERS
<model>_SCALEUNIT_FT FEET
**Remarks**
This function can be used in State S3.
**See Also**
CapFocusScaleUnit, SetFocusScaleUnit


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.27. SetFilenamePrefix
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the EDIT FILE NAME setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetFilenamePrefix
lAPIParam (IN) <model>_API_PARAM_SetFilenamePrefix
lCategory (IN) Select a target color space.
<model>_ITEM_FILENAME_sRGB sRGB
<model>_ITEM_FILENAME_AdobeRGB AdobeRGB
pPrefix (IN) A prefix of either five bytes including NULL termination (four characters) for
sRGB or four bytes including NULL termination (three characters) for AdobeRGB.
**Remarks**
This function can be used in State S3.
**See Also**
GetFilenamePrefix
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lCategory,
LPSTR pPrefix
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.28. GetFilenamePrefix
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the EDIT FILE NAME setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetFilenamePrefix
lAPIParam (IN) <model>_API_PARAM_GetFilenamePrefix
lCategory (IN) See lCategory of “SetFilenamePrefix”.
pPrefix (OUT) See pPrefix of “SetFilenamePrefix”.
**Remarks**
This function can be used in State S3.
**See Also**
SetFilenamePrefix
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lCategory,
LPSTR pPrefix
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.29. CapLockButtonMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported AE/AF LOCK MODE settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapLockButtonMode
lAPIParam (IN) <model>_API_PARAM_CapLockButtonMode
plNum (OUT) Returns the number of “SetLockButtonMode” settings supported.
plLockMode (OUT) See lLockMode of “SetLockButtonMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetLockButtonMode
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plLockMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.30. SetLockButtonMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the AE/AF LOCK MODE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetLockButtonMode
lAPIParam (IN) <model>_API_PA R A M_SetLockButtonMode
lLockMode (IN)
<model>_LOCKBUTTON_MODE_PRESSING WHEN PRESSED
<model>_LOCKBUTTON_MODE_SWITCH TOGGLE
**Remarks**
This function can be used in State S3.
**See Also**
GetLockButtonMode
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lLockMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.31. GetLockButtonMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the AE/AF LOCK MODE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetLockButtonMode
lAPIParam (IN) <model>_API_PA R A M_GetLockButtonMode
plLockMode (OUT) See lLockMode of “SetLockButtonMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetLockButtonMode
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plLockMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.32. CapColorSpace
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported COLOR SPACE settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapColorSpace
lAPIParam (IN) <model>_API_PARAM_CapColorSpace
plNum (OUT) Returns the number of “SetColorSpace” settings supported.
plColorSpace (OUT) See lColorSpace of SetColorSpace.
**Remarks**
This function can be used in State S3.
**See Also**
SetColorSpace
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plColorSpace
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.33. SetColorSpace
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the COLOR SPACE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetColorSpace
lAPIParam (IN) <model>_API_PA R A M_SetColorSpace
lColorSpace (IN)
<model>_COLORSPACE_sRGB sRGB
<model>_COLORSPACE_AdobeRGB Adobe RGB
**Remarks**
This function can be used in State S3.
**See Also**
GetColorSpace
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lColorSpace
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.34. GetColorSpace
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the COLOR SPACE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetColorSpace
lAPIParam (IN) <model>_API_PA R A M_GetColorSpace
plColorSpace (OUT) See lColorSpace of SetColorSpace.
**Remarks**
This function can be used in State S3.
**See Also**
SetColorSpace
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plColorSpace
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.35. CapFunctionLock
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported LOCK SETTINGs.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapFunctionLock
lAPIParam (IN) <model>_API_PARAM_CapFunctionLock
plNum (OUT) Returns the number of “SetFunctionLock” settings supported.
plLock (OUT)
<model>_FUNCTIONLOCK_FREE UNLOCK
<model>_FUNCTIONLOCK_ALL LOCK ALL
<model>_FUNCTIONLOCK_CATEGORY^ SELECTED LOCK^
**Remarks**
This function can be used in State S3.
**See Also**
SetFunctionLock
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plLock
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.36. SetFunctionLock
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the LOCK SETTING.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetFunctionLock
lAPIParam (IN) <model>_API_PA R A M_SetFunctionLock
lLock (IN)
<model>_FUNCTIONLOCK_UNLOCK UNLOCK
<model>_FUNCTIONLOCK_ALL LOCK ALL
<model>_FUNCTIONLOCK_CATEGORY SELECTED LOCK
**Remarks**
This function can be used in State S3.
**See Also**
GetFunctionLock
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lLock
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.37. GetFunctionLock
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the LOCK SETTING.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetFunctionLock
lAPIParam (IN) <model>_API_PA R A M_GetFunctionLock
plLock (OUT) See lLock of “SetFunctionLock”.
**Remarks**
This function can be used in State S3.
**See Also**
SetFunctionLock
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plLock
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.38. CapFunctionLockCategory
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3  3 3 3
**Description**
Queries the supported FUNCTION SELECTIONS for SELECTED FUNCTION LOCK.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapFunctionLockCategory
lAPIParam (IN) <model>_API_PARAM_CapFunctionLockCategory
pulCategory1Num (OUT) Returns the number of SetFocusLockCategory1 settings supported
pulCategory2Num (OUT) Returns the number of SetFocusLockCategory2 settings supported
pulCategory3Num (OUT) Returns the number of SetFocusLockCategory3 settings supported
pulCategory1 (OUT) See ulCategory1 of “SetFunctionLockCategory”
pulCategory2 (OUT) See ulCategory2 of “SetFunctionLockCategory”
pulCategory 3 (OUT) See ulCategory 3 of “SetFunctionLockCategory”
**Remarks**
This function can be used in State S3.
**See Also**
SetFunctionLockCategory
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
unsigned long* pulCategory1Num,
unsigned long* pulCategory2Num,
unsigned long* pulCategory3Num,
unsigned long* pulCategory1,
unsigned long* pulCategory2,
unsigned long* pulCategory3
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.39. SetFunctionLockCategory
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the FUNCTION SELECTIONS for SELECTED FUNCTION LOCK.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetFunctionLockCategory
lAPIParam (IN) <model>_API_PA R A M_SetFunctionLockCategory
ulCategory1 (IN) **[** X-T3/X-T4/X-Pro3/X-S10/GFX50S/GFX50R/GFX100/GFX100S/GFX50SII/
GFX100II/GFX100SII **]**
To specfy functions to enable/disable in bitmap fields.
<model>_FUNCTIONLOCK_CATEGORY1_FOCUSMODE FOCUS MODE
<model>_FUNCTIONLOCK_CATEGORY1_APERTURE APERTURE
<model>_FUNCTIONLOCK_CATEGORY1_SHUTTERSPEED SHUTTER SPEED
[X-T3/X-T4/X-Pro3/X-S10/GFX50S/GFX50R/GFX100/GFX100S/GFX50S II]
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
unsigned long ulCategory1,
unsigned long ulCategory2,
unsigned long ulCategory 3
);
[Other models]
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
unsigned long ulCategory1,
unsigned long ulCategory2
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_FUNCTIONLOCK_CATEGORY1_ISO ISO
<model>_FUNCTIONLOCK_CATEGORY1_EXPOSUREBIAS EXP. COMPENSATION
<model>_FUNCTIONLOCK_CATEGORY1_DRV DRIVE BUTTON
<model>_FUNCTIONLOCK_CATEGORY1_AEMODE METERING MODE
<model>_FUNCTIONLOCK_CATEGORY1_QBUTTON Q BUTTON
<model>_FUNCTIONLOCK_CATEGORY1_ISSWITCH OIS SWITCH
<model>_FUNCTIONLOCK_CATEGORY1_PROGRAMSHIFT PROGRAM SHIFT
<model>_FUNCTIONLOCK_CATEGORY1_VIEWMODE VIEW MODE BUTTON
<model>_FUNCTIONLOCK_CATEGORY1_DISPBACK DISP
<model>_FUNCTIONLOCK_CATEGORY1_AELOCK AE-L BUTTON
<model>_FUNCTIONLOCK_CATEGORY1_AFLOCK AF-L BUTTON
<model>_FUNCTIONLOCK_CATEGORY1_FOCUSASSIST MF ASSIST
<model>_FUNCTIONLOCK_CATEGORY1_MOVIEREC MOVIE RECORDING BUTTON
<model>_FUNCTIONLOCK_CATEGORY1_UP SELECTOR UP(F6)BUTTON
<model>_FUNCTIONLOCK_CATEGORY1_RIGHT SELECTOR RIGHT(F7)
<model>_FUNCTIONLOCK_CATEGORY1_LEFT SELECTOR LEFT(F8)BUTTON
<model>_FUNCTIONLOCK_CATEGORY1_DOWN SELECTOR DOWN(F9)BUTTON
<model>_FUNCTIONLOCK_CATEGORY1_FN1 Fn1 BUTTON
<model>_FUNCTIONLOCK_CATEGORY1_FN2 Fn2 BUTTON
<model>_FUNCTIONLOCK_CATEGORY1_AFMODE AF MODE
<model>_FUNCTIONLOCK_CATEGORY1_FACEDETECT FACE/EYE DETECTIN SETTING
<model>_FUNCTIONLOCK_CATEGORY1_SHOOTINGMENU OTHER SHOOTING MENU
<model>_FUNCTIONLOCK_CATEGORY1_MEDIAFORMAT FORMAT
<model>_FUNCTIONLOCK_CATEGORY1_ERASE ERASE
<model>_FUNCTIONLOCK_CATEGORY1_DATETIME AREA/DATE/TIME/TIME
DIFFERENCE
<model>_FUNCTIONLOCK_CATEGORY1_RESET RESET
<model>_FUNCTIONLOCK_CATEGORY1_SILENTMODE SILENTMODE
<model>_FUNCTIONLOCK_CATEGORY1_SOUND SOUND
**[Other models]**
Please refer to the Note for details.
The supported functions vary with the camera models.
ulCategory2 (IN) **[** X-T3/X-T4/X-Pro3/X-S10/GFX50S/GFX50R/GFX100/GFX100S/GFX50SII /
GFX100II/GFX100SII **]
To specfy functions to enable/disable in bitmap fields.**
<model>_FUNCTIONLOCK_CATEGORY2_SCREENDISP SCREEN SET-UP
<model>_FUNCTIONLOCK_CATEGORY2_COLORSPACE COLOR SPACE
<model>_FUNCTIONLOCK_CATEGORY2_SETUP OTHER SETUP MENU


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_FUNCTIONLOCK_CATEGORY2_OTHERSETUP OTHER SETUP MENU
<model>_FUNCTIONLOCK_CATEGORY2_WHITEBALANCE WHITE BALANCE
<model>_FUNCTIONLOCK_CATEGORY2_FILMSIMULATIO
N
FILM SIMULATION
<model>_FUNCTIONLOCK_CATEGORY2_FOCUSSTICK FOCUS STICK
<model>_FUNCTIONLOCK_CATEGORY2_FOCUSRANGESEL
ECTOR
Focus Range Selector
<model>_FUNCTIONLOCK_CATEGORY2_FN3 Fn3 BUTTON
<model>_FUNCTIONLOCK_CATEGORY2_FN4 Fn4 BUTTON
<model>_FUNCTIONLOCK_CATEGORY2_FN5 Fn5 BUTTON
<model>_FUNCTIONLOCK_CATEGORY2_FN10 Fn10 BUTTON
<model>_FUNCTIONLOCK_CATEGORY2_RDIAL R-DIAL
<model>_FUNCTIONLOCK_CATEGORY2_AFON AF-ON
<model>_FUNCTIONLOCK_CATEGORY2_TOUCHMODE TOUCH SCREEN MODE
<model>_FUNCTIONLOCK_CATEGORY2_TFN1 T-Fn1
<model>_FUNCTIONLOCK_CATEGORY2_TFN2 T-Fn2
<model>_FUNCTIONLOCK_CATEGORY2_TFN3 T-Fn3
<model>_FUNCTIONLOCK_CATEGORY2_TFN4 T-Fn4
<model>_FUNCTIONLOCK_CATEGORY2_SUBDISP SUB MONITOR MODE BUTTON
<model>_FUNCTIONLOCK_CATEGORY2_AELOCK_V Vertical grip AE-L button
<model>_FUNCTIONLOCK_CATEGORY2_AFON_V Vertical grip AF-ON button
<model>_FUNCTIONLOCK_CATEGORY2_FN1_V Vertical grip Fn1 button
<model>_FUNCTIONLOCK_CATEGORY2_FN2_V Vertical grip Fn2 button
<model>_FUNCTIONLOCK_CATEGORY2_FN3_V Vertical grip Fn3 button
<model>_FUNCTIONLOCK_CATEGORY2_FN4_V Vertical grip Fn4 button
<model>_FUNCTIONLOCK_CATEGORY2_RDIAL_V VERTICAL GRIP CENTER OF
R-DIAL
<model>_FUNCTIONLOCK_CATEGORY2_LEVER VIEWFINDER SELECTOR
<model>_FUNCTIONLOCK_CATEGORY2_IMAGESWITCHIN
GLEVER
STILL/MOVIE MODE DIAL
<model>_FUNCTIONLOCK_CATEGORY2_MODEDIAL MODE DIAL
<model>_FUNCTIONLOCK_CATEGORY2_FDIAL F-DIAL
<model>_FUNCTIONLOCK_CATEGORY2_FN_DIAL Fn-DIAL
<model>_FUNCTIONLOCK_CATEGORY2_SUBDISP_LIGHT SUB MONITOR BACKLIGHT
BUTTON
**[Other models]**
Please refer to the Note for details.
The supported functions vary with the camera models.
ulCategory 3 (IN) [X-S10/GFX100II/GFX100SII]


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
To specfy functions to enable/disable in bitmap fields.
<model>_FUNCTIONLOCK_CATEGORY3_ISOBUTTON ISO BUTTON
<model>_FUNCTIONLOCK_CATEGORY3_MOVIE_FOCUSM
ODE
(MOVIE)FOCUS MODE
<model>_FUNCTIONLOCK_CATEGORY3_MOVIE_AFMODE MOVIE AF MODE
<model>_FUNCTIONLOCK_CATEGORY3_OTHER_MOVIEM
ENU
OTHER MOVIE SETTING MENU
<model>_FUNCTIONLOCK_CATEGORY3_EXPOSUREMODE SHOOTING MODE
<model>_FUNCTIONLOCK_CATEGORY3_WBBUTTON WB BUTTON
<model>_FUNCTIONLOCK_CATEGORY3_BLUETOOTHPAIR
ING
Bluetooth PAIRING
<model>_FUNCTIONLOCK_CATEGORY3_BLUETOOTH Bluetooth ON/OFF
<model>_FUNCTIONLOCK_CATEGORY3_SUBJECTDETECT SUBJECT DETECT SETTING
<model>_FUNCTIONLOCK_CATEGORY3_OTHERCONNECTI
ONSETTING
OTHER NETWORK/USB SETTING
MENU
<model>_FUNCTIONLOCK_CATEGORY3_FM1 Z/F BUTTON
<model>_FUNCTIONLOCK_CATEGORY3_FM2 L-Fn1 BUTTON
<model>_FUNCTIONLOCK_CATEGORY3_FM3 L-Fn2 BUTTON
<model>_FUNCTIONLOCK_CATEGORY3_COMMUNICATIO
NSETSELECTION
SELECT CONNECTION SETTING
<model>_FUNCTIONLOCK_CATEGORY3_INFORMATIONDI
SP
INFORMATION
<model>_FUNCTIONLOCK_CATEGORY3_FN6 Fn6 BUTTON
[Other models]
Please refer to the Note for details.
The supported functions vary with the camera models.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**Note**
Supported functions **[** X-T3/X-T4/X-Pro3/X-S10/GFX50S/GFX50R/GFX100/GFX100S/GFX50SII **]
Item
X-
T3
X-
T4
X-
Pro3
X-
S10
GFX50S
GFX50R
GFX100
GFX100S
GFX50SII**
<model>_FUNCTIONLOCK_CATEGORY1_FOCUSMODE 3 3 3 3 3 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY1_APERTURE^3^^3^^3^^3^^3^^3^^3^^3^^3^
<model>_FUNCTIONLOCK_CATEGORY1_SHUTTERSPEED 3 3 3 3 3 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY1_ISO 3 3 3 3 3 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY1_EXPOSUREBIAS^3^^3^^3^^3^^3^^3^^3^^3^^3^
<model>_FUNCTIONLOCK_CATEGORY1_DRV 3 3 3 3 3 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY1_AEMODE 3 3 3 3 3 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY1_QBUTTON^3^^3^^3^^3^^3^^3^^3^^3^^3^
<model>_FUNCTIONLOCK_CATEGORY1_ISSWITCH^3^^3^^3^^3^^3^^3^^3^^3^^3^
<model>_FUNCTIONLOCK_CATEGORY1_PROGRAMSHIFT 3 3 3 3 3 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY1_VIEWMODE 3 3 3 3 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY1_DISPBACK^3^^3^^3^^3^^3^^3^^3^^3^^3^
<model>_FUNCTIONLOCK_CATEGORY1_AELOCK 3 3 3 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY1_AFLOCK 3 3
<model>_FUNCTIONLOCK_CATEGORY1_FOCUSASSIST^3^^3^^3^^3^^3^^3^^3^^3^
<model>_FUNCTIONLOCK_CATEGORY1_MOVIEREC 3
<model>_FUNCTIONLOCK_CATEGORY1_UP 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY1_RIGHT 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY1_LEFT^3^^3^^3^^3^
<model>_FUNCTIONLOCK_CATEGORY1_DOWN 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY1_FN1 3 3 3 3 3 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY1_FN2^3^^3^^3^^3^^3^^3^^3^^3^
<model>_FUNCTIONLOCK_CATEGORY1_AFMODE 3 3 3 3 3 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY1_FACEDETECT 3 3 3 3 3 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY1_SHOOTINGMENU^3^^3^^3^^3^^3^^3^^3^^3^^3^
<model>_FUNCTIONLOCK_CATEGORY1_MEDIAFORMAT 3 3 3 3 3 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY1_ERASE 3 3 3 3 3 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY1_DATETIME 3 3 3 3 3 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY1_RESET^3^^3^^3^^3^^3^^3^^3^^3^^3^
<model>_FUNCTIONLOCK_CATEGORY1_SILENTMODE
<model>_FUNCTIONLOCK_CATEGORY1_SOUND 3 3 3 3 3 3 3 3 3


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**Item
X-
T3
X-
T4
X-
Pro3
X-
S10
GFX50S
GFX50R
GFX100
GFX100S
GFX50SII**
<model>_FUNCTIONLOCK_CATEGORY2_SCREENDISP 3 3 3 3 3 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY2_COLORSPACE 3 3 3 3 3 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY2_SETUP^3^^3^^3^^3^^3^^3^^3^^3^^3^
<model>_FUNCTIONLOCK_CATEGORY2_OTHERSETUP 3 3 3 3 3 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY2_WHITEBALANCE 3 3 3 3 3 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY2_FILMSIMULATION^3^^3^^3^^3^^3^^3^^3^^3^^3^
<model>_FUNCTIONLOCK_CATEGORY2_FOCUSSTICK 3 3 3 3 3 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY2_FOCUSRANGESELECTOR 3 3 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY2_FN3^3^^3^^3^^3^^3^^3^
<model>_FUNCTIONLOCK_CATEGORY2_FN4 3 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY2_FN5 3 3 3
<model>_FUNCTIONLOCK_CATEGORY2_FN10 3 3 3
<model>_FUNCTIONLOCK_CATEGORY2_RDIAL^3^^3^^3^^3^^3^^3^
<model>_FUNCTIONLOCK_CATEGORY2_AFON 3 3 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY2_TOUCHMODE 3 3 3 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY2_TFN1^3^^3^^3^^3^^3^^3^^3^
<model>_FUNCTIONLOCK_CATEGORY2_TFN2 3 3 3 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY2_TFN3 3 3 3 3 3 3 3
<model>_FUNCTIONLOCK_CATEGORY2_TFN4^3^^3^^3^^3^^3^^3^^3^
<model>_FUNCTIONLOCK_CATEGORY2_SUBDISP 3 3 3
<model>_FUNCTIONLOCK_CATEGORY2_AELOCK_V 3
<model>_FUNCTIONLOCK_CATEGORY2_AFON_V 3
<model>_FUNCTIONLOCK_CATEGORY2_FN1_V^3^
<model>_FUNCTIONLOCK_CATEGORY2_FN2_V 3
<model>_FUNCTIONLOCK_CATEGORY2_FN3_V 3
<model>_FUNCTIONLOCK_CATEGORY2_FN4_V^3^
<model>_FUNCTIONLOCK_CATEGORY2_RDIAL_V 3
<model>_FUNCTIONLOCK_CATEGORY2_LEVER 3
<model>_FUNCTIONLOCK_CATEGORY2_IMAGESWITCHINGLEVER^3^^3^^3^
<model>_FUNCTIONLOCK_CATEGORY2_MODEDIAL^3^^3^^3^
<model>_FUNCTIONLOCK_CATEGORY2_FDIAL 3 3 3
<model>_FUNCTIONLOCK_CATEGORY2_FN_DIAL 3
<model>_FUNCTIONLOCK_CATEGORY2_SUBDISP_LIGHT^3^^3^


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**Item
X-
T3
X-
T4
X-
Pro3
X-
S10
GFX50S
GFX50R
GFX100
GFX100S
GFX50SII**
<model>_FUNCTIONLOCK_CATEGORY3_ISOBUTTON 3
<model>_FUNCTIONLOCK_CATEGORY3_MOVIE_FOCUSMODE 3
<model>_FUNCTIONLOCK_CATEGORY3_MOVIE_AFMODE^3^
<model>_FUNCTIONLOCK_CATEGORY3_OTHER_MOVIEMENU 3
<model>_FUNCTIONLOCK_CATEGORY3_EXPOSUREMODE 3
<model>_FUNCTIONLOCK_CATEGORY3_WBBUTTON
<model>_FUNCTIONLOCK_CATEGORY3_BLUETOOTHPAIRING
<model>_FUNCTIONLOCK_CATEGORY3_BLUETOOTH
<model>_FUNCTIONLOCK_CATEGORY3_SUBJECTDETECT
<model>_FUNCTIONLOCK_CATEGORY3_OTHERCONNECTIONSETTING
<model>_FUNCTIONLOCK_CATEGORY3_FM1
<model>_FUNCTIONLOCK_CATEGORY3_FM2
<model>_FUNCTIONLOCK_CATEGORY3_FM3
<model>_FUNCTIONLOCK_CATEGORY3_COMMUNICATIONSETSELECTIO
N
<model>_FUNCTIONLOCK_CATEGORY3_INFORMATIONDISP
<model>_FUNCTIONLOCK_CATEGORY3_FN6
**Remarks**
This function can be used in State S3.
**See Also**
GetFunctionLockCategory


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.40. GetFunctionLockCategory
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the FUNCTION SELECTIONS for SELECTED FUNCTION LOCK.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetFunctionLockCategory
lAPIParam (IN) <model>_API_PA R A M_GetFunctionLockCategory
pulCategory1 (OUT) See pulCategory1 of “SetFunctionLockCategory”
pulCategory2 (OUT) See pulCategory2 of “SetFunctionLockCategory”
pulCategory 3 (OUT) See pulCategory 3 of “SetFunctionLockCategory”
[X-S10/X-H2S]
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
unsigned long* pulCategory1,
unsigned long* pulCategory2,
unsigned long* pulCategory 3
);
[Other models]
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
unsigned long* pulCategory1,
unsigned long* pulCategory2
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**Remarks**
This function can be used in State S3.
**See Also**
SetFunctionLockCategory


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.41. CapFormatMemoryCard
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported memory card slots.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapFormatMemoryCard
lAPIParam (IN) <model>_API_PARAM_CapFormatMemoryCard
plNum (OUT) Returns the number of “FormatMemoryCard” settings supported.
plCategory (OUT)
<model>_ITEM_MEDIASLOT1 The card in the media slot 1
<model>_ITEM_MEDIASLOT2 The card in the media slot 2
<model>_ITEM_MEDIASLOT3 [GFX100II/GFX100SII]
External storage (SSD)^
**Remarks**
This function is available in PC PRIORITY MODE only.
This function can be used in State S3.
**See Also**
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plCategory
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.42. FormatMemoryCard
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Executes the FORMAT procedure.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_FormatMemoryCard
lAPIParam (IN) <model>_API_PA R A M_FormatMemoryCard
lCategory (IN) Select the FORMAT target slot.
<model>_ITEM_MEDIASLOT1 The card in the media slot 1
<model>_ITEM_MEDIASLOT2 The card in the media slot 2
<model>_ITEM_MEDIASLOT3 [GFX100II/GFX100SII]
External storage (SSD)^
**Remarks**
This function is available in PC PRIORITY MODE only.
This function can be used in State S3.
**See Also**
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lCategory
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.43. CapCustomDispInfo
Supported Cameras
X-
T1
X-
T2
X-
T3
X-
T4
X-
T 5
X-
Pro2
X-
Pro3
X-
S10
X-
H2S
X-
H2
X-
S20
X-
M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
^3^^3^^3^^3^^3^ ^3^^3^^3^
**Description**
Queries the supported DISP. CUSTOM SETTINGs.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapCustomDispInfo
lAPIParam (IN) <model>_API_PARAM_CapCustomDispInfo
plNum1 (OUT) Returns the number of SetCustomDispInfo Setting 1 settings supported
plNum2 (OUT) Returns the number of SetCustomDispInfo Setting 2 settings supported
pSetting1 (OUT) See setting1 of “SetCustomDispInfo”
pSetting 2 (OUT) See setting 2 of “SetCustomDispInfo”
**Remarks**
This function can be used in State S3.
**See Also**
SetCustomDispInfo
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum1,
long* plNum2,
unsigned long* pSetting1,
unsigned long* pSetting 2 ,
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.44. SetCustomDispInfo
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the DISP. CUSTOM SETTING.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetCustomDispInfo
lAPIParam (IN) <model>_API_PA R A M_SetCustomDispInfo
setting1 (IN) To specfy items to enable/disable in bitmap fields.
<model>_CUSTOMDISPINFO_FRAMEGUIDE FRAME GUIDE
<model>_CUSTOMDISPINFO_ELECTRONLEVEL ELECTRON LEVEL
<model>_CUSTOMDISPINFO_AFDISTANCE AF DISTANCE
<model>_CUSTOMDISPINFO_MFDISTANCE MF DISTANCE
<model>_CUSTOMDISPINFO_HISTOGRAM HISTOGRAM
<model>_CUSTOMDISPINFO_EXPOSUREPARAM EXPOSURE PA R AM
<model>_CUSTOMDISPINFO_EXPOSUREBIAS EXPOSURE BIAS
<model>_CUSTOMDISPINFO_PHOTOMETRY PHOTOMETRY
<model>_CUSTOMDISPINFO_FLASH FLASH
<model>_CUSTOMDISPINFO_WB WB
<model>_CUSTOMDISPINFO_FILMSIMULATION FILM SIMULATION
<model>_CUSTOMDISPINFO_DRANGE D RANGE
<model>_CUSTOMDISPINFO_FRAMESREMAIN FRAMES REMAIN
<model>_CUSTOMDISPINFO_IMAGESIZEQUALITY IMAGESIZE QUALITY
<model>_CUSTOMDISPINFO_BATTERY BATTERY
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
unsigned long setting1,
unsigned long setting 2
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_CUSTOMDISPINFO_FOCUSFRAME FOCUS FRAME
<model>_CUSTOMDISPINFO_SHOOTINGMODE SHOOTING MODE
<model>_CUSTOMDISPINFO_INFORMATIONBACKGROUND INFORMATION
BACKGROUND
<model>_CUSTOMDISPINFO_FOCUSMODE FOCUS MODE
<model>_CUSTOMDISPINFO_SHUTTERTYPE SHUTTER TYPE
<model>_CUSTOMDISPINFO_CONTINUOUSMODE CONTINUOUS MODE
<model>_CUSTOMDISPINFO_DUALISMODE DUAL IS MODE
<model>_CUSTOMDISPINFO_MOVIEMODE MOVIE MODE
<model>_CUSTOMDISPINFO_BLURWARNING BLUR WA R N I N G
<model>_CUSTOMDISPINFO_LIVEVIEWHIGHT LIVE VIEW HIGHT
<model>_CUSTOMDISPINFO_EXPOSUREBIASDIGIT EXPOSURE BIAS DIGIT
The supported items vary with the camera models.
setting 2 (IN) To specfy items to enable/disable in bitmap fields.
<model>_CUSTOMDISPINFO_35MMFORMAT 35MM FORMAT
<model>_CUSTOMDISPINFO_COOLINGFANSETTING COOLING FAN
SETTING
<model>_CUSTOMDISPINFO_DIGITALTELECONV DIGITAL TELECONV
<model>_CUSTOMDISPINFO_DIGITALZOOM DIGITAL ZOOM
<model>_CUSTOMDISPINFO_FOCUSINDICATOR FOCUS INDICATOR
<model>_CUSTOMDISPINFO_NOCARDWARNING NO CARD WA R N I N G
<model>_CUSTOMDISPINFO_DATETIME DATE TIME
<model>_CUSTOMDISPINFO_LENSSHIFT LENS SHIFT
<model>_CUSTOMDISPINFO_LENSTILT LENS TILT
<model>_CUSTOMDISPINFO_LENSREVOLVING LENS REVOLVING
<model>_CUSTOMDISPINFO_SSD SSD
The supported items vary with the camera models.
**Remarks**
This function can be used in State S3.
**See Also**
GetCustomDispInfo


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.45. GetCustomDispInfo
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the DISP. CUSTOM SETTING.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetCustomDispInfo
lAPIParam (IN) <model>_API_PA R A M_GetCustomDispInfo
pSetting1 (OUT) See pSetting1 of “SetCustomDispInfo”
pSetting 2 (OUT) See pSetting 2 of “SetCustomDispInfo”
**Remarks**
This function can be used in State S3.
**See Also**
SetCustomDispInfo
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
unsigned long* pSetting1,
unsigned long* pSetting 2
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.46. GetTransparentFrameInfo
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3
**Description**
Gets the Transparent frame information.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetTransparentFrameInfo
lAPIParam (IN) <model>_API_PARAM_ GetTransparentFrameInfo
pFrameInfo (OUT) ointer to a structure (SDK_TransparentFrameInfo) table.
typedef struct {
long lX;
long lY;
long lLength_H;
long lLength_V;
long lAlpha;
} SDK_TrackingAfFrameInfo;
lX:
Frame origin position in percent (100%=1024)
lY:
Frame origin position in percent (100%=1024)
lLength_H:
Horizontal line length in percent (100%=1024)
lLength_V:
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
SDK_TransparentFrameInfo* pFrameInfo
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
Vertical line length in percent (100%=1024)
lAlpha:
Transparency, 0～100(%)
**Remarks**
This function can be used in State S3.
**See Also**
None


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.47. CapMaskSetting
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
 3
**Description**
Queries the supported SURROUND VIEW settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMaskSetting
lAPIParam (IN) <model>_API_PARAM_CapMaskSetting
plNum (OUT) Returns the number of SetMaskSetting Setting settings supported
pSetting (OUT) See lSetting of “SetMaskSetting”
**Remarks**
This function can be used in State S3.
**See Also**
SetMaskSetting, GetMaskSetting
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting,
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.48. SetMaskSetting
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3
**Description**
Sets the SURROUND VIEW setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMaskSetting
lAPIParam (IN) <model>_API_PA R A M_SetMaskSetting
lSetting (IN)
<model>_ MASKSETTING_BLACK BLACK
<model>_ MASKSETTING_TRANSPARENT SEMI-TRANSPARENT
<model>_^ MASKSETTING_^ BRIGHTFRAME^ LINE^
**Remarks**
This function can be used in State S3.
**See Also**
CapMaskSetting, GetMaskSetting
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.10.49. GetMaskSetting
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3
**Description**
Gets the SURROUND VIEW setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMaskSetting
lAPIParam (IN) <model>_API_PA R A M_GetMaskSetting
pSetting (OUT) See lSetting of “SetMaskSetting”
**Remarks**
This function can be used in State S3.
**See Also**
CapMaskSetting, SetMaskSetting
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting,
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.11. Image Stabilization
4.2.11.1. CapLensISSwitch
Supported Cameras
X-
T1
X-
T2
X-
T3
X-
T4
X-
T 5
X-
Pro2
X-
Pro3
X-
S10
X-
H2S
X-
H2
X-
S20
X-
M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 (^)
**Description**
Queries the available lens IS switch settings to set.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapLensISSwitch
lAPIParam (IN) <model>_API_PA R A M_CapLensISSwitch
plNumLensISSwitch (OUT) Returns the number supported SetLensISSwitch setting.
plLensISSwitch (OUT) If not NULL, plLensISSwitch will return a list of the SetLensISSwitch
supported.
Allocate sizeof(long) * (*plNumLensISSwitch) bytes of space before calling this
function.
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
SetLensISSwitch, GetLensISSwitch
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNumLensISSwitch,
long* plLensISSwitch
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.11.2. SetLensISSwitch
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the lens IS switch mode.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetLensISSwitch
lAPIParam (IN) <model>_API_PA R A M_SetLensISSwitch
lISSwitch (IN)
<model>_ON ON
<model>_OFF OFF
**Remarks**
This function can be used in State S3. PC priority mode only.
**See Also**
CapLensISSwitch, GetLensISSwitch
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lISSwitch
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.11.3. GetLensISSwitch
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the lens IS switch mode.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetLensISSwitch
lAPIParam (IN) <model>_API_PA R A M_GetLensISSwitch
plISSwitch (OUT)
<model>_ON ON
<model>_OFF OFF
**Remarks**
This function can be used in State S3.
**See Also**
CapLensISSwitch, SetLensISSwitch
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plISSwitch
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.11.4. CapISMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported lens IS MODE settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapISMode
lAPIParam (IN) <model>_API_PARAM_CapISMode
plNum (OUT) Returns the number of “SetISMode” settings supported.
plISMode (OUT) <model>_IS_MODE_CONTINUOUS 0x0001 Continuous
<model>_IS_MODE_SHOOT 0x0002 Shoot
<model>_IS_MODE_OFF 0x0003 OFF
**Remarks**
This function can be used in State S3.
**See Also**
SetISMode
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plISMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.11.5. SetISMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the IS MODE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetISMode
lAPIParam (IN) <model>_API_PA R A M_SetISMode
lISMode (IN)
<model>_IS_MODE_CONTINUOUS 0x0001 Continuous
<model>_IS_MODE_SHOOT 0x0002 Shoot
<model>_IS_MODE_OFF 0x0003 OFF
**Remarks**
This function can be used in State S3.
**See Also**
GetISMode
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lISMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.11.6. GetISMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the IS MODE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetISMode
lAPIParam (IN) <model>_API_PA R A M_GetISMode
plISMode (OUT) See lISMode of “SetISMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetISMode
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plISMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.12. Save Image Meta-tag Information
4.2.12.1. SetComment
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the comment tag strings to be saved in images.
Once set, the tag will be saved with all pictures taken, whether or not they are taken in tethering mode.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetComment
lAPIParam (IN) <model>_API_PARAM_SetComment
pComment (IN) The comment in ASCII string.
Up to 256 byte including NULL termination.
**Remarks**
This function can be used in State S3.
**See Also**
GetComment
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
LPSTR pComment
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.12.2. GetComment
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the comment tag strings to be saved in images.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetComment
lAPIParam (IN) <model>_API_PARAM_GetComment
pComment (OUT) The comment in ASCII string
Allocate at least 256 bytes before calling this function.
**Remarks**
This function can be used in State S3.
**See Also**
SetComment
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
LPSTR pComment
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.12.3. SetCopyright
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX
50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the copyright tag strings to be saved in images.
Once set, the tag will be saved with all pictures taken, whether or not they are taken in tethering mode.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetCopyright
lAPIParam (IN) <model>_API_PARAM_SetCopyright
pCopyright1 (IN) An ASCII string of up to 256 bytes, including NULL termination.
pCopyright2 (IN) An ASCII string of up to 256 bytes, including NULL termination.
**Remarks**
This function can be used in State S3.
**See Also**
GetCopyright
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
LPSTR pCopyright1,
LPSTR pCopyright2
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.12.4. GetCopyright
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the copyright tag strings to be saved in images.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetCopyright
lAPIParam (IN) <model>_API_PARAM_GetCopyright
pCopyright1 (OUT) Returns the first copyright string.
Allocate a total of at least 512 bytes before calling this function.
pCopyright2 (OUT) Returns the second copyright string.
Allocate a total of at least 512 bytes before calling this function.
**Remarks**
This function can be used in State S3.
**See Also**
SetCopyright
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
LPSTR pCopyright1,
LPSTR pCopyright2
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.13. Camera Information
4.2.13.1. CheckBatteryInfo
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the battery state.
**Syntax
[GFX 100/GFX100S/X-H2S/ X-H2/X-T5/X-S20/GFX100II/GFX100SII]
[Other models]**
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plBodyBatteryInfo,
long* plGripBatteryInfo,
long* plGripBattery 2 Info,
long* plBodyBatteryRatio,
long* plGripBatteryRatio,
long* plGripBattery2Ratio,
long* plBodyBattery2Info,
long* plBodyBattery2Info
);
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plBodyBatteryInfo,
long* plGripBatteryInfo,
long* plGripBattery 2 Info,
long* plBodyBatteryRatio,
long* plGripBatteryRatio,
long* plGripBattery2Ratio,
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
“CheckBatteryInfo” uses XSDK_GetProp().
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CheckBatteryInfo
lAPIParam (IN) <model>_API_PA R A M_CheckBatteryInfo
plBodyBatteryInfo
plBodyBattery2Info
plGripBatteryInfo
plGripBattery2Info
(OUT) Get the level of the battery in the body.
<model>_POWERCAPACITY_EMPTY (^)
<model>_POWERCAPACITY_END (^)
<model>_POWERCAPACITY_PREEND5 Less than 1/5th full in RED
<model>_POWERCAPACITY_20 1/5th full (20%)
<model>_POWERCAPACITY_40 2 /5th full (40%)
<model>_POWERCAPACITY_60 3 /5th full (60%)
<model>_POWERCAPACITY_80 4 /5th full (80%)
<model>_POWERCAPACITY_100 5 /5th full (100%)
<model>_POWERCAPACITY_DC (^)
<model>_POWERCAPACITY_DC_CHARGE Charging
plBodyBatteryRatio
plBodyBattery2Ratio
pGripBatteryRatio
pGripBattery2Ratio
(OUT) Returns the state of the corresponding battery in the camera or camera grip.as
a value between 0 and 100.
**Remarks**
This function can be used in State S3.
**See Also**


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.13.2. GetShutterCount
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the shutter counter.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetShutterCount
lAPIParam (IN) <model>_API_PA R A M_GetShutterCount
plShutterCount (OUT) Returns the count for the current shutter.
plTotalShutterCount (OUT) Returns the count for the all shutters.
plExchangeCount (OUT) Returns the number of shutter units to be exchanged in repair center.
**Remarks**
This function can be used in State S3.
**See Also**
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plShutterCount,
long* plTotalShutterCount,
long* plExchangeCount
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.13.3. GetShutterCountEx
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the count for the front-curtain shutter.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetShutterCountEx
lAPIParam (IN) <model>_API_PA R A M_GetShutterCountEx
plShutterCount (OUT) Returns the front-curtain count for the current shutter.
plTotalShutterCount (OUT) Returns the count for the all shutters.
plExchangeCount (OUT) Returns the number of shutter units to be exchanged in repair center.
**Remarks**
This function can be used in State S3.
**See Also**
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plShutterCount,
long* plTotalShutterCount,
long* plExchangeCount
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.13.4. GetTiltShiftLensStatus
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3
**Description**
Gets tilt/shift lens status from the camera.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetTiltShiftLensStatus
lAPIParam (IN) <model>_API_PARAM_GetTiltShiftLensStatus
plTilt (OUT) Ten times value of the tilt amount in degree. 0 xFFFFFF shows undetectable
lens.
plShift (OUT) Ten times value of the shift amount in mm. 0 xFFFFFF shows undetectable lens.
plRotate (OUT) Ten times value of the rotate amount in degree. 0 xFFFFFF shows undetectable
lens.
**Note**
plShift :
The shift amount of tilt/shift lenses. It describes the 10 times value of the shift amount in mm.
For example, when the shift amount is 10.5 mm, the value 105 is recorded.
The value is from -32767 to 32768 (from -3276.8mm to 3276.7mm).
When the lens is rotated 90 degree CW (*plRotate=900) looking from the photographer, the right direction looking
from the photographer will be the positive direction.
plRotate:
The rotation angle of tilt/shift lenses. It describes the 10 times value of the rotation angle in degree. The positive
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plTilt,
long* plShift,
long* plRotate
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
direction is CW looking from the photographer.
For example, when the lens is rotated 22.5 degree CCW looking from the photographer, the value will be - 225.
The value is from -3599 to 3599 (from -359.9 degree to 359.9 degree).
**Remarks**
This function can be used in State S3.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.14. Media Control
4.2.14.1. GetMediaCapacity
Supported Cameras
X-
T1
X-
T2
X-
T3
X-
T4
X-
T 5
X-
Pro2
X-
Pro3
X-
S10
X-
H2S
X-
H2
X-
S20
X-
M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets recording media capacity.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMediaCapacity
lAPIParam (IN) <model>_API_PA R A M_GetMediaCapacity
lCategory (IN) Select the target storage media slot.
<model>_ITEM_MEDIASLOT1 The storage card in the media slot 1
<model>_ITEM_MEDIASLOT 2 The storage card in the media slot 2
<model>_ITEM_MEDIASLOT3 [GFX100II/GFX100SII]
External storage (SSD)^
plBlankFrameNum (OUT) Number of blank frames
plRemainSectorNum (OUT) Number of remaining sectors
plSectorSize (OUT) Sector size
plCardSize (OUT) Card capacity
<model>_MEDIASIZE_1M 1 MB
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lCategory,
long* plBlankFrameNum,
long* plRemainSectorNum,
long* plSectorSize,
long* plCardSize
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_MEDIASIZE_2M 2 MB
<model>_MEDIASIZE_4M 4 MB
<model>_MEDIASIZE_8M 8 MB
<model>_MEDIASIZE_16M 16 MB
<model>_MEDIASIZE_32M 32 MB
<model>_MEDIASIZE_64M 64 MB
<model>_MEDIASIZE_128M 128 MB
<model>_MEDIASIZE_256M 256 MB
<model>_MEDIASIZE_512M 512 MB
<model>_MEDIASIZE_1G 1 GB
<model>_MEDIASIZE_2G 2 GB
<model>_MEDIASIZE_4G 4 GB
<model>_MEDIASIZE_8G 8 GB
<model>_MEDIASIZE_16G 16 GB
<model>_MEDIASIZE_32G 32 GB
<model>_MEDIASIZE_32G_OVER^64 GB^ or more^
**Remarks**
This function can be used in State S3.
**See Also**


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.14.2. GetMediaStatus
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets recording media status.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMediaStatus
lAPIParam (IN) <model>_API_PA R A M_GetMediaStatus
lCategory (IN) Select the target storage media slot.
<model>_ITEM_MEDIASLOT1 The storage card in the media slot 1
<model>_ITEM_MEDIASLOT 2 The storage card in the media slot 2
<model>_ITEM_MEDIASLOT3 [GFX100II/GFX100SII]
External storage (SSD)
<model>_ITEM_HDMIOUTPUT [X-H2/X-T5/X-S20/GFX100II/GFX100SII]
HDMI output^
plStatus (OUT)
<model>_MEDIASTATUS_OK OK
<model>_MEDIASTATUS_WRITEPROTECTED Write protected
<model>_MEDIASTATUS_NOCARD No card
<model>_MEDIASTATUS_UNFORMATTED Unformatted
<model>_MEDIASTATUS_ERROR Some error on the media
<model>_MEDIASTATUS_MAXNO Frame number goes to 9999
<model>_MEDIASTATUS_FULL Card full
<model>_MEDIASTATUS_ACCESSING Accessing
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lCategory
long* plStatus
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_MEDIASTATUS_INCOMPATIBLE^ Incompatible^
**Remarks**
This function can be used in State S3.
**See Also**


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.15. Display Control
4.2.15.1. CapMFAssistMode
Supported Cameras
X-
T1
X-
T2
X-
T3
X-
T4
X-
T 5
X-
Pro2
X-
Pro3
X-
S10
X-
H2S
X-
H2
X-
S20
X-
M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported MF ASSIST MODE settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMFAssistMode
lAPIParam (IN) <model>_API_PARAM_CapMFAssistMode
plNum (OUT) Returns the number of “SetMFAssistMode” settings supported.
plAssistMode (OUT)
<model>_MF_ASSIST_STANDARD Standard
<model>_MF_ASSIST_SPLIT_BW Split image in black and white
<model>_MF_ASSIST_SPLIT_COLOR Split image in color
<model>_MF_ASSIST_PEAK_WHITE_L Focus peak highlight in low white
<model>_MF_ASSIST_PEAK_WHITE_H Focus peak highlight in high white
<model>_MF_ASSIST_PEAK_RED_L Focus peak highlight in low red
<model>_MF_ASSIST_PEAK_RED_H Focus peak highlight in high red
<model>_MF_ASSIST_PEAK_BLUE_L Focus peak highlight in low blue
<model>_MF_ASSIST_PEAK_BLUE_H Focus peak highlight in high blue
<model>_MF_ASSIST_PEAK_YELLOW_L Focus peak highlight in low yellow
<model>_MF_ASSIST_PEAK_YELLOW_H Focus peak highlight in high yellow
<model>_MF_ASSIST_MICROPRISM^ Micro-prism^
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plAssistMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**Remarks**
This function can be used in State S3.
**See Also**
SetMFAssistMode


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.15.2. SetMFAssistMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the MF ASSIST MODE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMFAssistMode
lAPIParam (IN) <model>_API_PA R A M_SetMFAssistMode
lAssistMode (IN)
<model>_MF_ASSIST_STANDARD Standard
<model>_MF_ASSIST_SPLIT_BW Split image in black and white
<model>_MF_ASSIST_SPLIT_COLOR Split image in color
<model>_MF_ASSIST_PEAK_WHITE_L Focus peak highlight in low white
<model>_MF_ASSIST_PEAK_WHITE_H Focus peak highlight in high white
<model>_MF_ASSIST_PEAK_RED_L Focus peak highlight in low red
<model>_MF_ASSIST_PEAK_RED_H Focus peak highlight in high red
<model>_MF_ASSIST_PEAK_BLUE_L Focus peak highlight in low blue
<model>_MF_ASSIST_PEAK_BLUE_H Focus peak highlight in high blue
<model>_MF_ASSIST_PEAK_YELLOW_L Focus peak highlight in low yellow
<model>_MF_ASSIST_PEAK_YELLOW_H Focus peak highlight in high yellow
<model>_MF_ASSIST_MICROPRISM Micro-prism
The options supported vary with the camera model.
**Remarks**
This function can be used in State S3.
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lAssistMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**See Also**
GetMFAssistMode


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.15.3. GetMFAssistMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the MF ASSIST MODE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMFAssistMode
lAPIParam (IN) <model>_API_PA R A M_GetMFAssistMode
plAssistMode (OUT) See lAssistMode of “SetMFAssistMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetMFAssistMode
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plAssistMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.15.4. CapFocusCheckMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX
50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported FOCUS CHECK MODE settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapFocusCheckMode
lAPIParam (IN) <model>_API_PARAM_CapFocusCheckMode
plNum (OUT) Returns the number of “SetFocusCheckMode” settings supported.
plFocusCheckMode (OUT) See lFocusCheckMode of “SetFocusCheckMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetFocusCheckMode
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plFocusCheckMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.15.5. SetFocusCheckMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the FOCUS CHECK MODE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetFocusCheckMode
lAPIParam (IN) <model>_API_PA R A M_SetFocusCheckMode
lFocusCheckMode (IN)
<model>_ON ON
<model>_OFF OFF
**Remarks**
This function can be used in State S3.
**See Also**
GetFocusCheckMode
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lFocusCheckMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.15.6. GetFocusCheckMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the FOCUS CHECK MODE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetFocusCheckMode
lAPIParam (IN) <model>_API_PA R A M_GetFocusCheckMode
plFocusCheckMode (OUT) See lFocusCheckMode of “SetFocusCheckMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetFocusCheckMode
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plFocusCheckMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.15.7. CapViewMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported VIEW MODE settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapViewMode
lAPIParam (IN) <model>_API_PARAM_CapViewMode
lCategory (IN) See lCategory of “SetViewMode”.
plNum (OUT) Returns the number of “SetViewMode” settings supported.
plViewMode (OUT)
<model>_VIEW_MODE_EYE EYE SENSOR
<model>_VIEW_MODE_EVF EVF ONLY
<model>_VIEW_MODE_LCD LCD ONLY
<model>_VIEW_MODE_EVF_EYE EVF ONLY+EYE SENSOR
<model>_VIEW_MODE_LCDPOSTVIEW EYE SENSOR + LCD IMAGE

###### 

**Remarks**
This function can be used in State S3.
**See Also**

```
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lCategory,
long* plNum,
long* plViewMode
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.15.8. SetViewMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the VIEW MODE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetViewMode
lAPIParam (IN) <model>_API_PA R A M_SetViewMode
lCategory (IN) Specify the target operationg mode to set the ViewMode.
<model>_ITEM_VIEWMODE_SHOOT The shooting mode
<model>_ITEM_VIEWMODE_PLAYBACK The playback mode
lViewMode (IN)
<model>_VIEW_MODE_EYE EYE SENSOR
<model>_VIEW_MODE_EVF EVF ONLY
<model>_VIEW_MODE_LCD LCD ONLY
<model>_VIEW_MODE_EVF_EYE^ EVF ONLY+EYE SENSOR^
**Remarks**
This function can be used in State S3.
**See Also**
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lCategory,
long lViewMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.15.9. GetViewMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the VIEW MODE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetViewMode
lAPIParam (IN) <model>_API_PA R A M_GetViewMode
lCategory (IN) See lCategory of “SetViewMode”.
plViewMode (OUT) See lViewModeof “SetViewMode”.
**Remarks**
This function can be used in State S3.
**See Also**
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lCategory,
long* plViewMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.16. Live View
4.2.16.1. StartLiveView
Supported Cameras
X-
T1
X-
T2
X-
T3
X-
T4
X-
T 5
X-
Pro2
X-
Pro3
X-
S10
X-
H2S
X-
H2
X-
S20
X-
M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Starts live view.
This function is available in PC PRIORITY mode only.
It will return BUSY unless the ReadImage buffer is empty.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_StartLiveView
lAPIParam (IN) <model>_API_PA R A M_StartLiveView
**Remarks**
This function can be used in State S3.
**See Also**
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.16.2. StopLiveView
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Ends live view.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_StopLiveView
lAPIParam (IN) <model>_API_PA R A M_StopLiveView
**Remarks**
This function can be used in State S3.
**See Also**
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.16.3. CapLiveViewImageQuality
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported live view image quality settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapLiveViewImageQuality
lAPIParam (IN) <model>_API_PA R A M_CapLiveViewImageQuality.
plNum (OUT) Returns the number of “SetLiveViewImageQuality” settings supported.
plQuality (OUT)
<model>_LIVEVIEW_QUALITY_FINE FINE
<model>_LIVEVIEW_QUALITY_BASIC^ BASIC^
**Remarks**
This function can be used in State S3.
**See Also**
SetLiveViewImageQuality
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plQuality
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.16.4. SetLiveViewImageQuality
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the live view image quality setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera, (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetLiveViewImageQuality
lAPIParam (IN) <model>_API_PA R A M_SetLiveViewImageQuality
lQuality (IN)
<model>_LIVEVIEW_QUALITY_FINE FINE
<model>_LIVEVIEW_QUALITY_BASIC^ BASIC^
**Remarks**
This function can be used in State S3.
**See Also**
GetLiveViewImageQuality
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lQuality
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.16.5. GetLiveViewImageQuality
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the live view image quality setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetLiveViewImageQuality
lAPIParam (IN) <model>_API_PA R A M_GetLiveViewImageQuality
plQuality (OUT) See lQuality of “SetLiveViewImageQuality”.
**Remarks**
This function can be used in State S3.
**See Also**
SetLiveViewImageQuality
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plQuality
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.16.6. CapLiveViewImageSize
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported live view image size settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapLiveViewImageSize
lAPIParam (IN) <model>_API_PARAM_CapLiveViewImageSize
plNum (OUT) Returns the number of “SetLiveViewImageSize” settings supported.
plSize (OUT)
<model>_LIVEVIEW_SIZE_L Width approximately 1024 pixels
<model>_LIVEVIEW_SIZE_M Width approximately 640 pixels
<model>_LIVEVIEW_SIZE_S Width approximately 320 pixels
**Remarks**
This function can be used in State S3.
**See Also**
SetLiveViewImageSize
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSize
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.16.7. SetLiveViewImageSize
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX
50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the live view image size setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetLiveViewImageSize
lAPIParam (IN) <model>_API_PA R A M_SetLiveViewImageSize
lSize (IN)
<model>_LIVEVIEW_SIZE_L Width approximately 1024 pixels
<model>_LIVEVIEW_SIZE_M Width approximately 640 pixels
<model>_LIVEVIEW_SIZE_S Width approximately 320 pixels
**Remarks**
This function can be used in State S3.
**See Also**
GetLiveViewImageSize
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSize
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.16.8. GetLiveViewImageSize
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the live view image size setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetLiveViewImageSize
lAPIParam (IN) <model>_API_PA R A M_GetLiveViewImageSize
plSize (OUT) See lSize of “SetLiveViewImageSize”.
**Remarks**
This function can be used in State S3.
**See Also**
SetLiveViewImageSize
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSize
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.16.9. CapThroughImageZoom
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported live view zoom ratio settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapThroughImageZoom
lAPIParam (IN) <model>_API_PARAM_CapThroughImageZoom
plNum (OUT) Returns the number of “SetThroughImageZoom” settings supported.
plZoom (OUT)
<model>_THROUGH_ZOOM_10 x 1.0
<model>_THROUGH_ZOOM_25 x 2.5
<model>_THROUGH_ZOOM_40 x 4.0
<model>_THROUGH_ZOOM_60 x 6.0
<model>_THROUGH_ZOOM_80 x 8.0
<model>_THROUGH_ZOOM_160 x 16.0
<model>_THROUGH_ZOOM_240 x 24.0
<model>_THROUGH_ZOOM_20 x2.0
<model>_THROUGH_ZOOM_33 x3. 3
<model>_THROUGH_ZOOM_66 x6. 6
<model>_THROUGH_ZOOM_131 x13.1
<model>_THROUGH_ZOOM_197 x19.7
<model>_THROUGH_ZOOM_ 83 X8.3
<model>_THROUGH_ZOOM_ 170 X17.0
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plZoom
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_THROUGH_ZOOM_ 68 X6.8
<model>_THROUGH_ZOOM_ 140 X14.0
<model>_THROUGH_ZOOM_ 120 X12.0
**Remarks**
This function can be used in State S3.
**See Also**
SetThroughImageZoom


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.16.10. SetThroughImageZoom
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the live view zoom ratio setting (and also LCD image zoom ratio setting).
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera, (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetThroughImageZoom
lAPIParam (IN) <model>_API_PA R A M_SetThroughImageZoom
lZoom (IN) **[X-H2S/X-H2/X-T5/X-S20]**
<model>_THROUGH_ZOOM_10 x 1.0
<model>_THROUGH_ZOOM_25 x 2.5
<model>_THROUGH_ZOOM_ 40 x 4 .0
<model>_THROUGH_ZOOM_ 80 x 8.0
<model>_THROUGH_ZOOM_ 120 x 12.0
**[Other X models]**
<model>_THROUGH_ZOOM_10 x 1.0
<model>_THROUGH_ZOOM_25 x 2.5
<model>_THROUGH_ZOOM_60 x 6.0
**[GFX 50S/GFX 50R]**
GFX50S_THROUGH_ZOOM_10 x 1.0
GFX50S_THROUGH_ZOOM_25 x 2.5
GFX50S_THROUGH_ZOOM_ 40 x 4.0
GFX50S_THROUGH_ZOOM_ 80 x 8 .0
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lZoom
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
GFX50S_THROUGH_ZOOM_ 160 x 16 .0
GFX50S_THROUGH_ZOOM_ 20 x 2.0
GFX50S_THROUGH_ZOOM_ 33 x 3.3
GFX50S_THROUGH_ZOOM_ 66 x 6.6
GFX50S_THROUGH_ZOOM_ 131 x 1 3.1
**[GFX50S II]**
GFX50SII_THROUGH_ZOOM_10 x 1.0
GFX50SII_THROUGH_ZOOM_25 x 2.5
GFX50SII_THROUGH_ZOOM_40 x 4.0
GFX50SII_THROUGH_ZOOM_83 x 8.3
GFX50SII_THROUGH_ZOOM_170 x 17.0
GFX50SII_THROUGH_ZOOM_20 x 2.0
GFX50SII_THROUGH_ZOOM_33 x 3.3
GFX50SII_THROUGH_ZOOM_68 x 6.8
GFX50SII_THROUGH_ZOOM_140 x14.0
**[GFX 100/GFX100S/GFX100II/GFX100SII]**
GFX100_THROUGH_ZOOM_10 x 1.0
GFX100_THROUGH_ZOOM_25 x 2.5
GFX100_THROUGH_ZOOM_ 40 x 4.0
GFX100_THROUGH_ZOOM_ 80 x 8 .0
GFX100_THROUGH_ZOOM_ 160 x 16 .0
GFX100_THROUGH_ZOOM_ 240 x 24 .0
GFX100_THROUGH_ZOOM_ 20 x20.0
GFX100_THROUGH_ZOOM_ 33 x33.0
GFX100_THROUGH_ZOOM_ 66 x 6 6.0
GFX100_THROUGH_ZOOM_ 131 x 1 3.1
GFX100_THROUGH_ZOOM_ 197 x 1 9.7
**Remarks**
This function can be used in State S3.
**See Also**
GetThroughImageZoom


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.16.11. GetThroughImageZoom
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the live view zoom ratio setting (and also LCD image zoom ratio setting).
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetThroughImageZoom
lAPIParam (IN) <model>_API_PA R A M_ GetThroughImageZoom
plZoom (OUT) See lSize of “SetThroughImageZoom”.
**Remarks**
This function can be used in State S3.
**See Also**
SetThroughImageZoom
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plZoom
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.16.12. GetLiveViewStatus
Supported Cameras
X-
T1
X-
T2
X-
T3
X-
T4
X-
T 5
X-
Pro2
X-
Pro3
X-
S10
X-
H2S
X-
H2
X-
S20
X-
M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 (^)
**Description**
Gets live view status.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetLiveViewStatus
lAPIParam (IN) <model>_API_PARAM_GetLiveViewStatus
plStatus (OUT)
<model>_ON ON
<model>_OFF OFF
**Remarks**
This function can be used in State S3.
**See Also**
CapLiveViewStatus
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plStatus
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17. Movie Control – MOVIE SETTING**
Control the settings that correspond to the following MOVIE SETTING menu.
APIs are available only when the STILL/MOVIE mode is in MOVIE mode.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.1. CapMovieImageFormat
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3
**Description**
Queries supported IMAGE FORMAT settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieImageFormat
lAPIParam (IN) <model>_API_PARAM_CapMovieImageFormat
plNum (OUT) Returns the number of “SetMovieImageFormat” settings supported.
plMode (OUT) "SetMovieImageFormat" List of possible values.
<model>_MOVIE_IMAGEFORMAT_GF GF
<model>_MOVIE_IMAGEFORMAT_35MM 35mm
<model>_MOVIE_IMAGEFORMAT_ANAMORPHIC_35MM ANAMORPHIC
(35mm)
<model>_IMAGEFORMAT_PREMISTA Premista
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieImageFormat、GetMovieImageFormat
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.2. SetMovieImageFormat
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3
**Description**
Sets the IMAGE FORMAT setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieImageFormat
lAPIParam (IN) <model>_API_PARAM_SetMovieImageFormat
lSetting (IN) Setting value (must be a configurable value obtained with
CapMovieImageFormat).
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieImageFormat、GetMovieImageFormat
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.3. GetMovieImageFormat
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3
**Description**
Gets the IMAGE FORMAT setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieImageFormat
lAPIParam (IN) <model>_API_PARAM_GetMovieImageFormat
plSetting (OUT) The current setting value obtained.
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieImageFormat、GetMovieImageFormat
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.4. CapAnamorphicDesqueezeDisplay
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3
**Description**
Queries supported DESQUEEZE DISPLAY IN RECODING settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapAnamorphicDesqueezeDisplay
lAPIParam (IN) <model>_API_PARAM_CapAnamorphicDesqueezeDisplay
plNum (OUT) Returns the number of “SetAnamorphicDesqueezeDisplay” settings supported.
plSetting (OUT)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
SetAnamorphicDesqueezeDisplay, GetAnamorphicDesqueezeDisplay
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.5. SetAnamorphicDesqueezeDisplay
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3
**Description**
Sets the DESQUEEZE DISPLAY IN RECODING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetAnamorphicDesqueezeDisplay
lAPIParam (IN) <model>_API_PARAM_SetAnamorphicDesqueezeDisplay
lSetting (IN)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
CapAnamorphicDesqueezeDisplay, GetAnamorphicDesqueezeDisplay
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.6. GetAnamorphicDesqueezeDisplay
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3
**Description**
Get the DESQUEEZE DISPLAY IN RECODING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetAnamorphicDesqueezeDisplay
lAPIParam (IN) <model>_API_PARAM_GetAnamorphicDesqueezeDisplay
plSetting (OUT)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
CapAnamorphicDesqueezeDisplay, SetAnamorphicDesqueezeDisplay
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.7. CapAnamorphicMagnification
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3
**Description**
Queries supported MAGNIFICATION settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapAnamorphicMagnification
lAPIParam (IN) <model>_API_PARAM_CapAnamorphicMagnification
plNum (OUT) Returns the number of “SetAnamorphicMagnification” settings supported.
plSetting (OUT)
100 1 .0 times
130 1 .3 times
133 1 .33 times
150 1 .5 times
180 1 .8 times
200 2 .0 times^
**Remarks**
This function can be used in State S3.
**See Also**
SetAnamorphicMagnification, GetAnamorphicMagnification
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.8. SetAnamorphicMagnification
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3
**Description**
Sets the MAGNIFICATION setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetAnamorphicMagnification
lAPIParam (IN) <model>_API_PARAM_SetAnamorphicMagnification
lSetting (IN)
100 1 .0 times
130 1 .3 times
133 1 .33 times
150 1 .5 times
180 1 .8 times
200 2 .0 times^
**Remarks**
This function can be used in State S3.
**See Also**
CapAnamorphicMagnification, GeAnamorphicMagnification
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.9. GetAnamorphicMagnification
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3
**Description**
Gets the MAGNIFICATION setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetAnamorphicMagnification
lAPIParam (IN) <model>_API_PARAM_GetAnamorphicMagnification
plValue (OUT) See lSetting of “SetAnamorphicMagnification”.
**Remarks**
This function can be used in State S3.
**See Also**
CapAnamorphicMagnification, SetAnamorphicMagnification
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plValue
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.10. CapMovieResolution
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported MOVIE MODE settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieResolution
lAPIParam (IN) <model>_API_PARAM_CapMovieResolution
plNum (OUT) Returns the number of “SetMovieResolution” settings supported.
plSetting (OUT)
<model>_MOVIE_RESOLUTION_6P2K_3_2 6.2K 3:2
<model>_MOVIE_RESOLUTION_8K_16_9 8 K 16:9
<model>_MOVIE_RESOLUTION_6K_16_9 6 K 16:9
<model>_MOVIE_RESOLUTION_4KHQ_16_9 4 K_HQ 16:9
<model>_MOVIE_RESOLUTION_4K_16_9 4 K 16:9
<model>_MOVIE_RESOLUTION_DCIHQ_17_9 DCI_HQ 17:9
<model>_MOVIE_RESOLUTION_DCI_17_9 DCI 17:9
(DCI_4K 17:9)
<model>_MOVIE_RESOLUTION_FULLHD_16_9 FullHD 16:9
<model>_MOVIE_RESOLUTION_FULLHD_17_9 FullHD 17:9
<model>_MOVIE_RESOLUTION_5K_17_9 5 K 17:9
<model>_MOVIE_RESOLUTION_DCI_8K_17_9 DCI_8K 17:9
<model>_MOVIE_RESOLUTION_CINESCO_2P35_1 CineSco 2.35:1
<model>_MOVIE_RESOLUTION_OPENGATE_3_2 OpenGate 3:2
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_MOVIE_RESOLUTION_35MM_16_9 3 5mm 16:9
<model>_MOVIE_RESOLUTION_ANAMORPHIC_2P76_1 Anamorphic 2.76:1
<model>_MOVIE_RESOLUTION_ANAMORPHIC_1P38_1 Anamorphic 1.38:1
<model>_MOVIE_RESOLUTION_FULLFRAME_3_2 FullFrame 3:2
<model>_MOVIE_RESOLUTION_FULLHDLP_ 16 _ 9 FullHD_LP 16:9
<model>_MOVIE_RESOLUTION_FULLHDLP_ 17 _ 9 FullHD_LP 17:9
<model>_ MOVIE_RESOLUTION_4K_LP_16_9 4K LP 16:9
<model_MOVIE_RESOLUTION_FULLHD_9_16^ FullHD^ 9:16^
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieResolution, GetMovieResolution


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.11. SetMovieResolution
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the MOVIE MODE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieResolution
lAPIParam (IN) <model>_API_PARAM_SetMovieResolution
lSetting (IN)
<model>_MOVIE_RESOLUTION_6P2K_3_2 6.2K 3:2
<model>_MOVIE_RESOLUTION_8K_16_9 8 K 16:9
<model>_MOVIE_RESOLUTION_6K_16_9 6 K 16:9
<model>_MOVIE_RESOLUTION_4KHQ_16_9 4 K_HQ 16:9
<model>_MOVIE_RESOLUTION_4K_16_9 4 K 16:9
<model>_MOVIE_RESOLUTION_DCIHQ_17_9 DCI_HQ 17:9
<model>_MOVIE_RESOLUTION_DCI_17_9 DCI 17:9
(DCI_4K 17:9)
<model>_MOVIE_RESOLUTION_FULLHD_16_9 FullHD 16:9
<model>_MOVIE_RESOLUTION_FULLHD_17_9 FullHD 17:9
<model>_MOVIE_RESOLUTION_5K_17_9 5 K 17:9
<model>_MOVIE_RESOLUTION_DCI_8K_17_9 DCI_8K 17:9
<model>_MOVIE_RESOLUTION_CINESCO_2P35_1 CineSco 2.35:1
<model>_MOVIE_RESOLUTION_OPENGATE_3_2 OpenGate 3:2
<model>_MOVIE_RESOLUTION_35MM_16_9 3 5mm 16:9
<model>_MOVIE_RESOLUTION_ANAMORPHIC_2P76_1 Anamorphic 2.76:1
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_MOVIE_RESOLUTION_ANAMORPHIC_1P38_1 Anamorphic 1.38:1
<model>_MOVIE_RESOLUTION_FULLFRAME_3_2 FullFrame 3:2
<model>_MOVIE_RESOLUTION_FULLHDLP_ 16 _ 9 FullHD_LP 16:9
<model>_MOVIE_RESOLUTION_FULLHDLP_ 17 _ 9 FullHD_LP 17:9
<model>_ MOVIE_RESOLUTION_4K_LP_16_9 4K LP 16:9
<model_MOVIE_RESOLUTION_FULLHD_9_16^ FullHD^ 9:16^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieResolution, GetMovieResolution


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.12. GetMovieResolution
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the MOVIE MODE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieResolution
lAPIParam (IN) <model>_API_PARAM_GetMovieResolution
plSetting (OUT)
<model>_MOVIE_RESOLUTION_6P2K_3_2 6.2K 3:2
<model>_MOVIE_RESOLUTION_8K_16_9 8 K 16:9
<model>_MOVIE_RESOLUTION_6K_16_9 6 K 16:9
<model>_MOVIE_RESOLUTION_4KHQ_16_9 4 K_HQ 16:9
<model>_MOVIE_RESOLUTION_4K_16_9 4 K 16:9
<model>_MOVIE_RESOLUTION_DCIHQ_17_9 DCI_HQ 17:9
<model>_MOVIE_RESOLUTION_DCI_17_9 DCI 17:9
(DCI_4K 17:9)
<model>_MOVIE_RESOLUTION_FULLHD_16_9 FullHD 16:9
<model>_MOVIE_RESOLUTION_FULLHD_17_9 FullHD 17:9
<model>_MOVIE_RESOLUTION_5K_17_9 5 K 17:9
<model>_MOVIE_RESOLUTION_DCI_8K_17_9 DCI_8K 17:9
<model>_MOVIE_RESOLUTION_CINESCO_2P35_1 CineSco 2.35:1
<model>_MOVIE_RESOLUTION_OPENGATE_3_2 OpenGate 3:2
<model>_MOVIE_RESOLUTION_35MM_16_9 3 5mm 16:9
<model>_MOVIE_RESOLUTION_ANAMORPHIC_2P76_1 Anamorphic 2.76:1
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_MOVIE_RESOLUTION_ANAMORPHIC_1P38_1 Anamorphic 1.38:1
<model>_MOVIE_RESOLUTION_FULLFRAME_3_2 FullFrame 3:2
<model>_MOVIE_RESOLUTION_FULLHDLP_ 16 _ 9 FullHD_LP 16:9
<model>_MOVIE_RESOLUTION_FULLHDLP_ 17 _ 9 FullHD_LP 17:9
<model>_ MOVIE_RESOLUTION_4K_LP_16_9 4K LP 16:9
<model_MOVIE_RESOLUTION_FULLHD_9_16^ FullHD^ 9:16^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieResolution, SetMovieResolution


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.13. CapMovieFrameRate
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported MOVIE MODE settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieFrameRate
lAPIParam (IN) <model>_API_PARAM_CapMovieFrameRate
plNum (OUT) Returns the number of “SetMovieFrameRate” settings supported.
plSetting (OUT)
<model>_MOVIE_FRAMERATE_59_94P 5 9.94P
<model>_MOVIE_FRAMERATE_50P 5 0P
<model>_MOVIE_FRAMERATE_29_97P 2 9.97P
<model>_MOVIE_FRAMERATE_25P 2 5P
<model>_MOVIE_FRAMERATE_24P 2 4P
<model>_MOVIE_FRAMERATE_23_98P^2 3.98P^
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieFrameRate, GetMovieFrameRate
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.14. SetMovieFrameRate
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the MOVIE MODE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieFrameRate
lAPIParam (IN) <model>_API_PARAM_SetMovieFrameRate
lSetting (IN)
<model>_MOVIE_FRAMERATE_59_94P 5 9.94P
<model>_MOVIE_FRAMERATE_50P 5 0P
<model>_MOVIE_FRAMERATE_29_97P 2 9.97P
<model>_MOVIE_FRAMERATE_25P 2 5P
<model>_MOVIE_FRAMERATE_24P 2 4P
<model>_MOVIE_FRAMERATE_23_98P^2 3.98P^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieFrameRate, GetMovieFrameRate
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.15. GetMovieFrameRate
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the MOVIE MODE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieFrameRate
lAPIParam (IN) <model>_API_PARAM_GetMovieFrameRate
plSetting (OUT)
<model>_MOVIE_FRAMERATE_59_94P 5 9.94P
<model>_MOVIE_FRAMERATE_50P 5 0P
<model>_MOVIE_FRAMERATE_29_97P 2 9.97P
<model>_MOVIE_FRAMERATE_25P 2 5P
<model>_MOVIE_FRAMERATE_24P 2 4P
<model>_MOVIE_FRAMERATE_23_98P^2 3.98P^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieFrameRate, SetMovieFrameRate
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.16. CapHighSpeedRecMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3
**Description**
Queries supported HIGH SPEED REC settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapHighSpeedRecMode
lAPIParam (IN) <model>_API_PARAM_CapHighSpeedRecMode
plNum (OUT) Returns the number of “SetHighSpeedRecMode” settings supported.
plSetting (OUT)
<model>_HIGHSPEEDREC_OFF OFF
<model>_HIGHSPEEDREC_ON ON
<model>_HIGHSPEEDREC_ON_HDMI_ONLY^ ON HDMI Only^
**Remarks**
This function can be used in State S3.
**See Also**
SetHighSpeedRecMode, GetHighSpeedRecMode
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.17. SetHighSpeedRecMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3
**Description**
Sets the HIGH SPEED REC setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetHighSpeedRecMode
lAPIParam (IN) <model>_API_PARAM_SetHighSpeedRecMode
lSetting (IN)
<model>_HIGHSPEEDREC_OFF OFF
<model>_HIGHSPEEDREC_ON ON
<model>_HIGHSPEEDREC_ON_HDMI_ONLY^ ON HDMI Only^
**Remarks**
This function can be used in State S3.
**See Also**
CapHighSpeedRecMode, GetHighSpeedRecMode
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.18. GetHighSpeedRecMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3
**Description**
Gets the HIGH SPEED REC setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetHighSpeedRecMode
lAPIParam (IN) <model>_API_PARAM_GetHighSpeedRecMode
plSetting (OUT)
<model>_HIGHSPEEDREC_OFF OFF
<model>_HIGHSPEEDREC_ON ON
<model>_HIGHSPEEDREC_ON_HDMI_ONLY^ ON HDMI Only^
**Remarks**
This function can be used in State S3.
**See Also**
CapHighSpeedRecMode, SetHighSpeedRecMode
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.19. CapHighSpeedRecResolution
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3
**Description**
Queries supported HIGH SPEED REC settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapHighSpeedRecResolution
lAPIParam (IN) <model>_API_PARAM_CapHighSpeedRecResolution
plNum (OUT) Returns the number of “SetHighSpeedRecResolution” settings supported.
plSetting (OUT)
<model>_MOVIE_RESOLUTION_4K_16_9 4 K 16:9
<model>_MOVIE_RESOLUTION_DCI_17_9 DCI 17:9
<model>_MOVIE_RESOLUTION_FULLHD_16_9 FullHD 16:9
<model>_MOVIE_RESOLUTION_FULLHD_17_9^ FullHD 17:9^
**Remarks**
This function can be used in State S3.
**See Also**
SetHighSpeedRecResolution, GetHighSpeedRecResolution
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.20. SetHighSpeedRecResolution
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3
**Description**
Sets the HIGH SPEED REC setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetHighSpeedRecResolution
lAPIParam (IN) <model>_API_PARAM_SetHighSpeedRecResolution
lSetting (IN)
<model>_MOVIE_RESOLUTION_4K_16_9 4 K 16:9
<model>_MOVIE_RESOLUTION_DCI_17_9 DCI 17:9
<model>_MOVIE_RESOLUTION_FULLHD_16_9 FullHD 16:9
<model>_MOVIE_RESOLUTION_FULLHD_17_9^ FullHD 17:9^
**Remarks**
This function can be used in State S3.
**See Also**
CapHighSpeedRecResolution, GetHighSpeedRecResolution
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.21. GetHighSpeedRecResolution
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3
**Description**
Gets the HIGH SPEED REC setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetHighSpeedRecResolution
lAPIParam (IN) <model>_API_PARAM_GetHighSpeedRecResolution
plSetting (OUT)
<model>_MOVIE_RESOLUTION_4K_16_9 4 K 16:9
<model>_MOVIE_RESOLUTION_DCI_17_9 DCI 17:9
<model>_MOVIE_RESOLUTION_FULLHD_16_9 FullHD 16:9
<model>_MOVIE_RESOLUTION_FULLHD_17_9^ FullHD 17:9^
**Remarks**
This function can be used in State S3.
**See Also**
CapHighSpeedRecResolution, SetHighSpeedRecResolution
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.22. CapHighSpeedRecFrameRate
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3
**Description**
Queries supported HIGH SPEED REC settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapHighSpeedRecFrameRate
lAPIParam (IN) <model>_API_PARAM_CapHighSpeedRecFrameRate
plNum (OUT) Returns the number of “SetHighSpeedRecFrameRate” settings supported.
plSetting (OUT)
<model>_HIGHSPEEDREC_FRAMERATE_240P 2 40P
<model>_HIGHSPEEDREC_FRAMERATE_2 0 0P 2 00P
<model>_HIGHSPEEDREC_FRAMERATE_ 1 20P 1 20P
<model>_HIGHSPEEDREC_FRAMERATE_^10 0P^1 00P^
**Remarks**
This function can be used in State S3.
**See Also**
SetHighSpeedRecFrameRate, GetHighSpeedRecFrameRate
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.23. SetHighSpeedRecFrameRate
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3
**Description**
Sets the HIGH SPEED REC setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetHighSpeedRecFrameRate
lAPIParam (IN) <model>_API_PARAM_SetHighSpeedRecFrameRate
lSetting (IN)
<model>_HIGHSPEEDREC_FRAMERATE_240P 2 40P
<model>_HIGHSPEEDREC_FRAMERATE_2 0 0P 2 00P
<model>_HIGHSPEEDREC_FRAMERATE_ 1 20P 1 20P
<model>_HIGHSPEEDREC_FRAMERATE_^10 0P^1 00P^
**Remarks**
This function can be used in State S3.
**See Also**
CapHighSpeedRecFrameRate, GetHighSpeedRecFrameRate
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.24. GetHighSpeedRecFrameRate
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3
**Description**
Gets the HIGH SPEED REC setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetHighSpeedRecFrameRate
lAPIParam (IN) <model>_API_PARAM_GetHighSpeedRecFrameRate
plSetting (OUT)
<model>_HIGHSPEEDREC_FRAMERATE_240P 2 40P
<model>_HIGHSPEEDREC_FRAMERATE_2 0 0P 2 00P
<model>_HIGHSPEEDREC_FRAMERATE_ 1 20P 1 20P
<model>_HIGHSPEEDREC_FRAMERATE_^10 0P^1 00P^
**Remarks**
This function can be used in State S3.
**See Also**
CapHighSpeedRecFrameRate, SetHighSpeedRecFrameRate
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.25. CapHighSpeedRecPlayBackFrameRate
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3
**Description**
Queries supported HIGH SPEED REC settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapHighSpeedRecPlayBackFrameRate
lAPIParam (IN) <model>_API_PARAM_CapHighSpeedRecPlayBackFrameRate
plNum (OUT) Returns the number of “SetHighSpeedRecPlayBackFrameRate” settings supported.
plSetting (OUT)
<model>_MOVIE_FRAMERATE_59_94P 5 9.94P
<model>_MOVIE_FRAMERATE_50P 5 0P
<model>_MOVIE_FRAMERATE_ 2 9_9 7 P 2 9.97P
<model>_MOVIE_FRAMERATE_ 25 P 2 5P
<model>_MOVIE_FRAMERATE_ 2 4P 2 4P
<model>_MOVIE_FRAMERATE_^23 _9^8 P^2 3.98P^
**Remarks**
This function can be used in State S3.
**See Also**
SetHighSpeedRecPlayBackFrameRate, GetHighSpeedRecPlayBackFrameRate
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.26. SetHighSpeedRecPlayBackFrameRate
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3
**Description**
Sets the HIGH SPEED REC setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetHighSpeedRecPlayBackFrameRate
lAPIParam (IN) <model>_API_PARAM_SetHighSpeedRecPlayBackFrameRate
lSetting (IN)
<model>_MOVIE_FRAMERATE_59_94P 5 9.94P
<model>_MOVIE_FRAMERATE_50P 5 0P
<model>_MOVIE_FRAMERATE_ 2 9_9 7 P 2 9.97P
<model>_MOVIE_FRAMERATE_ 25 P 2 5P
<model>_MOVIE_FRAMERATE_ 2 4P 2 4P
<model>_MOVIE_FRAMERATE_^23 _9^8 P^2 3.98P^
**Remarks**
This function can be used in State S3.
**See Also**
CapHighSpeedRecPlayBackFrameRate, GetHighSpeedRecPlayBackFrameRate
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.27. GetHighSpeedRecPlayBackFrameRate
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3
**Description**
Gets the HIGH SPEED REC setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetHighSpeedRecPlayBackFrameRate
lAPIParam (IN) <model>_API_PARAM_GetHighSpeedRecPlayBackFrameRate
plSetting (OUT)
<model>_MOVIE_FRAMERATE_59_94P 5 9.94P
<model>_MOVIE_FRAMERATE_50P 5 0P
<model>_MOVIE_FRAMERATE_ 2 9_9 7 P 2 9.97P
<model>_MOVIE_FRAMERATE_ 25 P 2 5P
<model>_MOVIE_FRAMERATE_ 2 4P 2 4P
<model>_MOVIE_FRAMERATE_^23 _9^8 P^2 3.98P^
**Remarks**
This function can be used in State S3.
**See Also**
CapHighSpeedRecPlayBackFrameRate, SetHighSpeedRecPlayBackFrameRate
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.28. CapMovieCaptureDelay
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Queries supported SELF TIMER settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieCaptureDelay
lAPIParam (IN) <model>_API_PARAM_CapMovieCaptureDelay
plNum (OUT) Returns the number of “SetMovieCaptureDelay” settings supported.
plSetting (OUT)
10000 10 min
5000 5 min
3000 3 min
0 OFF^
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieCaptureDelay, GetMovieCaptureDelay
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.29. SetMovieCaptureDelay
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Sets the SELF TIMER setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieCaptureDelay
lAPIParam (IN) <model>_API_PARAM_SetMovieCaptureDelay
lSetting (IN)
10000 10 min
5000 5 min
3000 3 min
0 OFF^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieCaptureDelay, GetMovieCaptureDelay
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.30. GetMovieCaptureDelay
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Get the SELF TIMER setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieCaptureDelay
lAPIParam (IN) <model>_API_PARAM_GetMovieCaptureDelay
plSetting (OUT)
10000 1 0 min
5000 5 min
3000 3 min
0 OFF^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieCaptureDelay, SetMovieCaptureDelay
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.31. CapMovieMediaRecord
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported MEDIA REC SETTING settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieMediaRecord
lAPIParam (IN) <model>_API_PARAM_CapMovieMediaRecord
plNum (OUT) Returns the number of “SetMovieMediaRecord” settings supported.
plSetting (OUT)
<model>_MOVIE_MEDIARECORD_SEQUENTIAL_
SLOT1_SLOT2
Sequential recode
slot1 to slot2
<model>_MOVIE_MEDIARECORD_SLOT2 Slot2 only
<model>_MOVIE_MEDIARECORD_SLOT 1 Slot1 only
<model>_MOVIE_MEDIARECORD_BACKUP Backup recode
slot1 and slot2
<model>_MOVIE_MEDIARECORD_SSD SSD only
<model>_MOVIE_MEDIARECORD_SSD_CF SSD and CF
<model>_MOVIE_MEDIARECORD_OFF OFF
<model>_MOVIE_MEDIARECORD_SEQUENTIAL_
SLOT2_SLOT1
Sequential recode
slot2 to slot1^
**Remarks**
This function can be used in State S3.
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**See Also**
SetMovieMediaRecord, GetMovieMediaRecord


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.32. SetMovieMediaRecord
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the MEDIA REC SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieMediaRecord
lAPIParam (IN) <model>_API_PARAM_SetMovieMediaRecord
lSetting (IN)
<model>_MOVIE_MEDIARECORD_SEQUENTIAL_
SLOT1_SLOT2
Sequential recode
slot1 to slot2
<model>_MOVIE_MEDIARECORD_SLOT2 Slot2 only
<model>_MOVIE_MEDIARECORD_SLOT 1 Slot1 only
<model>_MOVIE_MEDIARECORD_BACKUP Backup recode
slot1 and slot2
<model>_MOVIE_MEDIARECORD_SSD SSD only
<model>_MOVIE_MEDIARECORD_SSD_CF SSD and CF
<model>_MOVIE_MEDIARECORD_OFF OFF
<model>_MOVIE_MEDIARECORD_SEQUENTIAL_
SLOT2_SLOT1
Sequential recode
slot2 to slot1^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieMediaRecord, GetMovieMediaRecord
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.33. GetMovieMediaRecord
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the MEDIA REC SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieMediaRecord
lAPIParam (IN) <model>_API_PARAM_GetMovieMediaRecord
plSetting (OUT)
<model>_MOVIE_MEDIARECORD_SEQUENTIAL_
SLOT1_SLOT2
Sequential recode
slot1 to slot2
<model>_MOVIE_MEDIARECORD_SLOT2 Slot2 only
<model>_MOVIE_MEDIARECORD_SLOT 1 Slot1 only
<model>_MOVIE_MEDIARECORD_BACKUP Backup recode
slot1 and slot2
<model>_MOVIE_MEDIARECORD_SSD SSD only
<model>_MOVIE_MEDIARECORD_SSD_CF SSD and CF
<model>_MOVIE_MEDIARECORD_OFF OFF
<model>_MOVIE_MEDIARECORD_SEQUENTIAL_
SLOT2_SLOT1
Sequential recode
slot2 to slot1^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieMediaRecord, SetMovieMediaRecord
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.34. CapMovieBitRate
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported MEDIA REC SETTING settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieBitRate
lAPIParam (IN) <model>_API_PARAM_CapMovieBitRate
plNum (OUT) Returns the number of “SetMovieBitRate” settings supported.
plSetting (OUT)
<model>_MOVIE_BITRATE_720MBPS 7 00Mbps
<model>_MOVIE_BITRATE_400MBPS 4 00Mbps
<model>_MOVIE_BITRATE_360MBPS 3 60Mbps
<model>_MOVIE_BITRATE_200MBPS 2 00Mbps
<model>_MOVIE_BITRATE_100MBPS 1 00Mbps
<model>_MOVIE_BITRATE_50MBPS 5 0Mbps
<model>_MOVIE_BITRATE_30MBPS 3 0Mbps
<model>_MOVIE_BITRATE_15MBPS 1 5Mbps
<model>_MOVIE_BITRATE_8MBPS^8 Mbps^
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieBitRate, GetMovieBitRate
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.35. SetMovieBitRate
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the MEDIA REC SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieBitRate
lAPIParam (IN) <model>_API_PARAM_SetMovieBitRate
lSetting (IN)
<model>_MOVIE_BITRATE_720MBPS 7 00Mbps
<model>_MOVIE_BITRATE_400MBPS 4 00Mbps
<model>_MOVIE_BITRATE_360MBPS 3 60Mbps
<model>_MOVIE_BITRATE_200MBPS 2 00Mbps
<model>_MOVIE_BITRATE_100MBPS 1 00Mbps
<model>_MOVIE_BITRATE_50MBPS 5 0Mbps
<model>_MOVIE_BITRATE_30MBPS 3 0Mbps
<model>_MOVIE_BITRATE_15MBPS 1 5Mbps
<model>_MOVIE_BITRATE_8MBPS^8 Mbps^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieBitRate, GetMovieBitRate
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.36. GetMovieBitRate
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the MEDIA REC SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieBitRate
lAPIParam (IN) <model>_API_PARAM_GetMovieBitRate
plSetting (OUT)
<model>_MOVIE_BITRATE_720MBPS 7 00Mbps
<model>_MOVIE_BITRATE_400MBPS 4 00Mbps
<model>_MOVIE_BITRATE_360MBPS 3 60Mbps
<model>_MOVIE_BITRATE_200MBPS 2 00Mbps
<model>_MOVIE_BITRATE_100MBPS 1 00Mbps
<model>_MOVIE_BITRATE_50MBPS 5 0Mbps
<model>_MOVIE_BITRATE_30MBPS 3 0Mbps
<model>_MOVIE_BITRATE_15MBPS 1 5Mbps
<model>_MOVIE_BITRATE_8MBPS^8 Mbps^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieBitRate, SetMovieBitRate
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.37. CapMovieFileFormat
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported MEDIA REC SETTING settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieFileFormat
lAPIParam (IN) <model>_API_PARAM_CapMovieFileFormat
plNum (OUT) Returns the number of “SetMovieFileFormat” settings supported.
plSetting (OUT)
<model>_MOVIE_FORMAT_H264_ALL_I_MOV H.264 All-I MOV
<model>_MOVIE_FORMAT_H264_LONGGOP_I_MOV H.264 LongGOP MOV
<model>_MOVIE_FORMAT_H264_LONGGOP_MP4 H.264 LongGOP MP4
<model>_MOVIE_FORMAT_H265_4_2_0_ALL_I H.265(4:2:0) All-I
<model>_MOVIE_FORMAT_H265_4_2_0_LONGGOP H.265(4:2:0) LongGOP
<model>_MOVIE_FORMAT_H265_4_2_2_ALL_I H.265(4:2:2) All-I
<model>_MOVIE_FORMAT_H265_4_2_2_LONGGOP H.265(4:2:2) LongGOP
<model>_MOVIE_FORMAT_PRORESHQ ProResHQ
<model>_MOVIE_FORMAT_PRORES ProRes
<model>_MOVIE_FORMAT_PRORESLT^ ProResLT^
**Remarks**
This function can be used in State S3.
**See Also**
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
SetMovieFileFormat, GetMovieFileFormat


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.38. SetMovieFileFormat
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the MEDIA REC SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieFileFormat
lAPIParam (IN) <model>_API_PARAM_SetMovieFileFormat
lSetting (IN)
<model>_MOVIE_FORMAT_H264_ALL_I_MOV H.264 All-I MOV
<model>_MOVIE_FORMAT_H264_LONGGOP_I_MOV H.264 LongGOP MOV
<model>_MOVIE_FORMAT_H264_LONGGOP_MP4 H.264 LongGOP MP4
<model>_MOVIE_FORMAT_H265_4_2_0_ALL_I H.265(4:2:0) All-I
<model>_MOVIE_FORMAT_H265_4_2_0_LONGGOP H.265(4:2:0) LongGOP
<model>_MOVIE_FORMAT_H265_4_2_2_ALL_I H.265(4:2:2) All-I
<model>_MOVIE_FORMAT_H265_4_2_2_LONGGOP H.265(4:2:2) LongGOP
<model>_MOVIE_FORMAT_PRORESHQ ProResHQ
<model>_MOVIE_FORMAT_PRORES ProRes
<model>_MOVIE_FORMAT_PRORESLT^ ProResLT^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieFileFormat, GetMovieFileFormat
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.39. GetMovieFileFormat
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the MEDIA REC SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieFileFormat
lAPIParam (IN) <model>_API_PARAM_GetMovieFileFormat
plSetting (OUT)
<model>_MOVIE_FORMAT_H264_ALL_I_MOV H.264 All-I MOV
<model>_MOVIE_FORMAT_H264_LONGGOP_I_MOV H.264 LongGOP MOV
<model>_MOVIE_FORMAT_H264_LONGGOP_MP4 H.264 LongGOP MP4
<model>_MOVIE_FORMAT_H265_4_2_0_ALL_I H.265(4:2:0) All-I
<model>_MOVIE_FORMAT_H265_4_2_0_LONGGOP H.265(4:2:0) LongGOP
<model>_MOVIE_FORMAT_H265_4_2_2_ALL_I H.265(4:2:2) All-I
<model>_MOVIE_FORMAT_H265_4_2_2_LONGGOP H.265(4:2:2) LongGOP
<model>_MOVIE_FORMAT_PRORESHQ ProResHQ
<model>_MOVIE_FORMAT_PRORES ProRes
<model>_MOVIE_FORMAT_PRORESLT^ ProResLT^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieFileFormat, SetMovieFileFormat
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.40. CapMovieMediaRecordProRes
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3
**Description**
Queries supported PROXY SETTING settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieMediaRecordProRes
lAPIParam (IN) <model>_API_PARAM_CapMovieMediaRecordProRes
plNum (OUT) Returns the number of “SetMovieMediaRecordProRes” settings supported.
plSetting (OUT)
<model>_MOVIE_MEDIARECORD_PRORES_OFF OFF
<model>_MOVIE_MEDIARECORD_PRORES_H264 ON H264
<model>_MOVIE_MEDIARECORD_PRORES_PROXY^ ON Pro Res Proxy^
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieMediaRecordProRes, GetMovieMediaRecordProRes
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.41. SetMovieMediaRecordProRes
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3
**Description**
Sets the PROXY SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieMediaRecordProRes
lAPIParam (IN) <model>_API_PARAM_SetMovieMediaRecordProRes
lSetting (IN)
<model>_MOVIE_MEDIARECORD_PRORES_OFF OFF
<model>_MOVIE_MEDIARECORD_PRORES_H264 ON H264
<model>_MOVIE_MEDIARECORD_PRORES_PROXY^ ON Pro Res Proxy^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieMediaRecordProRes, GetMovieMediaRecordProRes
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.42. GetMovieMediaRecordProRes
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3
**Description**
Gets the PROXY SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieMediaRecordProRes
lAPIParam (IN) <model>_API_PARAM_GetMovieMediaRecordProRes
plSetting (OUT)
<model>_MOVIE_MEDIARECORD_PRORES_OFF OFF
<model>_MOVIE_MEDIARECORD_PRORES_H264 ON H264
<model>_MOVIE_MEDIARECORD_PRORES_PROXY^ ON Pro Res Proxy^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieMediaRecordProRes, SetMovieMediaRecordProRes
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.43. GetMediaEjectWarning
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the media eject warning information.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMediaEjectWarning
lAPIParam (IN) <model>_API_ PARAM _GetMediaEjectWarning
ulWarning (OUT) Media eject warning value.
[H2S/H2/T5]
<model>_MEDIA_EJECT_WARNING_SLOT1 SLOT1
<model>_MEDIA_EJECT_WARNING_SLOT 2 SLOT2
[S20]
<model>_MEDIA_EJECT_WARNING_SLOT1 SLOT1
[GFX100II/GFX100SII]
<model>_MEDIA_EJECT_WARNING_SLOT1 SLOT1
<model>_MEDIA_EJECT_WARNING_SLOT 2 SLOT2
<model>_MEDIA_EJECT_WARNING_SLOT 3 SLOT3
**Remarks**
This function can be used in State S3.
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
unsigned long* ulWarning
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**See Also**
None


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.44. CapMovieHDMIOutputInfoDisplay
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported HDMI OUTPUT INFO DISPLAY settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapMovieHDMIOutputInfoDisplay
lAPIParam (IN) <model>_API_PARAM_ CapMovieHDMIOutputInfoDisplay
plNum (OUT) Returns the number of “SetMovieHDMIOutputInfoDisplay” settings supported.
plSetting (OUT)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieHDMIOutputInfoDisplay, GetMovieHDMIOutputInfoDisplay
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.45. SetMovieHDMIOutputInfoDisplay
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3
**Description**
Sets the HDMI OUTPUT INFO DISPLAY setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetMovieHDMIOutputInfoDisplay
lAPIParam (IN) <model>_API_PARAM_ SetMovieHDMIOutputInfoDisplay
lSetting (IN)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieHDMIOutputInfoDisplay, GetMovieHDMIOutputInfoDisplay
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.46. GetMovieHDMIOutputInfoDisplay
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the HDMI OUTPUT INFO DISPLAY setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetMovieHDMIOutputInfoDisplay
lAPIParam (IN) <model>_API_PARAM_ GetMovieHDMIOutputInfoDisplay
plSetting (OUT) See lSetting of “SetMovieHDMIOutputInfoDisplay”.
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieHDMIOutputInfoDisplay, SetMovieHDMIOutputInfoDisplay
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.47. CapMovieHDMIRecControl
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported HDMI REC CONTROL settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapMovieHDMIRecControl
lAPIParam (IN) <model>_API_PARAM_ CapMovieHDMIRecControl
plNum (OUT) Returns the number of “SetMovieHDMIRecControl” settings supported.
plSetting (OUT)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieHDMIRecControl, GetMovieHDMIRecControl
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.48. SetMovieHDMIRecControl
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the HDMI REC CONTROL setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetMovieHDMIRecControl
lAPIParam (IN) <model>_API_PARAM_ SetMovieHDMIRecControl
lSetting (IN)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieHDMIRecControl , GetMovieHDMIRecControl
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.49. GetMovieHDMIRecControl
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the HDMI REC CONTROL setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetMovieHDMIRecControl
lAPIParam (IN) <model>_API_PARAM_GetMovieHDMIRecControl
plSetting (OUT) See lSetting of “SetMovieHDMIRecControl”.
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieHDMIRecControl , SetMovieHDMIRecControl
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.50. CapMovieHDMIOutputRAW
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported RAW OUTPUT SETTING settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieHDMIOutputRAW
lAPIParam (IN) <model>_API_PARAM_CapMovieHDMIOutputRAW
plNum (OUT) Returns the number of “SetMovieHDMIOutputRAW” settings supported.
plSetting (OUT)
<model>_MOVIE_HDMI_OUTPUT_RAW_OFF OFF
<model>_MOVIE_HDMI_OUTPUT_RAW_AT O M O S ON ATOMOS
<model>_MOVIE_HDMI_OUTPUT_RAW_BLACKMAGIC^ ON Blackmagic^
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieHDMIOutputRAW, GetMovieHDMIOutputRAW
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.51. SetMovieHDMIOutputRAW
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the RAW OUTPUT SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieHDMIOutputRAW
lAPIParam (IN) <model>_API_PARAM_SetMovieHDMIOutputRAW
lSetting (IN)
<model>_MOVIE_HDMI_OUTPUT_RAW_OFF OFF
<model>_MOVIE_HDMI_OUTPUT_RAW_AT O M O S ON ATOMOS
<model>_MOVIE_HDMI_OUTPUT_RAW_BLACKMAGIC^ ON Blackmagic^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieHDMIOutputRAW, GetMovieHDMIOutputRAW
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.52. GetMovieHDMIOutputRAW
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the RAW OUTPUT SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieHDMIOutputRAW
lAPIParam (IN) <model>_API_PARAM_GetMovieHDMIOutputRAW
plSetting (OUT)
<model>_MOVIE_HDMI_OUTPUT_RAW_OFF OFF
<model>_MOVIE_HDMI_OUTPUT_RAW_AT O M O S ON ATOMOS
<model>_MOVIE_HDMI_OUTPUT_RAW_BLACKMAGIC^ ON Blackmagic^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieHDMIOutputRAW, SetMovieHDMIOutputRAW
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.53. CapMovieHDMIOutputRAWResolution
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported RAW OUTPUT SETTING settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieHDMIOutputRAWResolution
lAPIParam (IN) <model>_API_PARAM_CapMovieHDMIOutputRAWResolution
plNum (OUT) Returns the number of “SetMovieHDMIOutputRAWResolution” settings supported.
plSetting (OUT)
<model>_MOVIE_HDMI_OUTPUT_RESOLUTION_4P8K 4 .8K
<model>_MOVIE_HDMI_OUTPUT_RESOLUTION_ 6 P 2 K 6 .2K
<model>_MOVIE_HDMI_OUTPUT_RESOLUTION_8K 8 K
<model>_MOVIE_HDMI_OUTPUT_RESOLUTION_ 5 P 2 K 5 .2K
<model>_MOVIE_HDMI_OUTPUT_RESOLUTION_4K 4 K
<model>_MOVIE_HDMI_OUTPUT_RESOLUTION_DCI_8K^ DCI 8K^
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieHDMIOutputRAWResolution, GetMovieHDMIOutputRAWResolution
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.54. SetMovieHDMIOutputRAWResolution
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the RAW OUTPUT SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieHDMIOutputRAWResolution
lAPIParam (IN) <model>_API_PARAM_SetMovieHDMIOutputRAWResolution
lSetting (IN)
<model>_MOVIE_HDMI_OUTPUT_RESOLUTION_4P8K 4 .8K
<model>_MOVIE_HDMI_OUTPUT_RESOLUTION_ 6 P 2 K 6 .2K
<model>_MOVIE_HDMI_OUTPUT_RESOLUTION_8K 8 K
<model>_MOVIE_HDMI_OUTPUT_RESOLUTION_ 5 P 2 K 5 .2K
<model>_MOVIE_HDMI_OUTPUT_RESOLUTION_4K 4 K
<model>_MOVIE_HDMI_OUTPUT_RESOLUTION_DCI_8K^ DCI 8K^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieHDMIOutputRAWResolution, GetMovieHDMIOutputRAWResolution
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.55. GetMovieHDMIOutputRAWResolution
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the RAW OUTPUT SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieHDMIOutputRAWResolution
lAPIParam (IN) <model>_API_PARAM_GetMovieHDMIOutputRAWResolution
plSetting (OUT)
<model>_MOVIE_HDMI_OUTPUT_RESOLUTION_4P8K 4 .8K
<model>_MOVIE_HDMI_OUTPUT_RESOLUTION_ 6 P 2 K 6 .2K
<model>_MOVIE_HDMI_OUTPUT_RESOLUTION_8K 8 K
<model>_MOVIE_HDMI_OUTPUT_RESOLUTION_ 5 P 2 K 5 .2K
<model>_MOVIE_HDMI_OUTPUT_RESOLUTION_4K 4 K
<model>_MOVIE_HDMI_OUTPUT_RESOLUTION_DCI_8K^ DCI 8K^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieHDMIOutputRAWResolution, SetMovieHDMIOutputRAWResolution
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.56. CapMovieHDMIOutputRAWFrameRate
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported RAW OUTPUT SETTING settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieHDMIOutputRAWFrameRate
lAPIParam (IN) <model>_API_PARAM_CapMovieHDMIOutputRAWFrameRate
plNum (OUT) Returns the number of “SetMovieHDMIOutputRAWFrameRate” settings supported.
plSetting (OUT)
<model>_MOVIE_HDMI_OUTPUT_FRAMERATE_59_94P 5 9.94P
<model>_MOVIE_HDMI_OUTPUT_FRAMERATE_5 0 P 5 0P
<model>_MOVIE_HDMI_OUTPUT_FRAMERATE_ 2 9_9 7 P 2 9.97P
<model>_MOVIE_HDMI_OUTPUT_FRAMERATE_ 2 5P 2 5P
<model>_MOVIE_HDMI_OUTPUT_FRAMERATE_ 2 4P 2 4P
<model>_MOVIE_HDMI_OUTPUT_FRAMERATE_^23 _9^8 P^2 3.98P^
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieHDMIOutputRAWFrameRate, GetMovieHDMIOutputRAWFrameRate
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.57. SetMovieHDMIOutputRAWFrameRate
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the RAW OUTPUT SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieHDMIOutputRAWFrameRate
lAPIParam (IN) <model>_API_PARAM_SetMovieHDMIOutputRAWFrameRate
lSetting (IN)
<model>_MOVIE_HDMI_OUTPUT_FRAMERATE_59_94P 5 9.94P
<model>_MOVIE_HDMI_OUTPUT_FRAMERATE_5 0 P 5 0P
<model>_MOVIE_HDMI_OUTPUT_FRAMERATE_ 2 9_9 7 P 2 9.97P
<model>_MOVIE_HDMI_OUTPUT_FRAMERATE_ 2 5P 2 5P
<model>_MOVIE_HDMI_OUTPUT_FRAMERATE_ 2 4P 2 4P
<model>_MOVIE_HDMI_OUTPUT_FRAMERATE_^23 _9^8 P^2 3.98P^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieHDMIOutputRAWFrameRate, GetMovieHDMIOutputRAWFrameRate
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.58. GetMovieHDMIOutputRAWFrameRate
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the RAW OUTPUT SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieHDMIOutputRAWFrameRate
lAPIParam (IN) <model>_API_PARAM_GetMovieHDMIOutputRAWFrameRate
plSetting (OUT)
<model>_MOVIE_HDMI_OUTPUT_FRAMERATE_59_94P 5 9.94P
<model>_MOVIE_HDMI_OUTPUT_FRAMERATE_5 0 P 5 0P
<model>_MOVIE_HDMI_OUTPUT_FRAMERATE_ 2 9_9 7 P 2 9.97P
<model>_MOVIE_HDMI_OUTPUT_FRAMERATE_ 2 5P 2 5P
<model>_MOVIE_HDMI_OUTPUT_FRAMERATE_ 2 4P 2 4P
<model>_MOVIE_HDMI_OUTPUT_FRAMERATE_^23 _9^8 P^2 3.98P^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieHDMIOutputRAWFrameRate, SetMovieHDMIOutputRAWFrameRate
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.59. CapMovieCropMagnification
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported FIX MOVIE CROP MAGNIFICATION settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapMovieCropMagnification
lAPIParam (IN) <model>_API_PARAM_ CapMovieCropMagnification
plNum (OUT) Returns the number of “SetMovieCropMagnification” settings supported.
plSetting (OUT)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieCropMagnification, GetMovieCropMagnification
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.60. SetMovieCropMagnification
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the FIX MOVIE CROP MAGNIFICATION setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetMovieCropMagnification
lAPIParam (IN) <model>_API_PARAM_ SetMovieCropMagnification
lSetting (IN)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieCropMagnification, GetMovieCropMagnification
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.61. GetMovieCropMagnification
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the FIX MOVIE CROP MAGNIFICATION setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetMovieCropMagnification
lAPIParam (IN) <model>_API_PARAM_ GetMovieCropMagnification
plSetting (OUT) See lSetting of “SetMovieCropMagnification”.
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieCropMagnification, SetMovieCropMagnification
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.62. GetMovieCropMagnificationValue
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the MOVIE CROP MAGNIFICAION VALUE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieCropMagnificationValue
lAPIParam (IN) <model>_API_PARAM_GetMovieCropMagnificationValue
plSetting (OUT) The obtained video crop magnification value.
**Remarks**
This function can be used in State S3.
**See Also**
None.
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plValue
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.63. CapFlogRecording
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported F-Log/HLG RECODING settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapFlogRecording
lAPIParam (IN) <model>_API_PARAM_CapFlogRecording
plNum (OUT) Returns the number of “SetFlogRecording” settings supported.
plSetting (OUT)
<model>_MOVIERECORD_MEDIA_FSIM_HDMI_FSIM Media1：Fsim
HDMI：Fsim
<model>_MOVIERECORD_MEDIA_FLOG_HDMI_FLOG Media1：F-Log
HDMI：F-Log
<model>_MOVIERECORD_MEDIA_FLOG2_HDMI_FLOG2 Media1：F-Log2
HDMI：F-Log2
<model>_MOVIERECORD_MEDIA_FSIM_HDMI_FLOG Media1：Fsim
HDMI：F-Log
<model>_MOVIERECORD_MEDIA_FSIM_HDMI_FLOG 2 Media1：Fsim
HDMI：F-Log2
<model>_MOVIERECORD_MEDIA_FLOG_HDMI_FSIM Media1：F-Log
HDMI：Fsim
<model>_MOVIERECORD_MEDIA_FLOG 2 _HDMI_FSIM Media1：F-Log2
HDMI：Fsim
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_MOVIERECORD_MEDIA_HLG_HDMI_HLG Media1：HLG

##### 

**Remarks**
This function can be used in State S3.
**See Also**
SetFlogRecording, GetFlogRecording


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.64. SetFlogRecording
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the F-Log/HLG RECODING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetFlogRecording
lAPIParam (IN) <model>_API_PARAM_SetFlogRecording
lSetting (IN)
<model>_MOVIERECORD_MEDIA_FSIM_HDMI_FSIM Media1：Fsim
HDMI：Fsim
<model>_MOVIERECORD_MEDIA_FLOG_HDMI_FLOG Media1：F-Log
HDMI：F-Log
<model>_MOVIERECORD_MEDIA_FLOG2_HDMI_FLOG2 Media1：F-Log2
HDMI：F-Log2
<model>_MOVIERECORD_MEDIA_FSIM_HDMI_FLOG Media1：Fsim
HDMI：F-Log
<model>_MOVIERECORD_MEDIA_FSIM_HDMI_FLOG 2 Media1：Fsim
HDMI：F-Log2
<model>_MOVIERECORD_MEDIA_FLOG_HDMI_FSIM Media1：F-Log
HDMI：Fsim
<model>_MOVIERECORD_MEDIA_FLOG 2 _HDMI_FSIM Media1：F-Log2
HDMI：Fsim
<model>_MOVIERECORD_MEDIA_HLG_HDMI_HLG Media1：HLG

##### 

```
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**Remarks**
This function can be used in State S3.
**See Also**
CapFlogRecording, GetFlogRecording


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.65. GetFlogRecording
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the F-Log/HLG RECODING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetFlogRecording
lAPIParam (IN) <model>_API_PARAM_GetFlogRecording
plSetting (OUT)
<model>_MOVIERECORD_MEDIA_FSIM_HDMI_FSIM Media1：Fsim
HDMI：Fsim
<model>_MOVIERECORD_MEDIA_FLOG_HDMI_FLOG Media1：F-Log
HDMI：F-Log
<model>_MOVIERECORD_MEDIA_FLOG2_HDMI_FLOG2 Media1：F-Log2
HDMI：F-Log2
<model>_MOVIERECORD_MEDIA_FSIM_HDMI_FLOG Media1：Fsim
HDMI：F-Log
<model>_MOVIERECORD_MEDIA_FSIM_HDMI_FLOG 2 Media1：Fsim
HDMI：F-Log2
<model>_MOVIERECORD_MEDIA_FLOG_HDMI_FSIM Media1：F-Log
HDMI：Fsim
<model>_MOVIERECORD_MEDIA_FLOG 2 _HDMI_FSIM Media1：F-Log2
HDMI：Fsim
<model>_MOVIERECORD_MEDIA_HLG_HDMI_HLG Media1：HLG

##### 

```
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**Remarks**
This function can be used in State S3.
**See Also**
CapFlogRecording, SetFlogRecording


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.66. CapMovieDataLevelSetting
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported DATA LEVEL SETTING settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieDataLevelSetting
lAPIParam (IN) <model>_API_PARAM_CapMovieDataLevelSetting
plNum (OUT) Returns the number of “SetMovieDataLevelSetting” settings supported.
plSetting (OUT)
<model>_MOVIE_DATA_LEVEL_SETTING_FULL Full
<model>_MOVIE_DATA_LEVEL_SETTING_VIDEO^ Video^
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieDataLevelSetting、GetMovieDataLevelSetting
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.67. SetMovieDataLevelSetting
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the DATA LEVEL SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieDataLevelSetting
lAPIParam (IN) <model>_API_PARAM_SetMovieDataLevelSetting
lSetting (IN)
<model>_MOVIE_DATA_LEVEL_SETTING_FULL Full
<model>_MOVIE_DATA_LEVEL_SETTING_VIDEO Video
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieDataLevelSetting、GetMovieDataLevelSetting
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.68. GetMovieDataLevelSetting
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the DATA LEVEL SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieDataLevelSetting
lAPIParam (IN) <model>_API_PARAM_GetMovieDataLevelSetting
plSetting (OUT)
<model>_MOVIE_DATA_LEVEL_SETTING_FULL Full
<model>_MOVIE_DATA_LEVEL_SETTING_VIDEO Video
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieDataLevelSetting、GetMovieDataLevelSetting
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.69. CapMovieHighFrequencyFlickerlessMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported FLICKERLESS S.S. SETTING settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieHighFrequencyFlickerlessMode
lAPIParam (IN) <model>_API_PARAM_CapMovieHighFrequencyFlickerlessMode
plNum (OUT) Returns the number of “SetMovieHighFrequencyFlickerlessMode”
settings supported.
plMode (OUT)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieHighFrequencyFlickerlessMode, GetMovieHighFrequencyFlickerlessMode
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.70. SetMovieHighFrequencyFlickerlessMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the FLICKERLESS S.S. SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieHighFrequencyFlickerlessMode
lAPIParam (IN) <model>_API_PARAM_SetMovieHighFrequencyFlickerlessMode
lMode (IN)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieHighFrequencyFlickerlessMode, GetMovieHighFrequencyFlickerlessMode
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.71. GetMovieHighFrequencyFlickerlessMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the FLICKERLESS S.S. SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieHighFrequencyFlickerlessMode
lAPIParam (IN) <model>_API_PARAM_GetMovieHighFrequencyFlickerlessMode
plMode (OUT) See lMode of “SetMovieHighFrequencyFlickerlessMode”.
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieHighFrequencyFlickerlessMode, SetMovieHighFrequencyFlickerlessMode
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.72. CapMovieIsMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported IS MODE settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapMovieIsMode
lAPIParam (IN) <model>_API_PARAM_ CapMovieIsMode
plNum (OUT) Returns the number of “SetMovieIsMode” settings supported.
plSetting (OUT)
<model>_ MOVIE_IS_MODE_OFF OFF
<model>_ MOVIE_IS_MODE_ON ON
<model>_ MOVIE_IS_MODE_IBIS_OIS ON(IBIS/OIS)
<model>_ MOVIE_IS_MODE_IBIS_OIS_DIS ON(IBIS/OIS + DIS)
<model>_MOVIE_IS_MODE_OIS ON(OIS)
<model>_MOVIE_IS_MODE_OIS_DIS^ ON(OIS + DIS)^
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieIsMode, GetMovieIsMode
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.73. SetMovieIsMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the IS MODE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetMovieIsMode
lAPIParam (IN) <model>_API_PARAM_ SetMovieIsMode
lSetting (IN)
<model>_ MOVIE_IS_MODE_OFF OFF
<model>_ MOVIE_IS_MODE_ON ON
<model>_ MOVIE_IS_MODE_IBIS_OIS ON(IBIS/OIS)
<model>_ MOVIE_IS_MODE_IBIS_OIS_DIS ON(IBIS/OIS + DIS)
<model>_MOVIE_IS_MODE_OIS ON(OIS)
<model>_MOVIE_IS_MODE_OIS_DIS^ ON(OIS + DIS)^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieIsMode, GetMovieIsMode
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.74. GetMovieIsMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the IS MODE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetMovieIsMode
lAPIParam (IN) <model>_API_PARAM_ GetMovieIsMode
plSetting (OUT) See lSetting of “SetMovieIsMode”.
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieIsMode, SetMovieIsMode
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.75. CapMovieIsModeBoost
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported IS MODE BOOST settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapMovieIsModeBoost
lAPIParam (IN) <model>_API_PARAM_ CapMovieIsModeBoost
plNum (OUT) Returns the number of “SetMovieIsModeBoost” settings supported.
plSetting (OUT)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieIsModeBoost, GetMovieIsModeBoost
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.76. SetMovieIsModeBoost
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the IS MODE BOOST setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetMovieIsModeBoost
lAPIParam (IN) <model>_API_PARAM_ SetMovieIsModeBoost
lSetting (IN)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieIsModeBoost, GetMovieIsModeBoost
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.77. GetMovieIsModeBoost
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the IS MODE BOOST setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetMovieIsModeBoost
lAPIParam (IN) <model>_API_PARAM_ GetMovieIsModeBoost
plSetting (OUT) See lSetting of “SetMovieIsModeBoost”.
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieIsModeBoost, SetMovieIsModeBoost
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.78. CapMovieZebraSetting
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported ZEBRA SETTING settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapMovieZebraSetting
lAPIParam (IN) <model>_API_PARAM_ CapMovieZebraSetting
plNum (OUT) Returns the number of “SetMovieZebraSetting” settings supported.
plSetting (OUT)
<model>_ MOVIE_ZEBRA_SETTING_OFF OFF
<model>_ MOVIE_ZEBRA_SETTING_RIGHT Zebra right
<model>_^ MOVIE_ZEBRA_SETTING_LEFT^ Zebra left^
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieZebraSetting, GetMovieZebraSetting
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.79. SetMovieZebraSetting
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the ZEBRA SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetMovieZebraSetting
lAPIParam (IN) <model>_API_PARAM_ SetMovieZebraSetting
lSetting (IN)
<model>_ MOVIE_ZEBRA_SETTING_OFF OFF
<model>_ MOVIE_ZEBRA_SETTING_RIGHT Zebra right
<model>_^ MOVIE_ZEBRA_SETTING_LEFT^ Zebra left^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieZebraSetting, GetMovieZebraSetting
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.80. GetMovieZebraSetting
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the ZEBRA SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetMovieZebraSetting
lAPIParam (IN) <model>_API_PARAM_ GetMovieZebraSetting
plSetting (OUT) See lSetting of “SetMovieZebraSetting”.
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieZebraSetting, SetMovieZebraSetting
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.81. CapMovieZebraLevel
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX
50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported ZEBRA LEVEL settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapMovieZebraLevel
lAPIParam (IN) <model>_API_PARAM_ CapMovieZebraLevel
plNum (OUT) Returns the number of “SetMovieZebraLevel” settings supported.
plSetting (OUT)
50 50%
55 55%
60 60%
65 6 5%
70 7 0%
75 7 5%
80 8 0%
85 8 5%
90 9 0%
95 9 5%
100 1 00%^
**Remarks**
This function can be used in State S3.
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**See Also**
SetMovieZebraLevel, SetMovieZebraLevel


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.82. SetMovieZebraLevel
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the ZEBRA LEVEL setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetMovieZebraLevel
lAPIParam (IN) <model>_API_PARAM_ SetMovieZebraLevel
lSetting (IN)
50 50%
55 55%
60 60%
65 6 5%
70 7 0%
75 7 5%
80 8 0%
85 8 5%
90 9 0%
95 9 5%
100 1 00%^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieZebraLevel, GetMovieZebraLevel
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.83. GetMovieZebraLevel
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the ZEBRA LEVEL setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetMovieZebraLevel
lAPIParam (IN) <model>_API_PARAM_ GetMovieZebraLevel
plSetting (OUT) See lSetting of “SetMovieZebraLevel”.
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieZebraLevel, SetMovieZebraLevel
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.84. CapWaveFormVectorScope
Supported Cameras
X-
T1
X-
T2
X-
T3
X-
T4
X-
T5
X-
Pro2
X-
Pro3
X-
S10
X-
H2S
X-
H2
X-
S20
X-
M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
^3^^3^^3^^3^
**Description**
Queries supported WAVE FORM/VECTOR SCOPE settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapWaveFormVectorScope
lAPIParam (IN) <model>_API_PARAM_CapWaveFormVectorScope
plNum (OUT) Returns the number of “SetWaveFormVectorScope” settings supported.
plSetting (OUT)
<model>_WAVEFORM_VECTORSCOPE_OFF OFF
<model>_WAVEFORM_VECTORSCOPE_WAVEFORM Waveform
<model>_WAVEFORM_VECTORSCOPE_PARADE Parade
<model>_WAVEFORM_VECTORSCOPE_VECTORSCOPE^ Vectorscope^
**Remarks**
This function can be used in State S3.
**See Also**
SetWaveFormVectorScope, GetWaveFormVectorScope
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.85. SetWaveFormVectorScope
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Sets the WAVE FORM/VECTOR SCOPE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetWaveFormVectorScope
lAPIParam (IN) <model>_API_PARAM_SetWaveFormVectorScope
lSetting (IN)
<model>_WAVEFORM_VECTORSCOPE_OFF OFF
<model>_WAVEFORM_VECTORSCOPE_WAVEFORM Waveform
<model>_WAVEFORM_VECTORSCOPE_PARADE Parade
<model>_WAVEFORM_VECTORSCOPE_VECTORSCOPE^ Vectorscope^
**Remarks**
This function can be used in State S3.
**See Also**
CapWaveFormVectorScope, GetWaveFormVectorScope
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.86. GetWaveFormVectorScope
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Get the WAVE FORM/VECTOR SCOPE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetWaveFormVectorScope
lAPIParam (IN) <model>_API_PARAM_GetWaveFormVectorScope
plSetting (OUT)
<model>_WAVEFORM_VECTORSCOPE_OFF OFF
<model>_WAVEFORM_VECTORSCOPE_WAVEFORM Waveform
<model>_WAVEFORM_VECTORSCOPE_PARADE Parade
<model>_WAVEFORM_VECTORSCOPE_VECTORSCOPE^ Vectorscope^
**Remarks**
This function can be used in State S3.
**See Also**
CapWaveFormVectorScope, SetWaveFormVectorScope
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.87. GetWaveFormData
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Get the WaveForm data.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetFocusMapData
lAPIParam (IN) <model>_API_PARAM_GetFocusMapData
plSize (OUT) Returns the waveform monitor data size
pData (OUT) Returns the waveform monitor data
**Remarks**
This function can be used in State S3.
**See Also**
None
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSize
unsigned char* pData
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.88. GetVectorScopeData
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Gets the VECTOR SCOPE data.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetVectorScopeData
lAPIParam (IN) <model>_API_PARAM_GetVectorScopeData
plSize (OUT) Returns the vector scope data size
pData (OUT) Returns the vector scope data
**Remarks**
This function can be used in State S3.
**See Also**
None
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSize
unsigned char* pData
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.89. GetParadeData
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX
50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Gets the PA R A D E data.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetParadeData
lAPIParam (IN) <model>_API_PARAM_GetParadeData
plSize (OUT) Returns the parade data size
pData (OUT) Returns the parade data
**Remarks**
This function can be used in State S3.
**See Also**
None
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSize
unsigned char* pData
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.90. CapWaveFormSetting
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Queries supported WAV EFORM settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapWaveFormSetting
lAPIParam (IN) <model>_API_PARAM_CapWaveFormSetting
plNum (OUT) Returns the number of “SetWaveFormSetting” settings supported.
plSetting (OUT)
<model>_WAVEFORM_SETTING_PATTERN1 PATTERN1
<model>_WAVEFORM_SETTING_PATTERN 2 PATTERN 2
<model>_WAVEFORM_SETTING_PATTERN 3 PATTERN 3
<model>_WAVEFORM_SETTING_PATTERN^4 PATTERN^4
**Remarks**
This function can be used in State S3.
**See Also**
SetWaveFormSetting, GetWaveFormSetting
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.91. SetWaveFormSetting
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Sets the WAV EFORM setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetWaveFormSetting
lAPIParam (IN) <model>_API_PARAM_SetWaveFormSetting
lSetting (IN)
<model>_WAVEFORM_SETTING_PATTERN1 PATTERN1
<model>_WAVEFORM_SETTING_PATTERN 2 PATTERN 2
<model>_WAVEFORM_SETTING_PATTERN 3 PATTERN 3
<model>_WAVEFORM_SETTING_PATTERN^4 PATTERN^4
**Remarks**
This function can be used in State S3.
**See Also**
CapWaveFormSetting, GetWaveFormSetting
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.92. GetWaveFormSetting
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Gets the WAV EFORM setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetWaveFormSetting
lAPIParam (IN) <model>_API_PARAM_GetWaveFormSetting
plSetting (OUT)
<model>_WAVEFORM_SETTING_PATTERN1 PATTERN1
<model>_WAVEFORM_SETTING_PATTERN 2 PATTERN 2
<model>_WAVEFORM_SETTING_PATTERN 3 PATTERN 3
<model>_WAVEFORM_SETTING_PATTERN^4 PATTERN^4
**Remarks**
This function can be used in State S3.
**See Also**
CapWaveFormSetting, SetWaveFormSetting
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.93. CapVectorScopeSetting
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Queries supported VECTORSCOPE settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapVectorScopeSetting
lAPIParam (IN) <model>_API_PARAM_CapVectorScopeSetting
plNum (OUT) Returns the number of “SetVectorScopeSetting” settings supported.
plSetting (OUT)
<model>_VECTORSCORE_SETTING_PATTERN1 PATTERN1
<model>_VECTORSCORE_SETTING_PATTERN 2 PATTERN 2
<model>_VECTORSCORE_SETTING_PATTERN 3 PATTERN 3
<model>_VECTORSCORE_SETTING_PATTERN^4 PATTERN^4
**Remarks**
This function can be used in State S3.
**See Also**
SetVectorScopeSetting, GetVectorScopeSetting
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* pNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.94. SetVectorScopeSetting
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Sets the VECTORSCOPE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetVectorScopeSetting
lAPIParam (IN) <model>_API_PARAM_SetVectorScopeSetting
lSetting (IN)
<model>_VECTORSCORE_SETTING_PATTERN1 PATTERN1
<model>_VECTORSCORE_SETTING_PATTERN 2 PATTERN 2
<model>_VECTORSCORE_SETTING_PATTERN 3 PATTERN 3
<model>_VECTORSCORE_SETTING_PATTERN^4 PATTERN^4
**Remarks**
This function can be used in State S3.
**See Also**
CapVectorScopeSetting, GetVectorScopeSetting
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.95. GetVectorScopeSetting
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Gets the VECTORSCOPE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetVectorScopeSetting
lAPIParam (IN) <model>_API_PARAM_GetVectorScopeSetting
plSetting (IN)
<model>_VECTORSCORE_SETTING_PATTERN1 PATTERN1
<model>_VECTORSCORE_SETTING_PATTERN 2 PATTERN 2
<model>_VECTORSCORE_SETTING_PATTERN 3 PATTERN 3
<model>_VECTORSCORE_SETTING_PATTERN^4 PATTERN^4
**Remarks**
This function can be used in State S3.
**See Also**
CapVectorScopeSetting, SetVectorScopeSetting
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.96. CapParadeSettingDisplay
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Queries supported PARADE SETTING (SWICH DISP.) settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapParadeSettingDisplay
lAPIParam (IN) <model>_API_PARAM_CapParadeSettingDisplay
plNum (OUT) Returns the number of “SetParadeSettingDisplay” settings supported.
plSetting (OUT)
<model>_PARADE_SETTING_DISPLAY_PATTERN1 PATTERN1
<model>_PARADE_SETTING_DISPLAY_PATTERN2 PATTERN 2
<model>_PARADE_SETTING_DISPLAY_PATTERN3 PATTERN 3
<model>_PARADE_SETTING_DISPLAY_PATTERN4^ PATTERN^4
**Remarks**
This function can be used in State S3.
**See Also**
SetParadeSettingDisplay, GetParadeSettingDisplay
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* pNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.97. SetParadeSettingDisplay
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Sets the PARADE SETTING (SWICH DISP.) setting
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetParadeSettingDisplay
lAPIParam (IN) <model>_API_PARAM_SetParadeSettingDisplay
lSetting (IN)
<model>_PARADE_SETTING_DISPLAY_PATTERN1 PATTERN1
<model>_PARADE_SETTING_DISPLAY_PATTERN2 PATTERN 2
<model>_PARADE_SETTING_DISPLAY_PATTERN3 PATTERN 3
<model>_PARADE_SETTING_DISPLAY_PATTERN4^ PATTERN^4
**Remarks**
This function can be used in State S3.
**See Also**
CapParadeSettingDisplay, GetParadeSettingDisplay
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.98. GetParadeSettingDisplay
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Gets the PARADE SETTING (SWICH DISP.) setting
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetParadeSettingDisplay
lAPIParam (IN) <model>_API_PARAM_GetParadeSettingDisplay
plSetting (OUT)
<model>_PARADE_SETTING_DISPLAY_PATTERN1 PATTERN1
<model>_PARADE_SETTING_DISPLAY_PATTERN2 PATTERN 2
<model>_PARADE_SETTING_DISPLAY_PATTERN3 PATTERN 3
<model>_PARADE_SETTING_DISPLAY_PATTERN4^ PATTERN^4
**Remarks**
This function can be used in State S3.
**See Also**
CapParadeSettingDisplay, SetParadeSettingDisplay
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.99. CapParadeSettingColor
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Queries supported PARADE SETTING (COLOR) settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapParadeSettingColor
lAPIParam (IN) <model>_API_PARAM_CapParadeSettingColor
plNum (OUT) Returns the number of “SetParadeSettingColor” settings supported.
plSetting (OUT)
<model>_PARADE_SETTING_COLOR_RGB RGB
<model>_PARADE_SETTING_COLOR_WHITE^ WHITE^
**Remarks**
This function can be used in State S3.
**See Also**
SetParadeSettingColor, GetParadeSettingColor
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* pNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.100. SetParadeSettingColor
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Sets the PARADE SETTING (COLOR) setting
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetParadeSettingColor
lAPIParam (IN) <model>_API_PARAM_SetParadeSettingColor
lSetting (IN)
<model>_PARADE_SETTING_COLOR_RGB RGB
<model>_PARADE_SETTING_COLOR_WHITE^ WHITE^
**Remarks**
This function can be used in State S3.
**See Also**
CapParadeSettingColor, GetParadeSettingColor
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.101. GetParadeSettingColor
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Gets the PARADE SETTING (COLOR) setting
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetParadeSettingColor
lAPIParam (IN) <model>_API_PARAM_GetParadeSettingColor
plSetting (OUT)
<model>_PARADE_SETTING_COLOR_RGB RGB
<model>_PARADE_SETTING_COLOR_WHITE^ WHITE^
**Remarks**
This function can be used in State S3.
**See Also**
CapParadeSettingColor, SetParadeSettingColor
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.102. CapMovieOptimizedControl
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported MOVIE OPTIMIZED MODE settongs.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapMovieOptimizedControl
lAPIParam (IN) <model>_API_PARAM_ CapMovieOptimizedControl
plNum (OUT) Returns the number of “SetMovieOptimizedControl” settings supported.
plSetting (OUT)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieOptimizedControl, GetMovieOptimizedControl
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.103. SetMovieOptimizedControl
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the MOVIE OPTIMIZED MODE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetMovieOptimizedControl
lAPIParam (IN) <model>_API_PARAM_ SetMovieOptimizedControl
lSetting (IN)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieOptimizedControl, GetMovieOptimizedControl
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.104. GetMovieOptimizedControl
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the MOVIE OPTIMIZED MODE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetMovieOptimizedControl
lAPIParam (IN) <model>_API_PARAM_ GetMovieOptimizedControl
plSetting (OUT) See lSetting of “SetMovieOptimizedControl”.
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieOptimizedControl, SetMovieOptimizedControl
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.105. CapRecFrameIndicator
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Queries supported REC FRAME INDICATOR settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapRecFrameIndicator
lAPIParam (IN) <model>_API_PARAM_CapRecFrameIndicator
plNum (OUT) Returns the number of “SetRecFrameIndicator” settings supported.
plSetting (OUT)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
SetRecFrameIndicator, GetRecFrameIndicator
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.106. SetRecFrameIndicator
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Sets the REC FRAME INDICATOR setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetRecFrameIndicator
lAPIParam (IN) <model>_API_PARAM_SetRecFrameIndicator
lSetting (IN)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
CapRecFrameIndicator, GetRecFrameIndicator
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.107. GetRecFrameIndicator
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Get the REC FRAME INDICATOR setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetRecFrameIndicator
lAPIParam (IN) <model>_API_PARAM_GetRecFrameIndicator
plSetting (OUT)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
CapRecFrameIndicator, SetRecFrameIndicator
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.108. CapMovieTallyLight
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported TALLY LAMP settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieTallyLight
lAPIParam (IN) <model>_API_PARAM_CapMovieTallyLight
plNum (OUT) Returns the number of “SetMovieTallyLight” settings supported.
plSetting (OUT) See lSetting of “SetMovieTallyLight”.
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieTallyLight、GetMovieTallyLight
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.109. SetMovieTallyLight
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the TALLY LAMP settng.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieTallyLight
lAPIParam (IN) <model>_API_PARAM_SetMovieTallyLight
lSetting (IN)
<model>_MOVIE_TALLYLIGHT_FRONT_OFF_REAR_ON Front OFF
Rear ON
<model>_MOVIE_TALLYLIGHT_FRONT_OFF_REAR_BLINK Front OFF
Rear Blinking
<model>_MOVIE_TALLYLIGHT_FRONT_ON_REAR_ON Front ON
Rear ON
<model>_MOVIE_TALLYLIGHT_FRONT_ON_REAR_OFF Front ON
Rear OFF
<model>_MOVIE_TALLYLIGHT_FRONT_BLINK_REAR_BLINK Front Blinking
Rear Blinking
<model>_MOVIE_TALLYLIGHT_FRONT_BLINK_REAR_OFF Front Blinking
Rear OFF
<model>_MOVIE_TALLYLIGHT_FRONT_OFF_REAR_OFF Front OFF
Rear OFF^
**Remarks**
This function can be used in State S3.
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**See Also**
CapMovieTallyLight、GetMovieTallyLight


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.110. GetMovieTallyLight
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the TALLY LAMP setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieTallyLight
lAPIParam (IN) <model>_API_PARAM_GetMovieTallyLight
plSetting (OUT) See “SetMovieTallyLight” for supported values.
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieTallyLight、SetMovieTallyLight
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.111. CapFanSetting
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
FX100RFGFX100RF G**
3 3 3 3 3 3 3 3
**Description**
Queries supported COOLING FAN SETTING settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapFanSetting
lAPIParam (IN) <model>_API_PARAM_CapFanSetting
plNum (OUT) Returns the number of “SetFanSetting” settings supported.
plSetting (OUT) See lSetting of “SetFanSetting”.
**Remarks**
This function can be used in State S3.
**See Also**
SetFanSetting
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.112. SetFanSetting
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets COOLING FAN SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetFanSetting
lAPIParam (IN) <model>_API_PARAM_SetFanSetting
lSetting (OUT)
<model>_FAN_SETTING_OFF OFF
<model>_FAN_SETTING_WEAK LOW
<model>_FAN_SETTING_STRONG HIGH
<model>_FAN_SETTING_AUTO1 AUTO1
<model>_FAN_SETTING_AUTO2^ AUTO2^
**Remarks**
This function can be used in State S3.
**See Also**
GetFanSetting
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.113. GetFanSetting
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets COOLING FAN SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetFanSetting
lAPIParam (IN) <model>_API_PARAM_GetFanSetting
plSetting (OUT) See lSetting of “SetFanSetting”.
**Remarks**
This function can be used in State S3.
**See Also**
SetFanSetting
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.114. SetMovieCustomSetting
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the EDIT/SAVE CUSTOM SETTING setting.
**Synta
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieCustomSetting
lAPIParam (IN) <model>_API_PARAM_SetMovieCustomSetting
lCustomSetting (IN)
<model>_ CUSTOM_SELECT Custom settings specified in lDestination
are reflected in the current settings.
<model>_ CUSTOM_SAVE Save the current settings to the
custom settings specified in lDestination.
<model>_ CUSTOM_INIT Initialize custom settings specified
in lDestination.
<model>_ CUSTOM_COPY Copy the custom settings specified
in lSource to the custom settings
specified in lDestination.^
lDestination (IN) Sets Custom Designation Destination.
<model>_ CUSTOM_1 Custom1
<model>_ CUSTOM_ 2 Custom2
<model>_ CUSTOM_ 3 Custom3
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lCustomSetting,
long lDestination
long lSource
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_ CUSTOM_ 4 Custom4
<model>_ CUSTOM_ 5 Custom5
<model>_ CUSTOM_ 6 Custom6
<model>_^ CUSTOM_^7 Custom7^
lSource (IN) Custom settings for specified source. (Use only for copying.)
<model>_ CUSTOM_1 Custom1
<model>_ CUSTOM_ 2 Custom2
<model>_ CUSTOM_ 3 Custom3
<model>_ CUSTOM_ 4 Custom4
<model>_ CUSTOM_ 5 Custom5
<model>_ CUSTOM_ 6 Custom6
<model>_^ CUSTOM_^7 Custom7^
**Remarks**
This function can be used in State S3.
**See Also**
None


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.115. SetMovieCustomName
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the EDIT CUSTOM SETTIMG name.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieCustomName
lAPIParam (IN) <model>_API_PARAM_SetMovieCustomName
lCustomNumber (IN)
<model>_ CUSTOM_1 Custom1
<model>_ CUSTOM_ 2 Custom2
<model>_ CUSTOM_ 3 Custom3
<model>_ CUSTOM_ 4 Custom4
<model>_ CUSTOM_ 5 Custom5
<model>_ CUSTOM_ 6 Custom6
<model>_^ CUSTOM_^7 Custom7^
pCustomName (IN) Set custom registration name for No. set in lCustomNumber.
254 characters + NULL (character limit follows camera specifications).
**Remarks**
This function can be used in State S3.
**See Also**
GetMovieCustomName
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lCustomNumber ,
LSTR pCustomName
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.116. GetMovieCustomName
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the EDIT CUSTOM SETTING name.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieCustomName
lAPIParam (IN) <model>_API_PARAM_GetMovieCustomName
lCustomNumber (IN) See lSetting of “SetMovieCustomName”.
pCustomName (OUT) Get the custom registration name of No. set in lCustomNumber.
254 characters + NULL (character limit follows camera specifications).
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieCustomName
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lCustomNumber ,
LSTR pCustomName
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.117. CapMovieDigitalZoom
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3
**Description**
Queries supported DIGITAL TELE-CONV. settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieDigitalZoom
lAPIParam (IN) <model>_API_PARAM_CapMovieDigitalZoom
plNum (OUT) Returns the number of “SetMovieDigitalZoom” settings supported.
plSetting (OUT) "SetMovieDigitalZoom" List of possible values.
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieDigitalZoom、GetMovieDigitalZoom
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.118. SetMovieDigitalZoom
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3
**Description**
Sets the DIGITAL TELE-CONV. setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieDigitalZoom
lAPIParam (IN) <model>_API_PARAM_SetMovieDigitalZoom
lSetting (IN) Setting value (must be a configurable value obtained with
CapMovieDigitalZoom).
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieDigitalZoom、GetMovieDigitalZoom
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.119. GetMovieDigitalZoom
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3
**Description**
Gets the DIGITAL TELE-CONV. setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieDigitalZoom
lAPIParam (IN) <model>_API_PARAM_GetMovieDigitalZoom
plSetting (OUT) The current setting value obtained.
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieDigitalZoom、GetMovieDigitalZoom
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.120. GetMovieDigitalZoomRange
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3
**Description**
Gets the DIGITAL TELE-CONV. RANGE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieDigitalZoom
lAPIParam (IN) <model>_API_PARAM_GetMovieDigitalZoom
plCurrent (OUT) Current value.
plMin (OUT) Minimum value.
plMax (OUT) Maximum value.
**Remarks**
This function can be used in State S3.
**See Also**
None.
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plCurrent,
long* plMin,
long* plMax
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.121. GetMovieRecordingTime
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the RECORDING TIME.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetMovieRecordingTime
lAPIParam (IN) <model>_API_PARAM_ GetMovieRecordingTime
plHour (OUT) Hour: 0- 23
plMinute (OUT) Minute: 0 - 59
plSecond (OUT) Second: 0- 59
**Remarks**
This function can be used in State S3.
**See Also**
None
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plHour,
long* plMinute,
long* plSecond,
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.122. GetMovieRemainingTime
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the REMAINING TIME.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetMovieRemainingTime
lAPIParam (IN) <model>_API_PARAM_ GetMovieRemainingTime
plHour (OUT) Hour: 0- 23
plMinute (OUT) Minute: 0 - 59
plSecond (OUT) Second: 0- 59
**Remarks**
This function can be used in State S3.
**See Also**
None
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plHour,
long* plMinute,
long* plSecond,
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.123. GetHistogramData
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the HISTOGRAM data.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetHistogramData
lAPIParam (IN) <model>_API_PARAM_GetHistogramData
plSize (OUT) The current setting value obtained.
pulData (OUT) Histogram data obtained from the camera.
The structure of the obtained data is as follows.
typedef struct {
long* lLuminance;
long* lColorR;
long* lColorG;
long* lColorB;
} SDK_HistogramData;
lLuminance:
Luminance.
lColorR:
Red channel intensity.
lColorG:
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSize,
SDK_HistgramData* pulData
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
Green channel intensity.
lColorB:
Blue channel intensity.
**Remarks**
This function can be used in State S3.
**See Also**
None.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.124. GetBodyTemperatureWarning
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3
**Description**
Gets the TEMPERATURE LIMIT information.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetBodyTemperatureWarning
lAPIParam (IN) <model>_API_PARAM_ GetBodyTemperatureWarning
plWarning (OUT)
<model>_BODY_TEMPERATURE_WARNING_NONE None
<model>_BODY_TEMPERATURE_WARNING_YELLOW Caution (Yellow)
<model>_BODY_TEMPERATURE_WARNING_RED^ Warning (Red)^
**Remarks**
This function can be used in State S3.
**See Also**
None
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plWarning
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.125. CapShortMovieSecond
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3
3
**Description**
Queries supported SHORT MOVIE MODE SECONDS SETUP settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapShortMovieSecond
lAPIParam (IN) <model>_API_PARAM_ CapShortMovieSecond
plNum (OUT) Returns the number of “SetShortMovieSecond” settings supported
plSetting (OUT)
<model>_ SHORT_MOVIE_SECOND_OFF OFF
<model>_ SHORT_MOVIE_SECOND_15S 15Second
<model>_ SHORT_MOVIE_SECOND_30S 30Second
<model>_^ SHORT_MOVIE_SECOND_60S^ 60Second^
**Remarks**
This function can be used in State S3.
**See Also**
SetShortMovieSecond ,GetShortMovieSecond
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.126. SetShortMovieSecond
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3
3
**Description**
Sets the SHORT MOVIE MODE SECONDS SETUP setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetShortMovieSecond
lAPIParam (IN) <model>_API_PARAM_ SetShortMovieSecond
lSetting (IN)
<model>_ SHORT_MOVIE_SECOND_OFF OFF
<model>_ SHORT_MOVIE_SECOND_15S 15Second
<model>_ SHORT_MOVIE_SECOND_30S 30Second
<model>_^ SHORT_MOVIE_SECOND_60S^ 60Second^
**Remarks**
This function can be used in State S3.
**See Also**
CapShortMovieSecond ,GetShortMovieSecond
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.127. GetShortMovieSecond
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3
3
**Description**
Gets the SHORT MOVIE MODE SECONDS SETUP setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetShortMovieSecond
lAPIParam (IN) <model>_API_PARAM_ GetShortMovieSecond
plSetting (OUT) See lSetting of “SetShortMovieSecond”.
**Remarks**
This function can be used in State S3.
**See Also**
CapShortMovieSecond ,SetShortMovieSecond
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.17.128. GetMovieTransparentFrameInfo
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3
3
**Description**
Gets the Transparent frame information.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetMovieTransparentFrameInfo
lAPIParam (IN) <model>_API_PARAM_ GetMovieTransparentFrameInfo
pFrameInfo (OUT) Pointer to a structure (SDK_MovieTransparentFrameInfo) table.
typedef struct {
long lX;
long lY;
long lLength_H;
long lLength_V;
long lAlpha;
} SDK_TrackingAfFrameInfo;
lX:
Frame origin position in percent (100%=1024)
lY:
Frame origin position in percent (100%=1024)
lLength_H:
Horizontal line length in percent (100%=1024)
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
<model>_SDK_MovieTransparentFrameInfo* pFrameInfo
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
lLength_V:
Vertical line length in percent (100%=1024)
lAlpha:
Transparency, 0～100(%)
**Remarks**
This function can be used in State S3.
**See Also**
None


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18. Movie Control – IMAGE QUALITY SETTING**
Control the settings that correspond to the following IMAGE QUALITY SETTING menu.
APIs are available only when the STILL/MOVIE mode is in MOVIE mode.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.1. CapMovieFilmSimulationMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported FILM SIMUATION settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieFilmSimulationMode
lAPIParam (IN) <model>_API_PARAM_CapMovieFilmSimulationMode
plNum (OUT) Returns the number of “SetMovieFilmSimulationMode” settings supported.
plSetting (OUT) See lSetting of “SetMovieFilmSimulationMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieFilmSimulationMode、GetMovieFilmSimulationMode
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.2. SetMovieFilmSimulationMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the FILM SIMULATION setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieFilmSimulationMode
lAPIParam (IN) <model>_API_PARAM_SetMovieFilmSimulationMode
lSetting (IN)
<model>_FILMSIMULATION_PROVIA FileSimulation
PROVIA
<model>_FILMSIMULATION_STD FilmSimulation
Standard
<model>_FILMSIMULATION_VELVIA FilmSimulation
VELVIA
<model>_FILMSIMULATION_ASTIA FilmSimulation
ASTIA
<model>_FILMSIMULATION_NEGHI FilmSimulation
Neg.Hi
<model>_FILMSIMULATION_NEGSTD FilmSimulation
Neg.STD
<model>_FILMSIMULATION_MONOCHRO FilmSimulation
Monochrome
<model>_FILMSIMULATION_MONOCHRO_Y FilmSimulation
Monochrome Y
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_FILMSIMULATION_MONOCHRO_R FilmSimulation
Monochrome R
<model>_FILMSIMULATION_MONOCHRO_G FilmSimulation
Monochrome G
<model>_FILMSIMULATION_SEPIA FilmSimulation
Sepia
<model>_FILMSIMULATION_CLASSIC_CHROME FilmSimulation
Classic Chrome
<model>_FILMSIMULATION_ACROS FilmSimulation
ACROS
<model>_FILMSIMULATION_ACROS_Y FilmSimulation
ACROS Y
<model>_FILMSIMULATION_ACROS_R FilmSimulation
ACROS R
<model>_FILMSIMULATION_ACROS_G FilmSimulation
ACROS G
<model>_FILMSIMULATION_ETERNA FilmSimulation
ETERNA
<model>_FILMSIMULATION_CLASSICNEG FilmSimulation
ClassicNeg.
<model>_FILMSIMULATION_BLEACH_BYPASS FilmSimulation
Bleach Bypass
<model>_FILMSIMULATION_NOSTALGICNEG FilmSimulation
Nostalgic Neg.
<model>_FILMSIMULATION_REALA FilmSimulation
REALA
<model>_FILMSIMULATION_AUTO^ FilmSimulation Auto^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieFilmSimulationMode、GetMovieFilmSimulationMode


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.3. GetMovieFilmSimulationMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the FILM SIMULATION setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieFilmSimulationMode
lAPIParam (IN) <model>_API_PARAM_GetMovieFilmSimulationMode
plSetting (OUT) See "SetMovieFilmSimulationMode" for supported values.
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieFilmSimulationMode、SetMovieFilmSimulationMode
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.4. CapMovieMonochromaticColor
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported MONOCHROMATIC COLOR settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieMonochromaticColor
lAPIParam (IN) <model>_API_PARAM_CapMovieMonochromaticColor
plWarmCoolNum (OUT) Returns the number of “lWarnCool” settings supported.
plRedGreenNum (OUT) Returns the number of “lRedGreen” settings supported.
lWarmCool (OUT) See lWarnCool of “SetMovieMonochromaticColor”.
lRedGreen (OUT) See lRedGreen of “SetMovieMonochromaticColor”.
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieMonochromaticColor、GetMovieMonochromaticColor
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plWarmCoolNum,
long* plRedGreenNum,
long* lWarmCool,
long* lRedGreen
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.5. SetMovieMonochromaticColor
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the MONOCHROMATIC COLOR setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieMonochromaticColor
lAPIParam (IN) <model>_API_PARAM_SetMovieMonochromaticColor
lWarmCool (IN)
<model>_MONOCHROMATICCOLOR_WC_P180 180
<model>_MONOCHROMATICCOLOR_WC_P170 170
<model>_MONOCHROMATICCOLOR_WC_P1 60 160
<model>_MONOCHROMATICCOLOR_WC_P1 50 150
<model>_MONOCHROMATICCOLOR_WC_P1 40 140
<model>_MONOCHROMATICCOLOR_WC_P1 30 130
<model>_MONOCHROMATICCOLOR_WC_P1 20 120
<model>_MONOCHROMATICCOLOR_WC_P1 10 110
<model>_MONOCHROMATICCOLOR_WC_P1 00 100
<model>_MONOCHROMATICCOLOR_WC_P 90 90
<model>_MONOCHROMATICCOLOR_WC_P 80 80
<model>_MONOCHROMATICCOLOR_WC_P 70 70
<model>_MONOCHROMATICCOLOR_WC_P 60 60
<model>_MONOCHROMATICCOLOR_WC_P 50 50
<model>_MONOCHROMATICCOLOR_WC_P 40 40
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lWarmCool,
long lRedGreen
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_MONOCHROMATICCOLOR_WC_P 30 30
<model>_MONOCHROMATICCOLOR_WC_P 20 20
<model>_MONOCHROMATICCOLOR_WC_P10 10
<model>_MONOCHROMATICCOLOR_WC_0 0
<model>_MONOCHROMATICCOLOR_WC_M 10 - 10
<model>_MONOCHROMATICCOLOR_WC_M2 0 - 20
<model>_MONOCHROMATICCOLOR_WC_M3 0 - 30
<model>_MONOCHROMATICCOLOR_WC_M4 0 - 40
<model>_MONOCHROMATICCOLOR_WC_M5 0 - 50
<model>_MONOCHROMATICCOLOR_WC_M6 0 - 60
<model>_MONOCHROMATICCOLOR_WC_M7 0 - 70
<model>_MONOCHROMATICCOLOR_WC_M8 0 - 80
<model>_MONOCHROMATICCOLOR_WC_M9 0 - 90
<model>_MONOCHROMATICCOLOR_WC_M10 0 - 100
<model>_MONOCHROMATICCOLOR_WC_M11 0 - 110
<model>_MONOCHROMATICCOLOR_WC_M12 0 - 120
<model>_MONOCHROMATICCOLOR_WC_M13 0 - 130
<model>_MONOCHROMATICCOLOR_WC_M14 0 - 140
<model>_MONOCHROMATICCOLOR_WC_M15 0 - 150
<model>_MONOCHROMATICCOLOR_WC_M16 0 - 160
<model>_MONOCHROMATICCOLOR_WC_M17 0 - 170
<model>_MONOCHROMATICCOLOR_WC_M18^0 -^180
lRedGreen (IN)
<model>_MONOCHROMATICCOLOR_RG_P180 180
<model>_MONOCHROMATICCOLOR_RG_P1 70 170
<model>_MONOCHROMATICCOLOR_RG_P1 60 160
<model>_MONOCHROMATICCOLOR_RG_P1 50 150
<model>_MONOCHROMATICCOLOR_RG_P1 40 140
<model>_MONOCHROMATICCOLOR_RG_P1 30 130
<model>_MONOCHROMATICCOLOR_RG_P1 20 120
<model>_MONOCHROMATICCOLOR_RG_P1 10 110
<model>_MONOCHROMATICCOLOR_RG_P1 00 100
<model>_MONOCHROMATICCOLOR_RG_P 90 90
<model>_MONOCHROMATICCOLOR_RG_P80 80
<model>_MONOCHROMATICCOLOR_RG_P 70 70
<model>_MONOCHROMATICCOLOR_RG_P 60 60
<model>_MONOCHROMATICCOLOR_RG_P 50 50
<model>_MONOCHROMATICCOLOR_RG_P 40 40
<model>_MONOCHROMATICCOLOR_RG_P 30 30


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_MONOCHROMATICCOLOR_RG_P 20 20
<model>_MONOCHROMATICCOLOR_RG_P10 10
<model>_MONOCHROMATICCOLOR_RG_0 0
<model>_MONOCHROMATICCOLOR_RG_M 10 - 10
<model>_MONOCHROMATICCOLOR_RG_M2 0 - 20
<model>_MONOCHROMATICCOLOR_RG_M3 0 - 30
<model>_MONOCHROMATICCOLOR_RG_M4 0 - 40
<model>_MONOCHROMATICCOLOR_RG_M5 0 - 50
<model>_MONOCHROMATICCOLOR_RG_M6 0 - 60
<model>_MONOCHROMATICCOLOR_RG_M7 0 - 70
<model>_MONOCHROMATICCOLOR_RG_M8 0 - 80
<model>_MONOCHROMATICCOLOR_RG_M9 0 - 90
<model>_MONOCHROMATICCOLOR_RG_M 100 - 100
<model>_MONOCHROMATICCOLOR_RG_M1 10 - 110
<model>_MONOCHROMATICCOLOR_RG_M 120 - 120
<model>_MONOCHROMATICCOLOR_RG_M 130 - 130
<model>_MONOCHROMATICCOLOR_RG_M 140 - 140
<model>_MONOCHROMATICCOLOR_RG_M 150 - 150
<model>_MONOCHROMATICCOLOR_RG_M 160 - 160
<model>_MONOCHROMATICCOLOR_RG_M 170 - 170
<model>_MONOCHROMATICCOLOR_RG_M^180 -^180
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieMonochromaticColor、GetMovieMonochromaticColor


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.6. GetMovieMonochromaticColor
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the MONOCHROMATIC COLOR setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieMonochromaticColor
lAPIParam (IN) <model>_API_PARAM_GetMovieMonochromaticColor
plWarnCool (OUT) See lWarnCool of “SetMovieMonochromaticColor”.
plRedGreen (OUT) See lRedGreen of “SetMovieMonochromaticColor”.
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieMonochromaticColor、SetMovieMonochromaticColor
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plWarnCool,
long* plRedGreen
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.7. CapMovieWhiteBalanceTune
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported WHITE BALANCE settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieWhiteBalanceTune
lAPIParam (IN) <model>_API_PARAM_CapMovieWhiteBalanceTune
lWBMode (IN) See "SetMovieWhiteBalanceTune" for supported values.
plTuneR_Min (OUT) Minimum configurable red value.
plTuneB_Min (OUT) Minimum configurable blue value.
plTuneR_Max (OUT) Maximum configurable red value.
plTuneB_Max (OUT) Maximum configurable blue value.
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieWhiteBalanceTune、GetMovieWhiteBalanceTune
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lWBMode,
long* plTuneR_Min,
long* plTuneB_Min.
long* plTuneR_Max,
long* plTuneB_Max
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.8. SetMovieWhiteBalanceTune
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the WHITE BALANCE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieWhiteBalanceTune
lAPIParam (IN) <model>_API_PARAM_SetMovieWhiteBalanceTune
lWBMode (IN)
<model>_WB_AUTO Auto
<model>_WB_AUTO_WHITE_PRIORITY Auto(White Priority)
<model>_WB_AUTO_AMBIENCE_PRIORITY Auto(Ambience
Priority)
<model>_WB_DAYLIGHT Daylight
<model>_WB_INCANDESCENT Incandescent
<model>_WB_UNDER_WATER Underwater
<model>_WB_FLUORESCENT1 Fluorescent light 1
<model>_WB_FLUORESCENT 2 Fluorescent light 2
<model>_WB_FLUORESCENT 3 Fluorescent light 3
<model>_WB_SHADE Shade
<model>_WB_COLORTEMP Color Temperature
<model>_WB_CUSTOM1 Custom1
<model>_WB_CUSTOM 2 Custom 2
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lWBMode,
long lTuneR,
long lTuneB
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
<model>_WB_CUSTOM 3 Custom 3
<model>_WB_CUSTOM 4 Custom 4
<model>_WB_CUSTOM^5 Custom^5
lTuneR (IN) Setting value(Red).
lTuneB (IN) Setting value(Blue).
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieWhiteBalanceTune、GetMovieWhiteBalanceTune


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.9. GetMovieWhiteBalanceTune
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the WHITE BALANCE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieWhiteBalanceTune
lAPIParam (IN) <model>_API_PARAM_GetMovieWhiteBalanceTune
lWBMode (IN) See "SetMovieWhiteBalanceTune" for supported values.
plTuneR (OUT) Getting value(Red).
plTuneB (OUT) Getting value(Blue).
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieWhiteBalanceTune、SetMovieWhiteBalanceTune
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lWBMode,
long* plTuneR,
long* plTuneB
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.10. CapMovieHighLightTone
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3
3 3 3
**Description**
Queries supported TONE CURVE(HIGHLIGHTS) settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieHighLightTone
lAPIParam (IN) <model>_API_PARAM_CapMovieHighLightTone
plNum (OUT) Returns the number of “SetMovieHighLightTone” settings supported.
plSetting (OUT) See lSetting of “SetMovieHighLightTone”.
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieHighLightTone、GetMovieHighLightTone
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.11. SetMovieHighLightTone
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the TONE CURVE(HIGHLIGHTS) setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieHighLightTone
lAPIParam (IN) <model>_API_PARAM_SetMovieHighLightTone
lSetting (IN)
<model>_HIGHLIGHT_TONE_P4 40
<model>_HIGHLIGHT_TONE_P3_5 35
<model>_HIGHLIGHT_TONE_P3 30
<model>_HIGHLIGHT_TONE_P2_5 25
<model>_HIGHLIGHT_TONE_P2 20
<model>_HIGHLIGHT_TONE_P1_5 15
<model>_HIGHLIGHT_TONE_P1 10
<model>_HIGHLIGHT_TONE_P0_5 5
<model>_HIGHLIGHT_TONE_0 0
<model>_HIGHLIGHT_TONE_M0_5 - 5
<model>_HIGHLIGHT_TONE_M1 - 10
<model>_HIGHLIGHT_TONE_M1_5 - 15
<model>_HIGHLIGHT_TONE_M2^ -^20
**Remarks**
This function can be used in State S3.
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**See Also**
CapMovieHighLightTone、GetMovieHighLightTone


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.12. GetMovieHighLightTone
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the TONE CURVE(HIGHLIGHTS) setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieShadowTone
lAPIParam (IN) <model>_API_PARAM_GetMovieHighLightTone
plSetting (OUT) See "SetMovieHighLightTone" for supported values.
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieHighLightTone、SetMovieHighLightTone
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.13. CapMovieShadowTone
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported TONE CURVE(SHADOWS) settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieShadowTone
lAPIParam (IN) <model>_API_PARAM_CapMovieShadowTone
plNum (OUT) Returns the number of “SetMovieShadowTone” settings supported.
plSetting (OUT) See lSetting of “SetMovieShadowTone”.
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieShadowTone、GetMovieShadowTone
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.14. SetMovieShadowTone
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the TONE CURVE(SHADOWS) setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieShadowTone
lAPIParam (IN) <model>_API_PARAM_SetMovieShadowTone
lSetting (IN)
<model>_SHADOW_TONE_P4 40
<model>_SHADOW_TONE_P3_5 35
<model>_SHADOW_TONE_P3 30
<model>_SHADOW_TONE_P2_5 25
<model>_SHADOW_TONE_P2 20
<model>_SHADOW_TONE_P1_5 15
<model>_SHADOW_TONE_P1 10
<model>_SHADOW_TONE_P0_5 5
<model>_SHADOW_TONE_0 0
<model>_SHADOW_TONE_M0_5 - 5
<model>_SHADOW_TONE_M1 - 10
<model>_SHADOW_TONE_M1_5 - 15
<model>_SHADOW_TONE_M2^ -^20
**Remarks**
This function can be used in State S3.
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**See Also**
CapMovieShadowTone、GetMovieShadowTone


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.15. GetMovieShadowTone
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the TONE CURVE(SHADOWS) setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieShadowTone
lAPIParam (IN) <model>_API_PARAM_GetMovieShadowTone
plSetting (OUT) See "SetMovieShadowTone" for supported values.
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieShadowTone、SetMovieShadowTone
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.16. CapMovieColorMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported COLOR settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieColorMode
lAPIParam (IN) <model>_API_PARAM_CapMovieColorMode
plNum (OUT) Returns the number of “SetMovieColorMode” settings supported.
plSetting (OUT) See lSetting of “SetMovieColorMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieColorMode、GetMovieColorMode
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.17. SetMovieColorMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the COLOR setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieColorMode
lAPIParam (IN) <model>_API_PARAM_SetMovieColorMode
lSetting (IN)
<model>_COLOR_P4 40
<model>_COLOR_P3 30
<model>_COLOR_P2 20
<model>_COLOR_P1 10
<model>_COLOR_0 0
<model>_COLOR_M1 10
<model>_COLOR_M 2 20
<model>_COLOR_M 3 30
<model>_COLOR_M^4 40
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieColorMode、GetMovieColorMode
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.18. GetMovieColorMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX
50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the COLOR setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieColorMode
lAPIParam (IN) <model>_API_PARAM_GetMovieColorMode
plSetting (OUT) See "SetMovieColorMode" for supported values.
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieColorMode、SetMovieColorMode
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.19. CapMovieSharpness
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX
50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported SHARPNESS settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieSharpness
lAPIParam (IN) <model>_API_PARAM_CapMovieSharpness
plNum (OUT) Returns the number of “SetMovieSharpness” settings supported.
plSetting (OUT) See lSetting of “SetMovieSharpness”.
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieSharpness、GetMovieSharpness
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.20. SetMovieSharpness
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the SHARPNESS setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieSharpness
lAPIParam (IN) <model>_API_PARAM_SetMovieSharpness
lSetting (IN)
<model>_SHARPNESS_P4 40
<model>_SHARPNESS_P3 30
<model>_SHARPNESS_P2 20
<model>_SHARPNESS_P1 10
<model>_SHARPNESS_0 0
<model>_SHARPNESS_M1 10
<model>_SHARPNESS_M 2 20
<model>_SHARPNESS_M 3 30
<model>_SHARPNESS_M^4 40
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieSharpness、GetMovieSharpness
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.21. GetMovieSharpness
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the SHARPNESS setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieSharpness
lAPIParam (IN) <model>_API_PARAM_GetMovieSharpness
plSetting (OUT) See "SetMovieSharpness" for supported values.
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieSharpness、SetMovieSharpness
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.22. CapMovieNoiseReduction
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported HIGH ISO NR settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieNoiseReduction
lAPIParam (IN) <model>_API_PARAM_CapMovieNoiseReduction
plNum (OUT) Returns the number of “SetMovieNoiseReduction” settings supported.
plSetting (OUT) See lSetting of “Set eReduction”.
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieNoiseReduction、GetMovieNoiseReduction
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.23. SetMovieNoiseReduction
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the HIGH ISO NR setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieNoiseReduction
lAPIParam (IN) <model>_API_PARAM_SetMovieNoiseReduction
lSetting (IN)
<model>_NOISEREDUCTION_P4 0x5000
<model>_NOISEREDUCTION_P3 0x6000
<model>_NOISEREDUCTION_P2 0x0000
<model>_NOISEREDUCTION_P1 0x1000
<model>_NOISEREDUCTION_0 0x2000
<model>_NOISEREDUCTION_M1 0x3000
<model>_NOISEREDUCTION_M 2 0x4000
<model>_NOISEREDUCTION_M 3 0x7000
<model>_NOISEREDUCTION_M^4 0x8000^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieNoiseReduction、GetMovieNoiseReduction
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.24. GetMovieNoiseReduction
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the HIGH ISO NR setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieNoiseReduction
lAPIParam (IN) <model>_API_PARAM_GetMovieNoiseReduction
plSetting (OUT) See "SetMovieNoiseReduction" for supported values.
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieNoiseReduction、SetMovieNoiseReduction
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.25. CapInterFrameNR
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported INTERFRAME NR settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapInterFrameNR
lAPIParam (IN) <model>_API_PARAM_CapInterFrameNR
plNum (OUT) Returns the number of “SetInterFrameNR” settings supported.
plSetting (OUT) See lSetting of “SetInterFrameNR”.
**Remarks**
This function can be used in State S3.
**See Also**
SetInterFrameNR、GetInterFrameNR
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.26. SetInterFrameNR
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the INTERFRAME NR setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetInterFrameNR
lAPIParam (IN) <model>_API_PARAM_SetInterFrameNR
lSetting (IN)
<model>_ON 0x0001
<model>_OFF^ 0x0002^
**Remarks**
This function can be used in State S3.
**See Also**
CapInterFrameNR、GetInterFrameNR
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.27. GetInterFrameNR
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the INTERFRAME NR setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetInterFrameNR
lAPIParam (IN) <model>_API_PARAM_GetInterFrameNR
plSetting (OUT) See "SetInterFrameNR" for supported values.
**Remarks**
This function can be used in State S3.
**See Also**
CapInterFrameNR、SetInterFrameNR
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.28. CapFlogDRangePriority
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3
**Description**
Queries supported F-LOG2 D RANGE PRIORITY settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapFlogDRangePriority
lAPIParam (IN) <model>_API_PARAM_CapFlogDRangePriority
plNum (OUT) Returns the number of “SetFlogDRangePriority” settings supported.
plSetting (OUT)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
SetFlogDRangePriority, GetFlogDRangePriority
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* pNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.29. SetFlogDRangePriority
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3
**Description**
Sets the F-LOG2 D RANGE PRIORITY setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetFlogDRangePriority
lAPIParam (IN) <model>_API_PARAM_SetFlogDRangePriority
lSetting (IN)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
CapFlogDRangePriority, GetFlogDRangePriority
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.30. GetFlogDRangePriority
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3
**Description**
Gets the F-LOG2 D RANGE PRIORITY setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetFlogDRangePriority
lAPIParam (IN) <model>_API_PARAM_GetFlogDRangePriority
plSetting (OUT)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
CapFlogDRangePriority, SetFlogDRangePriority
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.31. CapMoviePeripheralLightCorrection
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported PERIPHERAL LIGHT CORRECTION settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMoviePeripheralLightCorrection
lAPIParam (IN) <model>_API_PARAM_CapMoviePeripheralLightCorrection
plNum (OUT) Returns the number of “SetMoviePeripheralLightCorrection” settings supported.
plSetting (OUT) See lSetting of “SetMoviePeripheralLightCorrection”.
**Remarks**
This function can be used in State S3.
**See Also**
SetMoviePeripheralLightCorrection、GetMoviePeripheralLightCorrection
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.32. SetMoviePeripheralLightCorrection
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the PERIPHERAL LIGHT CORRECTION setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMoviePeripheralLightCorrection
lAPIParam (IN) <model>_API_PARAM_SetMoviePeripheralLightCorrection
lSetting (IN)
<model>_ON 0x0001
<model>_OFF^ 0x0002^
**Remarks**
This function can be used in State S3.
**See Also**
CapMoviePeripheralLightCorrection、GetMoviePeripheralLightCorrection
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.33. GetMoviePeripheralLightCorrection
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the PERIPHERAL LIGHT CORRECTION setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMoviePeripheralLightCorrection
lAPIParam (IN) <model>_API_PARAM_GetMoviePeripheralLightCorrection
plSetting (OUT) See "SetMoviePeripheralLightCorrection" for supported values.
**Remarks**
This function can be used in State S3.
**See Also**
CapMoviePeripheralLightCorrection、SetMoviePeripheralLightCorrection
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.34. CapMoviePortraitEnhancer
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3
**Description**
Queries supported MOVIE BEAUTIFUL SKIN PROCESSING settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapMoviePortraitEnhancer
lAPIParam (IN) <model>_API_PARAM_ CapMoviePortraitEnhancer
plNum (OUT) Returns the number of “SetMoviePortraitEnhancer” settings supported
plMode (OUT)
<model>_ PORTRAIT_ENHANCER_OFF OFF
<model>_ PORTRAIT_ENHANCER_SOFT Weak
<model>_ PORTRAIT_ENHANCER_MEDIUM Medium
<model>_^ PORTRAIT_ENHANCER_HARD^ Strong^
**Remarks**
This function can be used in State S3.
**See Also**
SetMoviePortraitEnhancer,GetShortMovieSecond
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.35. SetMoviePortraitEnhancer
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3
**Description**
Sets the MOVIE BEAUTIFUL SKIN PROCESSING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetMoviePortraitEnhancer
lAPIParam (IN) <model>_API_PARAM_ SetMoviePortraitEnhancer
lMode (IN)
<model>_ PORTRAIT_ENHANCER_OFF OFF
<model>_ PORTRAIT_ENHANCER_SOFT Weak
<model>_ PORTRAIT_ENHANCER_MEDIUM Medium
<model>_^ PORTRAIT_ENHANCER_HARD^ Strong^
**Remarks**
This function can be used in State S3.
**See Also**
CapMoviePortraitEnhancer, GetMoviePortraitEnhancer
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.18.36. GetMoviePortraitEnhancer
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3
**Description**
Gets the MOVIE BEAUTIFUL SKIN PROCESSING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetMoviePortraitEnhancer
lAPIParam (IN) <model>_API_PARAM_ GetMoviePortraitEnhancer
plMode (OUT) See lSetting of “SetMoviePortraitEnhancer”.
**Remarks**
This function can be used in State S3.
**See Also**
CapMoviePortraitEnhancer, SetMoviePortraitEnhancer
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19. Movie Control - AF/MF SETTING**
Control the settings that correspond to the following AF/MF SETTING menu.
APIs are available only when the STILL/MOVIE mode is in MOVIE mode.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.1. CapMovieFocusArea
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported FOCUS AREA settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieFocusArea
lAPIParam (IN) <model>_API_PARAM_CapMovieFocusArea
lAngle (IN)
<model>_ITEM_DIRECTION_CURRENT in camera’s current orientation
<model>_ITEM_DIRECTION_ 0 when camera is rotated 0°
<model>_ITEM_DIRECTION_ 90 when camera is rotated 9 0°
<model>_ITEM_DIRECTION_ 180 when camera is rotated 18 0°
<model>_ITEM_DIRECTION_^270 when camera is rotated^27 0°^
pFocusArea_Min (OUT) Pointer to a structure (SDK_FocusArea) table.
typedef struct {
long h;
long v;
long size;
} SDK_FocusArea;
h:
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lAngle,
SDK_FocusArea* pFocusArea_Min,
SDK_FocusArea* pFocusArea_Max
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
Horizontal display coordinate (absolute)
v:
Vertical display coordinate (absolute)
size:
Area size
pFocusArea_Max (OUT) Pointer to a structure (SDK_FocusArea) table.
typedef struct {
long h;
long v;
long size;
} SDK_FocusArea;
h:
Horizontal display coordinate (absolute)
v:
Vertical display coordinate (absolute)
size:
Area size
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieFocusArea, GetMovieFocusArea


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.2. SetMovieFocusArea
Description**
Sets the FOCUS AREA setting.
**Supported Cameras
X-
T1
X-
T2
X-
T3
X-
T4
X-
T5
X-
Pro2
X-
Pro3
X-
S10
X-
H2S
X-
H2
X-
S20
X-
M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieFocusArea
lAPIParam (IN) <model>_API_PARAM_SetMovieFocusArea
lAngle (IN)
<model>_ITEM_DIRECTION_CURRENT in camera’s current orientation
<model>_ITEM_DIRECTION_ 0 when camera is rotated 0°
<model>_ITEM_DIRECTION_ 90 when camera is rotated 9 0°
<model>_ITEM_DIRECTION_ 180 when camera is rotated 18 0°
<model>_ITEM_DIRECTION_^270 when camera is rotated^27 0°^
pFocusArea (IN) Pointer to a structure (SDK_FocusArea) table.
typedef struct {
long h;
long v;
long size;
} SDK_FocusArea;
h:
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lAngle,
SDK_FocusArea* pFocusArea
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
Horizontal display coordinate (absolute)
v:
Vertical display coordinate (absolute)
size:
Area size
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieFocusArea, GetMovieFocusArea


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.3. GetMovieFocusArea
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the FOCUS AREA setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieFocusArea
lAPIParam (IN) <model>_API_PARAM_GetMovieFocusArea
lAngle (IN)
<model>_ITEM_DIRECTION_CURRENT in camera’s current orientation
<model>_ITEM_DIRECTION_ 0 when camera is rotated 0°
<model>_ITEM_DIRECTION_ 90 when camera is rotated 9 0°
<model>_ITEM_DIRECTION_ 180 when camera is rotated 18 0°
<model>_ITEM_DIRECTION_^270 when camera is rotated^27 0°^
pFocusArea (OUT) Pointer to a structure (SDK_FocusArea) table.
typedef struct {
long h;
long v;
long size;
} SDK_FocusArea;
h:
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lAngle,
SDK_FocusArea* pFocusArea
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
Horizontal display coordinate (absolute)
v:
Vertical display coordinate (absolute)
size:
Area size
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieFocusArea, SetMovieFocusArea


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.4. CapMovieAFMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported AF MODE settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieAFMode
lAPIParam (IN) <model>_API_PARAM_CapMovieAFMode
plNum (OUT) Returns the number of “SetMovieAFMode” settings supported.
plAFMode (OUT)
<model>_MOVIE_AF_MULTI Auto area
<model>_MOVIE_AF_AREA Select area
<model>_MOVIE_AF_WIDETRACKING^ Wide tracking^
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieAFMode, GetMovieAFMode
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plAFMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.5. SetMovieAFMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets theAF MODE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieAFMode
lAPIParam (IN) <model>_API_PARAM_SetMovieAFMode
lAFMode (IN)
<model>_MOVIE_AF_MULTI Auto area
<model>_MOVIE_AF_AREA Select area
<model>_MOVIE_AF_WIDETRACKING^ Wide tracking^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieAFMode, GetMovieAFMode
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lAFMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.6. GetMovieAFMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the AF MODE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieAFMode
lAPIParam (IN) <model>_API_PARAM_GetMovieAFMode
plAFMode (OUT)
<model>_MOVIE_AF_MULTI Auto area
<model>_MOVIE_AF_AREA Select area
<model>_MOVIE_AF_WIDETRACKING^ Wide tracking^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieAFMode, SetMovieAFMode
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plAFMode
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.7. CapMovieAFCCustom
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported AF-C CUSTOM SETTINGS settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieAFCCustom
lAPIParam (IN) <model>_API_PARAM_CapMovieAFCCustom
pParam_Min (OUT) A minimum value is set. See “SetMovieAFCCustom” for supported value.
pParam_Max (OUT) A maximum value is set. See “SetMovieAFCCustom” for supported value.
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieAFCCustom、GetMovieAFCCustom
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
SDK_MOVIE_AFC_CUSTOM* pParam_Min,
SDK_MOVIE_AFC_CUSTOM* pParam_Max
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.8. SetMovieAFCCustom
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the AF-C CUSTOM SETTINGS setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieAFCCustom
lAPIParam (IN) <model>_API_PARAM_SetMovieAFCCustom
pParam (IN) Structure that stores setting values.
Typedef struct {
long lTracking;
long lSpeed;
} SDK_MOVIE_AFC_CUSTOM;
lTracking:
Subject retention characteristics.
lSpeed:
AF Speed.
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieAFCCustom、GetMovieAFCCustom
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
SDK_MOVIE_AFC_CUSTOM* pParam
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.9. GetMovieAFCCustom
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the AF-C CUSTOM SETTINGS setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieAFCCustom
lAPIParam (IN) <model>_API_PARAM_GetMovieAFCCustom
pParam (OUT) See “SetMovieAFCCustom” for supported value.
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieAFCCustom、SetMovieAFCCustom
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
SDK_MOVIE_AFC_CUSTOM* pParam
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.10. CapMovieEyeAFMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported FACE/EYE DETECTION SETTING settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieEyeAFMode
lAPIParam (IN) <model>_API_PARAM_CapMovieEyeAFMode
plNum (OUT) Returns the number of “SetMovieEyeAFMode” settings supported.
plSetting (OUT) See lSetting of “SetMovieEyeAFMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieEyeAFMode、GetMovieEyeAFMode
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.11. SetMovieEyeAFMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the FACE/EYE DETECTION SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieEyeAFMode
lAPIParam (IN) <model>_API_PARAM_SetMovieEyeAFMode
lSetting (IN)
<model>_EYE_AF_OFF Eye AF OFF.
<model>_EYE_AF_AUTO Eye AF Auto.
<model>_EYE_AF_RIGHT_PRIORITY Eye AF Right eye priority.
<model>_EYE_AF_LEFT_PRIORITY^ Eye AF Left^ eye priority.^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieEyeAFMode、GetMovieEyeAFMode
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.12. GetMovieEyeAFMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the FACE/EYE DETECTION SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieEyeAFMode
lAPIParam (IN) <model>_API_PARAM_GetMovieEyeAFMode
plSetting (OUT) See "SetMovieEyeAFMode" for supported values.
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieEyeAFMode、SetMovieEyeAFMode
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.13. CapMovieFaceDetectionMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported FACE DETECTION SETTING settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieFaceDetectMode
lAPIParam (IN) <model>_API_PARAM_CapMovieFaceDetectMode
plNum (OUT) Returns the number of “SetMovieFaceDetectMode” settings supported.
plSetting (OUT) See lSetting of “SetMovieFaceDetectMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieFaceDetectMode、GetMovieFaceDetectMode
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.14. SetMovieFaceDetectionMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the FACE DETECTION SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieFaceDetectMode
lAPIParam (IN) <model>_API_PARAM_SetMovieFaceDetectMode
lSetting (IN)
<model>_FACE_DETECTION_ON 0x0001
<model>_FACE_DETECTION_OFF^ 0x0002^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieFaceDetectMode、GetMovieFaceDetectMode
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.15. GetMovieFaceDetectionMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the FACE DETECTION SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieFaceDetectMode
lAPIParam (IN) <model>_API_PARAM_GetMovieFaceDetectMode
plSetting (OUT) See "SetMovieFaceDetectMode" for supported values.
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieFaceDetectMode、SetMovieFaceDetectMode
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.16. CapMovieSubjectDetectionMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported SUBJECT DETECTION SETTING settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieSubjectDetectionMode
lAPIParam (IN) <model>_API_PARAM_CapMovieSubjectDetectionMode
plNum (OUT) Returns the number of “SetMovieSubjectDetectionMode” settings supported.
plSetting (OUT) See lSetting of “SetMovieSubjectDetectionMode”.
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieSubjectDetectionMode、GetMovieSubjectDetectionMode
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.17. SetMovieSubjectDetectionMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the SUBJECT DETECTION SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieSubjectDetectionMode
lAPIParam (IN) <model>_API_PARAM_SetMovieSubjectDetectionMode
lSetting (IN)
<model>_SUBJECT_DETECTION_OFF Subject detection OFF.
<model>_SUBJECT_DETECTION_ANIMAL Subject detection Animal.
<model>_SUBJECT_DETECTION_BIRD Subject detection Bird.
<model>_SUBJECT_DETECTION_CAR Subject detection Car.
<model>_SUBJECT_DETECTION_BIKE Subject detection Bike.
<model>_SUBJECT_DETECTION_AIRPLANE Subject detection Airplane.
<model>_SUBJECT_DETECTION_TRAIN^ Subject detection Train.^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieSubjectDetectionMode、GetMovieSubjectDetectionMode
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.18. GetMovieSubjectDetectionMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the SUBJECT DETECTION SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieSubjectDetectionMode
lAPIParam (IN) <model>_API_PARAM_GetMovieSubjectDetectionMode
plSetting (OUT) See "SetMovieSubjectDetectionMode" for supported values.
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieSubjectDetectionMode、SetMovieSubjectDetectionMode
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.19. GetTrackingAfFrameInfo
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Gets the subject detection tracking AF framing outline information.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetTrackingAfFrameInfo
lAPIParam (IN) <model>_API_PARAM_GetTrackingAfFrameInfo
pFrameInfo (OUT) Pointer to a structure (SDK_TrackingAfFrameInfo) table.
typedef struct {
long lX;
long lY;
long lLength_H;
long lLength_V;
long lColorR;
long lColorG;
long lColorB;
long lAlpha;
} SDK_TrackingAfFrameInfo;
lX:
Frame origin position in percent (100%=1024)
lY:
Frame origin position in percent (100%=1024)
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
SDK_TrackingAfFrameInfo* pFrameInfo
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
lLength_H:
Horizontal line length in percent (100%=1024)
lLength_V:
Vertical line length in percent (100%=1024)
lColorR:
Line Color R Component
lColorG:
Line Color G Component
lColorB:
Line Color B Component
lAlpha:
Transparency, 0～100(%)
**Remarks**
This function can be used in State S3.
**See Also**
None


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.20. CapMovieFullTimeManual
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported AF+MF settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapMovieFullTimeManual
lAPIParam (IN) <model>_API_PARAM_CapMovieFullTimeManual
plNum (OUT) Returns the number of “SetMovieFullTimeManual” settings supported.
plSetting (OUT) "SetMovieFullTimeManual" List of possible values.
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieFullTimeManual、GetMovieFullTimeManual
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.21. SetMovieFullTimeManual
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the M AF+MF setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetMovieDataLevelSetting
lAPIParam (IN) <model>_API_PARAM_SetMovieDataLevelSetting
lSetting (IN) Setting value (must be a configurable value obtained with
CapMovieFullTimeManual).
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieFullTimeManual、GetMovieFullTimeManual
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.22. GetMovieFullTimeManual
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the AF+MF setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieDataLevelSetting
lAPIParam (IN) <model>_API_PARAM_GetMovieDataLevelSetting
plSetting (OUT) The current setting value obtained.
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieFullTimeManual、GetMovieFullTimeManual
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.23. CapMovieMFAssistMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported MF ASSIST settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapMovieMFAssistMode
lAPIPara
m
(IN) <model>_API_PARAM_ CapMovieMFAssistMode
plNum (OUT) Returns the number of “SetMovieMFAssistMode” settings supported.
plSetting (OUT)
<model>_ MF_ASSIST_STANDARD Standard
<model>_ MF_ASSIST_SPLIT_BW Split image in black
and white
<model>_ MF_ASSIST_SPLIT_COLOR Split image in color
<model>_ MF_ASSIST_PEAK_WHITE_L Focus peak highlight
in low white
<model>_ MF_ASSIST_PEAK_WHITE_H Focus peak highlight
in high white
<model>_ MF_ASSIST_PEAK_RED_L Focus peak highlight
in low red
<model>_ MF_ASSIST_PEAK_RED_H Focus peak highlight
in high red
<model>_ MF_ASSIST_PEAK_BLUE_L Focus peak highlight
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
in low blue
<model>_ MF_ASSIST_PEAK_BLUE_H Focus peak highlight
in high blue
<model>_ MF_ASSIST_ PEAK_YELLOW_L Focus peak highlight
in low yellow
<model>_ MF_ASSIST_ PEAK_YELLOW_H Focus peak highlight
in high yellow
<model>_ MF_ASSIST_MICROPRISM Micro-prism
<model>_ MF_ASSIST_FOCUSMETER Focus meter
<model>_ MF_ASSIST_FOCUSMETER_PEAK_WHITE_L Focus meter
+ peak highlight in
low white
<model>_ MF_ASSIST_FOCUSMETER_PEAK_WHITE_H Focus meter
+ peak highlight in
high white
<model>_ MF_ASSIST_FOCUSMETER_PEAK_RED_L Focus meter
+ peak highlight in
low red
<model>_ MF_ASSIST_FOCUSMETER_PEAK_RED_H Focus meter
+ peak highlight in
high red
<model>_ MF_ASSIST_FOCUSMETER_PEAK_BLUE_L Focus meter
+ peak highlight in
low blue
<model>_ MF_ASSIST_FOCUSMETER_PEAK_BLUE_H Focus meter
+ peak highlight in
high blue
<model>_ MF_ASSIST_FOCUSMETER_PEAK_YELLOW_L Focus meter
+ peak highlight in
low yellow
<model>_ MF_ASSIST_FOCUSMETER_PEAK_YELLOW_H Focus meter
+ peak highlight in
high yellow
<model>_MF_ASSIST_FOCUSMAP_BW Focus map in black
and white
<model>_MF_ASSIST_FOCUSMAP_COLOR^ Focus map in color^
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieMFAssistMode, GetMovieMFAssistMode


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.24. SetMovieMFAssistMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the MF ASSIST setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetMovieMFAssistMode
lAPIParam (IN) <model>_API_PARAM_ SetMovieMFAssistMode
lSetting (IN)
<model>_ MF_ASSIST_STANDARD Standard
<model>_ MF_ASSIST_SPLIT_BW Split image in black
and white
<model>_ MF_ASSIST_SPLIT_COLOR Split image in color
<model>_ MF_ASSIST_PEAK_WHITE_L Focus peak highlight
in low white
<model>_ MF_ASSIST_PEAK_WHITE_H Focus peak highlight
in high white
<model>_ MF_ASSIST_PEAK_RED_L Focus peak highlight
in low red
<model>_ MF_ASSIST_PEAK_RED_H Focus peak highlight
in high red
<model>_ MF_ASSIST_PEAK_BLUE_L Focus peak highlight
in low blue
<model>_ MF_ASSIST_PEAK_BLUE_H Focus peak highlight
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
in high blue
<model>_ MF_ASSIST_ PEAK_YELLOW_L Focus peak highlight
in low yellow
<model>_ MF_ASSIST_ PEAK_YELLOW_H Focus peak highlight
in high yellow
<model>_ MF_ASSIST_MICROPRISM Micro-prism
<model>_ MF_ASSIST_FOCUSMETER Focus meter
<model>_ MF_ASSIST_FOCUSMETER_PEAK_WHITE_L Focus meter
+ peak highlight in
low white
<model>_ MF_ASSIST_FOCUSMETER_PEAK_WHITE_H Focus meter
+ peak highlight in
high white
<model>_ MF_ASSIST_FOCUSMETER_PEAK_RED_L Focus meter
+ peak highlight in
low red
<model>_ MF_ASSIST_FOCUSMETER_PEAK_RED_H Focus meter
+ peak highlight in
high red
<model>_ MF_ASSIST_FOCUSMETER_PEAK_BLUE_L Focus meter
+ peak highlight in
low blue
<model>_ MF_ASSIST_FOCUSMETER_PEAK_BLUE_H Focus meter
+ peak highlight in
high blue
<model>_ MF_ASSIST_FOCUSMETER_PEAK_YELLOW_L Focus meter
+ peak highlight in
low yellow
<model>_ MF_ASSIST_FOCUSMETER_PEAK_YELLOW_H Focus meter
+ peak highlight in
high yellow
<model>_MF_ASSIST_FOCUSMAP_BW Focus map in black
and white
<model>_MF_ASSIST_FOCUSMAP_COLOR^ Focus map in color^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieMFAssistMode, GetMovieMFAssistMode


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.25. GetMovieMFAssistMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the MF ASSIST setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetMovieMFAssistMode
lAPIParam (IN) <model>_API_PARAM_ GetMovieMFAssistMode
plSetting (OUT) See lSetting of “SetMovieMFAssistMode”.
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieMFAssistMode, SetMovieMFAssistMode
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.26. CapMovieFocusCheckMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported FOCUS CHECK settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapMovieFocusCheckMode
lAPIParam (IN) <model>_API_PARAM_ CapMovieFocusCheckMode
plNum (OUT) Returns the number of “SetMovieFocusCheckMode” settings supported.
plSetting (OUT)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieFocusCheckMode, GetMovieFocusCheckMode
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.27. SetMovieFocusCheckMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the FOCUS CHECK setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetMovieFocusCheckMode
lAPIParam (IN) <model>_API_PARAM_ SetMovieFocusCheckMode
lSetting (IN)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieFocusCheckMode, GetMovieFocusCheckMode
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.28. GetMovieFocusCheckMode
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the FOCUS CHECK setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetMovieFocusCheckMode
lAPIParam (IN) <model>_API_PARAM_ GetMovieFocusCheckMode
plSetting (OUT) See lSetting of “SetMovieFocusCheckMode”.
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieFocusCheckMode, SetMovieFocusCheckMode
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.29. CapMovieFocusCheckLock
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported FOCUS CHECK LOCK settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapMovieFocusCheckLock
lAPIParam (IN) <model>_API_PARAM_ CapMovieFocusCheckLock
plNum (OUT) Returns the number of “SetMovieFocusCheckLock” settings supported.
plSetting (OUT)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieFocusCheckLock, GetMovieFocusCheckLock,
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.30. SetMovieFocusCheckLock
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the FOCUS CHECK LOCK setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetMovieFocusCheckLock
lAPIParam (IN) <model>_API_PARAM_ SetMovieFocusCheckLock
lSetting (IN)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieFocusCheckLock, GetMovieFocusCheckLock
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.31. GetMovieFocusCheckLock
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the FOCUS CHECK LOCK setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetMovieFocusCheckLock
lAPIParam (IN) <model>_API_PARAM_ GetMovieFocusCheckLock
plSetting (OUT) See lSetting of “SetMovieFocusCheckLock”.
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieFocusCheckLock, SetMovieFocusCheckLock
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.32. GetFocusMapData
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Gets the FUCUS MAP data.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetFocusMapData
lAPIParam (IN) <model>_API_PARAM_GetFocusMapData
plSize (OUT) Returns the number of focus points.
pFocusMapData (OUT) Pointer to a structure (SDK_FocusMapData) table.
typedef struct {
long lDistance;
long lColorR;
long lColorG;
long lColorB;
long lAlpha;
} SDK_FocusMapData;
lDistance:
Distance
lColorR:
Point Color R Component
lColorG:
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSize
SDK_FocusMapData* pFocusMapData
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
Point Color G Component
lColorB:
Point Color B Component
lAlpha:
Transparency, 0～100(%)
**Remarks**
This function can be used in State S3.
**See Also**
None


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.19.33. GetMovieFocusMeter
Supported Cameras
X-T3
X-T4
X-T**
(^5)
**X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3
**Description**
Gets the FOCUS METER status.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMovieFocusGuide
lAPIParam (IN) <model>_API_PARAM_GetMovieFocusGuide
plPosition (OUT) Returns the number about focus position.
plDisplay (OUT)
<model>_FOCUSMETER_DISPLAY_ON ON
<model>_FOCUSMETER_DISPLAY_OFF^ OFF^
plColor (OUT)
<model>_FOCUSMETER_COLOR_GRAY GRAY
<model>_FOCUSMETER_COLOR_WHITE WHITE
<model>_FOCUSMETER_COLOR_GREEN^ GREEN^
**Remarks**
This function can be used in State S3.
**See Also**
None
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plPosition,
long* plDisplay,
long* plColor
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20. Movie Control - AUDIO SETTING**
Control the settings that correspond to the following AUDIO SETTING menu.
APIs are available only when the STILL/MOVIE mode is in MOVIE mode.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.1. CapInternalMicLevel
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported INTERNAL MIC LEVEL ADJUSTMENT settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapInternalMicLevel
lAPIParam (IN) <model>_API_PARAM_CapInternalMicLevel
plNum (OUT) Returns the number of “SetInternalMicLevel” settings supported.
plSetting (OUT)
<model>_MIC_LEVEL_OFF OFF
<model>_MIC_LEVEL_MANUAL MANUAL
<model>_MIC_LEVEL_AUTO^ AUTO^
**Remarks**
This function can be used in State S3.
**See Also**
SetInternalMicLevel, GetInternalMicLevel
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.2. SetInternalMicLevel
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the INTERNAL MIC LEVEL ADJUSTMENT setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetInternalMicLevel
lAPIParam (IN) <model>_API_PARAM_ SetInternalMicLevel
lSetting (IN)
<model>_MIC_LEVEL_OFF OFF
<model>_MIC_LEVEL_MANUAL MANUAL
<model>_MIC_LEVEL_AUTO^ AUTO^
**Remarks**
This function can be used in State S3.
**See Also**
CapInternalMicLevel, GetInternalMicLevel
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.3. GetInternalMicLevel
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the INTERNAL MIC LEVEL ADJUSTMENT setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetInternalMicLevel
lAPIParam (IN) <model>_API_PARAM_ SetInternalMicLevel
plSetting (OUT) See lSetting of “SetInternalMicLevel”.
**Remarks**
This function can be used in State S3.
**See Also**
CapInternalMicLevel, SetInternalMicLevel
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.4. CapInternalMicLevelManual
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported INTERNAL MIC LEVEL ADJUSTMENT (MANUAL) settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapInternalMicLevelManual
lAPIParam (IN) <model>_API_PARAM_ CapInternalMicLevelManual
plNum (OUT) Returns the number of “SetInternalMicLevelManual” settings supported.
plSetting (OUT)

- 300 - 30 dB
- 285 - 28.5 dB
- 270 - 27 dB
- 255 - 25.5 dB
- 240 - 24 dB
- 225 - 22.5 dB
- 210 - 21 dB
- 195 - 19.5 dB
- 180 - 18 dB
- 165 - 16.5 dB
- 150 - 15 dB
- 135 - 13.5 dB
- 120 - 12 dB

```
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API

- 105 - 10.5 dB
- 90 - 9 dB
- 75 - 7.5 dB
- 60 - 6 dB
- 45 - 4.5 dB
- 30 - 3 dB
- 15 - 1.5 dB
0 0 dB
15 1 .5 dB
30 3 dB
45 4 .5 dB
60 6 dB^
**Remarks**
This function can be used in State S3.
**See Also**
SetInternalMicLevel, GetInternalMicLevel


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.5. SetInternalMicLevelManual
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the INTERNAL MIC LEVEL ADJUSTMENT (MANUAL) setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetInternalMicLevelManual
lAPIParam (IN) <model>_API_PARAM_ SetInternalMicLevelManual
lSetting (IN)

- 300 - 30 dB
- 285 - 28.5 dB
- 270 - 27 dB
- 255 - 25.5 dB
- 240 - 24 dB
- 225 - 22.5 dB
- 210 - 21 dB
- 195 - 19.5 dB
- 180 - 18 dB
- 165 - 16.5 dB
- 150 - 15 dB
- 135 - 13.5 dB
- 120 - 12 dB
- 105 - 10.5 dB
- 90 - 9 dB

```
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API

- 75 - 7.5 dB
- 60 - 6 dB
- 45 - 4.5 dB
- 30 - 3 dB
- 15 - 1.5 dB
0 0 dB
15 1 .5 dB
30 3 dB
45 4 .5 dB
60 6 dB^
**Remarks**
This function can be used in State S3.
**See Also**
CapInternalMicLevel, GetInternalMicLevel


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.6. GetInternalMicLevelManual
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the INTERNAL MIC LEVEL ADJUSTMENT (MANUAL) setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetInternalMicLevel
lAPIParam (IN) <model>_API_PARAM_ GetInternalMicLevel
plSetting (OUT) See lSetting of “SetInternalMicLevelManual”.
**Remarks**
This function can be used in State S3.
**See Also**
CapInternalMicLevel, SetInternalMicLevel
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.7. CapExternalMicLevel
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported EXTERNAL MIC LEVEL ADJUSTMENT settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapExternalMicLevel
lAPIParam (IN) <model>_API_PARAM_ CapExternalMicLevel
plNum (OUT) Returns the number of “SetExternalMicLevel” settings supported.
plSetting (OUT)
<model>_MIC_LEVEL_OFF OFF
<model>_MIC_LEVEL_MANUAL MANUAL
<model>_MIC_LEVEL_AUTO^ AUTO^
**Remarks**
This function can be used in State S3.
**See Also**
SetExternalMicLevel, GetExternalMicLevel
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.8. SetExternalMicLevel
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the EXTERNAL MIC LEVEL ADJUSTMENT setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetExternalMicLevel
lAPIParam (IN) <model>_API_PARAM_ SetExternalMicLevel
lSetting (IN)
<model>_MIC_LEVEL_OFF OFF
<model>_MIC_LEVEL_MANUAL MANUAL
<model>_MIC_LEVEL_AUTO^ AUTO^
**Remarks**
This function can be used in State S3.
**See Also**
CapExternalMicLevel, GetExternalMicLevel
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.9. GetExternalMicLevel
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the EXTERNAL MIC LEVEL ADJUSTMENT setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetExternalMicLevel
lAPIParam (IN) <model>_API_PARAM_ GetExternalMicLevel
plSetting (OUT) See lSetting of “SetExternalMicLevel”.
**Remarks**
This function can be used in State S3.
**See Also**
CapExternalMicLevel , SetExternalMicLevel
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.10. CapExternalMicLevelManual
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported EXTERNAL MIC LEVEL ADJUSTMENT (MANUAL) settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapExternalMicLevelManual
lAPIParam (IN) <model>_API_PARAM_ CapExternalMicLevelManual
plNum (OUT) Returns the number of “SetExternalMicLevelManual” settings supported.
plSetting (OUT)

- 300 - 30 dB
- 285 - 28.5 dB
- 270 - 27 dB
- 255 - 25.5 dB
- 240 - 24 dB
- 225 - 22.5 dB
- 210 - 21 dB
- 195 - 19.5 dB
- 180 - 18 dB
- 165 - 16.5 dB
- 150 - 15 dB
- 135 - 13.5 dB
- 120 - 12 dB

```
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API

- 105 - 10.5 dB
- 90 - 9 dB
- 75 - 7.5 dB
- 60 - 6 dB
- 45 - 4.5 dB
- 30 - 3 dB
- 15 - 1.5 dB
0 0 dB
15 1 .5 dB
30 3 dB
45 4 .5 dB
60 6 dB^
**Remarks**
This function can be used in State S3.
**See Also**
SetExternalMicLevelManual, GetExternalMicLevelManual


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.11. SetExternalMicLevelManual
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the EXTERNAL MIC LEVEL ADJUSTMENT (MANUAL) setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetExternalMicLevelManual
lAPIParam (IN) <model>_API_PARAM_ SetExternalMicLevelManual
lSetting (IN)

- 300 - 30 dB
- 285 - 28.5 dB
- 270 - 27 dB
- 255 - 25.5 dB
- 240 - 24 dB
- 225 - 22.5 dB
- 210 - 21 dB
- 195 - 19.5 dB
- 180 - 18 dB
- 165 - 16.5 dB
- 150 - 15 dB
- 135 - 13.5 dB
- 120 - 12 dB
- 105 - 10.5 dB
- 90 - 9 dB

```
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API

- 75 - 7.5 dB
- 60 - 6 dB
- 45 - 4.5 dB
- 30 - 3 dB
- 15 - 1.5 dB
0 0 dB
15 1 .5 dB
30 3 dB
45 4 .5 dB
60 6 dB^
**Remarks**
This function can be used in State S3.
**See Also**
CapExternalMicLevelManualm, GetExternalMicLevelManual


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.12. GetExternalMicLevelManual
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the EXTERNAL MIC LEVEL ADJUSTMENT (MANUAL) setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetExternalMicLevelManual
lAPIParam (IN) <model>_API_PARAM_ GetExternalMicLevelManual
plSetting (OUT) See lSetting of “SetExternalMicLevelManual”.
**Remarks**
This function can be used in State S3.
**See Also**
CapExternalMicLevelManual, SetExternalMicLevelManual
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.13. CapMicLevelLimiter
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX
50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported MIC LEVEL LIMITER settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapMicLevelLimiter
lAPIParam (IN) <model>_API_PARAM_ CapMicLevelLimiter
plNum (OUT) Returns the number of “SetMicLevelLimiter” settings supported.
plSetting (OUT)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
SetMicLevelLimiter, GetMicLevelLimiter
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.14. SetMicLevelLimiter
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the MIC LEVEL LIMITER setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetMicLevelLimiter
lAPIParam (IN) <model>_API_PARAM_ SetMicLevelLimiter
lSetting (IN)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
CapMicLevelLimiter, GetMicLevelLimiter
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.15. GetMicLevelLimiter
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the MIC LEVEL LIMITER setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetMicLevelLimiter
lAPIParam (IN) <model>_API_PARAM_ GetMicLevelLimiter
plSetting (OUT) See lSetting of “SetMicLevelLimiter”.
**Remarks**
This function can be used in State S3.
**See Also**
CapMicLevelLimiter, SetMicLevelLimiter
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.16. CapWindFilter
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported WIND FILTER settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapWindFilter
lAPIParam (IN) <model>_API_PARAM_ CapWindFilter
plNum (OUT) Returns the number of “SetWindFilter” settings supported.
plSetting (OUT)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
SetWindFilter, GetWindFilter
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.17. SetWindFilter
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the WIND FILTER setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetWindFilter
lAPIParam (IN) <model>_API_PARAM_ SetWindFilter
lSetting (IN)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
CapWindFilter, GetWindFilter
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.18. GetWindFilter
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the WIND FILTER setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetWindFilter
lAPIParam (IN) <model>_API_PARAM_ GetWindFilter
plSetting (OUT) See lSetting of “SetWindFilter”.
**Remarks**
This function can be used in State S3.
**See Also**
CapWindFilter, SetWindFilter
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.19. CapLowCutFilter
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported LOW CUT FILTER settings
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapLowCutFilter
lAPIParam (IN) <model>_API_PARAM_ CapLowCutFilter
plNum (OUT) Returns the number of “SetLowCutFilter” settings supported.
plSetting (OUT)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
SetLowCutFilter, GetLowCutFilter
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.20. SetLowCutFilter
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the LOW CUT FILTER setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetLowCutFilter
lAPIParam (IN) <model>_API_PARAM_ SetLowCutFilter
lSetting (IN)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
CapLowCutFilter, GetLowCutFilter
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.21. GetLowCutFilter
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the LOW CUT FILTER setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetLowCutFilter
lAPIParam (IN) <model>_API_PARAM_ GetLowCutFilter
plSetting (OUT) See lSetting of “SetLowCutFilter”.
**Remarks**
This function can be used in State S3.
**See Also**
CapLowCutFilter, SetLowCutFilter
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.22. CapHeadPhonesVolume
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported HEADPHONES VOLUME settings
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapHeadPhonesVolume
lAPIParam (IN) <model>_API_PARAM_ CapHeadPhonesVolume
plNum (OUT) Returns the number of “SetHeadPhonesVolume” settings supported.
plSetting (OUT)
<model>_ HEADPHONES_VOLUME_0 0
<model>_ HEADPHONES_VOLUME_ 1 10
<model>_ HEADPHONES_VOLUME_ 2 20
<model>_ HEADPHONES_VOLUME_ 3 30
<model>_ HEADPHONES_VOLUME_ 4 40
<model>_ HEADPHONES_VOLUME_ 5 50
<model>_ HEADPHONES_VOLUME_ 6 60
<model>_ HEADPHONES_VOLUME_ 7 70
<model>_ HEADPHONES_VOLUME_ 8 80
<model>_ HEADPHONES_VOLUME_ 9 90
<model>_^ HEADPHONES_VOLUME_^10 100
**Remarks**
This function can be used in State S3.
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**See Also**
SetHeadPhonesVolume, GetHeadPhonesVolume


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.23. SetHeadPhonesVolume
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the HEADPHONES VOLUME setting
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetHeadPhonesVolume
lAPIParam (IN) <model>_API_PARAM_ SetHeadPhonesVolume
lSetting (IN)
<model>_ HEADPHONES_VOLUME_0 0
<model>_ HEADPHONES_VOLUME_ 1 10
<model>_ HEADPHONES_VOLUME_ 2 20
<model>_ HEADPHONES_VOLUME_ 3 30
<model>_ HEADPHONES_VOLUME_ 4 40
<model>_ HEADPHONES_VOLUME_ 5 50
<model>_ HEADPHONES_VOLUME_ 6 60
<model>_ HEADPHONES_VOLUME_ 7 70
<model>_ HEADPHONES_VOLUME_ 8 80
<model>_ HEADPHONES_VOLUME_ 9 90
<model>_^ HEADPHONES_VOLUME_^10 100
**Remarks**
This function can be used in State S3.
**See Also**
CapHeadPhonesVolume, GetHeadPhonesVolume
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.24. GetHeadPhonesVolume
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the HEADPHONES VOLUME setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetHeadPhonesVolume
lAPIParam (IN) <model>_API_PARAM_ GetHeadPhonesVolume
plSetting (OUT) See lSetting of “SetHeadPhonesVolume”.
**Remarks**
This function can be used in State S3.
**See Also**
CapHeadPhonesVolume, SetHeadPhonesVolume
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.25. CapXLRAdapterMicSource
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported MIC INPUT CHANNEL settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapXLRAdapterMicSource
lAPIParam (IN) <model>_API_PARAM_ CapXLRAdapterMicSource
plNum (OUT) Returns the number of “SetXLRAdapterMicSource” settings supported.
plSetting (OUT)
<model>_ XLRADAPTER_MIC_SOURCE_4CH 4ch XLR + Camera
<model>_^ XLRADAPTER_MIC_SOURCE_2CH^ 2ch XLR only^
**Remarks**
This function can be used in State S3.
**See Also**
SetXLRAdapterMicSource, GetXLRAdapterMicSource
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.26. SetXLRAdapterMicSource
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the MIC INPUT CHANNEL setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetXLRAdapterMicSource
lAPIParam (IN) <model>_API_PARAM_ SetXLRAdapterMicSource
lSetting (IN)
<model>_ XLRADAPTER_MIC_SOURCE_4CH 4ch XLR + Camera
<model>_^ XLRADAPTER_MIC_SOURCE_2CH^ 2ch XLR only^
**Remarks**
This function can be used in State S3.
**See Also**
CapXLRAdapterMicSource, GetXLRAdapterMicSource
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.27. GetXLRAdapterMicSource
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the MIC INPUT CHANNEL setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetXLRAdapterMicSource
lAPIParam (IN) <model>_API_PARAM_ GetXLRAdapterMicSource
plSetting (OUT) See lSetting of “SetXLRAdapterMicSource”.
**Remarks**
This function can be used in State S3.
**See Also**
CapXLRAdapterMicSource, SetXLRAdapterMicSource
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.28. CapXLRAdapterMoniteringSource
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported 4CH AUDIO MONITORING settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapXLRAdapterMoniteringSource
lAPIParam (IN) <model>_API_PARAM_ CapXLRAdapterMoniteringSource
plNum (OUT) Returns the number of “SetXLRAdapterMoniteringSource” settings supported.
plSetting (OUT)
<model>_XLRADAPTER_MONITER_SOURCE_XLR XLR
<model>_XLRADAPTER_MONITER_SOURCE_CAMERA^ Camera^
**Remarks**
This function can be used in State S3.
**See Also**
SetXLRAdapterMoniteringSource, GetXLRAdapterMoniteringSource
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.29. SetXLRAdapterMoniteringSource
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the 4CH AUDIO MONITORING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetXLRAdapterMoniteringSource
lAPIParam (IN) <model>_API_PARAM_ SetXLRAdapterMoniteringSource
lSetting (IN)
<model>_XLRADAPTER_MONITER_SOURCE_XLR XLR
<model>_XLRADAPTER_MONITER_SOURCE_CAMERA^ Camera^
**Remarks**
This function can be used in State S3.
**See Also**
CapXLRAdapterMoniteringSource, GetXLRAdapterMoniteringSource
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.30. GetXLRAdapterMoniteringSource
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the 4CH AUDIO MONITORING setting
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetXLRAdapterMoniteringSource
lAPIParam (IN) <model>_API_PARAM_ GetXLRAdapterMoniteringSource
plSetting (OUT) See lSetting of “SetXLRAdapterMoniteringSource”.
**Remarks**
This function can be used in State S3.
**See Also**
CapXLRAdapterMoniteringSource, SetXLRAdapterMoniteringSource
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.31. CapXLRAdapterHDMIOutputSource
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported HDMI 4CH AUDIO OUTPUT settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapXLRAdapterHDMIOutputSource
lAPIParam (IN) <model>_API_PARAM_ CapXLRAdapterHDMIOutputSource
plNum (OUT) Returns the number of “SetXLRAdapterHDMIOutputSource” settings supported.
plSetting (OUT)
<model>_XLRADAPTER_ HDMIOUTPUT_SOURCE_XLR XLR
<model>_XLRADAPTER_^ HDMIOUTPUT_SOURCE_CAMERA^ Camera^
**Remarks**
This function can be used in State S3.
**See Also**
SetXLRAdapterHDMIOutputSource, GetXLRAdapterHDMIOutputSource
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.32. SetXLRAdapterHDMIOutputSource
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the HDMI 4CH AUDIO OUTPUT setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetXLRAdapterHDMIOutputSource
lAPIParam (IN) <model>_API_PARAM_ SetXLRAdapterHDMIOutputSource
lSetting (IN)
<model>_XLRADAPTER_ HDMIOUTPUT_SOURCE_XLR XLR
<model>_XLRADAPTER_^ HDMIOUTPUT_SOURCE_CAMERA^ Camera^
**Remarks**
This function can be used in State S3.
**See Also**
CapXLRAdapterHDMIOutputSource, GetXLRAdapterHDMIOutputSource
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.33. GetXLRAdapterHDMIOutputSource
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the HDMI 4CH AUDIO OUTPUT setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetXLRAdapterHDMIOutputSource
lAPIParam (IN) <model>_API_PARAM_ GetXLRAdapterHDMIOutputSource
plSetting (OUT) See lSetting of “SetXLRAdapterHDMIOutputSource”.
**Remarks**
This function can be used in State S3.
**See Also**
CapXLRAdapterHDMIOutputSource, SetXLRAdapterHDMIOutputSource
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.34. GetMicLevelIndicator
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the MIC LEVEL.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetMicLevelIndicator
lAPIParam (IN) <model>_API_PARAM_ GetMicLevelIndicator
pIndicator (OUT) Pointer to a structure (SDK_MICLEVEL_INDICATOR) table.
typedef struct {
long lDSC_L_Peak;
long lDSC_L_PeakHold;
long lDSC_R_Peak;
long lDSC_R_PeakHold;
long lXLR_1_Peak;
long lXLR_1_PeakHold;
long lXLR_2_Peak;
long lXLR_2_PeakHold;
long lWarning1;
long lWarning2;
long lMicLine;
} SDK_MICLEVEL_INDICATOR;
lDSC_L_Peak:
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
<model>_MICLEVEL_INDICATOR* pIndicator
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
Camera L Peak value block No. (-1: hidden, 0- 2 0: valid value).
lDSC_L_PeakHold:
Camera L Peak hold block No. (-1: hidden, 0-20: valid value).
lDSC_R_Peak:
Camera R Peak value block No. (-1:non-dispaly, 0-20: valid value).
lDSC_R_PeakHold:
Camera R Peak hold block No. (-1: non-dispaly, 0-20: valid value).
lXLR_1_Peak:
XLR1 Peak value block No. (-1: non-dispaly, 0-20: valid value).
lXLR_1_PeakHold:
XLR1 Peak hold block No. (-1: non-dispaly, 0-20: valid value).
lXLR_ 2 _Peak:
XLR2 Peak value block No. (-1: non-dispaly, 0-20: valid value).
lXLR_ 2 _PeakHold:
XLR2 Peak hold block No. (-1: non-dispaly, 0-20: valid value).
lWarning1:
Warning 1 Block No. (1-20) *Display peak value and peak hold above this value
in warning 1 color.
lWarning2:
Warning 2 Block No. (1-20) *Display peak value and peak hold above this value
in warning 2 colors.
lMicLine:
Mic/Line information (0:Mic, 1:Line) *Information indicating whether the above
output is mic or line.
**Remarks**
This function can be used in State S3.
**See Also**
None


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.35. CapMovieRecVolume
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3
3 3 3 3 3
**Description**
Queries supported REC START/STOP VOLUME setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapMovieRecVolume
lAPIParam (IN) <model>_API_PARAM_ CapMovieRecVolume
plNum (OUT) Returns the number of “SetMovieRecVolume” settings supported.
plSetting (OUT)
<model>_MOVIE_REC_VOLUME_OFF OFF
<model>_MOVIE_REC_VOLUME_ 1 Low
<model>_MOVIE_REC_VOLUME_ 2 Medium
<model>_MOVIE_REC_VOLUME_^3 Loud^
**Remarks**
This function can be used in State S3.
**See Also**
SetMovieRecVolume, GetMovieRecVolume
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.36. SetMovieRecVolume
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3
3 3 3 3 3
**Description**
Sets the REC START/STOP VOLUME setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetMovieRecVolume
lAPIParam (IN) <model>_API_PARAM_ SetMovieRecVolume
lSetting (IN)
<model>_MOVIE_REC_VOLUME_OFF OFF
<model>_MOVIE_REC_VOLUME_ 1 Low
<model>_MOVIE_REC_VOLUME_ 2 Medium
<model>_MOVIE_REC_VOLUME_^3 Loud^
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieRecVolume, GetMovieRecVolume
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.37. GetMovieRecVolume
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3
3 3 3 3 3
**Description**
Gets the REC START/STOP VOLUME setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetMovieRecVolume
lAPIParam (IN) <model>_API_PARAM_ GetMovieRecVolume
plSetting (OUT) See lSetting of “SetMovieRecVolume”.
**Remarks**
This function can be used in State S3.
**See Also**
CapMovieRecVolume, SetMovieRecVolume
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.38. CapDirectionalMic
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3
**Description**
Queries supported DIRECTIONAL MICROPHONE settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapDirectionalMic
lAPIParam (IN) <model>_API_PARAM_ CapDirectionalMic
plNum (OUT) Returns the number of “SetDirectionalMic” settings supported
plSetting (OUT)
<model>_ DIRECTIONAL_MIC_AUTO Auto
<model>_ DIRECTIONAL_MIC_SURROUND Surround
<model>_ DIRECTIONAL_MIC_FRONT Front
<model>_ DIRECTIONAL_MIC_TRACKING Tracking
<model>_^ DIRECTIONAL_MIC_NARRATION^ Narration^
**Remarks**
This function can be used in State S3.
**See Also**
SetDirectionalMic, GetDirectionalMic
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.39. SetDirectionalMic
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3
**Description**
Sets the DIRECTIONAL MICROPHONE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetDirectionalMic
lAPIParam (IN) <model>_API_PARAM_ SetDirectionalMic
lSetting (IN)
<model>_ DIRECTIONAL_MIC_AUTO Auto
<model>_ DIRECTIONAL_MIC_SURROUND Surround
<model>_ DIRECTIONAL_MIC_FRONT Front
<model>_ DIRECTIONAL_MIC_TRACKING Tracking
<model>_^ DIRECTIONAL_MIC_NARRATION^ Narration^
**Remarks**
This function can be used in State S3.
**See Also**
CapDirectionalMic, GetDirectionalMic
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.20.40. GetDirectionalMic
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3
**Description**
Gets the DIRECTIONAL MICROPHONE setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetDirectionalMic
lAPIParam (IN) <model>_API_PARAM_ GetDirectionalMic
plSetting (OUT) See lSetting of “SetDirectionalMic”.
**Remarks**
This function can be used in State S3.
**See Also**
CapDirectionalMic, SetDirectionalMic
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.21. Movie Control - TIME CODE SETTING**
Control the settings that correspond to the following TIME CODE SETTING menu.
APIs are available only when the STILL/MOVIE mode is in MOVIE mode.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.21.1. CapTimeCodeDisplay
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported TIME CODE DISPLAY settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapTimeCodeDisplay
lAPIParam (IN) <model>_API_PARAM_ CapTimeCodeDisplay
plNum (OUT) Returns the number of “SetTimeCodeDisplay” settings supported.
plSetting (OUT)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
SetTimeCodeDisplay, GetTimeCodeDisplay
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.21.2. SetTimeCodeDisplay
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the TIME CODE DISPLAY setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetTimeCodeDisplay
lAPIParam (IN) <model>_API_PARAM_ SetTimeCodeDisplay
lSetting (IN)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
CapTimeCodeDisplay, GetTimeCodeDisplay
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.21.3. GetTimeCodeDisplay
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the TIME CODE DISPLAY setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetTimeCodeDisplay
lAPIParam (IN) <model>_API_PARAM_ GetTimeCodeDisplay
plSetting (OUT) See lSetting of “SetTimeCodeDisplay”.
**Remarks**
This function can be used in State S3.
**See Also**
CapTimeCodeDisplay, SetTimeCodeDisplay
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.21.4. CapTimeCodeStartSetting
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported START TIME SETTING settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapTimeCodeStartSetting
lAPIParam (IN) <model>_API_PARAM_ CapTimeCodeStartSetting
plNum (OUT) Returns the number of “SetTimeCodeStartSetting” settings supported.
plSetting (OUT)
<model>_TIMECODE_START_SETTING_MANUAL Manual
<model>_TIMECODE_START_SETTING_CURRENT Current time
<model>_TIMECODE_START_SETTING_RESET^ Reset^
**Remarks**
This function can be used in State S3.
**See Also**
SetTimeCodeStartSetting
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.21.5. SetTimeCodeStartSetting
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the START TIME SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetTimeCodeStartSetting
lAPIParam (IN) <model>_API_PARAM_ SetTimeCodeStartSetting
lSetting (IN)
<model>_TIMECODE_START_SETTING_MANUAL Manual
<model>_TIMECODE_START_SETTING_CURRENT Current time
<model>_TIMECODE_START_SETTING_RESET^ Reset^
lHour (IN) Hour: 0- 23 (Valid only when MANUAL is specified in lSetting)
lMinute (IN) Minute: 0 - 59 (Valid only when MANUAL is specified in lSetting)
lSecond (IN) Second: 0-59 (Valid only when MANUAL is specified in lSetting)
lMilliSecond (IN) Millisecond: 0-29 (Valid only when MANUAL is specified in lSetting)
**Remarks**
This function can be used in State S3.
**See Also**
CapTimeCodeStartSetting
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting,
long lHour,
long lMinute,
long lSecond,
long lMilliSecond
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.21.6. CapTimeCodeCountUp
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3 3
**Description**
Queries supported COUNT UP SETTING settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapTimeCodeCountUp
lAPIParam (IN) <model>_API_PARAM_ CapTimeCodeCountUp
plNum (OUT) Returns the number of “SetTimeCodeCountUp” settings supported.
plSetting (OUT)
<model>_ TIMECODE_COUNTUP_RECRUN RECRUN
<model>_^ TIMECODE_COUNTUP_^ FREERUN^ FREERUN^
**Remarks**
This function can be used in State S3.
**See Also**
SetTimeCodeCountUp, GetTimeCodeCountUp
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.21.7. SetTimeCodeCountUp
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the COUNT UP SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetTimeCodeCountUp
lAPIParam (IN) <model>_API_PARAM_ SetTimeCodeCountUp
lSetting (IN)
<model>_ TIMECODE_COUNTUP_RECRUN RECRUN
<model>_^ TIMECODE_COUNTUP_^ FREERUN^ FREERUN^
**Remarks**
This function can be used in State S3.
**See Also**
CapTimeCodeCountUp, GetTimeCodeCountUp
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.21.8. GetTimeCodeCountUp
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the COUNT UP SETTING setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetTimeCodeCountUp
lAPIParam (IN) <model>_API_PARAM_ GetTimeCodeCountUp
plSetting (OUT) See lSetting of “SetTimeCodeCountUp”.
**Remarks**
This function can be used in State S3.
**See Also**
CapTimeCodeCountUp, SetTimeCodeCountUp
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.21.9. CapTimeCodeDropFrame
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported DROP FRAME settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapTimeCodeDropFrame
lAPIParam (IN) <model>_API_PARAM_ CapTimeCodeDropFrame
plNum (OUT) Returns the number of “SetTimeCodeDropFrame” settings supported.
plSetting (OUT)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
SetTimeCodeDropFrame, GetTimeCodeDropFrame
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.21.10. SetTimeCodeDropFrame
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the DROP FRAME setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetTimeCodeDropFrame
lAPIParam (IN) <model>_API_PARAM_ SetTimeCodeDropFrame
lSetting (IN)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
CapTimeCodeDropFrame, GetTimeCodeDropFrame
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.21.11. GetTimeCodeDropFrame
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the DROP FRAME setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetTimeCodeDropFrame
lAPIParam (IN) <model>_API_PARAM_ GetTimeCodeDropFrame
plSetting (OUT) See lSetting of “SetTimeCodeDropFrame”.
**Remarks**
This function can be used in State S3.
**See Also**
CapTimeCodeDropFrame, SetTimeCodeDropFrame
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.21.12. CapTimeCodeHDMIOutput
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported HDMI TIME CODE OUTPUT settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ CapTimeCodeHDMIOutput
lAPIParam (IN) <model>_API_PARAM_ CapTimeCodeHDMIOutput
plNum (OUT) Returns the number of “SetTimeCodeHDMIOutput” settings supported.
plSetting (OUT)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
SetTimeCodeHDMIOutput, GetTimeCodeHDMIOutput
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.21.13. SetTimeCodeHDMIOutput
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets the HDMI TIME CODE OUTPUT setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ SetTimeCodeHDMIOutput
lAPIParam (IN) <model>_API_PARAM_ SetTimeCodeHDMIOutput
lSetting (IN)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
CapTimeCodeHDMIOutput, GetTimeCodeHDMIOutput
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.21.14. GetTimeCodeHDMIOutput
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets the HDMI TIME CODE OUTPUT setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetTimeCodeHDMIOutput
lAPIParam (IN) <model>_API_PARAM_ GetTimeCodeHDMIOutput
plSetting (OUT) See lSetting of “SetTimeCodeHDMIOutput”.
**Remarks**
This function can be used in State S3.
**See Also**
CapTimeCodeHDMIOutput, SetTimeCodeHDMIOutput
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API

##### 4.2.21.15. CapATOMOSAirGluConnection

**Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**

```
3 3 3 3
```
**Description**
Queries supported CONNECT TO ATOMOS AirGlu BT settings.
**Syntax**

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapATOMOSAirGluConnection
lAPIParam (IN) <model>_API_PARAM_CapATOMOSAirGluConnection
plSetting (OUT)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**

##### 4.2.21.17. GetATOMOSAirGluConnection

```
APIENTRY XSDK_CapProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API

##### 4.2.21.16. SetATOMOSAirGluConnection

**Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**

```
3 3 3 3
```
**Description**
Sets the CONNECT TO ATOMOS AirGlu BT settings.
**Syntax**

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetATOMOSAirGluConnection
lAPIParam (IN) <model>_API_PARAM_SetATOMOSAirGluConnection
lSetting (IN)
<model>_ON ON
<model>_OFF^ OFF^
**Remarks**
This function can be used in State S3.
**See Also**
CapATOMOSAirGluConnection, GetATOMOSAirGluConnection

```
APIENTRY XSDK_SetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.21.17. GetATOMOSAirGluConnection
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**
3 3 3 3
**Description**
Gets the CONNECT TO ATOMOS AirGlu BT setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetATOMOSAirGluConnection
lAPIParam (IN) <model>_API_PARAM_GetATOMOSAirGluConnection
plSetting (OUT) See lSetting of “SetATOMOSAirGluConnection”.
**Remarks**
This function can be used in State S3.
**See Also**
CapATOMOSAirGluConnection, SetATOMOSAirGluConnection
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API

##### 4.2.21.18. GetTimeCode

**Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**

```
3 3 3 3 3 3 3 3
```
**Description**
Gets the TIME CODE.
**Syntax**

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_ GetTimeCode
lAPIParam (IN) <model>_API_PARAM_ GetTimeCode
plHour (OUT) Hour: 0- 23
plMinute (OUT) Minute: 0 - 59
plSecond (OUT) Second: 0- 59
plMilliSecond (OUT) Millisecond: 0- 29
**Remarks**
This function can be used in State S3.
**See Also**
None

```
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plHour,
long* plMinute,
long* plSecond,
long* plMilliSecond
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API

##### 4.2.21.19. GetTimeCodeCurrentValue

**Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**

```
3 3 3 3 3 3 3 3
```
**Description**
Gets the TIME CODE (CURRENT VA L U E).
**Syntax**

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetTimeCodeCurrentvalue
lAPIParam (IN) <model>_API_PARAM_GetTimeCodeCurrentValue
plHour (OUT) Hour: 0- 23
plMinute (OUT) Minute: 0 - 59
plSecond (OUT) Second: 0- 59
plMilliSecond (OUT) Millisecond: 0- 29
**Remarks**
This function can be used in State S3.
**See Also**
None

```
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plHour,
long* plMinute,
long* plSecond,
long* plMilliSecond
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API

##### 4.2.21.20. GetTimeCodeStatus

**Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T5
X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100S
GFX50S II
GFX100 II
GFX100S II
GFX100RF**

```
3 3 3 3
```
**Description**
Gets the TIME CODE SYNC. SETTING status.
**Syntax**

**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetTimeCodeStatus
lAPIParam (IN) <model>_API_PARAM_ GetTimeCodeStatus
plStatus (OUT)
<model>_TIMECODE_STATUS_USE_ALONE Camera alone use
<model>_TIMECODE_STATUS_SYNCING ATOMOS
AirGlu connected &
Timecode
synchronized.
<model>_TIMECODE_STATUS_DISCONNECTED AirGlu disconnection
<model>_TIMECODE_STATUS_NOT_SYNCED ATOMOS
AirGlu connected &
Timecode
not synchronized
(other).
<model>_TIMECODE_FRAMERATE_MISMATCH ATOMOS
AirGlu connected &
Timecode
not synchronized
(frame rate mismatch).^

```
APIENTRY XSDK_GetProp (
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plStatus
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**Remarks**
This function can be used in State S3.
**See Also**
None


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.22. Other Functions**

##### 4.2.22.1. CapCustomAutoPowerOff

**Supported Cameras
X-
T1
X-
T2
X-
T3
X-
T4
X-
T5
X-
Pro2
X-
Pro3
X-
S10
X-
H2S
X-
H2
X-
S20
X-
M5
GFX 50S
GFX 50R
GFX100
GFX100**

```
S
```
```
GFX50S II
GFX100 II
GFX100
```
**S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported customizable options for AUTO POWER OFF for “2 MIN”.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapCustomAutoPowerOff
lAPIParam (IN) <model>_API_PARAM_CapCustomAutoPowerOff
plSeconds_Min (OUT) Returns the minimum supported auto power off time.
plSeconds_Max (OUT) Returns the maximum supported auto power off time.
**Remarks**
This function can be used in State S3.
**See Also**

##### 4.2.22.2. SetCustomAutoPowerOff

```
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSeconds_Min,
long* plSeconds_Max
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API

##### 4.2.22.2. GetElectronicLevelSetting

**Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**

(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the custom AUTO POWER OFF for “2 MIN”.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetCustomAutoPowerOff
lAPIParam (IN) <model>_API_PA R A M_SetCustomAutoPowerOff
lSeconds (IN) A value of from 1 to 255. Values of 1 to 254 are equivalent to auto power off
delays of 10 to 263 seconds, while 255 disables auto power off.
**Remarks**
This function can be used in State S3.
**See Also**

##### 4.2.22.3. GetCustomAutoPowerOff

```
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSeconds
);
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

```
MODEL DEPENDENT
```
(^) API
**4.2.22.3. GetCustomAutoPowerOff
Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**
(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Gets the custom AUTO POWER OFF for “2 MIN”.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetCustomAutoPowerOff
lAPIParam (IN) <model>_API_PA R A M_ GetCustomAutoPowerOff
plSeconds (OUT) See lSeconds of “SetCustomAutoPowerOff”.
**Remarks**
This function can be used in State S3.
**See Also**
SetCustomAutoPowerOff
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSeconds
);


**FJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 31 .0. 0**

##### 4.2.22.4. CapPerformanceSettings

**Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**

(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX
50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3
**Description**
Queries supported PERFORMANCE settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapPerformanceSettings
lAPIPara
m
(IN) <model>_API_PARAM_CapPerformanceSettings
plNum (OUT) Returns the number of “SetPerformanceSetting” settings supported.
plSetting (OUT)
<model>_PERFORMANCE_NORMAL NORMAL
<model>_PERFORMANCE_ECONOMY ECONOMY
<model>_PERFORMANCE_BOOST_LOWLIGHT EVF/LCD LOW
LIGHT PRIORITY
<model>_PERFORMANCE_BOOST_RESOLUTION_PRIORIT
Y
EVF/LCD
RESOLUTION
PRIORITY
<model>_PERFORMANCE_BOOST_FRAMERATE_PRIORITY EVF FRAME
RATE PRIORITY
(120P)
<model>_PERFORMANCE_BOOST_AFPRIORITY_NORMAL AF PRIORITY -
NORMAL
<model>_PERFORMANCE_BOOST_AFTERIMAGE_REDUCT EVF FRAME
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);


**FJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 31 .0. 0**

```
ION RATE PRIORITY
(240P EQUIV.)
```
**Remarks**
This function can be used in State S3.
**See Also**

##### 4.2.22.6. GetPerformanceSettings


**FJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 31 .0. 0**

##### 4.2.22.5. SetPerformanceSettings

**Supported Cameras
X-T3
X-T4
X-T**

(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Sets the PERFORMANCE setting.
**Syntax**
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetPerformanceSettings
lAPIParam (IN) <model>_API_PARAM_SetPerformanceSettings
lSetting (IN)
**[GFX System]**
<model>_PERFORMANCE_NORMAL NORMAL
<model>_PERFORMANCE_BOOST_LOWLIGHT AF PRIORITY -
LOW LIGHT
<model>_PERFORMANCE_BOOST_RESOLUTION_PRIORITY EVF
RESOLUTION
PRIORITY
<model>_PERFORMANCE_BOOST_FRAMERATE_PRIORITY EVF FRAME
RATE PRIORITY
<model>_PERFORMANCE_BOOST_AFPRIORITY_NORMAL AF PRIORITY -
NORMAL
**[X Series]**
<model>_PERFORMANCE_NORMAL NORMAL
<model>_PERFORMANCE_ECONOMY ECONOMY
<model>_PERFORMANCE_BOOST_LOWLIGHT EVF/LCD


**FJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 31 .0. 0**

```
LOW LIGHT
PRIORITY
<model>_PERFORMANCE_BOOST_RESOLUTION_PRIORITY EVF/LCD
RESOLUTION
PRIORITY
<model>_PERFORMANCE_BOOST_FRAMERATE_PRIORITY EVF FRAME
RATE
PRIORITY
(120P)
<model>_PERFORMANCE_BOOST_AFPRIORITY_NORMAL AF PRIORITY
```
- NORMAL
<model>_PERFORMANCE_BOOST_AFTERIMAGE_REDUCTION EVF FRAME
RATE
PRIORITY
(240P EQUIV.)

**Remarks**
This function can be used in State S3.
**See Also**
CapPerformanceSettings, GetPerformanceSettings


**FJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 31 .0. 0**

##### 4.2.22.6. CapAutoPowerOffSetting

**Supported Cameras
X-T3
X-T4
X-T**

(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3 3 3 3 3
**Description**
Get the PERFORMANCE setting.
**Syntax**
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);
**Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapPerformanceSettings
lAPIPara
m
(IN) <model>_API_PARAM_ CapPerformanceSettings
plSetting (OUT
)
**[GFX System]**
<model>_PERFORMANCE_NORMAL NORMAL
<model>_PERFORMANCE_BOOST_LOWLIGHT AF PRIORITY -
LOW LIGHT
<model>_PERFORMANCE_BOOST_RESOLUTION_PRIORITY EVF
RESOLUTION
PRIORITY
<model>_PERFORMANCE_BOOST_FRAMERATE_PRIORITY EVF FRAME
RATE PRIORITY
<model>_PERFORMANCE_BOOST_AFPRIORITY_NORMAL AF PRIORITY -
NORMAL
**[X Series]**
<model>_PERFORMANCE_NORMAL NORMAL
<model>_PERFORMANCE_ECONOMY ECONOMY


**FJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 31 .0. 0**

```
<model>_PERFORMANCE_BOOST_LOWLIGHT EVF/LCD
LOW LIGHT
PRIORITY
<model>_PERFORMANCE_BOOST_RESOLUTION_PRIORITY EVF/LCD
RESOLUTIO
N PRIORITY
<model>_PERFORMANCE_BOOST_FRAMERATE_PRIORITY EVF FRAME
RATE
PRIORITY
(120P)
<model>_PERFORMANCE_BOOST_AFPRIORITY_NORMAL AF PRIORITY
```
- NORMAL
<model>_PERFORMANCE_BOOST_AFTERIMAGE_REDUCTIO
N

```
EVF FRAME
RATE
PRIORITY
(240P EQUIV.)
```
**Remarks**
This function can be used in State S3.
**See Also**
CapPerformanceSettings, SetPerformanceSettings


**FJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 31 .0. 0**

##### 4.2.22.7. CapElectronicLevelSetting

**Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**

(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Queries supported ELECTRONIC LEVEL SETTING selections.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapElectronicLevelSetting
lAPIParam (IN) <model>_API_PARAM_CapElectronicLevelSetting
plNum (OUT) Returns the number of “SetElectronicLevelSetting” settings supported.
plSetting (OUT) See lSetting of “SetElectronicLevelSetting”.
**Remarks**
This function can be used in State S3.
**See Also**

##### 4.2.22.1. SetElectronicLevelSetting

```
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);
```

**FJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 31 .0. 0**

```
4.2.22.1. SetElectronicLevelSetting
```
**Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**

(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Sets ELECTRONIC LEVEL SETTING.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetElectronicLevelSetting
lAPIParam (IN) <model>_API_PARAM_SetElectronicLevelSetting
lSetting (IN)
<model>_ELECTRONIC_LEVEL_SETTING_OFF OFF
<model>_ELECTRONIC_LEVEL_SETTING_2D 2D
<model>_ELECTRONIC_LEVEL_SETTING_^3 D^ 3D^
**Remarks**
This function can be used in State S3.
**See Also**
GetElectronicLevelSetting
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);


**FJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 31 .0. 0**

```
4.2.22.2. GetElectronicLevelSetting
```
**Supported Cameras
X-T1
X-T2
X-T3
X-T4
X-T**

(^5)
**X-Pro2
X-Pro3
X-S10
X-H2S
X-H2
X-S20
X-M5
GFX 50S
GFX 50R
GFX100
GFX100
S
GFX50S II
GFX100 II
GFX100
S** (^) **II
GFX100RF**
3 3 3 3 3 3 3 3
**Description**
Gets ELECTRONIC LEVEL SETTING.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetElectronicLevelSetting
lAPIParam (IN) <model>_API_PARAM_GetElectronicLevelSetting
plSetting (OUT) See lSetting of “SetElectronicLevelSetting”.
**Remarks**
This function can be used in State S3.
**See Also**
SetElectronicLevelSetting
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 31 .0. 0**

```
4.2.22.3. CapUSBPowerSupplyCommunication
```
**Supported Cameras
X-
T1
X-
T2
X-
T3
X-
T4
X-
T 5
X-
Pro2
X-
Pro3
X-
S10
X-
H2S
X-
H2
X-
S20
X-
M5
GFX
50S**

```
GFX 50R
GFX100
GFX100
```
```
S
```
```
GFX50S II
GFX100 II
GFX100
```
**S** (^) **II
GFX100RF**
^3^^3^^3^^3^^3^^3^
**Description**
Queries supported USBPOWER SUPPLY and COMMUNICATION SETTING selections.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapUSBPowerSupplyCommunication
lAPIParam (IN) <model>_API_PARAM_CapUSBPowerSupplyCommunication
plNum (OUT) Returns the number of “SetUSBPowerSupplyCommunication” settings supported.
plSetting (OUT) See lSetting of “SetUSBPowerSupplyCommunication”.
**Remarks**
This function can be used in State S3.
**See Also**

##### 4.2.22.4. SetUSBPowerSupplyCommunication

```
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);
```

**FJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 31 .0. 0**

```
4.2.22.4. SetUSBPowerSupplyCommunication
```
**Supported Cameras
X-
T1
X-
T2
X-
T3
X-
T4
X-
T 5
X-
Pro2
X-
Pro3
X-
S10
X-
H2S
X-
H2
X-
S20
X-
M5
GFX 50S
GFX 50R
GFX100
GFX100**

```
S
```
```
GFX50S II
GFX100 II
GFX100
```
**S** (^) **II
GFX100RF**
^3^^3^^3^^3^^3^^3^
**Description**
Sets the USB POWER SUPPLY / COMM SETTING.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetUSBPowerSupplyCommunication
lAPIParam (IN) <model>_API_PARAM_SetUSBPowerSupplyCommunication
lSetting (IN)
<model>_USB_POWER_SUPPLY_COMMUNICATION_AUTO Auto
<model>_USB_POWER_SUPPLY_COMMUNICATION_ON Power supply ON /
Communication OFF
<model>_USB_POWER_SUPPLY_COMMUNICATION_OFF Power supply OFF /
Communication ON^
**Remarks**
This function can be used in State S3.
<model>_USB_POWER_SUPPLY_COMMUNICATION_ON can use by only IP tether.
**See Also**

##### 4.2.22.5. GetUSBPowerSupplyCommunication

```
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);
```

**FJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 31 .0. 0**

```
4.2.22.5. GetUSBPowerSupplyCommunication
```
**Supported Cameras
X-
T1
X-
T2
X-
T3
X-
T4
X-
T 5
X-
Pro2
X-
Pro3
X-
S10
X-
H2S
X-
H2
X-
S20
X-
M5
GFX 50S
GFX 50R
GFX100
GFX100**

```
S
```
```
GFX50S II
GFX100 II
GFX100
```
**S** (^) **II
GFX100RF**
^3^^3^^3^^3^^3^^3^
**Description**
Gets the USB POWER SUPPLY / COMM SETTING.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetUSBPowerSupplyCommunication
lAPIParam (IN) <model>_API_PARAM_GetUSBPowerSupplyCommunication
plSetting (OUT) See lSetting of “SetUSBPowerSupplyCommunication”.
**Remarks**
This function can be used in State S3.
**See Also**
SetUSBPowerSupplyCommunication
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 31 .0. 0**

```
4.2.22.6. CapAutoPowerOffSetting
```
**Supported Cameras
X-
T1
X-
T2
X-
T3
X-
T4
X-
T 5
X-
Pro2
X-
Pro3
X-
S10
X-
H2S
X-
H2
X-
S20
X-
M5
GFX 50S
GFX 50R
GFX100
GFX100**

```
S
```
```
GFX50S II
GFX100 II
GFX100
```
**S** (^) **II
GFX100RF**
^3^^3^^3^^3^^3^^3^
**Description**
Queries supported AUTO POWER OFF settings.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_CapAutoPowerOffSetting
lAPIParam (IN) <model>_API_PARAM_CapAutoPowerOffSetting
plNum (OUT) Returns the number of “SetAutoPowerOffSetting” settings supported.
plSetting (OUT) See lSetting of “SetAutoPowerOffSetting”.
**Remarks**
This function can be used in State S3.
**See Also**

##### 4.2.22.7. SetAutoPowerOffSetting

```
APIENTRY XSDK_CapProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plNum,
long* plSetting
);
```

**FJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 31 .0. 0**

```
4.2.22.7. SetAutoPowerOffSetting
```
**Supported Cameras
X-
T1
X-
T2
X-
T3
X-
T4
X-
T 5
X-
Pro2
X-
Pro3
X-
S10
X-
H2S
X-
H2
X-
S20
X-
M5
GFX 50S
GFX 50R
GFX100
GFX100**

```
S
```
```
GFX50S II
GFX100 II
GFX100
```
**S** (^) **II
GFX100RF**
^3^^3^^3^^3^^3^^3^
**Description**
Sets the AUTO POWER OFF setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_SetAutoPowerOffSetting
lAPIParam (IN) <model>_API_PARAM_SetAutoPowerOffSetting
lSetting (IN)
<model>_AUTOPOWEROFF_OFF OFF
<model>_AUTOPOWEROFF_15SEC 1 5sec
<model>_AUTOPOWEROFF_30SEC 3 0sec
<model>_AUTOPOWEROFF_1MIN 1 min
<model>_AUTOPOWEROFF_2MIN 2 min
<model>_AUTOPOWEROFF_5MIN^5 min^
**Remarks**
This function can be used in State S3. **See Also**

##### 4.2.22.8. GetAutoPowerOffSetting

```
APIENTRY XSDK_SetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long lSetting
);
```

**FJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 31 .0. 0**

```
4.2.22.8. GetAutoPowerOffSetting
```
**Supported Cameras
X-
T1
X-
T2
X-
T3
X-
T4
X-
T 5
X-
Pro2
X-
Pro3
X-
S10
X-
H2S
X-
H2
X-
S20
X-
M5
GFX 50S
GFX 50R
GFX100
GFX100**

```
S
```
```
GFX50S II
GFX100 II
GFX100
```
**S** (^) **II
GFX100RF**
^3^^3^^3^^3^^3^^3^
**Description**
Gets the AUTO POWER OFF setting.
**Syntax
Return Value**
XSDK_COMPLETE : SUCCESS
XSDK_ERROR : ERROR
**Parameters**
hCamera (IN) The camera handle.
lAPICode (IN) <model>_API_CODE_GetAutoPowerOffSetting
lAPIParam (IN) <model>_API_PARAM_GetAutoPowerOffSetting
plSetting (OUT) See lSetting of “SetAutoPowerOffSetting”.
**Remarks**
This function can be used in State S3.
**See Also**
SetAutoPowerOffSetting
APIENTRY XSDK_GetProp(
XSDK_HANDLE hCamera,
long lAPICode,
long lAPIParam,
long* plSetting
);


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

**5. Error Codes**

Error Code macro definition Level Description
XSDK_ERRCODE_NOERR OK No error
XSDK_ERRCODE_SEQUENCE FATAL Function call sequence error
XSDK_ERRCODE_PARAM FATAL Function parameter error
XSDK_ERRCODE_INVALID_CAMERA INFO Invalid camera.
XSDK_ERRCODE_LOADLIB FATAL Lower-layer libraries cannot be loaded
XSDK_ERRCODE_UNSUPPORTED FATAL Unsupported function call
XSDK_ERRCODE_BUSY INFO Camera is busy
XSDK_ERRCODE_FORCEMODE_BUSY INFO Camera is in busy. XSDK_SetForceMode can be used to recover.
XSDK_ERRCODE_AF_TIMEOUT INFO Unable to focus using autofocus.
XSDK_ERRCODE_SHOOT_ERROR FATAL Error occurred during shooting.
XSDK_ERRCODE_FRAME_FULL INFO Frame buffer full; release canceled.
XSDK_ERRCODE_STANDBY INFO System standby.
XSDK_ERRCODE_NODRIVER FATAL No camera found.
XSDK_ERRCODE_NO_MODEL_MODULE FATAL No library; model-dependent function cannot be called.
XSDK_ERRCODE_API_NOTFOUND FATAL Unknown model-dependent function call.
XSDK_ERRCODE_API_MISMATCH FATAL Parameter mismatch for model-dependent function call.
XSDK_ERRCODE_COMMUNICATION FATAL Communication error.
XSDK_ERRCODE_TIMEOUT FATAL Operation timeout for unknown reasons.
XSDK_ERRCODE_COMBINATION FATAL Function call combination error.
XSDK_ERRCODE_WRITEERROR INFO Memory card write error. Memory card must be replaced.
XSDK_ERRCODE_CARDFULL INFO Memory card full. Memory card must be replaced or formatted.
XSDK_ERRCODE_HARDWARE FATAL Camera hardware error.
XSDK_ERRCODE_INTERNAL FATAL Unexpected internal error.
XSDK_ERRCODE_MEMFULL FATAL Unexpected memory error.
XSDK_ERRCODE_UNKNOWN FATAL Other unexpected error.
XSDK_ERRCODE_RUNNING_OTHER_FUNCTION INFO Camera is busy.
The busy status may be recovered by canceling the other functions.
Call XSDK_GetErrorDetails to get details for the other function.

FATAL: System cannot be used.
INFO: Information only. System can be used.
OK: System can be used.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

**6. Sample Source Code**

**6.1. HotFolder**

**6.1.1. Overview**
The HotFolder source project helps you understand:

- how to detect cameras when they are connected or turned on,
- how to detect cameras when they disconnected or turned off, and
- how to download pictures after they are taken.

**6.1.2. Compatible OS, Development Environment, Langage, Libraries**
Windows10, Windows8.1, and Windows7.
OS Windows macOS Linux Android
Development Environment Microsoft Visual
Studio 201 3

```
Xcode 12 - Android Studio
```
Language C++ Swift C++ Kotlin
C++(JNI)
Libraries MFC - - SDK3 4
CMake

**6.1.3. Operations (for Windows)**
Once launched, the software appears in the Windows task tray. The state of the connection to the camera is shown by an
icon that blinks green and white.

To choose a destination for pictures downloaded from the camera, click the icon in the task tray and choose **Select a
folder to receive images**.

**6.1.4. Operations** (for macOS)
Once launched, the software appears in the Menu-bar. The state of the connection to the camera is shown by an icon that
blinks green and white.

```
< >
```
To choose a destination for pictures downloaded from the camera, click the icon in the Menu-bar and choose **Select a
folder to receive images**.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

**6.2. ReleaseButton (for Windows)**

**6.2.1. Overview**
The ReleaseButton source project helps you understand:

- how to initiate the shutter-release from the computer, and
- how to detect the completion of the shutter-release.
This source project is written in Microsoft Visual Studio 2013 for easy conversion to newer versions of Visual Studio.

**6.2.2. Compatible OS**
Windows10, Windows8.1, and Windows7.


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

**6.3. ZoomPos**

**6.3.1. Overview**
The ZoomPos source project helps you understand:

- how to receive the zoom position, and
- how to convert the zoom position to the focal length.
This source project is written in Microsoft Visual Studio 2013 for easy conversion to newer versions of Visual Studio.

**6.3.2. Compatible OS, Development Environment, Langage, Libraries**

OS Windows macOS Linux Android
Development
Environment

```
Microsoft Visual
Studio 2022 C#
```
Visual Studio Code Visual Studio Code Kotlin
C++(JNI)
Language C# C# C# Kotlin
C++(JNI)
Libraries - .NET MAUI .Net 9.0 SDK3 4
CMake


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

**6.4. Multiple**

**6.4.1. Overview**

The Multiple source project helps you understand:

- how to use multiple cameras simultaneously
- how to search camera connections, to control an additional camera, and to delete disappeared cameras.

**6.4.2. Compatible OS, Development Environment, Langage, Libraries**

OS Windows macOS Linux
Development Environment Microsoft Visual
Studio 2022 C#

```
Xcode 15 -
```
Language C# Swift
Objective-C

```
C++
```
Libraries - - -


**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

**6.5. Liveview**

**6.5.1. Overview**
The Multiple source project helps you understand:

- how to start/stop live view.
- how to control a camera while live view is in use.

**6.5.2. Compatible OS, Development Environment, Langage, Libraries**

OS Windows macOS Linux Android
Development Environment - - - Android Studio

Langage Python3.11 Python3.11 Python3.11 Kotlin
C++(JNI)
Libraries Tkinter
Pillow

```
Tkinter
Pillow
```
```
Tkinter
Pillow
```
```
SDK3 4
CMake
```

**FUJIFILM X Series/GFX System Digital Camera Control Software Development Kit - Rev. 1. 33 .0. 0**

**7. Appendix**

**7.1. XFileName**

**7.1.1. Overview**
X and GFX Series cameras record the sequential file number (unique id) in the MakerNote information for transferred
images. The pictures in each pair of photos shot in RAW+JPEG mode have the same sequential file number (unique id)
in the MakerNote information, aiding in the identification of RAW+JPEG pairs.
If XSDK_SetMediaRecord is enabled (thus ensuring that pictures uploaded in PC SHOOT mode are also saved to the
camera memory card), X and GFX Series cameras will also record the file name to the memory card in the MakerNote
information field.
The sample code can be used to parse the information (identifying RAW+JPEG pairs and identifying the file name for
the memory card) from the transferred images. You can find this code in the SAMPLE folder in the XFileName
sub-folder.
Important Notices:

- This source code is written for little-endian systems only.
- This source code is not error-free.
- This source code is provided on an AS IS BASIS, with NO WARRANTY, with NO LIABILITY.


