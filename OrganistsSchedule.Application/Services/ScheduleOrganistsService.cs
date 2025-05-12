using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Enums;

namespace OrganistsSchedule.Application.Services;

public class ScheduleOrganistsService: IScheduleOrganistsService
{
    
    protected readonly IOrganistService _organistService;

    public ScheduleOrganistsService(IOrganistService organistService)
    {
        _organistService = organistService;
    }

    public List<HolyService> ScheduleOrganistsForHolyServices(ParameterSchedule parametersSchedule)
    {
        var holyServices = GenerateHolyServicesFromParameters(parametersSchedule);

        var organists = _organistService.GetByCongregation(parametersSchedule.CongregationId);
        
        if (organists != null)
        {
            //Reunião de Jovens e Menores
            ScheduleOrganists(organists
                    .FindAll(organist => (organist.Level & 
                                          OrganistsLevelEnum.YouthMeeting) == OrganistsLevelEnum.YouthMeeting), 
                holyServices.FindAll(service => service.IsYouthMeeting));
        
            //Cultos oficiais
            ScheduleOrganists(organists
                    .FindAll(organist => (organist.Level & 
                                          OrganistsLevelEnum.HolyService) == OrganistsLevelEnum.HolyService), 
                holyServices.FindAll(service => !service.IsYouthMeeting));
        }

        return holyServices;
    }
    private List<HolyService> GenerateHolyServicesFromParameters(ParameterSchedule parametersSchedule)
    {
        List<HolyService> holyServices = new List<HolyService>();
        
        foreach (var date in GetDays(parametersSchedule.StartDate, parametersSchedule.EndDate))
        {
            if (parametersSchedule.Congregation.DaysOfService.Contains(date.DayOfWeek))
            {
                if (date.DayOfWeek == DayOfWeek.Sunday && parametersSchedule.Congregation.HasYouthMeetings)
                {
                    holyServices.Add(new HolyService
                    {
                        Date = date,
                        CongregationId = parametersSchedule.CongregationId,
                        IsYouthMeeting = true
                    });
                    holyServices.Add(new HolyService
                    {
                        Date = date,
                        CongregationId = parametersSchedule.CongregationId,
                        IsYouthMeeting = false
                    });
                }
                else
                {
                    holyServices.Add(new HolyService
                    {
                        Date = date,
                        CongregationId = parametersSchedule.CongregationId,
                        IsYouthMeeting = false
                    });
                }
            }
        }

        return holyServices;
    }
    
    private void ScheduleOrganists(List<Organist> organists, List<HolyService> holyServices)
    {
        var sortedOrganistsBySequence = organists.OrderBy(o => o.Sequence).ToList();
        
        var lastOrganistToPlayOnWeekDay = 
            organists.ToDictionary(o => o, o => new Dictionary<string, DateTime?>());

        foreach (var organist in organists)
        {
            foreach (var day in organist.ServicesDaysOfWeek)
            {
                lastOrganistToPlayOnWeekDay[organist][day.ToString()] = null;
            }
        }
        
        var organistWeekdayCount = organists
            .ToDictionary(o => o, o => new Dictionary<string, int>
        {
            { DayOfWeek.Sunday.ToString(), 0 },
            { DayOfWeek.Monday.ToString(), 0 },
            { DayOfWeek.Tuesday.ToString(), 0 },
            { DayOfWeek.Wednesday.ToString(), 0 },
            { DayOfWeek.Thursday.ToString(), 0 },
            { DayOfWeek.Friday.ToString(), 0 },
            { DayOfWeek.Saturday.ToString(), 0 }
        });
        
        foreach (var service in holyServices)
        {
            var availableOrganists = sortedOrganistsBySequence
                .Where(o =>
                    o.ServicesDaysOfWeek.Contains(service.Date.DayOfWeek) &&
                    (service.IsYouthMeeting 
                        ? (o.Level & OrganistsLevelEnum.YouthMeeting) == OrganistsLevelEnum.YouthMeeting
                        : (o.Level & OrganistsLevelEnum.HolyService) == OrganistsLevelEnum.HolyService))
                .OrderBy(o => organistWeekdayCount[o].Values.Sum())
                .ThenBy(o => 
                    GetLeastRecentlyPlayedWeekday(o, service.Date, service.Date.DayOfWeek, lastOrganistToPlayOnWeekDay))
                .ThenBy(o => o.Sequence)
                .ToList();

            if (availableOrganists.Count > 0)
            {
                var selectedOrganist = availableOrganists.First();
                service.OrganistId = selectedOrganist.Id;
                organistWeekdayCount[selectedOrganist][service.Date.DayOfWeek.ToString()]++;
                lastOrganistToPlayOnWeekDay[selectedOrganist][service.Date.DayOfWeek.ToString()] = service.Date;
            }
        }
    }
    
    private DateTime? GetLeastRecentlyPlayedWeekday(Organist organist, DateTime currentDate, DayOfWeek currentDay, Dictionary<Organist, Dictionary<string, DateTime?>> organistLastPlayedWeekday)
    {
        return organistLastPlayedWeekday[organist].ContainsKey(currentDay.ToString()) ? organistLastPlayedWeekday[organist][currentDay.ToString()] : null;
    }
    
    private static IEnumerable<DateTime> GetDays(DateTime start, DateTime end) {
        for (var day = start; day <= end; day = day.AddDays(1)) yield return day;
    }
}