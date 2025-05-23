using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Domain.Interfaces;

public interface IAddressRepository: IRepositoryBase<Address>
{
    Task<Address?> GetAddressByZipCodeAsync(string zipCode, CancellationToken cancellationToken = default);
}