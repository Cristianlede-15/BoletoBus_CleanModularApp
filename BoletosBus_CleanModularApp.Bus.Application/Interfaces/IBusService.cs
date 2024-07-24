using BoletosBus_CleanModularApp.Bus.Application.Base;
using BoletosBus_CleanModularApp.Bus.Application.Dtos;

namespace BoletosBus_CleanModularApp.Bus.Application.Interfaces
{
    public interface IBusService
    {
        ServiceResult GetBuses();
        ServiceResult GetBusById(int id);
        ServiceResult SaveBus(BusSaveDto busSaveDto);
        ServiceResult UpdateBus(BusUpdateDto busUpdateDto);
        ServiceResult DeleteBus(BusDeleteDto busDeleteDto);
    }
}
