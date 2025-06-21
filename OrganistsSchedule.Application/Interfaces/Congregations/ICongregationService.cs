using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces.Results;

namespace OrganistsSchedule.Application.Interfaces;

public interface ICongregationService : ICrudServiceBase<Congregation, 
    CongregationPagedAndSortedRequest>
{
    Task<Congregation> SetOrganistsAsync(
        long congregationId,
        List<CongregationOrganist> congregationOrganists,
        CancellationToken cancellationToken = default);

    Task<IPagedResult<CongregationOrganist>> GetOrganistsByCongregationAsync(
        long congregationId,
        CancellationToken cancellationToken = default);
    
    Task<IPagedResult<CongregationDto>> GetAllWithHolyServiceFlagAsync(
        CongregationPagedAndSortedRequest request, 
        CancellationToken cancellationToken = default);
}