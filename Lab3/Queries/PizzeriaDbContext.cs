using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Queries.Options;

namespace Queries;

public class PizzeriaDbContext : DbContext
{
    public DbSet<Waiter> Waiters { get; set; }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(DbOptions.SqlConnectionString);
    }
}
