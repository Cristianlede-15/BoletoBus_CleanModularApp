using BoletosBus_CleanModularApp.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoletosBus_CleanModularApp.Cliente.Domain.Entities
{
    public class Cliente : BaseEntity<int>
    {
        [Column("IdCliente")]
        public override int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
    }
}
