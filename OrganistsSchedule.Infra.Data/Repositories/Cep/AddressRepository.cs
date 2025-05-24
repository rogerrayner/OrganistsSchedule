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

    public async Task<Address?> GetAddressByZipCodeAsync(string zipCode, CancellationToken cancellationToken = default)
    {
        return await context
            .Set<Address>()
            .Include(x => x.Cep)
            .FirstOrDefaultAsync(x => x.Cep.ZipCode == zipCode, cancellationToken);
    }

    public async Task<Address?> AddressAlreadyExistsAsync(string zipCode, long streetNumber, string complement,
        CancellationToken cancellationToken = default)
    {
        return await context
            .Set<Address>()
            .Include(x => x.Cep)
            .FirstOrDefaultAsync(x => 
                x.Cep.ZipCode == zipCode
                && x.StreetNumber == streetNumber
                && x.Complement == complement, cancellationToken);
    }
}