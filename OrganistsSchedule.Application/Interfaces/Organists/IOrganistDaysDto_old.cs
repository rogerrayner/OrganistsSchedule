namespace OrganistsSchedule.Application.Interfaces;

public interface IOrganistDaysOfService
{
    public long OrganistId { get; set; }
    public DayOfWeek[] DaysOfService { get; set; }
}