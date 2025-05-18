using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Interceptors;

public class UpdateAuditedEntitiesInterceptor():
    SaveChangesInterceptor
{
    public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        DbContext dbContext = eventData.Context;

        if (dbContext is null)
        {
            return base.SavedChangesAsync(eventData, result, cancellationToken);
        }
        
        IEnumerable<EntityEntry<IAuditableEntity>> entries = 
            dbContext
                .ChangeTracker
                .Entries<IAuditableEntity>();
        
        UpdateAuditableEntities(entries);
        
        return base.SavedChangesAsync(eventData, result, cancellationToken);
    }
    
    private async void UpdateAuditableEntities(IEnumerable<EntityEntry<IAuditableEntity>> entries)
    {
        //var user = await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);
        foreach (EntityEntry<IAuditableEntity> entityEntry in entries)
        {
            
            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Property(x => x.CreatedAt).CurrentValue = DateTime.UtcNow;
                
            }

            if (entityEntry.State == EntityState.Modified)
            {
                entityEntry.Property(x => x.UpdatedAt).CurrentValue = DateTime.UtcNow;
               
            }
        }
    }
}