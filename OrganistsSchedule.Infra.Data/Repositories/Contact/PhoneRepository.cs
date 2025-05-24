using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class PhoneRepository(ApplicationDbContext context) 
    : RepositoryBase<Phone>(context), IPhoneRepository
{
    public Task<Phone?> GetPhoneByNumberAsync(string number, CancellationToken cancellationToken = default)
    {
        return context.Phones
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Number == number);
    }
}