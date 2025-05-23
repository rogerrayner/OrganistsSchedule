using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class CepRepository(ApplicationDbContext context) 
    : RepositoryBase<Cep>(context), ICepRepository
{
    private readonly DbSet<Cep> _repository = context.Set<Cep>();

    public async Task<Cep?> GetCepByZipCodeAsync(string cep)
    {
        return await _repository
            .Where(x => x.ZipCode == cep)
            .Include(x => x.City)
            .ThenInclude(x => x.Country)
            .FirstOrDefaultAsync();
    }

    protected override IQueryable<Cep> IncludeChildren(IQueryable<Cep> query)
    {
        return query
            .Include(x => x.City)
            .ThenInclude(x => x.Country);
    }
}