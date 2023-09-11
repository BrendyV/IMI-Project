using FreshMvvm;
using Imi.Project.Mobile.Domain.Api.Services;
using Imi.Project.Mobile.Domain.Dtos;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class AnimalViewModel : FreshBasePageModel
    {
        private ObservableCollection<AnimalDto> animals;
        public ObservableCollection<AnimalDto> Animals
        {
            get { return animals; }
            set
            {
                animals = value;
                RaisePropertyChanged();
            }
        }
        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
            var response = await WebApiClient.GetApiResult<IEnumerable<AnimalDto>>($"{Constants._baseUri}api/animals");
            Animals = new ObservableCollection<AnimalDto>(response);
        }
        public ICommand OpenCreatePageCommand => new Command<InfoDto>(
            async (InfoDto animal) => { await CoreMethods.PushPageModel<CreateViewModel>(animal, false, false); });


        public ICommand ShowInfoCommand => new Command<Guid>(
            (Id) => { CoreMethods.PushPageModel<InfoViewModel>(Id); });

    }
}
