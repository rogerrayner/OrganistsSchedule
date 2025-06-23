using System.Data;
using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;
using OrganistsSchedule.Application.Specifications;
using OrganistsSchedule.Domain.Exceptions;
using OrganistsSchedule.Domain.Interfaces.Results;
using OrganistsSchedule.Domain.Results;
using OrganistsSchedule.Domain.Utils;

namespace OrganistsSchedule.Application.Services;

public class CongregationService(
    ICongregationRepository<CongregationPagedAndSortedRequest> repository, 
    IOrganistRepository<OrganistPagedAndSortedRequest> organistRepository,
    ICongregationOrganistRepository<CongregationPagedAndSortedRequest> congregationOrganistRepository,
    IUnitOfWork unitOfWork,
    IAddressService addressService,
    ICepService cepService,
    IMapper mapper)
    : CrudServiceBase<Congregation, 
            CongregationPagedAndSortedRequest>(repository, unitOfWork),
        ICongregationService
{
    public override Task<IPagedResult<Congregation>> GetAllAsync(CongregationPagedAndSortedRequest request, 
        CancellationToken cancellationToken,
        ISpecification<Congregation>? specification = null)
    {
        specification = new CongregationSpecification(request);
        return base.GetAllAsync(request, cancellationToken, specification);
    }

    public async Task<Congregation> SetOrganistsAsync(
        long congregationId,
        List<CongregationOrganist> congregationOrganists,
        CancellationToken cancellationToken = default)
    {
        await using var transaction = await unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        try
        {
            var congregation = await repository.GetByIdAsync(congregationId, cancellationToken);
            if (congregation == null)
                ErrorHandler.ThrowNotFoundException(Messages.NotFound, "Congregação");
            
            congregation.CongregationOrganists = congregationOrganists;
            
            await repository.UpdateAsync(congregation, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return congregation;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
    
    public async Task<IPagedResult<CongregationOrganist>> GetOrganistsByCongregationPagedAndSortedAsync(
        long congregationId,
        CancellationToken cancellationToken = default)
    {
        var result = 
            await congregationOrganistRepository.GetByCongregationPagedAndSortedAsync(
                congregationId, 
                cancellationToken);
        
        if (result == null || !result.Items.Any())
            return new PagedResult<CongregationOrganist>(new List<CongregationOrganist>(), 0);
    
        var congregations = result
            .Items
            .Select(o => new CongregationOrganist
            {
                OrganistId = o.Organist.Id,
                Organist = o.Organist,
                Congregation = o.Congregation,
                CongregationId = o.Congregation.Id,
                Sequence = o.Sequence,
                OrganistServiceDaysOfWeek = o.OrganistServiceDaysOfWeek
            }).ToList();
        
        var totalCount = result.TotalCount;
        
        return new PagedResult<CongregationOrganist>(congregations, totalCount);
    }
    
    public async Task<IEnumerable<CongregationOrganist>> GetOrganistsByCongregationAsync(
        long congregationId,
        CancellationToken cancellationToken = default)
    {
        return await congregationOrganistRepository.GetByCongregationAsync(
                congregationId, 
                cancellationToken);
    }

    public async Task<IPagedResult<CongregationDto>> GetAllWithHolyServiceFlagAsync(CongregationPagedAndSortedRequest request, 
        CancellationToken cancellationToken = default)
    {
        var specification = new CongregationSpecification(request);
        var results = await repository
            .GetAllWithHolyServiceFlagAsync(request, cancellationToken, specification);

        if (results == null || !results.Items.Any())
            return new PagedResult<CongregationDto>(new List<CongregationDto>(), 0);
        
        var congregations = results
            .Items.Select(c => new CongregationDto
            {
                Id = c.Id,
                Name = c.Name,
                RelatorioBrasCode = c.RelatorioBrasCode,
                Address = mapper.Map<AddressDto>(c.Address),
                HasYouthMeetings = c.HasYouthMeetings,
                HasGeneratedSchedule = c.HasGeneratedSchedule,
                DaysOfService = c.DaysOfService
            });
        
        var totalCount = results.TotalCount;
        
        return new PagedResult<CongregationDto>(congregations, totalCount);
    }

    public override async Task<Congregation> UpdateAsync(Congregation entity, long id, CancellationToken cancellationToken = default)
    {
        try
        {
            var congregation = await repository.GetByIdAsync(id, cancellationToken);
            
            if (congregation == null)
                ErrorHandler.ThrowNotFoundException(Messages.NotFound, "Congregação");
            
            congregation.Name = entity.Name;
            congregation.RelatorioBrasCode = entity.RelatorioBrasCode;
            congregation.DaysOfService = entity.DaysOfService;
            congregation.HasYouthMeetings = entity.HasYouthMeetings;

            if (entity.Address != null)
            {
                try
                {
                    await addressService.DeleteAsync(congregation.Address.Id, cancellationToken);
                    await unitOfWork.SaveChangesAsync(cancellationToken);
                    
                    congregation.Address = await addressService.CreateAsync(entity.Address, cancellationToken);   
                } catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw new NotFoundException("Endereço não encontrado");
                }
            }
            
            congregation = await base.UpdateAsync(congregation, id, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return congregation;
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public override async Task<Congregation> CreateAsync(
        Congregation entity, 
        CancellationToken cancellationToken = default)
    {
        try
        {
            if (entity.Address != null)
            {
                entity.Address = await addressService.CreateAsync(entity.Address, cancellationToken);
            }
            
            entity = await repository.CreateAsync(entity, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}