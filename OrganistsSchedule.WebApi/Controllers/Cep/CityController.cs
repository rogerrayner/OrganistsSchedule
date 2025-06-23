using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Bff.Interfaces;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/cities")]
public class CityController(ICityBffService serviceBase, IAuthService authService) 
    : ControllerBase<City, 
        CityDto, 
        CityPagedAndSortedRequest,
        CityCreateUpdateRequestDto, 
        CityCreateUpdateRequestDto>(serviceBase, authService)
{
    
    protected override string ReadPolicy => "read:city";
    protected override string UpdatePolicy => "update:city";
    protected override string CreatePolicy => "create:city";
    protected override string DeletePolicy => "delete:city";
    
    [NonAction]
    public override Task<ActionResult<CityDto>> UpdateAsync(CityCreateUpdateRequestDto dto, long id, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(dto, id, cancellationToken);
    }
}