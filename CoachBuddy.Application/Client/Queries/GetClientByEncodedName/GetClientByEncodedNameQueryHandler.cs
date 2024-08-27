using AutoMapper;
using CoachBuddy.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Application.Client.Queries.GetClientByEncodedName
{
    public class GetClientByEncodedNameQueryHandler : IRequestHandler<GetClientByEncodedNameQuery, ClientDto>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public GetClientByEncodedNameQueryHandler(IClientRepository clientRepository,IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }
        public async Task<ClientDto> Handle(GetClientByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByEncodedName(request.EncodedName);

            var dto=_mapper.Map<ClientDto>(client);

            return dto;
        }
    }
}
