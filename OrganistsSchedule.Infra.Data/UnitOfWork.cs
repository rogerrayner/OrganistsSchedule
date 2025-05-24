using System.Data;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
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
    
    public async Task<IDbContextTransaction> BeginTransactionAsync(IsolationLevel isolationLevel, CancellationToken cancellationToken = default)
    {
        return await dbContext.Database.BeginTransactionAsync(isolationLevel, cancellationToken);
    }
    
    private void SetUtcDateTimes()
    {
        foreach (var entry in dbContext.ChangeTracker.Entries())
        {
            foreach (var property in entry.Properties)
            {
                if (property.CurrentValue is DateTime dt && dt.Kind == DateTimeKind.Unspecified)
                {
                    property.CurrentValue = DateTime.SpecifyKind(dt, DateTimeKind.Utc);
                }
            }
        }
    }
}