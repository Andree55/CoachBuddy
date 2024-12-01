using CoachBuddy.Application.ClientGroup;
using CoachBuddy.Domain.Interfaces.Client;
using CoachBuddy.Domain.Interfaces.Group;
using MediatR;

namespace CoachBuddy.Application.Group.Commands.AddClientToGroup
{
    public class AddClientToGroupCommandHandler : IRequestHandler<AddClientToGroupCommand>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IClientRepository _clientRepository;

        public AddClientToGroupCommandHandler(IGroupRepository groupRepository,IClientRepository clientRepository)
        {
            _groupRepository = groupRepository;
            _clientRepository = clientRepository;
        }
        public async Task<Unit> Handle(AddClientToGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await _groupRepository.GetGroupWithClientsAsync(request.GroupId);

            if (group == null)
            {
                throw new ArgumentException("Group not found.");
            }

            var client = await _clientRepository.GetByIdAsync(request.ClientId);

            if (client == null)
            {
                throw new ArgumentException("Client not found.");
            }

            if (group.ClientGroups.Any(cg => cg.ClientId == request.ClientId))
            {
                throw new InvalidOperationException("Client is already in the group.");
            }

            var clientGroup = new Domain.Entities.Group.ClientGroup
            {
                GroupId = request.GroupId,
                ClientId = request.ClientId,
                AssignedAt = DateTime.UtcNow
            };

            group.ClientGroups.Add(clientGroup);

            await _groupRepository.SaveAsync();

            return Unit.Value;
        }
    }
}
