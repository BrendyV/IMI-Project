using FreshMvvm;
using Imi.Project.Mobile.Domain.Api;
using Imi.Project.Mobile.Domain.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class LoginViewModel : FreshBasePageModel
    {
        private IApiLoginService _loginService;

        public LoginViewModel(IApiLoginService loginService)
        {
            _loginService = loginService;
        }

        #region PROPERTIES
        private string email = "mde-user@imi.be";

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                RaisePropertyChanged();
            }
        }

        private string password = "Test123?";

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        public ICommand LoginCommand => new Command(
            async () =>
            {
                if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                {
                    await CoreMethods.DisplayAlert("Foutmelding", "Gelieve email en/of wachtwoord in te vullen", "Oké");
                    return;
                }


                var result = await _loginService.Login(Email, Password);

                if (!result)
                {
                    await CoreMethods.DisplayAlert("Foutmelding", "Gebruikersnaam of passwoord is incorrect!", "Oké");
                    return;
                }
                else
                {
                    await CoreMethods.PushPageModel<AnimalViewModel>(true);
                }
            });

    }
}
