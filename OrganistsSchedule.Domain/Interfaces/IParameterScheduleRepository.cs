using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Domain.Interfaces;

public interface IParameterScheduleRepository<TRequest>: IRepositoryBase<ParameterSchedule, TRequest>
    where TRequest : class, IPagedAndSortedRequest
{
    Task<ParameterSchedule> GetByRangeDateAndCongregationIdAsync(long congregationId, 
        DateTime startDate, 
        DateTime endDate,
        CancellationToken cancellationToken = default);

    Task<bool> HasDateRangeOverlapAsync(long congregationId,
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken = default);
}