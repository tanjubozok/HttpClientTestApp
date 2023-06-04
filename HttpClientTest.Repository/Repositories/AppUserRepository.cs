namespace HttpClientTest.Repository.Repositories;

public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
{
    public AppUserRepository(DatabaseContext context)
        : base(context)
    {
    }
}
