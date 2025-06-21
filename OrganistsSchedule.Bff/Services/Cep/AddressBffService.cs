using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Bff.Interfaces;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Bff.Services;

public class AddressBffService (IMapper mapper, IAddressService service)
    : CrudBffServiceBase<Address, 
                         AddressDto, 
                         AddressPagedAndSortedRequest,
                         AddressCreateUpdateDto>(mapper, service), 
        IAddressBffService
{


    public async Task<AddressDto> GetAddressByZipCodeAsync(string cep, CancellationToken cancellationToken = default)
    {
        var entity = await service.GetAddressByZipCodeAsync(cep, cancellationToken);
        return mapper.Map<AddressDto>(entity);
    }
}