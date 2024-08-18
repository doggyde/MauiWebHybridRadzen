using MauiWebHybridTest.Services;
using MauiWebHybridTest.Shared.Services;
using Microsoft.Extensions.Logging;
using Radzen;
//using Radzen;

namespace MauiWebHybridTest
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
                });

            // Add device-specific services used by the MauiWebHybridTest.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddRadzenComponents();

            builder.Services.AddSingleton<DialogService>();
            builder.Services.AddSingleton<NotificationService>();
            builder.Services.AddSingleton<TooltipService>();
            builder.Services.AddSingleton<ContextMenuService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
