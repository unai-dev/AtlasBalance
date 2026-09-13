using AtlasBalance.Application.DTOs.Expense;
using AtlasBalance.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlasBalance.API.Controllers;

[ApiController]
[Route("api/expenses")]
[Authorize]
/// <summary>
/// Controller: Expenses
/// - Gestiona endpoints CRUD para gastos (expenses).
/// - Delegación a IExpenseService; el controlador actúa como capa de transporte HTTP.
/// </summary>
public class ExpensesController : ControllerBase
{
    private readonly IExpenseService _service;

    public ExpensesController(IExpenseService service) => _service = service;

    /// <summary>
    /// Obtiene todos los gastos.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExpenseReadDto>>> GetAll() => Ok(await _service.GetAll());

    /// <summary>
    /// Obtiene un gasto por ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<ExpenseReadDto>> GetOne(int id) => Ok(await _service.GetOne(id));

    /// <summary>
    /// Obtiene un gasto por ID con relaciones (User, Currency, Category, PaymentMethod, Account).
    /// </summary>
    [HttpGet("{id}/relations")]
    public async Task<ActionResult<ExpenseReadWithRelationsDto>> GetOneWithRelations(int id) => Ok(await _service.GetOneWithRelations(id));

    /// <summary>
    /// Crea un gasto nuevo.
    /// - Valida integridad referencial mínima y delega persistencia al servicio.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<ExpenseReadDto>> Create([FromBody] ExpenseCreateDto dto)
    {
        var created = await _service.Create(dto);
        return CreatedAtAction(nameof(GetOne), new { id = created.ID }, created);
    }

    /// <summary>
    /// Elimina un gasto por ID.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }
}
