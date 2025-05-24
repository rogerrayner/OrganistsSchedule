using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Interfaces;

public interface IAddressService: ICrudServiceBase<Address, AddressDto, AddressCreateUpdateDto> {
    
    Task<AddressDto> GetAddressByZipCodeAsync(string cep, CancellationToken cancellationToken = default);
    
}