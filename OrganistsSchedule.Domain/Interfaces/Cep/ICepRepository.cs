using OrganistsSchedule.Domain.Entities;

namespace OrganistsSchedule.Domain.Interfaces;

public interface ICepRepository<TRequest>: IRepositoryBase<Cep, TRequest>
    where TRequest : class, IPagedAndSortedRequest
{
    Task<Cep?> GetCepByZipCodeAsync(
        string cep, 
        CancellationToken cancellationToken);

    /*Task<List<string>> GetDistrictsByCityIdAsync(
        long cityId,
        IPagedAndSortedSpecification? request = null,
        CancellationToken cancellationToken = default);

    Task<int> CountDistrictsByCityIdAsync(
        long cityId,
        IPagedAndSortedSpecification? request = null,
        CancellationToken cancellationToken = default);*/
    
    Task<List<string>> GetDistrictsByCityIdAsync(
        long cityId,
        CancellationToken cancellationToken = default);
    
}