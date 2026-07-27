using System;

namespace ClaimFlow.Application.DTOs.Claim;

public class CreateClaimDto
{
  public Guid PolicyId { get; set; }
  public string? Title { get; set; }
  public string? Description { get; set; }
}