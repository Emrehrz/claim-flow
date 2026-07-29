using ClaimFlow.Domain.Enums;

namespace ClaimFlow.Application.DTOs.Policy;

public class PolicyRequestResponseDto
{
    public Guid Id { get; set; }
    public Guid PolicyId { get; set; }
    public Guid UserId { get; set; }
    public PolicyRequestType RequestType { get; set; }
    public PolicyRequestStatus Status { get; set; }
    public string? Description { get; set; }
    public decimal? DummyPrice { get; set; }
    public string? AdminNote { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}