using CholitosAppFront.Core.DTOs;

namespace CholitosAppFront.Core.UseCases.Interfaces
{
    public interface IClientUseCase
    {
        Task<List<ClientDto>> GetAllClients();
    }
}
