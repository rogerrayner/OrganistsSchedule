using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Interfaces;

public interface IScheduleOrganistsService
{
    Task<List<HolyService>> ScheduleOrganistsForHolyServices(ParameterSchedule parametersSchedule);
}