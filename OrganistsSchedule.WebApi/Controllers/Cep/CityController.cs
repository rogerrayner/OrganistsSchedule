using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.WebApi.Controllers;

public class CityController(ICityService serviceBase) 
    : ControllerBase<CityDto, City>(serviceBase)
{
    
}