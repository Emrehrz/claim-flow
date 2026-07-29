using ClaimFlow.Application.DTOs.Policy;

namespace ClaimFlow.Application.Interfaces;

public interface IPolicyRequestService
{
    Task<PolicyRequestResponseDto> CreateAsync(Guid userId, CreatePolicyRequestDto input);
    Task<IEnumerable<PolicyRequestResponseDto>> GetPendingRequestsAsync();
    Task<IEnumerable<PolicyRequestResponseDto>> GetUserRequestsAsync(Guid userId);
    Task<PolicyRequestResponseDto> CompleteRequestAsync(CompletePolicyRequestDto input);
}