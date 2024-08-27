using AutoMapper;
using CoachBuddy.Application.Client;
using CoachBuddy.Domain.Interfaces;

namespace CoachBuddy.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository,IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }
        public async Task Create(ClientDto clientDto)
        {
            var client=_mapper.Map<Domain.Entities.Client>(clientDto);

            client.EncodeName();

            await _clientRepository.Create(client);
        }

        public async Task<IEnumerable<ClientDto>> GetAll()
        {
            var clients = await _clientRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<ClientDto>>(clients);

            return dtos;
        }
    }
}
