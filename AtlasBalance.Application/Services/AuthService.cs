using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using AtlasBalance.Application.Responses;
using AtlasBalance.Domain.Exceptions;
using AtlasBalance.Domain.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

public class AuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
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
