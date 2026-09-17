using AtlasBalance.Application.DTOs.LanguageResource;
using AtlasBalance.Application.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlasBalance.API.Controllers;

[ApiController]
[Route("api/language-resources")]
[Authorize]
/// <summary>
/// Controller: LanguageResources
/// - Provee endpoints CRUD para recursos de idioma (LanguageResource).
/// - Delegación a ILanguageResourceService; controla la validación de entrada y respuesta HTTP.
/// </summary>
public class LanguageResourcesController : ControllerBase
{
    private readonly ILanguageResourceService _service;

    public LanguageResourcesController(ILanguageResourceService service) => _service = service;

    /// <summary>
    /// Obtiene todos los recursos de idioma.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LanguageResourceReadDto>>> GetAll() => Ok(await _service.GetAll());

    /// <summary>
    /// Obtiene todos los recursos del idioma del usuario actual.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LanguageResourceReadDto>>> GetAllWithLanguageID()
        => Ok(await _service.GetAllWithLanguageID());

    /// <summary>
    /// Obtiene un recurso de idioma por ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<LanguageResourceReadDto>> GetOne(int id) => Ok(await _service.GetOne(id));

    /// <summary>
    /// Obtiene un recurso por ID incluyendo relaciones (p.ej. Language asociado).
    /// </summary>
    [HttpGet("{id}/relations")]
    public async Task<ActionResult<LanguageResourceReadWithRelationsDto>> GetOneWithRelations(int id) => Ok(await _service.GetOneWithRelations(id));

    /// <summary>
    /// Crea un nuevo recurso de idioma.
    /// - Valida que el idioma exista y delega la creación al servicio.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<LanguageResourceReadDto>> Create([FromBody] LanguageResourceCreateDto dto)
    {
        var created = await _service.Create(dto);
        return CreatedAtAction(nameof(GetOne), new { id = created.ID }, created);
    }

    /// <summary>
    /// Elimina un recurso de idioma por ID.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }
}
