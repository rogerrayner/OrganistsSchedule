namespace OrganistsSchedule.Application.Interfaces;

public interface IListResult<TDto>
{
    IEnumerable<TDto> Items { get; set; }
}