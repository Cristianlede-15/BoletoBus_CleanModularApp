using BoletosBus_CleanModularApp.Asiento.Application.Interfaces;
using BoletosBus_CleanModularApp.Asiento.Application.Services;
using BoletosBus_CleanModularApp.Asiento.Domain.Interfaces;
using BoletosBus_CleanModularApp.Asiento.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace BoletosBus_CleanModularApp.Asiento.IOC.Dependencies
{
    public static class AsientoDependency
    {
        public static void AddAsientoDependency(this IServiceCollection service)
        {
            #region"Asiento Repositories"
            service.AddScoped<IAsientoRepository, AsientoRepository>();
            #endregion

            #region"Asiento Services"
            service.AddTransient<IAsientoService, AsientoService>();
            #endregion
        }
    }
}
