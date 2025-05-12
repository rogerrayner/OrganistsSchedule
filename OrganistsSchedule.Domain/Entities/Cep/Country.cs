using System.Dynamic;

namespace OrganistsSchedule.Domain.Entities;

public sealed class Country: EntityBase
{
    public required string Name { get; set; }
    
}