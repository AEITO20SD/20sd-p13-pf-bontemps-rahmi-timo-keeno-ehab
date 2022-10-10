namespace BarberTime;

public partial class App : Application
{
    public static AccountRepository AccountRepo { get; private set; }

    public App(AccountRepository repo)
	{
		InitializeComponent();

		MainPage = new AppShell();

        AccountRepo = repo;

    }
}
