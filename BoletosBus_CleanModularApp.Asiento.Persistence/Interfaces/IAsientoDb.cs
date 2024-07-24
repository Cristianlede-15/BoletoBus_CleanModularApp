using BoletosBus_CleanModularApp.Asiento.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
