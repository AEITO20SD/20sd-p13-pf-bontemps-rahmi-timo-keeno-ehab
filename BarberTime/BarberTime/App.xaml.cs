namespace BarberTime;

public partial class App : Application
{
    public static CreateAccountViewModels AccountRepo { get; private set; }

    public App(CreateAccountViewModels repo)
    {
        InitializeComponent();

        MainPage = new AppShell();

        AccountRepo = repo;

    }
}
