using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Interfaces;

public interface ICongregationService : ICrudServiceBase<Congregation, 
    CongregationDto, 
    CongregationPagedAndSortedRequest, 
    CongregationCreateRequestDto, 
    CongregationUpdateRequestDto>
{
    Task<CongregationDto> SetOrganistsAsync(
        long congregationId,
        List<OrganistDaysDto> organistsDays,
        CancellationToken cancellationToken = default);

    Task<List<CongregationOrganistsDto>> GetCongregationOrganistsAsync(long congregationId,
        CancellationToken cancellationToken = default);
}