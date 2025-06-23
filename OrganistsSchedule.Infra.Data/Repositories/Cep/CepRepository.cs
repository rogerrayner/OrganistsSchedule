using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class CepRepository<TRequest>(ApplicationDbContext context)
    : RepositoryBase<Cep, TRequest>(context), ICepRepository<TRequest>
    where TRequest : class, IPagedAndSortedRequest
{
    private readonly DbSet<Cep> _repository = context.Set<Cep>();

    public async Task<Cep?> GetCepByZipCodeAsync(string zipCode, CancellationToken cancellationToken)
    {
        return await _repository
            .Include(x => x.City)
            .ThenInclude(x => x.Country)
            .FirstOrDefaultAsync(c => c.ZipCode == zipCode, cancellationToken);
    }
    
    public async Task<List<string>> GetDistrictsByCityIdAsync(
        long cityId,
        CancellationToken cancellationToken = default)
    {
        var query = _repository
            .Where(c => c.CityId == cityId);

        /*if (request != null)
            query = PagedAndSortedSpecificationQuery(query, request);*/        
        
        return await query
            .Select(c => c.District)
            .Distinct()
            .ToListAsync(cancellationToken);
    }

    protected override IQueryable<Cep> IncludeChildren(IQueryable<Cep> query)
    {
        return query
            .Include(x => x.City)
            .ThenInclude(x => x.Country);
    }
}