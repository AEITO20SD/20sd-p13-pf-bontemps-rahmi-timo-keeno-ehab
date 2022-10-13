using BarberTime.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private void LoadPopulairHaircuts()
        {
            Populairhaircuts = new()
            {
                new PopulairHaircut()
                {
                    Naam =  ("Classic Pompadour"),
                    Afbeelding =new Uri("")
                },

                new PopulairHaircut()
                {
                    Naam =  ("Medium Curls "),
                    Afbeelding =new Uri("")
                },

                 new PopulairHaircut()
                {
                    Naam =  ("Assymetrical Bang"),
                    Afbeelding =new Uri("")
                },

                new PopulairHaircut()
                {
                    Naam =  ("Spickey Texture "),
                    Afbeelding =new Uri("")
                },

            };
        }
    }
}
