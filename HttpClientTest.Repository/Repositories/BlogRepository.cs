namespace HttpClientTest.Repository.Repositories;

public class BlogRepository : GenericRepository<Blog>, IBlogRepository
{
    public BlogRepository(DatabaseContext context)
        : base(context)
    {
    }
}
