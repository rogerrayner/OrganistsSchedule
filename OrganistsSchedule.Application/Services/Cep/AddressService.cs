using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class AddressService(IMapper mapper, IAddressRepository repository, ICepService cepService, IUnitOfWork unitOfWork) 
    : CrudServiceBase<Address, AddressDto, AddressCreateUpdateDto>(mapper, repository, unitOfWork), 
        IAddressService
{
    public async Task<AddressDto> CreateAsync(AddressCreateUpdateDto dto, CancellationToken cancellationToken = default)
    {
        var cep = await cepService.GetCepByZipCodeAsync(dto.ZipCode, true);
        if (cep == null)
        {
            throw new Exception("Cep not found");
        }

        var address = new Address()
        {
            CepId = cep.Id,
            Complement = dto.Complement,
            StreetNumber = dto.StreetNumber
        };

        await repository.CreateAsync(address, cancellationToken);
        unitOfWork.SaveChangesAsync(cancellationToken);
        
        return mapper.Map<AddressDto>(address);
    }
}