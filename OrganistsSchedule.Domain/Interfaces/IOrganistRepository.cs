using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Domain.Interfaces;

public interface IOrganistRepository: IRepositoryBase<Organist>
{ 
    Task<IEnumerable<Organist>> GetByIdsAsync(List<long> organistIds, CancellationToken cancellationToken = default);
}