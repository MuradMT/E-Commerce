using E_Commerce_Backend.Domain.Common;

namespace E_Commerce_Backend.Application.Interfaces.Repositories;

public interface IWriteRepository<T> where T : class, IEntityBase, new()
{
     Task AddAsync(T entity);

     Task AddRangeAsync(IList<T> entities);
     
     /// <summary>
     /// We will do soft delete and update operations here
     /// </summary>
     Task<T> UpdateAsync(T entity);

     /// <summary>
     /// We will do hard delete here
     /// </summary>
     Task HardDeleteAsync(T entity);

     Task HardDeleteRangeAsync(IList<T> entities);
}
