namespace HttpClientTest.Entities.Models;

public class Category : IBaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<BlogCategory>? BlogCategories { get; set; }
}
