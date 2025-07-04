using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class CityRepository<TRequest>(ApplicationDbContext context)
    : RepositoryBase<City, TRequest>(context), ICityRepository<TRequest>
    where TRequest : class, IPagedAndSortedRequest
{
    public async Task<City?> GetByNameAsync(string name)
    {
        return await context.Set<City>()
            .FirstOrDefaultAsync(c => c.Name == name);
    }

    protected override IQueryable<City> IncludeChildren(IQueryable<City> query)
    {
        return query
            .Include(x => x.Country);
    }
}