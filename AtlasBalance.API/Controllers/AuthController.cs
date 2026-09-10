using AtlasBalance.Application.DTOs.Auth;
using AtlasBalance.Application.Interfaces;
using AtlasBalance.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AtlasBalance.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service) => _service = service;

    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] RegisterUserDto dto)
    {
        var created = await _service.Register(dto);
        return CreatedAtAction(null, created);
    }

    [HttpPost("login")]
    public async Task<ActionResult<JWTBearerResponse>> Login([FromBody] LoginUserDto dto)
        => Ok(await _service.Login(dto));
}
