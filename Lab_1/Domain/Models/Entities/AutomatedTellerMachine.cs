using System.Text;
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

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"Id: {Id}");
        stringBuilder.AppendLine($"Balance: {CurrentBalance}");
        stringBuilder.AppendLine($"Coordinates: [{Coordinates.X}; {Coordinates.Y}]");

        return stringBuilder.ToString();
    }
}
