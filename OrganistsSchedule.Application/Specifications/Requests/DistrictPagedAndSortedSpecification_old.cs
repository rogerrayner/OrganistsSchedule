using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Specifications.Requests;

[DoNotRegister]
public class DistrictPagedAndSortedSpecification_old : PagedAndSortedRequestDto //, IPagedAndSortedSpecification
{
    public DistrictPagedAndSortedSpecification_old(DistrictPagedAndSortedRequest? request)
    {
        if (request != null)
        {
            this.MaxCount = request.MaxCount;
            this.PageSize = request.PageSize;
            this.SkipCount = request.SkipCount;
            this.Sorting = request.Sorting;
        }
    }

    public IQueryable<Cep> Apply(IQueryable<Cep> query)
    {
        if (this.SkipCount > 0)
            query = query.Skip(this.SkipCount);

        if (this.MaxCount > 0)
            query = query.Take(Math.Min(this.PageSize, this.MaxCount));
        else
            query = query.Take(this.PageSize);
        
        /*if (!string.IsNullOrWhiteSpace(request.Street))
            query = query.Where(x => x.Street.Contains(request.Street));*/

        return query;
    }
}