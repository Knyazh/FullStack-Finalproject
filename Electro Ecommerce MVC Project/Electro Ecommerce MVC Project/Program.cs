namespace Electro_Ecommerce_MVC_Project;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews()
            .AddRazorRuntimeCompilation();

        var app = builder.Build();

        app.UseStaticFiles();
        app.MapControllerRoute("default", "{controller=Home}/{action=Index}");
        app.Run();
    }
}