namespace HttpClientTest.Entities.Models;

public class BlogCategory : IBaseEntity
{
    public int Id { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public int BlogId { get; set; }
    public Blog? Blog { get; set; }
}
