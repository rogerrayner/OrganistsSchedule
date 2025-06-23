using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Bff.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Bff.Services;

public class OrganistBffService(IMapper mapper, 
    IOrganistService service) 
    : CrudBffServiceBase<Organist, 
            OrganistDto, 
            OrganistPagedAndSortedRequest,
            OrganistCreateDto, 
            OrganistUpdateDto>(mapper, service),
        IOrganistBffService
{
    public async Task<PagedResultDto<OrganistDto>> GetAvailableOrganistsAsync(
        long congregationId,
        OrganistPagedAndSortedRequest request,
        CancellationToken cancellationToken = default,
        ISpecification<Organist>? specification = null)
    {
        var result = await service.GetAvailableOrganistsAsync(congregationId, request, cancellationToken, specification);

        return new PagedResultDto<OrganistDto>(
            mapper.Map<IEnumerable<OrganistDto>>(result.Items),
            result.TotalCount
            );
    }
}
