using System;
using System.IO;
using System.Linq;
using ClaimFlow.Application.Interfaces.Storage;
using ClaimFlow.Application.Interfaces.Ai;
using ClaimFlow.Domain.Entities;
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
    private readonly ILocalStorageService _localStorageService;
    private readonly IAiService _aiService;

    public ClaimService(
        IClaimRepository claimRepository, 
        IPolicyRepository policyRepository,
        ILocalStorageService localStorageService,
        IAiService aiService)
    {
          _claimRepository = claimRepository;
          _policyRepository = policyRepository;
          _localStorageService = localStorageService;
          _aiService = aiService;
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
            Title = dto.Title ?? string.Empty, // dto.Title null ise "" (boş string) atar
            Description = dto.Description ?? "Açıklama belirtilmedi", // Veya varsayılan metin
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
    if (role != "Admin" && policy?.Vehicle?.UserId != userId)
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

public async Task<ClaimDto> UploadClaimPhotoAsync(Guid claimId, Stream fileStream, string fileName, Guid currentUserId, string role, CancellationToken cancellationToken = default)
    {
        var claim = await _claimRepository.GetClaimWithVehicleDetailsAsync(claimId, cancellationToken); // Bunu ekle
        if (claim == null) throw new KeyNotFoundException("Hasar kaydı bulunamadı.");

        // Yetki kontrolü (Daha önce yazılmış EnsureOwnershipOrAdmin benzeri bir mantığın varsa onu kullan)
        if (role != "Admin" && claim?.Policy?.Vehicle?.UserId != currentUserId)
            throw new UnauthorizedAccessException("Bu hasar kaydına fotoğraf yükleme yetkiniz yok.");

        // 1. Doğrulama (Validation)
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
        var extension = Path.GetExtension(fileName).ToLowerInvariant();
        
        if (!allowedExtensions.Contains(extension))
            throw new InvalidOperationException("Sadece JPG ve PNG formatları desteklenmektedir.");

        if (fileStream.Length > 5 * 1024 * 1024) // 5 MB Limit
            throw new InvalidOperationException("Dosya boyutu 5MB'dan büyük olamaz.");

        // 2. Dosyayı Diske Kaydetme
        var fileUrl = await _localStorageService.SaveFileAsync(fileStream, fileName, "claims");

        // 3. Entity'i Güncelleme
        var photo = new ClaimPhoto 
        { 
            Id = Guid.NewGuid(),
            ClaimId = claimId,
            FileUrl = fileUrl,
            UploadedAt = DateTime.UtcNow
        };
        claim.Photos.Add(photo);

        // 4. AI Analizini Tetikleme
        claim.AiSummary = await _aiService.AnalyzeClaimAsync(claim.Description, claim.Photos.Count);

        // 5. Veritabanına Kaydetme
        await _claimRepository.UpdateAsync(claim);

        return claim.Adapt<ClaimDto>();
    }
}