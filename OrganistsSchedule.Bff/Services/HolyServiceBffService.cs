using AutoMapper;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Bff.Interfaces;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Bff.Services;

public class HolyServiceBffService(
    IMapper mapper,
    IHolyServiceService service)
        : IHolyServiceBffService
{
    public async Task<PagedResultDto<HolyServiceDto>> ScheduleOrganistsForHolyServicesAsync(long congregationId,
        HolyServiceScheduleRequestDto dates,
        CancellationToken cancellationToken = default)
    {
        var holyServices = await service.ScheduleOrganistsForHolyServicesAsync(congregationId, 
            dates.StartDate, 
            dates.EndDate, 
            cancellationToken);

        var totalCount = holyServices.Count();

        return new PagedResultDto<HolyServiceDto>(mapper.Map<IEnumerable<HolyServiceDto>>(holyServices), totalCount);
    }

    public async Task<IEnumerable<HolyServiceDto>> GetHolyServicesByCongregationIdAsync(long congregationId, CancellationToken cancellationToken = default)
    {
        var holyServices = await service.GetHolyServicesByCongregationIdAsync(congregationId, cancellationToken);
        return mapper.Map<IEnumerable<HolyServiceDto>>(holyServices);
    }
}