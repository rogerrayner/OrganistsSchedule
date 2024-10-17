using FluentValidation;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Utils;

namespace OrganistsSchedule.Domain.Validators;

public class OrganistValidator : AbstractValidator<Organist>
{
    public OrganistValidator()
    {
        RuleFor(x => x.Cpf)
            .NotEmpty().WithMessage("CPF is required.")
            .Must(CpfUtil.IsCpfValid).WithMessage("Invalid CPF.");
    }
}