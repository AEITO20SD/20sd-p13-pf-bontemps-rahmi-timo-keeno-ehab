using BarberTime.Viewmodels;
using BarberTime.Views;
using CommunityToolkit.Maui;

namespace BarberTime;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.UseMauiCommunityToolkit();

        string dbPath = FileAccessHelper.GetLocalFilePath("BarberTime.db3");
        builder.Services.AddSingleton<CreateAccountViewModels>(s => ActivatorUtilities.CreateInstance<CreateAccountViewModels>(s, dbPath));


	//Door Transient te gebruiken wordt er telkens een nieuwe pagina aangemaakt
		builder.Services.AddTransient<HaircutDetailPage>();
        builder.Services.AddTransient<HaircutDetailViewModel>();


        return builder.Build();
	}
}

