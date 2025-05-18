using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Mappings;

public class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<Cep, CepDto>()
            .ReverseMap();
        CreateMap<Cep, CepCreateUpdateRequestDto>()
            .ReverseMap();
        CreateMap<City, CityDto>()
            .ReverseMap();
        CreateMap<City, CityCreateUpdateRequestDto>()
            .ReverseMap();
        CreateMap<Country, CountryDto>()
            .ReverseMap();
        CreateMap<Country, CountryResponseDto>()
            .ReverseMap();
        CreateMap<Country, CountryCreateUpdateRequestDto>()
            .ReverseMap();
        CreateMap<Address, AddressDto>()
            .ReverseMap();
        CreateMap<Address, AddressCreateUpdateDto>()
            .ReverseMap();
        CreateMap<Email, EmailDto>()
            .ReverseMap();
        CreateMap<Email, EmailCreateUpdateRequestDto>()
            .ReverseMap();
        CreateMap<Phone, PhoneDto>()
            .ReverseMap();
        CreateMap<Phone, PhoneCreateUpdateRequestDto>()
            .ReverseMap();
        CreateMap<Congregation, CongregationDto>()
            .ReverseMap();
        CreateMap<Congregation, CongregationCreateRequestDto>()
            .ReverseMap();
        CreateMap<Congregation, CongregationUpdateRequestDto>()
            .ReverseMap();
        CreateMap<HolyService, HolyServiceDto>()
            .ReverseMap();
        CreateMap<Organist, OrganistDto>()
            .ReverseMap();
        CreateMap<ParameterSchedule, ParameterScheduleDto>()
            .ReverseMap();

    }
}