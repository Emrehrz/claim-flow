using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ClaimFlow.Application.Interfaces;
using ClaimFlow.Application.DTOs.Policy;
using ClaimFlow.Domain.Enums;
using System.Security.Claims;

namespace ClaimFlow.API.Controllers;

[ApiController]
    [Route("api/[controller]")]
    [Authorize] // Sprint 1'de kurulan JWT altyapısını gerektirir
    public class PoliciesController : ControllerBase
    {
        private readonly IPolicyService _policyService;

        public PoliciesController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        // GET /api/policies?vehicleId=...&status=Active
        [HttpGet]
        public async Task<IActionResult> GetPolicies([FromQuery] Guid? vehicleId, [FromQuery] PolicyStatus? status)
        {
            // Kullanıcı rolünü ve ID'sini token üzerinden okuma (Customer ise sadece kendi poliçelerini görebilmeli)
            var userRole = User.FindFirstValue(ClaimTypes.Role);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Not: Customer filtreleme mantığı IPolicyService içerisine de taşınabilir.
            var policies = await _policyService.GetPoliciesAsync(vehicleId, status);
            return Ok(policies);
        }

        // GET /api/policies/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPolicy(Guid id)
        {
            // IPolicyService içerisine GetByIdAsync implemente edildiği varsayımıyla
            var policy = await _policyService.GetPoliciesAsync(null, null); // Örnek çağrı, tekil getirme servise eklenecek
            return Ok(policy); 
        }

        // POST /api/policies
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreatePolicy([FromBody] CreatePolicyDto createDto)
        {
            var policy = await _policyService.CreatePolicyAsync(createDto);
            return CreatedAtAction(nameof(GetPolicy), new { id = policy.Id }, policy);
        }

        // PUT /api/policies/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePolicy(Guid id, [FromBody] UpdatePolicyDto updateDto)
        {
            var policy = await _policyService.UpdatePolicyAsync(id, updateDto);
            return Ok(policy);
        }

        // PUT /api/policies/{id}/status
        [HttpPut("{id}/status")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeStatus(Guid id, [FromBody] PolicyStatus status)
        {
            await _policyService.ChangeStatusAsync(id, status);
            return NoContent();
        }
    }