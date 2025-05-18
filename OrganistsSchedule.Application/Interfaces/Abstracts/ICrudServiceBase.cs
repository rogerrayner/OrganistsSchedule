using System.Linq.Expressions;
using OrganistsSchedule.Application.Services;

namespace OrganistsSchedule.Application.Interfaces;

public interface ICrudServiceBase<TEntity, TDto, TCreateDto, TUpdateDto>
{
    Task<PagedResultDto<TDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<TDto?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<TDto> CreateAsync(TCreateDto dto, CancellationToken cancellationToken = default);
    Task<TDto> UpdateAsync(TUpdateDto dto, long id, CancellationToken cancellationToken = default);
    Task<TDto> DeleteAsync(long id, CancellationToken cancellationToken = default);
}

public interface ICrudServiceBase<TEntity, TDto, TCreateDto>
    : ICrudServiceBase<TEntity, TDto, TCreateDto, TCreateDto>
{
}

public interface ICrudServiceBase<TEntity,TDto>
    : ICrudServiceBase<TEntity, TDto, TDto, TDto>
{
}