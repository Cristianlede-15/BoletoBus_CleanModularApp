using BoletosBus_CleanModularApp.Asiento.Domain.Interfaces;
using BoletosBus_CleanModularApp.Asiento.Persistence.Context;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosBus_CleanModularApp.Asiento.Persistence.Repositories
{
    public class AsientoRepository : IAsientoRepository
    {
        private readonly AsientoContext? _asientoContext;
        private readonly ILogger<AsientoRepository>? _logger;

        public AsientoRepository(AsientoContext asientoContext, ILogger<AsientoRepository> logger)
        {
            this._asientoContext = asientoContext;
            this._logger = logger;
        }
        public List<Domain.Entities.Asiento> GetAll()
        {
            if (_asientoContext == null)
            {
                _logger?.LogError("AsientoContext is null");
                return new List<Domain.Entities.Asiento>();
            }

            return _asientoContext.Asiento.ToList();
        }

        public Domain.Entities.Asiento? GetEntityById(int id)
        {
            try
            {
                var asiento = _asientoContext?.Asiento.Find(id);
                if (asiento is null)
                {
                    _logger?.LogError($"Asiento with id: {id}, not found");
                    return null;
                }
                return asiento;
            }
            catch
            {
                this._logger?.LogError($"An error occurred while trying to get the asiento with id: {id}");
                throw;
            }
        }

        public void Remove(Domain.Entities.Asiento entity)
        {
            try
            {
                if (entity is null)
                {
                    _logger?.LogError("The entity can't be null");
                    return;
                }

                var asientoEliminar = this._asientoContext?.Asiento.Find(entity.Id);

                if (asientoEliminar is null)
                {
                    _logger?.LogError($"The asiento with id: {entity.Id}, not found");
                    return;
                }

                _asientoContext?.Asiento.Remove(asientoEliminar);
                _asientoContext?.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger?.LogError($"An error occurred while trying to remove the asiento with id: {entity.Id}, " + ex.ToString());
                throw;
            }
        }

        public void Save(Domain.Entities.Asiento entity)
        {
            try
            {
                if (entity is null)
                {
                    _logger?.LogError("The entity can't be null");
                    return;
                }

                _asientoContext?.Asiento.Add(entity);
                _asientoContext?.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger?.LogError($"An error occurred while trying to save the asiento with id: {entity.Id}, " + ex.ToString());
                throw;
            }
        }

        public void Update(Domain.Entities.Asiento entity)
        {
            try
            {
                if (entity is null)
                {
                    _logger?.LogError("The entity can't be null");
                    return;
                }

                var asientoActualizar = this._asientoContext?.Asiento.Find(entity.Id);

                if (asientoActualizar is null)
                {
                    _logger?.LogError($"The asiento with id: {entity.Id}, not found");
                    return;
                }


                asientoActualizar.Id = entity.Id;
                asientoActualizar.IdBus = entity.IdBus;
                asientoActualizar.NumeroAsiento = entity.NumeroAsiento;
                asientoActualizar.NumeroPiso = entity.NumeroPiso;
                asientoActualizar.FechaModificacion = entity.FechaModificacion;

                _asientoContext.Entry(asientoActualizar).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                _asientoContext?.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger?.LogError($"An error occurred while trying to update the asiento with id: {entity.Id}, " + ex.ToString());
                throw;
            }
        }
    }
}
