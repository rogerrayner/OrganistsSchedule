using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Domain.Interfaces;

public interface IPhoneRepository: IRepositoryBase<Phone>
{
    Task<Phone?> GetPhoneByNumberAsync(string number, CancellationToken cancellationToken = default);
}