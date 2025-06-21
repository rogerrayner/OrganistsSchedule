using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Interfaces;

public interface IOrganistPagedAndSortedRequest: IPagedAndSortedRequest
{
    public string? FullName { get; set; }
    public string? ShortName { get; set; }
}