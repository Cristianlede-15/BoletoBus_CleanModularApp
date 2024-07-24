namespace BoletosBus_CleanModularApp.Bus.Persistence.Models
{
    public class BusBaseModel
    {
        public int IdBus { get; set; }
        public string? NumeroPlaca { get; set; }
        public string? Nombre { get; set; }
        public int? CapacidadPiso1 { get; set; }
        public int? CapacidadPiso2 { get; set; }
    }
}
