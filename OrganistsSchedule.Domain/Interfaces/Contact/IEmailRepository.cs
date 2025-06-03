using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Domain.Interfaces;

public interface IEmailRepository: IRepositoryBase<Email>
{
    Task<Email> GetEmailByEmailAddressAsync(string email, CancellationToken cancellationToken = default);
}