public class OrganistDaysDto
{
    public long OrganistId { get; set; }
    public DayOfWeek[] OrganistServiceDaysOfWeek { get; set; } = [];
    public int Sequence { get; set; }
}