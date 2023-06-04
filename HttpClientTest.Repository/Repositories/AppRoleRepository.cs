namespace HttpClientTest.Repository.Repositories;

public class AppRoleRepository : GenericRepository<AppRole>, IAppRoleRepository
{
    public AppRoleRepository(DatabaseContext context)
        : base(context)
    {
    }
}
