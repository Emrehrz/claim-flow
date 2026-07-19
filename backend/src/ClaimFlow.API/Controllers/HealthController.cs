using ClaimFlow.Application.DTOs.Health;
using ClaimFlow.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClaimFlow.API.Controllers;

[ApiController]
[Route("api/health")]
public sealed class HealthController : ControllerBase
{
    private readonly IHealthService healthService;

    public HealthController(IHealthService healthService)
    {
        this.healthService = healthService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(HealthCheckResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult<HealthCheckResponse>> Get(CancellationToken cancellationToken)
    {
        var response = await healthService.GetHealthAsync(cancellationToken);
        return Ok(response);
    }
}