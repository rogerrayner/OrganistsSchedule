using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class OrganistRepository(ApplicationDbContext context) 
    : RepositoryBase<Organist>(context), IOrganistRepository;