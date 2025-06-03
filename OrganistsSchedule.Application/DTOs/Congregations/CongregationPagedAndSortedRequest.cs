using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.Services.Requests;

namespace OrganistsSchedule.Application.DTOs;

public class CongregationPagedAndSortedRequest: PagedAndSortedRequestDto, ICongregationPagedAndSortedRequest
{
    public string? RelatorioBrasCode { get; set; }
    public string? Name { get; set; }
}