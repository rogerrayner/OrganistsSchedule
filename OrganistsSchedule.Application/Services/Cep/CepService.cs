using Microsoft.Extensions.DependencyInjection;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Application.Specifications;
using OrganistsSchedule.Domain.Interfaces;
using OrganistsSchedule.Domain.Interfaces.Results;
using OrganistsSchedule.Domain.Utils;
using ViaCep;

namespace OrganistsSchedule.Application.Services;

public class CepService(
    ICepRepository<CepPagedAndSortedRequest> repository, 
    IServiceProvider container, 
    ICityRepository<CityPagedAndSortedRequest> cityRepository, 
    ICountryRepository<CountryPagedAndSortedRequest> countryRepository,
    IUnitOfWork unitOfWork)
    : CrudServiceBase<Cep, CepPagedAndSortedRequest>(repository,
            unitOfWork), ICepService
{
    public override Task<IPagedResult<Cep>> GetAllAsync(CepPagedAndSortedRequest request, 
        CancellationToken cancellationToken,
        ISpecification<Cep>? specification = null)
    { 
        specification = new CepSpecification(request);
        return base.GetAllAsync(request, cancellationToken, specification);
    }

    public override async Task<Cep> CreateAsync(Cep entity, 
        CancellationToken cancellationToken = default)
    {
        try
        {
            var cep = await GetCepByZipCodeAsync(entity.ZipCode, false, cancellationToken);

            if (cep != null)
                ErrorHandler.ThrowBusinessException(Messages.AlreadyExists, "Cep");
            
            var cepByOnlineService = await GetCepByOnlineServiceAsync(entity.ZipCode, cancellationToken);
            
            if (cepByOnlineService == null)
                ErrorHandler.ThrowBusinessException(Messages.CepCreateNotFound);
            
            cep = new Cep
            {
                ZipCode = cepByOnlineService.ZipCode ?? "",
                Street = cepByOnlineService.Street,
                District = cepByOnlineService.District,
                State = cepByOnlineService.State,
                City = cepByOnlineService.City
            };

            await repository.CreateAsync(cep, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return cep;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Cep> GetCepByZipCodeAsync(string zipCode,
        bool searchOnline = true,
        CancellationToken cancellationToken = default)
    {
        try 
        {
            var entity =
                await repository
                    .GetCepByZipCodeAsync(zipCode, cancellationToken);

            if (entity == null
                && searchOnline)
            {
                entity = await GetCepByOnlineServiceAsync(zipCode, cancellationToken);
                if (entity == null)
                    ErrorHandler.ThrowBusinessException(Messages.CepCreateNotFound);
            }
            
            return entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<Cep> GetCepByOnlineServiceAsync(string zipCode, 
        CancellationToken cancellationToken = default)
    {
        Cep? cep = null;
        var viaCepClient = container.GetService<IViaCepClient>();
        var viaCepResult = await viaCepClient.SearchAsync(zipCode, cancellationToken);
        
        if (viaCepResult != null)
        {
            var country = await countryRepository.GetByNameAsync("Brasil")
                          ?? new Country { Name = "Brasil" };

            var city = await cityRepository.GetByNameAsync(viaCepResult.City)
                       ?? new City { Name = viaCepResult.City, Country = country };
            
            cep = new Cep
            {
                ZipCode = viaCepResult.ZipCode,
                Street = viaCepResult.Street,
                District = viaCepResult.Neighborhood,
                State = viaCepResult.StateInitials,
                City = city
            };
        } else ErrorHandler.ThrowBusinessException(Messages.IntegrationError, "Via Cep");

        return cep;
    }

    public Task<List<string>> GetDistrictsByCityIdAsync(
        long cityId,
        CancellationToken cancellationToken = default
        )
    {
        return repository.GetDistrictsByCityIdAsync(cityId, cancellationToken);
    }
}