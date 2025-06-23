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
        
        if (!string.IsNullOrWhiteSpace(request.Districts))
        {
            var districts = request.Districts
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(d => d.Trim().ToLower())
                .Where(d => !string.IsNullOrWhiteSpace(d))
                .ToList();

            if (districts.Any())
            {
                query = query.Where(x => x.Cep != null && districts.Contains(x.Cep.District.ToLower()));
            }
        }

        if (request.ExcludeIds != null && request.ExcludeIds.Any())
        {
            var excludeIdsList = request.ExcludeIds
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();

            if (excludeIdsList.Any())
            {
                query = query
                    .Where(o => !excludeIdsList.Contains(o.Id));
            }
        }

        return query;
    }
}