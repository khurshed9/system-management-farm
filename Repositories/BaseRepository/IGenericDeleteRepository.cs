using SystemManagementFactory.Domain.Entities;

namespace SystemManagementFactory.Repositories.BaseRepository;

public interface IGenericDeleteRepository<T> where T : BaseEntity
{
    Task DeleteAsync(T value);

    Task DeleteAsync(IEnumerable<T> values);
}