using CholitosAppFront.Core.Dtos;
using CholitosAppFront.Core.DTOs;
using CholitosAppFront.Core.Request;
using CholitosAppFront.Core.Response;
using CholitosAppFront.Core.Services.Interfaces;
using CholitosAppFront.Core.UseCases.Interfaces;
using Newtonsoft.Json;

namespace CholitosAppFront.Core.UseCases
{
    public class ClientUseCase : IClientUseCase
    {
        private readonly IGimnasioService _gimnasioService;

        public ClientUseCase(IGimnasioService gimnasioService) { 
            _gimnasioService = gimnasioService ?? throw new ArgumentNullException(nameof(gimnasioService));
        }

        public async Task<GenericResponseFingerPrint<FingerPrintDto>> GetFingerPrintImages() {
            GenericResponseFingerPrint<FingerPrintDto> genericResponseFingerPrint = new();
            string controller = "FingerPrint";
            string action = "FingerPrintCaptureThreeTimes";

            string response = await _gimnasioService.ConsumePostMethod(controller, action);
            genericResponseFingerPrint = JsonConvert.DeserializeObject<GenericResponseFingerPrint<FingerPrintDto>>(response);

            return genericResponseFingerPrint;
        }

        public async Task<GenericResponse<ClientDto>> AddClient(ClientRequest clientRequest)
        {
            GenericResponse<ClientDto> genericResponse = new();
            string controller = "Client";
            string action = "Create";

            string response = await _gimnasioService.ConsumePostMethod(controller, action, clientRequest);
            genericResponse = JsonConvert.DeserializeObject<GenericResponse<ClientDto>>(response);

            return genericResponse;
        }
    }
}
