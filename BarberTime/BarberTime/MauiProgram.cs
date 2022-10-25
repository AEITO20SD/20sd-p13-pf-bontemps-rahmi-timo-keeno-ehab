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

        return builder.Build();
	}
}
