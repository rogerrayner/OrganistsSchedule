
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.DTOs;

public class PagedRequestDto : IPagedRequest
{
    public int MaxCount { get; set; }
    public int SkipCount { get; set; }
}