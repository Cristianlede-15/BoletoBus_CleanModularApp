namespace BoletosBus_CleanModularApp.Bus.Application.Dtos
{
    public class BusSaveDto : BusBaseDto
    {
        public DateTime? FechaCreacion { get; set; }
        public object? Disponible { get; internal set; }
    }
}
