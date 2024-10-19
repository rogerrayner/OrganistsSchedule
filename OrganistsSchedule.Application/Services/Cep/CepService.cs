using AutoMapper;
using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Application.Interfaces;
using OrganistsSchedule.Domain.Entities;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Application.Services;

public class CepService(ICepRepository cepRepository, IMapper mapper)
    : CrudServiceBase<CepDto, Cep>(mapper, cepRepository), 
        ICepService
{
    private readonly IMapper _mapper = mapper;

    public async Task<CepDto> GetCepByZipCodeAsync(string cep)
    {
        var entity = await cepRepository
            .GetCepByZipCodeAsync(cep);
        return _mapper.Map<CepDto>(entity);
    }

    public Task<CepDto> GetCepByOnlineServiceAsync(string cep)
    {
        throw new NotImplementedException();
    }
}