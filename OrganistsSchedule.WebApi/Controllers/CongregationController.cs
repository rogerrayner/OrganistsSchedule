using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/congregations")]
public class CongregationController(ICongregationService serviceBase, IMapper mapper) 
    : ControllerBase<CongregationDto, Congregation>(serviceBase, mapper)
{
    [HttpPost]
    [Route("{id}/organists")]
    public virtual async Task<CongregationDto> SetOrganistsAsync(long id, List<long> organistIds)
    {
        return await serviceBase.SetOrganistsAsync(id, organistIds);
    }
}