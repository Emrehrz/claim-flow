using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClaimFlow.Application.DTOs.Policy;
using ClaimFlow.Domain.Enums;

namespace ClaimFlow.Application.Interfaces
{
    public interface IPolicyService
    {
        Task<IEnumerable<PolicyDto>> GetPoliciesAsync(Guid? vehicleId, PolicyStatus? status);
        Task<PolicyDto> CreatePolicyAsync(CreatePolicyDto createDto);
        Task<PolicyDto> UpdatePolicyAsync(Guid id, UpdatePolicyDto updateDto);
        Task ChangeStatusAsync(Guid id, PolicyStatus status);
    }
}