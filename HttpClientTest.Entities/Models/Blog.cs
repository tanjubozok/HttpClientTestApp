namespace HttpClientTest.Entities.Models;

public class Blog : IBaseEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public int AppUserId { get; set; }
    public AppUser? AppUser { get; set; }

    public List<BlogCategory>? BlogCategories { get; set; }
    public List<Comment>? Comments { get; set; }
}
