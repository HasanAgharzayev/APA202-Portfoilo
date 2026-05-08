using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Services;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("default"));
            });

            //builder.Services.AddSingleton<EmailService>();

            //builder.Services.AddSingleton<IEmailService, TestService>();

            //builder.Services.AddTransient<EmailService>();


            var app = builder.Build();

            app.UseStaticFiles();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
