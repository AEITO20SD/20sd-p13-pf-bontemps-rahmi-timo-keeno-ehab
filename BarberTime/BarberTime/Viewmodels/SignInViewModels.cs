using System;
using System.Collections.Generic;
using System.Linq;

namespace BarberTime.Viewmodels
{
    internal class SignInViewModels
    {
        private async void SignIn(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
    }
}
