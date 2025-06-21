namespace OrganistsSchedule.Application.Interfaces;

public interface IListResultDto<TDto>
{
    IEnumerable<TDto> Items { get; set; }
}