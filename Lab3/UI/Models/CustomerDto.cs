using Domain.Entities;

namespace UI.Models;

public record CustomerDto(string FirstName, string LastName, string PhoneNumber, DateTime DateOfBirth)
{
    public int? Id { get; private set; }

    public WaiterDto? Waiter { get; private set; }

    public static CustomerDto FromEntity(Customer entity)
    {
        var dto = new CustomerDto(
            entity.FirstName,
            entity.LastName,
            entity.PhoneNumber,
            entity.DateOfBirth);

        dto.SetId(entity.CustomerId);

        return dto;
    }

    public void SetId(int id)
    {
        if (!Id.HasValue)
        {
            Id = id;
        }
    }

    public void SetWaiter(WaiterDto? waiter)
    {
        Waiter = waiter;
    }
}