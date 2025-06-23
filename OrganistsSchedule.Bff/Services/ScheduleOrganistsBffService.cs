using AutoMapper;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Bff.Interfaces;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Bff.Services;

public class ScheduleOrganistsBffService(IMapper mapper, IScheduleOrganistsService service) : IScheduleOrganistsBffService
{
    
    public async Task<List<HolyServiceDto>> ScheduleOrganistsForHolyServices(ParameterScheduleDto dto,
        CancellationToken cancellationToken = default)
    {
        var entity = mapper.Map<ParameterSchedule>(dto);
        var response = await service.ScheduleOrganistsForHolyServices(entity, cancellationToken);
        return mapper.Map<List<HolyServiceDto>>(response);
    }
}