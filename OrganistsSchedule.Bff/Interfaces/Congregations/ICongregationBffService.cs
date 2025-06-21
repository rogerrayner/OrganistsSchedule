using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Bff.Interfaces;

public interface ICongregationBffService : ICrudBffServiceBase<Congregation, 
    CongregationDto, 
    CongregationPagedAndSortedRequest, 
    CongregationCreateRequestDto>
{
    Task<CongregationDto> SetOrganistsAsync(
        long congregationId,
        List<OrganistDaysDto> organistsDays,
        CancellationToken cancellationToken = default);

    Task<PagedResultDto<CongregationOrganistsDto>> GetOrganistsByCongregationAsync(long congregationId,
        CancellationToken cancellationToken = default);
    
    Task<PagedResultDto<CongregationDto>> GetAllWithHolyServiceFlagAsync(
        CongregationPagedAndSortedRequest request, CancellationToken cancellationToken);
}