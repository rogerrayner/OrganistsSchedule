using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Domain.Interfaces;

public interface IAddressRepository: IRepositoryBase<Address>
{
    Task<Address?> GetAddressByZipCodeAsync(string zipCode, CancellationToken cancellationToken = default);
    Task<Address?> AddressAlreadyExistsAsync(string zipCode, long streetNumber, string complement, CancellationToken cancellationToken = default);
}