using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Interfaces;
using OrganistsSchedule.Domain.Interfaces.Results;
using OrganistsSchedule.Domain.Results;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class CongregationOrganistRepository<TRequest>(ApplicationDbContext context)
    : RepositoryBase<CongregationOrganist, TRequest>(context), ICongregationOrganistRepository<TRequest>
    where TRequest : class, IPagedAndSortedRequest
{
    public async Task<IPagedResult<CongregationOrganist>> GetByCongregationPagedAndSortedAsync(long congregationId, 
        CancellationToken cancellationToken = default)
    {
        var query = context.CongregationOrganists
            .Where(co => co.CongregationId == congregationId)
            .Include(x => x.Organist)
            .Include(x => x.Congregation);
        
        var result = await query.ToListAsync(cancellationToken);
        
        var totalCount = await query.CountAsync(cancellationToken);

        return new PagedResult<CongregationOrganist>(result, totalCount);
    }
    
    public async Task<IEnumerable<CongregationOrganist>> GetByCongregationAsync(long congregationId, 
        CancellationToken cancellationToken = default)
    {
        return context.CongregationOrganists
            .Where(co => co.CongregationId == congregationId)
            .Include(x => x.Organist)
            .Include(x => x.Congregation);
    }

    protected override IQueryable<CongregationOrganist> IncludeChildren(IQueryable<CongregationOrganist> query)
    {
        return query
            .Include(x => x.Organist)
            .Include(x => x.Congregation);
    }
}