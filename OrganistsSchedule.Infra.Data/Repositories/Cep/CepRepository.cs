using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class CepRepository(ApplicationDbContext context) 
    : RepositoryBase<Cep>(context), ICepRepository
{
    private readonly DbSet<Cep> _dbSet = context.Set<Cep>();

    public async Task<Cep?> GetCepByZipCodeAsync(string cep)
    {
        return await _dbSet
            .Where(x => x.ZipCode == cep)
            .FirstOrDefaultAsync();
    }
}