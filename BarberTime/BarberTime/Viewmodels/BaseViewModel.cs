using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BarberTime.Viewmodels
{
    public class BaseViewModel
    {
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;
            storage = value;
            
            return true;
        }
    }
}