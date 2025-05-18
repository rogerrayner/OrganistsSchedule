using System.Dynamic;

namespace OrganistsSchedule.Domain.Entities;

public sealed class Country: AuditableEntityBase
{
    public required string Name { get; set; }
    
}