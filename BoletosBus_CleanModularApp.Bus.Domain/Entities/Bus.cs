using BoletosBus_CleanModularApp.Common.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosBus_CleanModularApp.Bus.Domain.Entities
{
    public class Bus : BaseEntity<int>
    {
        [Column("IdBus")]
        public override int Id { get; set; }
        public string? NumeroPlaca { get; set; }
        public string? Nombre { get; set; }
        public int? CapacidadPiso1 { get; set; }
        public int? CapacidadPiso2 { get; set; }

        [NotMapped]
        public int CapacidadTotal => (CapacidadPiso1 ?? 0) + (CapacidadPiso2 ?? 0);

        public bool? Disponible { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
