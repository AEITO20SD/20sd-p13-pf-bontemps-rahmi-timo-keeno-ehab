using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
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
    internal class AgendaViewModel : BaseViewModel
    {
        public Calendar<CalendarDay> Calendar { get; set; } = new Calendar<CalendarDay>()
        {
            SelectionType = SelectionType.Single,
            SelectionAction = SelectionAction.Replace
        }; 
        private bool _showHours;
        public bool ShowHours
        {
            get
            {
                return _showHours;
            }
            protected set
            {
                if (_showHours != value)
                {
                    _showHours = value;

                    OnPropertyChanged(nameof(ShowHours));
                }
            }
        }
        private string _notifyUserNoHoursLeft;
        public string NotifyUserNoHoursLeft
        {
            get
            {
                return _notifyUserNoHoursLeft;
            }
            protected set
            {
                if (_notifyUserNoHoursLeft != value)
                {
                    _notifyUserNoHoursLeft = value;

                    OnPropertyChanged(nameof(NotifyUserNoHoursLeft));
                }
            }
        }
        #region Commands
        public ICommand NavigateCalendarCommand { get; set; }
        public ICommand ChangeDateSelectionCommand { get; set; }
        #endregion

        #region Constructors
        public AgendaViewModel()
        {
            NavigateCalendarCommand = new Command<int>(NavigateCalendar);
            ChangeDateSelectionCommand = new Command<DateTime>(ChangeDateSelection);
            ShowHours = false;
        }
        #endregion

        #region Methods
     
      
        public void NavigateCalendar(int Amount)
        {
            Calendar?.NavigateCalendar(Amount);
        } 
        public void ChangeDateSelection(DateTime DateTime)
        {
            Calendar?.ChangeDateSelection(DateTime);
            // Logica zijn er uren beschikbaar in database. 
            if(DateTime.Day == 10)
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
        #endregion
    }
}
