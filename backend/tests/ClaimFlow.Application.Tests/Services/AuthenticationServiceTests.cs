using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Moq;
using ClaimFlow.Application.DTOs.Authentication;
using ClaimFlow.Application.Interfaces.Authentication;
using ClaimFlow.Application.Interfaces.Data;
using ClaimFlow.Application.Services;
using ClaimFlow.Domain.Entities;

namespace ClaimFlow.Application.Tests.Services;

public class AuthenticationServiceTests
{
    private readonly Mock<IJwtProvider> _jwtProviderMock;
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly AuthenticationService _sut;

    public AuthenticationServiceTests()
    {
        _jwtProviderMock = new Mock<IJwtProvider>();
        _userRepositoryMock = new Mock<IUserRepository>(); // Yeni mock nesnesi eklendi
        
        // Servis her iki bağımlılıkla başlatılıyor
        _sut = new AuthenticationService(_jwtProviderMock.Object, _userRepositoryMock.Object);
    }

    [Fact]
    public async Task LoginAsync_WithValidAdminCredentials_ReturnsLoginResponse()
    {
        // Arrange
        var request = new LoginRequest("admin@claimflow.com", "Password123!");
        
        // Başarılı senaryo için sahte kullanıcı nesnesi
        var fakeUser = new User 
        { 
            Id = Guid.NewGuid(), 
            Email = "admin@claimflow.com", 
            PasswordHash = "Password123!", 
            Role = "Admin" 
        };
        
        // _userRepository.GetByEmailAsync çağrıldığında sahte kullanıcıyı dön
        _userRepositoryMock
            .Setup(x => x.GetByEmailAsync(request.Email, It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeUser);

        _jwtProviderMock.Setup(x => x.GenerateToken(It.IsAny<User>())).Returns("valid_token");
        _jwtProviderMock.Setup(x => x.GenerateRefreshToken()).Returns("refresh_token");

        // Act
        var response = await _sut.LoginAsync(request, CancellationToken.None);

        // Assert
        Assert.NotNull(response);
        Assert.Equal("valid_token", response.AccessToken);
        Assert.Equal("refresh_token", response.RefreshToken);
    }

    [Fact]
    public async Task LoginAsync_WithInvalidPassword_ThrowsUnauthorizedAccessException()
    {
        // Arrange
        var request = new LoginRequest("admin@claimflow.com", "wrong_password");
        
        var fakeUser = new User 
        { 
            Id = Guid.NewGuid(), 
            Email = "admin@claimflow.com", 
            PasswordHash = "Password123!", 
            Role = "Admin" 
        };

        _userRepositoryMock
            .Setup(x => x.GetByEmailAsync(request.Email, It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeUser);

        // Act & Assert (Exception tipi AuthenticationService'deki değişikliğe göre güncellendi)
        await Assert.ThrowsAsync<UnauthorizedAccessException>(() => _sut.LoginAsync(request, CancellationToken.None));
    }
}