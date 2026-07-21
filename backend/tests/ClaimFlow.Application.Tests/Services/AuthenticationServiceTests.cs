using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Moq;
using ClaimFlow.Application.DTOs.Authentication;
using ClaimFlow.Application.Interfaces.Authentication;
using ClaimFlow.Application.Services;
using ClaimFlow.Domain.Entities;

namespace ClaimFlow.Application.Tests.Services;

public class AuthenticationServiceTests
{
    private readonly Mock<IJwtProvider> _jwtProviderMock;
    private readonly AuthenticationService _sut;

    public AuthenticationServiceTests()
    {
        _jwtProviderMock = new Mock<IJwtProvider>();
        _sut = new AuthenticationService(_jwtProviderMock.Object);
    }

    [Fact]
    public async Task LoginAsync_WithValidAdminCredentials_ReturnsLoginResponse()
    {
        // Arrange
        var request = new LoginRequest("admin@claimflow.com", "Password123!");
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
    public async Task LoginAsync_WithInvalidPassword_ThrowsException()
    {
        // Arrange
        var request = new LoginRequest("admin@claimflow.com", "wrong_password");

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _sut.LoginAsync(request, CancellationToken.None));
    }
}
