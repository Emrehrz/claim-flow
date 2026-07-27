using System;
using System.Threading;
using System.Threading.Tasks;
using ClaimFlow.Application.DTOs.Authentication;
using ClaimFlow.Application.Interfaces.Authentication;
using ClaimFlow.Application.Interfaces.Data;
using ClaimFlow.Domain.Entities;

namespace ClaimFlow.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtProvider _jwtProvider;
    private readonly IUserRepository _userRepository;

    // _jwtProvider parametresinin yanına _userRepository eklendi
    public AuthenticationService(IJwtProvider jwtProvider, IUserRepository userRepository)
    {
        _jwtProvider = jwtProvider;
        _userRepository = userRepository;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {
        // 1. Veritabanından kullanıcıyı e-posta ile bul
        var user = await _userRepository.GetByEmailAsync(request.Email);
        
        if (user == null)
        {
            throw new UnauthorizedAccessException("Geçersiz kullanıcı adı veya şifre.");
        }

        // 2. Şifre Doğrulaması (Eğer veritabanında PasswordHash tutuyorsan, hash karşılaştırması yapılmalı)
        // Mevcut User entity'sinde şifreyi nasıl tuttuğuna göre bu satırı uyarla.
        if (user.PasswordHash != request.Password)
        {
            throw new UnauthorizedAccessException("Geçersiz kullanıcı adı veya şifre.");
        }

        // 3. Token Üretimi
        var token = _jwtProvider.GenerateToken(user);
        var refreshToken = _jwtProvider.GenerateRefreshToken();

        return new LoginResponse(token, refreshToken, 3600);
    }

    public Task<LoginResponse> RefreshTokenAsync(string refreshToken, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}