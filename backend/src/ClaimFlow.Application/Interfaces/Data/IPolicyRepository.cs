using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClaimFlow.Domain.Entities;
using ClaimFlow.Domain.Enums;

namespace ClaimFlow.Application.Interfaces.Data
{
    public interface IPolicyRepository
    {
        Task<IEnumerable<Policy>> GetPoliciesAsync(Guid? vehicleId, PolicyStatus? status);
        Task<Policy?> GetByIdAsync(Guid id);
        Task AddAsync(Policy policy);
        Task UpdateAsync(Policy policy);
    }
}