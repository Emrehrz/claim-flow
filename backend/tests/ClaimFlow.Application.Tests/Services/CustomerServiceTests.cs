using ClaimFlow.Application.DTOs.Customer;
using ClaimFlow.Application.Interfaces.Data;
using ClaimFlow.Application.Services;
using ClaimFlow.Domain.Entities;
using Moq;
using Xunit;

namespace ClaimFlow.Application.Tests.Services;

public class CustomerServiceTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly CustomerService _customerService;

    public CustomerServiceTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _customerService = new CustomerService(_userRepositoryMock.Object);
    }

    [Fact]
    public async Task GetCustomerByIdAsync_ShouldReturnCustomer_WhenExists()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var user = new User { Id = userId, FirstName = "John", LastName = "Doe" };
        _userRepositoryMock.Setup(repo => repo.GetByIdAsync(userId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(user);

        // Act
        var result = await _customerService.GetCustomerByIdAsync(userId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("John", result.FirstName);
    }
}
