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
	}
}