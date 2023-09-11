using FreshMvvm;
using Imi.Project.Mobile.Domain.Api.Interfaces;
using Imi.Project.Mobile.Domain.Dtos;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Infrastructure;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class CreateViewModel : FreshBasePageModel
    {

        private readonly IApiAnimalRepository _animalService;

        public CreateViewModel(IApiAnimalRepository animalService)
        {
            _animalService = animalService;
        }

        #region PROPERTIES

        private string nameDutch;

        public string NameDutch
        {
            get { return nameDutch; }
            set
            {
                nameDutch = value;
                RaisePropertyChanged();
            }
        }

        private string nameFamily;

        public string NameFamily
        {
            get { return nameFamily; }
            set
            {
                nameFamily = value;
                RaisePropertyChanged();
            }
        }

        //private Uri image;

        //public Uri Image
        //{
        //    get { return image; }
        //    set
        //    {
        //        image = value;
        //        RaisePropertyChanged();
        //    }
        //}

        private int tempMin;

        public int TempMin
        {
            get { return tempMin; }
            set
            {
                tempMin = value;
                RaisePropertyChanged();
            }
        }

        private int tempMax;

        public int TempMax
        {
            get { return tempMax; }
            set
            {
                tempMax = value;
                RaisePropertyChanged();
            }
        }

        private int phMin;

        public int PhMin
        {
            get { return phMin; }
            set
            {
                phMin = value;
                RaisePropertyChanged();
            }
        }

        private int phMax;

        public int PhMax
        {
            get { return phMax; }
            set
            {
                phMax = value;
                RaisePropertyChanged();
            }
        }

        private int ghMin;

        public int GhMin
        {
            get { return ghMin; }
            set
            {
                ghMin = value;
                RaisePropertyChanged();
            }
        }

        private int ghMax;

        public int GhMax
        {
            get { return ghMax; }
            set
            {
                ghMax = value;
                RaisePropertyChanged();
            }
        }

        private string breeding;

        public string Breeding        
        {
            get { return breeding; }
            set
            {
                breeding = value;
                RaisePropertyChanged();
            }
        }

        private string diet;

        public string Diet
        {
            get { return diet; }
            set
            {
                diet = value;
                RaisePropertyChanged();
            }
        }

        private string continent;

        public string Continent
        {
            get { return continent; }
            set
            {
                continent = value;
                RaisePropertyChanged();
            }
        }

        private string kind;

        public string Kind
        {
            get { return kind; }
            set
            {
                kind = value;
                RaisePropertyChanged();
            }
        }

        private string social;

        public string Social
        {
            get { return social; }
            set
            {
                social = value;
                RaisePropertyChanged();
            }
        }


        #endregion

        public override async void Init(object initData)
        {
            if (initData is CreateEditDto)
            {
                CreateEditDto id = (CreateEditDto)initData;

                var animal = await _animalService.AddAnimalAsync(id);

                NameDutch = animal.NameDutch;
                NameFamily = animal.NameFamily;
                //Image = animal.Image;
                TempMin = animal.TempMin;
                TempMax = animal.TempMax;
                GhMin = animal.GhMin;
                GhMax = animal.GhMax;
                PhMin = animal.PhMin;
                PhMax = animal.PhMax;
                Breeding = animal.Breeding.Name;
                Continent = animal.Continent.Name;
                Diet = animal.Diet.Name;
                Kind = animal.Kind.Name;
                Social = animal.Social.Name;

            }
            else
            {
                throw new ArgumentException("Init data must be of type Guid", nameof(initData));
            }
        }
    }
}