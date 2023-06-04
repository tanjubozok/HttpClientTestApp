namespace HttpClientTest.Repository.Repositories;

public class GenericRepository<T> : IGenericRepository<T>
    where T : class, IBaseEntity, new()
{
    protected readonly DatabaseContext _context;
    protected readonly DbSet<T> _table;

    public GenericRepository(DatabaseContext context)
    {
        _context = context;
        _table = context.Set<T>();
    }

    public async Task<T?> AddAsync(T entity)
    {
        await _table
            .AddAsync(entity);

        return entity;
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        => await _table
        .AnyAsync(expression);

    public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        => await _table
        .CountAsync(expression);

    public void Delete(T entity)
        => _table
        .Remove(entity);

    public async Task<List<T>> GetAllAsync()
        => await _table
        .AsNoTracking()
        .ToListAsync();

    public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> keySelector)
        => await _table
        .OrderByDescending(keySelector)
        .AsNoTracking()
        .ToListAsync();

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        => await _table
        .Where(expression)
        .AsNoTracking()
        .ToListAsync();

    public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> expression, Expression<Func<T, TKey>> keySelector)
        => await _table
        .Where(expression)
        .OrderByDescending(keySelector)
        .AsNoTracking()
        .ToListAsync();

    public async Task<T?> GetByIdAsync(object id)
        => await _table
        .FindAsync(id);

    public async Task<T?> GetOneAsync(Expression<Func<T, bool>> expression)
        => await _table
        .Where(expression)
        .AsNoTracking()
        .FirstOrDefaultAsync();

    public void Update(T entity, T unchanged)
        => _context
        .Entry(unchanged)
        .CurrentValues
        .SetValues(entity);
}
