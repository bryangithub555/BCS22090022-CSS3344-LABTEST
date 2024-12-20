using BCS22090022.Services;
using BCS22090022.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace BCS22090022
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<Question3ViewModel>();
            builder.Services.AddSingleton<Question3>();
            builder.Services.AddSingleton<ApiService>();

            return builder.Build();
        }
    }
}
