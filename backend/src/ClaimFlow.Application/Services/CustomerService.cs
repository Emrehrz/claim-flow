using ClaimFlow.Application.DTOs.Customer;
using ClaimFlow.Application.Interfaces;
using ClaimFlow.Application.Interfaces.Data;
using Mapster;

namespace ClaimFlow.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly IUserRepository _userRepository;

    public CustomerService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<CustomerDto> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(id, cancellationToken);
        if (user == null)
            throw new KeyNotFoundException("Customer not found.");

        return user.Adapt<CustomerDto>();
    }

    public async Task<CustomerDto> UpdateCustomerAsync(Guid id, UpdateCustomerDto dto, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(id, cancellationToken);
        if (user == null)
            throw new KeyNotFoundException("Customer not found.");

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;

        await _userRepository.UpdateAsync(user, cancellationToken);

        return user.Adapt<CustomerDto>();
    }
}
