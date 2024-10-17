namespace OrganistsSchedule.Domain.Entities;

public abstract class EntityBase
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime UpdatedAt { get; protected set; }
    public long CreatedBy { get; protected set; }
    public long UpdatedBy { get; protected set; }
}