namespace HttpClientTest.Repository.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _context;

    public UnitOfWork(DatabaseContext context)
        => _context = context;

    public void SaveChanges()
        => _context
        .SaveChanges();

    public async Task<int> SaveChangesAsync()
        => await _context
        .SaveChangesAsync();
}
