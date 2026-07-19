using ClaimFlow.Application.DTOs.Health;
using ClaimFlow.Application.Interfaces;
using ClaimFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ClaimFlow.Infrastructure.Services;

public sealed class HealthService : IHealthService
{
    private readonly AppDbContext appDbContext;

    public HealthService(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<HealthCheckResponse> GetHealthAsync(CancellationToken cancellationToken)
    {
        var databaseAvailable = await appDbContext.Database.CanConnectAsync(cancellationToken);
        var message = databaseAvailable
            ? "Backend and PostgreSQL are reachable."
            : "Backend is running but PostgreSQL is unavailable.";

        return new HealthCheckResponse(databaseAvailable, message, DateTime.UtcNow);
    }
}