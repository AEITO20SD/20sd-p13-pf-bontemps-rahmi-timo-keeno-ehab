using BarberTime.Models;
using BarberTime.Services;
using BarberTime.Viewmodels;

namespace BarberTime.Views;

public partial class AddDienstPage : ContentPage
{
    public AddDienstPage()
    {
        InitializeComponent();
        this.BindingContext = new AddDienstPageViewModel();
    }

    public AddDienstPage(DienstenModel obj)
    {
        InitializeComponent();
        this.BindingContext = new AddDienstPageViewModel(obj);
    }
}