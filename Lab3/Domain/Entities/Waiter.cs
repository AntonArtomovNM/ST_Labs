using Domain.Entities.Contracts;

namespace Domain.Entities;

public class Waiter : PersonalDataEntity
{
    public int WaiterId { get; private set; }

    public decimal Salary { get; set; }

    public byte Rating { get; set; }

    public ICollection<Customer> Customers { get; private set; } = new List<Customer>();

    private Waiter()
    {
    }

    public Waiter(
        string firstName,
        string lastName,
        string phoneNumber,
        DateTime dateOfBirth,
        decimal salary,
        byte rating)
    : base(firstName, lastName, phoneNumber, dateOfBirth)
    {
        Salary = salary;
        Rating = rating;
    }
}
