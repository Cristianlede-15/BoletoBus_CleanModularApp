namespace BoletosBus_CleanModularApp.Asiento.Persistence.Models
{
    public class AsientoAccessModel : AsientoBaseModel
    {
        public int? NumeroPiso { get; set; }
        public int NumeroAsiento { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
