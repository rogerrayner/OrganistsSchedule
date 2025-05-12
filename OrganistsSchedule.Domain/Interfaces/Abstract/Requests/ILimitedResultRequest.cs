namespace OrganistsSchedule.Application.Interfaces;

public interface ILimitedResultRequest
{
    int MaxCount { get; set; }
}