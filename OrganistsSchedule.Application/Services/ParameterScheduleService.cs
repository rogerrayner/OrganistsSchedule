using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class ParameterScheduleService(
    IParameterScheduleRepository<
        ParameterSchedulePagedAndSortedRequest> repository, 
    IUnitOfWork unitOfWork) 
    : CrudServiceBase<ParameterSchedule, 
            ParameterSchedulePagedAndSortedRequest>(repository, unitOfWork),
        IParameterScheduleService
{
    public async Task<ParameterSchedule> GetByRangeDateAndCongregationIdAsync(long congregationId, 
        DateTime startDate, 
        DateTime endDate,
        CancellationToken cancellationToken = default)
    {
        return await repository.GetByRangeDateAndCongregationIdAsync(congregationId, 
            startDate, 
            endDate,
            cancellationToken);
    }
}