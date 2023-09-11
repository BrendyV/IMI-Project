using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Domain.NativeServices
{
    public  class DeviceInformation
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string ReleaseVersion { get; set; }
        public bool CanVibrate { get; set; }
        
    }
}
