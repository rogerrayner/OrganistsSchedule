using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces.Results;

namespace OrganistsSchedule.Domain.Interfaces;

public interface IOrganistRepository<TRequest>: IRepositoryBase<Organist, TRequest>
    where TRequest : class, IPagedAndSortedRequest
{ 
    Task<IEnumerable<Organist>> GetByIdsAsync(List<long> organistIds, 
        CancellationToken cancellationToken = default);

    Task<IPagedResult<Organist>> GetAvailableOrganistsAsync(
        TRequest request,
        CancellationToken cancellationToken = default,
        ISpecification<Organist>? specification = null);
}