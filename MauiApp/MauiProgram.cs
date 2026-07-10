using Microsoft.Extensions.Logging;

namespace SPOneHRApp;

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

        builder.Services.AddSingleton<MainPage>();

#if IOS
        // Register custom iOS WebView handler (auto-grants GPS + camera + sets User-Agent)
        builder.ConfigureMauiHandlers(handlers =>
        {
            handlers.AddHandler<WebView, iOSWebViewHandler>();
        });
#endif

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
