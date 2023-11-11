using UI.Models;

namespace UI.Services.Waiters;

public interface IWaiterManagementService
{
    Task<WaiterDto> Add(WaiterDto waiter);

    Task<WaiterDto> Update(WaiterDto waiter);

    Task<bool> Remove(WaiterDto waiter);

    Task<IList<WaiterDto>> GetAll();

    Task<WaiterDto?> GetDetails(int id);
}
