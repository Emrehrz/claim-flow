using ClaimFlow.Domain.Entities;
using ClaimFlow.Domain.Enums;

namespace ClaimFlow.Application.Interfaces.Data;

public interface IPolicyRequestRepository
{
    Task<bool> HasActiveRequestAsync(Guid policyId);
    Task AddAsync(PolicyRequest request);
    Task<PolicyRequest?> GetByIdAsync(Guid id);
    Task<IEnumerable<PolicyRequest>> GetPendingRequestsAsync();
    Task<IEnumerable<PolicyRequest>> GetUserRequestsAsync(Guid userId);
    Task SaveChangesAsync();
}