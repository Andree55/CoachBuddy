using AutoMapper;
using CoachBuddy.Application.ApplicationUser;
using CoachBuddy.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Application.Client.Commands.CreateClient
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateClientCommandHandler(IClientRepository clientRepository,IMapper mapper,IUserContext userContext)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public IUserContext UserContext { get; }

        public async Task<Unit> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = _mapper.Map<Domain.Entities.Client>(request);
            client.EncodeName();

            client.CreatedById = _userContext.GetCurrentUser().Id;

            await _clientRepository.Create(client);

            return Unit.Value;
        }
    }
}
