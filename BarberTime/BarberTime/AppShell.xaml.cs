using BarberTime.Views;

namespace BarberTime;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("Agendapage", typeof(Agendapage));
        Routing.RegisterRoute("Diensten", typeof(Diensten));
    }
}
