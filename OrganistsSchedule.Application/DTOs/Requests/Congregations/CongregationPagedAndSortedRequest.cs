using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.DTOs;

public class CongregationPagedAndSortedRequest: PagedAndSortedRequestDto, IPagedAndSortedRequest
{
    public string? RelatorioBrasCode { get; set; }
    public string? Name { get; set; }
}