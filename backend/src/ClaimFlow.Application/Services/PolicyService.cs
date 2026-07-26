using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClaimFlow.Application.DTOs.Policy; 
using ClaimFlow.Application.Interfaces;
using ClaimFlow.Application.Interfaces.Data;
using ClaimFlow.Domain.Entities;
using ClaimFlow.Domain.Enums;
using Mapster;

namespace ClaimFlow.Application.Services;

public class PolicyService : IPolicyService
{
    private readonly IPolicyRepository _policyRepository;

    public PolicyService(IPolicyRepository policyRepository)
    {
      _policyRepository = policyRepository;
    }

    public async Task <IEnumerable<PolicyDto>> GetPoliciesAsync ( Guid? vehicleId, PolicyStatus? status )
    {
      var policies = await _policyRepository.GetPoliciesAsync(vehicleId, status);
      return policies.Adapt<IEnumerable<PolicyDto>>();
    }

    public async Task<PolicyDto> CreatePolicyAsync(CreatePolicyDto createDto)
        {
            var policy = createDto.Adapt<Policy>();
            policy.Id = Guid.NewGuid();
            policy.Status = PolicyStatus.Active; // Yeni poliçe varsayılan olarak aktiftir

            await _policyRepository.AddAsync(policy);

            return policy.Adapt<PolicyDto>();
        }

        public async Task<PolicyDto> UpdatePolicyAsync(Guid id, UpdatePolicyDto updateDto)
        {
            var policy = await _policyRepository.GetByIdAsync(id);
            if (policy == null)
                throw new KeyNotFoundException("Policy not found.");

            // Manuel güncelleme
            policy.EndDate = updateDto.EndDate;
            policy.CoverageSummary = updateDto.CoverageSummary;
            policy.Status = updateDto.Status;

            await _policyRepository.UpdateAsync(policy);

            return policy.Adapt<PolicyDto>();
        }

        public async Task ChangeStatusAsync(Guid id, PolicyStatus status)
        {
            var policy = await _policyRepository.GetByIdAsync(id);
            if (policy == null)
                throw new KeyNotFoundException("Policy not found.");

            policy.Status = status;
            await _policyRepository.UpdateAsync(policy);
        }
    }