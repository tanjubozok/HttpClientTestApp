namespace HttpClientTest.Service.Abstract;

public interface IBlogService
{
    Task<IResponse<List<BlogListDto>>> GetAllAsync();
    Task<IResponse<BlogListDto>> GetByIdAsync(int blogId);
    Task<IResponse<BlogAddDto>> AddAsync(BlogAddDto dto);
    Task<IResponse> UpdateAsync(BlogUpdateDto dto);
    Task<IResponse> DeleteAsync(int id);
}
