using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.Services.Requests;

namespace OrganistsSchedule.Application.DTOs;

public class OrganistPagedAndSortedRequest: PagedAndSortedRequestDto, IOrganistPagedAndSortedRequest
{
    public string? FullName { get; set; }
    public string? ShortName { get; set; }
}