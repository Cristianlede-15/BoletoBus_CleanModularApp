using BoletosBus_CleanModularApp.Common.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosBus_CleanModularApp.Asiento.Domain.Entities
{
    public class Asiento : BaseEntity<int>
    {
        [Column("IdAsiento")]
        public override int Id { get; set; }

        public int IdBus { get; set; }

        public int? NumeroPiso { get; set; }

        public int? NumeroAsiento { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }
        public object? CapacidadTotal { get; set; }
        public object? Disponible { get; set; }
    }
}
