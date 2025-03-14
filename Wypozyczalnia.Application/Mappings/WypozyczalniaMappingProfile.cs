using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wypozyczalnia.Application.ApplicationUser;
using Wypozyczalnia.Application.Devices;
using Wypozyczalnia.Application.Reservations;
using Wypozyczalnia.Application.Wypozyczalnia.Commands;
using Wypozyczalnia.Application.Wypozyczalnia.Commands.EditWypozyczalnia;
using Wypozyczalnia.Domain.Entities;

namespace Wypozyczalnia.Application.Mappings
{
    public class WypozyczalniaMappingProfile : Profile
    {
        public WypozyczalniaMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();

            CreateMap<WypozyczalniaDto, Domain.Entities.Wypozyczalnia>()
                .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new WypozyczalniaContactDetails()
                {
                    City = src.City,
                    PhoneNumber = src.PhoneNumber,
                    PostalCode = src.PostalCode,
                    Street = src.Street,
                }));

            CreateMap<Domain.Entities.Wypozyczalnia, WypozyczalniaDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null && src.CreatedById == user.Id))
                .ForMember(dto => dto.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
                .ForMember(dto => dto.City, opt => opt.MapFrom(src => src.ContactDetails.City))
                .ForMember(dto => dto.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode))
                .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber));

            CreateMap<WypozyczalniaDto, EditWypozyczalniaCommand>();
            CreateMap<Domain.Entities.Devices, DeviceDto>();
        }
    }
}
