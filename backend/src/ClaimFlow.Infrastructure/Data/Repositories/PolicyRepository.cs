using ClaimFlow.Application.Interfaces.Data;
using ClaimFlow.Domain.Entities;
using ClaimFlow.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ClaimFlow.Infrastructure.Data.Repositories;

public class PolicyRepository : IPolicyRepository
    {
        private readonly AppDbContext _context;

        public PolicyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Policy>> GetPoliciesAsync(Guid? vehicleId, PolicyStatus? status)
        {
            var query = _context.Policies.AsQueryable();

            if (vehicleId.HasValue)
            {
                query = query.Where(p => p.VehicleId == vehicleId.Value);
            }

            if (status.HasValue)
            {
                query = query.Where(p => p.Status == status.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<Policy?> GetByIdAsync(Guid id)
        {
            return await _context.Policies
                .Include(p => p.Vehicle)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Policy policy)
        {
            await _context.Policies.AddAsync(policy);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Policy policy)
        {
            _context.Policies.Update(policy);
            await _context.SaveChangesAsync();
        }
    }


