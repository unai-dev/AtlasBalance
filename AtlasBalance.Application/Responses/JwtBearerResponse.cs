namespace AtlasBalance.Application.Responses;

public record JWTBearerResponse(string Token, DateTime ExpirationTime);
