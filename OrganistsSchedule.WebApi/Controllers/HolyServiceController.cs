using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.Services;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.WebApi.Controllers;

[Route("v1/holyServices")]
public class HolyServiceController(IHolyServiceService serviceBase, IMapper mapper, IExportService exportService) 
    : ControllerBase<HolyService, HolyServiceDto, HolyServiceDto, HolyServiceDto>(serviceBase, mapper)
{
    [HttpPost]
    [Route("congregations/{id}/scheduleOrganists")]
    public async Task<PagedResultDto<HolyServiceDto>> 
        ScheduleOrganistsForHolyServices(long id , 
            [FromBodyAttribute] HolyServiceScheduleRequestDto dates)
    {
        return await serviceBase.ScheduleOrganistsForHolyServicesAsync(id, dates);
    }
    
    [HttpGet("congregations/{id}/export")]
    public async Task<IActionResult> ExportToExcel(long id)
    {
        var holyServices = await serviceBase.GetHolyServicesByCongregationIdAsync(id);
        var fileBytes = exportService.ExportHolyServicesToExcel(holyServices);

        return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "HolyServices.xlsx");
    }

    [NonAction]
    public override Task<HolyServiceDto> GetByIdAsync(int id, 
        CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(id,cancellationToken);
    }

    [NonAction]
    public override Task<HolyServiceDto> CreateAsync(HolyServiceDto dto, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(dto, cancellationToken);
    }

    [NonAction]
    public override Task<HolyServiceDto> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(id, cancellationToken);
    }

    [NonAction]
    public override Task<HolyServiceDto> UpdateAsync(HolyServiceDto dto, long id, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(dto, id, cancellationToken);
    }

    [NonAction]
    public override Task<PagedResultDto<HolyServiceDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return base.GetAllAsync(cancellationToken);
    }
}