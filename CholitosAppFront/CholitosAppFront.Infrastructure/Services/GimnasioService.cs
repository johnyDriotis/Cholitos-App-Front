using CholitosAppFront.Core.Services.Interfaces;
using CholitosAppFront.Infrastructure.ClientFactory;
using CholitosAppFront.Infrastructure.Enums;
using System.Text;
using System.Text.Json;

namespace CholitosAppFront.Infrastructure.Services
{
    public class GimnasioService : IGimnasioService
    {
        private readonly IClientFactory _clientFactory;
        private readonly HttpClient _client;

        public GimnasioService(IClientFactory clientFactory)
        {
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
            _client = _clientFactory.GetExternalServices(EServices.GimnasioService);
        }

        public async Task<string> ConsumePostMethod(string controller, string action, object request) {

            string url = $"{_client.BaseAddress}api/{controller}/{action}";
            string data = JsonSerializer.Serialize(request);
            string contentType = "application/json" ;

            StringContent content = new StringContent(data, Encoding.UTF8, contentType);

            var response = await _client.PostAsync(url, content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) {
                return await response.Content.ReadAsStringAsync();
            }

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new Exception("No se encontro el endpoint solicitado. ");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("El servidor no se encuentra disponible. ");
            }
            else {
                throw new Exception("Ocurrio un error, codigo de respuesta: " + response.StatusCode + " - " + response.ReasonPhrase);
            }
        }
    }
}
