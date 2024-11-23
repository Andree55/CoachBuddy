using AutoMapper;
using CoachBuddy.Application.ApplicationUser;
using CoachBuddy.Application.Group;

namespace CoachBuddy.Application.Mappings
{
    public class GroupMappingProfile:Profile
    {
        public GroupMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();

            CreateMap<GroupDto, Domain.Entities.Group.Group>()
                .ForMember(g => g.EncodedName, opt => opt.MapFrom(src => src.Name.ToLower().Replace(" ", "-")));

            CreateMap<Domain.Entities.Group.Group, GroupDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null
                                                    && (src.CreatedById == user.Id || user.IsInRole("Moderator"))));
        }
    }
}
