using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Enums;
using OrganistsSchedule.Domain.Exceptions;
using OrganistsSchedule.Domain.Utils;

namespace OrganistsSchedule.Application.Services;

public class ScheduleOrganistsService(IOrganistService organistService,
    ICongregationService congregationService) : IScheduleOrganistsService
{
    
    public async Task<List<HolyService>> ScheduleOrganistsForHolyServices(ParameterSchedule parametersSchedule,
        CancellationToken cancellationToken = default)
    {
        var holyServices = GenerateHolyServicesFromParameters(parametersSchedule);
        var congregation = parametersSchedule.Congregation;
        var result = await congregationService
            .GetOrganistsByCongregationAsync(congregation.Id, cancellationToken);

        var organists = result.Items;

        if (ListValidation.IsNullOrEmpty(organists))
        {
            ErrorHandler.ThrowBusinessException(Messages.GenerationSchedule1013);
        }

        var youthMeetingOrganists = organists
            .Where(o => o.Organist.Level == OrganistsLevelEnum.YouthMeeting ||
                        o.Organist.Level == OrganistsLevelEnum.YouthMeetingAndHolyService)
            .ToList();
        
        var youthMeetingServices = holyServices
            .FindAll(service => service.IsYouthMeeting);

        if (!ListValidation.IsNullOrEmpty(youthMeetingServices)
            && !ListValidation.IsNullOrEmpty(youthMeetingOrganists))
        {
            ScheduleOrganists(
                youthMeetingOrganists,
                youthMeetingServices,
                parametersSchedule
            );
        }
        
        var holyServiceOrganists = organists
            .Where(o => (o.Organist.Level & OrganistsLevelEnum.HolyService) 
                        == OrganistsLevelEnum.HolyService)
            .ToList();
        
        var holyServiceServices = holyServices
            .FindAll(service => !service.IsYouthMeeting);

        if (!ListValidation.IsNullOrEmpty(holyServiceServices)
            && !ListValidation.IsNullOrEmpty(holyServiceOrganists))
        {
            ScheduleOrganists(holyServiceOrganists,
                holyServiceServices,
                parametersSchedule);
        }

        if (holyServices.Any(hs => hs.Organist == null))
        {
            ErrorHandler.ThrowBusinessException(Messages.GenerationSchedule1014);
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
                        IsYouthMeeting = true,
                        ParameterScheduleId = parametersSchedule.Id
                    });
                    holyServices.Add(new HolyService
                    {
                        Date = date,
                        CongregationId = parametersSchedule.CongregationId,
                        IsYouthMeeting = false,
                        ParameterScheduleId = parametersSchedule.Id
                    });
                }
                else
                {
                    holyServices.Add(new HolyService
                    {
                        Date = date,
                        CongregationId = parametersSchedule.CongregationId,
                        IsYouthMeeting = false,
                        ParameterScheduleId = parametersSchedule.Id
                    });
                }
            } else if (date.DayOfWeek == DayOfWeek.Sunday && parametersSchedule.Congregation.HasYouthMeetings)
            {
                holyServices.Add(new HolyService
                {
                    Date = date,
                    CongregationId = parametersSchedule.CongregationId,
                    IsYouthMeeting = true,
                    ParameterScheduleId = parametersSchedule.Id
                });
            }
        }

        return holyServices;
    }
    
    private async void ScheduleOrganists(List<CongregationOrganist> organists, 
        List<HolyService> holyServices, 
        ParameterSchedule parametersSchedule)
    {
        try
        {
            var sortedOrganistsBySequence = organists
                .OrderBy(o => o.Sequence)
                .ToList();
        
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
                            ? (o.Organist.Level & OrganistsLevelEnum.YouthMeeting) == OrganistsLevelEnum.YouthMeeting
                            : (o.Organist.Level & OrganistsLevelEnum.HolyService) == OrganistsLevelEnum.HolyService))
                    .OrderBy(o => organistWeekdayCount[o].Values.Sum())
                    .ThenBy(o => 
                        GetLeastRecentlyPlayedWeekday(o.OrganistId, service.Date, service.Date.DayOfWeek, lastOrganistToPlayOnWeekDay))
                    .ThenBy(o => o.Sequence)
                    .ToList();

                if (availableOrganists.Count > 0)
                {
                    var selectedOrganist = availableOrganists.First();
                    service.OrganistId = selectedOrganist.OrganistId;
                    service.Organist = selectedOrganist.Organist;
                    organistWeekdayCount[selectedOrganist][service.Date.DayOfWeek.ToString()]++;
                    lastOrganistToPlayOnWeekDay[selectedOrganist.OrganistId][service.Date.DayOfWeek.ToString()] = service.Date;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; 
        }
    }
    
    private DateTime? GetLeastRecentlyPlayedWeekday(long organistId, 
        DateTime currentDate, 
        DayOfWeek currentDay, 
        Dictionary<long, Dictionary<string, DateTime?>> organistLastPlayedWeekday)
    {
        return organistLastPlayedWeekday[organistId]
            .ContainsKey(currentDay.ToString()) ? organistLastPlayedWeekday[organistId][currentDay.ToString()] : null;
    }
    
    private static IEnumerable<DateTime> GetDays(DateTime start, DateTime end) {
        for (var day = start; day <= end; day = day.AddDays(1)) yield return day;
    }
}