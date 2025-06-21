using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;
using OrganistsSchedule.Domain.Interfaces.Results;

namespace OrganistsSchedule.Application.Interfaces;

public interface IOrganistService: ICrudServiceBase<Organist, OrganistPagedAndSortedRequest>
{
    Task<IEnumerable<Organist>> GetByIdsAsync(List<long> organistIds, 
        CancellationToken cancellationToken = default);

    Task<IPagedResult<Organist>> GetAvailableOrganistsAsync(
        long congregationId,
        OrganistPagedAndSortedRequest request,
        CancellationToken cancellationToken = default,
        ISpecification<Organist>? specification = null);
}