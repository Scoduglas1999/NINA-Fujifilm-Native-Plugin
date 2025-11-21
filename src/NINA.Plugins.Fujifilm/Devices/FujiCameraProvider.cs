using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading;
using System.Threading.Tasks;
﻿using NINA.Core.Utility;
using NINA.Equipment.Interfaces;
using NINA.Equipment.Interfaces.ViewModel;
using NINA.Image.Interfaces;
using NINA.Plugin.Interfaces;
using NINA.Profile.Interfaces;

namespace NINA.Plugins.Fujifilm.Devices;

    [Export(typeof(IEquipmentProvider))]
    public class FujiCameraProvider : IEquipmentProvider<ICamera>
    {
        private readonly IFujiCameraFactory _factory;

        public string Name => "Fujifilm";

        [ImportingConstructor]
        public FujiCameraProvider(IFujiCameraFactory factory)
        {
            try { System.IO.File.AppendAllText(@"c:\Users\scdou\Documents\NINA.Fujifilm.Plugin\debug_log.txt", $"[{DateTime.Now}] FujiCameraProvider Constructor called\n"); } catch {}
            _factory = factory;
        }

        public IList<ICamera> GetEquipment()
        {
            try 
            { 
                System.IO.File.AppendAllText(@"c:\Users\scdou\Documents\NINA.Fujifilm.Plugin\debug_log.txt", $"[{DateTime.Now}] FujiCameraProvider.GetEquipment called\n"); 
                
                var descriptors = _factory.GetAvailableCamerasAsync(CancellationToken.None).GetAwaiter().GetResult();
                System.IO.File.AppendAllText(@"c:\Users\scdou\Documents\NINA.Fujifilm.Plugin\debug_log.txt", $"[{DateTime.Now}] FujiCameraProvider: Found {descriptors.Count} cameras\n");

                var cameras = new List<ICamera>();
                foreach (var descriptor in descriptors)
                {
                    System.IO.File.AppendAllText(@"c:\Users\scdou\Documents\NINA.Fujifilm.Plugin\debug_log.txt", $"[{DateTime.Now}] FujiCameraProvider: Creating camera for {descriptor.DisplayName}\n");
                    cameras.Add(_factory.CreateGenericCamera(descriptor));
                }

                return cameras;
            } 
            catch (Exception ex)
            {
                System.IO.File.AppendAllText(@"c:\Users\scdou\Documents\NINA.Fujifilm.Plugin\debug_log.txt", $"[{DateTime.Now}] FujiCameraProvider.GetEquipment FAILED: {ex}\n");
                return new List<ICamera>();
            }
        }
    }
