namespace OrganistsSchedule.Application.Interfaces;

public interface ILimitedResultRequest
{
    int MaxCountResult { get; set; }
}