using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Bff.Interfaces;

public interface IOrganistBffService: ICrudBffServiceBase<Organist, 
    OrganistDto, 
    OrganistPagedAndSortedRequest, 
    OrganistCreateDto, 
    OrganistUpdateDto>
{
    Task<PagedResultDto<OrganistDto>> GetAvailableOrganistsAsync(
        long congregationId,
        OrganistPagedAndSortedRequest request,
        CancellationToken cancellationToken = default,
        ISpecification<Organist>? specification = null);
}