using BoletosBus_CleanModularApp.Infraestructure.Logger.Interfaces;


namespace BoletosBus_CleanModularApp.Infraestructure.Logger.Services
{
    public class LoggerService : ILoggerService
    {
        public void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {message}");
            Console.ResetColor();
        }

        public void LogInformation(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Info: {message}");
            Console.ResetColor();
        }
    }
}
