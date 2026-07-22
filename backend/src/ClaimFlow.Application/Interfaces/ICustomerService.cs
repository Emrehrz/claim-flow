using ClaimFlow.Application.DTOs.Customer;

namespace ClaimFlow.Application.Interfaces;

public interface ICustomerService
{
    Task<CustomerDto> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<CustomerDto> UpdateCustomerAsync(Guid id, UpdateCustomerDto dto, CancellationToken cancellationToken = default);
}
