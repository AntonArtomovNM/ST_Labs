using SimpleInjector;
using Queries;
using SimpleInjector.Diagnostics;
using UI.Services.Forms;
using UI.Services.Customers;
using UI.Services.Waiters;

namespace UI;

public static class IoC
{
    public static void RegisterDependencies(this Container container)
    {
        container.RegisterRepositories();

        RegisterServices(container);

        AutoRegisterForms(container);
    }

    private static void RegisterServices(Container container)
    {
        container.Register<IFormOpener, FormOpener>(Lifestyle.Singleton);

        container.Register<ICustomerManagementService, CustomerManagementService>(Lifestyle.Transient);
        container.Register<IWaiterManagementService, WaiterManagementService>(Lifestyle.Transient);
    }

    private static void AutoRegisterForms(Container container)
    {
        var types = container.GetTypesToRegister<Form>(typeof(IoC).Assembly);

        foreach (var type in types)
        {
            var registration =
                Lifestyle.Transient.CreateRegistration(type, container);

            registration.SuppressDiagnosticWarning(
                DiagnosticType.DisposableTransientComponent,
                "Forms should be disposed by app code; not by the container.");

            container.AddRegistration(type, registration);
        }
    }

}
