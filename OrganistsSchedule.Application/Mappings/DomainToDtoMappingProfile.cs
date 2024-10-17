using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Mappings;

public class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<Cep, CepDto>().ReverseMap();
        CreateMap<City, CityDto>().ReverseMap();
        CreateMap<Country, CountryDto>().ReverseMap();
        CreateMap<Address, AddressDto>().ReverseMap();
        CreateMap<Email, EmailDto>().ReverseMap();
        CreateMap<Phone, PhoneDto>().ReverseMap();
        CreateMap<Congregation, CongregationDto>().ReverseMap();
        CreateMap<HolyService, HolyServiceDto>().ReverseMap();
        CreateMap<Organist, OrganistDto>().ReverseMap();
        CreateMap<ParameterSchedule, ParameterScheduleDto>().ReverseMap();
        
    }
}