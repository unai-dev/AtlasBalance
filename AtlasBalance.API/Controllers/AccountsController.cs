using AtlasBalance.Application.DTOs.Account;
using AtlasBalance.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlasBalance.API.Controllers;

[ApiController]
[Route("api/accounts")]
[Authorize]
/// <summary>
/// Controller: Accounts
/// - Endpoints CRUD para cuentas.
/// - Valida DTOs y delega operaciones a IAccountService.
/// - Mantiene el controlador delgado sin lógica de negocio.
/// </summary>
public class AccountsController : ControllerBase
{
    private readonly IAccountService _service;

    public AccountsController(IAccountService service) => _service = service;

    /// <summary>
    /// Obtiene todas las cuentas.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AccountReadDto>>> GetAll() => Ok(await _service.GetAll());

    /// <summary>
    /// Obtiene una cuenta por ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<AccountReadDto>> GetOne(int id) => Ok(await _service.GetOne(id));

    /// <summary>
    /// Obtiene una cuenta por ID con relaciones (User, Expenses).
    /// </summary>
    [HttpGet("{id}/relations")]
    public async Task<ActionResult<AccountReadWithRelationsDto>> GetOneWithRelations(int id) => Ok(await _service.GetOneWithRelations(id));

    /// <summary>
    /// Crea una nueva cuenta.
    /// - Valida el DTO y delega la creación al servicio.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<AccountReadDto>> Create([FromBody] AccountCreateDto dto)
    {
        var created = await _service.Create(dto);
        return CreatedAtAction(nameof(GetOne), new { id = created.ID }, created);
    }

    /// <summary>
    /// Elimina una cuenta por ID.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }
}
