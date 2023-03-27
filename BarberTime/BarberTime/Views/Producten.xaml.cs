namespace BarberTime.Views;
using System;

public partial class Producten : ContentPage
{
	public Producten()
	{
        InitializeComponent();

        webView.Source="http://512359057.swh.strato-hosting.eu/barbertime/index.php";
    }
}
