
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Domain.Results;

public class ListResult<TEntity> : IListResult<TEntity>
{
    public IEnumerable<TEntity> Items
    {
        get { return _items ??= new List<TEntity>(); } 
        set => _items = value;
    }

    private IEnumerable<TEntity>? _items;

    public ListResult(IEnumerable<TEntity> items)
    {
        Items = items;
    }
}