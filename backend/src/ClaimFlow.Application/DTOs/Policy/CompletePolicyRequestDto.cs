using ClaimFlow.Domain.Enums;

namespace ClaimFlow.Application.DTOs.Policy;

public class CompletePolicyRequestDto
{
    public Guid RequestId { get; set; }
    public decimal DummyPrice { get; set; }
    public string? AdminNote { get; set; }
    public PolicyRequestStatus Status { get; set; } = PolicyRequestStatus.Completed;
}