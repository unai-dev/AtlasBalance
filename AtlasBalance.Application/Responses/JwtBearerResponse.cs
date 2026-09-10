namespace AtlasBalance.Application.Responses;

internal record JWTBearerResponse(string Token, DateTime ExpirationTime);
