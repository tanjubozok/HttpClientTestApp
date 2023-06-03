namespace HttpClientTest.Entities.Models;

public class AppRole : IBaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
