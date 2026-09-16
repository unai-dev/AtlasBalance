using AtlasBalance.Application.DTOs.LanguageResource;
using AtlasBalance.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlasBalance.API.Controllers;

[ApiController]
[Route("api/language-resources")]
[Authorize]
public class LanguageResourcesController : ControllerBase
{
    private readonly ILanguageResourceService _service;

    public LanguageResourcesController(ILanguageResourceService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LanguageResourceReadDto>>> GetAll() => Ok(await _service.GetAll());

    [HttpGet("{id}")]
    public async Task<ActionResult<LanguageResourceReadDto>> GetOne(int id) => Ok(await _service.GetOne(id));

    [HttpGet("{id}/relations")]
    public async Task<ActionResult<LanguageResourceReadWithRelationsDto>> GetOneWithRelations(int id) => Ok(await _service.GetOneWithRelations(id));

    [HttpPost]
    public async Task<ActionResult<LanguageResourceReadDto>> Create([FromBody] LanguageResourceCreateDto dto)
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
