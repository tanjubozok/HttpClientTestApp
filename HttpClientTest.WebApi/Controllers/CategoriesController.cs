using HttpClientTest.Common.ComplexTypes;
using HttpClientTest.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

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
}
