﻿using System.IO;
using Artemis.Core.DeviceProviders;
using Artemis.Core.Services;
using RGB.NET.Core;
using RGB.NET.Devices.Corsair;

namespace Artemis.Plugins.Devices.Corsair
{
    // ReSharper disable once UnusedMember.Global
    public class CorsairDeviceProvider : DeviceProvider
    {
        private readonly IRgbService _rgbService;

        public CorsairDeviceProvider(IRgbService rgbService) : base(RGB.NET.Devices.Corsair.CorsairDeviceProvider.Instance)
        {
            _rgbService = rgbService;
        }

        public override void EnablePlugin()
        {
            PathHelper.ResolvingAbsolutePath += (sender, args) => ResolveAbsolutePath(typeof(CorsairRGBDevice<>), sender, args);
            RGB.NET.Devices.Corsair.CorsairDeviceProvider.PossibleX64NativePaths.Add(Path.Combine(PluginInfo.Directory.FullName, "x64", "CUESDK.x64_2017.dll"));
            RGB.NET.Devices.Corsair.CorsairDeviceProvider.PossibleX86NativePaths.Add(Path.Combine(PluginInfo.Directory.FullName, "x86", "CUESDK_2017.dll"));
            _rgbService.AddDeviceProvider(RgbDeviceProvider);
        }
    }
}