using AutoMapper;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Specifications;
using OrganistsSchedule.Bff.Interfaces;

namespace OrganistsSchedule.Bff.Services;

public class CongregationBffService(IMapper mapper, 
    ICongregationService service,
    ICepBffService cepBffService)
    : CrudBffServiceBase<Congregation, 
            CongregationDto,
            CongregationPagedAndSortedRequest,
            CongregationCreateRequestDto, 
            CongregationCreateRequestDto>(mapper, service),
        ICongregationBffService
{
    public override Task<PagedResultDto<CongregationDto>> GetAllAsync(CongregationPagedAndSortedRequest request, CancellationToken cancellationToken,
        ISpecification<Congregation>? specification = null)
    {
        try
        {
            specification = new CongregationSpecification(request);
            return base.GetAllAsync(request, cancellationToken, specification);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public override async Task<CongregationDto> CreateAsync(CongregationCreateRequestDto dto, CancellationToken cancellationToken = default)
    {
        try
        {
            if (dto.Address != null 
                && dto.Address.Cep != null
                && !string.IsNullOrEmpty(dto.Address.Cep.ZipCode))
            {
                dto.Address.Cep = await cepBffService.GetCepByZipCodeAsync(dto.Address.Cep.ZipCode, true, cancellationToken);
                
            }
            
            return await base.CreateAsync(dto, cancellationToken);
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<CongregationDto> SetOrganistsAsync(
        long congregationId,
        List<OrganistDaysDto> organistsDays,
        CancellationToken cancellationToken = default)
    {
        var congregationOrganist = mapper.Map<List<CongregationOrganist>>(organistsDays);
        var entity = await service.SetOrganistsAsync(congregationId, congregationOrganist, cancellationToken);
        return mapper.Map<CongregationDto>(entity);
    }
    
    public async Task<PagedResultDto<CongregationOrganistsDto>> GetOrganistsByCongregationAsync(
        long congregationId,
        CancellationToken cancellationToken = default)
    {
        var result = await service.GetOrganistsByCongregationAsync(congregationId, cancellationToken);
        
        if (result.Items == null)
            return new PagedResultDto<CongregationOrganistsDto>(new List<CongregationOrganistsDto>(), 0);
        
        var congregationOrganists = result.Items;
        var totalCount = result.TotalCount;
        
        return new PagedResultDto<CongregationOrganistsDto>(
            mapper.Map<IEnumerable<CongregationOrganistsDto>>(congregationOrganists),
            totalCount);
    }

    public async Task<PagedResultDto<CongregationDto>> GetAllWithHolyServiceFlagAsync(CongregationPagedAndSortedRequest request, CancellationToken cancellationToken)
    {
        var result = await service
            .GetAllWithHolyServiceFlagAsync(request, cancellationToken);

        return new PagedResultDto<CongregationDto>(
            mapper.Map<IEnumerable<CongregationDto>>(result.Items),
            result.TotalCount
        );

    }
}