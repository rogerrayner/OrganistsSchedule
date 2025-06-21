using Microsoft.EntityFrameworkCore;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class ParameterScheduleRepository<TRequest>(ApplicationDbContext context)
    : RepositoryBase<ParameterSchedule, TRequest>(context), IParameterScheduleRepository<TRequest>
    where TRequest : class, IPagedAndSortedRequest
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
    
    public async Task<bool> HasDateRangeOverlapAsync(long congregationId,
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken = default)
    {
        return await context.ParametersSchedules
            .AnyAsync(p =>
                    p.CongregationId == congregationId &&
                    (
                        // Sobreposição ou datas exatamente iguais
                        (startDate <= p.EndDate && endDate >= p.StartDate)
                    ),
                cancellationToken
            );
    }
}