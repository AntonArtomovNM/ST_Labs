using Domain.Entities;

namespace Domain.Repositories;

public interface ICustomerRepository
{
    Task Add(Customer customer);

    Task Update(Customer customer);

    Task<bool> Remove(int customerId);

    Task<Customer?> Get(int customerId, bool shouldLoadWaiter = false);

    Task<IList<Customer>> GetAll();
}
