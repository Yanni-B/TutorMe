using Microsoft.Extensions.Logging;

namespace TutorMe
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
                    fonts.AddFont("KGPrimaryPenmanship.ttf", "KG");
                });

            builder.Services.AddSingleton<Database>();
            builder.Services.AddTransient<MainPage>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}


/*
   SOURCE :
   https://learn.microsoft.com/fr-fr/training/modules/store-local-data/4-exercise-store-data-locally-with-sqlite
   https://youtu.be/VziMUc-VQko?si=FeJ1QJWf-yCqF44P
*/