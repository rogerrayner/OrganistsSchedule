namespace OrganistsSchedule.Application.Interfaces;

public interface IPagedResultDto<TDto> : IListResultDto<TDto>, IHasTotalCountDto
{
    
}