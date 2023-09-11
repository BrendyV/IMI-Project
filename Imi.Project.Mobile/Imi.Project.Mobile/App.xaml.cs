using FreshMvvm;
using Imi.Project.Mobile.Domain.Services.Infrastructure;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.ViewModels;
using Xamarin.Forms;
using Imi.Project.Mobile.Domain.NativeServices;
using Imi.Project.Mobile.Domain.Api.Interfaces;
using Imi.Project.Mobile.Domain.Api.Services;

namespace Imi.Project.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjI4NjQ4QDMyMzAyZTMxMmUzMExFRHlPWmZHdHJPeXRReFVUcXh1R2RvTHJ3U3dVaFU2YVhobFk1OEpyQkk9");

            FreshIOC.Container.Register<IAnimalRepository, AnimalService>().AsMultiInstance();
            FreshIOC.Container.Register<IApiAnimalRepository, ApiAnimalService>().AsMultiInstance();
            FreshIOC.Container.Register<IApiLoginService,ApiLoginService>().AsMultiInstance();

            FreshIOC.Container.Register(DependencyService.Get<IDeviceInformationService>());

            InitializeComponent();

            MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<MainViewModel>());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
