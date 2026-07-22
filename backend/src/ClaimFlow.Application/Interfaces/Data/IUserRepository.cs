using ClaimFlow.Domain.Entities;

namespace ClaimFlow.Application.Interfaces.Data;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task UpdateAsync(User user, CancellationToken cancellationToken = default);
}
