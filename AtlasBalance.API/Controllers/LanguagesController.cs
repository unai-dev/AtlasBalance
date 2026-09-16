using AtlasBalance.Application.DTOs.Language;
using AtlasBalance.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlasBalance.API.Controllers;

[ApiController]
[Route("api/languages")]
[Authorize]
public class LanguagesController : ControllerBase
{
    private readonly ILanguageService _service;

    public LanguagesController(ILanguageService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LanguageReadDto>>> GetAll() => Ok(await _service.GetAll());

    [HttpGet("{id}")]
    public async Task<ActionResult<LanguageReadDto>> GetOne(int id) => Ok(await _service.GetOne(id));

    [HttpGet("{id}/relations")]
    public async Task<ActionResult<LanguageReadWithRelationsDto>> GetOneWithRelations(int id) => Ok(await _service.GetOneWithRelations(id));

    [HttpPost]
    public async Task<ActionResult<LanguageReadDto>> Create([FromBody] LanguageCreateDto dto)
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
