using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Queries.Repositories;

internal class WaiterRepository : IWaiterRepository
{
    private readonly PizzeriaDbContext _dbContext;

    public WaiterRepository(PizzeriaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Waiter waiter)
    {
        if (waiter is null)
        {
            throw new ArgumentNullException(nameof(waiter));
        }

        _dbContext.Waiters.Add(waiter);

        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Waiter waiter)
    {
        if (waiter is null)
        {
            throw new ArgumentNullException(nameof(waiter));
        }

        var previousWaiter = await _dbContext.Waiters
            .Where(x => x.WaiterId == waiter.WaiterId)
            .SingleOrDefaultAsync();

        if (previousWaiter is null)
        {
            throw new ArgumentException($"Waiter with id {waiter.WaiterId} was not found");
        }

        previousWaiter.UpdatePersonalData(waiter.FirstName, waiter.LastName, waiter.PhoneNumber, waiter.DateOfBirth);

        _dbContext.Waiters.Update(previousWaiter);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> Remove(int customerId)
    {
        var customer = await _dbContext.Customers
            .Where(x => x.CustomerId == customerId)
            .SingleOrDefaultAsync();

        if (customer is null)
        {
            return false;
        }

        _dbContext.Customers.Remove(customer);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<Waiter?> Get(int waiterId, bool shouldLoadCustomers = false)
    {
        var query = _dbContext.Waiters
            .AsNoTracking()
            .Where(x => x.WaiterId == waiterId);

        if (shouldLoadCustomers)
        {
            query.Include(x => x.Customers);
        }

        return await query.SingleOrDefaultAsync();

    }

    public async Task<IList<Waiter>> GetAll()
    {
        return await _dbContext.Waiters
            .AsNoTracking()
            .ToListAsync();
    }
}
