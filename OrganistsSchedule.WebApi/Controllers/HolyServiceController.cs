using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.Services;
using OrganistsSchedule.Application.Services.Requests;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/holyServices")]
public class HolyServiceController(IHolyServiceService serviceBase, IMapper mapper, IExportService exportService, IAuthService authService) 
    : ControllerBase<HolyService, 
        HolyServiceDto, 
        HolyServicePagedAndSortedRequest,
        HolyServiceDto, 
        HolyServiceDto>(serviceBase, mapper, authService)
{
    
    [HttpPost("congregations/{id}/scheduleOrganists")]
    [Authorize(Policy = "process:generate-schedule")]
    public async Task<PagedResultDto<HolyServiceDto>> 
        ScheduleOrganistsForHolyServices(long id , 
            [FromBodyAttribute] HolyServiceScheduleRequestDto dates)
    {
        return await serviceBase.ScheduleOrganistsForHolyServicesAsync(id, dates);
    }
    
    [HttpGet("congregations/{id}/export")]
    [Authorize(Policy = "process:export-schedule")]
    public async Task<IActionResult> ExportToExcel(long id)
    {
        var holyServices = await serviceBase.GetHolyServicesByCongregationIdAsync(id);
        var fileBytes = exportService.ExportHolyServicesToExcel(holyServices);

        return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "HolyServices.xlsx");
    }

    [NonAction]
    public override Task<ActionResult<HolyServiceDto>> GetByIdAsync(long id, 
        CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(id,cancellationToken);
    }

    [NonAction]
    public override Task<ActionResult<HolyServiceDto>> CreateAsync(HolyServiceDto dto, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(dto, cancellationToken);
    }

    [NonAction]
    public override Task<ActionResult<HolyServiceDto>> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(id, cancellationToken);
    }

    [NonAction]
    public override Task<ActionResult<HolyServiceDto>> UpdateAsync(HolyServiceDto dto, long id, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(dto, id, cancellationToken);
    }

    [NonAction]
    public override Task<ActionResult<PagedResultDto<HolyServiceDto>>> GetAllAsync([FromQuery] HolyServicePagedAndSortedRequest request, CancellationToken cancellationToken = default)
    {
        return base.GetAllAsync(request, cancellationToken);
    }
}