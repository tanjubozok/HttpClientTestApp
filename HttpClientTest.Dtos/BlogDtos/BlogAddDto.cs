namespace HttpClientTest.Dtos.BlogDtos;

public class BlogAddDto
{
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    public IFormFile ImagePath { get; set; }
    public int AppUserId { get; set; }
}
