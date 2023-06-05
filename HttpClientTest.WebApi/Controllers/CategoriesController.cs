namespace HttpClientTest.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _categoryService.GetAllAsync();
        if (result.ResponseTypes == ResponseType.Success)
            return Ok(result.Data);
        else if (result.ResponseTypes == ResponseType.NotFound)
            return NotFound(result.Message);
        else
            return BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _categoryService.GetByIdAsync(id);
        if (result.ResponseTypes == ResponseType.Success)
            return Ok(result.Data);
        else if (result.ResponseTypes == ResponseType.NotFound)
            return NotFound(result.Message);
        else
            return BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> Add(CategoryAddDto dto)
    {
        var result = await _categoryService.AddAsync(dto);
        if (result.ResponseTypes == ResponseType.Success)
            return Ok(result.Data);
        else if (result.ResponseTypes == ResponseType.SaveError)
            return BadRequest(result.Message);
        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> Update(CategoryUpdateDto dto)
    {
        var result = await _categoryService.UpdateAsync(dto);
        if (result.ResponseTypes == ResponseType.Success)
            return NoContent();
        else if (result.ResponseTypes == ResponseType.NotFound)
            return NotFound(result.Message);
        else if (result.ResponseTypes == ResponseType.SaveError)
            return BadRequest(result.Message);
        return BadRequest();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _categoryService.DeleteAsync(id);
        if (result.ResponseTypes == ResponseType.Success)
            return NoContent();
        else if (result.ResponseTypes == ResponseType.NotFound)
            return NotFound(result.Message);
        else if (result.ResponseTypes == ResponseType.SaveError)
            return BadRequest(result.Message);
        return BadRequest();
    }
}
