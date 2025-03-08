using CholitosAppFront.Core.DTOs;
using CholitosAppFront.Core.Interfaces;
using CholitosAppFront.Core.UseCases.Interfaces;

namespace CholitosAppFront.Core.UseCases
{
    public class ClientUseCase : IClientUseCase
    {
        private readonly IClientRepository _clientRepository;
        public ClientUseCase(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        }

        public async Task<List<ClientDto>> GetAllClients()
        {
            var clients = await _clientRepository.GetAllClients();
            return clients;
        }
    }
}
