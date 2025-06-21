using System.Data;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Application.Specifications;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;
using OrganistsSchedule.Domain.Interfaces.Results;
using OrganistsSchedule.Domain.Results;

namespace OrganistsSchedule.Application.Services;

public class OrganistService(
    IOrganistRepository<OrganistPagedAndSortedRequest> repository, 
    IUnitOfWork unitOfWork,
    IPhoneRepository<PhonePagedAndSortedRequest> phoneRepository,
    IEmailRepository<EmailPagedAndSortedRequest> emailRepository,
    ICongregationOrganistRepository<CongregationPagedAndSortedRequest> congregationRepository,
    ICepService cepService) 
    : CrudServiceBase<Organist, 
            OrganistPagedAndSortedRequest>(repository, unitOfWork),
        IOrganistService
{
    public override Task<IPagedResult<Organist>> GetAllAsync(
        OrganistPagedAndSortedRequest request, 
        CancellationToken cancellationToken,
        ISpecification<Organist>? specification = null)
    {
        specification = new OrganistSpecification(request);
        return base.GetAllAsync(request, cancellationToken, specification);
    }

    public async Task<IEnumerable<Organist>> GetByIdsAsync(List<long> organistIds, 
        CancellationToken cancellationToken = default)
    {
        return await repository.GetByIdsAsync(organistIds, cancellationToken);
    }

    public async Task<IPagedResult<Organist>> GetAvailableOrganistsAsync(
        long congregationId,
        OrganistPagedAndSortedRequest request,
        CancellationToken cancellationToken = default,
        ISpecification<Organist>? specification = null)
    {
        specification = new OrganistSpecification(request);
        var resultAvailableOrganists = await repository.GetAvailableOrganistsAsync(
            request,
            cancellationToken,
            specification);
        
        var resultOrganistsByCongregation = await congregationRepository
            .GetByCongregationAsync(congregationId, cancellationToken);
        
        var availableOrganists = resultAvailableOrganists
            .Items
            .Where(x => !resultOrganistsByCongregation.Items
                .Any(co => co.OrganistId == x.Id))
            .ToList();

        return new PagedResult<Organist>(availableOrganists, resultAvailableOrganists.TotalCount);

    }
    
    public override async Task<Organist> CreateAsync(Organist entity, CancellationToken cancellationToken = default)
    {
        
        await using var transaction = await unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        try
        {
            if (entity.Phone != null 
                && !string.IsNullOrEmpty(entity.Phone.Number))
            {
                var phone = await phoneRepository.GetPhoneByNumberAsync(entity.Phone.Number, cancellationToken);
                if (phone == null)
                {
                    entity.Phone = await phoneRepository.CreateAsync(entity.Phone, cancellationToken);
                    await unitOfWork.SaveChangesAsync(cancellationToken);
                }
            }
            
            if (entity.Emails != null && entity.Emails.Any())
            {
                var createdEmails = new List<Email>();
                foreach (var email in entity.Emails)
                {
                    var created = await emailRepository.CreateAsync(email, cancellationToken);
                    createdEmails.Add(created);
                }
                entity.Emails = createdEmails;
            }

            if (entity.Cep != null && !string.IsNullOrEmpty(entity.Cep.ZipCode))
            {
                var cep = await cepService.GetCepByZipCodeAsync(entity.Cep.ZipCode, true, cancellationToken);
                if (cep == null && !string.IsNullOrWhiteSpace(entity.Cep.ZipCode))
                {
                    cep = new Cep()
                    {
                        ZipCode = entity.Cep.ZipCode,
                        Street = "",
                        District = "",
                        State = ""
                    };
                
                    cep = await cepService.CreateAsync(cep, cancellationToken);
                }
                
                entity.Cep = cep;
            }

            
            entity = await repository.CreateAsync(entity, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}