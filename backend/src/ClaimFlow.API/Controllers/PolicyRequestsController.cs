using System.Security.Claims;
using ClaimFlow.Application.DTOs.Policy;
using ClaimFlow.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClaimFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PolicyRequestsController : ControllerBase
{
    private readonly IPolicyRequestService _service;

    public PolicyRequestsController(IPolicyRequestService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePolicyRequestDto input)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var result = await _service.CreateAsync(userId, input);
        return Ok(result);
    }

    [HttpGet("my-requests")]
    public async Task<IActionResult> GetMyRequests()
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var result = await _service.GetUserRequestsAsync(userId);
        return Ok(result);
    }

    [HttpGet("pending")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetPending()
    {
        var result = await _service.GetPendingRequestsAsync();
        return Ok(result);
    }

    [HttpPut("complete")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Complete([FromBody] CompletePolicyRequestDto input)
    {
        var result = await _service.CompleteRequestAsync(input);
        return Ok(result);
    }
}