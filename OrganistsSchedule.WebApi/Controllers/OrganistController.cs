using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Bff.Interfaces;
using OrganistsSchedule.Domain.Entities;
namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/organists")]
public class OrganistController(IOrganistBffService serviceBase, IAuthService authService) 
    : ControllerBase<Organist, 
        OrganistDto,
        OrganistPagedAndSortedRequest,
        OrganistCreateDto, 
        OrganistUpdateDto>(serviceBase, authService)
{
    protected override string ReadPolicy => "read:organist";
    protected override string UpdatePolicy => "update:organist";
    protected override string CreatePolicy => "create:organist";
    protected override string DeletePolicy => "delete:organist";
    
    [HttpGet]
    [Route("available")]
    //[Authorize(Policy = "process:set-organist-congregation")]
    public async Task<PagedResultDto<OrganistDto>> GetAvailableOrganistsAsync(
        [FromQuery] OrganistPagedAndSortedRequest request,
        CancellationToken cancellationToken = default)
    {
        return await serviceBase.GetAvailableOrganistsAsync(request.CongregationId, request, cancellationToken);
    }
    
    
}