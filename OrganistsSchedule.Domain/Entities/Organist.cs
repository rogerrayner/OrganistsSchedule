using OrganistsSchedule.Domain.Enums;
using OrganistsSchedule.Domain.Exceptions;
using OrganistsSchedule.Domain.Utils;

namespace OrganistsSchedule.Domain.Entities;

public sealed class Organist: AuditableEntityBase
{
    private string? _cpf;
    public string? Cpf
    {
        get => _cpf;
        private set
        {
            if (!string.IsNullOrEmpty(value) && !CpfUtil.IsCpfValid(value))
                throw new BusinessException(Messages.InvalidCpf);
            _cpf = value;
        }
    }
    private string _fullName = null!;
    public required string FullName
    {
        get => _fullName;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 10)
                throw new BusinessException(Messages.FullNameError);
            _fullName = value;
        }
    }
    private string _shortName = null!;
    public required string ShortName
    {
        get => _shortName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new BusinessException(Messages.Format(Messages.FieldRequiredMale, "Nome Abreviado"));
            _shortName = value;
        }
    }
    public ICollection<CongregationOrganist> CongregationOrganists { get; set; } = new List<CongregationOrganist>();
    public OrganistsLevelEnum Level { get; set; }
    public long? AddressId { get; set; }
    public Address? Address { get; set; }
    public ICollection<Email>? Emails { get; set; }
    public long? PhoneId { get; set; }
    public Phone? PhoneNumber { get; set; }
    public Organist(string? cpf)
    {
        Cpf = cpf;
    }
    public Organist() {}
    
}