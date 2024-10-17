using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class CityRepository(ApplicationDbContext context) 
    : RepositoryBase<City>(context), ICityRepository;