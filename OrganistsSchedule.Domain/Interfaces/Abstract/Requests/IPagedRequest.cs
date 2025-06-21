namespace OrganistsSchedule.Domain.Interfaces;

public interface IPagedRequest: 
    ILimitedRequest
{
    int SkipCount { get; set; }
}