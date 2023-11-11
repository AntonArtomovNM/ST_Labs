using UI.Models;

namespace UI.Services.Customers;

public interface ICustomerManagementService
{
    Task<CustomerDto> Add(CustomerDto customer);

    Task<CustomerDto> Update(CustomerDto customer);

    Task<bool> Remove(CustomerDto customer);

    Task<IList<CustomerDto>> GetAll();

    Task<CustomerDto?> GetDetails(int id);
}
