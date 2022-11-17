using BarberTime.Models;
using System.Collections.Generic;

namespace BarberTime.Views;
public partial class CreateAccountPage : ContentPage
{
	public CreateAccountPage()
	{
		InitializeComponent();
	}
    public void OnNewButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        App.AccountRepo.AddNewPerson(name.Text, email.Text, password.Text, number.Text);
        statusMessage.Text = App.AccountRepo.StatusMessage;
    }

    public void OnGetButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        List<CreateAccount> people = App.AccountRepo.GetAllPeople();
        peopleList.ItemsSource = people;
    }
}