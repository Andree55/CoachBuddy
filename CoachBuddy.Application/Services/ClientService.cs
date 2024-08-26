using CoachBuddy.Domain.Interfaces;

namespace CoachBuddy.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task Create(Domain.Entities.Client client)
        {
            client.EncodeName();

            await _clientRepository.Create(client);
        }
    }
}
