namespace HttpClientTest.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogsController : ControllerBase
{
    private readonly IBlogService _blogService;

    public BlogsController(IBlogService blogService)
    {
        _blogService = blogService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _blogService.GetAllAsync();
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
        var result = await _blogService.GetByIdAsync(id);
        if (result.ResponseTypes == ResponseType.Success)
            return Ok(result.Data);
        else if (result.ResponseTypes == ResponseType.NotFound)
            return NotFound(result.Message);
        else
            return BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> Add(BlogAddDto dto)
    {
        var result = await _blogService.AddAsync(dto);
        if (result.ResponseTypes == ResponseType.Success)
            return Ok(result.Data);
        else if (result.ResponseTypes == ResponseType.SaveError)
            return BadRequest(result.Message);
        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> Update(BlogUpdateDto dto)
    {
        var result = await _blogService.UpdateAsync(dto);
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
        var result = await _blogService.DeleteAsync(id);
        if (result.ResponseTypes == ResponseType.Success)
            return NoContent();
        else if (result.ResponseTypes == ResponseType.NotFound)
            return NotFound(result.Message);
        else if (result.ResponseTypes == ResponseType.SaveError)
            return BadRequest(result.Message);
        return BadRequest();
    }
}
