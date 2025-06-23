using AutoMapper;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Results;

namespace OrganistsSchedule.Bff.Mappings;

public class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<Cep, CepDto>()
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
        CreateMap<HolyService, HolyServiceDto>()
            .ReverseMap();
        CreateMap<Organist, OrganistDto>()
            .ReverseMap();
        CreateMap<Organist, OrganistCreateDto>()
            .ReverseMap();
        CreateMap<Organist, OrganistUpdateDto>()
            .ReverseMap();
        CreateMap<ParameterSchedule, ParameterScheduleDto>()
            .ReverseMap();
        CreateMap<ParameterSchedule, ParameterScheduleCreateUpdateDto>()
            .ReverseMap();
        CreateMap<CongregationOrganist, OrganistDaysDto>()
            .ReverseMap();
        CreateMap<CongregationOrganist, CongregationOrganistsDto>()
            .ReverseMap();
    }
}