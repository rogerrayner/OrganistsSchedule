namespace OrganistsSchedule.Domain.Entities;

public sealed class City: EntityBase
{
    public required string Name { get; set; }
    
    public long? CountryId { get; set; }
    public required Country Country { get; set; }
}