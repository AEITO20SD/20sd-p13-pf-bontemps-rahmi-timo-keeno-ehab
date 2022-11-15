namespace BarberTime.Views;
using System;

public partial class Producten : ContentPage
{
	public Producten()
	{
        InitializeComponent();

        webView.Source="http://151965.ao-alkmaar.nl/";
    }
}
