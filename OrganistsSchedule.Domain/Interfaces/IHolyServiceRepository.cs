using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Domain.Interfaces;

public interface IHolyServiceRepository<TRequest>: IRepositoryBase<HolyService, TRequest>
    where TRequest : class, IPagedAndSortedRequest
{
    
    Task<IEnumerable<HolyService>> GetHolyServicesByCongregationAsync(long congregationId, CancellationToken cancellationToken);
    
}