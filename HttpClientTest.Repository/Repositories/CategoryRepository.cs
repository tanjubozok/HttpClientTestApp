namespace HttpClientTest.Repository.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(DatabaseContext context)
        : base(context)
    {
    }
}
