using ClaimFlow.Application.DTOs.Policy;
using ClaimFlow.Application.Interfaces;
using ClaimFlow.Application.Interfaces.Data;
using ClaimFlow.Domain.Entities;
using ClaimFlow.Domain.Enums;

namespace ClaimFlow.Application.Services;

public class PolicyRequestService : IPolicyRequestService
{
    private readonly IPolicyRequestRepository _repository;

    public PolicyRequestService(IPolicyRequestRepository repository)
    {
        _repository = repository;
    }

    public async Task<PolicyRequestResponseDto> CreateAsync(Guid userId, CreatePolicyRequestDto input)
    {
        var hasActive = await _repository.HasActiveRequestAsync(input.PolicyId);
        if (hasActive)
        {
            throw new InvalidOperationException("Bu poliçe için zaten bekleyen bir talebiniz bulunmaktadır.");
        }

        var entity = new PolicyRequest
        {
            Id = Guid.NewGuid(),
            PolicyId = input.PolicyId,
            UserId = userId,
            RequestType = input.RequestType,
            Status = PolicyRequestStatus.Pending,
            Description = input.Description,
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();

        return MapToDto(entity);
    }

    public async Task<IEnumerable<PolicyRequestResponseDto>> GetPendingRequestsAsync()
    {
        var requests = await _repository.GetPendingRequestsAsync();
        return requests.Select(MapToDto);
    }

    public async Task<IEnumerable<PolicyRequestResponseDto>> GetUserRequestsAsync(Guid userId)
    {
        var requests = await _repository.GetUserRequestsAsync(userId);
        return requests.Select(MapToDto);
    }

    public async Task<PolicyRequestResponseDto> CompleteRequestAsync(CompletePolicyRequestDto input)
    {
        var entity = await _repository.GetByIdAsync(input.RequestId);
        if (entity == null)
        {
            throw new KeyNotFoundException("Talep bulunamadı.");
        }

        entity.DummyPrice = input.DummyPrice;
        entity.AdminNote = input.AdminNote;
        entity.Status = input.Status;
        entity.UpdatedAt = DateTime.UtcNow;

        await _repository.SaveChangesAsync();

        return MapToDto(entity);
    }

    private static PolicyRequestResponseDto MapToDto(PolicyRequest entity)
    {
        return new PolicyRequestResponseDto
        {
            Id = entity.Id,
            PolicyId = entity.PolicyId,
            UserId = entity.UserId,
            RequestType = entity.RequestType,
            Status = entity.Status,
            Description = entity.Description,
            DummyPrice = entity.DummyPrice,
            AdminNote = entity.AdminNote,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt
        };
    }
}