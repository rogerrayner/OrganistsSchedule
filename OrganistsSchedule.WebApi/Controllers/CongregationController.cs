using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/congregations")]
public class CongregationController(ICongregationService serviceBase, IMapper mapper, IAuthService authService) 
    : ControllerBase<Congregation, 
        CongregationDto, 
        CongregationPagedAndSortedRequest,
        CongregationCreateRequestDto, 
        CongregationUpdateRequestDto>(serviceBase, mapper, authService)
{
    
    protected override string ReadPolicy => "read:congregation";
    protected override string UpdatePolicy => "update:congregation";
    protected override string CreatePolicy => "create:congregation";
    protected override string DeletePolicy => "delete:congregation";
    
    [HttpPost]
    [Route("{id}/organists")]
    [Authorize(Policy = "process:set-organist-congregation")]
    public virtual async Task<CongregationDto> SetOrganistsAsync(long id, List<long> organistIds)
    {
        return await serviceBase.SetOrganistsAsync(id, organistIds);
    }
}