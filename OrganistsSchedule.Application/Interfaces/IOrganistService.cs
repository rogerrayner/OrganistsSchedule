using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Interfaces;

public interface IOrganistService: ICrudServiceBase<Organist, OrganistDto, OrganistCreateUpdateDto>
{
    List<Organist> GetByIds(List<long> organistIds, CancellationToken cancellationToken = default);
    List<Organist> GetByCongregation(long congregationId, CancellationToken cancellationToken = default);
}