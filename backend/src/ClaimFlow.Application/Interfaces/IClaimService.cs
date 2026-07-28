using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClaimFlow.Application.DTOs.Claim;
using System.IO;

namespace ClaimFlow.Application.Interfaces;

public interface IClaimService
{
    Task<ClaimDto> CreateClaimAsync(Guid userId, CreateClaimDto dto);
    Task<IEnumerable<ClaimDto>> GetClaimsByPolicyAsync(Guid userId, string role, Guid policyId);
    Task UpdateClaimStatusAsync(Guid claimId, UpdateClaimStatusDto dto);
    Task<ClaimDto> UploadClaimPhotoAsync(Guid claimId, Stream fileStream, string fileName, Guid currentUserId, string role, CancellationToken cancellationToken = default);
    Task<ClaimDto?> GetClaimByIdAsync(Guid claimId, Guid userId, string role, CancellationToken cancellationToken = default);
}