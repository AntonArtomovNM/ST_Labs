using Domain.Entities;

namespace Domain.Repositories;

public interface IWaiterRepository
{
    Task Add(Waiter waiter);

    Task Update(Waiter waiter);

    Task<bool> Remove(int waiterId);

    Task<Waiter?> Get(int waiterId, bool shouldLoadCustomers = false);

    Task<IList<Waiter>> GetAll();
}
