using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class CongregationRepository(ApplicationDbContext context)
    : RepositoryBase<Congregation>(context), ICongregationRepository
{
    protected override IQueryable<Congregation> IncludeChildren(IQueryable<Congregation> query)
    {
        return query
            .Include(x => x.Address)
            .ThenInclude(x => x.Cep)
            .ThenInclude(x => x.City)
            .ThenInclude(x => x.Country);
    }
}