using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class OrganistRepository(ApplicationDbContext context)
    : RepositoryBase<Organist>(context), IOrganistRepository
{
    protected override IQueryable<Organist> IncludeChildren(IQueryable<Organist> query)
    {
        return query
            .Include(x => x.Address)
            .ThenInclude(x => x.Cep)
            .Include(x => x.Emails)
            .Include(x => x.PhoneNumber);
    }
    
    public async Task<Organist?> GetByCpfAsync(string cpf, CancellationToken cancellationToken = default)
    {
        return await context.Organists
            .FirstOrDefaultAsync(x => x.Cpf == cpf, cancellationToken);
    }

    public async Task<IEnumerable<Organist>> GetByIdsAsync(List<long> organistIds, CancellationToken cancellationToken = default)
    {
        return await context.Organists
            .Where(x => organistIds.Contains(x.Id))
            .ToListAsync(cancellationToken);
    }
}