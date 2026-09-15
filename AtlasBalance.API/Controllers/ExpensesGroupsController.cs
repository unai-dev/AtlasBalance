using AtlasBalance.Application.DTOs.ExpensesGroup;
using AtlasBalance.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlasBalance.API.Controllers;

[ApiController]
[Route("api/expenses-groups")]
[Authorize]
public class ExpensesGroupsController : ControllerBase
{
    private readonly IExpensesGroupService _service;

    public ExpensesGroupsController(IExpensesGroupService service) => _service = service;

    [HttpGet("user/{userID}")]
    public async Task<ActionResult<IEnumerable<ExpensesGroupReadDto>>> GetAll(int userID) => Ok(await _service.GetAll(userID));

    [HttpGet("{id}")]
    public async Task<ActionResult<ExpensesGroupReadDto>> GetOne(int id) => Ok(await _service.GetOne(id));

    [HttpGet("{id}/relations")]
    public async Task<ActionResult<ExpensesGroupReadWithRelationsDto>> GetOneWithRelations(int id) => Ok(await _service.GetOneWithRelations(id));

    [HttpPost]
    public async Task<ActionResult<ExpensesGroupReadDto>> Create([FromBody] ExpensesGroupCreateDto dto)
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
