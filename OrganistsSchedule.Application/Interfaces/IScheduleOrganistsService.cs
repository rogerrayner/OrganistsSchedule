using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Interfaces;

public interface IScheduleOrganistsService
{
    List<HolyService> ScheduleOrganistsForHolyServices(ParameterSchedule parametersSchedule,
        CancellationToken cancellationToken = default);
}