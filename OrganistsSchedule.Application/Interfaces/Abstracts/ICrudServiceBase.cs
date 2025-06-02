using OrganistsSchedule.Application.Services;
using OrganistsSchedule.Application.Services.Requests;

namespace OrganistsSchedule.Application.Interfaces;

public interface ICrudServiceBase<TEntity, TDto, TRequestDto, TCreateDto, TUpdateDto>
{
    Task<PagedResultDto<TDto>> GetAllAsync(TRequestDto request, CancellationToken cancellationToken = default, ISpecification<TEntity>? spec = null);
    Task<TDto?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<TDto> CreateAsync(TCreateDto dto, CancellationToken cancellationToken = default);
    Task<TDto> UpdateAsync(TUpdateDto dto, long id, CancellationToken cancellationToken = default);
    Task<TDto> DeleteAsync(long id, CancellationToken cancellationToken = default);
}

public interface ICrudServiceBase<TEntity, TDto, TRequestDto, TCreateDto>
    : ICrudServiceBase<TEntity, TDto, TRequestDto, TCreateDto, TCreateDto>
{
}

public interface ICrudServiceBase<TEntity,TDto, TRequestDto>
    : ICrudServiceBase<TEntity, TDto, TRequestDto, TDto, TDto>
{
}