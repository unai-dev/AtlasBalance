using AtlasBalance.Application.DTOs.Auth;
using AtlasBalance.Application.DTOs.User;
using AtlasBalance.Application.Responses;

namespace AtlasBalance.Application.Interfaces;

public interface IAuthService
{
    Task<UserReadDto> Register(RegisterUserDto dto);
    Task<JWTBearerResponse> Login(LoginUserDto dto);
}
