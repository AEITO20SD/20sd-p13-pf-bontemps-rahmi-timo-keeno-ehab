using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberTime.Viewmodels.Agenda
{
    public partial class AgendaTimeViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _time;

        [ObservableProperty]
        private bool _isAvailable;

        [ObservableProperty]
        private bool _isChecked;
    }
}
