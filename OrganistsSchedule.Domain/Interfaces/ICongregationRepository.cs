using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces.Results;

namespace OrganistsSchedule.Domain.Interfaces;

public interface ICongregationRepository<TRequest>: IRepositoryBase<Congregation, TRequest>
    where TRequest : class, IPagedAndSortedRequest
{
    Task<IPagedResult<ICongregationWithHolyServiceFlag>> GetAllWithHolyServiceFlagAsync(
        TRequest request, CancellationToken cancellationToken,
        ISpecification<Congregation>? specification = null);
}