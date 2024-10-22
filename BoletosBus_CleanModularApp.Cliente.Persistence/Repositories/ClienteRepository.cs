﻿using BoletosBus_CleanModularApp.Cliente.Domain.Interfaces;
using BoletosBus_CleanModularApp.Cliente.Persistence.Context;
using Microsoft.Extensions.Logging;


namespace BoletosBus_CleanModularApp.Cliente.Persistence.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteContext? _context;
        private readonly ILogger<ClienteRepository>? _logger;

        public ClienteRepository(ClienteContext context, ILogger<ClienteRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public List<Domain.Entities.Cliente> GetAll()
        {
            return _context?.Cliente.ToList();
        }

        public Domain.Entities.Cliente GetEntityById(int id)
        {
            try 
            {
                var cliente = _context?.Cliente.Find(id);

                if (cliente == null)
                {
                    this._logger?.LogError("Error, cliente not found");
                }
                return cliente;

            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in GetEntityById");
                return null;
            }
        }

        public void Remove(Domain.Entities.Cliente entity)
        {
            try
            {
                if (entity is null) 
                {
                    this._logger?.LogError("The entity cannot be null");
                }
                var clienteEliminar = this._context.Cliente.Find(entity.Id);

                if(clienteEliminar is null) 
                {
                            this._logger?.LogError("Error, the entity is null");
                }

                _context.Cliente.Remove(entity);
                _context.SaveChanges();
            }
            catch(Exception ex) 
            {
                this._logger?.LogError("Error eliminando al cliente, " + ex.ToString());
            }
        }

        public void Save(Domain.Entities.Cliente entity)
        {
            try 
            {
                if (entity is null) 
                {
                    this._logger?.LogError("Error, the entity cannot be null");
                }
                _context?.Cliente.Add(entity);
                _context?.SaveChanges();
            } catch
            {
                this._logger?.LogError("Error guardando el cliente");
                throw;
            }
        }

        public void Update(Domain.Entities.Cliente entity)
        {
            try 
            {
                if (entity is null) 
                {
                    this._logger?.LogError("The entity cannot be null");
                }

                var clienteActualizar = this._context.Cliente.Find(entity.Id);

                if(clienteActualizar is null) 
                {
                    this._logger?.LogError("Error, the entity is null");
                }

                clienteActualizar.Id = entity.Id;
                clienteActualizar.Email = entity?.Email;
                clienteActualizar.Nombre = entity?.Nombre;
                clienteActualizar.Telefono = entity?.Telefono;

                _context.Entry(clienteActualizar).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();

            } catch 
            {
                this._logger?.LogError("Error actualizando al cliente");
                throw;
            }
        }
    }
}
