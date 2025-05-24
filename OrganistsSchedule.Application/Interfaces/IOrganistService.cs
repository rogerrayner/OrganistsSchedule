using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Interfaces;

public interface IOrganistService: ICrudServiceBase<Organist, OrganistDto, OrganistCreateDto, OrganistUpdateDto>
{
    Task<List<Organist>> GetByIdsAsync(List<long> organistIds, CancellationToken cancellationToken = default);
    Task<List<Organist>> GetByCongregationAsync(long congregationId, CancellationToken cancellationToken = default);
}