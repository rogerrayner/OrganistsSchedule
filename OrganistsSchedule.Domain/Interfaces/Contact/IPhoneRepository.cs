using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Domain.Interfaces;

public interface IPhoneRepository<TRequest>: IRepositoryBase<Phone, TRequest>
    where TRequest : class, IPagedAndSortedRequest
{
    Task<Phone?> GetPhoneByNumberAsync(string number, CancellationToken cancellationToken = default);
}