using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class EmailRepository(ApplicationDbContext context) 
    : RepositoryBase<Email>(context), IEmailRepository;