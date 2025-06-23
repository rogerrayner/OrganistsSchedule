using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Interfaces;

public interface IAddressService: ICrudServiceBase<Address, AddressPagedAndSortedRequest>
{
    Task<Address> GetAddressByZipCodeAsync(string cep, CancellationToken cancellationToken = default);
}