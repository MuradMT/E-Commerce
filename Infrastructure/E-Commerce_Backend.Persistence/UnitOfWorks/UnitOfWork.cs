namespace E_Commerce_Backend.Persistence.UnitOfWorks;

/// <summary>
/// Unit of work pattern helps to encapsulate database transactions.
/// It tracks operations to be performed on the database.
/// It can do commit or rollback the transaction according to the situation.
/// Works with specific dbcontext such as appdbcontext in our app.
/// </summary>
public class UnitOfWork(AppDbContext _context): IUnitOfWork
{
    public async ValueTask DisposeAsync()=>await _context.DisposeAsync();

    public int Save()=>_context.SaveChanges();

    public async Task<int> SaveAsync()=>await _context.SaveChangesAsync();

    IReadRepository<T> IUnitOfWork.GetReadRepository<T>()=> new ReadRepository<T>(_context);

    IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(_context);
}
