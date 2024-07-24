namespace BoletosBus_CleanModularApp.Bus.Persistence.Exceptions
{
    public class BusExceptions : Exception
    {
        public BusExceptions(string message) : base(message)
        {
        }

        public BusExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
