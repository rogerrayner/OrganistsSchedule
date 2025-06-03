using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain;
using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Application.Specifications;

[DoNotRegister]
public class CongregationSpecification(ICongregationPagedAndSortedRequest? request) : ISpecification<Congregation>
{
    public IQueryable<Congregation> Apply(IQueryable<Congregation> query)
    {
        if(request == null)
            return query;
        
        if (!string.IsNullOrWhiteSpace(request.RelatorioBrasCode))
            query = query.Where(x => x.RelatorioBrasCode.ToLower().Contains(request.RelatorioBrasCode.ToLower()));

        if (!string.IsNullOrWhiteSpace(request.Name))
            query = query.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));

        return query
            .OrderBy(x => x.Name)
            .ThenBy(x => x.RelatorioBrasCode);
    }
}