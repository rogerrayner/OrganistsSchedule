namespace OrganistsSchedule.Domain.Entities;

public sealed class Cep: AuditableEntityBase, IEquatable<Cep>
{
    public required string ZipCode { get; set; }
    public required string Street { get; set; }
    public required string District { get; set; }
    public required string State { get; set; }
    public long CityId { get; set; }
    public City? City { get; set; }
    
    public override bool Equals(object? obj) => Equals(obj as Cep);

    public bool Equals(Cep? other) => other != null && ZipCode == other.ZipCode;

    public override int GetHashCode() => ZipCode?.GetHashCode() ?? 0;
    
}