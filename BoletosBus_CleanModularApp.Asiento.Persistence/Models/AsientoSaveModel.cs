namespace BoletosBus_CleanModularApp.Asiento.Persistence.Models
{
    public class AsientoSaveModel : AsientoBaseModel
    {
        public int NumeroPiso { get; set; }
        public int NumeroAsiento { get; set; }
        public bool? Disponible { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
