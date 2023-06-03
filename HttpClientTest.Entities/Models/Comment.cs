namespace HttpClientTest.Entities.Models;

public class Comment : IBaseEntity
{
    public int Id { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public string AuthorEmail { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public int? ParentCommentId { get; set; }
    public Comment? ParentComment { get; set; }

    public List<Comment>? SubComment { get; set; }
}
