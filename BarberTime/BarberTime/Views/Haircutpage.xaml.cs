using BarberTime.Models;
using BarberTime.Viewmodels;

namespace BarberTime.Views
{
	public partial class Haircutpage : ContentPage
	{
		public Haircutpage()
		{
			InitializeComponent();
			BindingContext = new HaircutViewModels();
		}

		private void hairCutCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
            var itemSelected = e.CurrentSelection[0] as PopulairHaircut;
            if (itemSelected != null)
            {
                Routing.RegisterRoute(nameof(HaircutDetailPage), typeof(HaircutDetailPage));
            }
           
            //App.Current.MainPage.DisplayAlert("Item", $"{itemSelected.Naam}", "OK");
        }
    }
}