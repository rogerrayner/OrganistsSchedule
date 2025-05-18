using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Domain.Entities;

public abstract class EntityBaseBase: IEntityBase
{
    public long Id { get; set; }
}