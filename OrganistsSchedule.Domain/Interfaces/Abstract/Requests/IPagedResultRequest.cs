namespace OrganistsSchedule.Application.Interfaces;

public interface IPagedResultRequest: 
    ILimitedResultRequest
{
    int SkipCount { get; set; }
}