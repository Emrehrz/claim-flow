using System;
using System.Threading;
using System.Threading.Tasks;
using ClaimFlow.Application.Interfaces.Data;
using ClaimFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClaimFlow.Infrastructure.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public async Task UpdateAsync(User user, CancellationToken cancellationToken = default)
    {
        _context.Set<User>().Update(user);
        await _context.SaveChangesAsync(cancellationToken);
    }
}