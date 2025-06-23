namespace OrganistsSchedule.Domain.Interfaces;

public interface IListResult<TEntity>
{
    IEnumerable<TEntity> Items { get; set; }
}