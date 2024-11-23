using AutoMapper;
using CoachBuddy.Application.Common;
using CoachBuddy.Application.Group;
using CoachBuddy.Domain.Interfaces.Group;
using MediatR;

namespace CoachBuddy.Application.Group.Queries.GetAllGroups
{
    public class GetAllGroupsQueryHandler : IRequestHandler<GetAllGroupsQuery, PaginatedResult<GroupDto>>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;
        public GetAllGroupsQueryHandler(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }
        public IMapper Mapper { get; }
        public async Task<PaginatedResult<GroupDto>> Handle(GetAllGroupsQuery request, CancellationToken cancellationToken)
        {
            var groups = await _groupRepository.GetAll();

            var totalGroups = groups.Count();

            var paginatedGroups = groups
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var dtos = _mapper.Map<List<GroupDto>>(paginatedGroups);

            return new PaginatedResult<GroupDto>
            {
                Items = dtos,
                TotalCount = totalGroups,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };
        }
    }
}
