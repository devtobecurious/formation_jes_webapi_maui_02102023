using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SuiviDesWookiees.UI.Mobile.Services;
using System.Reflection;

namespace SuiviDesWookiees.UI.Mobile
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

            builder.Services.AddSingleton<IGetWookieesService, HttpGetWookieesService>();
            builder.Services.AddSingleton<AddWookiee>();
            builder.Services.AddSingleton<MainPage>();

            var getAssembly = Assembly.GetExecutingAssembly();
            using var stream = getAssembly.GetManifestResourceStream("SuiviDesWookiees.UI.Mobile.appsettings.json");
            var configBuilder = new ConfigurationBuilder().AddJsonStream(stream);

            builder.Configuration.AddConfiguration(configBuilder.Build());

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}