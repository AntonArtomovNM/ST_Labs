using Domain.Entities;
using Domain.Repositories;
using UI.Models;

namespace UI.Services.Customers;

public class CustomerManagementService : ICustomerManagementService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerManagementService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CustomerDto> Add(CustomerDto customer)
    {
        if (customer is null)
        {
            throw new ArgumentNullException(nameof(customer));
        }

        Customer entity = MapToEntity(customer);

        await _customerRepository.Add(entity);

        return CustomerDto.FromEntity(entity);
    }

    public async Task<CustomerDto> Update(CustomerDto customer)
    {
        if (customer is null)
        {
            throw new ArgumentNullException(nameof(customer));
        }

        if (customer.Id is null)
        {
            throw new ArgumentNullException("customer.Id");
        }

        var entity = MapToEntity(customer);

        await _customerRepository.Update(entity);

        return CustomerDto.FromEntity(entity);
    }

    public async Task<bool> Remove(CustomerDto customer)
    {
        if (customer is null)
        {
            throw new ArgumentNullException(nameof(customer));
        }

        if (customer.Id is null)
        {
            throw new ArgumentNullException("customer.Id");
        }

        return await _customerRepository.Remove(customer.Id.Value);
    }

    public async Task<IList<CustomerDto>> GetAll()
    {
        var entities = await _customerRepository.GetAll();

        return entities
            .Select(CustomerDto.FromEntity)
            .ToList();
    }

    public async Task<CustomerDto?> GetDetails(int id)
    {
        var entity = await _customerRepository.Get(id, shouldLoadWaiter: true);

        if (entity is null)
        {
            return null;
        }

        var customerDto = CustomerDto.FromEntity(entity);

        var waiterDto = entity.Waiter is null
            ? null
            : WaiterDto.FromEntity(entity.Waiter);

        customerDto.SetWaiter(waiterDto);

        return customerDto;
    }

    private Customer MapToEntity(CustomerDto dto)
    {
        var entity = new Customer(
            dto.FirstName,
            dto.LastName,
            dto.PhoneNumber,
            dto.DateOfBirth);

        entity.CustomerId = dto.Id.GetValueOrDefault();

        if (dto.Waiter is not null)
        {
            entity.WaiterId = dto.Waiter.Id;
        }

        return entity;
    }
}
