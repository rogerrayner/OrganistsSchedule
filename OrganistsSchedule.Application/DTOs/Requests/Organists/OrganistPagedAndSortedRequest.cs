using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.DTOs;

public class OrganistPagedAndSortedRequest: PagedAndSortedRequestDto, IPagedAndSortedRequest
{
    public string? FullName { get; set; }
    public string? ShortName { get; set; }
    
    public string? Name { get; set; }
    public string? District { get; set; }
    public long? CityId { get; set; }
    public string? State { get; set; }
    public long CongregationId { get; set; }
}