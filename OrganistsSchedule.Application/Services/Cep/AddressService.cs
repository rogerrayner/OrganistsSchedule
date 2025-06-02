using System.Data;
using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Exceptions;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class AddressService(IMapper mapper, 
    IAddressRepository repository, 
    ICepService cepService, 
    IUnitOfWork unitOfWork) 
    : CrudServiceBase<Address, 
            AddressDto,
            AddressPagedAndSortedRequest,
            AddressCreateUpdateDto>(mapper, repository, unitOfWork), 
        IAddressService
{
    public async Task<AddressDto> CreateAsync(AddressCreateUpdateDto dto, CancellationToken cancellationToken = default)
    {
        try
        {
            var cep = await cepService.GetCepByZipCodeAsync(dto.ZipCode, true);
            
            var address = new Address()
            {
                CepId = cep.Id,
                Complement = dto.Complement,
                StreetNumber = dto.StreetNumber
            };

            await repository.CreateAsync(address, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<AddressDto>(address);
        }
        catch (Exception e)
        {
            throw;
        }
        
    }

    public async Task<AddressDto> GetAddressByZipCodeAsync(string cep, CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAddressByZipCodeAsync(cep, cancellationToken);
        return mapper.Map<AddressDto>(entity);
    }

}