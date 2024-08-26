using AutoMapper;
using CoachBuddy.Application.Client;
using CoachBuddy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CoachBuddy.Application.Mappings
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<ClientDto, Domain.Entities.Client>()
                .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new ClientContactDetails()
                {
                    City = src.City,
                    PhoneNumber = src.PhoneNumber,
                    PostalCode = src.PostalCode,
                    Street = src.Street
                }));
        }
    }
}
