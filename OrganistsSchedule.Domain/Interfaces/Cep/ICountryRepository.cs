using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Domain.Interfaces;

public interface ICountryRepository<TRequest>: IRepositoryBase<Country,TRequest>
    where TRequest : class, IPagedAndSortedRequest
{
    Task<Country?> GetByNameAsync(string name);

}