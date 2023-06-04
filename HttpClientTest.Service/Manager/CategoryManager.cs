namespace HttpClientTest.Service.Manager;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<CategoryAddDto>> AddAsync(CategoryAddDto dto)
    {
        var category = _mapper.Map<Category>(dto);

        await _categoryRepository.AddAsync(category);

        var result = await _unitOfWork.SaveChangesAsync();
        if (result > 0)
            return new Response<CategoryAddDto>(ResponseType.Success, dto);

        return new Response<CategoryAddDto>(ResponseType.SaveError, "Ekleme sırasında bir hata oluştu");
    }

    public async Task<IResponse> DeleteAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category is null)
            return new Response(ResponseType.NotFound, $"Kategori bulunamadı");

        _categoryRepository.Delete(category);

        var result = await _unitOfWork.SaveChangesAsync();
        if (result > 0)
            return new Response(ResponseType.Success, $"{category.Name} silindi");

        return new Response(ResponseType.SaveError, "Silme sırasında bir hata oluştu");
    }

    public async Task<IResponse<List<CategoryListDto>>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        if (categories is null)
            return new Response<List<CategoryListDto>>(ResponseType.NotFound, $"Kategori bulunamadı");

        var dto = _mapper.Map<List<CategoryListDto>>(categories);

        return new Response<List<CategoryListDto>>(ResponseType.Success, dto);
    }

    public async Task<IResponse> UpdateAsync(CategoryUpdateDto dto)
    {
        var updatedCategory = await _categoryRepository.GetByIdAsync(dto.Id);
        if (updatedCategory is null)
            return new Response(ResponseType.NotFound, $"Kategori bulunamadı");

        var category = _mapper.Map<Category>(dto);
        _categoryRepository.Update(category, updatedCategory);

        var result = await _unitOfWork.SaveChangesAsync();
        if (result > 0)
            return new Response(ResponseType.Success, $"{category.Name} güncellendi");

        return new Response(ResponseType.SaveError, "Güncelleme sırasında bir hata oluştu");
    }
}
