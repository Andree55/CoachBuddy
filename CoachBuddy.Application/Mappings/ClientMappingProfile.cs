using AutoMapper;
using CoachBuddy.Application.ApplicationUser;
using CoachBuddy.Application.Client;
using CoachBuddy.Application.Client.Commands.DeleteClient;
using CoachBuddy.Application.Client.Commands.EditClient;
using CoachBuddy.Application.ClientTraining;
using CoachBuddy.Application.Group;
using CoachBuddy.Domain.Entities.Client;

namespace CoachBuddy.Application.Mappings
{
    public class CoachBuddyMappingProfile : Profile
    {
        public CoachBuddyMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();
            CreateMap<ClientDto, Domain.Entities.Client.Client>()
                .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new ClientContactDetails()
                {
                    City = src.City,
                    PhoneNumber = src.PhoneNumber,
                    PostalCode = src.PostalCode,
                    Street = src.Street,
                }));

            CreateMap<Domain.Entities.Client.Client, ClientDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null
                                                && (user.IsInRole("Admin"))))
                .ForMember(dto => dto.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
                .ForMember(dto => dto.City, opt => opt.MapFrom(src => src.ContactDetails.City))
                .ForMember(dto => dto.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode))
                .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber));

            CreateMap<ClientDto, EditClientCommand>();

            CreateMap<ClientTrainingDto, Domain.Entities.Client.ClientTraining>()
                .ReverseMap();

            CreateMap<ClientDto, DeleteClientCommand>();
            CreateMap<Domain.Entities.Group.Group, GroupDto>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.EncodedName, opt => opt.MapFrom(src => src.EncodedName))
            .ForMember(dest => dest.CreatedById, opt => opt.MapFrom(src => src.CreatedById))
            .ForMember(dest => dest.IsEditable, opt => opt.Ignore());

            CreateMap<GroupDto, Domain.Entities.Group.Group>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) 
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore()) 
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore()) 
                .ForMember(dest => dest.ClientGroups, opt => opt.Ignore());
        }
    }
}