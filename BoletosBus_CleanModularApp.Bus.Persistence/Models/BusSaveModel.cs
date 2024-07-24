namespace BoletosBus_CleanModularApp.Bus.Persistence.Models
{
    public class BusSaveModel : BusBaseModel
    {
        public DateTime? FechaCreacion { get; set; }
        public object? Disponible { get; internal set; }
    }
}
