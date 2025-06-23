using OrganistsSchedule.Application.DTOs;
using OrganistsSchedule.Domain.Interfaces;

namespace OrganistsSchedule.Bff.Interfaces;

public interface ICrudBffServiceBase<TEntity, 
    TDto,
    TRequest,
    TCreateDto, 
    TUpdateDto>
    where TRequest : class, IPagedAndSortedRequest
{
    Task<PagedResultDto<TDto>> GetAllAsync(
        TRequest request, 
        CancellationToken cancellationToken = default, 
        ISpecification<TEntity>? spec = null);

    Task<TDto?> GetByIdAsync(
        long id, 
        CancellationToken cancellationToken = default);

    Task<TDto> CreateAsync(
        TCreateDto dto, 
        CancellationToken cancellationToken = default);

    Task<TDto> UpdateAsync(
        TUpdateDto dto, 
        long id, 
        CancellationToken cancellationToken = default);

    Task<TDto> DeleteAsync(
        long id, 
        CancellationToken cancellationToken = default);
}

public interface ICrudBffServiceBase<TEntity, 
    TDto, 
    TRequest, 
    TCreateDto>
    : ICrudBffServiceBase<TEntity, TDto, TRequest, TCreateDto, TCreateDto>
    where TRequest : class, IPagedAndSortedRequest
{
}

public interface ICrudBffServiceBase<TEntity,
    TDto,
    TRequest>
    : ICrudBffServiceBase<TEntity, TDto, TRequest, TDto, TDto>
    where TRequest : class, IPagedAndSortedRequest
{
}