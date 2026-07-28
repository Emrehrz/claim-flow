using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClaimFlow.Domain.Entities;
using ClaimFlow.Domain.Enums;

namespace ClaimFlow.Application.Interfaces.Data;

public interface IClaimRepository
{
  Task<IEnumerable<Claim>> GetClaimsAsync(Guid? vehicleId, ClaimStatus? status);
  Task<Claim?> GetByIdAsync(Guid id);
  Task<IEnumerable<Claim>> GetClaimsByPolicyIdAsync(Guid policyId);
  Task AddAsync(Claim claim);
  Task UpdateAsync(Claim claim);

  Task<Claim> GetClaimWithVehicleDetailsAsync(Guid id, CancellationToken cancellationToken = default);
}