using Android.Content;
using Android.Hardware;
using Android.OS;
using Imi.Project.Mobile.Domain.NativeServices;
using System.Collections.Generic;
using Xamarin.Forms;

[assembly: Dependency(typeof(Imi.Project.Mobile.Droid.Services.DroidDeviceInformationService))]


namespace Imi.Project.Mobile.Droid.Services
{
    internal class DroidDeviceInformationService : IDeviceInformationService
    {
        public DeviceInformation GetDeviceInfo()
        {
            var info = new DeviceInformation
            {
                Manufacturer = Build.Manufacturer,
                Model = Build.Model,
                ReleaseVersion = Build.VERSION.Release + Build.VERSION.Incremental,
                CanVibrate = false,
                
            };

            using (var vib =
                (Vibrator)Android.App.Application.Context.GetSystemService(Context.VibratorService))
            {
                info.CanVibrate = vib.HasVibrator;
            }


            return info;
        }
    }
}