namespace BoletosBus_CleanModularApp.Web.Models.AsientoModels
{
    public class AsientoDeleteModel : AsientoBaseModel
    {
        public int IdAsiento { get; set; }
        public DateTime FechaEliminacion { get; set; }
    }
}
