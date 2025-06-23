using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class PhoneRepository<TRequest>(ApplicationDbContext context)
    : RepositoryBase<Phone, TRequest>(context), IPhoneRepository<TRequest>
    where TRequest : class, IPagedAndSortedRequest
{
    public Task<Phone?> GetPhoneByNumberAsync(string number, CancellationToken cancellationToken = default)
    {
        return context.Phones
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Number == number);
    }
}