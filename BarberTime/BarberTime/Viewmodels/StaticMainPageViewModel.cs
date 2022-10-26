using CommunityToolkit.Mvvm.ComponentModel;
using BarberTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace BarberTime.Viewmodels
{
     public partial class StaticMainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        List<StaticMainPage> staticMainPage;

        public StaticMainPageViewModel()
        {
            LoadStaticPage();
        }

        private void LoadStaticPage()
        {
            StaticMainPage = new()
            {
                new StaticMainPage(
                    Name: "Knip en style",
                    Description: "Knipbeurt + style met luxe haar producten",
                    Image: "haircut1.JPG",
                    Price: "€25" )};
        }

        [RelayCommand]
        private async void AgendaButtonClick()
        {
            await Shell.Current.GoToAsync("Agendapage");
        }

        [RelayCommand]
        private async void MijnAfspraakButtonClick()
        {
            await Shell.Current.GoToAsync("Agendapage");
        }

    }
}
