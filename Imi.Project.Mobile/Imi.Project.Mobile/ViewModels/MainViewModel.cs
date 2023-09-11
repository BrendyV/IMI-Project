using FreshMvvm;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class MainViewModel : FreshBasePageModel
    {


        public Command AnimalCommand
        {
            get { return new Command(ExecuteAnimalCommand); }
        }

        private async void ExecuteAnimalCommand()
        {
            await CoreMethods.PushPageModel<AnimalViewModel>();
        }

        public Command DevicePageCommand => new Command(async () =>
        {
            await CoreMethods.PushPageModel<DeviceViewModel>();
        });

        public Command LoginPageCommand => new Command(async () =>
        {
            await CoreMethods.PushPageModel<LoginViewModel>();
        });

    }
}
