using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/cities")]
public class CityController(ICityService serviceBase) 
    : ControllerBase<CityDto, City>(serviceBase)
{
    
}