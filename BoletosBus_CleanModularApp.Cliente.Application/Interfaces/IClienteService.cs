using BoletosBus_CleanModularApp.Cliente.Application.Base;
using BoletosBus_CleanModularApp.Cliente.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosBus_CleanModularApp.Cliente.Application.Interfaces
{
    public interface IClienteService
    {
        ServiceResult GetClientes();
        ServiceResult GetClienteById(int id);
        ServiceResult SaveCliente(ClienteSaveDto clienteSaveDto);
        ServiceResult UpdateCliente(ClienteUpdateDto clienteUpdateDto);
        ServiceResult DeleteCliente(ClienteDeleteDto clienteDeleteDto);
    }
}
