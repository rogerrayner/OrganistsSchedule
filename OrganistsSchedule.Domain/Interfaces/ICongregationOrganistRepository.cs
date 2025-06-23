using OrganistsSchedule.Domain.Interfaces.Results;

namespace OrganistsSchedule.Domain.Interfaces;

public interface ICongregationOrganistRepository<TRequest>: IRepositoryBase<CongregationOrganist, TRequest>
    where TRequest : class, IPagedAndSortedRequest
{
    Task<IEnumerable<CongregationOrganist>> GetByCongregationAsync(long congregationId,
        CancellationToken cancellationToken = default);
    
    Task<IPagedResult<CongregationOrganist>> GetByCongregationPagedAndSortedAsync(long congregationId,
        CancellationToken cancellationToken = default);   
    
    
}