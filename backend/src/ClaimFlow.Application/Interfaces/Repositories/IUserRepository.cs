using ClaimFlow.Domain.Entities;

namespace ClaimFlow.Application.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<User> UpdateCustomerAsync(User user, CancellationToken cancellationToken = default);
}