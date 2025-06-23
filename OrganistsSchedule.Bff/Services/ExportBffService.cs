using AutoMapper;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Bff.Interfaces;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Bff.Services;

public class ExportBffService(IMapper mapper, IExportService service) : IExportBffService
{
    public byte[] ExportHolyServicesToExcel(IEnumerable<HolyServiceDto> holyServicesDto)
    {
        var holyServices = mapper.Map<IEnumerable<HolyServiceDto>, IEnumerable<HolyService>>(holyServicesDto);
        return service.ExportHolyServicesToExcel(holyServices);
    }
}