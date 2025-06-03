using System.Linq.Expressions;
using Microsoft.VisualBasic;
using OrganistsSchedule.Application.Interfaces;

namespace OrganistsSchedule.Domain.Interfaces;

public interface IRepositoryBase<TEntity>
{
    Task<IEnumerable<TEntity>> GetAllAsync(IPagedAndSortedRequest request,
        CancellationToken cancellationToken = default,
        ISpecification<TEntity>? specification = null);

    Task<TEntity?> GetByIdAsync(long id,
        CancellationToken cancellationToken);

    Task<TEntity> CreateAsync(TEntity entity,
        CancellationToken cancellationToken);

    Task<TEntity> UpdateAsync(TEntity entity,
        CancellationToken cancellationToken);

    Task<TEntity> DeleteAsync(TEntity entity,
        CancellationToken cancellationToken);

    Task<IEnumerable<TEntity>> BulkDeleteAsync(IEnumerable<TEntity> entities,
        CancellationToken cancellationToken);

    Task<IEnumerable<TEntity>> BulkUpdateAsync(IEnumerable<TEntity> entities,
        CancellationToken cancellationToken);

    Task<IEnumerable<TEntity>> BulkCreateAsync(IEnumerable<TEntity> entities,
        CancellationToken cancellationToken);

    Task<int> CountAsync(IPagedAndSortedRequest request,
        CancellationToken cancellationToken = default,
        ISpecification<TEntity>? specification = null);
}