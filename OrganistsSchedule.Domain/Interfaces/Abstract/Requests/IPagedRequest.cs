namespace OrganistsSchedule.Application.Interfaces;

public interface IPagedRequest: 
    ILimitedRequest
{
    int SkipCount { get; set; }
}