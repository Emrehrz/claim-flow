using ClaimFlow.Application.DTOs.Vehicle;
using ClaimFlow.Application.Interfaces;
using ClaimFlow.Application.Interfaces.Data;
using ClaimFlow.Domain.Entities;
using Mapster;

namespace ClaimFlow.Application.Services;

public class VehicleService : IVehicleService
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IUserRepository _userRepository;

    public VehicleService(IVehicleRepository vehicleRepository, IUserRepository userRepository)
    {
        _vehicleRepository = vehicleRepository;
        _userRepository = userRepository;
    }

    private void EnsureOwnershipOrAdmin(Vehicle vehicle, Guid currentUserId, string role)
    {
        if (role != "Admin" && vehicle.UserId != currentUserId)
        {
            throw new UnauthorizedAccessException("You do not have permission to access this vehicle.");
        }
    }

    public async Task<VehicleDto> GetVehicleByIdAsync(Guid id, Guid currentUserId, string role, CancellationToken cancellationToken = default)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(id, cancellationToken);
        if (vehicle == null) throw new KeyNotFoundException("Vehicle not found.");

        EnsureOwnershipOrAdmin(vehicle, currentUserId, role);
        return vehicle.Adapt<VehicleDto>();
    }

    public async Task<IEnumerable<VehicleDto>> GetVehiclesByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var vehicles = await _vehicleRepository.GetByUserIdAsync(userId, cancellationToken);
        return vehicles.Adapt<IEnumerable<VehicleDto>>();
    }

    public async Task<VehicleDto> CreateVehicleAsync(Guid userId, CreateVehicleDto dto, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);
        if (user == null) throw new KeyNotFoundException("User not found.");

        var vehicle = dto.Adapt<Vehicle>();
        vehicle.UserId = userId;

        await _vehicleRepository.AddAsync(vehicle, cancellationToken);
        return vehicle.Adapt<VehicleDto>();
    }

    public async Task<VehicleDto> UpdateVehicleAsync(Guid id, Guid currentUserId, string role, UpdateVehicleDto dto, CancellationToken cancellationToken = default)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(id, cancellationToken);
        if (vehicle == null) throw new KeyNotFoundException("Vehicle not found.");

        EnsureOwnershipOrAdmin(vehicle, currentUserId, role);

        dto.Adapt(vehicle);
        await _vehicleRepository.UpdateAsync(vehicle, cancellationToken);

        return vehicle.Adapt<VehicleDto>();
    }

    public async Task DeleteVehicleAsync(Guid id, Guid currentUserId, string role, CancellationToken cancellationToken = default)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(id, cancellationToken);
        if (vehicle == null) throw new KeyNotFoundException("Vehicle not found.");

        EnsureOwnershipOrAdmin(vehicle, currentUserId, role);
        await _vehicleRepository.DeleteAsync(vehicle, cancellationToken);
    }
}
