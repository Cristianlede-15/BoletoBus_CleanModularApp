using BoletosBus_CleanModularApp.Asiento.Application.Dtos;

namespace BoletosBus_CleanModularApp.Asiento.Persistence.Interfaces
{
    public interface IAsientoDb
    {
        void SaveAsiento(AsientoSaveDto asientoSaveDto);
        void UpdateAsiento(AsientoUpdateDto asientoUpdateDto);
        void DeleteAsiento(AsientoDeleteDto asientoDeleteDto);
        void GetAsientoById(int idAsiento);
        List<AsientoAccesDto> GetAllAsientoAcces(AsientoAccesDto asientoAccesDto);
    }
}
