using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class CongregationRepository(ApplicationDbContext context)
    : RepositoryBase<Congregation>(context), ICongregationRepository
{
    public override IQueryable<Congregation> CreateFilteredQuery()
    {
        return context.Set<Congregation>()
            .Include(x => x.Organists)!
            .ThenInclude(x => x.Address);
    }
}