using Domain.Models.ValueObjects;

namespace Domain.Models.Entities;

public class Account : BalanceEntity
{
    public Guid BankId { get; }

    public CardNumber CardNumber { get; }

    public Pincode Pincode { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public Account(
        Guid bankId,
        CardNumber cardNumber,
        Pincode pincode,
        string firstName,
        string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentNullException(nameof(firstName));
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentNullException(nameof(lastName));
        }

        BankId = bankId;
        CardNumber = cardNumber;
        Pincode = pincode;
        FirstName = firstName;
        LastName = lastName;
    }

    public bool Authenticate(Pincode pincode)
    {
        return Pincode == pincode;
    }
}
