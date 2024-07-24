namespace BoletosBus_CleanModularApp.Infraestructure.Logger.Interfaces
{
    public interface ILoggerService
    {
        void LogInformation(string message);
        void LogError(string message);
    }
}
