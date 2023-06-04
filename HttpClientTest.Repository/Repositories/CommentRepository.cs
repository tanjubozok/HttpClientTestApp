namespace HttpClientTest.Repository.Repositories;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    public CommentRepository(DatabaseContext context)
        : base(context)
    {
    }
}
