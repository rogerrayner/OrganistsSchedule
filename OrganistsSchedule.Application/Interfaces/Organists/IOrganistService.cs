using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Interfaces;

public interface IOrganistService: ICrudServiceBase<Organist, 
    OrganistDto, 
    OrganistPagedAndSortedRequest, 
    OrganistCreateDto, 
    OrganistUpdateDto>
{
    Task<IEnumerable<Organist>> GetByIdsAsync(List<long> organistIds, CancellationToken cancellationToken = default);
}