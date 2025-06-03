using System.Data;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using System.Text.RegularExpressions;
using OrganistsSchedule.Application.Specifications;
using OrganistsSchedule.Domain.Exceptions;
using OrganistsSchedule.Domain.Interfaces;
using ViaCep;

namespace OrganistsSchedule.Application.Services;

public class CepService(ICepRepository repository, 
    IMapper mapper, 
    IServiceProvider container, 
    ICityRepository cityRepository, 
    ICountryRepository countryRepository,
    IUnitOfWork unitOfWork)
    : CrudServiceBase<Cep, 
            CepDto, 
            CepPagedAndSortedRequest,
            CepCreateUpdateRequestDto>(mapper, repository, unitOfWork), 
        ICepService
{
    public override Task<PagedResultDto<CepDto>> GetAllAsync(CepPagedAndSortedRequest request, 
        CancellationToken cancellationToken,
        ISpecification<Cep>? specification = null)
    { 
        specification = new CepSpecification(request);
        return base.GetAllAsync(request, cancellationToken, specification);
    }

    public async Task<CepDto> GetCepByZipCodeAsync(string zipCode,
        bool isPost = false,
        CancellationToken cancellationToken = default)
    {
        try 
        {
            var entity =
                mapper.Map<CepDto>(await repository
                    .GetCepByZipCodeAsync(zipCode));

            if (entity == null)
            {
                try
                {
                    entity = await GetCepByOnlineServiceAsync(zipCode, isPost);
                }
                catch (Exception e)
                {
                    throw new BusinessException(Messages.Format(Messages.IntegrationError, "Via Cep"));
                }
            }
            
            if (entity == null)
                throw new NotFoundException(Messages.Format(Messages.NotFound, "Cep"));
            
            return entity;
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public async Task<CepDto> GetCepByOnlineServiceAsync(string zipCode, 
        bool isPost = false, 
        CancellationToken cancellationToken = default)
    {
        Cep? cep = null;
        ViaCepResult? viaCepResult = null;
        var viaCepClient = container.GetService<IViaCepClient>();
        viaCepResult = await viaCepClient.SearchAsync(zipCode, cancellationToken);
        if (viaCepResult != null
            && !string.IsNullOrEmpty(viaCepResult.ZipCode))
        {
            cep = new Cep
            {
                ZipCode = Regex.Replace(viaCepResult.ZipCode ?? string.Empty, @"\D", ""),
                Street = viaCepResult.Street,
                District = viaCepResult.Neighborhood
            };

            var country = await countryRepository.GetByNameAsync("Brasil");
            var city = await cityRepository.GetByNameAsync(viaCepResult.City);
            if (city == null)
            {
                City cityCreate = new City()
                {
                    Name = viaCepResult.City,
                    CountryId = country.Id
                };
                city = await cityRepository.CreateAsync(cityCreate, cancellationToken);
                await unitOfWork.SaveChangesAsync(cancellationToken);
            }
            
            if (isPost)
            {
                cep.CityId = city.Id;
                await repository.CreateAsync(cep, cancellationToken);
                await unitOfWork.SaveChangesAsync(cancellationToken);
            }
            cep.City = city;
        }

        return mapper.Map<CepDto>(cep);
    }
}