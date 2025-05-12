using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Domain.Interfaces;

public interface IHolyServiceRepository: IRepositoryBase<HolyService>
{
    
    Task<ICollection<HolyService>> GetHolyServicesByCongregationAsync(long congregationId);
    
}