using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/cities")]
public class CityController(ICityService serviceBase, IMapper mapper) 
    : ControllerBase<City, CityDto, CityCreateUpdateRequestDto, CityCreateUpdateRequestDto>(serviceBase, mapper)
{
    [NonAction]
    public override Task<CityDto> UpdateAsync(CityCreateUpdateRequestDto dto, long id)
    {
        return base.UpdateAsync(dto, id);
    }
}