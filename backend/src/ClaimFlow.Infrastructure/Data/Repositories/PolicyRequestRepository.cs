using System;
using System.Threading;
using System.Threading.Tasks; 
using ClaimFlow.Application.Interfaces.Data;
using ClaimFlow.Domain.Entities;
using ClaimFlow.Domain.Enums;
using ClaimFlow.Infrastructure.Data; // DbContext namespace'iniz
using Microsoft.EntityFrameworkCore;

namespace ClaimFlow.Infrastructure.Repositories;

public class PolicyRequestRepository : IPolicyRequestRepository
{
    private readonly AppDbContext _context; // DbContext sınıfınızın adı

    public PolicyRequestRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> HasActiveRequestAsync(Guid policyId)
    {
        return await _context.PolicyRequests
            .AnyAsync(r => r.PolicyId == policyId && r.Status == PolicyRequestStatus.Pending);
    }

    public async Task AddAsync(PolicyRequest request)
    {
        await _context.PolicyRequests.AddAsync(request);
    }

    public async Task<PolicyRequest?> GetByIdAsync(Guid id)
    {
        return await _context.PolicyRequests.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<IEnumerable<PolicyRequest>> GetPendingRequestsAsync()
    {
        return await _context.PolicyRequests
            .Where(r => r.Status == PolicyRequestStatus.Pending)
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<PolicyRequest>> GetUserRequestsAsync(Guid userId)
    {
        return await _context.PolicyRequests
            .Where(r => r.UserId == userId)
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}