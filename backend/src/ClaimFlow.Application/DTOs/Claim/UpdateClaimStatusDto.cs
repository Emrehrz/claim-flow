using ClaimFlow.Domain.Enums;

namespace ClaimFlow.Application.DTOs.Claim;

public class UpdateClaimStatusDto
{
  public ClaimStatus Status {get; set;}
}