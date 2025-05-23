using System.Data;
using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Exceptions;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class OrganistService(IMapper mapper, 
    IOrganistRepository repository, 
    IUnitOfWork unitOfWork,
    ICepService cepService,
    IAddressRepository addressRepository,
    IPhoneRepository phoneRepository) 
    : CrudServiceBase<Organist, OrganistDto, OrganistCreateUpdateDto>(mapper, repository, unitOfWork),
        IOrganistService
{
    public List<Organist> GetByIds(List<long> organistIds, CancellationToken cancellationToken = default)
    { 
        var organists = repository.GetAllAsync(cancellationToken).Result
            .Where(x => organistIds.Contains(x.Id))
            .ToList();

        return organists;
    }

    public List<Organist> GetByCongregation(long congregationId, CancellationToken cancellationToken = default)
    { 
        return repository.GetByCongregation(congregationId);
    }

    public async Task<OrganistDto> CreateAsync(OrganistCreateUpdateDto dto, CancellationToken cancellationToken = default)
    {
        CepDto cep = null;
        Address address = null;
        Phone? phone = null;

        if (dto.Address != null
            && !string.IsNullOrEmpty(dto.Address.ZipCode))
        {
            cep = await cepService.GetCepByZipCodeAsync(dto.Address.ZipCode, true, cancellationToken);
        }
        
        if (cep == null)
            throw new NotFoundException(Messages.Format(Messages.NotFound, "Cep"));

        await using var transaction = await unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        try
        {
            if (cep != null)
            {
                address = await addressRepository.GetAddressByZipCodeAsync(cep.ZipCode, cancellationToken);
                if (address == null)
                {
                    address = new Address()
                    {
                        StreetNumber = dto.Address.StreetNumber,
                        CepId = cep.Id,
                        Complement = dto.Address.Complement
                    };
                    address = await addressRepository.CreateAsync(address, cancellationToken);
                    await unitOfWork.SaveChangesAsync(cancellationToken);
                }
            }
            
            if (!string.IsNullOrEmpty(dto.PhoneNumber))
            {
                phone = await phoneRepository.GetPhoneByNumberAsync(dto.PhoneNumber);
                if (phone == null)
                {
                    phone = new Phone()
                    {
                        Number = dto.PhoneNumber,
                        IsPrimary = true
                    };
                    phone = await phoneRepository.CreateAsync(phone, cancellationToken);
                    await unitOfWork.SaveChangesAsync(cancellationToken);
                }
                else
                    throw new BusinessException(Messages.Format(Messages.AlreadyExists, "Número de Telefone"));
                
            }

            var organist = new Organist()
            {
                FullName = dto.FullName,
                ShortName = dto.ShortName,
                AddressId = address?.Id,
                Level = dto.Level,
                Cpf = dto.Cpf,
                ServicesDaysOfWeek = dto.ServicesDaysOfWeek,
                Sequence = 1, //TODO: avaliar como será implementado o sequence das organistas,
                PhoneId = phone?.Id
            };
            
            organist = await repository.CreateAsync(organist, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            
            await transaction.CommitAsync();
            return mapper.Map<OrganistDto>(organist);
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}