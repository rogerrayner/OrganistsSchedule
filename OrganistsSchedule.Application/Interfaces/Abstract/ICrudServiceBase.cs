namespace OrganistsSchedule.Application.Interfaces;

public interface ICrudServiceBase<TDto, TEntity> 
    where TDto : class
    where TEntity : class
{
    Task<IEnumerable<TDto>> GetAllAsync();
    Task<TDto?> GetByIdAsync(long id);
    Task<TDto> CreateAsync(TDto dto);
    Task<TDto> UpdateAsync(TDto dto);
    Task<TDto> DeleteAsync(long id);
}