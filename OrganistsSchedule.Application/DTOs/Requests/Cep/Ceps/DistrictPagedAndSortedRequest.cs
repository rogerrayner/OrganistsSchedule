using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.DTOs;

public class DistrictPagedAndSortedRequest: PagedAndSortedRequestDto, IPagedAndSortedRequest
{
    public long? CityId { get; set; }
    public string? District { get; set; }
}