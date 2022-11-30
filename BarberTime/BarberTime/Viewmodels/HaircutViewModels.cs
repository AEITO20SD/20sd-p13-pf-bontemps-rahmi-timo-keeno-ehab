using BarberTime.Models;
using BarberTime.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BarberTime.Viewmodels
{
    public partial class HaircutViewModels : ObservableObject
    {
        [ObservableProperty]
        List<PopulairHaircut> populairhaircuts;

        public HaircutViewModels()
        {
            LoadPopulairHaircuts();

        }

        public Command<PopulairHaircut> itemCommand { get; }

        [RelayCommand]
        async Task Tap(string s)
        {
            await Shell.Current.GoToAsync(nameof(HaircutDetailPage));
        }


    private void LoadPopulairHaircuts()
        {
            ObservableCollection<PopulairHaircut> PopulairHaircutss;


            PopulairHaircutss = new()
            {
                new PopulairHaircut()
                {
                    Naam =  "Classic Pompadour",
                    Afbeelding = "man_bun.png"
                },

                new PopulairHaircut()
                {
                    Naam =  "Medium Curls ",
                    Afbeelding = "medium_curls.png"
                },

                 new PopulairHaircut()
                {
                    Naam =  "Assymetrical Bang",
                    Afbeelding = "undercut_fade.png"
                },

                new PopulairHaircut()
                {
                    Naam =  "Spickey Texture ",
                    Afbeelding ="modern_mullet.png"
                },

            };

        }

    }

}


