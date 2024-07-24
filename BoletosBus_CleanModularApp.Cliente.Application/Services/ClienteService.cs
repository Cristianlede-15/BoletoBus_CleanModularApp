using BoletosBus_CleanModularApp.Cliente.Application.Base;
using BoletosBus_CleanModularApp.Cliente.Application.Dtos;
using BoletosBus_CleanModularApp.Cliente.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosBus_CleanModularApp.Cliente.Application.Services
{
    public class ClienteService : IClienteService
    {
        public ServiceResult DeleteCliente(ClienteDeleteDto clienteDeleteDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetClienteById(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetClientes()
        {
            throw new NotImplementedException();
        }

        public ServiceResult SaveCliente(ClienteSaveDto clienteSaveDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult UpdateCliente(ClienteUpdateDto clienteUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
