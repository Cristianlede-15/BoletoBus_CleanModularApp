namespace BoletosBus_CleanModularApp.Asiento.Application.Dtos
{
    public class AsientoUpdateDto : AsientoBaseDto
    {
        public int? NumeroPiso { get; set; }
        public int? NumeroAsiento { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
