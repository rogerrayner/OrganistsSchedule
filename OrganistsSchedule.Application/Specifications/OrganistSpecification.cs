using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Specifications;

[DoNotRegister]
public class OrganistSpecification(OrganistPagedAndSortedRequest? request) :
    ISpecification<Organist>
{
    public IQueryable<Organist> Apply(IQueryable<Organist> query)
    {
        if(request == null)
            return query;
        
        if (!string.IsNullOrWhiteSpace(request.FullName))
            query = query.Where(x => x.FullName.ToLower().Contains(request.FullName.ToLower()));

        if (!string.IsNullOrWhiteSpace(request.ShortName))
            query = query.Where(x => x.ShortName.ToLower().Contains(request.ShortName.ToLower()));
        
        if (request.CityId.HasValue)
        {
            query = query.Where(x => x.Cep != null && x.Cep.CityId == request.CityId.Value);
        }
        
        if (!string.IsNullOrWhiteSpace(request.District))
        {
            var district = request.District.ToLower();
            query = query.Where(x => x.Cep != null && x.Cep.District.ToLower() == district);
        }        
        
        return query;
    }
}