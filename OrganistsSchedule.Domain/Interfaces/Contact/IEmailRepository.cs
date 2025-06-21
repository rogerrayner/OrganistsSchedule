using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Domain.Interfaces;

public interface IEmailRepository<TRequest>: IRepositoryBase<Email, TRequest>
    where TRequest : class, IPagedAndSortedRequest
{
    Task<Email> GetEmailByEmailAddressAsync(string email, CancellationToken cancellationToken = default);
}