using BarberTime.Models;
using BarberTime.Viewmodels;

namespace BarberTime.Views
{
	public partial class HaircutDetailPage : ContentPage
	{
		public HaircutDetailPage(HaircutDetailViewModel viewModel)
		{
			InitializeComponent();
			BindingContext = viewModel;

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

