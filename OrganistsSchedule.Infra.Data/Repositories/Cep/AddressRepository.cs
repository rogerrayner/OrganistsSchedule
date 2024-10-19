using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class AddressRepository(ApplicationDbContext context)
    : RepositoryBase<Address>(context), IAddressRepository
{
    public override IQueryable<Address> CreateFilteredQuery()
    {
        var query = context.Set<Address>()
            .Include(x => x.Cep);

        return query;
    }
}