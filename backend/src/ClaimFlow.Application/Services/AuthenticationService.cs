using ClaimFlow.Application.DTOs.Authentication;
using ClaimFlow.Application.Interfaces.Authentication;
using ClaimFlow.Domain.Entities;

namespace ClaimFlow.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtProvider _jwtProvider;

    public AuthenticationService(IJwtProvider jwtProvider)
    {
        _jwtProvider = jwtProvider;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {
        // TODO: In a real implementation, we would query the database to find the user
        // and verify the password hash. For Sprint 01 we simulate this.
        
        // Simulating user lookup
        if (request.Email != "admin@claimflow.com" && request.Email != "customer@claimflow.com")
        {
            throw new Exception("Invalid credentials");
        }

        var user = new User 
        { 
            Id = Guid.NewGuid(), 
            Email = request.Email, 
            Role = request.Email.Contains("admin") ? "Admin" : "Customer" 
        };

        // Simulating password check
        if (request.Password != "Password123!")
        {
            throw new Exception("Invalid credentials");
        }

        var token = _jwtProvider.GenerateToken(user);
        var refreshToken = _jwtProvider.GenerateRefreshToken();

        // Normally we'd fetch ExpiryMinutes from config or constants
        return new LoginResponse(token, refreshToken, 3600);
    }

    public Task<LoginResponse> RefreshTokenAsync(string refreshToken, CancellationToken cancellationToken = default)
    {
        // TODO: Implement refresh token validation from DB and issue new token
        throw new NotImplementedException();
    }
}
