using System.Security.Claims;
using ClaimFlow.Application.DTOs.Vehicle;
using ClaimFlow.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClaimFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class VehiclesController : ControllerBase
{
    private readonly IVehicleService _vehicleService;

    public VehiclesController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    private Guid GetCurrentUserId() => Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? Guid.Empty.ToString());
    private string GetCurrentUserRole() => User.FindFirstValue(ClaimTypes.Role) ?? string.Empty;

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetVehicleById(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(id, GetCurrentUserId(), GetCurrentUserRole(), cancellationToken);
            return Ok(vehicle);
        }
        catch (KeyNotFoundException ex) { return NotFound(new { message = ex.Message }); }
        catch (UnauthorizedAccessException) { return Forbid(); }
    }

    [HttpGet("user/{userId:guid}")]
    public async Task<IActionResult> GetVehiclesByUserId(Guid userId, CancellationToken cancellationToken)
    {
        // Check if querying own vehicles or is admin
        if (userId != GetCurrentUserId() && GetCurrentUserRole() != "Admin")
            return Forbid();

        var vehicles = await _vehicleService.GetVehiclesByUserIdAsync(userId, cancellationToken);
        return Ok(vehicles);
    }

    [HttpPost]
    public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleDto dto, CancellationToken cancellationToken)
    {
        try
        {
            var vehicle = await _vehicleService.CreateVehicleAsync(GetCurrentUserId(), dto, cancellationToken);
            return CreatedAtAction(nameof(GetVehicleById), new { id = vehicle.Id }, vehicle);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateVehicle(Guid id, [FromBody] UpdateVehicleDto dto, CancellationToken cancellationToken)
    {
        try
        {
            var vehicle = await _vehicleService.UpdateVehicleAsync(id, GetCurrentUserId(), GetCurrentUserRole(), dto, cancellationToken);
            return Ok(vehicle);
        }
        catch (KeyNotFoundException ex) { return NotFound(new { message = ex.Message }); }
        catch (UnauthorizedAccessException) { return Forbid(); }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteVehicle(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _vehicleService.DeleteVehicleAsync(id, GetCurrentUserId(), GetCurrentUserRole(), cancellationToken);
            return NoContent();
        }
        catch (KeyNotFoundException ex) { return NotFound(new { message = ex.Message }); }
        catch (UnauthorizedAccessException) { return Forbid(); }
    }
}