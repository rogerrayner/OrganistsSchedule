namespace OrganistsSchedule.Application.Interfaces;

public interface ISpecification<TEntity>
{
    IQueryable<TEntity> Apply(IQueryable<TEntity> query);
}