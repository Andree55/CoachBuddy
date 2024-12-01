using CoachBuddy.Application.ClientGroup;
using CoachBuddy.Domain.Interfaces.Client;
using CoachBuddy.Domain.Interfaces.Group;
using MediatR;

namespace CoachBuddy.Application.Group.Queries.GetGroupDetails
{
    public class GetGroupDetailsQueryHandler : IRequestHandler<GetGroupDetailsQuery, GroupDto>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IClientRepository _clientRepository; 
        public GetGroupDetailsQueryHandler(IGroupRepository groupRepository, IClientRepository clientRepository)
        {
            _groupRepository = groupRepository;
            _clientRepository = clientRepository;
        }

        public async Task<GroupDto> Handle(GetGroupDetailsQuery request, CancellationToken cancellationToken)
        {
            var group = await _groupRepository.GetGroupWithClientsAsync(request.GroupId);

            if (group == null)
            {
                throw new ArgumentException("Group not found.");
            }

            var allClients = await _clientRepository.GetAllClientsAsync();
            var clientIdsInGroup = group.ClientGroups.Select(cg => cg.ClientId).ToHashSet();

            var availableClients = allClients
                .Where(c => !clientIdsInGroup.Contains(c.Id))
                .Select(c => new AvailableClientDto
                {
                    Id = c.Id,
                    Name = $"{c.Name} {c.LastName}"
                })
                .ToList();

            return new GroupDto
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
                CreatedAt = group.CreatedAt,
                EncodedName = group.EncodedName,
                ClientGroups = group.ClientGroups.Select(cg => new ClientGroupDto
                {
                    ClientId = cg.ClientId,
                    FullName = $"{cg.Client.Name} {cg.Client.LastName}",
                    AssignedAt = cg.AssignedAt
                }).ToList(),
                AvailableClients = availableClients  
            };
        }

    }
}