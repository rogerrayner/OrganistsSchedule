using OrganistsSchedule.Application.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class PagedResultDto<TDto>: ListResultDto<TDto>, IPagedResult<TDto>
{
    public PagedResultDto(IEnumerable<TDto> items, long totalCount) : base(items)
    {
        TotalCount = totalCount;
    }
    public long TotalCount { get; set; }
}
