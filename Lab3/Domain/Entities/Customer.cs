using Domain.Entities.Contracts;

namespace Domain.Entities;

public class Customer : PersonalDataEntity
{
    public int CustomerId { get; set; }

    public int? WaiterId { get; set; }

    public Waiter? Waiter { get; set; }

    private Customer()
    {
    }

    public Customer(
        string firstName,
        string lastName,
        string phoneNumber,
        DateTime dateOfBirth)
    : base(firstName, lastName, phoneNumber, dateOfBirth)
    {
    }

    public void SetNewWaiter(int? waiterId)
    {
        if (WaiterId == waiterId)
        {
            return;
        }

        WaiterId = waiterId;
        Waiter = null;
    }
}
