using BoletosBus_CleanModularApp.Web.Models.Base;
using BoletosBus_CleanModularApp.Web.Models.URL_s;
using System.Configuration;

namespace BoletosBus_CleanModularApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient<ServicesAPI>();

            //Registrar URL's de las APIS
            builder.Services.Configure<ConfigurationURL_s>(builder.Configuration.GetSection("ApiUrls"));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
