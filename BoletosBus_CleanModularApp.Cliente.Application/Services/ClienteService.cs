using BoletosBus_CleanModularApp.Cliente.Application.Base;
using BoletosBus_CleanModularApp.Cliente.Application.Dtos;
using BoletosBus_CleanModularApp.Cliente.Application.Interfaces;
using BoletosBus_CleanModularApp.Cliente.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace BoletosBus_CleanModularApp.Cliente.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository? _clienteRepository;
        private readonly ILogger<ClienteService>? _logger;

        public ClienteService(IClienteRepository clienteRepository , ILogger<ClienteService> logger)
        {
            this._clienteRepository = clienteRepository;
            this._logger = logger;
        }
        public ServiceResult DeleteCliente(ClienteDeleteDto clienteDeleteDto)
        {
            var result = new ServiceResult();
            try 
            {
                var clienteEliminar = _clienteRepository?.GetEntityById(clienteDeleteDto.IdCliente);
                _clienteRepository?.Remove(clienteEliminar);
                result.Success = true;
                result.Message = "Cliente deleted";
                return result;
            }catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in DeleteCliente");
                result.Success = false;
                result.Message = "Error in DeleteCliente";
                return result;
            }
        }

        public ServiceResult GetClienteById(int id)
        {
            var result = new ServiceResult();
            try
            {
                var cliente = _clienteRepository?.GetEntityById(id);
                if (cliente == null)
                {
                    result.Success = false;
                    result.Message = "Cliente not found";
                }
                result.Data = cliente;
                result.Success = true;
                return result;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in GetClienteById");
                result.Success = false;
                result.Message = "Error in GetClienteById";
                return result;
            }
        }

        public ServiceResult GetClientes()
        {
            var result = new ServiceResult();
            try
            {
                var clientes = _clienteRepository?.GetAll();
                if (clientes == null)
                {
                    result.Success = false;
                    result.Message = "Clientes not found";
                }
                result.Data = clientes;
                result.Success = true;
                return result;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in GetClientes");
                result.Success = false;
                result.Message = "Error in GetClientes";
                return result;
            }
        }

        public ServiceResult SaveCliente(ClienteSaveDto clienteSaveDto)
        {
            var result = new ServiceResult();
            try
            {
                var cliente = new Domain.Entities.Cliente
                {
                    Nombre = clienteSaveDto.Nombre,
                    Telefono = clienteSaveDto.Telefono,
                    Email = clienteSaveDto.Email,

                };
                _clienteRepository?.Save(cliente);
                result.Success = true;
                result.Message = "Cliente saved";
                return result;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in SaveCliente");
                result.Success = false;
                result.Message = "Error in SaveCliente";
                return result;
            }
        }

        public ServiceResult UpdateCliente(ClienteUpdateDto clienteUpdateDto)
        {
            var result = new ServiceResult();
            try 
            {
                var cliente = new Domain.Entities.Cliente
                {
                    Nombre = clienteUpdateDto.Nombre,
                    Telefono = clienteUpdateDto.Telefono,
                    Email = clienteUpdateDto.Email,
                };

                _clienteRepository?.Update(cliente);
                result.Success = true;
                result.Message = "Cliente updated";
                return result;
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex, "Error in UpdateCliente");
                result.Success = false;
                result.Message = "Error in UpdateCliente";
                return result;
            }
        }
    }
}
