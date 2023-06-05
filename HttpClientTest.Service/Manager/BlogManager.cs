namespace HttpClientTest.Service.Manager;

public class BlogManager : IBlogService
{
    private readonly IBlogRepository _blogRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public BlogManager(IBlogRepository blogRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<BlogAddDto>> AddAsync(BlogAddDto dto)
    {
        var blog = _mapper.Map<Blog>(dto);
        await _blogRepository.AddAsync(blog);

        int result = await _unitOfWork.SaveChangesAsync();
        if (result > 0)
            return new Response<BlogAddDto>(ResponseType.Success, dto);

        return new Response<BlogAddDto>(ResponseType.SaveError, "Ekleme sırasında bir hata oluştu.");
    }

    public async Task<IResponse> DeleteAsync(int id)
    {
        var blog = await _blogRepository.GetByIdAsync(id);
        if (blog is null)
            return new Response(ResponseType.NotFound, "Blog bulunamadı");

        _blogRepository.Delete(blog);

        int result = await _unitOfWork.SaveChangesAsync();
        if (result > 0)
            return new Response(ResponseType.Success, "Silindi");

        return new Response(ResponseType.SaveError, "Silme sırasında bir hata oluştu.");
    }

    public async Task<IResponse<List<BlogListDto>>> GetAllAsync()
    {
        var list = await _blogRepository.GetAllAsync();
        if (list is null)
            return new Response<List<BlogListDto>>(ResponseType.NotFound, "Blog bulunamadı");

        var dto = _mapper.Map<List<BlogListDto>>(list);

        return new Response<List<BlogListDto>>(ResponseType.Success, dto);
    }

    public async Task<IResponse<BlogListDto>> GetByIdAsync(int blogId)
    {
        var blog = await _blogRepository.GetByIdAsync(blogId);
        if (blog is null)
            return new Response<BlogListDto>(ResponseType.NotFound, "Blog bulunamadı");

        var dto = _mapper.Map<BlogListDto>(blog);

        return new Response<BlogListDto>(ResponseType.Success, dto);
    }

    public async Task<IResponse> UpdateAsync(BlogUpdateDto dto)
    {
        var unchanged = await _blogRepository.GetByIdAsync(dto.Id);
        if (unchanged is null)
            return new Response(ResponseType.NotFound, "Blog bulunamadı");

        var blog = _mapper.Map<Blog>(dto);

        _blogRepository.Update(blog, unchanged);

        int result = await _unitOfWork.SaveChangesAsync();
        if (result > 0)
            return new Response(ResponseType.Success, "Güncellendi");

        return new Response(ResponseType.SaveError, "Güncelleme sırasında bir hata oluştu.");
    }
}
