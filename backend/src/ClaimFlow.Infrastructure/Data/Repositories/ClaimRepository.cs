using ClaimFlow.Application.Interfaces.Data;
using ClaimFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ClaimFlow.Domain.Enums;
using ClaimFlow.Infrastructure.Data;

namespace ClaimFlow.Infrastructure.Data.Repositories;

public class ClaimRepository : IClaimRepository
{
    private readonly AppDbContext _context;

    public ClaimRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Claim?> GetByIdAsync(Guid id)
    {
        return await _context.Claims
            .Include(c => c.Policy) // Poliçe detaylarına erişim için Join işlemi
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Claim>> GetClaimsByPolicyIdAsync(Guid policyId)
    {
        return await _context.Claims
            .Where(c => c.PolicyId == policyId)
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<Claim>> GetClaimsAsync(Guid? policyId, ClaimStatus? status)
    {
        var query = _context.Claims
            .Include(c => c.Policy)
            .AsQueryable();

        if (policyId.HasValue)
        {
            query = query.Where(c => c.PolicyId == policyId.Value);
        }

        if (status.HasValue)
        {
            query = query.Where(c => c.Status == status.Value);
        }

        return await query
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();
    }

    public async Task AddAsync(Claim claim)
    {
        await _context.Claims.AddAsync(claim);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Claim claim)
    {
        _context.Claims.Update(claim);
        await _context.SaveChangesAsync();
    }
}