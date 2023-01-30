
using APPFinanceiro;
using LiteDB;
using TAsk.Repositories;
using TAsk.Repositories.interfaces;
using TAsk.Viwes;

namespace TAsk;

public static class MauiProgram
{
	public static object CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("inter.ttf", "inter");
				fonts.AddFont("RobotoMono-Bold.ttf", "Roboto");
			})
			;
           

		return builder.Build();
	}
 //   public static MauiAppBuilder RegisterDataBase(this MauiAppBuilder mauiAppBuilder)
	//{
 //       mauiAppBuilder.Services.AddSingleton<LiteDatabase>(
	//	options =>
	//	{
 //               return new LiteDatabase($"Filename={AppSettings.DatabasePatch};Connection=Shared");
 //           });

 //       mauiAppBuilder.Services.AddTransient<IUserRepository, UserRepository>();

 //       return mauiAppBuilder;
 //   }
  
}
