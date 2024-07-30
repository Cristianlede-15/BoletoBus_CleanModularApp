namespace BoletosBus_CleanModularApp.Web.Models.URL_s
{
    public class ConfigurationURL_s
    {
        public string? AsientoBaseUrl { get; set; }
        public string? BusBaseUrl { get; set; }
        public string? ClienteBaseUrl { get; set; }

        // Asiento URLs
        public string GetAsientos => $"{AsientoBaseUrl}/api/Asiento/GetAsientos";
        public string GetAsientoById(int id) => $"{AsientoBaseUrl}/api/Asiento/GetAsientoById?id={id}";
        public string SaveAsiento => $"{AsientoBaseUrl}/api/Asiento/SaveAsiento";
        public string UpdateAsiento(int id) => $"{AsientoBaseUrl}/api/Asiento/UpdateAsiento?id={id}";
        public string DeleteAsiento(int id) => $"{AsientoBaseUrl}/api/Asiento/DeleteAsiento?id={id}";

        // Bus URLs
        public string GetBuses => $"{BusBaseUrl}/api/Bus/GetBuses";
        public string GetBusById(int id) => $"{BusBaseUrl}/api/Bus/GetBusById?id={id}";
        public string SaveBus => $"{BusBaseUrl}/api/Bus";
        public string UpdateBus(int id) => $"{BusBaseUrl}/api/Bus/UpdateBus?id={id}";
        public string DeleteBus(int id) => $"{BusBaseUrl}/api/Bus/DeleteBus?id={id}";

        // Cliente URLs
        public string GetClientes => $"{ClienteBaseUrl}/api/Cliente/GetClientes";
        public string GetClienteById(int id) => $"{ClienteBaseUrl}/api/Cliente/GetClienteById?id={id}";
        public string SaveCliente => $"{ClienteBaseUrl}/api/Cliente/CreateCliente";
        public string UpdateCliente(int id) => $"{ClienteBaseUrl}/api/Cliente/UpdateCliente?id={id}";
        public string DeleteCliente(int id) => $"{ClienteBaseUrl}/api/Cliente/DeleteCliente?id={id}";
    }
}
