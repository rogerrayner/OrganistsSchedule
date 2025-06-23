using OrganistsSchedule.Domain.Interfaces;
using OrganistsSchedule.Domain.Interfaces.Results;

namespace OrganistsSchedule.Application.Interfaces;

public interface ICrudServiceBase<TEntity, TRequest>
    where TRequest : class, IPagedAndSortedRequest
{
    Task<IPagedResult<TEntity>> GetAllAsync(TRequest request, 
        CancellationToken cancellationToken = default, 
        ISpecification<TEntity>? spec = null);
    Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity> UpdateAsync(TEntity entity, long id, CancellationToken cancellationToken = default);
    Task<TEntity> DeleteAsync(long id, CancellationToken cancellationToken = default);
}