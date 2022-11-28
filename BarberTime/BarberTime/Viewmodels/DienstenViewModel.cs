using BarberTime.Models;
using BarberTime.Services;
using BarberTime.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BarberTime.Viewmodels
{
    public class DienstenViewModel : BaseViewModel
    {
        #region Properties

        public ObservableCollection<DienstenModel> Dienst { get; set; } = new ObservableCollection<DienstenModel>();
        private readonly DienstService _dienstService;
        #endregion

        #region Constructor
        public DienstenViewModel()
        {
            _dienstService = new DienstService();
        }
        #endregion

        #region Methods
        public void ShowDiensten()
        {
            var allDiensten = _dienstService.GetAllDiensten();

            if (allDiensten?.Count > 0)
            {
                Dienst.Clear();
                foreach (var dienst in allDiensten)
                {
                    Dienst.Add(dienst);
                }
            }
        }
        #endregion

        #region Commands
        public ICommand NavigateToAddDienstPageCommand => new Command(async () =>
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddDienstPage());
        });


        public ICommand SelectedDienstCommand => new Command<DienstenModel>(async (dienst) =>
        {
            string res = await App.Current.MainPage.DisplayActionSheet("Operation", "Cancel", null, "Update", "Delete");

            switch (res)
            {
                case "Update":
                    await App.Current.MainPage.Navigation.PushAsync(new AddDienstPage(dienst));
                    break;
                case "Delete":
                    int del = _dienstService.DeleteDienst(dienst);
                    if (del > 0)
                    {
                        Dienst.Remove(dienst);
                    }
                    break;
            }
        });
        #endregion
    }
}
