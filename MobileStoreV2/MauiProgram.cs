
using MudBlazor;

namespace MobileStoreV2
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


            var connectionString = $"Server={Environment.MachineName}\\{Environment.UserName};Database=MobileStore;Trusted_Connection=True;TrustServerCertificate=True;";
            // var connectionString = $"Server={Environment.MachineName};Database=MobileStore;Trusted_Connection=True;TrustServerCertificate=True;";

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddTransient<IProductService, ProductService>();
            builder.Services.AddTransient<ICategoryService, CategoryService>();
            builder.Services.AddTransient<IBrandService, BrandService>();
            builder.Services.AddTransient<IImageService, ImageService>();
            builder.Services.AddTransient<Createdatabase>();


            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif
            var app = builder.Build();
            DataSeeder.EnsurePopulated(app);
            return app;
        }
    }
}
