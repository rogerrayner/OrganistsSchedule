using OrganistsSchedule.Application.DTOs;

namespace OrganistsSchedule.Bff.Interfaces;

public interface IHolyServiceBffService
{
    Task<PagedResultDto<HolyServiceDto>> ScheduleOrganistsForHolyServicesAsync(long congregationId,
        HolyServiceScheduleRequestDto dates,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<HolyServiceDto>> GetHolyServicesByCongregationIdAsync(long congregationId,
        CancellationToken cancellationToken = default);
}