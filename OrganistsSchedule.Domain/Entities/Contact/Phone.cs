
namespace OrganistsSchedule.Domain.Entities;

public sealed class Phone: AuditableEntityBase
{
    public required long Number { get; set; }
    
    public bool IsPrimary { get; set; }
    
    public long? OrganistId { get; set; }
    public Organist? Organist { get; set; }
}