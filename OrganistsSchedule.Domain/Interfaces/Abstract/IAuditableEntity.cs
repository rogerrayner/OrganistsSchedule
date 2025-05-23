namespace OrganistsSchedule.Domain.Interfaces;

public interface IAuditableEntity
{ 
    DateTime CreatedAt { get; protected set; }
    DateTime UpdatedAt { get; protected set; }
    long CreatedBy { get; protected set; }
    long UpdatedBy { get; protected set; }
}