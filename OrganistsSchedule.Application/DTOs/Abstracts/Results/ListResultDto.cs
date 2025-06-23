
using OrganistsSchedule.Application.Interfaces;

namespace OrganistsSchedule.Application.DTOs;

public class ListResultDto<TDto> : IListResultDto<TDto>
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