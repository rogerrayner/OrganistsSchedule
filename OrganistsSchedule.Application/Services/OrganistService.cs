using System.Data;
using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.Specifications;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Exceptions;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class OrganistService(IMapper mapper, 
    IOrganistRepository repository, 
    IUnitOfWork unitOfWork,
    ICepService cepService,
    IAddressService addressService,
    IPhoneRepository phoneRepository,
    IEmailRepository emailRepository) 
    : CrudServiceBase<Organist, 
            OrganistDto, 
            OrganistPagedAndSortedRequest,
            OrganistCreateDto, 
            OrganistUpdateDto>(mapper, repository, unitOfWork),
        IOrganistService
{
    public override Task<PagedResultDto<OrganistDto>> GetAllAsync(OrganistPagedAndSortedRequest request, CancellationToken cancellationToken,
        ISpecification<Organist>? specification = null)
    {
        specification = new OrganistSpecification(request);
        return base.GetAllAsync(request, cancellationToken, specification);
    }

    public async Task<IEnumerable<Organist>> GetByIdsAsync(List<long> organistIds, CancellationToken cancellationToken = default)
    {
        var organists = await repository.GetByIdsAsync(organistIds, cancellationToken);
        return organists.ToList();
    }

    public async Task<OrganistDto> CreateAsync(OrganistCreateDto dto, CancellationToken cancellationToken = default)
    {
        Phone? phone = null;
        Email? email = null;
        Address address = null;
        
        await using var transaction = await unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        try
        {
            if (dto.Address != null)
            {
                var addressCreateDto = new AddressCreateUpdateDto()
                {
                    ZipCode = dto.Address.ZipCode,
                    StreetNumber = dto.Address.StreetNumber,
                    Complement = dto.Address.Complement
                };
                var addressDto = await addressService.CreateAsync(addressCreateDto, cancellationToken);
                address = mapper.Map<Address>(addressDto);
            }

            if (!string.IsNullOrEmpty(dto.PhoneNumber))
            {
                phone = await phoneRepository.GetPhoneByNumberAsync(dto.PhoneNumber, cancellationToken);
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
            
            if (!string.IsNullOrEmpty(dto.Email))
            {
                email = await emailRepository.GetEmailByEmailAddressAsync(dto.Email, cancellationToken);
                if (email == null)
                {
                    email = new Email()
                    {
                        EmailAddress = dto.Email,
                        IsPrimary = true
                    };
                    email = await emailRepository.CreateAsync(email, cancellationToken);
                    await unitOfWork.SaveChangesAsync(cancellationToken);
                }
                else
                    throw new BusinessException(Messages.Format(Messages.AlreadyExists, "E-mail"));
                
            }

            var organist = new Organist()
            {
                FullName = dto.FullName,
                ShortName = dto.ShortName,
                AddressId = address?.Id,
                Level = dto.Level,
                PhoneId = phone?.Id
            };
            
            //TODO: Implement validação com full + short name
            
            organist = await repository.CreateAsync(organist, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            
            return mapper.Map<OrganistDto>(organist);
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}