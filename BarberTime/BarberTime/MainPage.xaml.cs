using BarberTime.Viewmodels;
﻿using BarberTime.Views;


namespace BarberTime;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new StaticMainPageViewModel();
	}
	private async void DienstButtonClick(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("Diensten");
    }
}

