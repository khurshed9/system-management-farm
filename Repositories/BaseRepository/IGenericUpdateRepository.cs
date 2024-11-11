using SystemManagementFactory.Domain.Entities;

namespace SystemManagementFactory.Repositories.BaseRepository;

public interface IGenericUpdateRepository<T> where T : BaseEntity
{
    Task UpdateAsync(T value);
    
    Task UpdateRangeAsync(IEnumerable<T> values);
}