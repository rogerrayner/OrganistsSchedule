using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class CongregationOrganistRepository(ApplicationDbContext context)
    : RepositoryBase<CongregationOrganist>(context), ICongregationOrganistRepository
{
    public async Task<IEnumerable<CongregationOrganist>> GetByCongregationAsync(long congregationId, 
        CancellationToken cancellationToken = default)
    {
        return await context.CongregationOrganists
            .Where(co => co.CongregationId == congregationId)
            .ToListAsync(cancellationToken);
    }
}