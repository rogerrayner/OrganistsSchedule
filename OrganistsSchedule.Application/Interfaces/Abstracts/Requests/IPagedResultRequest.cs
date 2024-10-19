namespace OrganistsSchedule.Application.Interfaces;

public interface IPagedResultRequest<TDto>: 
    ILimitedResultRequest
    where TDto : class
{
    int SkipCount { get; set; }
}