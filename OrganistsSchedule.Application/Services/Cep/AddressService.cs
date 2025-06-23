using System.Data;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Exceptions;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class AddressService(
    IAddressRepository<AddressPagedAndSortedRequest> repository,
    ICepService cepService,
    IUnitOfWork unitOfWork)
    : CrudServiceBase<Address, AddressPagedAndSortedRequest>(repository, unitOfWork),
        IAddressService
{
    
    public async Task<Address> GetAddressByZipCodeAsync(string cep, CancellationToken cancellationToken = default)
    {
        return await repository.GetAddressByZipCodeAsync(cep, cancellationToken);
    }

    public override async Task<Address> CreateAsync(Address entity, CancellationToken cancellationToken = default)
    {
        return await CreateOrUpdateAddressAsync(entity, 0, cancellationToken);
    }

    public override async Task<Address> UpdateAsync(Address entity, long id, CancellationToken cancellationToken = default)
    {
        return await CreateOrUpdateAddressAsync(entity, id, cancellationToken);
    }

    private async Task<Address> CreateOrUpdateAddressAsync(
        Address entity,
        long id = 0,
        CancellationToken cancellationToken = default)
    {
        await using var uow = await unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        try
        {
            var cep = await cepService.GetCepByZipCodeAsync(entity.Cep.ZipCode, true, cancellationToken);
            if (cep == null && !string.IsNullOrWhiteSpace(entity.Cep.ZipCode))
            {
                cep = new Cep()
                {
                    ZipCode = entity.Cep.ZipCode,
                    Street = "",
                    District = "",
                    State = ""
                };
                
                cep = await cepService.CreateAsync(cep, cancellationToken);
            }
            
            Address address;
            
            if (id > 0)
            {
                address = await repository.GetByIdAsync(id, cancellationToken)
                          ?? throw new NotFoundException("Endereço não encontrado");
                address.Cep = cep;
                address.StreetNumber = entity.StreetNumber;
                address.Complement = entity.Complement;
                await repository.UpdateAsync(address, cancellationToken);
            }
            else
            {
                address = new Address
                {
                    Id = 0,
                    Cep = cep,
                    StreetNumber = entity.StreetNumber,
                    Complement = entity.Complement
                };
                await repository.CreateAsync(address, cancellationToken);
            }
            
            await unitOfWork.SaveChangesAsync(cancellationToken);
            await uow.CommitAsync(cancellationToken);
            return address;
        } 
        catch (Exception e) {
            Console.WriteLine(e);
            await uow.RollbackAsync(cancellationToken);
            throw;
        }
    }
}