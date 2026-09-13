using AtlasBalance.Application.DTOs.User;
using AtlasBalance.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlasBalance.API.Controllers;

[ApiController]
[Route("api/users")]
[Authorize]
/// <summary>
/// Controller: Users
/// - Exposición de endpoints CRUD para la entidad User.
/// - Actúa como capa de transporte HTTP: valida DTOs, aplica autorizaciones y delega la lógica a IUserService.
/// - Devuelve DTOs y códigos HTTP estandarizados (200/201/204/4xx/5xx).
/// </summary>
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service) => _service = service;

    /// <summary>
    /// Obtiene todos los usuarios.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserReadDto>>> GetAll() => Ok(await _service.GetAll());

    /// <summary>
    /// Obtiene un usuario por ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<UserReadDto>> GetOne(int id) => Ok(await _service.GetOne(id));

    /// <summary>
    /// Obtiene un usuario por ID con sus relaciones (Accounts, Expenses).
    /// </summary>
    [HttpGet("{id}/relations")]
    public async Task<ActionResult<UserReadWithRelationsDto>> GetOneWithRelations(int id) => Ok(await _service.GetOneWithRelations(id));

    /// <summary>
    /// Crea un nuevo usuario. El UserName se genera automáticamente a partir del email si no se suministra.
    /// - Devuelve 201 con el recurso creado.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<UserReadDto>> Create([FromBody] UserCreateDto dto)
    {
        var created = await _service.Create(dto);
        return CreatedAtAction(nameof(GetOne), new { id = created.ID }, created);
    }

    /// <summary>
    /// Elimina un usuario por ID.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }
}
