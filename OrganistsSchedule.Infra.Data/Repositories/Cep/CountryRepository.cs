using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class CountryRepository(ApplicationDbContext context) 
    : RepositoryBase<Country>(context), ICountryRepository;