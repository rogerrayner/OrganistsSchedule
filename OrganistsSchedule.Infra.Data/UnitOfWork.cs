using System.Data;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore.Storage;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data;

internal sealed class UnitOfWork (ApplicationDbContext dbContext) : IUnitOfWork
{
    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return dbContext.SaveChangesAsync(cancellationToken);
    }
    
    public Task BulkSaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return dbContext.BulkSaveChangesAsync();
    }

    public IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
    {
        return dbContext.Database.BeginTransaction().GetDbTransaction();
    }
    
}