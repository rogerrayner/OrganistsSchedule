using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Specifications;

[DoNotRegister]
public class CepSpecification(ICepPagedAndSortedRequest? request) : ISpecification<Cep>
{
    public IQueryable<Cep> Apply(IQueryable<Cep> query)
    {
        if (request == null)
            return query;
        
        if (!string.IsNullOrWhiteSpace(request.ZipCode))
            query = query.Where(x => x.ZipCode == request.ZipCode);
        
        return query.OrderBy(x => x.ZipCode);
    }
}