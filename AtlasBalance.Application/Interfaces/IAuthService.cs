using AtlasBalance.Application.Responses;

namespace AtlasBalance.Application.Interfaces;

public interface IAuthService
{
    Task<JWTBearerResponse> Register(RegisterUserDto dto);
    Task<JWTBearerResponse> Login(LoginUserDto dto);
}
