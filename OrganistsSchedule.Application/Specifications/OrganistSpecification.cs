using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Specifications;

[DoNotRegister]
public class OrganistSpecification(IOrganistPagedAndSortedRequest? request) : ISpecification<Organist>
{
    public IQueryable<Organist> Apply(IQueryable<Organist> query)
    {
        if(request == null)
            return query;
        
        if (!string.IsNullOrWhiteSpace(request.FullName))
            query = query.Where(x => x.FullName.ToLower().Contains(request.FullName.ToLower()));

        if (!string.IsNullOrWhiteSpace(request.ShortName))
            query = query.Where(x => x.ShortName.ToLower().Contains(request.ShortName.ToLower()));

        return query
            .OrderBy(x => x.FullName)
            .ThenBy(x => x.ShortName);
    }
}