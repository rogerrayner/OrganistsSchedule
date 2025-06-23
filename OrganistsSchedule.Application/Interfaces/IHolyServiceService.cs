using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Interfaces;

public interface IHolyServiceService
{
    Task<IEnumerable<HolyService>> ScheduleOrganistsForHolyServicesAsync(long congregationId, 
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken = default);
    Task<IEnumerable<HolyService>> GetHolyServicesByCongregationIdAsync(long congregationId, CancellationToken cancellationToken = default);
}