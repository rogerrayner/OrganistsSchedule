using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class ParameterScheduleRepository(ApplicationDbContext context)
    : RepositoryBase<ParameterSchedule>(context), IParameterScheduleRepository
{
    public async Task<ParameterSchedule> GetByRangeDateAndCongregationIdAsync(long congregationId, 
        DateTime startDate, 
        DateTime endDate,
        CancellationToken cancellationToken = default)
    {
        return (await context.ParametersSchedules
            .Include(p => p.Congregation)
            .FirstOrDefaultAsync(p => p.CongregationId == congregationId && 
                                      p.StartDate.Date == startDate.Date && 
                                      p.EndDate.Date == endDate.Date, cancellationToken))!;
    }
}