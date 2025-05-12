using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Interfaces;

public interface ICongregationService : ICrudServiceBase<CongregationDto, Congregation>
{
    Task<CongregationDto> SetOrganistsAsync(long congregationId, List<long> organistIds);
}