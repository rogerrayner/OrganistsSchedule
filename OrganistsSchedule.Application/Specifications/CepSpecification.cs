using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Specifications;

[DoNotRegister]
public class CepSpecification(CepPagedAndSortedRequest? request) : ISpecification<Cep>
{
    public IQueryable<Cep> Apply(IQueryable<Cep> query)
    {
        if (request == null)
            return query;
        
        if (!string.IsNullOrWhiteSpace(request.ZipCode))
            query = query.Where(x => x.ZipCode == request.ZipCode);
        
        if (!string.IsNullOrWhiteSpace(request.Street))
            query = query.Where(x => x.Street.Contains(request.Street));
        
        if (request.CityId.HasValue)
            query = query.Where(x => x.CityId == request.CityId.Value);

        return query;
    }
}