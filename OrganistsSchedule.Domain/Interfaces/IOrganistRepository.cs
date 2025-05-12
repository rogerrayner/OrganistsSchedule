using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Domain.Interfaces;

public interface IOrganistRepository: IRepositoryBase<Organist>
{
    List<Organist> GetByCongregation(long congregationId);
}