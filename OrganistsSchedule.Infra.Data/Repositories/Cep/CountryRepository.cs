using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class CountryRepository<TRequest>(ApplicationDbContext context)
    : RepositoryBase<Country, TRequest>(context), ICountryRepository<TRequest>
    where TRequest : class, IPagedAndSortedRequest
{
    public async Task<Country?> GetByNameAsync(string name)
    {
        return await context.Set<Country>()
            .FirstOrDefaultAsync(c => c.Name == name);
    }
}