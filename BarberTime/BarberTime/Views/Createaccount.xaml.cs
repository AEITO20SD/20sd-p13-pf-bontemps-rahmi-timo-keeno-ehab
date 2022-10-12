using BarberTime.Models;
using Java.Lang;
using System.Collections.Generic;
using static Java.Util.Jar.Attributes;

namespace BarberTime;

public partial class CreateAccount : ContentPage
{
    public CreateAccount()
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

        List<Createaccount> people = App.AccountRepo.GetAllPeople();
        peopleList.ItemsSource = people;
    }
}
