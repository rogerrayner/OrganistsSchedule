using OrganistsSchedule.Application.DTOs;

namespace OrganistsSchedule.Bff.Interfaces;

public interface IScheduleOrganistsBffService
{
    Task<List<HolyServiceDto>> ScheduleOrganistsForHolyServices(ParameterScheduleDto dto,
        CancellationToken cancellationToken = default);
}