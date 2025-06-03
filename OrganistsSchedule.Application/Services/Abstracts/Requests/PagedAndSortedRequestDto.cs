using OrganistsSchedule.Application.Interfaces;

namespace OrganistsSchedule.Application.Services.Requests;

public class PagedAndSortedRequestDto: IPagedAndSortedRequest
{
    public int MaxCount { get; set; } = 0;
    public int SkipCount { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    
    public string? Sorting { get; set; }
}