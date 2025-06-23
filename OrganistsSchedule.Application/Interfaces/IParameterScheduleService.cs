using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Interfaces;

public interface IParameterScheduleService: ICrudServiceBase<ParameterSchedule, 
    ParameterSchedulePagedAndSortedRequest>
{
    Task<ParameterSchedule> GetByRangeDateAndCongregationIdAsync(long congregationId, 
        DateTime startDate, 
        DateTime endDate,
        CancellationToken cancellationToken = default);
}