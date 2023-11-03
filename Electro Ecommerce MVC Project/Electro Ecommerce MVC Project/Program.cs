using Electro_Ecommerce_MVC_Project.Database;
using Electro_Ecommerce_MVC_Project.Services.Abstracts;
using Electro_Ecommerce_MVC_Project.Services.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Electro_Ecommerce_MVC_Project;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews()
            .AddRazorRuntimeCompilation();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


        builder.Services
          .AddDbContext<EcommerceDbContext>(o =>
          {
              o.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
          })
               .AddSingleton<IFileService, FileService>()
               .AddHttpContextAccessor()
               .AddHttpClient();



        var app = builder.Build();

        app.UseStaticFiles();
        app.MapControllerRoute("default", "{controller=Home}/{action=Index}");
        app.Run();
    }
}