using OrganistsSchedule.Domain.Interfaces.Results;

namespace OrganistsSchedule.Domain.Interfaces;

public interface ICongregationOrganistRepository<TRequest>: IRepositoryBase<CongregationOrganist, TRequest>
    where TRequest : class, IPagedAndSortedRequest
{
    Task<IPagedResult<CongregationOrganist>> GetByCongregationAsync(long congregationId,
        CancellationToken cancellationToken = default);
}