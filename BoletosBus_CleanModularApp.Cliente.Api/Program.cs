
using BoletosBus_CleanModularApp.Cliente.IOC.Dependencies;
using BoletosBus_CleanModularApp.Cliente.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BoletosBus_CleanModularApp.Cliente.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ClienteContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ClienteContext"));
            });


            // Add dependencies
            builder.Services.AddClienteDependency();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
