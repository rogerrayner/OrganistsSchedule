using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Interfaces;

public interface IExportService
{
    public byte[] ExportHolyServicesToExcel(IEnumerable<HolyService> holyServices);
}