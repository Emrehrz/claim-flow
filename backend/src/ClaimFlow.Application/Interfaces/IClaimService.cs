using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClaimFlow.Application.DTOs.Claim;

namespace ClaimFlow.Application.Interfaces;

public interface IClaimService
{
    Task<ClaimDto> CreateClaimAsync(Guid userId, CreateClaimDto dto);
    Task<IEnumerable<ClaimDto>> GetClaimsByPolicyAsync(Guid userId, string role, Guid policyId);
    Task UpdateClaimStatusAsync(Guid claimId, UpdateClaimStatusDto dto);
  
}