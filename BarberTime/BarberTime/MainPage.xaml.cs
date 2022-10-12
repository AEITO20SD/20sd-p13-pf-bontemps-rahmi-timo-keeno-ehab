using BarberTime.Viewmodels;

namespace BarberTime;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new StaticMainPageViewModel();
	}
}

