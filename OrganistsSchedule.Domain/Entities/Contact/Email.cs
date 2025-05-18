namespace OrganistsSchedule.Domain.Entities;

public sealed class Email: AuditableEntityBase
{
    public required string EmailAddress { get; set; }
    
    public bool IsPrimary { get; set; }
    public long? OrganistId { get; set; }
    public Organist? Organist { get; set; }
}