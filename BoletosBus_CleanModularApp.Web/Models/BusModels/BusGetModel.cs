namespace BoletosBus_CleanModularApp.Web.Models.BusModels
{
    public class BusGetModel : BusBaseModel
    {
        public int IdBus { get; set; }
        public int CapacidadTotal { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }

}
