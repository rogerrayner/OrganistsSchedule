using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public abstract class RepositoryBase<TEntity>(DbContext context) 
    : IRepositoryBase<TEntity>
    where TEntity : class
{
    
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();
    
    public async Task<List<TEntity>> GetAllAsync()
    {
        var query = CreateFilteredQuery();
        return await query.ToListAsync();

    }

    public virtual IQueryable<TEntity> CreateFilteredQuery()
    {
        return _dbSet.AsQueryable();
    }

    public async Task<TEntity?> GetByIdAsync(long id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        _dbSet.Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<ICollection<TEntity>> BulkDeleteAsync(ICollection<TEntity> entities)
    {
        await context.BulkDeleteAsync(entities);
        await context.BulkSaveChangesAsync();
        return entities;
    }

    public async Task<ICollection<TEntity>> BulkUpdateAsync(ICollection<TEntity> entities)
    {
        await context.BulkUpdateAsync(entities);
        await context.BulkSaveChangesAsync();
        return entities;
    }

    public async Task<ICollection<TEntity>> BulkCreateAsync(ICollection<TEntity> entities)
    {
        await context.BulkInsertAsync(entities);
        await context.BulkSaveChangesAsync();
        return entities;
    }
}