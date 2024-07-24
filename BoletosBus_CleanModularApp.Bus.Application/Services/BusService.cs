using BoletosBus_CleanModularApp.Bus.Application.Base;
using BoletosBus_CleanModularApp.Bus.Application.Dtos;
using BoletosBus_CleanModularApp.Bus.Application.Interfaces;
using BoletosBus_CleanModularApp.Bus.Domain.Interfaces;
using Microsoft.Extensions.Logging;


namespace BoletosBus_CleanModularApp.Bus.Application.Services
{
    public class BusService : IBusService
    {
        private readonly IBusRepository? _busRepository;
        private readonly ILogger<BusService>? _logger;

        public BusService(IBusRepository busRepository, ILogger<BusService> logger)
        {
            _busRepository = busRepository;
            _logger = logger;
        }
        public ServiceResult DeleteBus(BusDeleteDto busDeleteDto)
        {
            var result = new ServiceResult();
            try
            {
                var busEliminar = _busRepository.GetEntityById(busDeleteDto.IdBus);
                _busRepository?.Remove(busEliminar);
                result.Success = true;
                result.Message = "Bus deleted";
                return result;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in DeleteBus");
                result.Success = false;
                result.Message = "Error in DeleteBus";
                return result;
            }
        }

        public ServiceResult GetBusById(int id)
        {
            var result = new ServiceResult();
            try
            {
                var bus = _busRepository.GetEntityById(id);
                if (bus == null)
                {
                    result.Success = false;
                    result.Message = "Bus not found";
                }
                result.Data = bus;
                result.Success = true;
                return result;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in GetBusById");
                result.Success = false;
                result.Message = "Error in GetBusById";
                return result;
            }
        }

        public ServiceResult GetBuses()
        {
            var result = new ServiceResult();
            try
            {
                var buses = _busRepository.GetAll();
                if (buses is null)
                {
                    result.Success = false;
                    result.Message = "Buses not found";
                }
                result.Data = buses;
                result.Success = true;
                return result;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in GetBuses");
                result.Success = false;
                result.Message = "Error in GetBuses";
                return result;
            }
        }

        public ServiceResult SaveBus(BusSaveDto busSaveDto)
        {
            var result = new ServiceResult();

            try
            {
                var bus = new Bus.Domain.Entities.Bus
                {
                    CapacidadPiso1 = busSaveDto.CapacidadPiso1,
                    CapacidadPiso2 = busSaveDto.CapacidadPiso2,
                    FechaCreacion = busSaveDto.FechaCreacion,
                    Nombre = busSaveDto.Nombre,
                    NumeroPlaca = busSaveDto.NumeroPlaca,
                    Disponible = (bool?)busSaveDto.Disponible
                };

                _busRepository?.Save(bus);
                result.Success = true;
                result.Message = "Bus saved";
                return result;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in SaveBus");
                result.Success = false;
                result.Message = "Error in SaveBus";
                return result;
            }
        }

        public ServiceResult UpdateBus(BusUpdateDto busUpdateDto)
        {
            var result = new ServiceResult();
            try
            {
                var bus = _busRepository.GetEntityById(busUpdateDto.IdBus);
                if (bus == null)
                {
                    result.Success = false;
                    result.Message = "Bus not found";
                    return result;
                }

                bus.CapacidadPiso1 = busUpdateDto.CapacidadPiso1;
                bus.CapacidadPiso2 = busUpdateDto.CapacidadPiso2;
                bus.Nombre = busUpdateDto.Nombre;
                bus.NumeroPlaca = busUpdateDto.NumeroPlaca;
                bus.Disponible = (bool?)busUpdateDto.Disponible;

                _busRepository?.Update(bus);
                result.Success = true;
                result.Message = "Bus updated";
                return result;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in UpdateBus");
                result.Success = false;
                result.Message = "Error in UpdateBus";
                return result;
            }
        }
    }
}
