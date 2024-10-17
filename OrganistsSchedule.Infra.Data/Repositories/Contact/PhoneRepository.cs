using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class PhoneRepository(ApplicationDbContext context) 
    : RepositoryBase<Phone>(context), IPhoneRepository;