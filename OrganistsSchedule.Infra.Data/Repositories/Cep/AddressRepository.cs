using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Infra.Data.Repositories;

public class AddressRepository(ApplicationDbContext context)
    : RepositoryBase<Address>(context), IAddressRepository;