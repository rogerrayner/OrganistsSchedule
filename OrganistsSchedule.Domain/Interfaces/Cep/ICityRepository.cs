using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Domain.Interfaces;

public interface ICityRepository<TRequest>: IRepositoryBase<City, TRequest>
    where TRequest : class, IPagedAndSortedRequest
{
    Task<City?> GetByNameAsync(string name);
}