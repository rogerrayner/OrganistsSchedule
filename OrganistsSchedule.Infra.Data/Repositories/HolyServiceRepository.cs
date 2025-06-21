using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class HolyServiceRepository<TRequest>(ApplicationDbContext context)
    : RepositoryBase<HolyService, TRequest>(context), IHolyServiceRepository<TRequest>
    where TRequest : class, IPagedAndSortedRequest
{
    public async Task<IEnumerable<HolyService>> GetHolyServicesByCongregationAsync(long congregationId, CancellationToken cancellationToken)
    {
        return await context.Set<HolyService>()
            .Where(x => x.Congregation.Id == congregationId)
            .Include(x => x.Organist)
            .Include(x => x.Congregation)
            .ToListAsync(cancellationToken);
    }

    protected override IQueryable<HolyService> IncludeChildren(IQueryable<HolyService> query)
    {
        return query
            .Include(x => x.Organist)
            .Include(x => x.Congregation);
    }
}