using OrganistsSchedule.Application.Interfaces;

namespace OrganistsSchedule.Application.Services.Requests;

public class PagedAndSortedResultRequestDto: IPagedAndSortedResultRequest
{
    public int MaxCount { get; set; }
    public int SkipCount { get; set; }
    public string? Sorting { get; set; }
}