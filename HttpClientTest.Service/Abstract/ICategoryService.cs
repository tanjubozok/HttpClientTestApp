namespace HttpClientTest.Service.Abstract;

public interface ICategoryService
{
    Task<IResponse<List<CategoryListDto>>> GetAllAsync();
    Task<IResponse<CategoryAddDto>> AddAsync(CategoryAddDto dto);
    Task<IResponse> UpdateAsync(CategoryUpdateDto dto);
    Task<IResponse> DeleteAsync(int id);
}
