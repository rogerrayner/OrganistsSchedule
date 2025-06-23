using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;
using OrganistsSchedule.Domain.Interfaces.Results;
using OrganistsSchedule.Domain.Results;
using OrganistsSchedule.Infra.Data.Responses;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class CongregationRepository<TRequest>(ApplicationDbContext context)
    : RepositoryBase<Congregation, TRequest>(context), ICongregationRepository<TRequest>
    where TRequest : class, IPagedAndSortedRequest
{
    protected override IQueryable<Congregation> IncludeChildren(IQueryable<Congregation> query)
    {
        return query
            .Include(x => x.Address)
            .ThenInclude(x => x.Cep)
            .ThenInclude(x => x.City)
            .ThenInclude(x => x.Country)
            .Include(x => x.CongregationOrganists);
    }
    
    public async Task<IPagedResult<ICongregationWithHolyServiceFlag>> GetAllWithHolyServiceFlagAsync(
        TRequest request, CancellationToken cancellationToken,
        ISpecification<Congregation>? specification = null)
    {
        var baseQuery = context
            .Set<Congregation>()
            .AsQueryable();

        if (specification != null)
            baseQuery = specification.Apply(baseQuery);

        baseQuery = baseQuery
            .OrderBy(x => x.Name);

        var totalCount = await GetTotalCountAsync(baseQuery, cancellationToken);

        var idsQuery = baseQuery
            .Skip(request.SkipCount)
            .Take(request.PageSize)
            .Select(e => e.Id);

        var ids = await idsQuery.ToListAsync(cancellationToken);

        if (!ids.Any())
            return new PagedResult<ICongregationWithHolyServiceFlag>(
                new List<ICongregationWithHolyServiceFlag>(),
                0);

        var query = context
            .Set<Congregation>()
            .Where(e => ids.Contains(e.Id))
            .Include(x => x.Address)
            .ThenInclude(x => x.Cep)
            .ThenInclude(x => x.City)
            .ThenInclude(x => x.Country);

        var results = await query
            .Select(c => new CongregationWithHolyServiceFlag
            {
                Id = c.Id,
                Name = c.Name,
                RelatorioBrasCode = c.RelatorioBrasCode,
                Address = c.Address,
                HasYouthMeetings = c.HasYouthMeetings,
                HasGeneratedSchedule = context.Set<HolyService>().Any(h => h.CongregationId == c.Id),
                DaysOfService = c.DaysOfService
            })
            .ToListAsync(cancellationToken);
        
        results = results
            .OrderBy(r => ids.IndexOf(r.Id))
            .ToList();

        return new PagedResult<ICongregationWithHolyServiceFlag>(results, totalCount);
    }
}