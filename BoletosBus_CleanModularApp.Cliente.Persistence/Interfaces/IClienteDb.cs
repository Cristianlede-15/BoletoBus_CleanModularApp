using BoletosBus_CleanModularApp.Cliente.Application.Dtos;

namespace BoletosBus_CleanModularApp.Cliente.Persistence.Interfaces
{
    public interface IClienteDb
    {
        void SaveCliente(ClienteSaveDto clienteSaveDto);
        void UpdateCliente(ClienteUpdateDto clienteUpdateDto);
        void DeleteCliente(ClienteDeleteDto clienteDeleteDto);
        void GetClienteById(int idCliente);
        List<ClienteAccessDto> GetAllClienteAcces(ClienteAccessDto clienteAccesDto);
    }
}
