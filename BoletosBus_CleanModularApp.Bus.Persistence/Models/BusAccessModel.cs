namespace BoletosBus_CleanModularApp.Bus.Persistence.Models
{
    public class BusAccessModel : BusBaseModel
    {
        public bool Disponible { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
