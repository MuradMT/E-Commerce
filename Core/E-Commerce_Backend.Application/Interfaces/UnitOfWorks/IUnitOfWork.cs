using E_Commerce_Backend.Application.Interfaces.Repositories;
using E_Commerce_Backend.Domain.Common;

namespace E_Commerce_Backend.Application.UnitOfWorks;

public interface IUnitOfWork:IAsyncDisposable
{
     IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new();

     IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();

     Task<int> SaveAsync();

     int Save();
}
