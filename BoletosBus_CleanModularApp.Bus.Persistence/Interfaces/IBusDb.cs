using BoletosBus_CleanModularApp.Bus.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
