using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Services;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Interfaces;

public interface IHolyServiceService: ICrudServiceBase<HolyServiceDto, HolyService>
{
    Task<PagedResultDto<HolyServiceDto>> ScheduleOrganistsForHolyServices(long congregationId, HolyServiceScheduleRequestDto dates);
}