using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Bff.Interfaces;

namespace OrganistsSchedule.WebApi.Controllers;

[ApiController]
[Route("v1/holyServices")]
public class HolyServiceController(IHolyServiceBffService serviceBase, 
    IExportBffService exportService, IAuthService authService) : Controller
{
    
    [HttpPost("congregations/{id}/scheduleOrganists")]
    //[Authorize(Policy = "process:generate-schedule")]
    public async Task<PagedResultDto<HolyServiceDto>> ScheduleOrganistsForHolyServices(long id , [FromBodyAttribute] HolyServiceScheduleRequestDto dates)
    {
        return await serviceBase.ScheduleOrganistsForHolyServicesAsync(id, dates);
    }
    
    [HttpGet("congregations/{id}/export")]
    //[Authorize(Policy = "process:export-schedule")]
    public async Task<IActionResult> ExportToExcel(long id)
    {
        var holyServices = await serviceBase.GetHolyServicesByCongregationIdAsync(id);
        var fileBytes = exportService.ExportHolyServicesToExcel(holyServices);
        
        if (fileBytes == null || fileBytes.Length == 0)
        {
            return NotFound();
        }
        
        return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "HolyServices.xlsx");
    }
}