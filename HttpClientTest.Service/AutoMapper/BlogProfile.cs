namespace HttpClientTest.Service.AutoMapper;

public class BlogProfile : Profile
{
    public BlogProfile()
    {
        CreateMap<Blog, BlogListDto>().ReverseMap();
        CreateMap<Blog, BlogAddDto>().ReverseMap();
        CreateMap<Blog, BlogUpdateDto>().ReverseMap();
    }
}
