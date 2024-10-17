using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class CountryService(IMapper mapper, ICountryRepository repository) 
    : CrudServiceBase<CountryDto, Country>(mapper, repository), 
        ICountryService
{
    
}