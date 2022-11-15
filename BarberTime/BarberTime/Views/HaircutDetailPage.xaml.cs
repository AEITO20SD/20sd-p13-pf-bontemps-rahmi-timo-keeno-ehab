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
	}
}