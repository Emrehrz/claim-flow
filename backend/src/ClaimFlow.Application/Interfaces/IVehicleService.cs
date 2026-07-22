using ClaimFlow.Application.DTOs.Vehicle;

namespace ClaimFlow.Application.Interfaces;

public interface IVehicleService
{
    Task<VehicleDto> GetVehicleByIdAsync(Guid id, Guid currentUserId, string role, CancellationToken cancellationToken = default);
    Task<IEnumerable<VehicleDto>> GetVehiclesByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<VehicleDto> CreateVehicleAsync(Guid userId, CreateVehicleDto dto, CancellationToken cancellationToken = default);
    Task<VehicleDto> UpdateVehicleAsync(Guid id, Guid currentUserId, string role, UpdateVehicleDto dto, CancellationToken cancellationToken = default);
    Task DeleteVehicleAsync(Guid id, Guid currentUserId, string role, CancellationToken cancellationToken = default);
}
