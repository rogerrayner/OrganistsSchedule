using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class EmailRepository(ApplicationDbContext context) 
    : RepositoryBase<Email>(context), IEmailRepository
{
    public async Task<Email> GetEmailByEmailAddressAsync(string email, CancellationToken cancellationToken = default)
    {
        return await context.Emails
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.EmailAddress == email, cancellationToken);
    }
}