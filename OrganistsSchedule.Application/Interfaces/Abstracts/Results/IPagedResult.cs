namespace OrganistsSchedule.Application.Interfaces;

public interface IPagedResult<TDto> : IListResult<TDto>, IHasTotalCount
{
    
}