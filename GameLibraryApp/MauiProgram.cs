using GameLibraryApp.Services;
using GameLibraryApp.Views;
using Microsoft.Extensions.Logging;

namespace GameLibraryApp
{
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
            builder.Services.AddSingleton<GameDatabaseService>();

            builder.Services.AddTransient<GamesPage>();
            builder.Services.AddTransient<AddGamePage>();
            builder.Services.AddTransient<GameDetailsPage>();
            builder.Services.AddTransient<WishlistPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
