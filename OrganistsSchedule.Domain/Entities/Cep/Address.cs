namespace OrganistsSchedule.Domain.Entities;

public sealed class Address : AuditableEntityBase, IEquatable<Address>
{
    public long CepId { get; set; }
    public Cep Cep { get; set; }
    public required long StreetNumber { get; set; }
    public string? Complement { get; set; }

    public override bool Equals(object? obj) => Equals(obj as Address);

    public bool Equals(Address? other)
    {
        if (other is null) return false;
        return StreetNumber == other.StreetNumber
               && string.IsNullOrEmpty(Complement) == string.IsNullOrEmpty(other.Complement)
               && Cep?.Equals(other.Cep) == true;
    }

    public override int GetHashCode() =>
        HashCode.Combine(StreetNumber, Complement, Cep?.ZipCode);
}