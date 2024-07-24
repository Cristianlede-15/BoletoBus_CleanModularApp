﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosBus_CleanModularApp.Asiento.Persistence.Models
{
    public class AsientoAccessModel : AsientoBaseModel
    {
        public int? NumeroPiso { get; set; }
        public int NumeroAsiento { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
