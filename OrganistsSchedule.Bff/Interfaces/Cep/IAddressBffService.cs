using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Bff.Interfaces;

public interface IAddressBffService: ICrudBffServiceBase<Address, 
    AddressDto, 
    AddressPagedAndSortedRequest,
    AddressCreateUpdateDto>  {
    Task<AddressDto> GetAddressByZipCodeAsync(string cep, CancellationToken cancellationToken = default);
}