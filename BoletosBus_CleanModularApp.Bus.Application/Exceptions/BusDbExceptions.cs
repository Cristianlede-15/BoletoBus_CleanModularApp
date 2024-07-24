namespace BoletosBus_CleanModularApp.Bus.Application.Exceptions
{
    public class BusDbExceptions : ArgumentNullException
    {
        public BusDbExceptions(string message) : base(message)
        {
        }
    }
}
