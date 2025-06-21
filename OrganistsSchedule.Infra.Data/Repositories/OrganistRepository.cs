using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;
using OrganistsSchedule.Domain.Interfaces.Results;
using OrganistsSchedule.Domain.Results;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class OrganistRepository<TRequest>(
    ApplicationDbContext context)
    : RepositoryBase<Organist, TRequest>(context), 
        IOrganistRepository<TRequest>
    where TRequest : class, IPagedAndSortedRequest
{
    protected override IQueryable<Organist> IncludeChildren(IQueryable<Organist> query)
    {
        return query
            .Include(x => x.Cep);
    }

    public async Task<IEnumerable<Organist>> GetByIdsAsync(List<long> organistIds, CancellationToken cancellationToken = default)
    {
        return await context.Organists
            .Where(x => organistIds.Contains(x.Id))
            .ToListAsync(cancellationToken);
    }
    
    public async Task<IPagedResult<Organist>> GetAvailableOrganistsAsync(
        TRequest request,
        CancellationToken cancellationToken = default,
        ISpecification<Organist>? specification = null)
    {
        var query = context
            .Organists
            .AsQueryable();
        
        if (specification != null)
            query = specification.Apply(query);
        
        var totalCount = await GetTotalCountAsync(query, cancellationToken);
        
        query = PagedAndSortedQuery(query, request);
        
        var results = await query.ToListAsync(cancellationToken);

        return new PagedResult<Organist>(results, totalCount);
    }
}