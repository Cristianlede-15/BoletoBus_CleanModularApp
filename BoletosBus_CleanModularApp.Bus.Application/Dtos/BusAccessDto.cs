namespace BoletosBus_CleanModularApp.Bus.Application.Dtos
{
    public class BusAccessDto : BusBaseDto
    {
        public bool Disponible { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
