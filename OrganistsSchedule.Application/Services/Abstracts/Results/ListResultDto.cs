using OrganistsSchedule.Application.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class ListResultDto<TDto> : IListResult<TDto>
{
    public IEnumerable<TDto> Items
    {
        get { return _items ??= new List<TDto>(); } 
        set => _items = value;
    }

    private IEnumerable<TDto>? _items;

    public ListResultDto(IEnumerable<TDto> items)
    {
        Items = items;
    }
}