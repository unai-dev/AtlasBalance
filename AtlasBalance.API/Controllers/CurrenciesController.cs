using AtlasBalance.Application.DTOs.Currency;
using AtlasBalance.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlasBalance.API.Controllers;

[ApiController]
[Route("api/currencies")]
[Authorize]
public class CurrenciesController : ControllerBase
{
    private readonly ICurrencyService _service;

    public CurrenciesController(ICurrencyService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CurrencyReadDto>>> GetAll() => Ok(await _service.GetAll());

    [HttpGet("{id}")]
    public async Task<ActionResult<CurrencyReadDto>> GetOne(int id) => Ok(await _service.GetOne(id));

    [HttpGet("{id}/relations")]
    public async Task<ActionResult<CurrencyReadWithRelationsDto>> GetOneWithRelations(int id) => Ok(await _service.GetOneWithRelations(id));

    [HttpPost]
    public async Task<ActionResult<CurrencyReadDto>> Create([FromBody] CurrencyCreateDto dto)
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
