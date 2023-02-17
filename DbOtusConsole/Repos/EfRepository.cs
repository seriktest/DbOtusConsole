using DbOtusConsole.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DbOtusConsole.Repos;

public class EfRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly DbContext _dbContext;

    public EfRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync().ConfigureAwait(false);
    }

    public async Task<T?> GetAsync(Guid id)
    {
        return await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
    }

    public async Task AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity).ConfigureAwait(false);
        await _dbContext.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task UpdateAsync(T entity)
    {
        await _dbContext.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entry = await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        if (entry != null) _dbContext.Set<T>().Remove(entry);
        await _dbContext.SaveChangesAsync().ConfigureAwait(false);
    }
}