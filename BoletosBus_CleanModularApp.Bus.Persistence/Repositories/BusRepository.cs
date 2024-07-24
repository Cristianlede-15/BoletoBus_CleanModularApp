using BoletosBus_CleanModularApp.Bus.Domain.Interfaces;
using BoletosBus_CleanModularApp.Bus.Persistence.Context;
using Microsoft.Extensions.Logging;

namespace BoletosBus_CleanModularApp.Bus.Persistence.Repositories
{
    public class BusRepository : IBusRepository
    {
        private readonly BusContext? _context;
        private readonly ILogger<BusRepository>? _logger;

        public BusRepository(BusContext context, ILogger<BusRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public List<Domain.Entities.Bus> GetAll()
        {
            return _context.Bus.ToList();
        }

        public Domain.Entities.Bus GetEntityById(int id)
        {
            try
            {
                var bus = _context.Bus.Find(id);

                if (bus is null)
                {
                    _logger.LogError($"Bus with id {id} not found");
                }
                return bus;
            }
            catch
            {
                this._logger.LogError($"Bus with id {id} not found");
                throw;
            }
        }

        public void Remove(Domain.Entities.Bus entity)
        {
            try 
            {
                if (entity is null)
                {
                    _logger.LogError("Entity is null");
                }

                var busEliminar = _context.Bus.Find(entity.Id);

                if (busEliminar is null)
                {
                    _logger.LogError($"Bus with id {entity.Id} not found");
                }

                _context.Bus.Remove(busEliminar);
                _context.SaveChanges();
            }catch(Exception ex)
            {
                this._logger.LogError($"Bus with id {entity.Id} not found", ex.ToString());
            }
        }

        public void Save(Domain.Entities.Bus entity)
        {
            try 
            {
                if (entity is null)
                {
                    _logger.LogError("Entity is null");
                }

                _context.Bus.Add(entity);
                _context.SaveChanges();
            }catch(Exception ex)
            {
                this._logger.LogError($"Bus with id {entity.Id} not found", ex.ToString());
            }
        }

        public void Update(Domain.Entities.Bus entity)
        {
            try 
            {
                if (entity is null)
                {
                    _logger.LogError("Entity is null");
                }

                var busActualizar = _context.Bus.Find(entity.Id);

                if (busActualizar is null)
                {
                    _logger.LogError($"Bus with id {entity.Id} not found");
                }

                busActualizar.Id = entity.Id;
                busActualizar.NumeroPlaca  = entity.NumeroPlaca;
                busActualizar.Nombre = entity.Nombre;
                busActualizar.CapacidadPiso1 = entity.CapacidadPiso1;
                busActualizar.CapacidadPiso2 = entity.CapacidadPiso2;
                busActualizar.Disponible = entity.Disponible;
                busActualizar.FechaCreacion = entity.FechaCreacion;


                _context.Entry(busActualizar).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }catch(Exception ex)
            {
                this._logger.LogError($"Bus with id {entity.Id} not found", ex.ToString());
            }
        }
    }
}
