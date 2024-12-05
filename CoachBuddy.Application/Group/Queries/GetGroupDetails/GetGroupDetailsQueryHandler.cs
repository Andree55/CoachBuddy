using AutoMapper;
using CoachBuddy.Application.ClientGroup;
using CoachBuddy.Domain.Interfaces.Client;
using CoachBuddy.Domain.Interfaces.Group;
using MediatR;

namespace CoachBuddy.Application.Group.Queries.GetGroupDetails
{
    public class GetGroupDetailsQueryHandler : IRequestHandler<GetGroupDetailsQuery, GroupDetailsDto>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public GetGroupDetailsQueryHandler(IGroupRepository groupRepository, IClientRepository clientRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<GroupDetailsDto> Handle(GetGroupDetailsQuery request, CancellationToken cancellationToken)
        {
            
            var group = await _groupRepository.GetByEncodedNameAsync(request.EncodedName);
            if (group == null)
            {
                throw new KeyNotFoundException($"Group with encoded name '{request.EncodedName}' not found.");
            }

            var availableClients = await _clientRepository.GetAvailableClientsForGroupAsync(group.Id);

            var groupDetailsDto = _mapper.Map<GroupDetailsDto>(group);
            groupDetailsDto.ClientGroups = group.ClientGroups.Select(cg => _mapper.Map<ClientGroupDto>(cg)).ToList();
            groupDetailsDto.AvailableClients = availableClients.Select(c => _mapper.Map<AvailableClientDto>(c)).ToList();

            return groupDetailsDto;
        }
    }
}
