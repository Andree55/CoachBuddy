using AutoMapper;
using CoachBuddy.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Application.Client.Queries.GetClientsBySearch
{
    public class GetClientsBySearchQueryHandler : IRequestHandler<GetClientsBySearchQuery, List<ClientDto>>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public GetClientsBySearchQueryHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }
        public async Task<List<ClientDto>> Handle(GetClientsBySearchQuery request, CancellationToken cancellationToken)
        {
            var clients = await _clientRepository.GetAll();

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                clients = clients.Where(c=>
                c.Name.Contains(request.SearchTerm) ||
                c.LastName.Contains(request.SearchTerm))
                    .ToList();
                
            }
            return _mapper.Map<List<ClientDto>>(clients);
        }
    }
}
