using BoletosBus_CleanModularApp.Asiento.Application.Base;
using BoletosBus_CleanModularApp.Asiento.Application.Dtos;
using BoletosBus_CleanModularApp.Asiento.Application.Interfaces;
using BoletosBus_CleanModularApp.Asiento.Domain.Interfaces;
using Microsoft.Extensions.Logging;


namespace BoletosBus_CleanModularApp.Asiento.Application.Services
{
    public class AsientoService : IAsientoService
    {
        private readonly IAsientoRepository _asientoRepository;
        private readonly ILogger<AsientoService> _logger;

        public AsientoService(IAsientoRepository asientoRepository, ILogger<AsientoService> logger)
        {
            _asientoRepository = asientoRepository;
            _logger = logger;
        }
        public ServiceResult DeleteAsiento(AsientoDeleteDto asientoDeleteDto)
        {
            var result = new ServiceResult();
            try
            {
                var asientoEliminar = _asientoRepository.GetEntityById(asientoDeleteDto.IdBus);
                _asientoRepository.Remove(asientoEliminar);
                result.Success = true;
                result.Message = "Asiento deleted";
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in DeleteAsiento");
                result.Success = false;
                result.Message = "Error in DeleteAsiento";
                return result;
            }
        }

        public ServiceResult GetAsientoById(int id)
        {
            var result = new ServiceResult();
            try
            {
                var asiento = _asientoRepository.GetEntityById(id);
                if (asiento == null)
                {
                    result.Success = false;
                    result.Message = "Asiento not found";
                }
                result.Data = asiento;
                result.Success = true;
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAsientoById");
                result.Success = false;
                result.Message = "Error in GetAsientoById";
                return result;
            }
        }

        public ServiceResult GetAsientos()
        {
            var result = new ServiceResult();
            try
            {
                var asientos = _asientoRepository.GetAll();
                if (asientos is null)
                {
                    result.Success = false;
                    result.Message = "Asientos not found";
                }
                result.Data = asientos;
                result.Success = true;
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAsientos");
                result.Success = false;
                result.Message = "Error in GetAsientos";
                return result;
            }
        }

        public ServiceResult SaveAsiento(AsientoSaveDto asientoSaveDto)
        {
            var result = new ServiceResult();
            try 
            {
                var asiento = new Domain.Entities.Asiento
                {
                    Id = asientoSaveDto.IdBus,
                    IdBus = asientoSaveDto.IdBus,
                    NumeroPiso = asientoSaveDto.NumeroPiso,
                    NumeroAsiento = asientoSaveDto.NumeroAsiento,
                    FechaCreacion = asientoSaveDto.FechaCreacion,
                    Disponible = asientoSaveDto.Disponible,
                };
                _asientoRepository.Save(asiento);
                result.Success = true;
                result.Message = "Asiento saved";
                return result;
            }catch(Exception ex) 
            {
                _logger.LogError(ex, "Error in SaveAsiento");
                result.Success = false;
                result.Message = "Error in SaveAsiento";
                return result;
            }
        }

        public ServiceResult UpdateAsiento(AsientoUpdateDto asientoUpdateDto)
        {
            var result = new ServiceResult();
            try
            {
                var asiento = new Domain.Entities.Asiento
                {
                    Id = asientoUpdateDto.IdBus,
                    IdBus = asientoUpdateDto.IdBus,
                    NumeroPiso = asientoUpdateDto.NumeroPiso,
                    NumeroAsiento = asientoUpdateDto.NumeroAsiento,
                    FechaModificacion = asientoUpdateDto.FechaModificacion
                };
                _asientoRepository.Update(asiento);
                result.Success = true;
                result.Message = "Asiento updated";
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateAsiento");
                result.Success = false;
                result.Message = "Error in UpdateAsiento";
                return result;
            }
        }
    }
}
