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
        public GetGroupDetailsQueryHandler(IGroupRepository groupRepository, IClientRepository clientRepository, IMapper _mapper)
        {
            _groupRepository = groupRepository;
            _clientRepository = clientRepository;
            this._mapper = _mapper;
        }


        public async Task<GroupDetailsDto> Handle(GetGroupDetailsQuery request, CancellationToken cancellationToken)
        {

            var group = await _groupRepository.GetGroupByEncodedNameAsync(request.EncodedName);

            if (group == null)
            {
                throw new KeyNotFoundException($"Group with encoded name '{request.EncodedName}' not found.");
            }

            var assignedClientGroups = await _clientGroupRepository.GetClientGroupsByGroupIdAsync(group.Id);

            var availableClients = await _clientRepository.GetAvailableClientsForGroupAsync(group.Id);

            var groupDetailsDto = new GroupDetailsDto
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
                CreatedAt = group.CreatedAt,
                EncodedName = group.EncodedName,
                CreatedById = group.CreatedById,
                IsEditable = group.IsEditable,
                ClientGroups = assignedClientGroups.Select(cg => new ClientGroupDto
                {
                    ClientId = cg.ClientId,
                    FullName = $"{cg.Client.Name} {cg.Client.LastName}",
                    AssignedAt = cg.AssignedAt
                }).ToList(),
                AvailableClients = availableClients.Select(c => new AvailableClientDto
                {
                    Id = c.Id,
                    FullName = $"{c.Name} {c.LastName}"
                }).ToList()
            };

            return groupDetailsDto;

        }

    }
}