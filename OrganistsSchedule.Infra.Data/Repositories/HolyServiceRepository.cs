using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class HolyServiceRepository(ApplicationDbContext context)
    : RepositoryBase<HolyService>(context), IHolyServiceRepository
{
    public async Task<ICollection<HolyService>> GetHolyServicesByCongregationAsync(long congregationId)
    { 
        return await context.Set<HolyService>()
            .Where(x => x.Congregation.Id == congregationId)
            .ToListAsync();
    }
}