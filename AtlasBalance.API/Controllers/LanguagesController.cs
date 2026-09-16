using AtlasBalance.Application.DTOs.Language;
using AtlasBalance.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlasBalance.API.Controllers;

[ApiController]
[Route("api/languages")]
[Authorize]
/// <summary>
/// Controller: Languages
/// - Gestiona los endpoints CRUD para idiomas (Language).
/// - Valida DTOs y delega la lógica a ILanguageService.
/// - Mantiene el controlador delgado y orientado a transporte HTTP.
/// </summary>
public class LanguagesController : ControllerBase
{
    private readonly ILanguageService _service;

    public LanguagesController(ILanguageService service) => _service = service;

    /// <summary>
    /// Obtiene todos los idiomas.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LanguageReadDto>>> GetAll() => Ok(await _service.GetAll());

    /// <summary>
    /// Obtiene un idioma por su identificador.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<LanguageReadDto>> GetOne(int id) => Ok(await _service.GetOne(id));

    /// <summary>
    /// Obtiene un idioma por ID incluyendo entidades relacionadas (p.ej. recursos asociados).
    /// </summary>
    [HttpGet("{id}/relations")]
    public async Task<ActionResult<LanguageReadWithRelationsDto>> GetOneWithRelations(int id) => Ok(await _service.GetOneWithRelations(id));

    /// <summary>
    /// Crea un nuevo idioma.
    /// - Valida el DTO y delega la persistencia al servicio de aplicación.
    /// - Devuelve 201 con el recurso creado.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<LanguageReadDto>> Create([FromBody] LanguageCreateDto dto)
    {
        var created = await _service.Create(dto);
        return CreatedAtAction(nameof(GetOne), new { id = created.ID }, created);
    }

    /// <summary>
    /// Elimina un idioma por ID.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }
}
