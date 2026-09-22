using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using AtlasBalance.Application.DTOs.Auth;
using AtlasBalance.Application.DTOs.User;
using AtlasBalance.Application.Interfaces;
using AtlasBalance.Application.Responses;
using AtlasBalance.Domain.Exceptions;
using AtlasBalance.Domain.Models;

using AutoMapper;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace AtlasBalance.Application.Services;

/// <summary>
/// Servicio de autenticación y registro de usuarios.
/// - Responsable de las operaciones relacionadas con Identity (registro, login y generación de JWT).
/// - Orquesta UserManager/SignInManager y genera respuestas adecuadas para la capa API.
/// - Lanza excepciones tipadas (BadRequestException, NotFoundException) para que el middleware global las transforme
///   en respuestas HTTP apropiadas.
/// </summary>
public class AuthService: IAuthService
{
    #region Fields & Dependencies
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private readonly ILogger<AuthService> _logger;
    #endregion

    #region Constructors
    /// <summary>
    /// Constructor.
    /// </summary>
    public AuthService(UserManager<User> userManager, 
        SignInManager<User> signInManager, IConfiguration configuration,
        IMapper mapper, ILogger<AuthService> logger)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _mapper = mapper;
        _logger = logger;
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// Registra un nuevo usuario en Identity usando UserManager.
    /// - El DTO debe contener Email y Password.
    /// - Devuelve un UserReadDto mapeado desde la entidad creada.
    /// </summary>
    /// <param name="dto">DTO con los datos para crear el usuario.</param>
    /// <returns>UserReadDto con los datos del usuario creado.</returns>
    /// <exception cref="BadRequestException">Si la creación falla (errores de Identity).</exception>
    public async Task<UserReadDto> Register(UserCreateDto dto)
    {
        // Crear la entidad de usuario y delegar en UserManager para hashing de contraseña y persistencia
        var newUser = new User
        {
            UserName = dto.UserName,
            Email = dto.Email
        };

        var result = await _userManager.CreateAsync(newUser, dto.Password);

        if (!result.Succeeded)
        {
             throw new BadRequestException($"Failed to create user");
        } 

        return _mapper.Map<UserReadDto>(newUser);
    }

    /// <summary>
    /// Valida credenciales y devuelve un JWT cuando el login es correcto.
    /// - Busca al usuario por email, valida la contraseña y genera el token.
    /// </summary>
    /// <param name="dto">DTO con Email y Password.</param>
    /// <returns>JWTBearerResponse con token y expiración.</returns>
    /// <exception cref="NotFoundException">Si el usuario no existe.</exception>
    /// <exception cref="BadRequestException">Si la contraseña es incorrecta.</exception>
    public async Task<JWTBearerResponse> Login(LoginUserDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email)
            ?? throw new NotFoundException("User Not Found");

        var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

        if (!result.Succeeded)
            throw new BadRequestException($"Failed to login {dto.Email}");

        return await GenerateJWTBearer(dto.Email);
    }
    #endregion

    #region Private Methods & Helpers
    /// <summary>
    /// Genera un JWT con los claims del usuario y la configuración de la aplicación.
    /// - Incluye el claim de email y cualquier claim adicional asociado al usuario en Identity.
    /// - La clave secreta se obtiene de la configuración (JWT_SECRET).
    /// </summary>
    /// <param name="email">Email del usuario para cargar sus claims.</param>
    /// <returns>JWTBearerResponse con token y fecha de expiración.</returns>
    private async Task<JWTBearerResponse> GenerateJWTBearer(string email)
    {
        // Preparar claims básicos
        List<Claim> claims = new List<Claim>();
        Claim emailClaim = new Claim("email", email);

        // Obtener el usuario y sus claims desde Identity
        User currentUser = await _userManager.FindByEmailAsync(email)
            ?? throw new NotFoundException("User not found");

        claims.Add(emailClaim);
        claims.AddRange(await _userManager.GetClaimsAsync(currentUser));

        // Construir token JWT usando la clave secreta de configuración
        SymmetricSecurityKey jwtSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT_SECRET"]!));
        SigningCredentials credentials = new SigningCredentials(jwtSecret, SecurityAlgorithms.HmacSha256);
        DateTime expirationTime = DateTime.Now.AddMinutes(120);

        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expirationTime, signingCredentials: credentials);

        string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return new JWTBearerResponse(token, expirationTime);
    }
    #endregion

}
