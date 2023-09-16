using Domain.Models.Exceptions;

namespace Domain.Models.Entities;

public abstract class BalanceEntity : Entity
{
    public decimal CurrentBalance { get; private set; }

    public decimal AvailableBalance { get; private set; }

    public void Deposit(decimal amount)
    {
        if (CurrentBalance != AvailableBalance)
        {
            throw new ValidationException($"{GetType().Name} balance operation is already in progress");
        }

        AvailableBalance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (CurrentBalance != AvailableBalance)
        {
            throw new ValidationException($"{GetType().Name} balance operation is already in progress");
        }

        if (AvailableBalance < amount)
        {
            throw new InsufficientBalanceException($"{GetType().Name} balance is insufficient. Available balance: {AvailableBalance}, Amount: {amount}");
        }

        AvailableBalance -= amount;
    }

    public void SaveBalanceChange()
    {
        CurrentBalance = AvailableBalance;
    }

    public void CancelBalanceChange()
    {
        AvailableBalance = CurrentBalance;
    }
}
