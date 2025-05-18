using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class OrganistRepository(ApplicationDbContext context)
    : RepositoryBase<Organist>(context), IOrganistRepository
{
    public List<Organist> GetByCongregation(long congregationId, CancellationToken cancellationToken = default)
    {
        return context.Organists
            .Where(x => x.CongregationId == congregationId)
            .ToList();
    }
}