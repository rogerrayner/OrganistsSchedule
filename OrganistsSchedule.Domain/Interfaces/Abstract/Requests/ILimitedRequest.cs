namespace OrganistsSchedule.Domain.Interfaces;

public interface ILimitedRequest
{
    int MaxCount { get; set; }
}