using Domain.Models.ValueObjects;

namespace Domain.Models.Entities;

public class AutomatedTellerMachine : BalanceEntity
{
    public Guid BankId { get; }

    public Coordinates Coordinates { get; }

    public AutomatedTellerMachine(
        Guid bankId,
        Coordinates coordinates)

    {
        BankId = bankId;
        Coordinates = coordinates;
    }
}
