using OrganistsSchedule.Application.DTOs;

namespace OrganistsSchedule.Bff.Interfaces;

public interface IExportBffService
{
    public byte[] ExportHolyServicesToExcel(IEnumerable<HolyServiceDto> holyServices);
}