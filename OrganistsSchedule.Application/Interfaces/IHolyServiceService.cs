using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Services;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Interfaces;

public interface IHolyServiceService: ICrudServiceBase<HolyService, HolyServiceDto>
{
    Task<PagedResultDto<HolyServiceDto>> ScheduleOrganistsForHolyServices(long congregationId, 
        HolyServiceScheduleRequestDto dates,
        CancellationToken cancellationToken = default);
    List<HolyServiceDto> GetHolyServicesByCongregationId(long congregationId, CancellationToken cancellationToken = default);
}