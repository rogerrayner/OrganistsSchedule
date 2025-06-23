namespace OrganistsSchedule.Domain.Interfaces;

public interface IPagedAndSortedRequest: IPagedRequest, ISortedRequest
{
    public int PageSize { get; set; }
}