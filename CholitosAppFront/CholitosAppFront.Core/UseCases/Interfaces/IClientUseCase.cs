
using CholitosAppFront.Core.Dtos;
using CholitosAppFront.Core.DTOs;
using CholitosAppFront.Core.Request;
using CholitosAppFront.Core.Response;

namespace CholitosAppFront.Core.UseCases.Interfaces
{
    public interface IClientUseCase
    {
        Task<GenericResponseFingerPrint<FingerPrintDto>> GetFingerPrintImages();
        Task<GenericResponse<ClientDto>> AddClient(ClientRequest clientRequest);
    }
}
