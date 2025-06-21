using OrganistsSchedule.Application.Interfaces;

namespace OrganistsSchedule.Application.DTOs;

public class PagedResultDto<TDto>: ListResultDto<TDto>, IPagedResultDto<TDto>
{
    public PagedResultDto(IEnumerable<TDto> items, long totalCount) : base(items)
    {
        TotalCount = totalCount;
    }
    public long TotalCount { get; set; }
}
