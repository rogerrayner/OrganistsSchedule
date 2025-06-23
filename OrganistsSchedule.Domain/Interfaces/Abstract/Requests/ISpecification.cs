namespace OrganistsSchedule.Domain.Interfaces;

public interface ISpecification<TEntity>
{
    IQueryable<TEntity> Apply(IQueryable<TEntity> query);
}