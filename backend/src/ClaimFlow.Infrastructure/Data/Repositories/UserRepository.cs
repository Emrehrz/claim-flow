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

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Users.FindAsync(new object[] { id }, cancellationToken);
    }

    public Task UpdateAsync(User user, CancellationToken cancellationToken = default)
    {
        _context.Users.Update(user);
        return _context.SaveChangesAsync(cancellationToken);
    }
}
