using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public abstract class RepositoryBase<TEntity>(DbContext _context) 
    : IRepositoryBase<TEntity>
    where TEntity : class
{
    private readonly DbSet<TEntity> _dbSet = _context.Set<TEntity>();
    
    private IQueryable<TEntity> CreateFilteredQuery(ISpecification<TEntity>? specification = null)
    {
        var query = _dbSet.AsQueryable();
        
        if (specification != null)
            query = specification.Apply(query);

        return query;
    }
    
    protected virtual IQueryable<TEntity> IncludeChildren(IQueryable<TEntity> query)
    {
        return query;
    }
    
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(IPagedAndSortedRequest request,
        CancellationToken cancellationToken,
        ISpecification<TEntity>? specification = null)
    {
        var query = CreateFilteredQuery(specification);
        
        query = IncludeChildren(query);

        if (request.SkipCount > 0)
            query = query.Skip(request.SkipCount);

        if (request.MaxCount > 0)
            query = query.Take(Math.Min(request.PageSize, request.MaxCount));
        else
            query = query.Take(request.PageSize);

        return await query.ToListAsync(cancellationToken);
    }

    public virtual async Task<int> CountAsync(IPagedAndSortedRequest request, 
        CancellationToken cancellationToken = default,
        ISpecification<TEntity>? specification = null)
    {
        var query = CreateFilteredQuery(specification);
        query = IncludeChildren(query);
        return await query.CountAsync(cancellationToken);
    }

    public virtual async Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var query = _dbSet.AsQueryable();
        query = IncludeChildren(query);
        return await query.FirstOrDefaultAsync(e => EF.Property<long>(e, "Id") == id);
    }

    public virtual async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _dbSet.Add(entity);
        return entity;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _dbSet.Update(entity);
        return entity;
    }

    public virtual async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _dbSet.Remove(entity);
        return entity;
    }

    public virtual async Task<IEnumerable<TEntity>> BulkDeleteAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        await _context.BulkDeleteAsync(entities);
        return entities;
    }

    public virtual async Task<IEnumerable<TEntity>> BulkUpdateAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        await _context.BulkUpdateAsync(entities);
        return entities;
    }

    public virtual async Task<IEnumerable<TEntity>> BulkCreateAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        await _context.BulkInsertAsync(entities);
        return entities;
    }
}