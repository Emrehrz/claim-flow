using ClaimFlow.Application.DTOs.Health;

namespace ClaimFlow.Application.Interfaces;

public interface IHealthService
{
    Task<HealthCheckResponse> GetHealthAsync(CancellationToken cancellationToken);
}