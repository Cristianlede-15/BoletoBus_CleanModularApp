using BoletosBus_CleanModularApp.Cliente.Application.Interfaces;
using BoletosBus_CleanModularApp.Cliente.Application.Services;
using BoletosBus_CleanModularApp.Cliente.Domain.Interfaces;
using BoletosBus_CleanModularApp.Cliente.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosBus_CleanModularApp.Cliente.IOC.Dependencies
{
    public static class ClienteDependency
    {
        public static void AddClienteDependency(this IServiceCollection service)
        {
            #region"Cliente Repositories"
            service.AddScoped<IClienteRepository, ClienteRepository>();
            #endregion

            #region"Cliente Services"
            service.AddTransient<IClienteService, ClienteService>();
            #endregion
        }
    }
}
