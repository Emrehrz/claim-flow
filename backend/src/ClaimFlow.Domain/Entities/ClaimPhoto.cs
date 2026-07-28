using System;

namespace ClaimFlow.Domain.Entities;

public class ClaimPhoto
{
    public Guid Id { get; set; }
    public Guid ClaimId { get; set; }
    public string FileUrl { get; set; } = string.Empty;
    public DateTime UploadedAt { get; set; }

    // Navigation property
    public Claim Claim { get; set; } = null!;
}