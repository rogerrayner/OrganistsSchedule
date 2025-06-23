using OrganistsSchedule.Domain.Enums;
using OrganistsSchedule.Domain.Exceptions;
using OrganistsSchedule.Domain.Utils;

namespace OrganistsSchedule.Domain.Entities;

public sealed class Organist: AuditableEntityBase
{
    private string _fullName = null!;
    public required string FullName
    {
        get => _fullName;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 10)
                ErrorHandler.ThrowBusinessException(Messages.FullNameError);
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
                ErrorHandler.ThrowBusinessException(Messages.FieldRequiredMale, "Nome Abreviado");
            _shortName = value;
        }
    }
    public ICollection<CongregationOrganist> CongregationOrganists { get; set; } = new List<CongregationOrganist>();
    public OrganistsLevelEnum Level { get; set; }
    public long? CepId { get; set; }
    public Cep? Cep { get; set; }
    public ICollection<Email>? Emails { get; set; }
    public long? PhoneId { get; set; }
    public Phone? Phone { get; set; }
    public Organist() {}
    
}