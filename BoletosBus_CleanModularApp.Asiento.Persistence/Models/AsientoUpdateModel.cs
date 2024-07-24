namespace BoletosBus_CleanModularApp.Asiento.Persistence.Models
{
    public class AsientoUpdateModel : AsientoBaseModel
    {
        public int? NumeroPiso { get; set; }
        public int? NumeroAsiento { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
