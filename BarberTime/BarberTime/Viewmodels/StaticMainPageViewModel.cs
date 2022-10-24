using CommunityToolkit.Mvvm.ComponentModel;
using BarberTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Image: new Uri("https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.dmarge.com%2Fwp-content%2Fuploads%2F2022%2F09%2F4-textured-quiff-haircut-on-black-hair-960x1200.jpeg&imgrefurl=https%3A%2F%2Fwww.dmarge.com%2Fpopular-mens-haircuts&tbnid=6r73Z1lYNM5xTM&vet=12ahUKEwjjxeecmN36AhWWwbsIHSXgBxsQMygDegUIARDhAQ..i&docid=N1Wtza28rCiaDM&w=960&h=1200&q=hair%20cut&ved=2ahUKEwjjxeecmN36AhWWwbsIHSXgBxsQMygDegUIARDhAQ"),
                    Price: 25 )};
        }
    }
}
