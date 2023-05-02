using System.Reflection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IntJob.DataAccess.DbAccess;

namespace IntJob.MAUI;

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
			});

		string appConfigStreamName = "IntJob.MAUI.appsettings.json";

		var assembly = Assembly.GetExecutingAssembly();
		Console.WriteLine(assembly.FullName);
        var stream = assembly.GetManifestResourceStream(appConfigStreamName);
		var config = new ConfigurationBuilder()
			.AddJsonStream(stream)
			.Build();

		builder.Configuration.AddConfiguration(config);

		var connectionStrings = builder.Configuration["ConnectionStrings"];

		builder.Services.AddSingleton<ISqliteDataAccess, SqliteDataAccess>();
		builder.Services.AddSingleton<IAgentData, AgentData>();
		
#if DEBUG
		builder.Logging.AddDebug();
#endif
		
		return builder.Build();
	}
}

