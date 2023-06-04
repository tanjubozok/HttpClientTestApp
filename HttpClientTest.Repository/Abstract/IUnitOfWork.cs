namespace HttpClientTest.Repository.Abstract;

public interface IUnitOfWork
{
    void SaveChanges();
    Task SaveChangesAsync();
}
