using System;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Queries.Repositories;

internal class CustomerRepository : ICustomerRepository
{
    private readonly PizzeriaDbContext _dbContext;

    public CustomerRepository(PizzeriaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Customer customer)
    {
        if (customer is null)
        {
            throw new ArgumentNullException(nameof(customer));
        }

        _dbContext.Customers.Add(customer);

        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Customer customer)
    {
        if (customer is null)
        {
            throw new ArgumentNullException(nameof(customer));
        }

        var previousCustomer = await _dbContext.Customers
            .Where(x => x.CustomerId == customer.CustomerId)
            .SingleOrDefaultAsync();

        if (previousCustomer is null)
        {
            throw new ArgumentException($"Customer with id {customer.CustomerId} was not found");
        }

        previousCustomer.UpdatePersonalData(customer.FirstName, customer.LastName, customer.PhoneNumber, customer.DateOfBirth);
        previousCustomer.SetNewWaiter(customer.WaiterId);

        _dbContext.Customers.Update(previousCustomer);

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

    public async Task<Customer?> Get(int customerId, bool shouldLoadWaiter = false)
    {
        var query = _dbContext.Customers
            .Where(x => x.CustomerId == customerId)
            .AsNoTracking();

        if (shouldLoadWaiter)
        {
            query = query
                .Include(x => x.Waiter)
                .AsNoTracking();
        }

        return await query.SingleOrDefaultAsync();
    }

    public async Task<IList<Customer>> GetAll()
    {
        return await _dbContext.Customers
            .AsNoTracking()
            .ToListAsync();
    }
}
