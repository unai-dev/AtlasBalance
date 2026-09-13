using AtlasBalance.Application.DTOs.Auth;
using AtlasBalance.Application.DTOs.User;
using AtlasBalance.Application.Interfaces;
using AtlasBalance.Application.Responses;

using Microsoft.AspNetCore.Mvc;

namespace AtlasBalance.API.Controllers;

/// <summary>
/// Controller: Auth
/// - Expone endpoints para autenticación: registro y login.
/// - Valida DTOs y delega la lógica de negocio a IAuthService.
/// - No implementa lógica de negocio; responde con objetos DTO y códigos HTTP apropiados.
/// </summary>
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service) => _service = service;

    /// <summary>
    /// Registra un nuevo usuario.
    /// - Recibe UserCreateDto (Email, Password, ...).
    /// - Devuelve 201 con el DTO del usuario creado.
    /// </summary>
    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] UserCreateDto dto)
    {
        var created = await _service.Register(dto);
        return CreatedAtAction(null, created);
    }

    /// <summary>
    /// Autentica un usuario y devuelve un JWT.
    /// - Devuelve 200 con token y expiración en caso de éxito.
    /// </summary>
    [HttpPost("login")]
    public async Task<ActionResult<JWTBearerResponse>> Login([FromBody] LoginUserDto dto)
        => Ok(await _service.Login(dto));
}
