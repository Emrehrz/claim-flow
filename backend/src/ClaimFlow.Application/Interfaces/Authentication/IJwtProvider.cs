using ClaimFlow.Domain.Entities;

namespace ClaimFlow.Application.Interfaces.Authentication;

public interface IJwtProvider
{
    string GenerateToken(User user);
    string GenerateRefreshToken();
}
