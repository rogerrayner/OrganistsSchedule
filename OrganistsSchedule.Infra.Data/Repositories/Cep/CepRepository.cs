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
            .FirstOrDefaultAsync();
    }

    public override IQueryable<Cep> CreateFilteredQuery()
    {
        //TODO validar relacionamentos para resolver o erro que está ocorrendo ao incluir cidade e país no result
        return _repository
            .Include(x => x.City);
    }
}