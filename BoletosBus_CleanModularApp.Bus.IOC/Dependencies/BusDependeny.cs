using BoletosBus_CleanModularApp.Bus.Application.Interfaces;
using BoletosBus_CleanModularApp.Bus.Application.Services;
using BoletosBus_CleanModularApp.Bus.Domain.Interfaces;
using BoletosBus_CleanModularApp.Bus.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BoletosBus_CleanModularApp.Bus.IOC.Dependencies
{
    public static class BusDependeny
    {
        public static void AddBusDependency(this IServiceCollection service)
        {
            #region"Bus Repositories"
            service.AddScoped<IBusRepository, BusRepository>();
            #endregion

            #region"Bus Services"
            service.AddTransient<IBusService, BusService>();
            #endregion
        }
    }
}
