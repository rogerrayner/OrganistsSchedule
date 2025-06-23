
using OrganistsSchedule.Domain.Interfaces.Results;

namespace OrganistsSchedule.Domain.Results;

public class PagedResult<TEntity>: ListResult<TEntity>, IPagedResult<TEntity>
{
    public PagedResult(IEnumerable<TEntity> items, long totalCount) : base(items)
    {
        TotalCount = totalCount;
    }
    public long TotalCount { get; set; }
}
