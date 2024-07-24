

namespace BoletosBus_CleanModularApp.Cliente.Persistence.Exceptions
{
    public class ClienteExceptions : Exception
    {
        public ClienteExceptions(string message) : base(message)
        {
        }

        public ClienteExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
