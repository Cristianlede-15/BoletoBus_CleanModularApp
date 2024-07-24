namespace BoletosBus_CleanModularApp.Bus.Application.Dtos
{
    public class BusBaseDto
    {
        public int IdBus { get; set; }
        public string? NumeroPlaca { get; set; }
        public string? Nombre { get; set; }
        public int? CapacidadPiso1 { get; set; }
        public int? CapacidadPiso2 { get; set; }
        public int CapacidadTotal { get; set; }
    }
}
