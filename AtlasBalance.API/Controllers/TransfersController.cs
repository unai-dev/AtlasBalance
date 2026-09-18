using AtlasBalance.Application.DTOs.Transfer;
using AtlasBalance.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlasBalance.API.Controllers;

[ApiController]
[Route("api/transfers")]
[Authorize]
/// <summary>
/// Controller: Transfers
/// - Provee endpoints para operaciones sobre Transfer.
/// - Sigue las mismas convenciones que otros controladores: delega la lógica a ITransferService,
///   documenta cada endpoint y devuelve códigos HTTP apropiados.
/// - Nota: no se implementa endpoint Update por petición del equipo.
/// </summary>
public class TransfersController : ControllerBase
{
    private readonly ITransferService _service;

    public TransfersController(ITransferService service) => _service = service;

    /// <summary>
    /// Obtiene todos los transfers.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TransferReadDto>>> GetAll() => Ok(await _service.GetAll());

    /// <summary>
    /// Obtiene un transfer por ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<TransferReadDto>> GetOne(int id) => Ok(await _service.GetOne(id));

    /// <summary>
    /// Obtiene un transfer por ID incluyendo entidades relacionadas (User, Currency, Category, PaymentMethod, Account).
    /// </summary>
    [HttpGet("{id}/relations")]
    public async Task<ActionResult<TransferReadWithRelationsDto>> GetOneWithRelations(int id) => Ok(await _service.GetOneWithRelations(id));

    /// <summary>
    /// Crea un nuevo transfer.
    /// - Valida la existencia de entidades referenciadas y delega la persistencia al servicio.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<TransferReadDto>> Create([FromBody] TransferCreateDto dto)
    {
        var created = await _service.Create(dto);
        return CreatedAtAction(nameof(GetOne), new { id = created.ID }, created);
    }

    /// <summary>
    /// Elimina un transfer por ID.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }
}
