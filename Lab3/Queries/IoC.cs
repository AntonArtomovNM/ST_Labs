using Domain.Repositories;
using Queries.Repositories;
using SimpleInjector;

namespace Queries;

public static class IoC
{
    public static void RegisterRepositories(this Container container)
    {
        container.Register<PizzeriaDbContext>(Lifestyle.Singleton);

        container.Register<ICustomerRepository, CustomerRepository>();
        container.Register<IWaiterRepository, WaiterRepository>();
    }
}
