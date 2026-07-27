using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClaimFlow.Application.DTOs.Claim;
using ClaimFlow.Application.Interfaces;
using ClaimFlow.Application.Interfaces.Data;
using ClaimFlow.Domain.Enums;
using Mapster;

namespace ClaimFlow.Application.Services;

public class ClaimService : IClaimService
{
    private readonly IClaimRepository _claimRepository;
    private readonly IPolicyRepository _policyRepository;

    public ClaimService(IClaimRepository claimRepository, IPolicyRepository policyRepository)
    {
        _claimRepository = claimRepository;
        _policyRepository = policyRepository;
    }

    public async Task<ClaimDto> CreateClaimAsync(Guid userId, CreateClaimDto dto)
    {
        var policy = await _policyRepository.GetByIdAsync(dto.PolicyId);
        
        if (policy == null)
            throw new KeyNotFoundException("Poliçe bulunamadı.");

        // İŞ KURALI: Sadece aktif poliçeler hasar kaydı açabilir.
        if (policy.Status != PolicyStatus.Active)
            throw new InvalidOperationException("Yalnızca aktif poliçeler için hasar kaydı oluşturulabilir.");

        // TODO: İleride Vehicle tablosu üzerinden userId doğrulaması da eklenebilir.

        var claim = new Domain.Entities.Claim
        {
            Id = Guid.NewGuid(),
            PolicyId = dto.PolicyId,
            Title = dto.Title,
            Description = dto.Description,
            Status = ClaimStatus.Submitted, // Varsayılan durum
            CreatedAt = DateTime.UtcNow
        };

        await _claimRepository.AddAsync(claim);

        return claim.Adapt<ClaimDto>();
    }

    public async Task<IEnumerable<ClaimDto>> GetClaimsByPolicyAsync(Guid userId, string role, Guid policyId)
{
    var policy = await _policyRepository.GetByIdAsync(policyId);
    if (policy == null)
        throw new KeyNotFoundException("Poliçe bulunamadı.");

    // İŞ KURALI VE İZOLASYON (Sprint 4 Kabul Kriteri)
    // Eğer istek atan kişi Admin değilse ve poliçe ona ait değilse erişimi engelle.
    if (role != "Admin" && policy.Vehicle.UserId != userId)
    {
        throw new UnauthorizedAccessException("Bu poliçeye ait hasar dosyalarını görüntüleme yetkiniz yok.");
    }

    var claims = await _claimRepository.GetClaimsByPolicyIdAsync(policyId);
    return claims.Adapt<IEnumerable<ClaimDto>>();
}

    public async Task UpdateClaimStatusAsync(Guid claimId, UpdateClaimStatusDto dto)
    {
        var claim = await _claimRepository.GetByIdAsync(claimId);
        if (claim == null)
            throw new KeyNotFoundException("Hasar dosyası bulunamadı.");

        claim.Status = dto.Status;
        await _claimRepository.UpdateAsync(claim);
    }
}