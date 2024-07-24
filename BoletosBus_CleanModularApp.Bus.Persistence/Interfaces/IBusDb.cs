using BoletosBus_CleanModularApp.Bus.Application.Dtos;

namespace BoletosBus_CleanModularApp.Bus.Persistence.Interfaces
{
    public interface IBusDb
    {
        void SaveBus(BusSaveDto busSaveDto);
        void UpdateBus(BusUpdateDto busUpdateDto);
        void DeleteBus(BusDeleteDto busDeleteDto);
        void GetBusById(int idBus);
        List<BusAccessDto> GetAllAsientoAcces(BusAccessDto busAccessDto);

    }
}
