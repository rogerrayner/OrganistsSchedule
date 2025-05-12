using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Mappings;

public class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<Cep, CepDto>()
            .ReverseMap()
            .ForMember("Id", opt => opt.Ignore());
        CreateMap<City, CityDto>()
            .ReverseMap()
            .ForMember("Id", opt => opt.Ignore());
        CreateMap<Country, CountryDto>()
            .ReverseMap()
            .ForMember("Id", opt => opt.Ignore());
        CreateMap<Address, AddressDto>()
            .ReverseMap()
            .ForMember("Id", opt => opt.Ignore());
        CreateMap<Email, EmailDto>()
            .ReverseMap()
            .ForMember("Id", opt => opt.Ignore());
        CreateMap<Phone, PhoneDto>()
            .ReverseMap()
            .ForMember("Id", opt => opt.Ignore());
        CreateMap<Congregation, CongregationDto>()
            .ReverseMap()
            .ForMember("Id", opt => opt.Ignore());
        CreateMap<HolyService, HolyServiceDto>()
            .ReverseMap()
            .ForMember("Id", opt => opt.Ignore());
        CreateMap<Organist, OrganistDto>()
            .ReverseMap()
            .ForMember("Id", opt => opt.Ignore());
        CreateMap<ParameterSchedule, ParameterScheduleDto>()
            .ReverseMap()
            .ForMember("Id", opt => opt.Ignore());
        
    }
}