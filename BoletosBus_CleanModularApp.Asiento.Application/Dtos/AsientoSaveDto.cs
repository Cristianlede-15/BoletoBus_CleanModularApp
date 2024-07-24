using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosBus_CleanModularApp.Asiento.Application.Dtos
{
    public class AsientoSaveDto : AsientoBaseDto
    {
        public int NumeroPiso { get; set; }
        public int NumeroAsiento { get; set; }
        public bool? Disponible { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
