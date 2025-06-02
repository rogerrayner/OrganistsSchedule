using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Domain.Interfaces;

public interface IHolyServiceRepository: IRepositoryBase<HolyService>
{
    
    Task<IEnumerable<HolyService>> GetHolyServicesByCongregationAsync(long congregationId, CancellationToken cancellationToken);
    
}