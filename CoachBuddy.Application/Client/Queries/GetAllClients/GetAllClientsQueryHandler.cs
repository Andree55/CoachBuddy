using AutoMapper;
using CoachBuddy.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Application.Client.Queries.GetAllClients
{
    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, IEnumerable<ClientDto>>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public GetAllClientsQueryHandler(IClientRepository clientRepository,IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public IMapper Mapper { get; }

        public async Task<IEnumerable<ClientDto>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var clients = await _clientRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<ClientDto>>(clients);

            return dtos;
        }
    }
}
