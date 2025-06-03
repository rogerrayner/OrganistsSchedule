namespace OrganistsSchedule.Application.Interfaces;

public interface ICongregationPagedAndSortedRequest: IPagedAndSortedRequest
{
    public string? RelatorioBrasCode { get; set; }
    public string? Name { get; set; }
}