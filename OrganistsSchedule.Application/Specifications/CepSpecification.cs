using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Specifications;

[DoNotRegister]
public class CepSpecification(string zipCode) : ISpecification<Cep>
{
    public IQueryable<Cep> Apply(IQueryable<Cep> query)
        => query.Where(x => x.ZipCode == zipCode);
}