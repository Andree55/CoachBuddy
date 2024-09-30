using AutoMapper;
using CoachBuddy.Application.Common;
using CoachBuddy.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Application.Client.Queries.GetAllClients
{
    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, PaginatedResult<ClientDto>>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public GetAllClientsQueryHandler(IClientRepository clientRepository,IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public IMapper Mapper { get; }

        public async Task<PaginatedResult<ClientDto>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var clients = await _clientRepository.GetAll();

            var totalClients = clients.Count();

            var paginatedClients = clients
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var dtos = _mapper.Map<List<ClientDto>>(paginatedClients);

            return new PaginatedResult<ClientDto>
            {
                Items = dtos,
                TotalCount = totalClients,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };
        }
    }
}
