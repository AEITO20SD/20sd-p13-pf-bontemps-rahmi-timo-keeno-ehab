using BarberTime.Models;
using BarberTime.Services;
using BarberTime.Viewmodels;

namespace BarberTime.Views;

public partial class Diensten : ContentPage
{
    private DienstenViewModel _viewModel;
    public Diensten()
    {
        InitializeComponent();
        _viewModel = new DienstenViewModel();
        this.BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.ShowDiensten();
    }
}