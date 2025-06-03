using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Services;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Interfaces;

public interface IHolyServiceService: ICrudServiceBase<HolyService, HolyServiceDto, HolyServicePagedAndSortedRequest>
{
    Task<PagedResultDto<HolyServiceDto>> ScheduleOrganistsForHolyServicesAsync(long congregationId, 
        HolyServiceScheduleRequestDto dates,
        CancellationToken cancellationToken = default);
    Task<List<HolyServiceDto>> GetHolyServicesByCongregationIdAsync(long congregationId, CancellationToken cancellationToken = default);
}