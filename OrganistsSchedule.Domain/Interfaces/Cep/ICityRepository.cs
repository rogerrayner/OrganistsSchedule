using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Domain.Interfaces;

public interface ICityRepository: IRepositoryBase<City>
{
    Task<City?> GetByNameAsync(string name);
}