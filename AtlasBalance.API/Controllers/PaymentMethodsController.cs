using AtlasBalance.Application.DTOs.PaymentMethod;
using AtlasBalance.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlasBalance.API.Controllers;

[ApiController]
[Route("api/payment-methods")]
[Authorize]
public class PaymentMethodsController : ControllerBase
{
    private readonly IPaymentMethodService _service;

    public PaymentMethodsController(IPaymentMethodService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PaymentMethodReadDto>>> GetAll() => Ok(await _service.GetAll());

    [HttpGet("{id}")]
    public async Task<ActionResult<PaymentMethodReadDto>> GetOne(int id) => Ok(await _service.GetOne(id));

    [HttpGet("{id}/relations")]
    public async Task<ActionResult<PaymentMethodReadWithRelationsDto>> GetOneWithRelations(int id) => Ok(await _service.GetOneWithRelations(id));

    [HttpPost]
    public async Task<ActionResult<PaymentMethodReadDto>> Create([FromBody] PaymentMethodCreateDto dto)
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
