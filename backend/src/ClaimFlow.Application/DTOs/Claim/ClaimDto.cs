using System;
using ClaimFlow.Domain.Enums;

namespace ClaimFlow.Application.DTOs.Claim;

public class ClaimDto
{
  public Guid Id { get; set; }
  public Guid PolicyId { get; set; }
  public string? Title { get; set; }
  public string? Description { get; set; }
  public ClaimStatus Status { get; set; }
  public DateTime CreatedAt { get; set; }
}