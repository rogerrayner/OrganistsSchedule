using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Interfaces;
using OrganistsSchedule.Domain.Interfaces.Results;
using OrganistsSchedule.Domain.Results;

namespace OrganistsSchedule.Infra.Data.Repositories;

public abstract class RepositoryBase<TEntity, TRequest>(DbContext _context) 
    : IRepositoryBase<TEntity, TRequest>
    where TEntity : class
    where TRequest : class, IPagedAndSortedRequest
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

    public async Task<int> GetTotalCountAsync(IQueryable<TEntity> query, CancellationToken cancellationToken = default)
    {
        return await query.CountAsync(cancellationToken);
    }
    
    public virtual async Task<IPagedResult<TEntity>> GetAllAsync(
        TRequest request, 
        CancellationToken cancellationToken, 
        ISpecification<TEntity>? specification = null)
    {
        var baseQuery = CreateFilteredQuery(specification);
        var totalCount = await GetTotalCountAsync(baseQuery, cancellationToken);
        
        baseQuery = PagedAndSortedQuery(baseQuery, request);
        
        var idsQuery = baseQuery
            .Select(e => EF.Property<long>(e, "Id"));

        var ids = await idsQuery.ToListAsync(cancellationToken);

        if (!ids.Any())
            return new PagedResult<TEntity>(new List<TEntity>(), 0);

        var query = _dbSet
            .Where(e => ids.Contains(EF.Property<long>(e, "Id")));
        query = IncludeChildren(query);

        var results = await query.ToListAsync(cancellationToken);
        
        return new PagedResult<TEntity>(results, totalCount);
    }
    
    public virtual IQueryable<TEntity> PagedAndSortedQuery(
        IQueryable<TEntity> query,
        TRequest request, 
        ISpecification<TEntity>? specification = null)
    {
        if (request.SkipCount > 0)
            query = query.Skip(request.SkipCount);

        if (request.MaxCount > 0)
            query = query.Take(Math.Min(request.PageSize, request.MaxCount));
        else
            query = query.Take(request.PageSize);

        return query;
    }
    
    /*public virtual IQueryable<TEntity> PagedAndSortedSpecificationQuery(
        IQueryable<TEntity> query,
        IPagedAndSortedSpecification request)
    {
        if (request.SkipCount > 0)
            query = query.Skip(request.SkipCount);

        if (request.MaxCount > 0)
            query = query.Take(Math.Min(request.PageSize, request.MaxCount));
        else
            query = query.Take(request.PageSize);

        return query;
    }*/

    public virtual async Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var query = _dbSet.AsQueryable();
        query = query.Where(e => EF.Property<long>(e, "Id") == id);
        query = IncludeChildren(query);
        return await query.FirstOrDefaultAsync(cancellationToken);
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