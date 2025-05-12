using OrganistsSchedule.Application.Interfaces;

namespace OrganistsSchedule.Application.Services.Requests;

public class PagedResultRequestDto : IPagedResultRequest
{
    public int MaxCount { get; set; }
    public int SkipCount { get; set; }
}