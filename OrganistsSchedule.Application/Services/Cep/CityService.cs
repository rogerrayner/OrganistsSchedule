using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class CityService(IMapper mapper, ICityRepository repository) 
    : CrudServiceBase<CityDto, City>(mapper, repository), 
        ICityService
{
    
}