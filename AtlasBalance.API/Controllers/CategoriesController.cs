using AtlasBalance.Application.DTOs.Category;
using AtlasBalance.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlasBalance.API.Controllers;

[ApiController]
[Route("api/categories")]
[Authorize]
/// <summary>
/// Controller: Categories
/// - Gestiona endpoints CRUD para categorías.
/// - Controlador delgado que delega la lógica a ICategoryService.
/// - Devuelve DTOs y códigos HTTP estandarizados.
/// </summary>
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoriesController(ICategoryService service) => _service = service;

    /// <summary>
    /// Obtiene todas las categorías.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryReadDto>>> GetAll() => Ok(await _service.GetAll());

    /// <summary>
    /// Obtiene una categoría por ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryReadDto>> GetOne(int id) => Ok(await _service.GetOne(id));

    /// <summary>
    /// Obtiene una categoría por ID incluyendo relaciones (p.ej. expenses).
    /// </summary>
    [HttpGet("{id}/relations")]
    public async Task<ActionResult<CategoryReadWithRelationsDto>> GetOneWithRelations(int id) => Ok(await _service.GetOneWithRelations(id));

    /// <summary>
    /// Crea una nueva categoría.
    /// - Valida DTO y delega la creación a ICategoryService.
    /// - Responde 201 con el recurso creado.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<CategoryReadDto>> Create([FromBody] CategoryCreateDto dto)
    {
        var created = await _service.Create(dto);
        return CreatedAtAction(nameof(GetOne), new { id = created.ID }, created);
    }

    /// <summary>
    /// Elimina una categoría por ID.
    /// - Devuelve 204 cuando la operación se completa correctamente.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }
}
