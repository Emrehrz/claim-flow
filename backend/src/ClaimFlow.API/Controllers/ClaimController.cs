using System.Security.Claims;
using ClaimFlow.Application.DTOs.Claim;
using ClaimFlow.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClaimFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ClaimsController : ControllerBase
{
    private readonly IClaimService _claimService;

    public ClaimsController(IClaimService claimService)
    {
        _claimService = claimService;
    }

    private Guid GetCurrentUserId() => Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? Guid.Empty.ToString());
    private string GetCurrentUserRole() => User.FindFirstValue(ClaimTypes.Role) ?? string.Empty;

    // POST /api/claims (Kullanıcı ihbar bırakır)
    [HttpPost]
    public async Task<IActionResult> CreateClaim([FromBody] CreateClaimDto dto)
    {
        try
        {
            var result = await _claimService.CreateClaimAsync(GetCurrentUserId(), dto);
            return StatusCode(201, result);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    // GET /api/claims/policy/{policyId} (Timeline mantığı için listeleme)
    [HttpGet("policy/{policyId:guid}")]
    public async Task<IActionResult> GetClaimsByPolicy(Guid policyId)
    {
        try
        {
            var result = await _claimService.GetClaimsByPolicyAsync(GetCurrentUserId(), GetCurrentUserRole(), policyId);
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (UnauthorizedAccessException)
        {
            return Forbid();
        }
    }

    // PATCH /api/claims/{id}/status (Sadece Admin yetkisiyle statü güncelleme)
    [HttpPatch("{id:guid}/status")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateClaimStatus(Guid id, [FromBody] UpdateClaimStatusDto dto)
    {
        try
        {
            await _claimService.UpdateClaimStatusAsync(id, dto);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}