using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Domain.Entities;

public abstract class AuditableEntityBase: EntityBaseBase, IAuditableEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public long CreatedBy { get; set; }
    public long UpdatedBy { get; set; }
}