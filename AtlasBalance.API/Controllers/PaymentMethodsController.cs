using AtlasBalance.Application.DTOs.PaymentMethod;
using AtlasBalance.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlasBalance.API.Controllers;

[ApiController]
[Route("api/payment-methods")]
[Authorize]
/// <summary>
/// Controller: PaymentMethods
/// - CRUD para métodos de pago.
/// - Controlador delgado que valida entrada y delega a IPaymentMethodService.
/// </summary>
public class PaymentMethodsController : ControllerBase
{
    private readonly IPaymentMethodService _service;

    public PaymentMethodsController(IPaymentMethodService service) => _service = service;

    /// <summary>
    /// Obtiene todos los métodos de pago.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PaymentMethodReadDto>>> GetAll() => Ok(await _service.GetAll());

    /// <summary>
    /// Obtiene un método de pago por ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<PaymentMethodReadDto>> GetOne(int id) => Ok(await _service.GetOne(id));

    /// <summary>
    /// Obtiene un método de pago por ID incluyendo relaciones (p.ej. expenses relacionados).
    /// </summary>
    [HttpGet("{id}/relations")]
    public async Task<ActionResult<PaymentMethodReadWithRelationsDto>> GetOneWithRelations(int id) => Ok(await _service.GetOneWithRelations(id));

    /// <summary>
    /// Crea un nuevo método de pago.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<PaymentMethodReadDto>> Create([FromBody] PaymentMethodCreateDto dto)
    {
        var created = await _service.Create(dto);
        return CreatedAtAction(nameof(GetOne), new { id = created.ID }, created);
    }

    /// <summary>
    /// Elimina un método de pago por ID.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }
}
