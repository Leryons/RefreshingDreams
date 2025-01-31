namespace RefreshingDreams
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
                    fonts.AddFont("Roboto-Regular.ttf", "Roboto");
                    fonts.AddFont("Belgiano_Serif.ttf", "Belgiano");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Services
            builder.Services.AddSingleton<Database>();
            builder.Services.AddSingleton<CocktailServices>();
            builder.Services.AddTransient<UserServices>();

            // ViewModels
            builder.Services.AddTransient<UserViewModel>();
            builder.Services.AddSingleton<CocktailViewModel>();

            // Pages
            builder.Services.AddSingleton<MenuPage>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<SignUpPage>();
            builder.Services.AddTransient<BillPage>();

            return builder.Build();
        }
    }
}