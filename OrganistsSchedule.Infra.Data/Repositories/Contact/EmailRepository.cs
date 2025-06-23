using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class EmailRepository<TRequest>(ApplicationDbContext context)
    : RepositoryBase<Email, TRequest>(context), IEmailRepository<TRequest>
    where TRequest : class, IPagedAndSortedRequest
{
    public async Task<Email> GetEmailByEmailAddressAsync(string email, CancellationToken cancellationToken = default)
    {
        return await context.Emails
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.EmailAddress == email, cancellationToken);
    }
}