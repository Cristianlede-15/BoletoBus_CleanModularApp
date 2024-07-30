namespace BoletosBus_CleanModularApp.Web.Models.AsientoModels
{
    public class AsientoGetModel : AsientoBaseModel
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
