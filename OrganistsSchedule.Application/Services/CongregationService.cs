using System.Data;
using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;
using System.Linq;
using OrganistsSchedule.Domain.Exceptions;

namespace OrganistsSchedule.Application.Services;

public class CongregationService(IMapper mapper, 
    ICongregationRepository repository, 
    IOrganistRepository organistRepository, 
    IUnitOfWork unitOfWork,
    IAddressService addressService)
    : CrudServiceBase<Congregation, 
            CongregationDto, 
            CongregationPagedAndSortedRequest,
            CongregationCreateRequestDto, 
            CongregationUpdateRequestDto>(mapper, repository, unitOfWork),
        ICongregationService
{
    public async Task<CongregationDto> SetOrganistsAsync(long congregationId, List<long> organistIds, CancellationToken cancellationToken = default)
    {
        await using var transaction = 
            await unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        try
        {
            var congregation = await repository.GetByIdAsync(congregationId, cancellationToken);
            if (congregation == null)
                throw new NotFoundException(Messages.Format(Messages.NotFound, "Congregação"));

            var organists = await organistRepository.GetByIdsAsync(organistIds, cancellationToken);

            foreach (var organist in organists)
            {
                organist.CongregationId = congregation.Id;
                organist.Congregation = congregation;
                await organistRepository.UpdateAsync(organist, cancellationToken);
            }

            congregation.Organists = mapper.Map<ICollection<Organist>?>(organists);
            
            await repository.UpdateAsync(congregation, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            
            await transaction.CommitAsync(cancellationToken);
            
            return await Task.FromResult(mapper.Map<CongregationDto>(congregation));
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }

    public async Task<CongregationDto> CreateAsync(CongregationCreateRequestDto dto, CancellationToken cancellationToken = default)
    {
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

            var congregation = new Congregation()
            {
                AddressId = address?.Id,
                Name = dto.Name,
                DaysOfService = dto.DaysOfService,
                HasYouthMeetings = dto.HasYouthMeetings
            };
            
            congregation = await repository.CreateAsync(congregation, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            
            var response = mapper.Map<CongregationDto>(congregation);
            return response;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}