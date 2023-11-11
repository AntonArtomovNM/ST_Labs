using Domain.Entities;

namespace UI.Models;

public record WaiterDto(string FirstName, string LastName, string PhoneNumber, DateTime DateOfBirth, decimal Salary, byte Rating)
{
    public int? Id { get; private set; }

    public ICollection<CustomerDto>? Customers { get; private set; }

    public static WaiterDto FromEntity(Waiter entity)
    {
        var dto = new WaiterDto(
            entity.FirstName,
            entity.LastName,
            entity.PhoneNumber,
            entity.DateOfBirth,
            entity.Salary,
            entity.Rating);

        dto.SetId(entity.WaiterId);

        return dto;
    }

    public void SetId(int id)
    {
        if (!Id.HasValue)
        {
            Id = id;
        }
    }

    public void SetCustomers(IEnumerable<CustomerDto> customers)
    {
        if (Customers is null)
        {
            Customers = customers.ToList();
        }
    }
}