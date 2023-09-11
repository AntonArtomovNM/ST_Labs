using Domain.Models.ValueObjects;

namespace Domain.Models.Entities;

public class AutomatedTellerMachine : BalanceEntity
{
    public Guid BankId { get; }

    public Address Address { get; }

    public AutomatedTellerMachine(
        Address address,
        Guid bankId)
    {
        if (address is null)
        {
            throw new ArgumentNullException(nameof(address));
        }

        Address = address;
        BankId = bankId;
    }
}
