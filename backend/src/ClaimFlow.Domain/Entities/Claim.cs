using System;
using ClaimFlow.Domain.Enums;

namespace ClaimFlow.Domain.Entities;

public class Claim
{
    public Guid Id { get; set; }
    
    // Yabancı Anahtar (Foreign Key)
    public Guid PolicyId { get; set; }
    
    // Navigation Property
    public Policy Policy { get; set; }
    
    public string Title { get; set; }
    public string Description { get; set; }
    public ClaimStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }

    public string? AiSummary { get; set; }
    public ICollection<ClaimPhoto> Photos { get; set; } = new List<ClaimPhoto>();
}