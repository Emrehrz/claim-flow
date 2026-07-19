namespace ClaimFlow.Application.DTOs.Health;

public sealed record HealthCheckResponse(
    bool Success,
    string Message,
    DateTime TimestampUtc);