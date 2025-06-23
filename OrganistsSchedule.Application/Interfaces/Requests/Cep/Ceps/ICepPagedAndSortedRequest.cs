using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Interfaces;

public interface ICepPagedAndSortedRequest: IPagedAndSortedRequest
{
    public string? ZipCode { get; set; }
    public string? Street {get; set;}
}