using AutoMapper;
using CoachBuddy.Application.ApplicationUser;
using CoachBuddy.Application.Group;
using CoachBuddy.Application.Group.Commands.EditGroup;
using CoachBuddy.Application.Group.Commands.DeleteGroup;

namespace CoachBuddy.Application.Mappings
{
    public class GroupMappingProfile : Profile
    {
        public GroupMappingProfile(IUserContext userContext)
        {
            
        }
    }
}
