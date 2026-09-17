using AtlasBalance.Application.DTOs.ExpensesGroup;
using AtlasBalance.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlasBalance.API.Controllers;

[ApiController]
[Route("api/expenses-groups")]
[Authorize]
/// <summary>
/// Controller: ExpensesGroups
/// - Gestiona endpoints CRUD para grupos de gastos.
/// - Controlador delgado que delega la lógica a IExpensesGroupService.
/// - Devuelve DTOs y códigos HTTP estandarizados.
/// </summary>
public class ExpensesGroupsController : ControllerBase
{
    private readonly IExpensesGroupService _service;

    public ExpensesGroupsController(IExpensesGroupService service) => _service = service;

    /// <summary>
    /// Obtiene todos los grupos de gastos de un usuario.
    /// </summary>
    [HttpGet("user/{userID}")]
    public async Task<ActionResult<IEnumerable<ExpensesGroupReadDto>>> GetAll(int userID) => Ok(await _service.GetAll(userID));

    /// <summary>
    /// Obtiene un grupo de gastos por ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<ExpensesGroupReadDto>> GetOne(int id) => Ok(await _service.GetOne(id));

    /// <summary>
    /// Obtiene un grupo de gastos por ID incluyendo relaciones (p.ej. expenses).
    /// </summary>
    [HttpGet("{id}/relations")]
    public async Task<ActionResult<ExpensesGroupReadWithRelationsDto>> GetOneWithRelations(int id) => Ok(await _service.GetOneWithRelations(id));

    /// <summary>
    /// Crea un nuevo grupo de gastos.
    /// - Valida DTO y delega la creación a IExpensesGroupService.
    /// - Responde 201 con el recurso creado.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<ExpensesGroupReadDto>> Create([FromBody] ExpensesGroupCreateDto dto)
    {
        var created = await _service.Create(dto);
        return CreatedAtAction(nameof(GetOne), new { id = created.ID }, created);
    }

    /// <summary>
    /// Elimina un grupo de gastos por ID.
    /// - Devuelve 204 cuando la operación se completa correctamente.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }
}
