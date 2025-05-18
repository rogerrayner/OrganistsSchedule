using System.Data;

namespace OrganistsSchedule.Domain.Interfaces;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
    Task BulkSaveChangesAsync(CancellationToken cancellationToken);
    IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
}