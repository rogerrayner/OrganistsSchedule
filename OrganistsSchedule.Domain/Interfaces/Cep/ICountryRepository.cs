using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Domain.Interfaces;

public interface ICountryRepository: IRepositoryBase<Country>
{
    Task<Country?> GetByNameAsync(string name);

}