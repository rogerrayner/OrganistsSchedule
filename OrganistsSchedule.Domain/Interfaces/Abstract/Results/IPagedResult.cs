namespace OrganistsSchedule.Domain.Interfaces.Results;

public interface IPagedResult<TEntity> : IListResult<TEntity>, IHasTotalCount
{
    
}