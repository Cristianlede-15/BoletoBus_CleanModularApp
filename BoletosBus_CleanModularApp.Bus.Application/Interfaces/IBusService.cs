using BoletosBus_CleanModularApp.Bus.Application.Base;
using BoletosBus_CleanModularApp.Bus.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
