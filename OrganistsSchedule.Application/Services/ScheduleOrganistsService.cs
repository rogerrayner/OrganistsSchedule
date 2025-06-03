using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Enums;

namespace OrganistsSchedule.Application.Services;

public class ScheduleOrganistsService(IOrganistService organistService,
    ICongregationService congregationService) : IScheduleOrganistsService
{
    
    public async Task<List<HolyService>> ScheduleOrganistsForHolyServices(ParameterSchedule parametersSchedule,
        CancellationToken cancellationToken = default)
    {
        var holyServices = GenerateHolyServicesFromParameters(parametersSchedule);
        var congregation = parametersSchedule.Congregation;
        var organists = await congregationService.GetCongregationOrganistsAsync(congregation.Id);

        if (organists != null)
        {
            //Reunião de Jovens e Menores
            ScheduleOrganists(organists
                    .FindAll(organist => (organist.Level & 
                                          OrganistsLevelEnum.YouthMeeting) == OrganistsLevelEnum.YouthMeeting), 
                holyServices.FindAll(service => service.IsYouthMeeting),
                parametersSchedule);
        
            //Cultos oficiais
            ScheduleOrganists(organists
                    .FindAll(organist => (organist.Level & 
                                          OrganistsLevelEnum.HolyService) == OrganistsLevelEnum.HolyService), 
                holyServices.FindAll(service => !service.IsYouthMeeting),
                parametersSchedule);
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
    
    private async void ScheduleOrganists(List<CongregationOrganistsDto> organists, List<HolyService> holyServices, ParameterSchedule parametersSchedule)
    {
        try
        {
            var sortedOrganistsBySequence = organists.OrderBy(o => o.Sequence).ToList();
        
            var lastOrganistToPlayOnWeekDay = 
                organists.ToDictionary(o => o.OrganistId, o => new Dictionary<string, DateTime?>());

            foreach (var organist in organists)
            {
                foreach (var day in organist.OrganistServiceDaysOfWeek)
                {
                    lastOrganistToPlayOnWeekDay[organist.OrganistId][day.ToString()] = null;
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
                        o.OrganistServiceDaysOfWeek.Contains(service.Date.DayOfWeek) &&
                        (service.IsYouthMeeting 
                            ? (o.Level & OrganistsLevelEnum.YouthMeeting) == OrganistsLevelEnum.YouthMeeting
                            : (o.Level & OrganistsLevelEnum.HolyService) == OrganistsLevelEnum.HolyService))
                    .OrderBy(o => organistWeekdayCount[o].Values.Sum())
                    .ThenBy(o => 
                        GetLeastRecentlyPlayedWeekday(o.OrganistId, service.Date, service.Date.DayOfWeek, lastOrganistToPlayOnWeekDay))
                    .ThenBy(o => o.Sequence)
                    .ToList();

                if (availableOrganists.Count > 0)
                {
                    var selectedOrganist = availableOrganists.First();
                    service.OrganistId = selectedOrganist.OrganistId;
                    organistWeekdayCount[selectedOrganist][service.Date.DayOfWeek.ToString()]++;
                    lastOrganistToPlayOnWeekDay[selectedOrganist.OrganistId][service.Date.DayOfWeek.ToString()] = service.Date;
                }
            }
        }
        catch (Exception e)
        {
            throw; 
        }
    }
    
    private DateTime? GetLeastRecentlyPlayedWeekday(long organistId, DateTime currentDate, DayOfWeek currentDay, Dictionary<long, Dictionary<string, DateTime?>> organistLastPlayedWeekday)
    {
        return organistLastPlayedWeekday[organistId].ContainsKey(currentDay.ToString()) ? organistLastPlayedWeekday[organistId][currentDay.ToString()] : null;
    }
    
    private static IEnumerable<DateTime> GetDays(DateTime start, DateTime end) {
        for (var day = start; day <= end; day = day.AddDays(1)) yield return day;
    }
}