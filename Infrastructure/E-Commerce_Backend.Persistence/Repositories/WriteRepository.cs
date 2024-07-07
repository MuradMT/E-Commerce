
namespace E_Commerce_Backend.Persistence.Repositories;

public class WriteRepository<T>(DbContext _context): IWriteRepository<T> where T : class, IEntityBase, new()
{
     DbSet<T> Table { get => _context.Set<T>();}

    public async Task AddAsync(T entity)
    {
        await Table.AddAsync(entity);
    }

    public async Task AddRangeAsync(IList<T> entities)
    {
        await Table.AddRangeAsync(entities);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        await Task.Run(() => Table.Update(entity));
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        await Task.Run(() => Table.Remove(entity));
    }
    
}
