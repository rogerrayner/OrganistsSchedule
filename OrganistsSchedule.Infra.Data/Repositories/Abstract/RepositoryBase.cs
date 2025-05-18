using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public abstract class RepositoryBase<TEntity>(DbContext _context) 
    : IRepositoryBase<TEntity>
    where TEntity : class
{
    private readonly DbSet<TEntity> _dbSet = _context.Set<TEntity>();
    
    public virtual async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        var query = CreateFilteredQuery();
        query = IncludeChildren(query);
        return await query.ToListAsync();
    }

    public virtual IQueryable<TEntity> CreateFilteredQuery()
    {
        return _dbSet.AsQueryable();
    }
    
    protected virtual IQueryable<TEntity> IncludeChildren(IQueryable<TEntity> query)
    {
        return query;
    }

    public virtual async Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var query = IncludeChildren(_dbSet.AsQueryable());
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

    public virtual async Task<ICollection<TEntity>> BulkDeleteAsync(ICollection<TEntity> entities, CancellationToken cancellationToken)
    {
        await _context.BulkDeleteAsync(entities);
        return entities;
    }

    public virtual async Task<ICollection<TEntity>> BulkUpdateAsync(ICollection<TEntity> entities, CancellationToken cancellationToken)
    {
        await _context.BulkUpdateAsync(entities);
        return entities;
    }

    public virtual async Task<ICollection<TEntity>> BulkCreateAsync(ICollection<TEntity> entities, CancellationToken cancellationToken)
    {
        await _context.BulkInsertAsync(entities);
        return entities;
    }
}