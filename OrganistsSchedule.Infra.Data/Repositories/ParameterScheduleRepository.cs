using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class ParameterScheduleRepository(ApplicationDbContext context)
    : RepositoryBase<ParameterSchedule>(context), IParameterScheduleRepository
{
    public ParameterSchedule GetByRangeDateAndCongregationIdAsync(long congregationId, DateTime startDate, DateTime endDate)
    {
        return context.ParametersSchedules
            .Include(p => p.Congregation)
            .FirstOrDefault(p => p.CongregationId == congregationId && 
                                 p.StartDate.Date == startDate.Date && 
                                 p.EndDate.Date == endDate.Date);
    }
}