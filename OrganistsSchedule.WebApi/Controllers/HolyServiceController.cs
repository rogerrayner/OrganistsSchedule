using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.Services;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/holyServices")]
public class HolyServiceController(IHolyServiceService serviceBase) 
    : ControllerBase<HolyServiceDto, HolyService>(serviceBase)
{

    [HttpPost]
    [Route("congregations/{id}/scheduleOrganists")]
    public async Task<PagedResultDto<HolyServiceDto>> ScheduleOrganistsForHolyServices(long id , [FromBodyAttribute] HolyServiceScheduleRequestDto dates)
    {
        return await serviceBase.ScheduleOrganistsForHolyServices(id, dates);
    }
    
}