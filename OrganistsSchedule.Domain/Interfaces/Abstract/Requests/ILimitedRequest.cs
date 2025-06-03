namespace OrganistsSchedule.Application.Interfaces;

public interface ILimitedRequest
{
    int MaxCount { get; set; }
}