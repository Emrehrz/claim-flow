using System.Security.Claims;
using ClaimFlow.Application.DTOs.Claim;
using ClaimFlow.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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

[HttpPost("{id}/photos")]
// Rol yetkilendirmesi kullanıyorsan [Authorize] niteliklerini mevcut yapıya göre ayarla
public async Task<IActionResult> UploadPhoto(Guid id, IFormFile file, CancellationToken cancellationToken)
{
    if (file == null || file.Length == 0)
        return BadRequest("Lütfen geçerli bir dosya yükleyin.");

// "id" yerine standart NameIdentifier veya doğrudan "sub" claim'ini arıyoruz
    var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value 
                   ?? User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
    
    // Rol claim'ini de güvenceye alalım
    var roleClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Role)?.Value 
                 ?? User.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;
                 
    if (!Guid.TryParse(userIdClaim, out Guid currentUserId))
        return Unauthorized();

    using var stream = file.OpenReadStream();
    
    var result = await _claimService.UploadClaimPhotoAsync(
        id, 
        stream, 
        file.FileName, 
        currentUserId, 
        roleClaim ?? "Customer", 
        cancellationToken);

    return Ok(result);
}

[HttpGet("{id}")]
public async Task<IActionResult> GetClaimById(Guid id, CancellationToken cancellationToken)
{
    // Token'dan istek atan kullanıcının bilgilerini alıyoruz
    var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
    var role = User.FindFirst(ClaimTypes.Role)?.Value!;

    var claim = await _claimService.GetClaimByIdAsync(id, userId, role, cancellationToken);
    
    if (claim == null)
        return NotFound(new { message = "Hasar dosyası bulunamadı." });

    return Ok(claim);
}
}