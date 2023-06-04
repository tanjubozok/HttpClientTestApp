namespace HttpClientTest.Repository.Abstract;

public interface IGenericRepository<T>
    where T : class, IBaseEntity, new()
{
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> keySelector);
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression);
    Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> expression, Expression<Func<T, TKey>> keySelector);

    Task<T?> GetOneAsync(Expression<Func<T, bool>> expression);
    Task<T?> GetByIdAsync(object id);

    Task<int> CountAsync(Expression<Func<T, bool>> expression);
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

    Task<T?> AddAsync(T entity);

    void Update(T entity, T unchanged);
    void Delete(T entity);
}
