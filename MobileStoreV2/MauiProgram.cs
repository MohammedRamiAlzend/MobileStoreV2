using Microsoft.Extensions.Logging;
using MobileStoreV2.Data;
using MudBlazor.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MobileStoreV2.Services.Interfaces;
using MobileStoreV2.Services;

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


            //var connectionString = "Server=DESKTOP-SVMILGI\\DELL;Database=MobileStore;Trusted_Connection=True;TrustServerCertificate=True;";
            //Console.WriteLine(Environment.MachineName);

            var connectionString = $"Server={Environment.MachineName}\\{Environment.UserName};Database=MobileStore;Trusted_Connection=True;TrustServerCertificate=True;";
            
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddTransient<IProductService, ProductService>();

            builder.Services.AddTransient<ICategoryService, CategoryService>();


            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
