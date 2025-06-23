using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Bff.Interfaces;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/congregations")]
public class CongregationController(ICongregationBffService serviceBase, IAuthService authService) 
    : ControllerBase<Congregation, 
        CongregationDto,
        CongregationPagedAndSortedRequest,
        CongregationCreateRequestDto, 
        CongregationCreateRequestDto>(serviceBase, authService)
{
    
    protected override string ReadPolicy => "read:congregation";
    protected override string UpdatePolicy => "update:congregation";
    protected override string CreatePolicy => "create:congregation";
    protected override string DeletePolicy => "delete:congregation";
    
    [HttpPost]
    [Route("{id}/organists")]
    //[Authorize(Policy = "process:set-organist-congregation")]
    public virtual async Task<CongregationDto> SetOrganistsAsync(long id, List<OrganistDaysDto> organistsDays)
    {
        return await serviceBase.SetOrganistsAsync(id, organistsDays);
    }
    
    [HttpGet]
    [Route("{id}/organists")]
    //[Authorize(Policy = "process:set-organist-congregation")]
    public async Task<PagedResultDto<CongregationOrganistsDto>> GetOrganistsByCongregationAsync(long id)
    {
        return await serviceBase.GetOrganistsByCongregationAsync(id);
    }

    public override async Task<ActionResult<PagedResultDto<CongregationDto>>> GetAllAsync(CongregationPagedAndSortedRequest request, CancellationToken cancellationToken = default)
    {
        return await serviceBase
            .GetAllWithHolyServiceFlagAsync(request, cancellationToken);
    }
}