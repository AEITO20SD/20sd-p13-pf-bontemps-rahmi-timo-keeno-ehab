using BarberTime.Models;
using BarberTime.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BarberTime.Viewmodels
{
    public class AddDienstPageViewModel : BaseViewModel
    {
        #region Properties
        private string _name;
        public string Name
        {
            get => _name; 
            set =>SetProperty(ref _name, value);
        }

        private string _length;
        public string Length
        {
            get => _length;
            set => SetProperty(ref _length, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private string _price;
        public string Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }

        private int _dienstID;
        private readonly DienstService _dienstService;
        #endregion

        #region Constructor
        public AddDienstPageViewModel()
        {
            _dienstService = new DienstService();
        }

        public AddDienstPageViewModel(DienstenModel dienstObj)
        {
            Name = dienstObj.Name;
            Length = dienstObj.Length;
            Description = dienstObj.Description;
            Price = dienstObj.Price;
            _dienstID = dienstObj.Id;
            _dienstService = new DienstService();

        }
        #endregion


        #region Commands
        public ICommand AddDienstCommand => new Command(async () =>
        {
            DienstenModel obj = new DienstenModel
            {
                Length = Length,
                Price = Price,
                Description = Description,
                Name = Name,
                Id = _dienstID
            };
            if (_dienstID > 0)
            {
                _dienstService.UpdateDienst(obj);
            }
            else
            {
                _dienstService.InsertDienst(obj);
            }
            await App.Current.MainPage.Navigation.PopAsync();
        });
        #endregion
    }
}
