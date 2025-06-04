using System.Data;
using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;
using System.Linq;
using OrganistsSchedule.Application.Specifications;
using OrganistsSchedule.Domain.Exceptions;

namespace OrganistsSchedule.Application.Services;

public class CongregationService(IMapper mapper, 
    ICongregationRepository repository, 
    IOrganistRepository organistRepository,
    ICongregationOrganistRepository congregationOrganistRepository,
    IUnitOfWork unitOfWork,
    IAddressService addressService)
    : CrudServiceBase<Congregation, 
            CongregationDto, 
            CongregationPagedAndSortedRequest,
            CongregationCreateRequestDto, 
            CongregationCreateRequestDto>(mapper, repository, unitOfWork),
        ICongregationService
{
    public override Task<PagedResultDto<CongregationDto>> GetAllAsync(CongregationPagedAndSortedRequest request, CancellationToken cancellationToken,
        ISpecification<Congregation>? specification = null)
    {
        specification = new CongregationSpecification(request);
        return base.GetAllAsync(request, cancellationToken, specification);
    }

    public async Task<CongregationDto> SetOrganistsAsync(
        long congregationId,
        List<OrganistDaysDto> organistsDays,
        CancellationToken cancellationToken = default)
    {
        await using var transaction = await unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        try
        {
            var congregation = await repository.GetByIdAsync(congregationId, cancellationToken);
            if (congregation == null)
                throw new NotFoundException(Messages.Format(Messages.NotFound, "Congregação"));

            var organistIds = organistsDays.Select(x => x.OrganistId).ToList();
            var organists = await organistRepository.GetByIdsAsync(organistIds, cancellationToken);

            foreach (var organistDays in organistsDays)
            {
                // Se não vier dias, usa os dias da congregation
                var days = (organistDays.DaysOfService == null || !organistDays.DaysOfService.Any())
                    ? congregation.DaysOfService.ToArray()
                    : organistDays.DaysOfService;

                var existing = congregation.CongregationOrganists
                    .FirstOrDefault(co => co.OrganistId == organistDays.OrganistId);

                if (existing != null)
                {
                    existing.OrganistServiceDaysOfWeek = days;
                }
                else
                {
                    var organist = organists.First(o => o.Id == organistDays.OrganistId);
                    congregation.CongregationOrganists.Add(new CongregationOrganist
                    {
                        CongregationId = congregation.Id,
                        OrganistId = organist.Id,
                        Organist = organist,
                        Congregation = congregation,
                        OrganistServiceDaysOfWeek = days
                    });
                }
            }

            await repository.UpdateAsync(congregation, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return mapper.Map<CongregationDto>(congregation);
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
    
    public async Task<List<CongregationOrganistsDto>> GetCongregationOrganistsAsync(long congregationId,
        CancellationToken cancellationToken = default)
    {
        var congregationOrganists = await congregationOrganistRepository.GetByCongregationAsync(congregationId, cancellationToken);

        return congregationOrganists.Select(o => new CongregationOrganistsDto
        {
            OrganistId = o.Organist.Id,
            CongregationId = o.Congregation.Id,
            Level = o.Organist.Level,
            Sequence = o.Sequence,
            OrganistServiceDaysOfWeek = o.OrganistServiceDaysOfWeek
        }).ToList();
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
                RelatorioBrasCode = dto.RelatorioBrasCode,
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