using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class ParameterScheduleRepository(ApplicationDbContext context)
    : RepositoryBase<ParameterSchedule>(context), IParameterScheduleRepository;