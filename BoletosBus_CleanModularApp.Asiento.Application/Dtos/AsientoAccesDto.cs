using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosBus_CleanModularApp.Asiento.Application.Dtos
{
    public class AsientoAccesDto : AsientoBaseDto
    {
        public int? NumeroPiso { get; set; }
        public int NumeroAsiento { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public object? Disponible { get; internal set; }
    }
}
