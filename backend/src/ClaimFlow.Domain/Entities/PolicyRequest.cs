using System;
using ClaimFlow.Domain.Enums;

namespace ClaimFlow.Domain.Entities;

public class PolicyRequest
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    // İlişkiler
    public Guid PolicyId { get; set; }
    public Policy Policy { get; set; } = null!;

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    // Talep Detayları
    public PolicyRequestType RequestType { get; set; }
    public PolicyRequestStatus Status { get; set; } = PolicyRequestStatus.Pending;
    public string? Description { get; set; }

    // Admin Yanıt Alanları
    public decimal? DummyPrice { get; set; }
    public string? AdminNote { get; set; }

    // Zaman Damgaları
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}