namespace OrganistsSchedule.Application.Interfaces;

public interface ICepPagedAndSortedRequest: IPagedAndSortedRequest
{
    public string? ZipCode { get; set; }
}