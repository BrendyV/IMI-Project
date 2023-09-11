using FreshMvvm;
using Imi.Project.Mobile.Domain.NativeServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.ViewModels
{
    public class DeviceViewModel : FreshBasePageModel
    {
        private readonly IDeviceInformationService _deviceInfoService;

        public DeviceViewModel(IDeviceInformationService deviceInfoService)
        {
            _deviceInfoService = deviceInfoService;
        }

        public DeviceInformation Info { get; set; }

        public override void Init(object initData)
        {
            base.Init(initData);
            Info = _deviceInfoService.GetDeviceInfo();
        }
    }
}
