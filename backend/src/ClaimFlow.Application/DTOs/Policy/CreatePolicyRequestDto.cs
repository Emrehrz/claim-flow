using ClaimFlow.Domain.Enums;

namespace ClaimFlow.Application.DTOs.Policy;

public class CreatePolicyRequestDto
{
    public Guid PolicyId { get; set; }
    public PolicyRequestType RequestType { get; set; }
    public string? Description { get; set; }
}