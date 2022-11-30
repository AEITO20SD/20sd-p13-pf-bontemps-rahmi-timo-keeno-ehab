using BarberTime.Models;
using BarberTime.Models.Agenda;
using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XCalendar.Core.Enums;
using XCalendar.Core.Models;

namespace BarberTime.Viewmodels.Agenda
{
    internal partial class AgendaViewModel : ObservableObject
    {

        private SQLiteConnection conn;

        [ObservableProperty]
        public ObservableCollection<AgendaTimeViewModel> timesViewModel;
        public Calendar<CalendarDay> Calendar { get; set; } = new Calendar<CalendarDay>()
        {
            SelectionType = SelectionType.Single,
            SelectionAction = SelectionAction.Replace
        };
        [ObservableProperty]
        private bool _showHours;

        [ObservableProperty]
        private string _notifyUserNoHoursLeft;
    
        #region Commands
        public ICommand NavigateCalendarCommand { get; set; }
        public ICommand ChangeDateSelectionCommand { get; set; }
        public ICommand SaveReservationCommand { get; set; }

        #endregion

        #region Constructors
        public AgendaViewModel()
        {
            NavigateCalendarCommand = new Command<int>(NavigateCalendar);
            ChangeDateSelectionCommand = new Command<DateTime>(ChangeDateSelection);
            SaveReservationCommand = new Command(SaveReservation);

            ShowHours = false;
            TimesViewModel = new ObservableCollection<AgendaTimeViewModel>();
            LoadTimes();

            var dbPath = FileAccessHelper.GetLocalFilePath("BarberTime.db3");
            // Code to initialize the repository.
            if (conn != null)
                return;

            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<Reservation>();
        }
        #endregion

        #region Methods
        private void LoadTimes()
        {
            TimesViewModel.Add(new AgendaTimeViewModel()
            {
                Time = "08:00",
                IsAvailable = true             
            });
            TimesViewModel.Add(new AgendaTimeViewModel()
            {
                Time = "09:00",
                IsAvailable = true
            }); TimesViewModel.Add(new AgendaTimeViewModel()
            {
                Time = "10:00",
                IsAvailable = true
            }); TimesViewModel.Add(new AgendaTimeViewModel()
            {
                Time = "11:00",
                IsAvailable = true
            }); TimesViewModel.Add(new AgendaTimeViewModel()
            {
                Time = "12:00",
                IsAvailable = true
            }); TimesViewModel.Add(new AgendaTimeViewModel()
            {
                Time = "13:00",
                IsAvailable = true
            }); TimesViewModel.Add(new AgendaTimeViewModel()
            {
                Time = "14:00",
                IsAvailable = true
            }); TimesViewModel.Add(new AgendaTimeViewModel()
            {
                Time = "15:00",
                IsAvailable = true
            });
            TimesViewModel.Add(new AgendaTimeViewModel()
            {
                Time = "16:00",
                IsAvailable = true
            }); TimesViewModel.Add(new AgendaTimeViewModel()
            {
                Time = "17:00",
                IsAvailable = true
            }); TimesViewModel.Add(new AgendaTimeViewModel()
            {
                Time = "18:00",
                IsAvailable = true
            }); TimesViewModel.Add(new AgendaTimeViewModel()
            {
                Time = "19:00",
                IsAvailable = true
            });
        }
      
        public void NavigateCalendar(int Amount)
        {
            Calendar?.NavigateCalendar(Amount);
        } 
        public void ChangeDateSelection(DateTime DateTime)
        {
            Calendar?.ChangeDateSelection(DateTime);

            // Reset TimesViewModel naar startup waardes.
            foreach(var timeViewModel in TimesViewModel)
            {
                timeViewModel.IsChecked = false;
                timeViewModel.IsAvailable = true;
            }

            // Haal alle reservaties op vanaf database.
            List<Reservation> reservations = conn.Query<Reservation>("Select * From Reservation");

            // Voor. 
            foreach (var reservation in reservations.Where(m=>m.Date == DateTime.ToString()))
            {
                TimesViewModel.FirstOrDefault(m => m.Time == reservation.Time).IsAvailable = false;
            }

            if (TimesViewModel.Any(m=>m.IsAvailable))
            {
                ShowHours = true;
                NotifyUserNoHoursLeft = "";
            }
            else
            {
                ShowHours = false;
                NotifyUserNoHoursLeft = $"{DateTime.ToString("D")} Heeft geen beschikbare uren!";
            }
        }

        public void SaveReservation()
        {
            var selectedTime = TimesViewModel.FirstOrDefault(m => m.IsChecked);
            conn.Insert(new Reservation { Date = Calendar?.SelectedDates.FirstOrDefault().ToString(), Time = selectedTime.Time });
            selectedTime.IsAvailable = false;
            selectedTime.IsChecked = false;
        }
        #endregion
    }
}
