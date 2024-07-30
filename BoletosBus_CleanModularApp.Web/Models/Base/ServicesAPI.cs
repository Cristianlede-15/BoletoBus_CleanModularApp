using Newtonsoft.Json;
using System.Text;

namespace BoletosBus_CleanModularApp.Web.Models.Base
{
    public class ServicesAPI
    {
        private readonly HttpClient _httpClient;

        public ServicesAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse<T>> GetAsync<T>(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResponse<T>>(jsonResponse);
            }
            else
            {
                return new ApiResponse<T>
                {
                    Success = false,
                    Message = $"Error al obtener datos de la API: {response.ReasonPhrase}"
                };
            }
        }


        public async Task<ApiResponse<T>> PostAsync<T>(string url, T data)
        {
            var jsonContent = JsonConvert.SerializeObject(data);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(url, contentString);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResponse<T>>(jsonResponse);
            }
            else
            {
                return new ApiResponse<T>
                {
                    Success = false,
                    Message = $"Error al enviar datos a la API: {response.ReasonPhrase}"
                };
            }
        }


        public async Task<ApiResponse<T>> DeleteAsync<T>(string url)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResponse<T>>(jsonResponse);
            }
            else
            {
                return new ApiResponse<T>
                {
                    Success = false,
                    Message = $"Error al eliminar datos de la API: {response.ReasonPhrase}"
                };
            }
        }
    }
}
