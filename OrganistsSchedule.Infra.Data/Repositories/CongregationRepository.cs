using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class CongregationRepository(ApplicationDbContext context)
    : RepositoryBase<Congregation>(context), ICongregationRepository;