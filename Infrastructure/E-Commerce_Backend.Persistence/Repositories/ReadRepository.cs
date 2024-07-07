

namespace E_Commerce_Backend.Persistence.Repositories;

public class ReadRepository<T>(AppDbContext _context) : IReadRepository<T> where T : class, IEntityBase, new()
{
    DbSet<T> Table { get => _context.Set<T>(); }

    public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
    {
        IQueryable<T> queryable = Table;

        if (!enableTracking) queryable = queryable.AsNoTracking();

        if (include is not null) queryable = include(queryable);

        if (predicate is not null) queryable = queryable.Where(predicate);

        if (orderBy is not null)
            return await orderBy(queryable).ToListAsync();

        return await queryable.ToListAsync();

    }

    public async Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
    {
        IQueryable<T> queryable = Table;

        if (!enableTracking) queryable = queryable.AsNoTracking();

        if (include is not null) queryable = include(queryable);

        if (predicate is not null) queryable = queryable.Where(predicate);

        var skipSize = (currentPage - 1) * pageSize;

        if (orderBy is not null)
        {
            return await orderBy(queryable).Skip(skipSize).Take(pageSize).ToListAsync();
        }

        return await queryable.Skip(skipSize).Take(pageSize).ToListAsync();
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
    {
        IQueryable<T> queryable = Table;

        if (!enableTracking) queryable = queryable.AsNoTracking();

        if (include is not null) queryable = include(queryable);

        return await queryable.FirstOrDefaultAsync(predicate);
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
    {
        Table.AsNoTracking();

        if (predicate is not null) Table.Where(predicate);
    
        return await Table.CountAsync();
    }

    public  IQueryable<T> Find(Expression<Func<T, bool>> predicate,bool enableTracking = false)
    {
        if (!enableTracking) Table.AsNoTracking();

        return  Table.Where(predicate);
    }
}
