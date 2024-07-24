namespace BoletosBus_CleanModularApp.Asiento.Persistence.Exceptions
{
    public class AsientoExceptions : Exception
    {
        public AsientoExceptions(string message) : base(message)
        {
        }

        public AsientoExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
