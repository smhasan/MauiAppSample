using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

#if ANDROID
using Android.Views;
using Microsoft.Maui.Handlers;
#endif
namespace MauiAppSample
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
#if ANDROID
            EntryHandler.Mapper.AppendToMapping("NoKeyboard", (handler, view) =>
            {
                handler.PlatformView.ShowSoftInputOnFocus = false;
            });
#endif

            return builder.Build();
        }
    }
}
