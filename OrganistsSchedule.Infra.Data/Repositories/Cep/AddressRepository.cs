using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class AddressRepository(ApplicationDbContext context)
    : RepositoryBase<Address>(context), IAddressRepository
{
    protected override IQueryable<Address> IncludeChildren(IQueryable<Address> query)
    {
        return query
            .Include(x => x.Cep)
            .ThenInclude(x => x.City)
            .ThenInclude(x => x.Country);
    }
}