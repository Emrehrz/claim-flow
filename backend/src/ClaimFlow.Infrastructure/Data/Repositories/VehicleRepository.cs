using ClaimFlow.Application.Interfaces.Data;
using ClaimFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClaimFlow.Infrastructure.Data.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly AppDbContext _context;

    public VehicleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Vehicle?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Vehicles.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<IEnumerable<Vehicle>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _context.Vehicles
            .Where(v => v.UserId == userId)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Vehicle vehicle, CancellationToken cancellationToken = default)
    {
        await _context.Vehicles.AddAsync(vehicle, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public Task UpdateAsync(Vehicle vehicle, CancellationToken cancellationToken = default)
    {
        _context.Vehicles.Update(vehicle);
        return _context.SaveChangesAsync(cancellationToken);
    }

    public Task DeleteAsync(Vehicle vehicle, CancellationToken cancellationToken = default)
    {
        _context.Vehicles.Remove(vehicle);
        return _context.SaveChangesAsync(cancellationToken);
    }
}
