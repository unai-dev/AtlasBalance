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
using Microsoft.IdentityModel.Tokens;

public class AuthService: IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration, IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _mapper = mapper;
    }
    public async Task<UserReadDto> Register(UserCreateDto dto)
    {
        var newUser = new User
        {
            UserName = dto.UserName,
            Email = dto.Email
        };

        var result = await _userManager.CreateAsync(newUser, dto.Password);

        if (!result.Succeeded)
            throw new BadRequestException($"Failed to create user");

        return _mapper.Map<UserReadDto>(newUser);
    }

    public async Task<JWTBearerResponse> Login(LoginUserDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email)
            ?? throw new NotFoundException("User Not Found");

        var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

        if (!result.Succeeded)
            throw new BadRequestException($"Failed to login {dto.Email}");

        return await GenerateJWTBearer(dto.Email);
    }

    private async Task<JWTBearerResponse> GenerateJWTBearer(string email)
    {
        List<Claim> claims = new List<Claim>();
        Claim emailClaim = new Claim("email", email);

        User currentUser = await _userManager.FindByEmailAsync(email)
            ?? throw new NotFoundException("User not found");

        claims.Add(emailClaim);
        claims.AddRange(await _userManager.GetClaimsAsync(currentUser));

        SymmetricSecurityKey jwtSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT_SECRET"]!));
        SigningCredentials credentials = new SigningCredentials(jwtSecret, SecurityAlgorithms.HmacSha256);
        DateTime expirationTime = DateTime.Now.AddMinutes(120);

        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expirationTime, signingCredentials: credentials);

        string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return new JWTBearerResponse(token, expirationTime);
    }


}
