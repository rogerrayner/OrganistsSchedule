namespace OrganistsSchedule.Domain.Interfaces;

public interface ICongregationOrganistRepository: IRepositoryBase<CongregationOrganist>
{
    Task<IEnumerable<CongregationOrganist>> GetByCongregationAsync(long congregationId,
        CancellationToken cancellationToken = default);
}