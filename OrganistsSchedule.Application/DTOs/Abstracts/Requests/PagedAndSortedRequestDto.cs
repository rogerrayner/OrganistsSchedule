using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.DTOs;

public class PagedAndSortedRequestDto: IPagedAndSortedRequest
{
    public int MaxCount { get; set; } = 0;
    public int SkipCount { get; set; } = 0;
    public int PageSize { get; set; } = 10;
    
    public string? Sorting { get; set; }
}