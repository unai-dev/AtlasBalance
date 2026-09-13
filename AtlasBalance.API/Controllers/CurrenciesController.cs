using AtlasBalance.Application.DTOs.Currency;
using AtlasBalance.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlasBalance.API.Controllers;

[ApiController]
[Route("api/currencies")]
[Authorize]
/// <summary>
/// Controller: Currencies
/// - Provee endpoints CRUD para monedas (Currency).
/// - Delegación a ICurrencyService para la lógica de aplicación.
/// </summary>
public class CurrenciesController : ControllerBase
{
    private readonly ICurrencyService _service;

    public CurrenciesController(ICurrencyService service) => _service = service;

    /// <summary>
    /// Obtiene todas las monedas.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CurrencyReadDto>>> GetAll() => Ok(await _service.GetAll());

    /// <summary>
    /// Obtiene una moneda por ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<CurrencyReadDto>> GetOne(int id) => Ok(await _service.GetOne(id));

    /// <summary>
    /// Obtiene una moneda por ID incluyendo relaciones (p.ej. expenses).
    /// </summary>
    [HttpGet("{id}/relations")]
    public async Task<ActionResult<CurrencyReadWithRelationsDto>> GetOneWithRelations(int id) => Ok(await _service.GetOneWithRelations(id));

    /// <summary>
    /// Crea una nueva moneda.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<CurrencyReadDto>> Create([FromBody] CurrencyCreateDto dto)
    {
        var created = await _service.Create(dto);
        return CreatedAtAction(nameof(GetOne), new { id = created.ID }, created);
    }

    /// <summary>
    /// Elimina una moneda por ID.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }
}
