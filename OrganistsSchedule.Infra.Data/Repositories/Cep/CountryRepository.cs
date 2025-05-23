using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class CountryRepository(ApplicationDbContext context) 
    : RepositoryBase<Country>(context), ICountryRepository
{
    public async Task<Country?> GetByNameAsync(string name)
    {
        return await context.Set<Country>()
            .FirstOrDefaultAsync(c => c.Name == name);
    }
}