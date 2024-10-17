using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class HolyServiceRepository(ApplicationDbContext context)
    : RepositoryBase<HolyService>(context), IHolyServiceRepository;