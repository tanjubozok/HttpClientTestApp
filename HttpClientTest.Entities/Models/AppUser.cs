namespace HttpClientTest.Entities.Models;

public class AppUser : IBaseEntity
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;

    public List<Blog>? Blogs { get; set; }
}
