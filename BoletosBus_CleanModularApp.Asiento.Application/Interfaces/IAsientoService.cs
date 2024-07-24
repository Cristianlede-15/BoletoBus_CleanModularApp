using BoletosBus_CleanModularApp.Asiento.Application.Base;
using BoletosBus_CleanModularApp.Asiento.Application.Dtos;

namespace BoletosBus_CleanModularApp.Asiento.Application.Interfaces
{
    public interface IAsientoService
    {
        ServiceResult GetAsientos();
        ServiceResult GetAsientoById(int id);
        ServiceResult SaveAsiento(AsientoSaveDto asientoSaveDto);
        ServiceResult UpdateAsiento(AsientoUpdateDto asientoUpdateDto);
        ServiceResult DeleteAsiento(AsientoDeleteDto asientoDeleteDto);
    }
}
