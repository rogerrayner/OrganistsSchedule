using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Domain.Interfaces;

public interface IOrganistRepository: IRepositoryBase<Organist>
{
    Task<List<Organist>> GetByCongregationAsync(long congregationId, CancellationToken cancellationToken = default);
    Task<Organist?> GetByCpfAsync(string cpf, CancellationToken cancellationToken = default);
    Task<IEnumerable<Organist>> GetByIdsAsync(List<long> organistIds, CancellationToken cancellationToken = default);
}