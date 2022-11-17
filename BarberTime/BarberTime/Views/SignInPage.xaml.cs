namespace BarberTime.Views;

public partial class SignInPage : ContentPage
{
	public SignInPage()
	{
		InitializeComponent();
	}
	private async void TapGestureForSign(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("//CreateAccountPage");
    }
}