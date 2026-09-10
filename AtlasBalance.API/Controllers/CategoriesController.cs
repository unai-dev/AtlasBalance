using AtlasBalance.Application.DTOs.Category;
using AtlasBalance.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlasBalance.API.Controllers;

[ApiController]
[Route("api/categories")]
[Authorize]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoriesController(ICategoryService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryReadDto>>> GetAll() => Ok(await _service.GetAll());

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryReadDto>> GetOne(int id) => Ok(await _service.GetOne(id));

    [HttpGet("{id}/relations")]
    public async Task<ActionResult<CategoryReadWithRelationsDto>> GetOneWithRelations(int id) => Ok(await _service.GetOneWithRelations(id));

    [HttpPost]
    public async Task<ActionResult<CategoryReadDto>> Create([FromBody] CategoryCreateDto dto)
    {
        var created = await _service.Create(dto);
        return CreatedAtAction(nameof(GetOne), new { id = created.ID }, created);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }
}
