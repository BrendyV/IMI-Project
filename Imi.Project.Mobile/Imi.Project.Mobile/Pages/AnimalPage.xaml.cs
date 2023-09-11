using Imi.Project.Mobile.Domain.Dtos;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnimalPage : ContentPage
    {
        public AnimalPage()
        {
            InitializeComponent();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var viewmodel = (AnimalViewModel)BindingContext;
            var tappedAnimal = (AnimalDto)e.Item;
            viewmodel.ShowInfoCommand.Execute(tappedAnimal.Id);
        }
    }
}