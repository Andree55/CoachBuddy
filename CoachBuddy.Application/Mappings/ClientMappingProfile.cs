using AutoMapper;
using CoachBuddy.Application.ApplicationUser;
using CoachBuddy.Application.Client;
using CoachBuddy.Application.Client.Commands.EditClient;
using CoachBuddy.Application.ClientTraining;
using CoachBuddy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Application.Mappings
{
    public class CoachBuddyMappingProfile : Profile
    {
        public CoachBuddyMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();
            CreateMap<ClientDto, Domain.Entities.Client>()
                .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new ClientContactDetails()
                {
                    City = src.City,
                    PhoneNumber = src.PhoneNumber,
                    PostalCode = src.PostalCode,
                    Street = src.Street,
                }));

            CreateMap<Domain.Entities.Client, ClientDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null 
                                                && (src.CreatedById == user.Id || user.IsInRole("Moderator"))))
                .ForMember(dto => dto.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
                .ForMember(dto => dto.City, opt => opt.MapFrom(src => src.ContactDetails.City))
                .ForMember(dto => dto.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode))
                .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber));

            CreateMap<ClientDto, EditClientCommand>();

            CreateMap<ClientTrainingDto, Domain.Entities.ClientTraining>()
                .ReverseMap();

        }
    }
}