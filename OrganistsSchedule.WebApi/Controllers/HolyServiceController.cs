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
    public async Task<PagedResultDto<HolyServiceDto>> ScheduleOrganistsForHolyServices(long id , [FromBodyAttribute] HolyServiceScheduleRequestDto dates)
    {
        return await serviceBase.ScheduleOrganistsForHolyServices(id, dates);
    }
    
    [HttpGet("congregations/{id}/export")]
    public async Task<IActionResult> ExportToExcel(long id)
    {
        var holyServices = await serviceBase.GetHolyServicesByCongregationId(id);
        var fileBytes = exportService.ExportHolyServicesToExcel(holyServices);

        return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "HolyServices.xlsx");
    }
    
}