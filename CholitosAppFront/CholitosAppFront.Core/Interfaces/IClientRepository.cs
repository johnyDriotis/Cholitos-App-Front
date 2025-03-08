using CholitosAppFront.Core.Domain;
using CholitosAppFront.Core.DTOs;

namespace CholitosAppFront.Core.Interfaces
{
    public interface IClientRepository
    {
        Task<List<ClientDto>> GetAllClients();
    }
}
