using ClaimFlow.Application.Interfaces.Data;
using ClaimFlow.Application.Services;
using ClaimFlow.Domain.Entities;
using Moq;
using Xunit;

namespace ClaimFlow.Application.Tests.Services;

public class VehicleServiceTests
{
    private readonly Mock<IVehicleRepository> _vehicleRepositoryMock;
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly VehicleService _vehicleService;

    public VehicleServiceTests()
    {
        _vehicleRepositoryMock = new Mock<IVehicleRepository>();
        _userRepositoryMock = new Mock<IUserRepository>();
        _vehicleService = new VehicleService(_vehicleRepositoryMock.Object, _userRepositoryMock.Object);
    }

    [Fact]
    public async Task GetVehicleByIdAsync_ShouldThrowUnauthorizedAccessException_WhenNotOwner()
    {
        // Arrange
        var vehicleId = Guid.NewGuid();
        var ownerId = Guid.NewGuid();
        var requesterId = Guid.NewGuid();
        var vehicle = new Vehicle { Id = vehicleId, UserId = ownerId };

        _vehicleRepositoryMock.Setup(repo => repo.GetByIdAsync(vehicleId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(vehicle);

        // Act & Assert
        await Assert.ThrowsAsync<UnauthorizedAccessException>(() =>
            _vehicleService.GetVehicleByIdAsync(vehicleId, requesterId, "Customer"));
    }

    [Fact]
    public async Task GetVehicleByIdAsync_ShouldReturnVehicle_WhenOwner()
    {
        // Arrange
        var vehicleId = Guid.NewGuid();
        var ownerId = Guid.NewGuid();
        var vehicle = new Vehicle { Id = vehicleId, UserId = ownerId };

        _vehicleRepositoryMock.Setup(repo => repo.GetByIdAsync(vehicleId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(vehicle);

        // Act
        var result = await _vehicleService.GetVehicleByIdAsync(vehicleId, ownerId, "Customer");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(vehicleId, result.Id);
    }
}
