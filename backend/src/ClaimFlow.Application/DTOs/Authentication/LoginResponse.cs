namespace ClaimFlow.Application.DTOs.Authentication;

public record LoginResponse(string AccessToken, string RefreshToken, int ExpiresIn);
